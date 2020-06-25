using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameRegister : MonoBehaviour
{
    public TextMeshProUGUI nameText;

    public void RegisterName()
    {
        PlayerPrefs.SetString("PlayerName", nameText.text);
    }

    public void Update()
    {
        if(PlayerPrefs.GetString("PlayerName") != nameText.text)
        {

            RegisterName();

        }
    }
}
