using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statcontroller : MonoBehaviour
{
   

    public Text ammoText;
    public Text armourText;
    public Text healthText;

    void Update()
    {
        ammoText.text = GunScript.instance.currentBullets.ToString();
        healthText.text = HealthScript.instance.currentHealth.ToString();
        armourText.text = HealthScript.instance.currentArmour.ToString();
        if (HealthScript.instance.GetComponent<HealthScript>().currentArmour < 0)
        {
            armourText.text = 0.ToString(); 
        }
    }
}
