using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleDeadEvent : MonoBehaviour
{

    public PeopleMove move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerDead()
    {
        if (move != null)
        {
            move.killPeople();
        }
    }
}
