using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mudar_cena : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        string cena = SceneManager.GetActiveScene().name;

        if (collision.gameObject.tag == "Player" && cena == "Fase 2")
        {
            SceneManager.LoadScene("cutsceF2");

        }

        if (collision.gameObject.tag == "Player" && cena == "Fase final")
        {
            SceneManager.LoadScene("Final 1_Cutscene");

        }


        if (collision.gameObject.tag == "Player" && cena == "Fase final 2")
        {
            SceneManager.LoadScene("Reflorestamento");

        }

    }



    public void MudarCenaMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void MudarCenaCutSceneChefe()
    {
        SceneManager.LoadScene("Fase final 2");

    }

}