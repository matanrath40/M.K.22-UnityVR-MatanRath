using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RedButtonRiddle : MonoBehaviour
{
    public static RedButtonRiddle Instance;

    private BigRedButton m_BigRedButton;
    [SerializeField]
    private AudioSource m_BigRedButtonAudioSource;
    [SerializeField]
    private Light m_LampCeiling1Light;
    [SerializeField]
    private Light m_LampCeiling2Light;
    [SerializeField]
    private GameObject m_WinningUI;

    //private bool[] m_KeysInside = new bool[2] { false, false };
    private int m_NumberOfKeysInside = 0;

    private bool isOpen = false;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        m_BigRedButton = GameObject.Find("BigRedButton").GetComponent<BigRedButton>();
        m_WinningUI.SetActive(false);
        //m_KeySocket = GameObject.Find("KeySocket").GetComponent<GameObject>();
        //m_KeySocket.ena
        //m_KeySocket = GameObject.Find("KeySocket (1)").GetComponent<GameObject>();

    }

    public void AddKey()
    {
        m_NumberOfKeysInside++;
        checkIfAllKeysIn();

    }

    public void RemoveKey()
    {
        m_NumberOfKeysInside--;

    }

    private void checkIfAllKeysIn()
    {
        if (m_NumberOfKeysInside == 2)
        {
            //m_ButtonCover.OpenCover();
            m_BigRedButton.OpenButtonCover();
            //m_BigRedButton.OpenButtonCover();
            //Animator animator = m_ButtonCover.GetComponent<Animator>();
            //animator.SetTrigger("OpenRedButtonCover");
        }
    }

    public void EnableSockets()
    {
        m_BigRedButton.EnableSockets();
    }

    public void PlayAlert()
    {
        m_BigRedButtonAudioSource.Play();
        //m_LampCeiling1Light.color = new Color(255f, 0, 0);
        //m_LampCeiling2Light.color = new Color(255f, 0, 0);
    }

    public void StopAlert()
    {
        m_BigRedButtonAudioSource.Stop();
        m_LampCeiling1Light.color = new Color(255f, 0, 0);
        m_LampCeiling2Light.color = new Color(255f, 0, 0);
    }

    public void ShowWinningUI()
    {
        m_WinningUI.SetActive(true);
    }

    public void onClickExit()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);

    }

}
