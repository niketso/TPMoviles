using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    NavMeshAgent agent;
    //[SerializeField] private float speed = 1f;
    [SerializeField] private float minDist = 2.1f;
    [SerializeField] private Transform target;
    [SerializeField] private Transform myTransform;
    Animator AnimatorEnemy;
    float dist;
    //bool colPiso = false;
    bool isDead;
    bool isAtacking;
    Collider coll;
    [SerializeField] private bool runner = false;
    LayerMask layerEnemy = 10;
    public bool isStopped = false;

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
    
    void Update()
    {        
        dist = (Vector3.Distance(transform.position, target.position));
        AnimatorEnemy.SetFloat("DistanceToPlayer", dist);
        //Debug.Log(dist);
        

        if (!isDead && dist > minDist)
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
    
    void Atack()
    {
        if (!isDead)
        {
            AnimatorEnemy.SetTrigger("Atack");
            AnimatorEnemy.SetBool("Atacking", true);
            agent.SetDestination(transform.position);
            //AnimatorEnemy.SetInteger("WichAtack", Random.Range(1, 4));
        }
    }

    void Move()
    {
        if (!isDead && !isStopped)
        {            
            if (runner == true)
            {
                AnimatorEnemy.SetBool("Runner", true);
            }
            AnimatorEnemy.SetBool("Atacking", false);
            agent.SetDestination(target.position);
            AnimatorEnemy.SetFloat("Speed", 0.1f);
        }
        else
        {
            agent.SetDestination(transform.position);
            AnimatorEnemy.SetBool("Atacking", false);
        }
    }

    /*void CheckSphere()
    {
        if (Physics.CheckSphere(new Vector3(this.transform.position.x + 0.15f, this.transform.position.y+1.05f, this.transform.position.z), 0.35f, layerEnemy))
        {
            Debug.Log("Choque contra otro enemy");
            AnimatorEnemy.SetFloat("Speed", 0);
            
            //agent.SetDestination(this.transform.position); 
        }        
    }*/
}