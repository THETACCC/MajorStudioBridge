using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleMove : MonoBehaviour
{
    public bool isLeft = true;
    public float speed = 5f;
    public float DestoryXPosition;

    private BloodManager bloodManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject BloodMaster = GameObject.FindGameObjectWithTag("BloodMaster");
        if (BloodMaster != null )
        {
            bloodManager = BloodMaster.GetComponent<BloodManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object to the left
        if(isLeft)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            // Check if the object's position is less than the defined X position to destroy it
            if (transform.position.x >= DestoryXPosition)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            // Check if the object's position is less than the defined X position to destroy it
            if (transform.position.x <= DestoryXPosition)
            {
                Destroy(gameObject);
            }
        }

    }

    private void OnMouseDown()
    {
        bloodManager.eachKillCount = speed * 1f;
        bloodManager.AddBlood();
        // Destroy the game object when clicked
        Destroy(gameObject);
    }
}
