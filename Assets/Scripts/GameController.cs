using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int Vidas = 3;
    public Text VidasText;

    private int Enemigos = 8;
    public Text EneRestantes;

    public float tiempo = 0.0f;
    public Text TiempoText;

   
    // Start is called before the first frame update
    void Start()
    {
        VidasText.text = "Vidas Restantes: " +Vidas;
        EneRestantes.text = "Enemigos Restantes: " + Enemigos; 
    }

    // Update is called once per frame
    void Update()
    {

        tiempo -= Time.deltaTime;
        TiempoText.text = "Tiempo Restante: " + tiempo.ToString("f0");

        if (tiempo <= 0)
        {
            SceneManager.LoadScene("Escene2");
        }

    }
    
    public void RestaTiempo()
    {
        
        
    }

    public void RestaVidas(int vidas)
    {
        this.Vidas -= vidas;
        VidasText.text = "Vidas Restantes: " + Vidas;

    }

    public void RestaEnemigos(int enemigos)
    {
        this.Enemigos -= enemigos;
        EneRestantes.text = "Enemigos Restantes: " + Enemigos;

    }
    
  

    
    public void NoVidas()
    {
        VidasText.text = "No tienes vidas :(";
    }

}
