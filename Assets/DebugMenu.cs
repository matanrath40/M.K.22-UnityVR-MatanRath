using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class DebugMenu : MonoBehaviour
{
    private BooksRiddle m_BooksRiddle;

    // BooksRiddle GameObjects and Animators
    [SerializeField]
    private GameObject m_Book16;
    private Animator m_Book16Animator;
    [SerializeField]
    private GameObject m_Book4;
    private Animator m_Book4Animator;
    [SerializeField]
    private GameObject m_Book13;
    private Animator m_Book13Animator;
    [SerializeField]
    private GameObject m_Book22;
    private Animator m_Book22Animator;
    [SerializeField]
    private GameObject m_Book10;
    private Animator m_Book10Animator;

    // SafeRiddle
    [SerializeField]
    private GameObject m_SafeDoor;
    private Animator m_SafeDoorAnimator;
    
    private void Start()
    {
        m_BooksRiddle = BooksRiddle.Instance;

        //m_Book16 = GameObject.Find("Book_16");
        m_Book16Animator = m_Book16.GetComponent<Animator>();
        m_Book16Animator.enabled = false;

        //m_Book4 = GameObject.Find("Book_4");
        m_Book4Animator = m_Book4.GetComponent<Animator>();
        m_Book4Animator.enabled = false;

        //m_Book13 = GameObject.Find("Book_13");
        m_Book13Animator = m_Book13.GetComponent<Animator>();
        m_Book13Animator.enabled = false;

        //m_Book22 = GameObject.Find("Book_22");
        m_Book22Animator = m_Book22.GetComponent<Animator>();
        m_Book22Animator.enabled = false;

        //m_Book10 = GameObject.Find("Book_10");
        m_Book10Animator = m_Book10.GetComponent<Animator>();
        m_Book10Animator.enabled = false;

        m_SafeDoorAnimator = m_SafeDoor.GetComponent<Animator>();
    }

    public void OnPressSolveBooksRiddle()
    {
        // animate books riddle
        //m_Book16.GetComponent<XRGrabInteractable>().enabled = true;
        m_Book16Animator.enabled = true;
        m_Book4Animator.enabled = true;
        m_Book13Animator.enabled = true;
        m_Book22Animator.enabled = true;
        m_Book10Animator.enabled = true;

    }

    public void OnPressSolveSafeRiddle()
    {
        m_SafeDoorAnimator.SetTrigger("isPressedCorrectCode");
    }
}

