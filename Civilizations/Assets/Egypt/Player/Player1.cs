using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{

    public bool IsFacingRight = true;

    public float Speed;
    public float Smooth;

    private Rigidbody2D rb;
    private Animator ar;

    public LayerMask WhatIsGround;
    public Transform GroundChecker;
    public float Radius;

    public bool IsGrounded = true;
    public bool IsOnMainGround;
    public float JumpForce;

    public float TimeBtwAttacks;
    public Transform AttackPos;
    public LayerMask WhatIsEnemies;
    public float AttackRange;

    public float Health;
    public Slider HealthSlide;
    public GameObject CheckpointPos;

    public GameObject GameOver;


    public GameObject Wall1;
    public GameObject Wall2;

    public float MummiesKilled = 0;
    public GameObject Spawner;
    public bool attacking = false;
    public GameObject Blood;
    public AudioSource SwordEffect;

    public bool AbleToAttack = true;
    public float DamageToBoss;

    public int Coins;
    public int CoinsPlus;

    public int Trail;

    public GameObject Scorpion;
   
    IEnumerator CoolDown()
    {
        
        yield return new WaitForSeconds(TimeBtwAttacks);
        AbleToAttack = true;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Traps")
        {

            Health = 0;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name== "Detector")
        {

            Wall1.SetActive(true);
            Wall2.SetActive(true);
        }
    }

    void Start()
    {

        Trail = PlayerPrefs.GetInt("Trail");

        if(Trail == 1)
        {

            GetComponent<TrailRenderer>().enabled = true;

        }


        Time.timeScale = 1;
        Coins = PlayerPrefs.GetInt("Coins");
        rb = GetComponent<Rigidbody2D>();
        ar = GetComponent<Animator>();

    }

    void FixedUpdate()
    {

        if(HealthSlide.value != Health)
        {

            HealthSlide.value = Health;

        }

        float x = Input.GetAxisRaw("Horizontal") * Speed;

        Vector2 TargetVelocity = new Vector2(x, rb.velocity.y);

        rb.velocity = Vector2.SmoothDamp(rb.velocity, TargetVelocity, ref TargetVelocity, Smooth * Time.deltaTime);

        ar.SetBool("Walking", x!= 0 && IsGrounded == true);
        ar.SetBool("Jumping", rb.velocity.y != 0);
        ar.SetBool("Running", Input.GetKey(KeyCode.LeftShift) && x !=0 && IsGrounded == true);
        ar.SetBool("Attacking", attacking);

        if ( x > 0 && IsFacingRight == false)
        {

            Flip();

        }

        else if (x < -1 && IsFacingRight == true)
        {

            Flip();

        }

        IsGrounded = Physics2D.OverlapCircle( GroundChecker.position , Radius, WhatIsGround );
       

       

        if (Input.GetKey(KeyCode.LeftShift))
        {

            Speed = 13;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            Speed = 10;

        }

    
    }

    void Flip()
    {

        IsFacingRight = !IsFacingRight;
        Vector3 scaler = transform.localScale;
            scaler.x *= -1;
        transform.localScale = scaler;

    }

     void Update()
    {
        if (IsGrounded)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                rb.velocity = new Vector2(rb.velocity.x, JumpForce);

            }

        }

        if (MummiesKilled >= 30)
        {

            Spawner.SetActive(false);

        }

        if(AbleToAttack == true)
        {


            if (Input.GetKeyDown(KeyCode.Mouse0) && AbleToAttack == true)
            {
                SwordEffect.Play();
                attacking = true;
                AbleToAttack = false;
                Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, WhatIsEnemies);

                

                for(int i =0; i < EnemiesToDamage.Length; i++)
                {
                    

                    if (EnemiesToDamage[i].tag == "Mummies")
                    {

                        Instantiate(Blood, EnemiesToDamage[i].gameObject.transform.position, Quaternion.identity);
                        EnemiesToDamage[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                        Destroy(EnemiesToDamage[i]);

                        EnemiesToDamage[i].gameObject.GetComponent<Animator>().SetBool("Dead", true);
                    }

                    if(EnemiesToDamage[i].tag == "Boss")
                    {
                        print("Boss");
                        EnemiesToDamage[i].GetComponent<Boss>().Health -= DamageToBoss;

                    }


                }
                StartCoroutine(CoolDown());
            }



          

        }

      

        if(Health <= 0)
        {


            GameOver.SetActive(true);
            Time.timeScale = 0.0001f;
            

        }


    }


    private void OnDrawGizmosSelected()
    {


        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);

    }

    public void BackToIdle()
    {

        attacking = false;

    }

    public void Restart()
    {
        if (GetComponent<Anubis>().CheckPoint == false)
        {
            SceneManager.LoadScene("Egypt");
        }

        else if (GetComponent<Anubis>().CheckPoint == true)
        {

            transform.position = CheckpointPos.transform.position;
            Health = 100;
            GameOver.SetActive(false);
            Scorpion.GetComponent<Boss>().Health = 500;
            Time.timeScale = 1;



        }


    }

    public void Quit()
    {

        SceneManager.LoadScene(0);

    }

    public void Done()
    {
        Coins += CoinsPlus;
        PlayerPrefs.SetInt("Coins", Coins);
        SceneManager.LoadScene(0);

    }

    public void TakeDamage(float Damage)
    {

        Health -= Damage;

    }

}
