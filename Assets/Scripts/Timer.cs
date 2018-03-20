using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    public int timer;
    public int totaltime = 120;
    
    public float lastUpdate = 0f;
    public Material material;
    [SerializeField] private float CutOffValue = 0;
    // Use this for initialization
    void Start () {
        material = GetComponent<Renderer>().material;
        timer = totaltime;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - lastUpdate >= 1f && timer>0)
        {
            timer--;
            
            lastUpdate = Time.time;
            if(CutOffValue<1f)
            CutOffValue += (1f / totaltime);
        }
        material.SetFloat("_Cutoff", CutOffValue);
        
    }
}
