using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour {

    [SerializeField] GameObject keypad;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    bool keypadOpen = false;

    private void Start()
    {
        keypad.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !keypadOpen)
        {
            keypad.SetActive(true);
            controller.enabled = false;
            keypadOpen = true;
        }
        if(other.gameObject.tag == "Player" && keypadOpen)
        {
            keypad.SetActive(false);
        }
    }
}
