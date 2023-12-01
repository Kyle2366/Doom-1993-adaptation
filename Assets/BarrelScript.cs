using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public Transform player;
    public BoxCollider bC;
    public SphereCollider sC;
    public Animator anim;
    public bool explode;
    // Start is called before the first frame update
    void Start()
    {
        explode = false;
        sC.GetComponent<SphereCollider>();
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        Explosion();
    }

    public void Explosion()
    {
        if (explode)
        {
            sC.GetComponent<SphereCollider>().enabled = true;
            anim.Play("BarrelExplosion");
            Debug.Log("Explosion!");
            Destroy(gameObject, 0.5f);
        }
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
         col.gameObject.GetComponent<EnemyController>().Death();           
        }
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent <HealthScript>().Death();
        }
    }
}
