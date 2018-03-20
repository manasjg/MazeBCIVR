using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionManager : MonoBehaviour
{
    public int Attention;
    public int Meditation;
    public int Blink;
    private NeuroskyConn myConn;
    // Use this for initialization

    private void Awake()
    {
        myConn = gameObject.AddComponent<NeuroskyConn>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        myConn.ReadSocket();
        Attention = myConn.attention;
        Meditation = myConn.meditation;
    }
}
