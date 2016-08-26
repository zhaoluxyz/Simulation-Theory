//CREATED BY JOSH

using UnityEngine;
using System.Collections;

public class StartGameFrontDoor : MonoBehaviour {

    Game gameProgression;
    DialogueScript dialogueScript;

    void Start()
    {
        gameProgression = GameObject.Find("Game").GetComponent<Game>();
        dialogueScript = GameObject.Find("Game").GetComponent<DialogueScript>();
    }

    //if the game progression is 0 then display the corresponding dialogue
    void OnTriggerEnter(Collider collider)
    {
        if (gameProgression.gameProgression == 0)
        {
            dialogueScript.showDialogue = true;
        }
    }
}
