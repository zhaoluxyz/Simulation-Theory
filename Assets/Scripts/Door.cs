using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public bool open = false;
	public bool moving;
	AudioSource doorSound;
	public float openedY, closedY;
	public float speed = 10;
	public bool isSound;

	void Start()
	{
		doorSound = gameObject.GetComponent<AudioSource>();
	}

	void Update()
	{	
		if (moving)
		{			
			if (!open)
			{

				Quaternion targetRotation = Quaternion.Euler(0, closedY, 0);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

				if (transform.rotation == targetRotation)
				{
					moving = false;
				}
			}
			else
			{
				Quaternion targetRotation = Quaternion.Euler(0, openedY, 0);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

				if (transform.rotation == targetRotation)
				{
					moving = false;
				}
			}
		}
	}

	public void PlaySound()
	{
		Debug.Log ("Played door sound");
		doorSound.Play ();
		isSound = doorSound.isPlaying;
	}
}
