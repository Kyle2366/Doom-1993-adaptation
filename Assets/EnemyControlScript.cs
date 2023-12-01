using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlScript : MonoBehaviour , IDamageable
{
    public Animator anim;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(float damage)
    {
        health =- damage;
        Debug.Log (health);
        if(health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

        }
    }
}
