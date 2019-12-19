using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class UILeveThree : MonoBehaviour
{

    public GameObject queryField;
    public GameObject TableOverlay;
    public GameObject HelpOverlay;
    public GameObject InfoOverlay;
    public GameObject ResultOverlay;
    public GameObject Table;
    public GameObject Row;
    public GameObject AlternativeQuery;
    public GameObject CorrectQuery;
    public GameObject Star40;
    public GameObject StarUnder40;
    public GameObject Star70;
    public GameObject Star100;
    public TextMeshProUGUI wrongAnswer;
    private bool canBeAnswered;
    private bool goCoroutine;
    private List<KeywordMetaData> query;
    private List<KeywordMetaData> wholequery;
    private float spacing;
    public static int finalScore;
    public static int counter;
    private string user;
    void Start()
    {
        counter++;
        if (counter == 1)
            StartCoroutine(HelpFirst());
    
        query = new List<KeywordMetaData>();
        wholequery = new List<KeywordMetaData>();
        canBeAnswered = false;
        goCoroutine = false;
        user = GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Username;
        GameObject.Find("Music").GetComponent<AudioSource>().Stop();

    }

    IEnumerator HelpFirst()
    {

        HelpOverlay.SetActive(true);
        yield return new WaitForSeconds(5);
        HelpOverlay.SetActive(false);
    }
    public void NextLevel()
    {//levelThree
        GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Level = 4;
        string user = GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Username;
        PlayerPrefs.SetInt("level" + user, 4);
        SceneManager.LoadScene("LevelThree");  //level4
    }

 
    public void Restart()
    {
        SceneManager.LoadScene("LevelThree");
    }

    private int Score()
    {
        int color = 0;
        if (finalScore < 40)
        {
            color = 1;
            StarUnder40.SetActive(true);
        }
        if (finalScore >= 40)
        {
            color = 2;
            Star40.SetActive(true);
        }
        if (finalScore >= 70)
        {
            Star70.SetActive(true);
            color = 3;
        }
        if (finalScore >= 100)
        {
            Star100.SetActive(true);
            color = 4;
        }
        return color;
    }

    private bool ValidateQuery(List<KeywordMetaData> q)
    {

        if (q.Count == 9
            && q[0].keywordName == "Select"
            && q[1].keywordName == "cname"
            && q[2].keywordName == "credits"
            && q[3].keywordName == "From"
            && q[4].keywordName == "Course"
            && q[5].keywordName == "Where"
            && q[6].keywordName == "credits"
            && q[7].keywordName == ">="
            && q[8].keywordName == "5")
        {
            canBeAnswered = true;
            return true;
        }

        else
                if (q.Count == 0)
        {
            wrongAnswer.text = "Start constructing your question!";
            return false;
        }
        else
        {
            if (q.Count == 9 && q[0].keywordName == "Select" && q[3].keywordName == "From" && q[4].keywordName == "Course")
            {//if i'm here then the query is constructed correctly but with a wrong order
                wrongAnswer.text = "You are half way there! " +
                    "Try reordering the green puzzle pieces to get the exact required report";
                UILeveThree.finalScore -= 10;
                canBeAnswered = true;
                goCoroutine = true;
            }
            else if (q.Count != 9)
            {

                wrongAnswer.text = "Your question is incomplete! " +
                    "Complete the puzzle..";
                UILeveThree.finalScore -= 30;
            }
            else
            {

                wrongAnswer.text = "Your question is not understandable! " +
                    "Keep in mind that the blue puzzle pieces are main keywords" +
                    " that should always be at the beginning of the line";
                UILeveThree.finalScore -= 30;
            }

            return false;
        }

    }
    IEnumerator HalfValid()
    {
        AlternativeQuery.SetActive(true);
        CorrectQuery.SetActive(false);
        yield return new WaitForSeconds(2);
        AlternativeQuery.SetActive(false);
    }

   
    public void ViewResults()
    {
        spacing = 0;
        HelpOverlay.SetActive(false);
        TableOverlay.SetActive(false);
        ResultOverlay.SetActive(true);
        if (queryField.transform.GetChild(0).childCount > 0 || queryField.transform.GetChild(1).childCount > 0 || queryField.transform.GetChild(2).childCount > 0)
        {

            for (int i = 0; i < queryField.transform.childCount; i++)
            {
                for (int j = 0; j < queryField.transform.GetChild(i).childCount; j++)
                {
                   
                    KeywordMetaData key = new KeywordMetaData(queryField.transform.GetChild(i).GetChild(j).tag.Split('-')[0], queryField.transform.GetChild(i).GetChild(j).tag.Split('-')[1]);

                    if (key.isAttribute)
                    {
                        query.Add(key); //to get data for
                    }
                   
                    wholequery.Add(key); //for validating the query 
                }
            }
            
        }
        if (!ValidateQuery(wholequery))
        {

            if (goCoroutine)
            {
                StartCoroutine(HalfValid());
            }
            else
            {
                ClearResults();
                AlternativeQuery.SetActive(true);
                CorrectQuery.SetActive(false);
                
            }

        }
        else
        {
            AlternativeQuery.SetActive(false);
            CorrectQuery.SetActive(true);
            int c = Score();
            PlayerPrefs.SetInt("LevelColor3"+user, c);
            PlayerPrefs.Save();
        }
        if (canBeAnswered)
        {
            for (int u = 0; u < query.Count; u++)
            {
                Table.transform.GetChild(0).GetChild(u).GetComponent<TextMeshProUGUI>().SetText(query[u].keywordName);
            }
          

            for (int i = 0; i < query[0].result.Count; i++)
            {
                var row = Instantiate(Row, Table.transform);
                row.GetComponent<RectTransform>().position = new Vector2(Table.transform.GetChild(2).GetComponent<RectTransform>().position.x, Table.transform.GetChild(2).GetComponent<RectTransform>().position.y - spacing);
                //Apply Where Condition
                if (Int32.Parse(query[1].result[i]) >= 5)
                {
                    spacing += 41;
                    row.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(query[0].result[i]);//cname
                    row.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(query[1].result[i]);//credits
                }

            }
        }
        query = new List<KeywordMetaData>();
        wholequery = new List<KeywordMetaData>();
    }

    public void ClearResults()
    {
        var rows = Table.transform.childCount;
        for (int i = 3; i < rows; i++)
        {
            Destroy(Table.transform.GetChild(i).gameObject);
        }
    }

}

