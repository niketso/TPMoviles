using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	Image bgImage;
    Image joystickImage;
    Vector2 inputVector;

    bool drag = false;

    Camera pressEventCamera;
    int pointerId;

    private void Awake() 
	{
        bgImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
    }
	public void OnDrag(Vector3 position)
	{
		Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform, position, pressEventCamera, out pos))
		{
			//Ubicacion exacta de donde se presiono la pantalla.
			pos.x = pos.x / bgImage.rectTransform.sizeDelta.x;
			pos.y = pos.y / bgImage.rectTransform.sizeDelta.y;

            Debug.Log(pos);

			//normalizar los valores.
			inputVector = new Vector2((pos.x * 2.0f - 1.0f) ,(pos.y * 2.0f - 1.0f));
            
			if(inputVector.magnitude > 1.0f)
			{
				inputVector = inputVector.normalized;
			}
            Debug.Log(inputVector);
                
            //Hacer que se mueva el joystick.
            joystickImage.rectTransform.anchoredPosition = new Vector2(
                inputVector.x * (bgImage.rectTransform.sizeDelta.x / 3f),
                inputVector.y * (bgImage.rectTransform.sizeDelta.y / 3f));
				
		}
	}
	public void  OnPointerUp(PointerEventData eventData)
	{
        pressEventCamera = eventData.pressEventCamera;
        drag = false;
		inputVector =  Vector2.zero;
		joystickImage.rectTransform.anchoredPosition = Vector2Int.zero;
	}
	public void OnPointerDown(PointerEventData eventData)
	{
        pointerId = eventData.pointerId;
        pressEventCamera = eventData.pressEventCamera;
        drag = true;
	}

    void Update()
    {
        if (drag)
        {
            if (pointerId >= Input.touchCount)
                pointerId = 0;

            Touch[] touches = Input.touches;
            
            OnDrag(touches[pointerId].position);
        }
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
