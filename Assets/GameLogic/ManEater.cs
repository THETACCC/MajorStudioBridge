using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManEater : MonoBehaviour
{

    public float timeBetweenEat = 5f;
    private float time = 0f;

    public Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > timeBetweenEat)
        {
            time = 0;
            Eat();
        }
    }

    public void Eat()
    {

        // Optional: Play eat animation or other effects
        myAnimator.SetTrigger("Eat");
        // Get the Box Collider 2D attached to this GameObject
        Invoke("StartEating", .5f);

    }

    public void StartEating()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        if (boxCollider != null)
        {
            // Use the box collider's bounds to define the area of detection
            Vector2 center = boxCollider.bounds.center;
            Vector2 size = boxCollider.bounds.size;

            // Detect all colliders within the box area
            Collider2D[] colliders = Physics2D.OverlapBoxAll(center, size, 0f);

            // Loop through each collider found
            foreach (Collider2D collider in colliders)
            {
                // Check if the collider has the tag "People"
                if (collider.CompareTag("People"))
                {
                    // Destroy the game object with the tag "People"
                    GameObject people = collider.gameObject;
                    if (people != null)
                    {
                        PeopleMove peopleMove = people.GetComponent<PeopleMove>();
                        peopleMove.killPeopleInstant();
                    }

                }
            }


        }
    }

}
