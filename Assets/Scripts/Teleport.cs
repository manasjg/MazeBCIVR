using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    //public Transform portal_anim;
    public GameObject portal_Or1;
    public GameObject portal_Or2;
    public GameObject portal_B1;
    public GameObject portal_B2;
    public GameObject portal_G1;
    public GameObject portal_G2;
    public GameObject portal_R1;
    public GameObject portal_R2;
    public GameObject portal_Y1;
    public GameObject portal_Y2;
    //public Transform tpLoc;

    // Use this for initialization
    void Start ()
    {
        portal_Or1.gameObject.SetActive(false);
        portal_Or2.gameObject.SetActive(false);
        portal_B1.gameObject.SetActive(false);
        portal_B2.gameObject.SetActive(false);
        portal_G1.gameObject.SetActive(false);
        portal_G2.gameObject.SetActive(false);
        portal_R1.gameObject.SetActive(false);
        portal_R2.gameObject.SetActive(false);
        portal_Y1.gameObject.SetActive(false);
        portal_Y2.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Yellow_1")
        {
            portal_Y1.gameObject.SetActive(true);
            if (other.gameObject.transform.Find("Slider").GetComponent<Slider>().value == other.gameObject.transform.Find("Slider").GetComponent<Slider>().maxValue)
            {
                transform.position = new Vector3(-3.5f, 0.49f, 3.89f);
            }

            other.gameObject.transform.Find("Slider").GetComponent<Slider>().value = 0;
        }

        if (other.gameObject.tag == "Yellow_2")
        {
            portal_Y2.gameObject.SetActive(true);
            if (other.gameObject.transform.Find("Slider").GetComponent<Slider>().value == other.gameObject.transform.Find("Slider").GetComponent<Slider>().maxValue)
            {
                transform.position = new Vector3(4.21f, 0.49f, 3.91f);
            }

            other.gameObject.transform.Find("Slider").GetComponent<Slider>().value = 0;
        }

        if (other.gameObject.tag == "Orange_1")
        {
            portal_Or1.gameObject.SetActive(true);
            if (other.gameObject.transform.Find("Slider").GetComponent<Slider>().value == other.gameObject.transform.Find("Slider").GetComponent<Slider>().maxValue)
                transform.position = new Vector3(10.48f, 0.49f, 1.45f);

            other.gameObject.transform.Find("Slider").GetComponent<Slider>().value = 0;
        }

        if (other.gameObject.tag == "Orange_2")
        {
            portal_Or2.gameObject.SetActive(true);
            if (other.gameObject.transform.Find("Slider").GetComponent<Slider>().value == other.gameObject.transform.Find("Slider").GetComponent<Slider>().maxValue)
            {
                transform.position = new Vector3(0.78f, 0.49f, 1.87f);
                //StopPortal();
            }

            other.gameObject.transform.Find("Slider").GetComponent<Slider>().value = 0;
        }

        if (other.gameObject.tag == "Red_1")
        {
            portal_R1.gameObject.SetActive(true);
            if (other.gameObject.transform.Find("Slider").GetComponent<Slider>().value == other.gameObject.transform.Find("Slider").GetComponent<Slider>().maxValue)
                transform.position = new Vector3(8.44f, 0.49f, -7.24f);

            other.gameObject.transform.Find("Slider").GetComponent<Slider>().value = 0;
        }

        if (other.gameObject.tag == "Red_2")
        {
            portal_R2.gameObject.SetActive(true);
            if (other.gameObject.transform.Find("Slider").GetComponent<Slider>().value == other.gameObject.transform.Find("Slider").GetComponent<Slider>().maxValue)
                transform.position = new Vector3(-3.45f, 0.49f, -3f);

            other.gameObject.transform.Find("Slider").GetComponent<Slider>().value = 0;
        }

        if (other.gameObject.tag == "Blue_1")
        {
            portal_B1.gameObject.SetActive(true);
            if (other.gameObject.transform.Find("Slider").GetComponent<Slider>().value == other.gameObject.transform.Find("Slider").GetComponent<Slider>().maxValue)
                transform.position = new Vector3(-5.95f, 0.49f, -3.19f);

            other.gameObject.transform.Find("Slider").GetComponent<Slider>().value = 0;
        }

        if (other.gameObject.tag == "Blue_2")
        {
            portal_B2.gameObject.SetActive(true);
            if (other.gameObject.transform.Find("Slider").GetComponent<Slider>().value == other.gameObject.transform.Find("Slider").GetComponent<Slider>().maxValue)
                transform.position = new Vector3(-6.03f, 0.49f, -5.4f);

            other.gameObject.transform.Find("Slider").GetComponent<Slider>().value = 0;
        }

        if (other.gameObject.tag == "Green_1")
        {
            portal_G1.gameObject.SetActive(true);
            if (other.gameObject.transform.Find("Slider").GetComponent<Slider>().value == other.gameObject.transform.Find("Slider").GetComponent<Slider>().maxValue)
                transform.position = new Vector3(-3.65f, 0.49f, -7.48f);

            other.gameObject.transform.Find("Slider").GetComponent<Slider>().value = 0;
        }

        if (other.gameObject.tag == "Green_2")
        {
            portal_G2.gameObject.SetActive(true);
            if (other.gameObject.transform.Find("Slider").GetComponent<Slider>().value == other.gameObject.transform.Find("Slider").GetComponent<Slider>().maxValue)
                transform.position = new Vector3(1.65f, 0.49f, -7.25f);

            other.gameObject.transform.Find("Slider").GetComponent<Slider>().value = 0;
        }
	}

    void OnTriggerExit (Collider other)
    {
        portal_Or1.gameObject.SetActive(false);
        portal_Or2.gameObject.SetActive(false);
        portal_B1.gameObject.SetActive(false);
        portal_B2.gameObject.SetActive(false);
        portal_G1.gameObject.SetActive(false);
        portal_G2.gameObject.SetActive(false);
        portal_R1.gameObject.SetActive(false);
        portal_R2.gameObject.SetActive(false);
        portal_Y1.gameObject.SetActive(false);
        portal_Y2.gameObject.SetActive(false);
    }
}
