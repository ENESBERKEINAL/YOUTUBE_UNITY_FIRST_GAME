using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yıldız : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "karakter")
        {
            karakter.yildiz_sayisi++;
            Debug.Log(karakter.yildiz_sayisi);
            GameObject.Destroy(this.gameObject);
        }
    }
}
