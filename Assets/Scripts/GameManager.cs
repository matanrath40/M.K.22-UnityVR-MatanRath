using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Scene m_CurrentScene;

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

    }

    public void StartTimer()
    {
        m_StartTime = Time.time;
    }

    public void FinishGame()
    {
        float totalGameTime = Time.time - m_StartTime;
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

        string bestScores = PlayerPrefs.GetString("BestScores", "");

        if (bestScores == "") // case there is no bestScores
        {
            PlayerPrefs.SetString("BestScores", playerIdAndTimeString + ";-1:99999999;-2:99999999");
            PlayerPrefs.Save();
            return;
        }

        string[] bestScoresArray = bestScores.Split(';');

        string[] newScoresArray = new string[3];

        int insertIndex = -1;

        for (int i = 0; i < bestScoresArray.Length; i++)
        {
            if (bestScoresArray[i] == "")
            {
                insertIndex = i;
                break;
            }

            string[] parts = bestScoresArray[i].Split(':');
            float currentTime = float.Parse(parts[i]);

            if (i_TotalGameTime > currentTime)
            {
                insertIndex = i;
                break;
            }

        }

        if (insertIndex >= 0)
        {
            for (int i = 0; i < insertIndex; i++)
            {
                newScoresArray[i] = bestScoresArray[i];
            }
            newScoresArray[insertIndex] = bestScores;
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
            newScoresArray[newScoresArray.Length - 1] = bestScores;
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

    

}
