
using UnityEngine;
using UnityEngine.SceneManagement;


public class PowerUpManager : MonoBehaviour {

    [SerializeField] GameObject plyr;
    [SerializeField] GameObject powerUpUI;
   // private float powerUpDuration = 30;
    private bool powerUpIsActivated = false;

    Timer powerUPDurationTimer = new Timer(10.0f);
    

    private void Update()
    {
        if (!powerUpIsActivated)
        {
            
            InfiniteBullets();
            MachineGun();
        }
        else
        {
            powerUpIsActivated = false;
            powerUpUI.SetActive(false);
        }

    }

    private void InfiniteBullets()
    {
        if (InputManager.Instance.GetPowerUpButton())
        {
            powerUPDurationTimer.Start();                               
        }
        
         if(powerUPDurationTimer.Update(Time.deltaTime))
        {
            powerUpUI.SetActive(false);
            plyr.GetComponent<PlayerShoot>().infiniteAmmoActivated = false;
            Debug.Log("Deactivated");
            powerUPDurationTimer.Reset();
        }
        else if(powerUPDurationTimer.IsRunning)
        {
            plyr.GetComponent<PlayerShoot>().infiniteAmmoActivated = true;
            powerUpUI.SetActive(true);
            

            Debug.Log("Activated");
        }

    }

    private void MachineGun()
    {
        /*if (Input.GetKeyDown(KeyCode.W))
        {
            powerUpUI.SetActive(true);
        }*/
    }
}
