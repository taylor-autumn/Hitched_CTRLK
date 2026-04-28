using UnityEngine;
using UnityEngine.Assemblies;

public class SwimMovement : MonoBehaviour
{
    //basic swim movement variables ONLY XY MOVEMENT
    public float speed = 10f; //self explanatory
    public Rigidbody2D rb; //player rigiding it
    Vector2 movement; //xy movement

    //bobbing up and down after sometime i suppose
    Vector3 idlePosition;
    private bool isIdleOff; //toggle
    private float bobbingStart = 0; //bobbing start is time replacement
    public float bobbingHeight = 1f;
    public float bobSpeed = 1.5f;
    //public Animator spriteSheet below when sprite comes for bob and swimming
    public Animator swimmingAnimations;
    public bool tpTrigger = false;

    void Start()
    {
        isIdleOff = false; //Is idle off? false (no), meaning idle is on, I know weird wording.
    }

    void Update()
    {
        //basic movement
        movement.x = Input.GetAxis("Horizontal") * speed;
        movement.y = Input.GetAxis("Vertical") * speed;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) //detects movement by detecing inputs
        {
            swimmingAnimations.SetBool("isWalking",true);
            swimmingAnimations.SetFloat("InputX",movement.x);//walkingAnims
            swimmingAnimations.SetFloat("InputY",movement.y);
            idlePosition = transform.position; //tracks last pos FOR IDLE REF
            isIdleOff = true; //is not idle
        }
        else//IDLE
        {
            if (isIdleOff == true && tpTrigger == false)
            {
                swimmingAnimations.SetBool("isWalking",false);
                swimmingAnimations.SetFloat("LastInputX",movement.x);//go to idle
                swimmingAnimations.SetFloat("LastInputY",movement.y);
                bobbingStart = 0;
                isIdleOff = false;
            }
            bobbingStart += 0.0001f; 
            //sorry for the bad variable names lol, but imagine bobbing start as
            //a clock/t and on the graph it just restarts to the start of the graph
            //in the if you want to change the speed use bobSpeed
            float newY = Mathf.Sin(bobbingStart * bobSpeed) * bobbingHeight + idlePosition.y;
            transform.position = new Vector3(idlePosition.x, newY, idlePosition.z); //transformm
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            tpTrigger = true;
            idlePosition = collision.gameObject.GetComponent<teleport>().targetCharPosition;
            print(idlePosition);
            transform.position = idlePosition;
            Invoke("triggerTpOff", 1f);
        }
    }
    void OTriggerEnter2D(Collider2D collision)
    {
        
    }

    void FixedUpdate() //PART OF BASIC MOVEMENT
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    void triggerTpOff()
    {
        tpTrigger = false;
    }
}
