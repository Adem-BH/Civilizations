using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting : StateMachineBehaviour
{
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Attack", false);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {





        if (animator.GetComponent<Boss>().InLimits == true)
        {

            animator.SetBool("Walk", true);
            animator.SetBool("Sting", false);
         
           


        }




    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Sting", false);
    }

    

    
}
