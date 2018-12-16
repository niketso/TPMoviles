﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    AudioSource audioSource;   

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();        
        audioSource.Play();        
    }

}
