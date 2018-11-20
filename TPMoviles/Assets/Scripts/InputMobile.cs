using UnityEngine;

public class InputMobile : IInput
{
    VirtualJoystick _virtualJoystick;
    public InputMobile(VirtualJoystick vj)
    {
        _virtualJoystick = vj;
    }
       
    public float GetHorizontalCameraAxis()
    {
        
        return _virtualJoystick.GetHorizontalAxis();
    }


    public float GetVerticalCameraAxis()
    {
        
        return _virtualJoystick.GetVerticalAxis();
    }


    public bool GetFireButton()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
        if (Input.GetKeyDown(KeyCode.O))
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
