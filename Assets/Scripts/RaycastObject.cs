using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastObject : MonoBehaviour {

	void OnTriggerEnter()
    {
        if (RaycastTest.beingCarried)
        {
            RaycastTest.touched = true;
        }
    }
}
