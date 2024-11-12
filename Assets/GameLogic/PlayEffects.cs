using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffects : MonoBehaviour
{
    public ParticleSystem myParticles;
    // Start is called before the first frame update
    void Start()
    {
        myParticles.Play();
        Invoke("KillSelf", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void KillSelf()
    {
        Destroy(this.gameObject);
    }
}