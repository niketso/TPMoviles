using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesBehaviour : MonoBehaviour {

    [SerializeField] private GameObject[] wavesArray;
    
    private void Awake()
    {
        GroupOfEnemiesManager.Instance.Assign(wavesArray);
    }
}
