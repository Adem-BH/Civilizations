using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    public float Health;
    public Slider HealthSlider;

    public GameObject Limits;
    public bool InLimits;

    public Vector2 Dis;

    public GameObject Poison;
    public Transform FirePoint;

     GameObject Player;

    public bool IsFacingRight = true;

    public Vector3 ResetPosition;

   public bool Attack;
    public float AttackDamage;

    public bool Dead = false;

    public GameObject Done;

    

    void Start()
    {
       
        Player = GameObject.FindGameObjectWithTag("Player");

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Attack = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            Attack = false;

        }
    }

    void Update()
    {
        if(HealthSlider.value != Health)
        {

            HealthSlider.value = Health;

        }

        if(Health <= 0)
        {
            Done.SetActive(true);
            GetComponent<Animator>().SetBool("Dead", true);
            Dead = true;

        }

        ResetPosition = new Vector3(89.45f, transform.position.y, 0);

         Dis = Player.transform.position - transform.position;
        Vector2 Dir2Spwn = ResetPosition - transform.position;

        if (InLimits || InLimits == false && transform.position == ResetPosition)
        {

            Scale(Dis);

        }

       

        else if (InLimits == false && transform.position != ResetPosition)
        {

            Scale(Dir2Spwn);

        }

       




    }
    
    public void Flip()
    {
        //Quaternion Rot = transform.rotation;

        //if (Rot.y < 100)
        //{
        //    IsFacingRight = false;
        //    Rot.y = 180;
        //    transform.rotation = Rot;

        //}

        //else if(Rot.y > 100)
        //{

        //    IsFacingRight = true;
        //    Rot.y =0;
        //    transform.rotation = Rot;

        //}

        IsFacingRight = !IsFacingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    void Scale(Vector2 Dir)
    {

        if (Dir.normalized.x > 0 && IsFacingRight == false)
        {

            Flip();

        }

        if (Dir.normalized.x < 0 && IsFacingRight == true)
        {

            Flip();

        }

    }

    public void Shoot()
    {

       float angle = Mathf.Atan2(Dis.y, Dis.x) * Mathf.Rad2Deg;
        Quaternion Rotation = Quaternion.Euler(0, 0, angle);

        Instantiate(Poison, FirePoint.position,Rotation);

      

    }

    public void Damage()
    {

        Player.GetComponent<Player1>().TakeDamage(AttackDamage);

    }

}
