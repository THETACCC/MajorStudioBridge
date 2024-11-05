using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawnerLeft : MonoBehaviour
{
    public GameObject People;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPeople()
    {
        GameObject spawnedPerson = Instantiate(People, transform.position, Quaternion.identity);
        Debug.Log("Spawned People");
        PeopleMove peopleMove = spawnedPerson.GetComponent<PeopleMove>();
        if (peopleMove != null)
        {
            peopleMove.speed = Random.Range(.5f, 5f);
            peopleMove.isLeft= true;
            peopleMove.DestoryXPosition = 12f;
        }
    }
}
