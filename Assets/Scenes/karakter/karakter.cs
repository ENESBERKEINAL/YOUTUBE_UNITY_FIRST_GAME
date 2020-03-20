using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*public static class AxisInput
{
    public const string Horizontal = "Horizontal";
    public const string Vertical = "Vertical";
}*/
public class karakter : MonoBehaviour
{
    // Start is called before the first frame update
    public float hiz;
    public float h;
    public float ziplama_gucu;
    Rigidbody2D fizik_karakter;
    Animator animasyon_oynatıcı;
    public bool yerdemi;
    public static int yildiz_sayisi; 
    public Text textimiz;
    public int max_can;
    public int can_sayisi;
    float time = 0;
    public GameObject[] canlar;
    public bool sol;
    public bool sag;
    void Start()
    {
        yildiz_sayisi = 0;
        yildiz_sayisi = PlayerPrefs.GetInt("yildiz");
        fizik_karakter = GetComponent<Rigidbody2D>();
        animasyon_oynatıcı = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        textimiz.text = yildiz_sayisi.ToString();
        if (can_sayisi == 0)
        {
            ol();
        }
        
        if(transform.position.y < -4f)
        {
            ol();
        }

    }

    void FixedUpdate()
    { //  float horizontalInput = Input.GetAxis("Horizontal");
      // float verticalInput = Input.GetAxis("Vertical");
      //h = Input.GetAxis("Horizontal");
        if (sol)
        {
            h = 1;
        }
        if (sag)
        {
            h = -1;
        }
        if (sol == false && sag == false)
        {
            h = 0;
        }
        transform.position += new Vector3(h * hiz * Time.deltaTime, 0, 0);
        if (h >0 ) {
            transform.rotation = new Quaternion(0,0, 0, 0);
         }
        else if (h < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        animasyon_oynatıcı.SetFloat("hiz", Mathf.Abs(h));
        animasyon_oynatıcı.SetBool("yerde", yerdemi);
    }
    void ol()
    {
        PlayerPrefs.SetInt("yildiz", yildiz_sayisi);
        Application.LoadLevel(Application.loadedLevel);
    }
    void Can_azalma()
    {
        can_sayisi--;
        GameObject.Find("can" + can_sayisi.ToString()).active = false;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ates")
        {
            if (time <= 0)
            {
                Can_azalma();
                time = 3f;
            }
        }
        else if (coll.gameObject.tag == "can")
        {
            if (can_sayisi <  max_can)
            {
                canlar[can_sayisi].active = true;
                can_sayisi++;
                GameObject.Destroy(coll.gameObject);
            }
        }
        else if(coll.gameObject.tag == "door")
        {
            PlayerPrefs.SetInt("yildiz", yildiz_sayisi);
          //  PlayerPrefs.SetInt("bolum", Application.LoadLevel);
            Application.LoadLevel("2");
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ates")
        {
            if (time <= 0)
            {
                Can_azalma();
                time = 3f;
            }
        }
    }
    public void zıpla()
    {
        
            fizik_karakter.velocity += new Vector2(0, ziplama_gucu);
            yerdemi = false;
        
    }
    public void sol_press()
    {
        sol = true;
    }
    public void sol_break()
    {
        sol = false;
    }
    public void sag_press()
    {
        sag = true;
    }
    public void sag_break()
    {
        sag = false;
    }
}
