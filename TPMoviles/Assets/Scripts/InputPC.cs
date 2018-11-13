

using UnityEngine;

public class InputPC : IInput
{
    public float GetHorizontalCameraAxis()
    {
         return Input.GetAxis("Horizontal");
    }


    public float GetVerticalCameraAxis()
    {
        return Input.GetAxis("Vertical");
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

}

