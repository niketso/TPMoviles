using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RayCreator : MonoBehaviour
{

    Animator animatorEnemy;
    EnemyMovement enemy;
    LayerMask layermaskEnemy = ~10;
    Vector3 rayPos;

    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        enemy = GetComponent<EnemyMovement>();
        //rayPos = new Vector3(transform.position.x+0.35f, transform.position.y + 1, transform.position.z);
        //Debug.Log("ANYTHING");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter" + this.name);
        Debug.Log("Enter" + collision.gameObject.name);
        /*if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(this.name);
            Debug.Log(collision.gameObject.name);
        }*/
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit" + this.name);
        Debug.Log("Exit" + collision.gameObject.name);
        /*if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(this.name);
            Debug.Log(collision.gameObject.name);
        }*/
    }

    float rayLength = 1f;

    int[] angles = new int[] { -20, -10, 0, 10, 20 };
    List<RaycastHit> hits = new List<RaycastHit>();
    //  List<bool> results = new List<bool>();

    void Update()
    {
        hits.Clear();
        // results.Clear();
        rayPos = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z);
        for (int i = 0; i < angles.Length; i++)
        {
            var angle = angles[i];
            var absAngle = Mathf.Abs(angle);
            var newRayLength = (100 - (absAngle * 2)) * rayLength / 100;
            var direction = Quaternion.AngleAxis(angles[i], transform.up) * transform.forward;
            RaycastHit hit;
            var result = Physics.Raycast(rayPos, direction, out hit, newRayLength, layermaskEnemy);
            if (result)
                hits.Add(hit);
        }
        //RaycastHit hit1;
        //var direction1 = transform.forward;
        //var result1 = Physics.Raycast(rayPos, direction1, out hit1, rayLength, layermaskEnemy);
        //RaycastHit hit2;
        //var direction2 = Quaternion.AngleAxis(10, transform.up) * transform.forward;
        //var result2 = Physics.Raycast(rayPos, direction2, out hit2, rayLength, layermaskEnemy);
        //RaycastHit hit3;
        //var direction3 = Quaternion.AngleAxis(20, transform.up) * transform.forward;
        //var result3 = Physics.Raycast(rayPos, direction3, out hit3, rayLength, layermaskEnemy);
        //RaycastHit hit4;
        //var direction4 = Quaternion.AngleAxis(30, transform.up) * transform.forward;
        //var result4 = Physics.Raycast(rayPos, direction4, out hit4, rayLength, layermaskEnemy);
        //RaycastHit hit5;
        //var direction5 = Quaternion.AngleAxis(-10, transform.up) * transform.forward;
        //var result5 = Physics.Raycast(rayPos, direction5, out hit5, rayLength, layermaskEnemy);
        //RaycastHit hit6;
        //var direction6 = Quaternion.AngleAxis(-20, transform.up) * transform.forward;
        //var result6 = Physics.Raycast(rayPos, direction6, out hit6, rayLength, layermaskEnemy);
        //RaycastHit hit7;
        //var direction7 = Quaternion.AngleAxis(-30, transform.up) * transform.forward;
        //var result7 = Physics.Raycast(rayPos, direction7, out hit7, rayLength, layermaskEnemy);
        if (hits.Any())
        //if (result1 || result2 || result3 || result4 || result5 || result6 || result7)
        /*Physics.Raycast(rayPos, direction1, out hit1, 4, layermaskEnemy) || Physics.Raycast(rayPos, direction2, out hit2, 4, layermaskEnemy) || 
       Physics.Raycast(rayPos, direction3, out hit3, 4, layermaskEnemy) || Physics.Raycast(rayPos, direction4, out hit4, 4, layermaskEnemy) || 
       Physics.Raycast(rayPos, direction5, out hit5, 4, layermaskEnemy) || Physics.Raycast(rayPos, direction6, out hit6, 4, layermaskEnemy) || 
       Physics.Raycast(rayPos, direction7, out hit7, 4, layermaskEnemy)*/
        {
            string hitDetails = "";
            //Debug.DrawRay(rayPos, transform.forward, Color.green);
            foreach (var item in hits)
            {
                Debug.DrawLine(rayPos, item.point, Color.red);
                hitDetails = item.collider.name + " " + item.distance + " ";
            }
            //if (result1)
            //{
            //    Debug.DrawLine(rayPos, hit1.point);
            //    //Debug.DrawRay(rayPos, direction1, Color.green);
            //    hitDetails = hit1.collider.name + " " + hit1.distance;
            //}

            /*if (result2)
                Debug.DrawRay(rayPos, direction2, Color.green);
            if (result3)
                Debug.DrawRay(rayPos, direction3, Color.green);
            if (result4)
                Debug.DrawRay(rayPos, direction4, Color.green);
            if (result5)
                Debug.DrawRay(rayPos, direction5, Color.green);
            if (result6)
                Debug.DrawRay(rayPos, direction6, Color.green);
            if (result7)
                Debug.DrawRay(rayPos, direction7, Color.green);*/
            Debug.Log("ENEMY COLLISION - " + this.gameObject.name + " " + hitDetails);

            //Debug.Log("ENEMY COLLISION" + this.gameObject.name + " " + hitDetails + " " + result1 + " " + result2 + " " + result3 + " " + result4 + " " + result5 + " " + result6 + " " + result7);
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
