//CREATED BY JOSH

using UnityEngine;
using System.Collections;

public class OldDialogue : MonoBehaviour 
{
	public string[] text;
	public int index, opIndex;
	public bool showDlg;
	public string npcName;

	public MouseLook player,cam;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<MouseLook>();
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<MouseLook>();
	}

	void OnGUI()
	{
		if (showDlg) 
		{
			float scrW = Screen.width / 16;
			float scrH = Screen.height / 9;

			GUI.Box (new Rect (0 , 0.6f * scrH, (float)Screen.width, 3 * scrH), text [index]);

			if (!(index + 1 >= text.Length ||  index == opIndex)) 
			{
				if (GUI.Button (new Rect (15 * scrW, 5 * scrH, scrW, 0.5f * scrH),"Next")) 
				{
					index++;
				}
			} 
			else if (index == opIndex)
			{
				if (GUI.Button (new Rect (13 * scrW, 5.5f * scrH, 1.5f * scrW, 0.5f * scrH),"Accept")) 
				{
					index++;
				}
				if (GUI.Button (new Rect (14.5f * scrW, 5.5f * scrH, 1.5f * scrW, 0.5f * scrH),"Decline")) 
				{
					index++;
				}

			}
			else 
			{
				if (GUI.Button (new Rect (15 * scrW, 5 * scrH, scrW, 0.5f * scrH), "Bye")) 
				{
					showDlg = false;
					player.enabled = true;
					cam.enabled = true;
					Cursor.visible = false;
					Cursor.lockState = CursorLockMode.Locked;
					index = 0;
				}
			}

            if (index == text.Length)
            {
                showDlg = false;
                //index = 0;
            }
                
		}
	}

}
