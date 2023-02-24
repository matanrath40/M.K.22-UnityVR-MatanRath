using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGeneratorScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] m_Clouds;

    [SerializeField]
    float m_SpawnInterval;

    [SerializeField]
    GameObject m_EndPoint;

    Vector3 m_StartPos;


    // Start is called before the first frame update
    void Start()
    {
        m_StartPos = transform.position;

        StartCoroutine(DoSpawn());

    }


    void SpwanCloud()
    {
        GameObject cloud = Instantiate(m_Clouds[UnityEngine.Random.Range(0, m_Clouds.Length)]);

        m_StartPos.y = UnityEngine.Random.Range(m_StartPos.y, m_StartPos.y + 3);
        m_StartPos.z = UnityEngine.Random.Range(m_StartPos.z, m_StartPos.z + 5);
        cloud.transform.position = m_StartPos;

        float scale = UnityEngine.Random.Range(0.8f, 1.2f);
        cloud.transform.localScale = new Vector3(scale, scale, scale);

        float speed = UnityEngine.Random.Range(0.5f, 1.5f);
        cloud.GetComponent<CloudMovementScript>().StartFloating(speed, m_EndPoint.transform.position.x);

    }



    IEnumerator DoSpawn()
    {
        for(; ; )
        {
            //print("Cloud Spawned");
            SpwanCloud();
            yield return new WaitForSeconds(m_SpawnInterval);
        }
    }
}
