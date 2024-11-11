using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMove : MonoBehaviour
{
    public float speed = 5f;
    public float DestoryXPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Check if the object's position is less than the defined X position to destroy it
        if (transform.position.x >= DestoryXPosition)
        {
            Destroy(gameObject);
        }
    }
}
