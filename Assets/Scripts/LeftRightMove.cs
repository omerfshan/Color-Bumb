using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMove : MonoBehaviour
{
    public float speed, distance; // Hareket hızı ve mesafesi
    private float maxX, minX; // Sağ ve sol sınır değerleri
    public bool right, dontMove; // Sağ hareket ve durdurma kontrolü
    private bool stop; // Hareket durdurma durumu

    void Start()
    {
        // Hareket sınırlarını başlangıç pozisyonuna göre belirle
        maxX = transform.position.x + distance;
        minX = transform.position.x - distance;
    }

    void Update()
    {
        // Nesne durdurulmadıysa ve hareket engellenmediyse
        if (!stop && !dontMove)
        {
            if (right)
            {
                // Sağ yöne hareket et
                transform.position += Vector3.right * speed * Time.deltaTime;
                // Sağ sınırı aştığında sola dön
                if (transform.position.x >= maxX)
                    right = false;
            }
            else
            {
                // Sol yöne hareket et
                transform.position += Vector3.left * speed * Time.deltaTime;
                // Sol sınırı aştığında sağa dön
                if (transform.position.x <= minX)
                    right = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Çarpışma sırasında "White" tag'ine sahip nesneye veya "Player" isimli nesneye çarptığında
        if (other.gameObject.tag == "White" && other.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1 
            || other.gameObject.name == "Player")
        {
            stop = true; // Hareketi durdur
            GetComponent<Rigidbody>().freezeRotation = false; // Dönme kilidini kaldır
        }
    }
}
