using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfEnemies : MonoBehaviour {
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private PlayerMovement player;

    private void Awake()
    {
        enemies = new List<GameObject>();
    }
    
    private void Update()
    {
            
    }
    public void Assign(GameObject gameobj)
    {
        gameobj.SetActive(false);
        enemies.Add(gameobj);
    }
    public void ClearList(GameObject gameobj)
    {
        enemies.Remove(gameobj);

        if (enemies.Count == 0)
        {
            player.SetNextWaypoint();
            player.Walk();
        }
    }

    private void OnEnable()
    {
        foreach (GameObject go in enemies)
        {
            go.SetActive(true);
        }
    }
}
