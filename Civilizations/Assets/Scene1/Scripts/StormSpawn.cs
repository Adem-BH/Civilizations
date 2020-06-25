using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormSpawn : MonoBehaviour
{

    public static StormSpawn instance;

    public GameObject StormUI;

    public float X;
    public float MinX;
    public float MaxX;

    public float Y;
    public float MinY;
    public float MaxY;

    public Vector2 SpawnPosition;

    public int Respawns;

    public GameObject StormPrefab;

    public bool UI = false;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {

        


        
    }

    
    void Update()
    {

        if (UI)
        {
            StormUI.SetActive(true);
            StormSpawn.instance.UI = false;
        }

        if (Respawns < 1) 
        {
           

            X = Random.Range(MinX, MaxX);
            Y = Random.Range(MinY, MaxY);

            SpawnPosition = new Vector2(X, Y);

            Instantiate(StormPrefab, SpawnPosition, Quaternion.identity);
            Respawns++;
            StormSpawn.instance.UI = false;

        }

    }

    public void Cancel()
    {

        StormUI.SetActive(false);

    }
}
