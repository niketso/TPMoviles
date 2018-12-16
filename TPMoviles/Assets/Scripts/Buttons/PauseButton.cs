using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : VirtualJoystickButtons {

	bool isActivated = false;

	public void ActivatePauseButton()
	{
		 isActivated = true;
	}

	public bool ButtonState()
	{
		return isActivated;
	}

	public void DeactivatePauseButton()
	{
		isActivated = false;
	}
}
