using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Bots : MonoBehaviour
{

    public GameObject Direction;
    public Vector2 NewPos;
    public float RotationSpeed;
    public float X;
    public float Y;

    public float Power;
    public float PlayerPower;

    public GameObject gui;
    public TextMeshProUGUI PowerGUI;


    public GameObject Player;
    

    public AIPath Path;

    public bool AbleToChange;

    IEnumerator Change()
    {

        GetComponent<Renderer>().enabled = false;
        gui.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(20);

        GetComponent<Renderer>().enabled = true;
        gui.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = true;
        ChangePower();

        AbleToChange = false;

    }

    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
      

        ChangePower();


        X = Random.Range(-30.89f, 45.7f);
        Y = Random.Range(-34.6f, 23.22f);
        NewPos = new Vector2(X, Y);
        Direction.transform.position = NewPos;
    }

    // Update is called once per frame
    void Update()
    {

        if(AbleToChange == true)
        {

            StartCoroutine(Change());


        }


        if (PowerGUI.text != Power.ToString())
        {

            PowerGUI.text = Power.ToString();

        }

        Mouvement();

    }

    private void FixedUpdate()
    {

        gui.transform.position = new Vector2(transform.position.x , transform.position.y + 1.4f);
        
        
    }

    void ChangePos()
    {
        X = Random.Range(-30.89f, 45.7f);
        Y = Random.Range(-34.6f, 23.22f);
        NewPos = new Vector2(X, Y);
        Direction.transform.position = NewPos;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ships" || collision.gameObject.tag == "Island")
        {

            ChangePos();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Direction)
        {

            ChangePos();

        }

        if (collision.gameObject.tag == "MinDistance" || collision.gameObject.tag == "Island" )
        {

            ChangePos();

        }
    }

   



    public void Mouvement()
    {

        Vector2 Direction = Vector2.zero;
        Direction.x = Path.desiredVelocity.x;
        Direction.y = Path.desiredVelocity.y;

        

        if (Direction != Vector2.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.back, Direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        }

    }

    public void ChangePower()
    {
        PlayerPower = Player.GetComponent<Power>().PowerAmmount;

        Power = Random.Range(PlayerPower - 300, PlayerPower + 300);

        if (Power < 0)
        {

            Power = Random.Range(100, 500);

        }

        Power = Mathf.Floor(Power);

    }

    


}




