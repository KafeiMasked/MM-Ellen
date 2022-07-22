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
        
        foreach (GameObject ramp in ramps)
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
                    position = position + Vector3.up * slope * speed;
                }
                if (Input.GetKey("s"))
                {
                    position = position - Vector3.up * slope * speed;
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

        if (Input.GetKey("w"))
        {
            upMoveCount += 1;
        }
        if (Input.GetKey("a"))
        {
            rightMoveCount -= 1;
        }
        if (Input.GetKey("s"))
        {
            upMoveCount -= 1;
        }
        if (Input.GetKey("d"))
        {
            rightMoveCount += 1;
        }
        if (upMoveCount != 0 || rightMoveCount != 0)
        {
            // Determine magnitude and direction of new position vector relative to old position
            var magnitude = Mathf.Sqrt(rightMoveCount * rightMoveCount + upMoveCount * upMoveCount);
            var resultant = rightMoveCount * Vector3.right + upMoveCount * Vector3.forward;

            // Set new position
            position = position + (resultant / magnitude) * speed;
        }
    }
    
    private void xCollisionHandler(BoxCollider self, BoxCollider obj)
    {
        // Only run this code if we are in the right z-location.
        if (self.bounds.center.z + self.bounds.extents.z > obj.bounds.center.z - obj.bounds.extents.z &&
            self.bounds.center.z - self.bounds.extents.z < obj.bounds.center.z + obj.bounds.extents.z)
        {
            // Colliding outside-left and moving right
            if (self.bounds.center.x < obj.bounds.center.x - obj.bounds.extents.x &&
                self.bounds.center.x + self.bounds.extents.x > obj.bounds.center.x - obj.bounds.extents.x &&
                Input.GetKey("d"))
            {
                position = position - Vector3.right * speed;

            }

            // Colliding inside-right and moving left
            if (self.bounds.center.x > obj.bounds.center.x - obj.bounds.extents.x &&
                self.bounds.center.x - self.bounds.extents.x < obj.bounds.center.x - obj.bounds.extents.x &&
                Input.GetKey("a"))
            {
                position = position + Vector3.right * speed;

            }

            // Colliding outside-right and moving left
            if (self.bounds.center.x > obj.bounds.center.x + obj.bounds.extents.x &&
                self.bounds.center.x - self.bounds.extents.x < obj.bounds.center.x + obj.bounds.extents.x &&
                Input.GetKey("a"))
            {
                position = position + Vector3.right * speed;
            }

            // Colliding inside-left and moving right
            if (self.bounds.center.x < obj.bounds.center.x + obj.bounds.extents.x &&
                self.bounds.center.x + self.bounds.extents.x > obj.bounds.center.x + obj.bounds.extents.x &&
                Input.GetKey("d"))
            {
                position = position - Vector3.right * speed;
            }
        }
    }

    private void zCollisionHandler(BoxCollider self, BoxCollider obj)
    {
        // Only run this code if we are in the right x-location.
        if (self.bounds.center.x + self.bounds.extents.x > obj.bounds.center.x - obj.bounds.extents.x &&
            self.bounds.center.x - self.bounds.extents.x < obj.bounds.center.x + obj.bounds.extents.x)
        {
            // Colliding outside-bottom and moving up
            if (self.bounds.center.z < obj.bounds.center.z - obj.bounds.extents.z &&
                self.bounds.center.z + self.bounds.extents.z > obj.bounds.center.z - obj.bounds.extents.z &&
                Input.GetKey("w"))
            {
                position = position - Vector3.forward * speed;

            }

            // Colliding inside-top and moving down
            if (self.bounds.center.z > obj.bounds.center.z - obj.bounds.extents.z &&
                self.bounds.center.z - self.bounds.extents.z < obj.bounds.center.z - obj.bounds.extents.z &&
                Input.GetKey("s"))
            {
                position = position + Vector3.forward * speed;

            }

            // Colliding outside-top and moving down
            if (self.bounds.center.z > obj.bounds.center.z + obj.bounds.extents.z &&
                self.bounds.center.z - self.bounds.extents.z < obj.bounds.center.z + obj.bounds.extents.z &&
                Input.GetKey("s"))
            {
                position = position + Vector3.forward * speed;
            }

            // Colliding inside-bottom and moving up
            if (self.bounds.center.z < obj.bounds.center.z + obj.bounds.extents.z &&
                self.bounds.center.z + self.bounds.extents.z > obj.bounds.center.z + obj.bounds.extents.z &&
                Input.GetKey("w"))
            {
                position = position - Vector3.forward * speed;
            }
        }
    }
}
