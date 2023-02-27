using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;


public class DebugMenu : MonoBehaviour
{
    private bool m_IsBooksSolved = false;
    private bool m_IsSafeSolved = false;
    private bool m_IsLightsSolved = false;
    private bool m_IsKeysSolved = false;


    private BooksRiddle m_BooksRiddle;

    // Buttons
    //private game
    [SerializeField]
    private Button m_SolveLightsRiddle;
    [SerializeField]
    private Button m_SolveKeysRiddleButton;
    [SerializeField]
    private Button m_PressOnRedButtonRiddleButton;

    // Books Riddle 
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

    // Safe Riddle
    [SerializeField]
    private GameObject m_SafeDoor;
    private Animator m_SafeDoorAnimator;

    // Lights Riddle
    [SerializeField]
    private TableLamp m_TableLamp;
    [SerializeField]
    private LightBulb m_Bulb1;
    [SerializeField]
    private LightBulb m_Bulb2;
    [SerializeField]
    private LightBulb m_Bulb3;

    // Keys Riddle
    [SerializeField]
    private Animator m_Key1Animator;
    [SerializeField]
    private Animator m_Key2Animator;

    // Big Red Button
    [SerializeField]
    private BigRedButton m_BigRedButton;



    private void Start()
    {
        m_BooksRiddle = BooksRiddle.Instance;

        m_SolveLightsRiddle.interactable = false;
        m_SolveKeysRiddleButton.interactable = false;
        m_PressOnRedButtonRiddleButton.interactable = false;
        
        //Listm_SolveBookButton.GetComponents<>();

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

        m_IsBooksSolved = true;

        if (m_IsSafeSolved)
        {
            enableLightsButton();

        }

    }

    public void OnPressSolveSafeRiddle()
    {
        m_SafeDoorAnimator.SetTrigger("isPressedCorrectCode");

        m_IsSafeSolved = true;

        if (m_IsBooksSolved)
        {
            enableLightsButton();

        }

    }

    public void OnPressSolveLightsRiddle()
    {
        m_TableLamp.TurnOnLamp();
        m_Bulb1.TurnOnBulb();
        m_Bulb2.TurnOnBulb();
        m_Bulb3.TurnOnBulb();

        m_IsLightsSolved = true;
        m_SolveKeysRiddleButton.interactable = true;

    }

    public void OnPressSolveKeysRiddle()
    {
        m_Key1Animator.enabled = true;
        m_Key2Animator.enabled = true;

        m_IsKeysSolved = true;
        m_PressOnRedButtonRiddleButton.interactable = true;
    }

    public void OnPressSolveRedButton()
    {
        m_BigRedButton.OnPressButton();
    }

    private void enableLightsButton()
    {
        m_SolveLightsRiddle.interactable = true;

    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

