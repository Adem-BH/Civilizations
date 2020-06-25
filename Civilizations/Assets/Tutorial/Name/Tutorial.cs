using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public bool InputName = false;
    public TextMeshProUGUI NameGUI;


    public AudioSource NameAudio;
    public TextMeshProUGUI NameText;

    public 

    IEnumerator Tutor()
    {

        NameAudio.Play();
        NameText.DOFade(1, 0.5f);
        yield return new WaitForSeconds(NameAudio.clip.length);



    }

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void NameChange(string Name)
    {


        NameGUI.text = Name;


    }

}
