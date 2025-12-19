using UnityEngine;
using UnityEngine.InputSystem;
public class BowlMovement : MonoBehaviour
{
     [Header("Movement")]
    public float maxSpeed = 10f;
    public float acceleration = 45f;
    public float deceleration = 55f;

    [Header("Screen Bounds")]
    public float screenPadding = 0.5f;

    [Header("Tilt (Juice)")]
    public float maxTilt = 12f;
    public float tiltSmoothness = 10f;

    [Header("Input")]
    public InputActionReference moveAction;

    private float currentSpeed;
    private float targetSpeed;
    private float screenLimit;
    private float moveInput;

    void Awake()
    {
        moveAction.action.Enable();
    }

    void Start()
    {
        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        screenLimit = Camera.main.orthographicSize * Camera.main.aspect
                      - halfWidth
                      - screenPadding;
    }

    void Update()
    {
        ReadInput();
        
    }
    void FixedUpdate()
    {
        UpdateSpeed();
        MoveBowl();
        ApplyTilt();
    }

    void ReadInput()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        moveInput = Mathf.Clamp(input.x, -1f, 1f);
    }

    void UpdateSpeed()
    {
        targetSpeed = moveInput * maxSpeed;

        if (Mathf.Abs(moveInput) > 0.01f)
        {
            currentSpeed = Mathf.MoveTowards(
                currentSpeed,
                targetSpeed,
                acceleration * Time.deltaTime
            );
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(
                currentSpeed,
                0f,
                deceleration * Time.deltaTime
            );
        }
    }

    void MoveBowl()
    {
        Vector3 pos = transform.position;
        pos.x += currentSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -screenLimit, screenLimit);
        transform.position = pos;
    }

    void ApplyTilt()
    {
        float tilt = -currentSpeed / maxSpeed * maxTilt;
        Quaternion targetRot = Quaternion.Euler(0f, 0f, tilt);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRot,
            tiltSmoothness * Time.deltaTime
        );
    }

    void OnDisable()
    {
        moveAction.action.Disable();
    }
}
