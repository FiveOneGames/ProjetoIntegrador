using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{

    public int agroRange = 5;
    public GameObject target, objTiro;
    public Rigidbody rb;
    private bool isMoving;
    private Vector3 moveDirection;
    public float waitTime = 3;
    private float waitCounter;
    public float moveTime = 5;
    private float moveCounter;
    private Animator anim;
    private float moveSpeed;
    public int speed = 3;
    private float nextFireTime = 0f;
    public float fireRate = 1f;

   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        anim.SetBool("walk", false);
        RandomWaitCounter();
        RandomMoveCounter();
        moveSpeed = 50;

    }

    private void Update()
    {
  
       if (Vector3.Distance(target.transform.position, transform.position) >= agroRange)
        {
            anim.SetBool("attack", false);
            if (isMoving)
            {
                moveCounter -= Time.deltaTime;
                rb.velocity = moveDirection;

                if (moveCounter < 0.0f)
                {
                    isMoving = false;
                    RandomWaitCounter();
                    anim.SetBool("walk", false);
                }

            }
            else
            {
                waitCounter -= Time.deltaTime;
                rb.velocity = Vector3.zero;

                if (waitCounter < 0.0f)
                {
                    isMoving = true;
                    RandomMoveCounter();
                    moveDirection = new Vector3(Random.Range(-0.5f, 0.5f) * moveSpeed, 0.0f, Random.Range(-0.5f, 0.5f));

                    anim.SetBool("walk", true);


                }
            }

            if (rb.velocity != Vector3.zero)
            {
                //Andar virado para frente
                transform.rotation = Quaternion.LookRotation(rb.velocity.normalized);
                moveSpeed = 50;
            }
        }
        else
        {
         
            transform.LookAt(target.transform.position);
            //Dentro do alcance de agro, move em direção ao jogador
            Vector3 dirToPlayer = (target.transform.position - transform.position).normalized;
            rb.velocity = dirToPlayer * moveSpeed;
            
            anim.SetBool("walk", true);
            anim.SetBool("attack", true);
            moveSpeed = 10;
            if (Time.time >= nextFireTime)
            {
                AtackEnemy();
                nextFireTime = Time.time + 1f / fireRate; //Atualiza o proximo tempo de tiro

            }

        }
    }








    public void RandomWaitCounter()
    {
        waitCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);

    }
    public void RandomMoveCounter()
    {
        moveCounter = Random.Range(moveTime * 0.75f, moveTime * 1.25f);

    }


    public void AtackEnemy()
    {
        Vector3 targetDirection = (target.transform.position - transform.position).normalized;
        Vector3 AlturaAttack = new Vector3 (transform.position.x, (transform.position.y + 3), transform.position.z);
        //Instancia o tiro na posição e rotaçao do inimigo
        GameObject tiro = Instantiate(objTiro, AlturaAttack, Quaternion.Euler(0f, 0f, 0f));
        

        //Obtem o componente rigidbody do tiro e define sua velocidade na direcao do jogador
        Rigidbody tiroRb = tiro.GetComponent<Rigidbody>();
        tiroRb.velocity = targetDirection * speed;

        Destroy(tiro, 2f);

    }
    



   
















}
