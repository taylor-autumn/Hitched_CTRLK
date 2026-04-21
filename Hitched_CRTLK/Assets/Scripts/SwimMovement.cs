using UnityEngine;

public class SwimMovement : MonoBehaviour
{
    //basic swim movement variables ONLY XY MOVEMENT
    public float speed = 10f; //self explanatory
    public Rigidbody rb; //player rigiding it
    Vector3 movement; //xy movement

    //bobbing up and down after sometime i suppose
    Vector3 idlePosition;
    private bool idleOnorOff; //toggle
    private float bobbingStart = 0; //bobbing start is time replacement
    public float bobbingHeight = 1f;
    public float bobSpeed = 1.5f;
    //public Animator spriteSheet below when sprite comes for bob and swimming

    void Start()
    {
        idleOnorOff = false;
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
            idleOnorOff = true;
        }
        else
        {
            if (idleOnorOff == true)
            {
                bobbingStart = 0;
                idleOnorOff = false;
            }
            bobbingStart += 0.0001f; 
            //sorry for the bad variable names lol, but imagine bobbing start as
            //a clock/t and on the graph it just restarts to the start of the graph
            //in the (basically always the center of the player rather than random 
            // starting times) if you want to change the speed bobSpeed is less confusing
            float newY = Mathf.Sin(bobbingStart * bobSpeed) * bobbingHeight + idlePosition.y;
            transform.position = new Vector3(idlePosition.x, newY, idlePosition.z); //transformm
        }
    }

    void FixedUpdate() //PART OF BASIC MOVEMENT
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
