using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coder : MonoBehaviour
{

    public static Coder Instance;

    private bool m_HasOpenedSafe = false;


    [SerializeField]
    private Canvas coderUI;

    [SerializeField]
    private GameObject door;

    [SerializeField]
    private AudioSource m_SafeAudioSource;

    private Animator m_DoorAnimator;

    private string m_CorrectPassword = "120296";

    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        m_DoorAnimator = door.GetComponent<Animator>();

        coderUI.enabled = false;
    }



    public void onSelectCoder()
    {
        Debug.Log("coder selected!");
        if (!m_HasOpenedSafe)
        {
            toggleCoderUI();

        }
    }

    private void toggleCoderUI()
    {
        if (coderUI.enabled)
        {
            coderUI.enabled = false;
        } else
        {
            coderUI.enabled = true;
        }
    }

    public bool IsPasswordValid(string i_PasswordToCheck)
    {
        Debug.Log("Coder: " + i_PasswordToCheck);
        bool isValid = checkPassword(i_PasswordToCheck);

        if (isValid)
        {
            coderUI.enabled = false;
            m_DoorAnimator.SetTrigger("isPressedCorrectCode");
            m_SafeAudioSource.Play();
            m_HasOpenedSafe = true;
            return true;
        }

        return false;
    }

    private bool checkPassword(string i_PasswordToCheck)
    {
        bool returnValue = false;

        if (i_PasswordToCheck == m_CorrectPassword)
        {
            returnValue = true;
        }

        return returnValue;
    }
}
