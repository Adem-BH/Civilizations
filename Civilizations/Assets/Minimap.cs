using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    public Transform Camera;



    void Start()
    {
        


    }

    
    void FixedUpdate()
    {
      
         
        

    }

    private void LateUpdate()
    {
        Vector3 Newpos = Camera.transform.position;
        Newpos.z = transform.position.z;
        transform.position = Newpos;
    }

}
