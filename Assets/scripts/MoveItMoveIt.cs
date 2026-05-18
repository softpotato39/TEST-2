using UnityEngine;

// HELLO !
// this is a script to put on: PLAYER
// it just gotta count stuff for ya then do stuff with it >:)

public class MoveItMoveIt : MonoBehaviour
{
    // banana - character controller    // sonic - speed
    // uppies - jump force / strength   // apple - gravity
    // wind - velocity                  // grass - if player is on the ground

    public CharacterController banana;      // character player component (ADD IT ON PLAYER !)
    public float sonic = 10f;               // speed
    public float shadowSonic = 20f;         // RUN speed >:)
    public float uppies = 5f;               // jump force / strength 
    public float apple = -9.8f;             // gravity
    Vector3 wind;
    bool grass;                             //check if player on ground to enable/disable jump

    //SAY CHEESE - camera stuff
    public float mouseSensitivity = 2f;
    public float verticalRotation = 0f;
    private Transform cameraTransform;

    void Start()
    {
        //SAY CHEESE
        cameraTransform = Camera.main.transform;
        //i want my aesthetics bro - makes mouse invisible >:)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void RotateCamera()
    {
        //I GO WHERE YOU GO - makes horizontal + vertical relative to where the camera is looking
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
    void Update()
    {
        //ground check and stuff :D
        grass = banana.isGrounded;
        if (grass && wind.y < 0)
        {
            wind.y = -2f;
        }

        //movin around and stuff :3
        float sideways = Input.GetAxis("Horizontal");
        float onwards = Input.GetAxis("Vertical");
        Vector3 move = (transform.forward * onwards + transform.right * sideways).normalized;
        //banana.Move(move * sonic * Time.deltaTime);

        //added sprinting i think ? :O
        bool weRunnnin = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = weRunnnin ? shadowSonic : sonic;
        banana.Move(move * currentSpeed * Time.deltaTime);

        //jumping and stuff :O
        if (Input.GetKeyDown(KeyCode.Space) && grass)
        {
            wind.y = Mathf.Sqrt(uppies * -2f * apple);
        }

        //jump time and fall time and stuff :P
        wind.y += apple * Time.deltaTime;
        banana.Move(wind * Time.deltaTime);
        RotateCamera();

    }
}
