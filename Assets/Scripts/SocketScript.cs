using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

public class SocketScript : MonoBehaviour {
    private NeuroskyConn myConn;
    public int Attention;
    public float lastUpdate = 0f;
    public int blink=0;
    // Use this for initialization
    private void Awake()
    {
       myConn= gameObject.AddComponent<NeuroskyConn>();
    }
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
            myConn.ReadSocket();
       
            
        
    
    }
}
