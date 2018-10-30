using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCreator : MonoBehaviour {

    Animator animatorEnemy;
    EnemyMovement enemy;
    LayerMask layermaskEnemy = 10;

	void Start ()
    {
        animatorEnemy = GetComponent<Animator>();
        enemy = GetComponent<EnemyMovement>();
	}
	
	void Update ()
    {
        
        RaycastHit hit1;
        var direction1 = transform.forward;
        Physics.Raycast(transform.position, direction1, out hit1, 3);

        RaycastHit hit2;
        var direction2 = Quaternion.AngleAxis(30, transform.up)*transform.forward;
        Physics.Raycast(transform.position, direction2, out hit2, 3);

        RaycastHit hit3;
        var direction3 = Quaternion.AngleAxis(60, transform.up) * transform.forward;
        Physics.Raycast(transform.position, direction3, out hit3, 3);

        RaycastHit hit4;
        var direction4 = Quaternion.AngleAxis(90, transform.up) * transform.forward;
        Physics.Raycast(transform.position, direction4, out hit4, 3);

        RaycastHit hit5;
        var direction5 = Quaternion.AngleAxis(-30, transform.up) * transform.forward;
        Physics.Raycast(transform.position, direction5, out hit5, 3);

        RaycastHit hit6;
        var direction6 = Quaternion.AngleAxis(-60, transform.up) * transform.forward;
        Physics.Raycast(transform.position, direction6, out hit6, 3);

        RaycastHit hit7;
        var direction7 = Quaternion.AngleAxis(-90, transform.up) * transform.forward;        
        Physics.Raycast(transform.position, direction7, out hit7, 3);

        if (hit1.transform.CompareTag("Enemy") || hit2.transform.CompareTag("Enemy") || hit3.transform.CompareTag("Enemy") || hit4.transform.CompareTag("Enemy")
            || hit5.transform.CompareTag("Enemy") || hit6.transform.CompareTag("Enemy") || hit7.transform.CompareTag("Enemy"))
        {
            Debug.Log("CHOQUE CONTRA ENEMIGO");
            animatorEnemy.SetFloat("Speed", 0);
            enemy.isStopped = true;
        }
        else
        {
            animatorEnemy.SetFloat("Speed", 0.1f);
            enemy.isStopped = false;
        }
    }
}
