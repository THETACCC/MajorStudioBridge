using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiSpawnLeft : MonoBehaviour
{

    public GameObject Taxi;
    // Start is called before the first frame update
    public void SpawnPeople()
    {
        GameObject spawnedPerson = Instantiate(Taxi, transform.position, Quaternion.identity);
        Debug.Log("Spawned People");
        TaxiMove peopleMove = spawnedPerson.GetComponent<TaxiMove>();
        if (peopleMove != null)
        {
            peopleMove.speed = Random.Range(5f, 10f);
            peopleMove.isLeft = true;
            peopleMove.DestoryXPosition = 4f;
        }
    }
}
