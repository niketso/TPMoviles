
using UnityEngine;

public class InputManager : MonoBehaviour {

    static InputManager instance = null;

    IInput input;

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InputManager>();
            }

            return instance;
        }
    }

    // Use this for initialization
    void Awake()
    {
        instance = this;

#if UNITY_ANDROID || UNITY_IOS
        input = new InputMobile();
#else
        input = new InputPC();
#endif
    }
    

    public float GetHorizontalCameraAxis()
    {
        return input.GetHorizontalCameraAxis();
    }


    public float GetVerticalCameraAxis()
    {
        return input.GetVerticalCameraAxis();
    }


    public bool GetFireButton()
    {
        return input.GetFireButton();
    }

    public bool GetPowerUpButton()
    {
        return input.GetPowerUpButton();
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
