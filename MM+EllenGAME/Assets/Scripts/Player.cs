using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 0.01f;
    Vector3 position;
    GameObject[] platforms;
    GameObject[] ramps;
    BoxCollider body;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        ramps = GameObject.FindGameObjectsWithTag("Ramp");
        body = gameObject.GetComponent<BoxCollider>();
    }

    private void movementHandlerWeeeeeee()
    {
        if (Input.GetKey("w"))
        {
            // <x, y, z> = <x, y, z> + <0, 0, 1> * 0.01f.
            position = position + Vector3.forward * speed;
        }
        if (Input.GetKey("s"))
        {
            position = position - Vector3.forward * speed;
        }
        if (Input.GetKey("a"))
        {
            //                    <1, 0, 0>
            position = position - Vector3.right * speed;
        }
        if (Input.GetKey("d"))
        {
            position = position + Vector3.right * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movementHandlerWeeeeeee();

        foreach (GameObject platform in platforms)
        {
            // Make collision with each platform (but not the ramps. Ramps are handled as a special case below, but you may want to make the sides of a ramp behave like a wall :o), or just use Unity's default collision detection. I personally like coding it myself, since then I can change it how 
            // I like, but you can just use Unity's default collision detection too. 
        }


        foreach (GameObject ramp in ramps)
        {
            BoxCollider box = ramp.GetComponent<BoxCollider>();
            if (body.bounds.center.x + body.bounds.extents.x > box.bounds.center.x - box.bounds.extents.x &&
                body.bounds.center.x - body.bounds.extents.x < box.bounds.center.x + box.bounds.extents.x &&
                body.bounds.center.z + body.bounds.extents.z > box.bounds.center.z - box.bounds.extents.z &&
                body.bounds.center.z - body.bounds.extents.z < box.bounds.center.z + box.bounds.extents.z)
            {
                float length = body.bounds.size.z + box.bounds.size.z;
                float slope = box.bounds.size.y / length;

                // We should make this work for ramps in all four different directions too (ramps to the right, ramps to the left, ramps behind you, etc). 
                // Also, another thing to do is make sure the player cannot enter, say, a ramp that's infront of them, from the lefthand side. So ramps can only be entered 
                // in the direction the ramps are angled towards. 
                if (Input.GetKey("w"))
                {
                    position = position + Vector3.up * slope * speed;
                }
                if (Input.GetKey("s"))
                {
                    position = position - Vector3.up * slope * speed;
                }
            }
        }

        transform.position = position;

    }
}
