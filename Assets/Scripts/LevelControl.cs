using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour {

    [SerializeField] private Image image;
    [SerializeField] private Animator anim;

    AudioSource audioSource;
    [SerializeField] AudioClip audio;
    
    [SerializeField] Text loadText;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        loadText.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            loadText.enabled = true;
        }
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Fading());
            audioSource.PlayOneShot(audio, 1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            loadText.enabled = false;
        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => image.color.a == 1);
        SceneManager.LoadScene("SpaceStationHall");
    }
}
