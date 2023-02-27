using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROriginManager : MonoBehaviour
{
    public static XROriginManager Instnance;

    // Start is called before the first frame update

    void Start()
    {
        if (Instnance == null)
        {
            Instnance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        GameObject leftController = XROriginManager.Instnance.transform.Find("XR Origin/CameraOffset/LeftHand/LeftBaseController").gameObject;

        XRRayInteractor rayInteractor = leftController.GetComponent<XRRayInteractor>();

        rayInteractor.enabled = false; // or true to enable it
        rayInteractor.enabled = true;

    }
}
