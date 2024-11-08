using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiSpawnerMaster : MonoBehaviour
{
    //SpawnerRef
    public GameObject peopleSpawnLeft;
    public GameObject peopleSpawnRight;
    private TaxiSpawnLeft peopleSpawnL;
    private TaxiSpawnRight peopleSpawnR;

    public float timeBetweenSpawn = 0.35f;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        peopleSpawnL = peopleSpawnLeft.GetComponent<TaxiSpawnLeft>();
        peopleSpawnR = peopleSpawnRight.GetComponent<TaxiSpawnRight>();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timeBetweenSpawn)
        {
            Debug.Log("Spawn");
            int Spawning = Random.Range(0, 2);
            Debug.Log(Spawning);
            if (Spawning == 0)
            {
                peopleSpawnL.SpawnPeople();


            }
            else
            {
                peopleSpawnR.SpawnPeople();
            }
            time = 0f;
        }
    }
}
