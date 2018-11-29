using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpButton : VirtualJoystickButtons {
	bool isActivated = false;

	public void ActivatePowerUpButton()
	{
		 isActivated = true;
	}

	public bool ButtonState()
	{
		return isActivated;
	}

	public void DeactivatePowerUpButton()
	{
		isActivated = false;
	}
}
