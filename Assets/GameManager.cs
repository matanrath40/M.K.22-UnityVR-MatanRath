using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int playerUniqueID;

        if(!PlayerPrefs.HasKey("PlayerID"))
        {
            playerUniqueID = 1;
        } else
        {
            playerUniqueID = PlayerPrefs.GetInt("PlayerID") + 1;
        }

        PlayerPrefs.SetInt("PlayerID", playerUniqueID);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
