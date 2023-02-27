using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject m_DebugMenuUI;
    [SerializeField]
    private GameObject m_XROrigin;

    private void Awake()
    {
        //if (XROriginManager.XROrigin != null)
        //{
        //    // Set the XR origin settings to match your desired settings
        //    //XRSettings.SetTrackingOriginMode(XRSettingsTrackingOriginMode.Floor);
        //    //XRSettings.SetReferencePoint(XRManager.XROrigin.transform);
        //    m_XROrigin = XROriginManager.XROrigin;
            
        //}
    }
    void Start()
    {
        if (Application.isEditor)
        {
            m_DebugMenuUI.SetActive(true);
        } else
        {
            m_DebugMenuUI.SetActive(false);
        }

        if (XROriginManager.Instnance != null)
        {
            XROriginManager xrOriginManager = XROriginManager.Instnance;

            xrOriginManager.transform.position = new Vector3(1.66f, 0.221f, -8.521f);

            GameObject leftController = XROriginManager.Instnance.transform.Find("XR Origin/CameraOffset/LeftHand/LeftBaseController").gameObject;

            XRRayInteractor rayInteractor = leftController.GetComponent<XRRayInteractor>();

            rayInteractor.enabled = false; // or true to enable it
            rayInteractor.enabled = true;




        }

    }

}
