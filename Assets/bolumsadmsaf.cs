using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bolum_sistemi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        kilit_sistemi();
    }
    public Button[] buttonlar;
    public void bolum_ac(string bolum_ismi)
    {
        Application.LoadLevel(bolum_ismi);
    }
    public void kilit_sistemi()
    {
        int bolums = PlayerPrefs.GetInt("bolum");

    }
}
