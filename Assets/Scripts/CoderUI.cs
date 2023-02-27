using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoderUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_Password; 
    void Start()
    {
        //playerID = GameObject.Find("Player ID Label").GetComponent<TextMeshProUGUI>();
        m_Password = GameObject.Find("Password").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPressNumpad(string i_Key)
    {
        Debug.Log(i_Key + " was pressed");

        if (i_Key == "C")
        {
            m_Password.SetText("");
        } 
        else if (i_Key == "ENTER")
        {

            onPlayerPressedEnter();


        } else
        {
            m_Password.SetText(m_Password.text + i_Key);

        }

    }

    private void onPlayerPressedEnter()
    {
        Debug.Log("Player pressd enter password");

        if (!Coder.Instance.IsPasswordValid(m_Password.text))
        {
            m_Password.SetText("");
        }
    }
}
