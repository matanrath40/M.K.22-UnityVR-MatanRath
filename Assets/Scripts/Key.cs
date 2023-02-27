using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    Animator m_Animator;
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    public void PlayKeyAnimation()
    {
        m_Animator.SetTrigger("KeyEnterHole");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "KeyHole")
        {
            m_Animator.SetTrigger("KeyInSocket");

        }

    }

}
