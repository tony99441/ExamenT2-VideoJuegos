using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game1Controller : MonoBehaviour
{
    private int Vidas = 3;
    public Text VidasText;

    private int Enemigos = 5;
    public Text EneRestantes;
    
    // Start is called before the first frame update
    void Start()
    {
        VidasText.text = "Vidas Restantes: " +Vidas;
        EneRestantes.text = "Enemigos Restantes: " + Enemigos; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestaVidas1(int vidas)
    {
        this.Vidas -= vidas;
        VidasText.text = "Vidas Restantes: " + Vidas;

    }

    public void RestaEnemigos1(int enemigos)
    {
        this.Enemigos -= enemigos;
        EneRestantes.text = "Enemigos Restantes: " + Enemigos;

    }
    
    
    public void NoVidas1()
    {
        VidasText.text = "No tienes vidas :(";
    }
}
