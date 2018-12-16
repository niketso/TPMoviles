

using UnityEngine;

public class InputPC : IInput
{
    public float GetHorizontalCameraAxis()
    {
         return Input.GetAxis("Mouse X");
    }


    public float GetVerticalCameraAxis()
    {
        return Input.GetAxis("Mouse Y");
    }


    public bool GetFireButton()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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
        if (Input.GetKeyDown(KeyCode.Q))
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

    public bool GetPauseButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

