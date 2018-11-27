using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButton :  VirtualJoystickButtons {

	bool isActivated = false;

	public void ActivateFireButton()
	{
		 isActivated = true;
	}

	public bool ButtonState()
	{
		return isActivated;
	}

	public void DeactivateFireButton()
	{
		isActivated = false;
	}
}