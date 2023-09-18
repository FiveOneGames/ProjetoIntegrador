using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Hud : MonoBehaviour
{
    public Image life; //pega o componente Image da unity
    public Sprite image0;
    public Sprite image25;
    public Sprite image50;
    public Sprite image75;
    public Sprite image100;
    public GameObject player; //Pega o player
    private bool gerarimage; //variavel de controle
    //public Text text; //pega o componente text da unity


    void Start()
    {
        life.sprite = image100;
        gerarimage = false;
        //text.text = "0";


    }





    void Update()
    {
        
        if (player.GetComponent<Player>().life == 100 && gerarimage == true)
        {
            StartCoroutine(WaitImage(0.5f));
            
        }
        else if (player.GetComponent<Player>().life == 75)
        {
            life.sprite = image75;
        }
        else if (player.GetComponent<Player>().life == 50)
        {
            life.sprite = image50;

        }
        else if (player.GetComponent<Player>().life == 25)
        {
            life.sprite = image25;
            gerarimage = true;
        }

        //text.text = Convert.ToString(player.GetComponent<Player>().moeda);

    }




     private IEnumerator WaitImage(float waitTime)
     {
         life.sprite = image0;
         yield return new WaitForSeconds(waitTime);
         life.sprite = image100;
         gerarimage = false;
     }
    



}

