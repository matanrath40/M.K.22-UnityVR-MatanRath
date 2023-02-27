using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator m_Animator;
    [SerializeField]
    private GameObject m_PauseMenu;
    [SerializeField]
    private GameObject m_FrontDoorInsideSign;

    private MeshRenderer m_SignMeshRenderer;
    [SerializeField]
    private Canvas m_SignCanvas;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_SignMeshRenderer = m_FrontDoorInsideSign.GetComponent<MeshRenderer>();


    }

    // Update is called once per frame

    public void OpenDoor()
    {
        m_Animator.SetTrigger("OpenDoorTrigger");
    }

    public void OnPauseGame()
    {
        //m_FrontDoorInsideSign.SetActive(false);
        m_SignCanvas.enabled = false;
        m_SignMeshRenderer.enabled = false;
        m_PauseMenu.SetActive(true);
    }

    //private void toggleShowPauseMenu()
    //{
    //    if (m_PauseMenu.enabled)
    //    {
    //        m_PauseMenu.enabled = false;
    //    } else
    //    {
    //        m_PauseMenu.enabled = true;
    //    }
    //}
}
