using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //public static GameObject XROrigin;

    private Scene m_CurrentScene;

    private GameObject m_DebugMenuUI;

    private float m_StartTime;

    private bool m_HasSolvedLightsRiddle = false;


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

        //if (XROrigin == null)
        //{
        //    // If a reference to the XR origin does not already exist, set it to the child of this GameObject
        //    XROrigin = FindGameObjectInScene("XR Origin");

        //    // Make the XR origin persistent between scenes
        //    DontDestroyOnLoad(XROrigin);
        //}
        //else
        //{
        //    // If a reference to the XR origin already exists, destroy this GameObject (so that there is only one instance of the XR origin in the scene)
        //    Destroy(XROrigin);
        //}

    }

    public void StartTimer() // 21.24.07 (3.93) ---- 21.24.25 (21
    {
        m_StartTime = Time.time;
        Debug.Log("Starting Time: " + m_StartTime);
    }

    public void FinishGame()
    {
        float totalGameTime = Time.time - m_StartTime;
        //deb
        saveScore(totalGameTime);
        Debug.Log("Overall time to solve: " + totalGameTime);


    }

    private void checkIfHighScore(float i_TotalGameTime)
    {
        
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

    private void saveScore(float i_TotalGameTime)
    {

        string playerIdAndTimeString = PlayerPrefs.GetInt("PlayerID").ToString() + ":" + i_TotalGameTime.ToString();

        string bestScores = PlayerPrefs.GetString("BestScores", "-1:9999999;-1:9999999;-1:9999999");

        string[] bestScoresArray = bestScores.Split(';');
        

        string[] newScoresArray = new string[bestScoresArray.Length];

        int insertIndex = -1;

        for (int i = 0; i < bestScoresArray.Length; i++)
        {


            string[] parts = bestScoresArray[i].Split(':');
            float currentTime = float.Parse(parts[1]);

            if (i_TotalGameTime < currentTime)
            {
                insertIndex = i;
                break;
            }

        }

        if (insertIndex >= 0) // 0,1,2
        {
            for (int i = 0; i <=  insertIndex; i++)
            {
                newScoresArray[i] = bestScoresArray[i];
            }
            
            newScoresArray[insertIndex] = playerIdAndTimeString;

            for (int i = insertIndex + 1; i < newScoresArray.Length; i++)
            {
                newScoresArray[i] = bestScoresArray[i - 1];
            }
        }
        else
        {
            for (int i = 0; i < newScoresArray.Length - 1; i++)
            {
                newScoresArray[i] = bestScoresArray[i];
            }

        }

        string newBestScoresString = string.Join(";", newScoresArray);

        PlayerPrefs.SetString("BestScores", newBestScoresString);
        PlayerPrefs.Save();


    }


    public void onSolvingLightsRiddle()
    {
        m_HasSolvedLightsRiddle = true;
    }

    public bool HasSolvedLightsRiddle()
    {
        return m_HasSolvedLightsRiddle;
    }

    private GameObject FindGameObjectInScene(string name)
    {
        // Get the current scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Iterate over all root GameObjects in the scene hierarchy
        foreach (GameObject rootGameObject in currentScene.GetRootGameObjects())
        {
            // Check if the root GameObject has a child GameObject with the given name
            Transform childTransform = rootGameObject.transform.Find(name);
            if (childTransform != null)
            {
                // Return the child GameObject if it is found
                return childTransform.gameObject;
            }
        }

        // Return null if the GameObject is not found
        return null;
    }
}


