using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player; // Every "Public" variable needs to be filled in with its value from outside of here, in the Unity editor component of the script. 
    // ^^ We could also retrieve the player by giving them a "Player" tag, and doing FindGameObjectsWithTag, like we did in the Player class to find the platforms.
    // Either way works, and it depends on you which way you prefer (getting other classes via public variables, or via tags). 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerPositionX = player.transform.position.x; // This gets the player's x position.
        float playerColliderPositionX = player.GetComponent<BoxCollider>().center.x; // This also gets the player's x position.
        // The two of these are almost the same in behavior, and you can use either of these. The former gets the player's visual position, the latter gets the 
        // player's physical position (the position of its collider). 
    }
}
