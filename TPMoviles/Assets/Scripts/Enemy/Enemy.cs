using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private GroupOfEnemies groupOfEnemies;

    private void Awake()
    {
        groupOfEnemies.Assign(gameObject);
    }

    public void IsDead()
    {
        groupOfEnemies.ClearList(gameObject);
    }


    
}
