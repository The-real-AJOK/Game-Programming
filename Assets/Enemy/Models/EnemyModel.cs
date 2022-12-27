using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.AI;

public class EnemyModel : MonoBehaviour
{
    private Rigidbody rigidbody;
    float currentY;
    public float FallingThreshold = -2.0f;
    // [HideInInspector]
    // public bool Falling = false;
    // public bool Jumping = false;

    // private Subject<bool> SphereSubjectFalling;
    // private Subject<bool> SphereSubjectJumping;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Start()
    {
        var rigidbody = this.gameObject.AddComponent<Rigidbody>();
    }

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform; //spawn not inject
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer); //Event 1
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer); //Event 2

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    // public IObservable<bool> SphereFalling
    // {
    //     get
    //     {
    //         return this.SphereSubjectFalling.AsObservable();
    //     }
    // }

    // public IObservable<bool> SphereJumping
    // {
    //     get
    //     {
    //         return this.SphereSubjectJumping.AsObservable();
    //     }
    // }

    // void Start()
    // {
    //     this.rigidbody = this.gameObject.GetComponent<Rigidbody>();
    //     currentY = this.rigidbody.position.y;
    // }

    // public void Update()
    // {
    //     // OutOfBounds();
    //     // SphereJumps();
    // }

    public void EnableGravity()
    {
        this.rigidbody.useGravity = true;
    }

    // SphereComponent()
    // {
    //     this.SphereSubjectFalling = new Subject<bool>();
    //     this.SphereSubjectJumping = new Subject<bool>();
    //     // this.SphereSubject = new Subject<Unit>();
    // }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     this.StartCoroutine("HideAfterSeconds", ObstacleComponent.TIME_BEFORE_HIDING_AFTER_COLLISION_IN_SECONDS);
    //     this.ObstacleCollisionSubject.OnNext(Unit.Default);
    // }

    // public void OutOfBounds()
    // {
    //     if (this.rigidbody.position.y < FallingThreshold)
    //     {
    //         Debug.Log("Falling...");
    //         Falling = true;
    //         this.SphereSubjectFalling.OnNext(Falling);
    //         this.SphereSubjectFalling.OnCompleted();
    //     }
    //     else
    //     {
    //         Falling = false;
    //     }

    //     // return Falling;
    // }

    // public void SphereJumps()
    // {
    //     float lastY = currentY;
    //     currentY = this.rigidbody.position.y;
    //     Debug.Log(currentY - lastY);

    //     if (currentY > lastY)
    //     {
    //         Debug.Log("Jumping...");
    //         Jumping = true;
    //         this.SphereSubjectJumping.OnNext(Jumping);
    //     }
    //     else
    //     {
    //         Debug.Log("Not jumping");
    //         Jumping = false;
    //     }

    //     // return Falling;
    // }
}
