
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//levelTwo
public class UI : MonoBehaviour
{
    public GameObject queryField;
    private List<KeywordMetaData> query;
    private List<KeywordMetaData> wholequery;
    private float spacing;
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
    private string user;
    public static int finalScore;
    public static int counter;

    void Start()
    {
        counter++;
        if(counter == 1)
        StartCoroutine(HelpFirst());
        
        query = new List<KeywordMetaData>();
        wholequery = new List<KeywordMetaData>();
        canBeAnswered = false;
        goCoroutine = false;
        
        user = GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Username;
        GameObject.Find("Music").GetComponent<AudioSource>().Stop();
       
    }

   public IEnumerator HelpFirst()
    {

        HelpOverlay.SetActive(true);
        yield return new WaitForSeconds(5);
        HelpOverlay.SetActive(false);
    }
    public void NextLevel()
    {
        GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Level = 3;
        PlayerPrefs.SetInt("level" + user, 3);
        SceneManager.LoadScene("LevelThree");  
    }

 
    public void Restart() {
        SceneManager.LoadScene("LevelTwo");
    }

    private int Score()
    {
        int color = 0;
        if (UI.finalScore < 40) {
            color = 1;
            StarUnder40.SetActive(true);
        }
            
        if (UI.finalScore >= 40)
        {
            color = 2;
            Star40.SetActive(true);
        }
        if (UI.finalScore >= 70)
        {
            Star70.SetActive(true);
            color = 3;
        }
        if (UI.finalScore >= 100)
        {
            Star100.SetActive(true);
            color = 4;
        }
        return color;
    }

    private bool ValidateQuery(List<KeywordMetaData> q)
    {

        if (q.Count == 8
            && q[0].keywordName == "Select"
            && q[7].keywordName == "Student"
            && q[6].keywordName == "From"
            && q[1].keywordName == "id"
            && q[2].keywordName == "firstname"
            && q[3].keywordName == "lastname"
            && q[4].keywordName == "email"
            && q[5].keywordName == "age") {
            canBeAnswered = true;
               return true;
        }
        
        else
                if (q.Count==0)
        {
            wrongAnswer.text = "Start constructing your question!";
            return false;
        }
        else
        {
            if (q.Count == 8 && q[0].keywordName == "Select" && q[6].keywordName == "From" && q[7].keywordName == "Student")
            {
                wrongAnswer.text = "You are half way there! " +
                    "Try reordering the green puzzle pieces to get the exact required report";
                canBeAnswered = true;
                UI.finalScore -= 10;
                goCoroutine = true;
            }
            else if (q.Count != 8)
            {
                    
                wrongAnswer.text = "Your question is incomplete! " +
                    "Complete the puzzle..";
                UI.finalScore -= 30;
            }
            else
            {

                wrongAnswer.text = "Your question is not understandable! " +
                    "Keep in mind that the blue puzzle pieces are main keywords" +
                    " that should always be at the beginning of the line";
                UI.finalScore -= 30;
            }

            return false;
        }

    }
     IEnumerator HalfValid() {
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
        if (queryField.transform.GetChild(0).childCount > 0 || queryField.transform.GetChild(1).childCount > 0)
        {
         
            for (int i = 0; i < queryField.transform.childCount; i++)
            {
                for (int j = 0; j < queryField.transform.GetChild(i).childCount; j++)
                {
                    KeywordMetaData key = new KeywordMetaData(queryField.transform.GetChild(i).GetChild(j).tag.Split('-')[0], queryField.transform.GetChild(i).GetChild(j).tag.Split('-')[1]);
                    if (key.isAttribute)
                    {
                        query.Add(key);
                    }
                    wholequery.Add(key);
                }
            }
        }
        if (!ValidateQuery(wholequery))
        {
            
            if (goCoroutine) {
                StartCoroutine(HalfValid());
            }
            else
            {
                ClearResults();
                AlternativeQuery.SetActive(true);
                CorrectQuery.SetActive(false);
            }

        }
        else {
            AlternativeQuery.SetActive(false);
            CorrectQuery.SetActive(true);
            int c = Score();
            Debug.Log("finalScore: "+UI.finalScore);
            PlayerPrefs.SetInt("LevelColor2"+user, c);
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
                spacing += 41;

                row.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(query[0].result[i]);
                row.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(query[1].result[i]);
                row.transform.GetChild(2).GetComponent<TextMeshProUGUI>().SetText(query[2].result[i]);
                row.transform.GetChild(3).GetComponent<TextMeshProUGUI>().SetText(query[3].result[i]);
                row.transform.GetChild(4).GetComponent<TextMeshProUGUI>().SetText(query[4].result[i]);

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
