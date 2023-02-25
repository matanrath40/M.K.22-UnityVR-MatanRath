using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class KeySocket : MonoBehaviour
{
    private RedButtonRiddle m_RedButtonRiddle;
    private Animator m_KeyAnimator;
    XRSocketInteractor m_Socket;


    // Start is called before the first frame update
    void Start()
    {
        m_RedButtonRiddle = RedButtonRiddle.Instance;
        m_Socket = GetComponent<XRSocketInteractor>();

    }

    public void OnPutKeyInSocket()
    {
        IXRSelectInteractable key = m_Socket.GetOldestInteractableSelected();
        GameObject keyObj = key.transform.gameObject;

        //Debug.Log(keyObj.transform.name + " MATAN DEBUG");
        //m_KeyAnimator.SetTrigger("KeyInSocket");

        m_RedButtonRiddle.AddKey();
    }

    public void OnRemoveKeyFromSocket()
    {
        m_RedButtonRiddle.RemoveKey();
    }

    // Update is called once per frame
}
