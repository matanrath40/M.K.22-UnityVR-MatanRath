using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoorScript : MonoBehaviour
{
    public bool isOpen = false;
    [SerializeField]
    private bool m_IsRotatingDoor = true;
    [SerializeField]
    private float m_Speed = 1f;
    [Header("Rotation Configs")]
    [SerializeField]
    private float m_RotationAmount = 90f;
    [SerializeField]
    private float m_ForwardDirection = 0;

    private Vector3 m_StartRotation;
    private Vector3 m_Forward;

    private Coroutine AnimationCoroutine;

    private void Awake()
    {
        m_StartRotation = transform.rotation.eulerAngles;
        m_Forward = transform.right;
    }

    public void Open(Vector3 userPosition)
    {
        if (!isOpen)
        {
            if(AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            if(m_IsRotatingDoor)
            {
                float dot = Vector3.Dot(m_Forward, (userPosition - transform.position).normalized);
                Debug.Log($"Dot: {dot.ToString("N3")}");
                AnimationCoroutine = StartCoroutine(DoRotationOpen(dot));
            }
        }
    }

    private IEnumerator DoRotationOpen(float forwardAmount)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if(forwardAmount >= m_ForwardDirection)
        {
            endRotation = Quaternion.Euler(new Vector3(0, m_StartRotation.y - m_RotationAmount, 0));
        } else
        {
            endRotation = Quaternion.Euler(new Vector3(0, m_StartRotation.y + m_RotationAmount, 0));
        }

        isOpen = true;

        float time = 0;

        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * m_Speed;
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            if (m_IsRotatingDoor)
            {
                AnimationCoroutine = StartCoroutine(DoRotationClose());
            }
        }
    }

    private IEnumerator DoRotationClose()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(m_StartRotation);

        isOpen = false;

        float time = 0;

        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * m_Speed;
        }

    }

    public void OpenDoor()
    {
        Debug.Log("Open Door!");
    }


}
