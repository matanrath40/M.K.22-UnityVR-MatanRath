using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Scene m_CurrentScene;


    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;

            m_CurrentScene = SceneManager.GetActiveScene();
            Debug.Log("Currently active scene: " + m_CurrentScene.name);

        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        int playerUniqueID;

        if(!PlayerPrefs.HasKey("PlayerID"))
        {
            playerUniqueID = 1;
        } else
        {
            playerUniqueID = PlayerPrefs.GetInt("PlayerID") + 1;
        }

        PlayerPrefs.SetInt("PlayerID", playerUniqueID);



    }

    

}
