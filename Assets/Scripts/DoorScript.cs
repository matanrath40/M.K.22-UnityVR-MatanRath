using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame

    public void OpenDoor()
    {
        m_Animator.SetTrigger("OpenDoorTrigger");
    }
}
