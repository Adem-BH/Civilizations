using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy : MonoBehaviour
{

    public GameObject Player;

    public float Speed;
    public float Damage;
    public bool IsFacingRight = true;

    private Rigidbody2D rb;
    private Animator ar;

    public float ShakeDuration;
    public float ShakeElapsedTime;

    public Camera MainCamera;

    public Vector2 Dir;
    public GameObject Spawner;


   
    void Start()
    {
        MainCamera = Camera.main;
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        ar = GetComponent<Animator>();
        Spawner = GameObject.Find("Spawner");

    }
    IEnumerator StopShake()
    {

        yield return new WaitForSeconds(ShakeDuration);

            MainCamera.GetComponent<Shake>().AbleToShake = false;

    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if(ShakeElapsedTime > 0)
        {

            MainCamera.GetComponent<Shake>().ShakeAmmount = 2;
            MainCamera.GetComponent<Shake>().AbleToShake = true;
            ShakeElapsedTime -= Time.deltaTime;
            StartCoroutine(StopShake());

        }

       

        Dir = Player.transform.position - transform.position;


        if (ar.GetBool("Attacking") == false)
        {

            rb.transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);

        }
      

       
       

        if (Dir.x > 0 && IsFacingRight == false)
        {

            Flip();

        }

        if(Dir.x < 0 && IsFacingRight == true)
        {

            Flip();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            ar.SetBool("Attacking", true);

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            ar.SetBool("Attacking", false);

        }
    }

    public void DamagePlayer()
    {

        ShakeElapsedTime = ShakeDuration;

        Player.GetComponent<Player1>().Health -= Damage;
        

    }

    public void Die()
    {
       

        Spawner.GetComponent<MummiesSpwner>().MummiesNumber++;
            Player.GetComponent<Player1>().MummiesKilled++;
        Destroy(gameObject);

    }

    public void Flip()
    {

        IsFacingRight = !IsFacingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;


    }

}
