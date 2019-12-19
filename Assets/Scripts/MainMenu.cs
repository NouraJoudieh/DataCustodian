using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioClip CoffeeSipClip;
    public AudioSource CoffeeAudio;
    public AudioClip PaperClip;
    public AudioSource PaperAudio;
    public GameObject StudentClipBoard;
    public GameObject CourseClipBoard;
    public GameObject MarksClipBoard1;
    public GameObject MarksClipBoard2;
    public GameObject MarksClipBoard3;
    public GameObject HelpOverlay;
    public GameObject InfoOverlay;
    public GameObject TableOverlay;
    public GameObject ResultOverlay;
    public GameObject Table;
    public GameObject AlternativeQuery;
    public GameObject CorrectQuery;
    public TextMeshProUGUI ClipBoardText;
    public GameObject Star40;
    public GameObject StarUnder40;
    public GameObject Star70;
    public GameObject Star100;
    private int i;
   
    void Start()
    {
        i = 0;
        PaperAudio.mute = true;
        CoffeeAudio.mute = true;
    }

    public void Next() {
       
        PaperAudio.mute = false;
        PaperAudio.PlayOneShot(PaperClip);


        if (i == 0)
        {
            StudentClipBoard.SetActive(false);
            CourseClipBoard.SetActive(true);
            MarksClipBoard1.SetActive(false);
            MarksClipBoard2.SetActive(false);
            MarksClipBoard3.SetActive(false);
            ClipBoardText.SetText("Course");
            i = 1;
        }
        else
        if (i == 1) {
            StudentClipBoard.SetActive(false);
            CourseClipBoard.SetActive(false);
            MarksClipBoard1.SetActive(true);
            MarksClipBoard2.SetActive(false);
            MarksClipBoard3.SetActive(false);
            ClipBoardText.SetText("Marks1");
            i = 2;
        }
        else
        if (i == 2) {
            StudentClipBoard.SetActive(false);
            CourseClipBoard.SetActive(false);
            MarksClipBoard1.SetActive(false);
            MarksClipBoard2.SetActive(true);
            MarksClipBoard3.SetActive(false);
            ClipBoardText.SetText("Marks2");
            i = 3;
        }
        else
         if (i == 3) {
            StudentClipBoard.SetActive(false);
            CourseClipBoard.SetActive(false);
            MarksClipBoard1.SetActive(false);
            MarksClipBoard2.SetActive(false);
            MarksClipBoard3.SetActive(true);
            ClipBoardText.SetText("Marks3");
            i = 4;
        }
        else
        if (i == 4) {
            StudentClipBoard.SetActive(true);
            CourseClipBoard.SetActive(false);
            MarksClipBoard1.SetActive(false);
            MarksClipBoard2.SetActive(false);
            MarksClipBoard3.SetActive(false);
            ClipBoardText.SetText("Student");
            i = 0;
        }
       
    }
    public void Previous() {
       // MainMusic.Stop();
        PaperAudio.mute = false;
        PaperAudio.PlayOneShot(PaperClip);
        if (i == 0)
        {
            StudentClipBoard.SetActive(false);
            CourseClipBoard.SetActive(false);
            MarksClipBoard1.SetActive(false);
            MarksClipBoard2.SetActive(false);
            MarksClipBoard3.SetActive(true);
            ClipBoardText.SetText("Mark3");
            i = 4;
        }
        else
        if (i == 1)
        {
            StudentClipBoard.SetActive(true);
            CourseClipBoard.SetActive(false);
            MarksClipBoard1.SetActive(false);
            MarksClipBoard2.SetActive(false);
            MarksClipBoard3.SetActive(false);
            ClipBoardText.SetText("Student");
            i = 0;
        }
        else
        if (i == 2)
        {
            StudentClipBoard.SetActive(false);
            CourseClipBoard.SetActive(true);
            MarksClipBoard1.SetActive(false);
            MarksClipBoard2.SetActive(false);
            MarksClipBoard3.SetActive(false);
            ClipBoardText.SetText("Course");
            i = 1;
        }
        else
         if (i == 3)
        {
            StudentClipBoard.SetActive(false);
            CourseClipBoard.SetActive(false);
            MarksClipBoard1.SetActive(true);
            MarksClipBoard2.SetActive(false);
            MarksClipBoard3.SetActive(false);
            ClipBoardText.SetText("Marks1");
            i = 2;
        }
        else
        if (i == 4)
        {
            StudentClipBoard.SetActive(false);
            CourseClipBoard.SetActive(false);
            MarksClipBoard1.SetActive(false);
            MarksClipBoard2.SetActive(true);
            MarksClipBoard3.SetActive(false);
            ClipBoardText.SetText("Marks2");
            i = 3;
        }

    }
   
    public void CoffeeSip()
    {
        CoffeeAudio.mute = false;
        CoffeeAudio.PlayOneShot(CoffeeSipClip);
    }
    public void ViewTables()
    {
        HelpOverlay.SetActive(false);
        TableOverlay.SetActive(true);
        StudentClipBoard.SetActive(true);
        ClipBoardText.SetText("Student");
    }
    public void CloseOverlay() {
        TableOverlay.SetActive(false);
        HelpOverlay.SetActive(false);
        InfoOverlay.SetActive(false);
    }
    public void CloseHelp()
    {
        HelpOverlay.SetActive(false);
        InfoOverlay.SetActive(false);
    }


    public void Close()
    {
        //Also Retry
        //For Back button in result overlays
        TableOverlay.SetActive(false);
        HelpOverlay.SetActive(false);
        ResultOverlay.SetActive(false);
        CorrectQuery.SetActive(false);
        AlternativeQuery.SetActive(false);
        InfoOverlay.SetActive(false);
        Star100.SetActive(false);
        Star70.SetActive(false);
        Star40.SetActive(false);
        StarUnder40.SetActive(false);
        //Delete  Results in Table
        var rows = Table.transform.childCount;
        for (int i = 3; i < rows; i++)
        {
            Destroy(Table.transform.GetChild(i).gameObject);
        }

    }
    public void Help()
    {
        TableOverlay.SetActive(false);
        InfoOverlay.SetActive(false);
        HelpOverlay.SetActive(true);
    }

    public void Info()
    {
        InfoOverlay.SetActive(true);
        TableOverlay.SetActive(false);
        HelpOverlay.SetActive(false);
    }

    public void BackToMain() {

        SceneManager.LoadScene("ChooseLevel");
    }
}
