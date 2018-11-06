using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RayCreator : MonoBehaviour
{

    Animator animatorEnemy;
    EnemyMovement enemy;
    LayerMask layermaskEnemy = 1<<10;
    Vector3 rayPos;

    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        enemy = GetComponent<EnemyMovement>();       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter" + this.name);
        Debug.Log("Enter" + collision.gameObject.name);       
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit" + this.name);
        Debug.Log("Exit" + collision.gameObject.name);       
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
            if (result && hit.collider != this.GetComponent<Collider>()/*hit.transform.name!=this.name*/)
                hits.Add(hit);
        }
      
        if (hits.Any())       
        {
            string hitDetails = "";
            foreach (var item in hits)
            {
                Debug.DrawLine(rayPos, item.point, Color.red);
                hitDetails = item.collider.name + " " + item.distance + " ";
            }
           
            Debug.Log("ENEMY COLLISION - " + this.gameObject.name + " " + hitDetails);            
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
