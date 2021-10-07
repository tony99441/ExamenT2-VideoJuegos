using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    private int camina = 0;
    
    private int VidasEnemy = 3;

    private GameController game; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        game = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camina == 0)
        {
            rb.velocity = new Vector2(4, rb.velocity.y);
            sr.flipX = false; 
        }
        
        if (VidasEnemy <=0)
        {
            Debug.Log("Personaje debe morir");
            Destroy(this.gameObject);
            game.RestaEnemigos(1);
            
            
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

    public void VidasEnemigo(int vidas)
    {
        this.VidasEnemy -= vidas;
        Debug.Log(VidasEnemy);
    }
    
   
    
}
