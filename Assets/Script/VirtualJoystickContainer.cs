﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystickContainer : MonoBehaviour ,IDragHandler, IPointerUpHandler, IPointerDownHandler 

{
	private Image bgImg;
	private Image joystickImg;

	public Vector3 InputDirection{ set; get; }

	private void Start()
	{
		bgImg = GetComponent<Image> ();
		joystickImg = transform.GetChild(0).GetComponent<Image> ();
		InputDirection = Vector3.zero;
	}


	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos = Vector2.zero;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform,ped.position, ped.pressEventCamera,out pos))
		{
			pos.x = (pos.x/bgImg.rectTransform.sizeDelta.x);
//			pos.y = (pos.y/bgImg.rectTransform.sizeDelta.y);

			float x = (bgImg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
//			float y = (bgImg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

			InputDirection = new Vector3 (x, 0, 0);
			InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

			joystickImg.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (bgImg.rectTransform.sizeDelta.x / 3 ),
				InputDirection.y * (bgImg.rectTransform.sizeDelta.y / 3));
		}	
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{
		//				InputDirection = Vector3.zero; // for don't follow me game
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	//	public float Horizontal()
	//	{
	//		if (InputDirection.x != 0)
	//			return InputDirection.x;
	//		else
	//			return Input.GetAxis ("Horizontal");
	//	}
	//
	//	public float Vertical()
	//	{
	//		if (InputDirection.x != 0)
	//			return InputDirection.y;
	//		else
	//			return Input.GetAxis ("Vertical");
	//	}
}
