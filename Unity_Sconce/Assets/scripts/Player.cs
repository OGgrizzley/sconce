using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Vulnerable
{
    // Properties ///////////////////////////////////////////////////////
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float gravityValue = 9.81f;
    [SerializeField] private float jumpHeight = 10.0f;
    private bool groundedPlayer;
    private bool canJump = true;
    private float playerFallHeight = -35f;
    private float fallDamage = 0f;
    


    // Constructors /////////////////////////////////////////////////////



    // Overrides ////////////////////////////////////////////////////////
    // What happens when a :Player takes damage?
    public override void takeDamage(string _type, float _amount) {
        if (_amount > 0)
            if (_type != "heal")
                return; //Guard clause: Not damaging.


        changeHP(_amount);
        return;
    }
    // What happens when (:Player.hp < 0)?
    public override void die() {
        Debug.Log("DEAD.");
        Destroy(gameObject);
        return;
    }



    // Methods //////////////////////////////////////////////////////////
    void Start()
    {
        hp = hp_max/2;
        controller = gameObject.AddComponent<CharacterController>();
    }
    void Update()
    {
        move();
    }
    
    // TODO: split this into info gathering (Update) and executing (FixedUpdate).
    void move() 
    {
        
        // Gotten from: https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
        // Uses axis define in the Input Manager.
        groundedPlayer = controller.isGrounded;
    
        if (playerVelocity.y < playerFallHeight)
            fallDamage = playerVelocity.y;

        // Stops player from:
        //  - Falling thorugh the floor
        //  - Building downward momentum while remining on the ground.
        //  - Allows for a post-leap jump if player didn't jump from the ground.
        if (groundedPlayer && playerVelocity.y < 0)
        {
            if (fallDamage != 0f) 
            {
                takeDamage("crush", fallDamage);
                fallDamage = 0f;
            }    
            
            canJump = true;
            playerVelocity.y = 0f;
        }
        
        // Clamp vertical speed from (-40 , 40).
        playerVelocity.y = Mathf.Clamp(playerVelocity.y, -40, 40); 

        // Obtain a normalized vector that describes the player's intentions
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = move.normalized;


        // tell the controller where to move horizontally.
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Instantaneous potential change of height
        if (Input.GetButton("Jump") && canJump)
        {
            playerVelocity.y = jumpHeight;
            fallDamage = 0f;
            canJump = false;
        }

        // with constant deccel due to gravity
        playerVelocity.y += -gravityValue * Time.deltaTime;
        
        // tell the controller where to move vertically.
        controller.Move(playerVelocity * Time.deltaTime);
    }


}

