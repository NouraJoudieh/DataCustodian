using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelOne : MonoBehaviour
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
    private bool canBeAnswered;
    public TextMeshProUGUI wrongAnswer;
    public static int finalScore;
    public static int counter;
    private string user;

    
    void Start()
    {
        counter++;
        if(counter == 1)
        StartCoroutine(HelpFirst());
        query = new List<KeywordMetaData>();
        wholequery = new List<KeywordMetaData>();
        canBeAnswered = false;
        user = GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Username;
        GameObject.Find("Music").GetComponent<AudioSource>().Stop();
    }

    IEnumerator HelpFirst() {
        HelpOverlay.SetActive(true);
        yield return new WaitForSeconds(5);
        HelpOverlay.SetActive(false);
    }
 
    public void Restart() {
        SceneManager.LoadScene("LevelOne");
    }
    public void NextLevel ()
    {
        GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Level = 2;
        string user = GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Username;
        PlayerPrefs.SetInt("level" + user, 2);
        SceneManager.LoadScene("LevelTwo");
    }

    private int Score() {
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

        if (q.Count == 4
            && q[0].keywordName == "Select"
            && q[3].keywordName == "Student"
            && q[2].keywordName == "From"
            && q[1].keywordName == "all")
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
            if (q.Count == 4 && (q[0].keywordName != "Select" || q[2].keywordName != "From" && q[3].keywordName != "Student"))
            {
                wrongAnswer.text = "Your question is not understandable! " +
                   "Keep in mind that the blue puzzle pieces are main keywords" +
                   " that should always be at the beginning of the line";
                UILevelOne.finalScore -= 30;
            }
            else if (q.Count != 4)
            {
                UILevelOne.finalScore -= 30;
                wrongAnswer.text = "Your question is incomplete! " +
                    "Complete the puzzle..";
            }

            return false;
        }

    }
   
    public void ViewResults()
    {
        
        ClearResults();

        spacing = 0;
        //level One query is select id,firstname,lastname,email,age from students
        HelpOverlay.SetActive(false);
        TableOverlay.SetActive(false);
        ResultOverlay.SetActive(true);
        for (int i = 0; i < queryField.transform.childCount; i++)
        {
            for (int j = 0; j < queryField.transform.GetChild(i).childCount; j++)
            {
                KeywordMetaData k = new KeywordMetaData(queryField.transform.GetChild(i).GetChild(j).tag.Split('-')[0], queryField.transform.GetChild(i).GetChild(j).tag.Split('-')[1]);
                wholequery.Add(k);

            }
        }
        KeywordMetaData key = new KeywordMetaData("id","Sel");
        KeywordMetaData key1 = new KeywordMetaData("firstname","Sel");
        KeywordMetaData key2 = new KeywordMetaData("lastname","Sel");
        KeywordMetaData key3 = new KeywordMetaData("email","Sel");
        KeywordMetaData key4 = new KeywordMetaData("age","Sel");
        query.Add(key);
        query.Add(key1);
        query.Add(key2);
        query.Add(key3);
        query.Add(key4);


        if (!ValidateQuery(wholequery))
        {
            ClearResults();
            AlternativeQuery.SetActive(true);
            CorrectQuery.SetActive(false);
           
        }
        else
        {
           
            AlternativeQuery.SetActive(false);
            CorrectQuery.SetActive(true);
            int c= Score();
            Debug.Log("Level One "+user);
            PlayerPrefs.SetInt("LevelColor1"+user, c);
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



    public void ClearResults() {
        var rows = Table.transform.childCount;
        for (int i = 3; i < rows; i++)
        {
            Destroy(Table.transform.GetChild(i).gameObject);
        }
    }

   
    

}

