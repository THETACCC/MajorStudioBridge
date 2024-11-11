using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockSpawner : MonoBehaviour
{
    public GameObject cockPrefab; // Reference to the rat prefab
    public float spawnDuration = 2f; // Total time to spawn 100 rats
    public int ratCount = 50; // Total number of rats to spawn
    public float xMin = -14f; // Minimum Y position
    public float xMax = 25f; // Maximum Y position

    // Start is called before the first frame update
    void Start()
    {
        // Optional: Start spawning automatically
        //Invoke("StartSpawning", 5f);
    }

    // Call this method to start spawning rats
    public void StartSpawning()
    {
        GameObject[] peopleObjects = GameObject.FindGameObjectsWithTag("People");
        foreach (GameObject peopleObject in peopleObjects)
        {
            var personScript = peopleObject.GetComponent<PeopleMove>(); // Replace PeopleScript with the actual script name that has autoKill
            if (personScript != null)
            {
                personScript.killPeople(); // Call the autoKill function on the randomly selected person
            }
        }
        GameObject[] TaxiObjects = GameObject.FindGameObjectsWithTag("Car");
        foreach (GameObject TaxiObject in TaxiObjects)
        {
            var Taxiscript = TaxiObject.GetComponent<TaxiMove>(); // Replace PeopleScript with the actual script name that has autoKill
            if (Taxiscript != null)
            {
                Taxiscript.killPeople(); // Call the autoKill function on the randomly selected person
            }
        }

        GameObject[] TrainOjects = GameObject.FindGameObjectsWithTag("Train");
        foreach (GameObject TrainOject in TrainOjects)
        {
            var TrainScript = TrainOject.GetComponent<TrainMove>(); // Replace PeopleScript with the actual script name that has autoKill
            if (TrainScript != null)
            {
                TrainScript.killPeople(); // Call the autoKill function on the randomly selected person
            }
        }

        StartCoroutine(SpawnRats());
    }

    private IEnumerator SpawnRats()
    {
        float spawnInterval = spawnDuration / ratCount; // Calculate the time between each spawn

        for (int i = 0; i < ratCount; i++)
        {
            // Generate a random position within the specified Y range
            Vector3 spawnPosition = new Vector3(Random.Range(xMin, xMax), transform.position.y, 0);

            // Instantiate the rat prefab at the generated position

            GameObject spawnedRat = Instantiate(cockPrefab, spawnPosition, Quaternion.identity);
            CockMove ratMove = spawnedRat.GetComponent<CockMove>();
            if (ratMove != null)
            {
                ratMove.speed = Random.Range(10f, 15f);
                ratMove.DestoryYPosition = 13f;
            }
            // Wait for the next spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
