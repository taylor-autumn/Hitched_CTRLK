using UnityEngine;
using UnityEngine.InputSystem;

public class SwimMovement : MonoBehaviour
{
    //basic swim movement variables ONLY XY MOVEMENT
    public float speed; //self explanatory
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
    storyProgression storyProgression;
    private Vector2 IdleDelay; 

    void Start()
    {
        isIdleOff = false; //Is idle off? false (no), meaning idle is on, I know weird wording.
        storyProgression = GameObject.Find("gameManager").GetComponent<storyProgression>();
    }

    void Update()
    {
        //CAN ONLY MOVE IN NORMAL MODE, NO MOVEMENT IN DIALOGUE OR MENU
        if (storyProgression.mode == storyProgression.gameMode.normal)
        {
            GetComponent<Animator>().enabled = true;
            swimmingAnimations.SetBool("stopWalkDebug", true);
            //basic movement
            movement.x = Input.GetAxis("Horizontal") * speed;
            movement.y = Input.GetAxis("Vertical") * speed;
        }
        else
        {
            swimmingAnimations.SetBool("stopWalkDebug", false);
            swimmingAnimations.SetBool("isWalking", false);
            swimmingAnimations.SetFloat("InputX", 0);//walkingAnims
            swimmingAnimations.SetFloat("InputY", 0);
            swimmingAnimations.SetFloat("LastInputX", 0);//go to idle
            swimmingAnimations.SetFloat("LastInputY", 0);
        }


            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) //detects movement by detecing inputs
        {
            swimmingAnimations.SetBool("isWalking", true);
            swimmingAnimations.SetFloat("InputX", movement.x);//walkingAnims
            swimmingAnimations.SetFloat("InputY", movement.y);
            idlePosition = transform.position; //tracks last pos FOR IDLE REF
            isIdleOff = true; //is not idle
        }
        else//IDLE
        {
            if (isIdleOff == true && tpTrigger == false)
            {
                swimmingAnimations.SetBool("isWalking", false);
                swimmingAnimations.SetFloat("LastInputX", movement.x);//go to idle
                swimmingAnimations.SetFloat("LastInputY", movement.y);
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
        if (gameObject.GetComponent<playerProgress>().levelsCompleted == collision.gameObject.GetComponent<teleport>().progressRequiredToStart)
        {   //ik its weird but because of how I wrote the idle position anim code it will look like this.
            IdleDelay = collision.gameObject.GetComponent<teleport>().targetCharPosition;
            float delayTime = collision.gameObject.GetComponent<teleport>().delayTime;
            print(delayTime);
            Invoke("animationDelay", delayTime);
        }
            
    }

    void FixedUpdate() //PART OF BASIC MOVEMENT
    {
        if (storyProgression.mode == storyProgression.gameMode.normal)
        {
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        }
    }

    void animationDelay()
    {
        tpTrigger = true;
        idlePosition = IdleDelay;
        print(idlePosition);
        transform.position = idlePosition;
        Invoke("triggerTpOff", 1f);
    }
    void triggerTpOff()
    {
        tpTrigger = false;
    }
}
