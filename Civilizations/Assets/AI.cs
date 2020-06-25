using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public bool Scan1 = true;

   IEnumerator Scan()
    {
        Scan1 = false;
        yield return new WaitForSeconds(0.3f);
        AstarPath.active.Scan();
        Scan1 = true;
    }

    void Start()
    {
        
     

    }


    void Update()
    {
        if (Scan1 == true)
        {
            StartCoroutine(Scan());
        }

    }
}
