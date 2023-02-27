using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject m_FrontDoorInsideSign;

    private MeshRenderer m_SignMeshRenderer;

    private void Start()
    {
        m_SignMeshRenderer = m_FrontDoorInsideSign.GetComponent<MeshRenderer>();

    }
    public void OnPressResume()
    {
        //m_FrontDoorInsideSign.SetActive(true);
        m_SignMeshRenderer.enabled = true;
        gameObject.SetActive(false);
        //m_FrontDoorInsideSign.SetActive(true);

    }

    public void OnPressExit()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
