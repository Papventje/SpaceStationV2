using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour{

    Camera cam;
    [SerializeField] Transform playerCam;
    [SerializeField] Keypad keypad;

    public bool pickup = false;
    public static bool beingCarried = false;
    public static bool touched = false;

    [SerializeField] float throwForce;

    void Start()
    {
        cam = GetComponent<Camera>();
        keypad = GetComponent<Keypad>();
    }

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 5, Color.yellow);
        if (Physics.Raycast(ray, out hit, 3))
        {
            if (hit.collider.gameObject.tag == "PickupObject")
                pickup = true;
            else
                pickup = false;
        }
        if(pickup && Input.GetKeyDown(KeyCode.E))
        {
            hit.collider.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            hit.collider.transform.parent = playerCam;
            beingCarried = true;
        }
        if (beingCarried)
        {
            if (touched)
            {
                hit.collider.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                hit.collider.transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                hit.collider.transform.parent = null;
                beingCarried = false;
                hit.collider.transform.gameObject.GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                hit.collider.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                hit.collider.transform.parent = null;
                beingCarried = false;
            }
        }
    }
}
