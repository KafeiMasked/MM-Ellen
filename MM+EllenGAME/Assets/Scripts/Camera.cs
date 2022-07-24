using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player; // Every "Public" variable needs to be filled in with its value from outside of here, in the Unity editor component of the script. 
    // ^^ We could also retrieve the player by giving them a "Player" tag, and doing FindGameObjectsWithTag, like we did in the Player class to find the platforms.
    // Either way works, and it depends on you which way you prefer (getting other classes via public variables, or via tags). 
    private GameObject[] rightend;
    private GameObject[] leftend;
    private GameObject[] topend;
    private GameObject[] bottomend;

    float angle;
    float radius = 10;
    float yPos;
    float zPos;

    float xPos;

    // Start is called before the first frame update
    void Start()
    {
        rightend = GameObject.FindGameObjectsWithTag("EndRight");
        leftend = GameObject.FindGameObjectsWithTag("EndLeft");
        topend = GameObject.FindGameObjectsWithTag("EndTop");
        bottomend = GameObject.FindGameObjectsWithTag("EndBottom");


        angle = transform.eulerAngles.x;
        yPos = player.transform.position.y + radius * Mathf.Sin(angle * Mathf.PI / 180);
        zPos = player.transform.position.z - radius * Mathf.Cos(angle * Mathf.PI / 180);
        xPos = player.transform.position.x;

        transform.position = new Vector3(xPos, yPos, zPos);


    }

    void handleEnds()
    {
        foreach (GameObject end in rightend)
        {
            Vector3 pos = UnityEngine.Camera.main.WorldToViewportPoint(end.transform.position);
            if (pos.x < 1.0 + (xPos - transform.position.x))
            {
                xPos = transform.position.x;
            }
        }

        foreach (GameObject end in leftend)
        {
            Vector3 pos = UnityEngine.Camera.main.WorldToViewportPoint(end.transform.position);
            if (pos.x > 0.0 + (xPos - transform.position.x))
            {
                xPos = transform.position.x;
            }
        }

        foreach (GameObject end in topend)
        {

            Vector3 pos = UnityEngine.Camera.main.WorldToViewportPoint(end.transform.position);
            if (pos.y < 1.0 + (zPos - transform.position.z))
            {
                zPos = transform.position.z;

            }
        }

        foreach (GameObject end in bottomend)
        {
            Vector3 pos = UnityEngine.Camera.main.WorldToViewportPoint(end.transform.position);
            if (pos.y > 0.0 + (zPos - transform.position.z))
            {
                zPos = transform.position.z;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        yPos = player.transform.position.y + radius * Mathf.Sin(angle * Mathf.PI / 180);
        zPos = player.transform.position.z - radius * Mathf.Cos(angle * Mathf.PI / 180);
        xPos = player.transform.position.x;

        handleEnds();

        

        

        transform.position = new Vector3(xPos, yPos, zPos);

    }
}
