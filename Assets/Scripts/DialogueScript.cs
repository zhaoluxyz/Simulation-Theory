using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueScript : MonoBehaviour
{
    Game game;
    List<string[]> allDialogue = new List<string[]>();
    MouseLook playerLook, camLook;
    Movements movement;
    Interact interact;
    Camera cam;
    GUIStyle dialogueStyle;

    public bool showDialogue;
    bool multipleOptions;
    int dialogueIndex = 0;
    float scrW = Screen.width / 16, scrH = Screen.height / 9, camFOV;

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
    #region dialogue1
    string[] dialogue1 =
    {
        "Player: How are you able to speak to me?",
        "Tree: This isn't real life.",
        "Tree: Huh? What do you mean?",
        "Player: I can give you the short version or the long version.",
        //short: index 4
        "Tree: Scientists are doing experiments on you and your brain is connected to a simulation.",
        "Player: WHAT? HOW LONG HAVE I BEEN HERE FOR?!",
        "Tree: Only a day.",
        "Player: WHAT?! ONLY A DAY?! IT'S FELT LIKE YEARS!",
        "Tree: That's because the computer is able to process a reality faster than reality itself.",
        "Tree: One of the programmers have programmed me into the simulation to try help you escape",
        //long: index 10
        "Tree: You were kidnapped by a group oif scientists who are doing experiments on you.",
        "Tree: They put you to sleep and inserted a chip into your brain which is connected to this simulation.",
        "Tree: They are monitoring how your brain reacts to living in a virtual world.",
        "Player: WHAT? HOW LONG HAVE I BEEN HERE FOR?!",
        "Tree: Only a day.",
        "Player: WHAT?! ONLY A DAY?! IT'S FELT LIKE YEARS!",
        "Tree: That's because the computer is able to process a reality faster than reality itself.",
        "Tree: the reasn I'm able to talk to you is because one of their programmers believes what they are doing is wrong and wants to help you escape without them knowing he is helping",
        "Tree: So he programmed me to help",
        //continueing: index 19
        "Player: So how are you going to help me?",
        "Tree: There's an object not to far from here that can give me tha bility to change the simulation code.",
        "Tree: But since I'm only a tree I'm unable to go get it.",
        "Player: So where is this object?",
        "Tree: It is somewhere down the path to the left.",
        "Player: What does it look like?",
        "Tree: I'm not sure but look for something that looks out of place.",
        "Player: I'll be right back."
    };
    #endregion

    void Start ()
    {
        //game = game/dialogue progression, playerlook = player rotation, camlook = camera rotation, movement = player movement, interact = player interaction, cam = maincamera camera component
        game = GetComponent<Game>();
        playerLook = GameObject.Find("Player").GetComponent<MouseLook>();
        camLook = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();
        movement = GameObject.Find("Player").GetComponent<Movements>();
        interact= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Interact>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        camFOV = cam.fieldOfView;

        allDialogue.Add(dialogue0);
        allDialogue.Add(dialogue1);
    }

    void Update()
    {
        scrW = Screen.width / 16;
        scrH = Screen.height / 9;

        if (showDialogue && !multipleOptions)
            if (Input.GetKeyDown(KeyCode.Space))
                dialogueIndex++;
    }
	
	void OnGUI()
    {
        dialogueStyle = new GUIStyle(GUI.skin.box);
        dialogueStyle.fontSize = (int)(scrW/2.5);
        dialogueStyle.normal.textColor = Color.white;
        dialogueStyle.hover.textColor = Color.white;
        dialogueStyle.alignment = TextAnchor.MiddleCenter;
        dialogueStyle.wordWrap = true;
        dialogueStyle.padding = new RectOffset(5, 60, 0, 0);

        //show dialogue
        if (showDialogue)
        {
            //disable movement and enable cursor
            playerLook.enabled = false;
            camLook.enabled = false;
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

                    DialogueComplete();
                }
                else
                {
                    //display the dialogure and increment the index
                    GUI.Box(new Rect(0, (Screen.height / 2) - (1.5f * scrH), Screen.width, 3 * scrH), allDialogue[game.dialogueProgression][dialogueIndex], dialogueStyle);

                    if (GUI.Button(new Rect(14.8f * scrW, 5 * scrH, scrW, 0.5f * scrH), "Next"))
                    {
                        multipleOptions = false;
                        dialogueIndex++;
                    }

                    if (dialogueIndex == 6)
                    {
                        //zooms in onto the tree on last dialogue
                        Quaternion targetPlayerRot = Quaternion.Euler(0, 90, 0);
                        Quaternion targetCameraRot = Quaternion.Euler(0, -270, 0);

                        playerLook.transform.rotation = Quaternion.Lerp(playerLook.transform.rotation, targetPlayerRot, 3f * Time.deltaTime);
                        camLook.transform.rotation = Quaternion.Lerp(camLook.transform.rotation, targetCameraRot, 3f * Time.deltaTime);
                        cam.fieldOfView = 30;
                    }
                }
            }
            #endregion
            #region DIALOGUE 1
            else if (game.gameProgression == 1 && game.dialogueProgression == 1)
            {
                //if there is no more dialogure then progress through game
                if (dialogueIndex == allDialogue[1].Length)
                {
                    game.gameProgression++;
                    game.dialogueProgression++;
                    dialogueIndex = 0;

                    DialogueComplete();
                }
                else
                {
                    //display the dialogure and increment the index
                    GUI.Box(new Rect(0, (Screen.height / 2) - (1.5f * scrH), Screen.width, 3 * scrH), allDialogue[game.dialogueProgression][dialogueIndex], dialogueStyle);

                    if (dialogueIndex == 9)
                        dialogueIndex = 19;

                    if(dialogueIndex == 3)
                    {
                        multipleOptions = true;
                        if (GUI.Button(new Rect(13.6f * scrW, 4.4f * scrH, 2.3f*scrW, 0.5f * scrH), "1. Short Version") || Input.GetKeyDown(KeyCode.Alpha1))
                        {
                            dialogueIndex++;
                            multipleOptions = false;
                        }
                        if (GUI.Button(new Rect(13.6f* scrW, 5 * scrH, 2.3f*scrW, 0.5f * scrH), "2. Long Version") || Input.GetKeyDown(KeyCode.Alpha2))
                        {
                            dialogueIndex = 10;
                            multipleOptions = false;
                        }
                    }
                    else if(GUI.Button(new Rect(14.8f * scrW, 5 * scrH, scrW, 0.5f * scrH), "Next"))
                    {
                        dialogueIndex++;
                    }
                }
            }
            #endregion
            else
            {
                DialogueComplete();
            }
        }
    }

    void DialogueComplete()
    {
        //when dialogue is complete
        playerLook.enabled = true;
        camLook.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        showDialogue = false;
        movement.allowMovement = true;
        interact.isInteracting = false;
        cam.fieldOfView = camFOV;
    }
}
