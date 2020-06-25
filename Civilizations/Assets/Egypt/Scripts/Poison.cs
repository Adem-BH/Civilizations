using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{

    public float Damage;
    public GameObject Player;

    public Vector3 PlayerPos;

    public float PoisonSpeed;
    public bool Collided = false;


    public float Alpha;


    IEnumerator TakeDamage()
    {

        GetComponent<Renderer>().enabled = false;

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1);
            Player.GetComponent<Player1>().TakeDamage(Damage/5);

            if (i == 4)
            {
                Destroy(gameObject);

            }
        }


    }


    void Start()
    {
       

        GetComponent<Rigidbody2D>().velocity = transform.up * PoisonSpeed;

        Player = GameObject.FindGameObjectWithTag("Player");

        PlayerPos = Player.transform.position;

        Alpha = GetComponent<Renderer>().material.color.a;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            Collided = true;
            StartCoroutine(TakeDamage());

        }
    }

    void FixedUpdate()
    {

        transform.position = Vector2.MoveTowards(transform.position, PlayerPos, PoisonSpeed  );

        if(Collided == false && transform.position == PlayerPos)
        {

            Destroy(gameObject);


        }



    }


    

  

   

}
