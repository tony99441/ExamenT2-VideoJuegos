using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTerminaController : MonoBehaviour
{
    
   
    private int Termina;
    public Text TerminaText;
  
    // Start is called before the first frame update
    void Start()
    {
        
TerminaText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LlamarGameOver()
    {
        TerminaText.gameObject.SetActive(true);
        TerminaText.text = "Juego Terminado !!! ";
    }

}
