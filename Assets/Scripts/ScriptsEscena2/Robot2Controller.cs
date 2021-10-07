using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Robot2Controller : MonoBehaviour
{
    public float velocityX;
    public float JumpForce; 
    
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    private const int Idle = 0;
    private const int Run = 1;
    private const int Jump = 2;
    private const int Slide = 3;
    private const int RunShot = 4;
    private const int Shoot = 5;
    private const int Dead = 6;
    
    
    private int estaMuerto = 0;
    
    
    public GameObject balaDerecha; 
    public GameObject balaIzquierda; 

    
    public GameObject balaGrandeDerecha; 
    public GameObject balaGrandeIzquierda; 
    
    private float cargarTiempo = 0;

    private GameController game; 
    private int vidasRestantes = 3;

    private GameTerminaController gametermina; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        game = FindObjectOfType<GameController>();
        gametermina = FindObjectOfType<GameTerminaController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (estaMuerto == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            changeAnimation(Idle);
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-velocityX, rb.velocity.y);
                sr.flipX = true;
                changeAnimation(Run);
            } 
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(velocityX, rb.velocity.y);
                sr.flipX = false;
                changeAnimation(Run);
            }
            
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                rb.AddForce(Vector2.up*JumpForce, ForceMode2D.Impulse);
                changeAnimation(Jump);
            }
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(velocityX, rb.velocity.y);
                changeAnimation(Slide);
            }
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-velocityX, rb.velocity.y);
                changeAnimation(Slide);
            }

            
            
            if (Input.GetKey(KeyCode.X))
            {
                cargarTiempo += Time.deltaTime;
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                if (cargarTiempo < 1)
                {
                    var bala = sr.flipX ? balaIzquierda : balaDerecha;
                    var position = new Vector2(transform.position.x, transform.position.y);
                    var rotation = balaDerecha.transform.rotation;
                    Instantiate(bala, position, rotation);
                }else if (cargarTiempo <3)
                {
                    var balaG = sr.flipX ? balaGrandeIzquierda : balaGrandeDerecha;
                    var positionG = new Vector2(transform.position.x, transform.position.y);
                    var rotationG = balaGrandeDerecha.transform.rotation;
                    Instantiate(balaG, positionG, rotationG);  
                }
                cargarTiempo = 0;
            }
            
            
        }
        
        if (estaMuerto == 1)
        {
            changeAnimation(Dead);
            SceneManager.LoadScene("Escene2");
        }
        
    }
    
    
    
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            game.RestaVidas(1);
            Debug.Log(" Si choca con el enemigo");
            vidasRestantes -= 1; 

        }
        if (vidasRestantes <=0)
        {
            estaMuerto = 1;
            game.NoVidas();
           
            
        }

        if (collision.gameObject.CompareTag("LLave"))
        {
            SceneManager.LoadScene("Escene2");
        }

        if (collision.gameObject.CompareTag("LlaveFinal"))
        {
            gametermina.LlamarGameOver();
        }



    }
    
}
