using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfEnemiesManager : MonoBehaviour
{
    [SerializeField] private Queue<GroupOfEnemies> groupOfEnemies;
    

    private static GroupOfEnemiesManager instance;

    public static GroupOfEnemiesManager Instance
    {
        get
        {
            instance = FindObjectOfType<GroupOfEnemiesManager>();
            if (instance == null)
            {
                GameObject go = new GameObject("EnemyManager");
                instance = go.AddComponent<GroupOfEnemiesManager>();
            }
            return instance;
        }
    }
    
    private void Awake()
    {
        groupOfEnemies = new Queue<GroupOfEnemies>();       
    }

    public void Assign(GameObject[] gameobj)
    {        
        foreach (GameObject go in gameobj)
        {
            go.GetComponent<GroupOfEnemies>().enabled = false;           
            groupOfEnemies.Enqueue(go.GetComponent<GroupOfEnemies>());
        }

        //Debug.Log("Asignado");
    }
    
    public void ActivateGroup()
    {
        if (groupOfEnemies.Count == 0)
        {
            Debug.Log(groupOfEnemies.Count);
            return;
        }
        GroupOfEnemies goe = groupOfEnemies.Dequeue();
        //Debug.Log(goe);
        goe.enabled = true;
        //Debug.Log("Activado");
    }
}
