//CREATED BY JOSH

using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour {

	public float baseSpeed = 10;
	public float sprintSpeed = 30;
	public float speed;

	public float jumpSpeed = 8;
	public float gravity = 20;

	private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;

    public bool allowMovement = true;

    AudioSource walkingSound;

	void Start()
	{
		controller = this.gameObject.GetComponent <CharacterController>();

		speed = baseSpeed;

        walkingSound = this.gameObject.GetComponent<AudioSource>();
	}

	void Update ()
    {
        //disables movement
        if (!allowMovement)
            return;

        //player movement vector
		if (controller.isGrounded) 
		{
			if (Input.GetKey(KeyCode.LeftShift)) 
			{
				speed = sprintSpeed;
                walkingSound.clip = Resources.Load("Foot Running") as AudioClip;
            } 
			else 
			{
				speed = baseSpeed;
                walkingSound.clip = Resources.Load("Foot Walking") as AudioClip;
			}

            if (!walkingSound.isPlaying && (Input.GetAxis("Horizontal") != 0 || (Input.GetAxis("Vertical") != 0)))
            {
                walkingSound.Play();
            }
            else if (walkingSound.isPlaying && (Input.GetAxis("Horizontal") == 0 && (Input.GetAxis("Vertical") == 0)))
            {
                walkingSound.Stop();
            }

			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
            moveDirection *= speed;

            //space bar press jumps and reduces the speed
            if (Input.GetKeyDown(KeyCode.Space)) 
			{
                moveDirection /= speed;
                moveDirection *= speed / 1.25f;
                moveDirection.y = jumpSpeed;
			}

            
        }

        //applying gravity and moving the character
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	}
}
