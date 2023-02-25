using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCover : MonoBehaviour
{
    // Start is called before the first frame update
    Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();

    }
    public void OpenCover()
    {
        m_Animator.SetTrigger("OpenRedButtonCover");
        Debug.Log("OpenRedButtonCover.");
    }
}
