using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour {

    [SerializeField] private Image image;
    [SerializeField] private Animator anim;
    
    [SerializeField] Text loadText;

    private void Start()
    {
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
