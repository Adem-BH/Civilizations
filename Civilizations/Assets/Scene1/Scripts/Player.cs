using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float Speed;
    public float Smooth;
    public float RotationSpeed;
    public bool AbleToMove;

    public bool ResetHealth = false;
    public int MaxHealth = 100;

    public float Health;
    public Slider HealthSlider;

    public GameObject GameOver;

    private Rigidbody2D rb;

    public TextMeshProUGUI Name;
    
   
    
    void Start()
    {

        Time.timeScale = 1;
        print(PlayerPrefs.GetString("PlayerName"));
        Name.text = PlayerPrefs.GetString("PlayerName");
        AbleToMove = true;
        Health = PlayerPrefs.GetFloat("Health");
        rb = GetComponent<Rigidbody2D>();

    }


    void FixedUpdate()
    {



        if(PlayerPrefs.GetFloat("Health") != Health)
        {

            PlayerPrefs.SetFloat("Health", Health);


        }

        if(HealthSlider.value != Health)
        {
            HealthSlider.value = Health;

        }
       
        if (AbleToMove == true)
        {
            Mouvement();
        }



    }

     void Update()
    {
        if(ResetHealth == true)
        {

            PlayerPrefs.SetFloat("Health", MaxHealth);
            ResetHealth = false;

        }


        if(Health <= 0)
        {

            Health = 0;
            AbleToMove = false;
            GameOver.SetActive(true);
            

        }
    }

    public  void Mouvement()
    {

        Vector2 Direction = Vector2.zero;
        Direction.x = Input.GetAxisRaw("Horizontal");
        Direction.y = Input.GetAxisRaw("Vertical");


        Vector2 TargetVelocity = Direction * Speed;


        rb.velocity = Vector2.SmoothDamp(rb.velocity, TargetVelocity, ref TargetVelocity, Smooth * Time.fixedDeltaTime);

        if (Direction != Vector2.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, Direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        }

    } 

    public void TakeDamage(float Ammount)
    {

        Health -= Ammount;
        PlayerPrefs.SetFloat("Health", Health);

    }

    public void Restart()
    {
        PlayerPrefs.SetFloat("Health", 100f);
        PlayerPrefs.SetFloat("Coins", 0);
        PlayerPrefs.SetInt("Trail", 0);
        GetComponent<Power>().PowerAmmount = 500f;
        PlayerPrefs.SetFloat("Power", 500f);
        GameOver.SetActive(false);
        SceneManager.LoadScene(0);
        

    }
}
