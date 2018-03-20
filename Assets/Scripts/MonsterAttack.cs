using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour {

    public const string IDLE = "Anim_Idle";
    public const string RUN = "Anim_Run";
    public const string ATTACK = "Anim_Attack";
    public const string DAMAGE = "Anim_Damage";
    public const string DEATH = "Anim_Death";

    Animation anim;
    
    public float speed ;
    public bool MetPlayer=false;
    public bool PlayerEntered = false;
    public int DealDamage = 10;
    public int takeDamage = 10;
    public int TotalHealth = 50;
    public bool isAlive = true;
    bool deathAnimationplayed = false;
    float AttackTimeUpdate = 0;
    float DeathTimeUpdate = 0;
    bool TakingDamage = false;
    float DamageTimeUpdate = 0;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAlive)
        {
            
            PlayerEntered = GameObject.Find("TriggerEnemy").GetComponent<ActivateEnemy>().PlayerEntered;
            if (transform.eulerAngles.y > 180 || transform.eulerAngles.y<0)
            {
                speed = -speed;
            }
            if (transform.eulerAngles.y < 180)
            {
                speed = speed;
            }
            if (PlayerEntered && !MetPlayer && !TakingDamage)
            {
                anim.CrossFade(RUN);

                transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            }
            if (PlayerEntered && !MetPlayer && TakingDamage)
            {
                anim.CrossFade(DAMAGE);
                if (Time.time - DamageTimeUpdate > 0.3f)
                {
                    TakingDamage = false;
                    DamageTimeUpdate = Time.time;
                }
            }
            if (PlayerEntered && MetPlayer)
            {
                if (Time.time - AttackTimeUpdate > 1f)
                {
                    AttackTimeUpdate = Time.time;

                    anim.CrossFade(ATTACK);
                    DamagePlayer(DealDamage);
                }

            }

            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        }
        if (!isAlive && !deathAnimationplayed)
        {
            anim.CrossFade(DEATH);

            deathAnimationplayed = true;
            DeathTimeUpdate = Time.time;
            
        }
        if (!isAlive && deathAnimationplayed)
        {
            if (Time.time - DeathTimeUpdate > 2.5f)
            {
                Destroy(gameObject);
            }
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            MetPlayer = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MetPlayer = false;
        }
    }
    void DamagePlayer(int damage)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Shooter>().TakeDamage(damage);
    }
    public void TakeDamage(int damage)
    {
        if (TotalHealth > 0 )
        {
            TakingDamage = true;
            TotalHealth = TotalHealth - damage;
            DamageTimeUpdate = Time.time;
            
           

        }
        if (TotalHealth == 0)
        {
            isAlive = false;
        }
    }
}
