using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {

    private void Start()
    {
        StartCoroutine("FlashingLight");
    }

    IEnumerator FlashingLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GetComponent<Light>().enabled =! GetComponent<Light>().enabled;
        }
    }

}
