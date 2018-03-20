using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalSliderInc : MonoBehaviour {
    GameObject Go;
    public int attentionlevel= 0;
    public bool PlayerEntered = false;
    [SerializeField] int SliderVal = 0;
    ParticleSystem ps;
    // Use this for initialization
    void Start () {
       
        ps = transform.Find("Portal/Circle (1)").gameObject.GetComponent<ParticleSystem>();
        Debug.Log(ps);
        Go = GameObject.FindGameObjectWithTag("Connector");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerEntered)
        {
           
            attentionlevel = Go.GetComponent<NeuroskyConn>().attention;

            transform.Find("Text").gameObject.GetComponent<Text>().text = ("Attention: " + attentionlevel + "\n");
            //"Meditation: " + myConn.meditation.ToString() + "\n" +
            //"Blink:" + myConn.blink.ToString());
            if (attentionlevel > 50)
            {
                SliderVal++;

                Debug.Log("Attention is greater than 50");

            }
            if (SliderVal > 100)
            {
                var main = ps.main;
                main.simulationSpeed = 2.25f;
            }
            if (SliderVal > 200)
            {
                var main = ps.main;
                main.simulationSpeed = 2.5f;
            }
            if (SliderVal > 300)
            {
                var main = ps.main;
                main.simulationSpeed = 2.75f;
            }
            if (SliderVal > 400)
            {
                var main = ps.main;
                main.simulationSpeed = 3.25f;
            }
            if (SliderVal == 500)
            {
                var main = ps.main;
                main.simulationSpeed = 4f;
            }
            transform.Find("Slider").gameObject.GetComponent<Slider>().value = SliderVal;
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            PlayerEntered = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            PlayerEntered = false;
    }
}
