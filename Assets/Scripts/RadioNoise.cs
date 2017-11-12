using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioNoise : MonoBehaviour {

    AudioSource audioSource;
    [SerializeField] AudioClip clip;

    private void Start()
    {
        GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(clip, transform.position, 0.2f);
    }


}
