using UnityEngine;
using System.Collections;
using System;

public class Interact : MonoBehaviour {

    public bool isInteracting, isHovering, invalidProgression;
    string hoverText;

    float scrW = Screen.width / 16, scrH = Screen.height / 9;

    DateTime timedisplay;

    Game gameProgression;
    DialogueScript dialogueScript;

    void Start()
    {
        gameProgression = GameObject.Find("Game").GetComponent<Game>();
        dialogueScript = GameObject.Find("Game").GetComponent<DialogueScript>();
    }

    void Update ()
    {
        scrW = Screen.width / 16;
        scrH = Screen.height / 9;

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
					doorMove.PlaySound ();
                }
                else if (castHit.collider.CompareTag("NPC"))
                {
                    if(gameProgression.gameProgression == 1 && gameProgression.dialogueProgression == 1)
                        dialogueScript.showDialogue = true;
                    else
                    {
                        if (gameProgression.gameProgression == 2 && gameProgression.dialogueProgression == 2)
                        {
                            invalidProgression = true;
                            hoverText = "You need to go and get the object which will allow me to help you!";
                            timedisplay = DateTime.Now.AddSeconds(5);
                        }

                    }
                }
                else if (castHit.collider.CompareTag("Keyboard"))
                {
                    Debug.Log("interact keyboard");
                    castHit.transform.GetComponent<scptKeyboardStuff>().KeyboardPickedUp();
                }
            }
        }

        if (invalidProgression)
        {
            isHovering = false;
            return;
        }

        //raycast to view text of interaction type

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
            else
                isHovering = false;
        }
        else
            isHovering = false;

    }

    void OnGUI()
    {
        //style for displayed text
        GUIStyle labelStyle = new GUIStyle();
        labelStyle.fontSize = (int)(scrW/2.5);
        labelStyle.normal.textColor = Color.white;
        labelStyle.alignment = TextAnchor.MiddleCenter;
        labelStyle.wordWrap = true;

        //if you speak to someone when there is no new dialogue
        if (invalidProgression)
        {
            if (timedisplay > DateTime.Now)
            {
                labelStyle.fontSize = (int)(scrW/2);
                GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 200), hoverText, labelStyle);
            }
            else
                invalidProgression = false;
            return;
        }

        //if you are currently interacting then disable the ability to interact
        if (isInteracting)
            return;

        //if the raycast is hovering over a object then display the corresponding text
        if (isHovering)
        {
            GUI.Label(new Rect(Screen.width / 2 -75, Screen.height / 2 - 25, 150, 50), hoverText, labelStyle);
        }
            
    }

}
