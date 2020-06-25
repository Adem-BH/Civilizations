using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Coins : MonoBehaviour
{

    public TextMeshProUGUI CoinGUI;
    public int CoinAmmount;


    void Start()
    {

        CoinAmmount = PlayerPrefs.GetInt("Coins");

    }

    void FixedUpdate()
    {

        if(CoinAmmount != PlayerPrefs.GetInt("Coins"))
        {

            
            PlayerPrefs.SetInt("Coins", CoinAmmount);

        }
        CoinGUI.text = CoinAmmount.ToString();

    }
}
