using UnityEngine;

public class SwimMovement : MonoBehaviour
{
    //basic swim movement variables ONLY XY MOVEMENT
    public float speed = 10f; //self explanatory
    public Rigidbody rb; //player rigiding it
    Vector3 movement; //xy movement

    //bobbing up and down after sometime i suppose
    Vector3 idlePosition;
    float bobbingHeight = 1f;
    float bobSpeed = 1.5f;
    //public Animator spriteSheet below when sprite comes for bob and swimming

    void Start()
    {
        
    }

    void Update()
    {
        //basic movement
        movement.x = Input.GetAxis("Horizontal") * speed;
        movement.y = Input.GetAxis("Vertical") * speed;

        //animations
        if (movement.x != 0 || movement.y != 0) //detects movement by detecing the vector 3 movement
        {
            idlePosition = transform.position; //tracks last pos FOR IDLE REF
        }
        else
        {
            //3am note im guessing something to do with Time.time because
            // time is always going to be at a different moment and there isn't a set "start" area
            //hence the height of the block is somewhat randomn based on when the player will 
            // stop and start moving in that sense. so finding a way to always start on the middle y axis
            //of the idle position before bobbng up and down on the calculated spot is the goal.
            float newY = Mathf.Sin(Time.time * bobSpeed) * bobbingHeight + idlePosition.y; //up down
            transform.position = new Vector3(idlePosition.x, newY); //transoformm
        }
    }

    void FixedUpdate() //PART OF BASIC MOVEMENT
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
