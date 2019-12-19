using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle toggle;
    public Sprite Sound;
    public Sprite SoundOff;
    public GameObject SettingsOverlay;
    public GameObject HelpOverlay;
    public GameObject CreditsOverlay;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Music()
    {
        var music = GameObject.Find("Music");
        if (toggle.isOn)
        {
            //do the stuff when the toggle is on
            toggle.transform.GetChild(0).GetComponent<Image>().sprite=SoundOff;
            music.GetComponent<AudioSource>().mute = true;

        }
        else
        {
            //do the stuff when the toggle is off
            toggle.transform.GetChild(0).GetComponent<Image>().sprite = Sound;
            music.GetComponent<AudioSource>().mute = false;

        }

    }

    public void Exit() {
        GameObject.Find("PlayerInfo").GetComponent<PlayerData>().isLoggedIn = false;
        Application.Quit();
    }

    public void Help() {
        HelpOverlay.SetActive(true);
    }
    public void CloseHelp()
    {
        HelpOverlay.SetActive(false);
    }

    public void CloseSettings() {
        SettingsOverlay.SetActive(false);
    }

    public void OpenSettings() {
        SettingsOverlay.SetActive(true);
    }

    public void OpenCredits() {
        CreditsOverlay.SetActive(true);
    }
    public void CloseCredits()
    {
        CreditsOverlay.SetActive(false);
    }
    public void Play() {
        if (GameObject.Find("PlayerInfo").GetComponent<PlayerData>().isLoggedIn)
        {
            SceneManager.LoadScene("ChooseLevel");
        }
        else
        {
            SceneManager.LoadScene("LoginScene");
        }
    }

    
}
