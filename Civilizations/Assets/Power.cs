using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Power : MonoBehaviour
{
    public float PowerAmmount;

    public GameObject AttackGui;
    public GameObject WonGui;
    public GameObject LostGui;
    public GameObject EnemyShip;
    public GameObject GrandParent;

    public TextMeshProUGUI PowerDisplay;

    public float EnemyPower;

    public float Multiplier;
    public int FixedPercentage = 50;
    public float Percentage;

    public int LuckNumber;
    void Start()
    {
        
        PlayerPrefs.GetFloat("Power");

        PowerAmmount = PlayerPrefs.GetFloat("Power");
        PowerAmmount = Mathf.Floor(PowerAmmount);

    }

    // Update is called once per frame
    void Update()
    {
       
        
        if(PlayerPrefs.GetFloat("Power") != PowerAmmount)
        {

            PlayerPrefs.SetFloat("Power", PowerAmmount);


        }

        if(PowerDisplay.text != PowerAmmount.ToString())
        {

            PowerDisplay.text = PowerAmmount.ToString();

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ships")
        {

            EnemyPower = collision.gameObject.GetComponent<Bots>().Power;
            AttackGui.SetActive(true);
            EnemyShip = collision.gameObject;
            EnemyShip.GetComponentInParent<AIPath>().canMove = false;
            GrandParent = EnemyShip.transform.parent.transform.parent.gameObject;

        }
    }

    public void Attack()
    {

        Multiplier = PowerAmmount / EnemyPower;
      
        Percentage = FixedPercentage * Multiplier;
     
        Percentage = Mathf.Floor(Percentage);

        LuckNumber = Random.Range(0, 100);

        if(LuckNumber <= Percentage)
        {

            WonGui.SetActive(true);
            AttackGui.SetActive(false);
            GetComponent<Player>().Health -= 20;
            PowerAmmount += 100;
            GetComponent<Coins>().CoinAmmount += 1000;
            EnemyShip.GetComponentInParent<AIPath>().canMove = true;
            EnemyShip.GetComponent<Bots>().AbleToChange = true;
        }

        else if(LuckNumber > Percentage)
        {

            LostGui.SetActive(true);
            AttackGui.SetActive(false);
            GetComponent<Player>().Health -= 50;
            EnemyShip.GetComponentInParent<AIPath>().canMove = true;

        }

        
    }

    public void Cancel()
    {


        AttackGui.SetActive(false);
        EnemyShip.GetComponentInParent<AIPath>().canMove = true;

    }

    public void CancelWon()
    {

        WonGui.SetActive(false);

    }

    public void CancelLost()
    {

        LostGui.SetActive(false);

    }
}
