using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSocketScript : MonoBehaviour {

    private NeuroskyConn myConn;

    public int attenion = 0;

    // Use this for initialization
    private void Awake()
    {
        myConn = gameObject.AddComponent<NeuroskyConn>();

    }
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        myConn.ReadSocket();
        attenion = myConn.attention;
        if(attenion>50)
        GetComponent<Slider>().value++;

       


    }
}
