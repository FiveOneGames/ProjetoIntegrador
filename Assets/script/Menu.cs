using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{


    public void Jogar()
    {
        SceneManager.LoadScene("Fase 2");
    }

    public void Sair()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }


}