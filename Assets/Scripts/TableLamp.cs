using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableLamp : MonoBehaviour
{
    private GameObject m_InsideLightGameObject;
    private GameObject m_OutsideLightGameObject;

    private Light m_InsideLight;
    private Light m_OutsideLight;

    private int m_ID;


    private bool isOn = false;

    void Start()
    {
        m_ID = transform.GetComponent<ObjectID>().ID;

        m_InsideLightGameObject = transform.Find("Inside Light").gameObject;
        m_OutsideLightGameObject = transform.Find("Outside Light").gameObject;

        m_InsideLight = m_InsideLightGameObject.GetComponent<Light>();
        m_OutsideLight = m_OutsideLightGameObject.GetComponent<Light>();

        m_InsideLight.enabled = false;
        m_OutsideLight.enabled = false;

        isOn = false;
    }

    public void OnTouchTableLamp()
    {
        if (isOn)
        {
            TurnOffLamp();

        } else
        {
            TurnOnLamp();

        }
    }

    public void TurnOnLamp()
    {
        m_InsideLight.enabled = true;
        m_OutsideLight.enabled = true;
        isOn = true;
        LampsRiddle.Instance.AddLamp(m_ID);
    }

    public void TurnOffLamp()
    {
        m_InsideLight.enabled = false;
        m_OutsideLight.enabled = false;
        isOn = false;
        LampsRiddle.Instance.RemoveLamp(m_ID);
    }
}
