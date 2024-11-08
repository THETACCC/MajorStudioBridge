using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEyeController : MonoBehaviour
{

    public GameObject TheEyeVisual;
    public Animator myAnimator;
    public GameObject myUpdateTab;
    public GameObject myExitTab;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator.SetBool("isHover", false);
    }

    // Called when the mouse enters the collider attached to this GameObject
    void OnMouseEnter()
    {
        myAnimator.SetBool("isHover", true);
    }

    // Called when the mouse exits the collider attached to this GameObject
    void OnMouseExit()
    {
        myAnimator.SetBool("isHover", false);
    }

    void OnMouseDown()
    {
        if (myUpdateTab != null)
        {
            myUpdateTab.SetActive(true);
            myExitTab.SetActive(true);// Activates the GameObject on click
        }
    }

}
