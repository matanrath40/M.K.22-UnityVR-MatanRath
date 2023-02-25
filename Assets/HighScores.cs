using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI firstPlace;
    [SerializeField]
    private TextMeshProUGUI secondPlace;
    [SerializeField]
    private TextMeshProUGUI thirdPlace;

    private string m_FirstPlaceString;
    private string m_SecondPlaceString;
    private string m_ThirdPlaceString;

    private string m_BestScoresString;

    private string[] m_BestScoresArray;

    private int m_NumberOfHighScores;

    // Start is called before the first frame update
    void Start()
    {
        m_BestScoresString = PlayerPrefs.GetString("BestScores", "");
        splitBestScoresString(m_BestScoresString);
        setScores();
        setScoresOnUI();

    }

    private void splitBestScoresString(string i_BestScoresString)
    {
        if (i_BestScoresString == "")
        {
            return;
        }
        string[] scoreStrings = i_BestScoresString.Split(';');

        m_NumberOfHighScores = scoreStrings.Length;

        string[] playerIds = new string[scoreStrings.Length];
        string[] playerTimes = new string[scoreStrings.Length];

        m_BestScoresArray = new string[scoreStrings.Length];

        for (int i = 0; i < scoreStrings.Length; i++)
        {
            string[] parts = scoreStrings[i].Split(':');
            playerIds[i] = parts[0];
            playerTimes[i] = parts[1];

            m_BestScoresArray[i] = parts[0] + " ||| Time to beat: " + parts[1]; 
        }
    }

    private void setScores()
    {
        if (m_BestScoresString == "")
        {
            return;
        }

        if (m_NumberOfHighScores == 1)
        {
            m_FirstPlaceString = m_BestScoresArray[0];
        } else if (m_NumberOfHighScores == 2)
        {
            m_FirstPlaceString = m_BestScoresArray[0];
            m_SecondPlaceString = m_BestScoresArray[1];

        } else
        {
            m_FirstPlaceString = m_BestScoresArray[0];
            m_SecondPlaceString = m_BestScoresArray[1];
            m_ThirdPlaceString = m_BestScoresArray[2];

        }
    }

    private void setScoresOnUI()
    {
        firstPlace.text = m_FirstPlaceString;
        secondPlace.text = m_SecondPlaceString;
        thirdPlace.text = m_ThirdPlaceString;
    }

    // best 3 scores are saved in player prefs in a string: "14:60.3;87:62.44;12:65.9"


}
