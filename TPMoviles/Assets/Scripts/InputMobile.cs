using UnityEngine;

public class InputMobile : IInput
{

    public float GetHorizontalCameraAxis()
    {
        //Crear d pad en UI.
        return Input.GetAxis("Horizontal");
    }


    public float GetVerticalCameraAxis()
    {
        //Crear d pad en UI.
        return Input.GetAxis("Vertical");
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
