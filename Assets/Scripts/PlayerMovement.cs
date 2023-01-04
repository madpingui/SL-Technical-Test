using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Player movement speed.")]                                public float speed         = 1.0f;
    [Tooltip("Force applied to players jump.")]                        public float jumpForce     = 5.0f;

    [Space]

    [Header ("Jetpack")]
    [Tooltip("Force that is going to be applied when using jetpack.")] public float jetpackForce  = 5.0f;
    [Tooltip("Fuel recharged per second.")]                            public float rechargeRate  = 1.0f;
    [Tooltip("Fuel discharge per second when using jetpack.")]         public float dischargeRate = 1.0f;
    [Tooltip("Maximum fuel amount.")]                                  public float maxFuel       = 100.0f;
    
    public float currentFuel { get; private set; }
    
    private Rigidbody rigidbody;
    private Camera camera;
    private float groundCheckDistance = 0.5f;
    private bool gameEnded = false;

    void Start()
    {
        currentFuel = maxFuel; // Begin with jetpack tank filled;
        rigidbody = GetComponent<Rigidbody>();
        camera = Camera.main; // Expensive search but once it's fine.

        WinState.WinEvent += () => gameEnded = true;
    }

    void Update()
    {
        if(gameEnded)
            return;

        Movement();
        Jump();
        Jetpack();

        CheckValidPlayerPosition();
    }

    // All logic for player movement
    void Movement()
    {
        // Works both with WASD and arrow keys.
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        // Get the camera's forward direction.
        var cameraForward = camera.transform.forward;
        cameraForward.y = 0;  // Ignore the vertical component.
        cameraForward = cameraForward.normalized;

        // Move the player relative to the camera direction.
        var direction = cameraForward * vertical + camera.transform.right * horizontal;

        rigidbody.AddForce(direction * speed);
    }

    
    void Jump()
    {
        // Check if the player wants to jump.
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void Jetpack()
    {
        // Check if the player wants to use jetpack, it's not grounded and has fuel, if so then use jetpack.
        if (Input.GetKey(KeyCode.LeftShift) && !IsGrounded() && currentFuel > 0)
        {
            rigidbody.AddForce(Vector3.up * jetpackForce, ForceMode.Force);
            currentFuel = Mathf.Max(0, currentFuel - Time.deltaTime * dischargeRate);
        }

        // Recharge fuel over time when grounded.
        if (IsGrounded())
            currentFuel = Mathf.Min(maxFuel, currentFuel + Time.deltaTime * rechargeRate);
    }

    // Check if the player is grounded
    bool IsGrounded() => Physics.Raycast(transform.position, Vector3.down, groundCheckDistance + 0.1f);

    void CheckValidPlayerPosition()
    {
        // Prevention if player went underground.
        if (transform.position.y < -10)
        {
            // Reset player position
            transform.position = Vector3.up;
        }
    }
}
