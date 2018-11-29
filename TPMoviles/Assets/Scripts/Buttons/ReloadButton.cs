using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadButton : VirtualJoystickButtons {

	bool isActivated = false;

	public void ActivateReloadButton()
	{
		 isActivated = true;
	}

	public bool ButtonState()
	{
		return isActivated;
	}

	public void DeactivateReloadButton()
	{
		isActivated = false;
	}
}
