using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

	public MouseLook player,cam;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<MouseLook>();
		cam = GetComponent<MouseLook>();
	}

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			Ray interact;
			interact = Camera.main.ScreenPointToRay (new Vector2 (Screen.width / 2, Screen.height / 2));
			RaycastHit hitInfo;
			if (Physics.Raycast (interact, out hitInfo, 20)) 
			{
				if (hitInfo.collider.CompareTag ("NPC")) 
				{
					Dialogue dlg = hitInfo.transform.GetComponent<Dialogue> ();
					if (dlg != null) 
					{
						dlg.showDlg = true;
						player.enabled = false;
						cam.enabled = false;
						Cursor.visible = true;
						Cursor.lockState = CursorLockMode.None;
					}
				}
                else if (hitInfo.collider.CompareTag("Door"))
                {
                    Door doorMove = hitInfo.transform.GetComponent<Door>();
                    doorMove.moving = true;
                    doorMove.open = !doorMove.open;
                    Debug.Log("Door Interact");
                }
			}
		}
	}
}
