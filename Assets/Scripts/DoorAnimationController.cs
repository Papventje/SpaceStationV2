using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorAnimationController : MonoBehaviour {

    [SerializeField] Animator animator;
    bool doorOpen;
    bool ePressed;

    //[SerializeField] private Text openText;

    private void Start()
    {
        doorOpen = false;
        ePressed = false;

        //openText.enabled = false;

        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //openText.enabled = true;
        }
        if(other.gameObject.tag == "Player" && ePressed)
        {
                doorOpen = true;
                Doors("Open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (doorOpen)
        {
            doorOpen = false;
            Doors("Close");
        }
        if(other.gameObject.tag == "Player")
        {
            //openText.enabled = false;
        }
    }

    void Doors(string direction)
    {
        animator.SetTrigger(direction);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ePressed = true;
        }
        else
        {
            ePressed = false;
        }
    }
}
