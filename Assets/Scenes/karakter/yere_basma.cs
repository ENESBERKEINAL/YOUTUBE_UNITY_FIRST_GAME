 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yere_basma : MonoBehaviour
{
    // Start is called before the first frame update
    karakter k;
    void Start()
    {
        k = transform.root.GetComponent<karakter>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "zemin")
        {
            k.yerdemi = true;
        }
    }
}
