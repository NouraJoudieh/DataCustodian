using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APIHandler : MonoBehaviour
{
    public string userId;
    public string trackId;
    public string gameId;

    public string url;

    private void Start()
    {
        url = Application.absoluteURL;
        StartCoroutine(GetRequest(url));
    }

    private void Update()
    {

    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            uri = "localhost:3000/dc?user_id=1&track_id=1&game_id=1";
            string[] attributes = uri
                .Split('?')[1]
                .Split('&');
            userId = attributes[0].Split('=')[1];
            trackId = attributes[1].Split('=')[1];
            gameId = attributes[2].Split('=')[1];
        }
        string scoreDetails = "{" +
            "Level: ," +
            "Score: ," +
            "}";
        StartCoroutine(Login(userId, trackId, gameId, "score", scoreDetails));
    }

    IEnumerator Login(string user, string track, string game, string score, string scoreDetails)
    {
        WWWForm form = new WWWForm();
        form.AddField("game_id", game);
        form.AddField("user_id", user);
        form.AddField("track_id", track);
        form.AddField("game_score", score);
        form.AddField("result_file", scoreDetails);

        string bodyData =
            "{" +
            "\"game_id\": " + game + ", " +
            "\"user_id\":" + user + ", " +
            "\"track_id\":" + track + ", " +
            "\"game_score\":" + score + ", " +
            " }";
        Debug.Log(bodyData);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8000/api/v1/savescore", bodyData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            Debug.Log(System.Text.Encoding.Default.GetBytes((bodyData)));
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.Default.GetBytes((bodyData)));
            www.downloadHandler = new DownloadHandlerBuffer();
            www.chunkedTransfer = false;
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}