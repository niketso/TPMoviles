using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	 Image bgImage;
    Image joystickImage;
    Vector2 inputVector;
    private void Awake() 
	{
        bgImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
    }
	public void OnDrag(PointerEventData eventData)
	{
			Vector2 pos;
			if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform, eventData.position,eventData.pressEventCamera, out pos))
			{
				//Ubicacion exacta de donde se presiono la pantalla.
				pos.x = (pos.x / bgImage.rectTransform.sizeDelta.x);
				pos.y = (pos.y / bgImage.rectTransform.sizeDelta.y);

				//normalizar los valores.
				inputVector = new Vector2(pos.x*2 + 1 ,pos.y*2 - 1);
				if(inputVector.magnitude > 1.0f)
				{
					inputVector = inputVector.normalized;
				}
				//Hacer que se mueva el joystick.
				joystickImage.rectTransform.anchoredPosition = new Vector2(
                    inputVector.x * (bgImage.rectTransform.sizeDelta.x / 3f),
                    inputVector.y * (bgImage.rectTransform.sizeDelta.y / 3f));
				
			}
	}
	public void  OnPointerUp(PointerEventData eventData)
	{
		inputVector =  Vector2.zero;
		joystickImage.rectTransform.anchoredPosition = Vector2Int.zero;
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		OnDrag(eventData);
	}

	public float GetHorizontalAxis()
	{
			return inputVector.x;
	}

	public float GetVerticalAxis()
	{
		return inputVector.y;
	}

	



}
