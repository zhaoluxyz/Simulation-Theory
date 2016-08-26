//CREATED BY JOSH

using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    public bool isInteracting;
    public bool isHovering;
    string hoverText;

	void Update ()
    {
        //if you are currently interacting then disable the ability to interact
        if (isInteracting)
            return;

        //raycast when E is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray rayInteract = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit castHit;

            if (Physics.Raycast(rayInteract, out castHit, 20))
            {
                //interact with door then open door
                if (castHit.collider.CompareTag("Door"))
                {
                    Door doorMove = castHit.transform.GetComponent<Door>();
                    doorMove.moving = true;
                    doorMove.open = !doorMove.open;
                }
            }
        }

        //raycast to view kind of interaction

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
        //if the raycast is hovering over a object then display the corresponding text
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
