using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MummiesSpwner : MonoBehaviour
{


    public GameObject MummiesPrefab;
    public int MummiesNumber;
    Vector2 SpawnPosition;
    float x;
    GameObject[] Blood;


    IEnumerator DestoyBlood()
    {

        yield return new WaitForSeconds(60);

        Blood = GameObject.FindGameObjectsWithTag("Blood");
        for (int i = 0; i < Blood.Length; i++)
        {


            Destroy(Blood[i]);

        }


    }

    void Start()
    {


        


    }


    void Update()
    {


        StartCoroutine(DestoyBlood());

        if (MummiesNumber > 0 )
        {
            {

                x = Random.Range(52.18f, 128.3f);
                SpawnPosition = new Vector2(x, 12.2f);

                Instantiate(MummiesPrefab, SpawnPosition, Quaternion.identity);

                MummiesNumber--;

            }

       }
    }




}
