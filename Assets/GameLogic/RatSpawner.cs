using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    public GameObject ratPrefab; // Reference to the rat prefab
    public float spawnDuration = 2f; // Total time to spawn 100 rats
    public int ratCount = 100; // Total number of rats to spawn
    public float yMin = -8f; // Minimum Y position
    public float yMax = 10f; // Maximum Y position

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
                personScript.killPeopleInstant(); // Call the autoKill function on the randomly selected person
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
            Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(yMin, yMax), 0);

            // Instantiate the rat prefab at the generated position
            
            GameObject spawnedRat = Instantiate(ratPrefab, spawnPosition, Quaternion.identity);
            RatMove ratMove = spawnedRat.GetComponent<RatMove>();
            if (ratMove != null)
            {
                ratMove.speed = Random.Range(10f, 15f);
                ratMove.DestoryXPosition = 16f;
            }
            // Wait for the next spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
