using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semente : MonoBehaviour
{
    public GameObject semente;
    public int speed = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            JogarSemente();
           
        }



    }

    public void JogarSemente()
    {
        Vector3 targetDirection = (transform.position).normalized;
        Vector3 AlturaAttack = new Vector3(transform.position.x, (transform.position.y + 3), transform.position.z);
        //Instancia o tiro na posição e rotaçao do inimigo
        GameObject sem = Instantiate(semente, AlturaAttack, Quaternion.Euler(0f, 0f, 0f));


        //Obtem o componente rigidbody do tiro e define sua velocidade na direcao do jogador
        Rigidbody sementeRb = sem.GetComponent<Rigidbody>();
        sementeRb.velocity = targetDirection * speed;

        Destroy(sem, 2f);

    }
}
