using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SphereColl : MonoBehaviour {

    Animator AnimatorEnemy;
    EnemyMovement enemy;

    private void Start()
    {
        AnimatorEnemy = GetComponentInParent<Animator>();
        enemy = GetComponentInParent<EnemyMovement>();
    }

   /* private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CHOQUE CONTRA ALGO");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("CHOQUE CONTRA ENEMIGO");
            AnimatorEnemy.SetFloat("Speed", 0);
            enemy.isStopped = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("CHOQUE CONTRA ALGO");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("CHOQUE CONTRA ENEMIGO");
            AnimatorEnemy.SetFloat("Speed", 0);
            enemy.isStopped = true;
        }
    }*/
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CHOQUE CONTRA ALGO");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("CHOQUE CONTRA ENEMIGO");
            AnimatorEnemy.SetFloat("Speed", 0);
            enemy.isStopped = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
       

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("SALI DEL ENEMY");
            AnimatorEnemy.SetFloat("Speed", 0.1f);
            enemy.isStopped = false;
        }
    }
    
}
