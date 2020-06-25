using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{


    public Image Logo;
    public float Duration;


    IEnumerator Fade()
    {

        Logo.DOFade(1, Duration);
        yield return new WaitForSeconds(Duration);
        Logo.DOFade(0, Duration);
        yield return new WaitForSeconds(Duration);
        SceneManager.LoadScene(PlayerPrefs.GetInt("Load"));

    }

    void Start()
    {



        StartCoroutine(Fade());


    }



    void Update()
    {
        
    }
}
