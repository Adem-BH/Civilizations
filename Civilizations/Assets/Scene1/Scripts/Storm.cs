using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : MonoBehaviour
{

    public float Damage;
    GameObject Player;
  

    public AudioSource Thunder;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            Player.GetComponent<Player>().TakeDamage(Damage);
            Damage = 0;

            StormSpawn.instance.UI = true;
            Thunder.Play();

            

            Invoke("Destroy", Thunder.clip.length);
            

        }
    }
    
    void Start()
    {
        Damage = Random.Range(10, 20);
        Player = GameObject.Find("Player");
        
    }

    void FixedUpdate()
    {
       

        
    }

    public void Destroy()
    {
        StormSpawn.instance.Respawns--;
        
        Destroy(gameObject);

    }

    

}
