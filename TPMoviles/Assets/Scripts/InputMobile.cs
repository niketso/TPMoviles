using UnityEngine;

public class InputMobile : IInput
{
    VirtualJoystick _virtualJoystick;
    VirtualJoystickButtons _virtualJoystickButtons;
    public InputMobile(VirtualJoystick vj,VirtualJoystickButtons vjb)
    {
        _virtualJoystick = vj;
        _virtualJoystickButtons = vjb;
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
        return _virtualJoystickButtons.FireButton();
    }

    public bool GetPowerUpButton()
    {       
        return _virtualJoystickButtons.PowerUpButton();     
    }

    public bool GetReloadButton()
    {
        return _virtualJoystickButtons.ReloadButton();
    }

}
