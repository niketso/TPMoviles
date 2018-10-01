using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float minDist = 2.1f;
    [SerializeField] private Transform target;
    [SerializeField] private Transform myTransform;
    Animator AnimatorEnemy;
    float dist;
    bool colPiso = false;
    bool isDead;
    bool isAtacking;
    Collider coll;

    public bool IsAtacking
    {
        get { return isAtacking; }
        set { isAtacking = value; }
    }

    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }

    }

    private void Awake()
    {
        isDead = false;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        AnimatorEnemy = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        coll = GetComponent<Collider>();
    }

    void Atack()
    {
        AnimatorEnemy.SetTrigger("Atack");
        //AnimatorEnemy.SetInteger("WichAtack", Random.Range(1, 4));
    }

    void Move()
    {
        if (!isDead)
        {
            agent.SetDestination(target.position);
            AnimatorEnemy.SetFloat("Speed", 0.1f);
        }
        else { agent.SetDestination(transform.position); }
    }

    void Update()
    {        
        dist = (Vector3.Distance(transform.position, target.position));
        AnimatorEnemy.SetFloat("DistanceToPlayer", dist);
        Debug.Log(dist);
        if (dist >= minDist)
        {
            Move();
        }
        else AnimatorEnemy.SetFloat("Speed", 0);

        if (dist <= minDist)
        {
            Atack();
            isAtacking = true;
        }
        else isAtacking = false;

        if (AnimatorEnemy.GetBool("Dead"))
        {
            this.coll.enabled = false;
        }
    }
}