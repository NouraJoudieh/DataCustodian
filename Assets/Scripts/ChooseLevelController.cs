using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLevelController : MonoBehaviour
{
    public GameObject LevelPanel;
    int levelReached;
    string user;

    void Start()
    {
        levelReached = GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Level;
        user = GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Username;
        

        for (int i = 1; i <= levelReached; i++)
        {
            int color = PlayerPrefs.GetInt("LevelColor"+i+user);
            LevelPanel.transform.GetChild(i - 1).GetComponent<Button>().interactable = true;
            if(color == 1)
                LevelPanel.transform.GetChild(i - 1).GetComponent<Image>().color = Color.red;
            else if(color == 2)
                LevelPanel.transform.GetChild(i - 1).GetComponent<Image>().color = Color.yellow;
            else if(color == 3)
                LevelPanel.transform.GetChild(i - 1).GetComponent<Image>().color = new Color(1.00f, 0.60f, 0.00f, 1.00f);
            else if(color == 4)LevelPanel.transform.GetChild(i - 1).GetComponent<Image>().color = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back() {
        SceneManager.LoadScene("MainScene");
    }
    public void LevelOne() {
        UILevelOne.counter = 0;
        UILevelOne.finalScore = 100;
        SceneManager.LoadScene("LevelOne");
    }
    public void LevelTwo()
    {
        UI.counter = 0;
        UI.finalScore = 100;
        SceneManager.LoadScene("LevelTwo");
    }
    public void LevelThree()
    {
        UILeveThree.counter = 0;
        UILeveThree.finalScore = 100;
        SceneManager.LoadScene("LevelThree");
    }
}
