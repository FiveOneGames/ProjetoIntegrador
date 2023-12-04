using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 30;
    public float speedRotation;
    Animator m_Animator;
    public int life = 100;
    private bool ischao;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        ischao = true;
    }

    // Update is called once per frame
    void Update()
    {
        float moveV = -(Input.GetAxis("Vertical"));
        transform.Translate(moveV * Time.deltaTime * speed, 0, 0);

        float moveH = Input.GetAxis("Horizontal");
        transform.Rotate(0, moveH * Time.deltaTime * speedRotation, 0);

        if (moveH > 0 || moveH < 0 || moveV > 0 || moveV < 0)
        {

            m_Animator.SetBool("walk", true);

        }
        else
        {
            m_Animator.SetBool("walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) & ischao)
        {
            m_Animator.SetBool("jump", true);
            transform.Translate(0, 20 * Time.deltaTime * 40, 0);
            ischao = false;
        }
        else
        {
            m_Animator.SetBool("jump", false);
        }

        if (!ischao)
        {
            transform.Translate(0, -1 * Time.deltaTime * 20, 0);

        }

        if (Input.GetKey(KeyCode.X))
        {
            m_Animator.SetBool("attack", true);

            

        }
        else
        {
            m_Animator.SetBool("attack", false);

        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            attack();
        }

    }
    void attack()
    {
        if (Input.GetKey(KeyCode.X))
        {
            m_Animator.SetBool("attack", true);



        }
        else
        {
            m_Animator.SetBool("attack", false);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            life -= 25;
            if (life <= 0)
            {
             
                life = 100;
                this.transform.position = GameObject.Find("inicio").transform.position;
                this.transform.eulerAngles = new Vector3(0, 0, 0);
            }



        }


        if (collision.gameObject.tag == "terreno")
        {
            ischao = true;


        }

        if (collision.gameObject.tag == "Reflorestamento")
        {
            SceneManager.LoadScene("Reflorestamento");

        }

        

    }







}
