using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleMove : MonoBehaviour
{
    public bool isLeft = true;
    public float speed = 5f;
    public float DestoryXPosition;

    public GameObject Visuals;
    public Animator myAnimator;

    public GameObject VisualsRegular;
    public Animator myRegularAnimator;

    public GameObject VisualsSlow;
    public Animator mySlowAnimator;

    private BloodManager bloodManager;

    public ParticleSystem deadVFX;
    public GameObject DeadVFXOBJ;
    // Start is called before the first frame update
    void Start()
    {
        GameObject BloodMaster = GameObject.FindGameObjectWithTag("BloodMaster");
        if (BloodMaster != null )
        {
            bloodManager = BloodMaster.GetComponent<BloodManager>();
        }

        if(speed > 1f && speed <= 3f)
        {
            Visuals.SetActive(false);
            VisualsRegular.SetActive(true);
            VisualsSlow.SetActive(false);
        }
        else if (speed > 3f)
        {
            Visuals.SetActive(true);
            VisualsRegular.SetActive(false);
            VisualsSlow.SetActive(false);
        }
        else
        {
            Visuals.SetActive(false);
            VisualsRegular.SetActive(false);
            VisualsSlow.SetActive(true);
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
            Visuals.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            VisualsRegular.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            VisualsSlow.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            // Check if the object's position is less than the defined X position to destroy it
            if (transform.position.x <= DestoryXPosition)
            {
                Destroy(gameObject);
            }
        }


        if(Input.GetKeyDown(KeyCode.O))
        {
            killPeopleInstant();
        }

    }

    public void autoKill()
    {

            AudioManager.PlaySound(SoundType.Tentacles, 1);



        deadVFX.Play();
        myAnimator.SetBool("isDead", true);
        myRegularAnimator.SetBool("isDead", true);
        mySlowAnimator.SetBool("isDead", true);
        // Destroy the game object when clicked
        //Destroy(gameObject);
        Invoke("killPeople", 0.3f);
    }

    private void OnMouseDown()
    {

            AudioManager.PlaySound(SoundType.Tentacles, 1);

        deadVFX.Play();
        myAnimator.SetBool("isDead", true);
        myRegularAnimator.SetBool("isDead", true);
        mySlowAnimator.SetBool("isDead", true);
        // Destroy the game object when clicked
        //Destroy(gameObject);
        Invoke("killPeople", 0.3f);
    }

    public void killPeople()
    {


        bloodManager.eachKillCount = speed * 1f;
        bloodManager.AddBlood();
        Destroy(gameObject);
    }


    public void killPeopleInstant()
    {
        Instantiate(DeadVFXOBJ, gameObject.transform.position, Quaternion.identity);

        bloodManager.eachKillCount = speed * 1f;
        bloodManager.AddBlood();
        Destroy(gameObject);
    }
}
