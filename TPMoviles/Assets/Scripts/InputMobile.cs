using UnityEngine;

public class InputMobile : IInput
{
        [SerializeField] VirtualJoystick vJoystick;
    public float GetHorizontalCameraAxis()
    {
        //Crear joystick en UI.
        return vJoystick.GetHorizontalAxis();
    }


    public float GetVerticalCameraAxis()
    {
        //Crear koystick en UI.
        return vJoystick.GetVerticalAxis();
    }


    public bool GetFireButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool GetPowerUpButton()
    {
        //crear boton en UI.
        if (Input.GetKeyDown(KeyCode.O) )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool GetReloadButton()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
