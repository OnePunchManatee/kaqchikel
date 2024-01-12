using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static bool freeze = false;
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag = 1;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    //public float playerHeight = 1f;
    public LayerMask whatIsGround;
    bool grounded;

    Scene currentScene;
    public Transform orientation;   

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    private Vector3 lastPosition;

    public GameObject playerObj;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        currentScene = SceneManager.GetActiveScene();
        lastPosition = transform.position;
        print(lastPosition);
    }
    


    /*private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a non-trigger Collider
        if (!collision.collider.isTrigger)
        {
            if (!grounded)
            {
                // Move the player back to their previous position
                transform.position = lastPosition;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Check if the collision is with a non-trigger Collider
        if (!collision.collider.isTrigger)
        {
            if (!grounded)
            {
                // Move the player back to their previous position
                transform.position = lastPosition;
            }
        }
    }*/

    private void LateUpdate()
    {
        // Update the last position of the player
        lastPosition = transform.position;
    }


    private void MyInput()
    {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            //when to jump
            if (Input.GetKey(jumpKey) && readyToJump && grounded)
            {
                readyToJump = false;

                Jump();

                Invoke(nameof(ResetJump), jumpCooldown);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //MyInput();
        
        ////ground check
        ////GameObject capsule = GetComponent<GameObject>();

        //grounded = Physics.Raycast(transform.position, Vector3.down, 2, whatIsGround);
        ////print(capsule.transform.position);
        ////if (rb.velocity.y > -.1 && rb.velocity.y<=0)
        ////{
        ////    grounded = true;
        ////}
        //print(grounded);
        ////handle drag;
        //if (grounded)
        //{
        //    rb.drag = groundDrag;
        //}
        //else
        //{
        //    rb.drag = 2;
        //}
        //SpeedControl();
        ////print(rb.position.z);
        //if (rb.position.y < -6 && currentScene.name == "GardenDimension")
        //{
        //    rb.position = new Vector3(55, 6, 82);
        //    //SceneManager.LoadScene("Simulation");
        //} else if(rb.position.x > 61.1 && rb.position.z >100.75 && rb.position.z <-100.3 || rb.position.y < -11.5)
        //{
        //    SceneManager.LoadScene("GardenDimension");
        //}


    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (!PlayerMovement.freeze)
        {
            //calculate movement direction
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            if (!grounded)
            {
                //rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            }
        }
        MyInput();

        //ground check
        //GameObject capsule = GetComponent<GameObject>();

        //grounded = Physics.Raycast(transform.position, Vector3.down, 2, whatIsGround);
        //print(capsule.transform.position);
        if (rb.velocity.y > -.2 && rb.velocity.y <= .2)
        {
            grounded = true;
        } else
        {
            grounded = false;
        }
        //print(grounded);
        //handle drag;
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0; // TODO
        }
        SpeedControl();
        //print(rb.position.z);
        if (rb.position.y < -6 && currentScene.name == "GardenDimension")
        {
            rb.position = new Vector3(55, 6, 82);
            //SceneManager.LoadScene("Simulation");
        }
        else if (rb.position.x > 61.1 && rb.position.z > 100.75 && rb.position.z < -100.3 || rb.position.y < -11.5)
        {
            SceneManager.LoadScene("GardenDimension");
        }
    }

    void Jump()
    {
        if (!PlayerMovement.freeze)
        {
            //resets y-velocity for consistent jump height
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    void ResetJump()
    {
        readyToJump = true;
    }
    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
