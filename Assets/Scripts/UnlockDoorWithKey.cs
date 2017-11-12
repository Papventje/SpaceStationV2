using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoorWithKey : MonoBehaviour {

    [SerializeField] GameObject doorCollider;
    [SerializeField] GameObject keyInDoor;

    private void Start()
    {
        doorCollider.GetComponent<BoxCollider>().enabled = false;
        keyInDoor.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Key")
        {
            doorCollider.GetComponent<BoxCollider>().enabled = true;
            Destroy(other.gameObject);
            keyInDoor.SetActive(true);
            //Start Animation - 1st Turn key - 2nd Loop turned around key
        }
    }
}
