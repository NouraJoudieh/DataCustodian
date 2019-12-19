using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginSceneController : MonoBehaviour

{
    public TMP_InputField username;
    public TMP_InputField password;
    public GameObject WrongUser;
    
    
    public void SignUp() {
       
        SceneManager.LoadScene("SignInPage");
    }
    IEnumerator Invalid()
    {
        WrongUser.SetActive(true);
        yield return new WaitForSeconds(2);
        WrongUser.SetActive(false);
        username.text = "";
        password.text = "";

    }

    public void SignIn() {
        //Validate Username and Password
        string user = username.text.Trim();
        string pass = password.text.Trim();
        if (PlayerPrefs.HasKey("user" + user) && PlayerPrefs.GetString("pass" + user).Equals(pass))
        {
            GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Username = user;
            GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Password = pass;
            GameObject.Find("PlayerInfo").GetComponent<PlayerData>().isLoggedIn = true;
            GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Level = PlayerPrefs.GetInt("level"+user);
            SceneManager.LoadScene("ChooseLevel");
        }
        else {
             StartCoroutine(Invalid());

        }
    }
  
    public void Back()
    {
        SceneManager.LoadScene("MainScene");
    }
}
