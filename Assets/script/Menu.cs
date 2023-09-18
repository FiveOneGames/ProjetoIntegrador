using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    //public Texture2D cursorTexture;
    void Start()
    {
        //Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);

    }

    public void Jogar()
    {
        SceneManager.LoadScene("Fase final");
    }

    public void Sair()
    {
        Application.Quit();
    }


}