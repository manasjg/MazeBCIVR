using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour {
    public bool isAlive = true;
    public int ShootDamage = 10;
    public int Health = 50;
    public Camera fpsCamera;
    public int LatestBlink = 0;
    GameObject Go;

    private void Awake()
    {
       

    }
    // Use this for initialization
    void Start () {
        fpsCamera = Camera.main;
        Go = GameObject.FindGameObjectWithTag("Connector");
    }
	
	// Update is called once per frame
	void Update () {
        if (!isAlive)
        {
            Debug.Log("Player Dead");
        }
        if (GameObject.Find("TriggerEnemy").GetComponent<ActivateEnemy>().PlayerEntered)
        {
           
            if (LatestBlink !=Go.GetComponent<NeuroskyConn>().blink || Input.GetButtonDown("Fire1"))
            {
                Shoot(ShootDamage);
                LatestBlink = Go.GetComponent<NeuroskyConn>().blink;
            }
        }
        
	}

    public void TakeDamage(int damage)
    {
        if (Health > 0)
        {
            Health = Health - damage;
        }
        if (Health == 0)
        {
            isAlive = false;
        }
    }
    public void Shoot(int damage)
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position,fpsCamera.transform.forward,out hit))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.gameObject.tag == "Enemy")
            {
                Debug.Log("Hitmonster");
                hit.transform.gameObject.GetComponent<MonsterAttack>().TakeDamage(ShootDamage);
            }
        }
    }
}
