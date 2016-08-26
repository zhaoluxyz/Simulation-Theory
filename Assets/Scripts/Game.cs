//CREATED BY JOSH

using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public int gameProgression = 0;
    //0-walk through front door, 1-talk to tree,

    public int dialogueProgression = 0;
    //0-walk through front door, 1-talk to tree,

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
}
