using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementVR : MonoBehaviour {
    public float speed = 0.00000001f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Shooter>().isAlive)
        {
            if (Input.GetKey(KeyCode.W) || transform.Find("[CameraRig]").gameObject.transform.Find("Controller (left)").
                GetComponent<SteamVR_TrackedController>().triggerPressed)
            {
                transform.Translate(Camera.main.transform.forward * speed);
            }
            if (Input.GetKey(KeyCode.S) || transform.Find("[CameraRig]").gameObject.transform.Find("Controller (right)").
               GetComponent<SteamVR_TrackedController>().triggerPressed)
            {
                transform.Translate(-Camera.main.transform.forward * speed);
            }
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
