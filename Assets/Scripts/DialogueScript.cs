using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueScript : MonoBehaviour
{
    Game game;
    List<string[]> allDialogue = new List<string[]>();
    MouseLook player, cam;
    Movements movement;

    public bool showDialogue;
    int dialogueIndex;
    float scrW = Screen.width / 16, scrH = Screen.height / 9;

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

    void Start () {
        game = GetComponent<Game>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movements>();

        allDialogue.Add(dialogue0);	
	}
	
	void OnGUI()
    {
        if (showDialogue)
        {
            player.enabled = false;
            cam.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            movement.allowMovement = false;
            
            #region DIALOGUE 0
            if (game.gameProgression == 0 && game.dialogueProgression == 0)
            {
                if (dialogueIndex == allDialogue[game.dialogueProgression].Length)
                {
                    game.gameProgression++;
                    game.dialogueProgression++;
                    dialogueIndex = 0;                 
                }
                else
                {
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
                player.enabled = true;
                cam.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                showDialogue = false;
                movement.allowMovement = true;
            }
        }
    }
}
