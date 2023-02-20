using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerScript : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject capsule;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //capsule = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(key))
    }
}
