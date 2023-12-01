using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public EndOfGame EOG;
    public static HealthScript instance;

    public float maxHealth = 100, currentHealth;
    public float maxArmour = 100, currentArmour;

    public bool ignoreArmour;
    public bool hasArmour;
    public bool canHeal;
    public bool canArmour;
    // Start is called before the first frame update
    void Start()
    {
        ignoreArmour = false;
        hasArmour = true;
        currentArmour = 20;
        currentHealth = maxHealth;
    }
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentArmour > 0)
        {
            hasArmour = true;
        }
        if(currentArmour <= 0)   
        {
            hasArmour = false;
        }
        Debug.Log("Player Health is" + currentHealth);
        Debug.Log("Player Armour is" + currentArmour);
    }
    public void TakeDamage(float damage)
    {
        if (hasArmour == true && !ignoreArmour)
        {
            damage = damage-2;
            currentArmour -= damage;
        }
        if(hasArmour == false || ignoreArmour)
        {
            currentHealth -= damage;
        }
       
        if (currentHealth <= 0)
        {
            Death();
        }

    }
    public void Death()
    {
        Destroy(gameObject);
        Debug.Log("Player died");
        EOG.ResetGame();
            
    }

    public void SmallHealthBonus(int smallHealth)
    {
        
        if (currentHealth < 200)
        {
            currentHealth = currentHealth + smallHealth;
            Debug.Log("Small Health Bonus!");
        }
        if (currentHealth > 195)
        {
            currentHealth = 200;
        }

    }
    public void BigHealthBonus(int bigHealth)
    {
        if (currentHealth <= 175)
        {
            currentHealth = currentHealth + bigHealth;
            Debug.Log("Big Health Bonus!");
        }
        if (currentHealth > 175)
        {
            currentHealth = 200;
        }

    }
    public void SmallArmourBonus(int smallArmour)
    {
        if (currentArmour < 200)
        {
            currentArmour = currentArmour + smallArmour;
            Debug.Log("Small Armour Bonus!");
        }
        if (currentArmour > 195)
        {
            currentArmour = 200;
        }

    }
    public void BigArmourBonus(int bigArmour)
    {
        if (currentArmour <= 175)
        {
            currentArmour = currentArmour + bigArmour;
            Debug.Log("Big Armour Bonus!");
        }
        if (currentArmour > 175)
        {
            currentArmour = 200;
        }

    }

    public void ArmourOff()
    {
        ignoreArmour = true;
    }

    
}

