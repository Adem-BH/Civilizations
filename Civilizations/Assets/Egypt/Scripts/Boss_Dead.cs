using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Dead : StateMachineBehaviour
{
   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.GetComponent<Rigidbody2D>().isKinematic = true;
        animator.GetComponent<PolygonCollider2D>().enabled = false;
        animator.GetComponent<Boss>().enabled = false;


    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    

  
}
