using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using System;

public class Shop : MonoBehaviour
{
    public GameObject ShopGui;

    public float price;

    public TextMeshProUGUI Bought;
    public TextMeshProUGUI NoCoins;
    public TextMeshProUGUI FixPrice;

    IEnumerator Message(TextMeshProUGUI Message)
    {

        Message.gameObject.SetActive(true);
        Message.DOFade(1, 1);
        yield return new WaitForSeconds(1);
        Message.DOFade(0, 1);
        yield return new WaitForSeconds(1.2f);
        Message.gameObject.SetActive(false);

    }

    void Start()
    {
       
       

    }


    void Update()
    {

        price = Mathf.Floor(GetComponent<Player>().MaxHealth) - Mathf.Floor(GetComponent<Player>().Health);
        

        if (FixPrice.text != price.ToString())
        {

            FixPrice.text = price.ToString();


        }

    }

    public void Active()
    {

        ShopGui.SetActive(true);

    }

    public void Cancel()
    {

        ShopGui.SetActive(false);

    }

    public void Trail()
    {

        if (PlayerPrefs.GetInt("Trail") == 0)
        {

            if (GetComponent<Coins>().CoinAmmount >= 1000)
            {
                PlayerPrefs.SetInt("Trail", 1);

                GetComponent<Coins>().CoinAmmount -= 1000;

            }
        }

        else if(PlayerPrefs.GetInt("Trail") == 1)
        {


            StartCoroutine(Message(Bought));


        }

        else if(GetComponent<Coins>().CoinAmmount < 1000)
        {

            StartCoroutine(Message(NoCoins));

        }


    }


    
    

    public void Fix()
    {

        if (GetComponent<Coins>().CoinAmmount >= price)
        {
            GetComponent<Player>().Health += price;

            GetComponent<Coins>().CoinAmmount -= (int)price;
        }


    }

    public void Exit()
    {

        ShopGui.SetActive(false);

    }

}
