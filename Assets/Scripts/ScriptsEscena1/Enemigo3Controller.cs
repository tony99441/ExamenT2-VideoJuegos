using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3Controller : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    private int camina = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camina == 0)
        {
            rb.velocity = new Vector2(4, rb.velocity.y);
            sr.flipX = false; 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ParedDerecha") )
        {
            Debug.Log("Toca Pared Derecha");
            sr.flipX = true;
            rb.velocity = new Vector2(-7, rb.velocity.y);
            camina = 1;
        }
        if (collision.gameObject.CompareTag("ParedIzquierda") && camina ==1)
        {
            Debug.Log("Toca Pared izquierda");
            rb.velocity = new Vector2(7, rb.velocity.y);
            sr.flipX = false;
        }

        
    }
}
