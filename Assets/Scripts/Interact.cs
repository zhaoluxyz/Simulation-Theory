//CREATED BY JOSH

using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    public bool isInteracting;
    public bool isHovering;
    string hoverText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isInteracting)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray rayInteract = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit castHit;

            if (Physics.Raycast(rayInteract, out castHit, 20))
            {
                if (castHit.collider.CompareTag("Door"))
                {
                    Door doorMove = castHit.transform.GetComponent<Door>();
                    doorMove.moving = true;
                    doorMove.open = !doorMove.open;
                }
            }
        }


        Ray rayInteractHover = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit castHitHover;

        if (Physics.Raycast(rayInteractHover,out castHitHover, 20))
        {
            if (castHitHover.collider.CompareTag("Door"))
            {
                hoverText = "Press E to Open Door";
                isHovering = true;
            }
            else if (castHitHover.collider.CompareTag("NPC"))
            {
                hoverText = "Press E to Speak";
                isHovering = true;
            }
        }
        else
        {
            isHovering = false;
        }
    }

    void OnGUI()
    {
        if (isHovering)
        {
            GUIStyle labelStyle = new GUIStyle();
            labelStyle.fontSize = (20);
            labelStyle.normal.textColor = Color.white;
            labelStyle.alignment = TextAnchor.MiddleCenter;
            labelStyle.wordWrap = true;

            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), hoverText, labelStyle);
        }
    }

}
