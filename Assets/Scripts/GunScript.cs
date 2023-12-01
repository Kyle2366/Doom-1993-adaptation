using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
 
    public static GunScript instance;
    public static Action shootInput;
    public Transform gunPoint,gunPoint2;
  
    public Animator anim;
    public int shotDis = 100;
    public int damage = 5;
    public int currentBullets;
    public int maxBullets= 50;
    public float timeSincelastShot;

    public bool canShoot;
    public bool canDamage;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        canShoot = true;
        canDamage = true;
        currentBullets = maxBullets;
    }

    private void Update()
    {
        timeSincelastShot += Time.deltaTime;

        Debug.DrawRay(gunPoint.position, gunPoint.forward);
        Debug.DrawRay(gunPoint.position, -gunPoint.up * 1);
        CheckForPoisonFloor();
    }

    public void GunShot()
    {    
        if (currentBullets > 0 && canShoot && canDamage)
        {
            Debug.Log("Shot Gun!");
            if (Physics.Raycast(gunPoint.position, transform.forward, out RaycastHit hitInfo, shotDis))
            {
                if (hitInfo.collider.TryGetComponent<BarrelScript>(out BarrelScript BS))
                {
                    BS.explode = true;
                }
                if (hitInfo.collider.TryGetComponent<EnemyController>(out EnemyController EC))
                {
                    EC.TakeDamage();
                }
                anim.Play("Gunshot");
                /*
                Debug.Log(hitInfo.transform.name);
                IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                damageable?.TakeDamage(damage);
                */
            }
            if (Physics.Raycast(gunPoint2.position, transform.forward, out RaycastHit hitInfo2, shotDis))
            {
                if (hitInfo2.collider.TryGetComponent<BarrelScript>(out BarrelScript BS))
                {
                    BS.explode = true;
                }
                if (hitInfo2.collider.TryGetComponent<EnemyController>(out EnemyController EC))
                {
                    EC.TakeDamage();
                }
                anim.Play("Gunshot");
                /*
                Debug.Log(hitInfo.transform.name);
                IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                damageable?.TakeDamage(damage);
                */
            }

            currentBullets--;
        }
        


    }
    public void CheckForPoisonFloor()
    {
        Physics.Raycast(-gunPoint.up, -transform.up, out RaycastHit rayhit);
        {
            if (rayhit.transform.gameObject.tag == "PoisonFloor")
            {
                HealthScript.instance.GetComponent<HealthScript>().TakeDamage(50 * Time.deltaTime);
                Debug.Log("POISON!!");
            }
        }
    }
    private void OnGunShot()
    {

        throw new NotImplementedException();
    }

    public void CanShoot()
    {
        canShoot = true;

    }
    public void CantShoot()
    {
        canShoot = false;

    }  
    public void CantDamage()
    {
        canDamage = false;

    } 
    public void CanDamage()
    {
        canDamage = true;

    }
}
