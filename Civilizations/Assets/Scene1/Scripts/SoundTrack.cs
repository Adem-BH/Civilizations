using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrack : MonoBehaviour
{

    public AudioSource[] Songs;
    public int SongNumber = 0;
    public bool AbleToPlay = false;
    AudioSource Current;

    IEnumerator Sing()
    {

        

        if (Current.isPlaying == false)
        {

            Current = Songs[SongNumber];
            Current.Play();
            print(SongNumber);
            
            yield return new WaitForSeconds(Current.clip.length);
      
           

        }


    }

    void Start()
    {

        Current = Songs[SongNumber];

    }
    void Update()
    {

        if(SongNumber >= Songs.Length)
        {

            SongNumber = 0;

        }

        if (AbleToPlay == true && Current.isPlaying == false)
        {
            for (int i = 0; i < 1; i++)
            {
                SongNumber++;
            }
            StartCoroutine(Sing());
            

        }

       

        if (Input.GetKeyDown(KeyCode.E) && Current.isPlaying == true)
        {



            Current.Stop();

            for (int i = 0; i < 1; i++)
            {
                SongNumber++;
            }

            if (SongNumber >= Songs.Length)
            {

                SongNumber = 0;

            }
            Current = Songs[SongNumber];
            StartCoroutine(Sing());
            



        }

        if (Input.GetKeyDown(KeyCode.Q) && Current.isPlaying == true)
        {

           

            Current.Stop();
            for (int i = 0; i < 1; i++)
            {
                SongNumber--;
            }
            if (SongNumber < 0)
            {

                SongNumber = 8;

            }
            Current = Songs[SongNumber];
            StartCoroutine(Sing());




        }


        if (Input.GetKeyDown(KeyCode.E) && Current.isPlaying == false && AbleToPlay == false )
        {

            AbleToPlay = true;

            Current = Songs[SongNumber];


            StartCoroutine(Sing());

           

           

        }

        


        if (Input.GetKeyDown(KeyCode.B))
        {


            if(Current.isPlaying == true)
            {

                AbleToPlay = false;

                Current.Stop();

            }
           


        }

        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Island")
        {


            if (Current.isPlaying == true)
            {

                AbleToPlay = false;

                Current.Stop();

            }

        }
    }

}                                                                                                                                                                                                                                                                                                                                                                                               