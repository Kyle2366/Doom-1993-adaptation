using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public GameObject healthPickUp;
    public int smallHealthBonus = 5;
    public int smallArmourBonus = 2;
    public int bigArmourBonus = 10;
    public int bigHealthBonus = 25;
    public int clipBonus = 5;
    HealthScript HS;
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
        if (gameObject.tag == "SmallHealth")
        {
            if (col.gameObject.tag == "Player")
            {
                HealthScript.instance.GetComponent<HealthScript>().SmallHealthBonus(smallHealthBonus);
                Destroy(gameObject, .5f);

            }
        }
        if (gameObject.tag == "BigHealth")
        {
            if (col.gameObject.tag == "Player")
            {
                HealthScript.instance.GetComponent<HealthScript>().BigHealthBonus(bigHealthBonus);
                Destroy(gameObject, .5f);
            }
        }
        if (gameObject.tag == "SmallArmour")
        {
            if (col.gameObject.tag == "Player")
            {
                HealthScript.instance.GetComponent<HealthScript>().SmallArmourBonus(smallArmourBonus);
                Destroy(gameObject, .5f);
            }
        }
        if (gameObject.tag == "BigArmour")
        {
            if (col.gameObject.tag == "Player")
            {
                HealthScript.instance.GetComponent<HealthScript>().BigArmourBonus(bigArmourBonus);
                Destroy(gameObject, .5f);
            }
        }
        if (gameObject.tag == "Clip")
        {
            if (col.gameObject.tag == "Player")
            {
                GunScript.instance.currentBullets += clipBonus;
                Destroy(gameObject, .5f);
                Debug.Log("Clip PickUp!");
            }
       
        }
    }
}
