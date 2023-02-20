using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovementScript : MonoBehaviour
{
    private float m_Speed;
    private float m_EndPosX;


    public void StartFloating(float i_Speed, float i_endPosX)
    {
        m_Speed = i_Speed;
        m_EndPosX = i_endPosX;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * m_Speed));

        if (transform.position.x > m_EndPosX)
        {
            Destroy(gameObject);
        }
    }
}
