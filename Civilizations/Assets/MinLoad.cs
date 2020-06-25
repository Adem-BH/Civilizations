using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinLoad : MonoBehaviour
{

    public Image Close1;
    public Image Close2;
    public float CloseTime;
    public Vector2 CloseTowards1;
    public Vector2 CloseTowards2;
    public GameObject Closes;

    public GameObject Minimap;

    void Start()
    {
        Closes.SetActive(true);
        Close1.rectTransform.DOMoveX(CloseTowards1.x, CloseTime);
        Close2.rectTransform.DOMoveX(CloseTowards2.x, CloseTime);
        Invoke("False", 2);
    }

  
    void Update()
    {


        



    }

    public void False()
    {

        Closes.SetActive(false);
        Minimap.SetActive(true);

    }

}
