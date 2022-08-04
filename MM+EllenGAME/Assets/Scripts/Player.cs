using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 0.0125f;
    float faster = 0.03f;
    Vector3 position;
    GameObject[] platforms;
    GameObject[] rampsBT;
    GameObject[] rampsTB;
    GameObject[] rampsLR;
    GameObject[] rampsRL;
    BoxCollider body;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        rampsBT = GameObject.FindGameObjectsWithTag("RampBT");
        rampsTB = GameObject.FindGameObjectsWithTag("RampTB");
        rampsLR = GameObject.FindGameObjectsWithTag("RampLR");
        rampsRL = GameObject.FindGameObjectsWithTag("RampRL");
        body = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        movementHandler();

        foreach (GameObject platform in platforms)
        {
            BoxCollider box = platform.GetComponent<BoxCollider>();

            // Implement collision detection between player and platforms
            xCollisionHandler(body, box);
            zCollisionHandler(body, box);
        }

        // The next four for-loops implement ramp inclinations in the four distinct directions. 
        // There is almost certainly a better way to write these four for-loops using a single loop, which should be done in the future.

        // Height increase from bottom (lowest z coordinate) to top (highest z coordinate)
        foreach (GameObject ramp in rampsBT)
        {
            
            BoxCollider box = ramp.GetComponent<BoxCollider>();

            // Do not let player enter ramp from the side
            xCollisionHandler(body, box);

            // Move player up and down in y-direction on ramps
            if (body.bounds.center.x + body.bounds.extents.x > box.bounds.center.x - box.bounds.extents.x &&
                body.bounds.center.x - body.bounds.extents.x < box.bounds.center.x + box.bounds.extents.x &&
                body.bounds.center.z + body.bounds.extents.z > box.bounds.center.z - box.bounds.extents.z &&
                body.bounds.center.z - body.bounds.extents.z < box.bounds.center.z + box.bounds.extents.z)
            {
                float length = body.bounds.size.z + box.bounds.size.z;
                float slope = box.bounds.size.y / length;

                if (Input.GetKey("w"))
                {
                    if (Input.GetKey("c"))
                    {
                        position = position + Vector3.up * slope * faster;
                    }
                    else {
                        position = position + Vector3.up * slope * speed;
                    }
                }
                    
                if (Input.GetKey("s"))
                {
                    if (Input.GetKey("c"))
                    {
                        position = position - Vector3.up * slope * faster;
                    }
                    else {
                        position = position - Vector3.up * slope * speed;
                    }
                }
            }
        }

        // Height increase from top (higest z coordinate) to bottom (lowest z coordinate)
        foreach (GameObject ramp in rampsTB)
        {

            BoxCollider box = ramp.GetComponent<BoxCollider>();

            // Do not let player enter ramp from the side
            xCollisionHandler(body, box);

            // Move player up and down in y-direction on ramps
            if (body.bounds.center.x + body.bounds.extents.x > box.bounds.center.x - box.bounds.extents.x &&
                body.bounds.center.x - body.bounds.extents.x < box.bounds.center.x + box.bounds.extents.x &&
                body.bounds.center.z + body.bounds.extents.z > box.bounds.center.z - box.bounds.extents.z &&
                body.bounds.center.z - body.bounds.extents.z < box.bounds.center.z + box.bounds.extents.z)
            {
                float length = body.bounds.size.z + box.bounds.size.z;
                float slope = box.bounds.size.y / length;

                if (Input.GetKey("w"))
                {
                    if (Input.GetKey("c"))
                    {
                        position = position - Vector3.up * slope * faster;
                    }
                    else {
                        position = position - Vector3.up * slope * speed;
                    }
                }
                if (Input.GetKey("s"))
                {
                    if (Input.GetKey("c"))
                    {
                        position = position + Vector3.up * slope * faster;
                    }
                    else {
                        position = position + Vector3.up * slope * speed;
                    }
                    
                }
            }
        }

        // Height increase from left (lowest x coordinate) to rigt (highest x coordinate)
        foreach (GameObject ramp in rampsLR)
        {

            BoxCollider box = ramp.GetComponent<BoxCollider>();

            // Do not let player enter ramp from the side
            zCollisionHandler(body, box);

            // Move player up and down in y-direction on ramps
            if (body.bounds.center.x + body.bounds.extents.x > box.bounds.center.x - box.bounds.extents.x &&
                body.bounds.center.x - body.bounds.extents.x < box.bounds.center.x + box.bounds.extents.x &&
                body.bounds.center.z + body.bounds.extents.z > box.bounds.center.z - box.bounds.extents.z &&
                body.bounds.center.z - body.bounds.extents.z < box.bounds.center.z + box.bounds.extents.z)
            {
                float length = body.bounds.size.x + box.bounds.size.x;
                float slope = box.bounds.size.y / length;

                if (Input.GetKey("d"))
                {
                    if (Input.GetKey("c"))
                    {
                        position = position + Vector3.up * slope * faster;
                    }
                    else {
                        position = position + Vector3.up * slope * speed;
                    }
                    
                }
                if (Input.GetKey("a"))
                {
                    if (Input.GetKey("c"))
                    {
                        position = position - Vector3.up * slope * faster;
                    }
                    else {
                        position = position - Vector3.up * slope * speed;
                    }
                    
                }
            }
        }

        // Height increase from right (highest x coordinate) to left (lowest x coordinate)
        foreach (GameObject ramp in rampsRL)
        {

            BoxCollider box = ramp.GetComponent<BoxCollider>();

            // Do not let player enter ramp from the side
            zCollisionHandler(body, box);

            // Move player up and down in y-direction on ramps
            if (body.bounds.center.x + body.bounds.extents.x > box.bounds.center.x - box.bounds.extents.x &&
                body.bounds.center.x - body.bounds.extents.x < box.bounds.center.x + box.bounds.extents.x &&
                body.bounds.center.z + body.bounds.extents.z > box.bounds.center.z - box.bounds.extents.z &&
                body.bounds.center.z - body.bounds.extents.z < box.bounds.center.z + box.bounds.extents.z)
            {
                float length = body.bounds.size.x + box.bounds.size.x;
                float slope = box.bounds.size.y / length;

                if (Input.GetKey("d"))
                {
                    if (Input.GetKey("c"))
                    {
                        position = position + Vector3.up * slope * faster;
                    }
                    else {
                        position = position - Vector3.up * slope * speed;
                    } 
                }
                if (Input.GetKey("a"))
                {
                    if (Input.GetKey("c"))
                    {
                        position = position + Vector3.up * slope * faster;
                    }
                    else {
                        position = position + Vector3.up * slope * speed;
                    } 
                }
            }
        }

        // Actual player movement occurs here
        transform.position = position;
    }

    // Normalized movement
    private void movementHandler()
    {
        // Allow for multiple 'wasd' button presses at once
        int upMoveCount = 0;
        int rightMoveCount = 0;
        int isFaster = 0;

        if (Input.GetKey("w"))
        {
            upMoveCount += 1;
            if (Input.GetKey("c"))
            {
                isFaster += 1;
            }
        }
        if (Input.GetKey("a"))
        {
            rightMoveCount -= 1;
            if (Input.GetKey("c"))
            {
                isFaster += 1;
            }
        }
        if (Input.GetKey("s"))
        {
            upMoveCount -= 1;
            if (Input.GetKey("c"))
            {
                isFaster += 1;
            }
        }
        if (Input.GetKey("d"))
        {
            rightMoveCount += 1;
            if (Input.GetKey("c"))
            {
                isFaster += 1;
            }
        }

        if (upMoveCount != 0 || rightMoveCount != 0)
        {
            // Determine magnitude and direction of new position vector relative to old position
            var magnitude = Mathf.Sqrt(rightMoveCount * rightMoveCount + upMoveCount * upMoveCount);
            var resultant = rightMoveCount * Vector3.right + upMoveCount * Vector3.forward;
            if (isFaster !=0)
            {
                position = position + (resultant / magnitude) * faster;
            }
            else {
            // Set new position
            position = position + (resultant / magnitude) * speed;
            }
        }
    }

    private void xCollisionHandler(BoxCollider self, BoxCollider obj)
    {
        // Only run this code if we are in the right z-location.
        if (self.bounds.center.z + self.bounds.extents.z > obj.bounds.center.z - obj.bounds.extents.z &&
            self.bounds.center.z - self.bounds.extents.z < obj.bounds.center.z + obj.bounds.extents.z &&
            self.bounds.center.y + self.bounds.extents.y > obj.bounds.center.y - obj.bounds.extents.y &&
            self.bounds.center.y - self.bounds.extents.y < (obj.bounds.center.y + obj.bounds.extents.y) * 0.5f)
        {
            // Colliding outside-left and moving right
            if (self.bounds.center.x < obj.bounds.center.x - obj.bounds.extents.x &&
                self.bounds.center.x + self.bounds.extents.x > obj.bounds.center.x - obj.bounds.extents.x &&
                Input.GetKey("d"))
            {
                if (Input.GetKey("c"))
                {
                    position = position - Vector3.right * faster;
                }
                else {
                    position = position - Vector3.right * speed;
                }
            }

            // Colliding inside-right and moving left
            if (self.bounds.center.x > obj.bounds.center.x - obj.bounds.extents.x &&
                self.bounds.center.x - self.bounds.extents.x < obj.bounds.center.x - obj.bounds.extents.x &&
                Input.GetKey("a"))
            {
                if (Input.GetKey("c"))
                {
                    position = position + Vector3.right * faster;
                }
                else {
                    position = position + Vector3.right * speed;
                }
            }

            // Colliding outside-right and moving left
            if (self.bounds.center.x > obj.bounds.center.x + obj.bounds.extents.x &&
                self.bounds.center.x - self.bounds.extents.x < obj.bounds.center.x + obj.bounds.extents.x &&
                Input.GetKey("a"))
            {
                if (Input.GetKey("c"))
                {
                    position = position + Vector3.right * faster;
                }
                else {
                    position = position + Vector3.right * speed;
                }
            }

            // Colliding inside-left and moving right
            if (self.bounds.center.x < obj.bounds.center.x + obj.bounds.extents.x &&
                self.bounds.center.x + self.bounds.extents.x > obj.bounds.center.x + obj.bounds.extents.x &&
                Input.GetKey("d"))
            {
                if (Input.GetKey("c"))
                {
                    position = position - Vector3.right * faster;
                }
                else {
                    position = position - Vector3.right * speed;
                }
            }
        }
    }

    private void zCollisionHandler(BoxCollider self, BoxCollider obj)
    {
        // Only run this code if we are in the right x-location and right eight.
        if (self.bounds.center.x + self.bounds.extents.x > obj.bounds.center.x - obj.bounds.extents.x &&
            self.bounds.center.x - self.bounds.extents.x < obj.bounds.center.x + obj.bounds.extents.x &&
            self.bounds.center.y + self.bounds.extents.y > obj.bounds.center.y - obj.bounds.extents.y &&
            self.bounds.center.y - self.bounds.extents.y < (obj.bounds.center.y + obj.bounds.extents.y) * 0.5f)
        {
            // Colliding outside-bottom and moving up
            if (self.bounds.center.z < obj.bounds.center.z - obj.bounds.extents.z &&
                self.bounds.center.z + self.bounds.extents.z > obj.bounds.center.z - obj.bounds.extents.z &&
                Input.GetKey("w"))
            {
                if (Input.GetKey("c"))
                {
                    position = position - Vector3.forward * faster;
                }
                else {
                    position = position - Vector3.forward * speed;
                }
            }

            // Colliding inside-top and moving down
            if (self.bounds.center.z > obj.bounds.center.z - obj.bounds.extents.z &&
                self.bounds.center.z - self.bounds.extents.z < obj.bounds.center.z - obj.bounds.extents.z &&
                Input.GetKey("s"))
            {
                if (Input.GetKey("c"))
                {
                    position = position + Vector3.forward * faster;
                }
                else {
                    position = position + Vector3.forward * speed;
                }
            }

            // Colliding outside-top and moving down
            if (self.bounds.center.z > obj.bounds.center.z + obj.bounds.extents.z &&
                self.bounds.center.z - self.bounds.extents.z < obj.bounds.center.z + obj.bounds.extents.z &&
                Input.GetKey("s"))
            {
                if (Input.GetKey("c"))
                {
                    position = position + Vector3.forward * faster;
                }
                else {
                    position = position + Vector3.forward * speed;
                }
            }

            // Colliding inside-bottom and moving up
            if (self.bounds.center.z < obj.bounds.center.z + obj.bounds.extents.z &&
                self.bounds.center.z + self.bounds.extents.z > obj.bounds.center.z + obj.bounds.extents.z &&
                Input.GetKey("w"))
            {
                if (Input.GetKey("c"))
                {
                    position = position - Vector3.forward * faster;
                }
                else {
                    position = position - Vector3.forward * speed;
                }
            }
        }
    }
}
