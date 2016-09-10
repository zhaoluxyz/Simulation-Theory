using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    //what part of the game you are up to
    public int gameProgression = 0;
    //0-walk through front door, 1-talk to tree,

    //what dialogue you are up to
    public int dialogueProgression = 0;
    //0-walk through front door, 1-talk to tree,

    void Start()
    {
        //hide cursor and lock it
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
}
