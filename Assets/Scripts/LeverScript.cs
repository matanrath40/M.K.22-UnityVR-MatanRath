using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class LeverScript : MonoBehaviour
{
    public HingeJoint hingeJoint;
    public float targetAngle = -45f;
    public GameObject door;

    protected void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        door = GetComponent<GameObject>();

    }

    protected void Update()
    {

        if (hingeJoint.angle <= targetAngle)
        {
            door.SendMessage("OpenDoor");
        }
        
    }
}
