using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampsRiddle : MonoBehaviour
{
    public static LampsRiddle Instance;

    private bool[] m_LampsOn = new bool[6] { false, false, false, false, false, false };

    private bool hasSolved = false;

    private void Awake()
    {
        Instance = this;
    }

    public void AddLamp(int i_LampID)
    {
        m_LampsOn[i_LampID] = true;
        checkIfRiddleSolved();


    }

    public void RemoveLamp(int i_LampID)
    {
        m_LampsOn[i_LampID] = false;
        checkIfRiddleSolved();
    }

    private void checkIfRiddleSolved()
    {
        if (!hasSolved)
        {
            if (m_LampsOn[0] && !m_LampsOn[1] && m_LampsOn[2] && m_LampsOn[3] && !m_LampsOn[4] && m_LampsOn[5])
            {
                // riddle solved
                Debug.Log("Lamps Riddle Solved!");
                hasSolved = true;
                RedButtonRiddle.Instance.EnableSockets();
                //RedButtonRiddle.Instance.
                GameManager.Instance.onSolvingLightsRiddle();
            }
        }

    }
}
