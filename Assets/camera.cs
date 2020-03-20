using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camera : MonoBehaviour
{
    
    public Transform karakter;
    public float mesafe,x;
    
    void Start()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("karakter");
        karakter = playerObjects[0].transform;

      //  karakter = GameObject.FindGameObjectWithTag("karakter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (karakter.GetComponent<karakter>().yerdemi)
        {

            transform.position = new Vector3(karakter.transform.position.x + x, karakter.transform.position.y + mesafe, -10);
        }
        else
        {
            transform.position = new Vector3(karakter.transform.position.x + x, transform.position.y, -10);
        }
    }
}
