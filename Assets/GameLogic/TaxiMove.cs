using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiMove : MonoBehaviour
{
    public bool isLeft = true;
    public float speed = 5f;
    public float DestoryXPosition;

    public GameObject Visuals;
    public Animator myAnimator;
    public ParticleSystem deadVFX;
    public GameObject DeadVFXOBJ;
    private BloodManager bloodManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject BloodMaster = GameObject.FindGameObjectWithTag("BloodMaster");
        if (BloodMaster != null)
        {
            bloodManager = BloodMaster.GetComponent<BloodManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object to the left
        if (isLeft)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            Visuals.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
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
        if (bloodManager.isTentacle1 == true)
        {
            //Instantiate(DeadVFXOBJ, gameObject.transform.position, Quaternion.identity);
            AudioManager.PlaySound(SoundType.Tentacles, 1);
            myAnimator.SetBool("isDead", true);
            // Destroy the game object when clicked
            //Destroy(gameObject);
            Invoke("killPeople", .75f);
        }
    }

    public void killPeople()
    {
        bloodManager.eachKillCount = speed * 5f;
        bloodManager.AddBloodTaxi();
        Destroy(gameObject);
    }


    public void killPeopleInstant()
    {
        //Instantiate(DeadVFXOBJ, gameObject.transform.position, Quaternion.identity);
        bloodManager.eachKillCount = speed * 5f;
        bloodManager.AddBloodTaxi();
        Destroy(gameObject);
    }


}
