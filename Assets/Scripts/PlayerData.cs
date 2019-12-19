using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData:MonoBehaviour
{
    public int Level { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool isLoggedIn { get; set; }

    private static PlayerData _instance;

    private void Awake()
    {
        
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }



}
