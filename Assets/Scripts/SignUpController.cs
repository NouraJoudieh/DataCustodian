using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignUpController : MonoBehaviour
{

    public TMP_InputField username;
    public TMP_InputField password;
    public GameObject WrongUser;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Invalid()
    {
        WrongUser.SetActive(true);
        yield return new WaitForSeconds(2);
        WrongUser.SetActive(false);
        username.text = "";
        password.text = "";

    }
    public void SignUp() {
        string user = username.text.Trim();
        string pass = password.text.Trim();
        if (PlayerPrefs.HasKey("user" + user))
        {
            StartCoroutine(Invalid());
        }
        else
        {
        int level = 1;
        PlayerPrefs.SetString("user"+user,user);
        PlayerPrefs.SetString("pass"+user,pass);
        PlayerPrefs.SetInt("level"+user, level);
            GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Username = user;
            GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Password = pass;
            GameObject.Find("PlayerInfo").GetComponent<PlayerData>().Level = level;
            GameObject.Find("PlayerInfo").GetComponent<PlayerData>().isLoggedIn = true;
        SceneManager.LoadScene("ChooseLevel");
        }
       
    }
    public void Back() {
        SceneManager.LoadScene("MainScene");
    }

}
