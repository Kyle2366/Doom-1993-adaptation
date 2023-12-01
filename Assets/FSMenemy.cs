using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum EnemyStates
{

    Idle,
    Move,
    Attack1,
    Chase,
    Damaged,
    Search,
    Die,
    Jump,
    TakeDamage,
    Block,
    Finished,


}
public class EnemyController : MonoBehaviour 
{
    [SerializeField] private Transform enemy;
    [Header("References")]
    private float yPos;
    public EnemyStates enemyState, previousState;
    GameObject player;
    GunScript GS;
    [Header("Combat")]
    public float maxHealth = 100;
    public float currentHealth;
    public float minDistance = 10f;
    public bool canAttack;
    public bool canBeHurt;
    public float enemyDamage = 5f;
    public float shotDis = 10000;
    public Transform attackPoint;
    public Transform attackPoint2;
    public Transform attackPoint3;
    public Rigidbody gunShot;
    float timeAtLastShot;
    [Header("Patrol")]
    public Vector3 destination;
    public Transform Player;
    public NavMeshAgent agent;
    public bool spotted;
    public float searchTime;
    [Header("animation")]
    public Animator anim;
    void Start()
    {
        canBeHurt = true;
        yPos = attackPoint.position.y;
        canAttack = true;
        spotted = false;
        enemyState = EnemyStates.Search;
        player = GameObject.Find("Player");
        currentHealth = maxHealth;
    }
    void Update()
    {

        Debug.DrawRay(attackPoint.position, attackPoint.forward * shotDis);
        Debug.DrawRay(attackPoint2.position, attackPoint.forward * shotDis);
        Debug.DrawRay(attackPoint3.position, attackPoint.forward * shotDis);
       
        DoLogic();
        print("ENEMY HEALTH = " + currentHealth);
        print(enemyState);
    }
    public void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            enemyState = EnemyStates.Die;
        }
    }
    void DoLogic()
    {
        if (enemyState == EnemyStates.Idle)
        {
            SearchForPlayer();
            DoChase();
            CheckHealth();
        }
        if (enemyState == EnemyStates.Chase)
        {
            DoChase();
            CheckForAttack();
            CheckHealth();
          
        }
        if (enemyState == EnemyStates.Damaged)
        {
           
            TakeDamage();
            CheckHealth();
        }
        if (enemyState == EnemyStates.Attack1)
        {
            CheckForAttack();
            CheckHealth();
            SearchForPlayer();
        }
        if (enemyState == EnemyStates.Die)
        {
            canBeHurt = false;
            Death();
        }
        if (enemyState == EnemyStates.Search)
        {
            SearchForPlayer();
            CheckHealth();
        } 
    }
    void CheckForAttack()
    {
        var currentTime = Time.time;
        var timeSinceLastShot = currentTime - timeAtLastShot;
        if (canAttack && spotted == true && timeSinceLastShot > 1f)
        {
            switch (previousState)
            {              
                default:
                    enemyState = EnemyStates.Attack1;
              
                    previousState = enemyState;
                    transform.LookAt(Player);
                    attackPoint.transform.LookAt(Player);
                    Rigidbody shot;
                    shot = Instantiate(gunShot, attackPoint.position,transform.rotation);
                    shot.isKinematic = false;
                    shot.velocity = attackPoint.transform.TransformDirection(Vector3.forward * 20);
                    timeAtLastShot = Time.time;
                    
                    break;
            }
        }
    }

    void DoChase()
    {
        if (spotted == true && canAttack == true)
        {
            transform.LookAt(Player);
            enemy.GetComponent<NavMeshAgent>().speed = 7;
            print("CHASING");
            destination = Player.position;
            agent.destination = destination;   
            enemyState = EnemyStates.Attack1;    
        }
        else
        {
            enemyState = EnemyStates.Search;
        }
    }
    public void TakeDamage()
    {
        if (canBeHurt)
        {
            currentHealth -= GunScript.instance.GetComponent<GunScript>().damage;
            Debug.Log(currentHealth);
        }
        if (currentHealth <= 0)
        {
            enemyState = EnemyStates.Die;
        }
    }
    void SearchForPlayer()
    {
            if (Physics.Raycast(attackPoint.position, transform.forward, out RaycastHit hitinfo, shotDis))
            {
                if (hitinfo.collider.gameObject.tag == "Player")
                {
                    spotted = true;
                    enemyState = EnemyStates.Chase;
                }
            }
            if (Physics.Raycast(attackPoint2.position, transform.forward, out RaycastHit hitinfo2, shotDis))
            {
                if (hitinfo2.collider.gameObject.tag == "Player")
                {
                    spotted = true;
                    enemyState = EnemyStates.Chase;
                }
            }
            if (Physics.Raycast(attackPoint3.position, transform.forward, out RaycastHit hitinfo3, shotDis))
            {
                if (hitinfo3.collider.gameObject.tag == "Player")
                {
                    spotted = true;
                    enemyState = EnemyStates.Chase;
                }
            }
    }
    public void Death()
    {
             
        Debug.Log("Enemy died");
        anim.Play("Enemy Die");
        Destroy(gameObject,1.5f);
    }
    void deleteObject()
    {
        gameObject.SetActive(false);
    }
    void CanAttack()
    {
        canAttack = true;
    }
}