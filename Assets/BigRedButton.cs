using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRedButton : MonoBehaviour
{
    GameManager m_GameManager;

    private GameObject m_ButtonCover;
    private Animator m_ButtonCoverAnimator;

    private GameObject m_RedButton;
    private Animator m_RedButtonAnimator;

    [SerializeField]
    private GameObject m_Socket1;    
    [SerializeField]
    private GameObject m_Socket2;
    //private RedButtonRiddle m_RedButtonRiddle;

    private void Start()
    {
        m_GameManager = GameManager.Instance;
        m_Socket1.SetActive(false);
        m_Socket2.SetActive(false);

        m_ButtonCover = GameObject.Find("ButtonCover");
        if (m_ButtonCover != null)
        {
            m_ButtonCoverAnimator = m_ButtonCover.GetComponent<Animator>();
        }

        m_RedButton = GameObject.Find("RedButton");
        if (m_RedButton != null)
        {
            m_RedButtonAnimator = m_RedButton.GetComponent<Animator>();
        }
    }

    public void OpenButtonCover()
    {
        m_ButtonCoverAnimator.SetTrigger("OpenRedButtonCover");
    }

    public void OnPressButton()
    {
        m_RedButtonAnimator.SetTrigger("PressedOnRedButton");
        Debug.Log("You won!");
        m_GameManager.FinishGame();
    }

    public void EnableSockets()
    {
        m_Socket1.SetActive(true);
        m_Socket2.SetActive(true);
    }




}
