//CREATED BY JOSH

using UnityEngine;
using System.Collections;

public class StartGameFrontDoor : MonoBehaviour {

    bool hasBeenTriggered;

    string[] dialogue =
    {
        "Hey, you over there.",
        "Player: Huh? who said that?",
        "I'm over here.",
        "Player: Where?",
        "I'm right in front of you.",
        "Player: The tree?",
        "Tree: Yes, come closer so we aren't yelling at each other."
    };

    void OnTriggerEnter(Collider collider)
    {
        if (!hasBeenTriggered)
        {

        }
    }
}
