using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenuScript : MonoBehaviour
{

    public TextMeshProUGUI playerID;


    // Start is called before the first frame update
    void Start()
    {

        playerID = GameObject.Find("Player ID Label").GetComponent<TextMeshProUGUI>();
        playerID.SetText("Player ID: " + PlayerPrefs.GetInt("PlayerID"));

    }

    public void onClickPlayGame()
    {
        Debug.Log("User Clicked on start game");
    }

    public void onClickQuit()
    {
        Debug.Log("User Clicked on quit game");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
