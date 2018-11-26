using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualJoystickButtons : MonoBehaviour, IPointerUpHandler, IPointerDownHandler{

   [SerializeField] Button fireButton;
   [SerializeField] Button reloadButton;
   [SerializeField] Button powerUpButton;


    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    public bool FireButton()
    {
        return true;
        
    }
    public bool ReloadButton()
    {
        return true;
    }

    public bool PowerUpButton()
    {
        return true;
    }
}
