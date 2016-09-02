using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueScript : MonoBehaviour
{
    Game game;
    List<string[]> allDialogue = new List<string[]>();
    MouseLook player, cam;
    Movements movement;
    Interact interact;

    public bool showDialogue;
    int dialogueIndex;
    float scrW = Screen.width / 16, scrH = Screen.height / 9;

    #region dialogue0
    string [] dialogue0 = 
    {
        "Hey! you over there!",
        "Player: Huh? who said that?",
        "I'm over here!",
        "Player: Over Where?",
        "I'm right in front of you!",
        "Player: The tree?!",
        "Tree: Yes! come closer so we aren't yelling at each other!"
    };
    #endregion

    void Start () {
        game = GetComponent<Game>();
        player = GameObject.Find("Player").GetComponent<MouseLook>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();
        movement = GameObject.Find("Player").GetComponent<Movements>();
        interact= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Interact>();


        allDialogue.Add(dialogue0);	
	}
	
	void OnGUI()
    {
        //show dialogue
        if (showDialogue)
        {
            //disable movement and enable cursor
            player.enabled = false;
            cam.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            movement.allowMovement = false;
            interact.isInteracting = true;
            
            #region DIALOGUE 0
            if (game.gameProgression == 0 && game.dialogueProgression == 0)
            {
                //if there is no more dialogure then progress through game
                if (dialogueIndex == allDialogue[game.dialogueProgression].Length)
                {
                    game.gameProgression++;
                    game.dialogueProgression++;
                    dialogueIndex = 0;                 
                }
                else
                {
                    //display the dialogure and increment the index
                    GUI.Box(new Rect(0, (Screen.height / 2) - (1.5f * scrH), Screen.width, 3 * scrH), allDialogue[game.dialogueProgression][dialogueIndex]);

                    if (GUI.Button(new Rect(15 * scrW, 5 * scrH, scrW, 0.5f * scrH), "Next"))
                    {
                        dialogueIndex++;
                    }
                }
            }
            #endregion
            else
            {
                //when dialogue is complete enable movement and disable cursor
                player.enabled = true;
                cam.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                showDialogue = false;
                movement.allowMovement = true;
                interact.isInteracting = false;
            }
        }
    }
}
