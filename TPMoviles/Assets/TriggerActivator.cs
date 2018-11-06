using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivator : MonoBehaviour {

    Animator enemyAnim;
    [SerializeField] GameObject enemyToActivate;


    private void Awake()
    {
        enemyAnim = enemyToActivate.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyToActivate.SetActive(false);
        }
    }
}
