using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour
{
    public GameObject shot;
    public float damage = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Map")
        {
            Destroy(shot);
        }
        if (col.gameObject.tag == "1")
        {
            Destroy(shot);
        }
        if (col.gameObject.tag == "2")
        {
            Destroy(shot);
        }
        if (col.gameObject.tag == "3")
        {
            Destroy(shot);
        }
        if (col.gameObject.tag == "Player")
        {
            
            HealthScript.instance.GetComponent<HealthScript>().TakeDamage(damage);
        }
    }
}
