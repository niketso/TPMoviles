﻿using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualJoystickButtons : MonoBehaviour{

    [SerializeField] FireButton _fireButton;
    [SerializeField]  ReloadButton _reloadButton;
     [SerializeField]  PowerUpButton _powerUpButton;

   
    public bool FireButton()
    {
        return _fireButton.ButtonState();      
    }
    public bool ReloadButton()
    {
        return _reloadButton.ButtonState();
    }

    public bool PowerUpButton()
    {
        return _powerUpButton.ButtonState();
    }
}