using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{

    private GameObject m_Bulb;
    private Renderer m_BulbRenderer;
    private Light m_BulbLight;
    private bool isOn = false;

    [SerializeField]
    private Material m_BulbOffMaterial;
    [SerializeField]
    private Material m_BulbOnMaterial;

    private int m_ID;
    void Start()
    {
        m_ID = transform.GetComponent<ObjectID>().ID;

        m_Bulb = transform.Find("Bulb").gameObject;
        m_BulbRenderer = m_Bulb.GetComponent<Renderer>();
        m_BulbRenderer.material = m_BulbOffMaterial;

        GameObject bulbLightGameObject = transform.Find("Light").gameObject;
        m_BulbLight = bulbLightGameObject.GetComponent<Light>();
        m_BulbLight.enabled = false;

        isOn = false;

        Debug.Log("Currently applied material: " + m_BulbRenderer.material);

    }

    public void OnTouchBulb()
    {

        if (isOn)
        {
            isOn = false;
            m_BulbRenderer.material = m_BulbOffMaterial;
            m_BulbLight.enabled = false;
            LampsRiddle.Instance.RemoveLamp(m_ID);
            Debug.Log("Bulb is turning off...");

        } else
        {
            isOn = true;
            m_BulbRenderer.material = m_BulbOnMaterial;
            m_BulbLight.enabled = true;
            LampsRiddle.Instance.AddLamp(m_ID);
            Debug.Log("Bulb is turning on...");



        }
    }
}
