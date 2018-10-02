using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private PlayerMovement player;

    private static EnemyManager instance;
    public static EnemyManager Instance
    {
        get
        {
            instance = FindObjectOfType<EnemyManager>();
            if (instance == null)
            {
                GameObject go = new GameObject("EnemyManager");
                instance = go.AddComponent<EnemyManager>();
            }
            return instance;
        }
    }

      
    private void Awake()
    {
        enemies = new List<GameObject>();
    }
    public void Assign(GameObject gameobj)
    {
        enemies.Add(gameobj);
    }
    public void ClearList(GameObject gameobj)
    {
        enemies.Remove(gameobj);
        if (enemies.Count == 0)
        {
            NextWayPoint();
        }
    }
    private void NextWayPoint()
    {
        player.Walk();
    }

  
}
