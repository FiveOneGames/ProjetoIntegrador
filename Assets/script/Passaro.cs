using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Passaro : MonoBehaviour
{

    int moveSpeed = 50;
    public Rigidbody rb;
    private Vector3 moveDirection;
    private float tempo = 200;


    private void Start()
    {
        Movimenta_passaro();
    }



    void Update()
    {


        if (tempo > 0)
        {
            tempo--;
            transform.rotation = Quaternion.LookRotation(rb.velocity.normalized);
            

        }
        else
        {
            Movimenta_passaro();
            tempo = 200;

        }


    }



    void Movimenta_passaro()
    {

      
        moveDirection = new Vector3(Random.Range(-0.5f, 0.5f) * moveSpeed, 0.0f, Random.Range(-0.5f, 0.5f));
        rb.velocity = moveDirection;

        
    }
}