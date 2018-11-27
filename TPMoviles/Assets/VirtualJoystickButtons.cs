using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualJoystickButtons : MonoBehaviour, IPointerUpHandler{

    [SerializeField] FireButton _fireButton;
    [SerializeField]  ReloadButton _reloadButton;
     [SerializeField]  PowerUpButton _powerUpButton;

    public void OnPointerUp(PointerEventData eventData)
    {   
       _fireButton.DeactivateFireButton();
       _reloadButton.DeactivateReloadButton();
       _powerUpButton.DeactivatePowerUpButton();

    }
   
    public bool FireButton()
    {
        return _fireButton.ButtonState();      
    }
    public bool ReloadButton()
    {
        return _reloadButton;
    }

    public bool PowerUpButton()
    {
        return _powerUpButton;
    }
}
