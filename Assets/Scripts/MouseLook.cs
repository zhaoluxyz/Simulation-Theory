//CREATED BY JOSH

using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/MouseLook")]

public class MouseLook : MonoBehaviour {

	public enum RotationAxis
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxis axis = RotationAxis.MouseX;
	public float sensitivityX = 10, sensitivityY = 10;
	public float minimumX = -360, maximumX = 360;
	public float minimumY = -90, maximumY = 90;
	float rotationY = 0;

    Settings settings;

    void Start()
    {
        settings = GameObject.Find("Game").GetComponent<Settings>();
        sensitivityX = settings.mouseXSensitivity;
        sensitivityY = settings.mouseYSensitivity;
    }

	void Update () 
	{
        //vertical and horizontal look
		if(axis == RotationAxis.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sensitivityX;
			rotationY += Input.GetAxis ("Mouse Y");
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
        }
        //horizontal look
        else if(axis == RotationAxis.MouseX)
		{
			transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityX, 0);
        }
        //vertical look
		else
		{
			rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3 (-rotationY, transform.localEulerAngles.y, 0);
        }
	}
}
