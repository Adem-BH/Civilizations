using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Walk : StateMachineBehaviour
{

    public GameObject Player;
    public float Speed;

    
    public GameObject Scorpion;

    public bool IsFacingRight = false;

    private Rigidbody2D rb;


    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
            rb = animator.GetComponent<Rigidbody2D>();
        Scorpion = animator.gameObject;
        
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

       
        

        if (animator.GetComponent<Boss>().InLimits) rb.transform.position = Vector2.MoveTowards(animator.transform.position, Player.transform.position, Speed * Time.deltaTime);

        else if(animator.GetComponent<Boss>().InLimits == false)
        {
            if (animator.transform.position.x != animator.GetComponent<Boss>().ResetPosition.x)
            {
                rb.transform.position = Vector2.MoveTowards(animator.transform.position, animator.GetComponent<Boss>().ResetPosition, Speed * Time.deltaTime);

               
            }


            

        }

        if (animator.GetComponent<Boss>().InLimits == false && animator.transform.position == animator.GetComponent<Boss>().ResetPosition)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Sting", true);


        }


        if (animator.GetComponent<Boss>().InLimits && animator.GetComponent<Boss>().Attack == true)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Attack", true);


        }





    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Walk", false);
       

    }

    
    
   

    

}
