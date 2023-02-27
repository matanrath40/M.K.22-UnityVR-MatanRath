using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenuScript : MonoBehaviour
{
    GameManager m_GameManager;
    public TextMeshProUGUI playerID;
    TrialLogger trialLogger;


    // Start is called before the first frame update
    void Start()
    {
        m_GameManager = GameManager.Instance;
        playerID = GameObject.Find("Player ID Label").GetComponent<TextMeshProUGUI>();
        playerID.SetText("Player ID: " + PlayerPrefs.GetInt("PlayerID"));

        //List<string> columnList = new List<string>();
        trialLogger = TrialLogger.Instance;
        trialLogger.Initialize(PlayerPrefs.GetInt("PlayerID").ToString());

    }

    public void onClickPlayGame()
    {
        Debug.Log("User Clicked on start game");
        trialLogger.StartTrial();
        LoadNextScene();
        m_GameManager.StartTimer();
    }

    public void onClickQuit()
    {
        Debug.Log("User Clicked on quit game");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
