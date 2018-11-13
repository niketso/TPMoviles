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
            if (enemyToActivate.activeSelf == true)
            {
                Debug.Log("DESACTIVAR WINDOW");
                Time.timeScale = 1;
                enemyToActivate.SetActive(false);
            }
            else
            {
                Debug.Log("ACTIVAR WINDOW");
                Time.timeScale = 0.5f;
                enemyToActivate.SetActive(true);
                enemyAnim.SetTrigger("Attack");
            }
        }
    }
}
