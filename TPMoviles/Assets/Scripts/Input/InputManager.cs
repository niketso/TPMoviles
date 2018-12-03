
using UnityEngine;

public class InputManager : MonoBehaviour {

    static InputManager instance = null;

    IInput input;

    [SerializeField] VirtualJoystick vJoystick;
    [SerializeField] VirtualJoystickButtons vJoystickButtons;
    [SerializeField] GameObject movileInputCanvas;

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
        if(!movileInputCanvas)
            movileInputCanvas.SetActive(true);
        input = new InputMobile(vJoystick,vJoystickButtons);
#else
        if (movileInputCanvas)
            movileInputCanvas.SetActive(false);
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
        return input.GetReloadButton();
    }
    
    


}
