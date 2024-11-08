using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpwnRight : MonoBehaviour
{
    public GameObject Train;
    // Start is called before the first frame update
    public void SpawnPeople()
    {
        GameObject spawnedPerson = Instantiate(Train, transform.position, Quaternion.identity);
        Debug.Log("Spawned People");
        TrainMove peopleMove = spawnedPerson.GetComponent<TrainMove>();
        if (peopleMove != null)
        {
            peopleMove.speed = Random.Range(10f, 15f);
            peopleMove.isLeft = false;
            peopleMove.DestoryXPosition = -25f;
        }
    }
}