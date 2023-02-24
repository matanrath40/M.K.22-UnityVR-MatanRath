using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVStand : MonoBehaviour
{
    Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();

    }
    public void OpenDoor()
    {
        m_Animator.SetTrigger("openRightDoor");
        Debug.Log("TV STAND DOOR IS OPENING...");
    }
}
