using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaGrandeController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocityX = 15f;

    private GameController game; 
    
    private EnemigoController enemigo;

    private Enemigo1Controller enemigo1;

    private Enemigo2Controller enemigo2; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        game = FindObjectOfType<GameController>();
        enemigo = FindObjectOfType<EnemigoController>();
        enemigo1 = FindObjectOfType<Enemigo1Controller>();
        enemigo2 = FindObjectOfType<Enemigo2Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Enemigo") ) {
                
            Debug.Log("Ha topado al enemigo");
            enemigo.VidasEnemigo(2);

        } 
        if (other.gameObject.CompareTag("Enemigo1") ) {
            
            enemigo1.VidasEnemigo1(2);
            
        } 
        if (other.gameObject.CompareTag("Enemigo2") ) {
            
            enemigo2.VidasEnemigo2(2);
            
        } 
        
        
        
        

        if (other.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }

       
    
    }
    
}
