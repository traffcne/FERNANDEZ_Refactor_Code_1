using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]

    [Tooltip("HorizontalSpeed")]
    [SerializeField] private float moveSpeed;

    [Tooltip("Rate of Change for moveSpeed")]
    [SerializeField] private float moveAccel;

    [Tooltip("Decel when no input")]
    [SerializeField] private float moveDecel;

    public PlayerInput PI;
    private float currentSpeed;
    private float initialYPos;
    private CharacterController playerControl;

    private void Awake()
    {
        playerControl = GetComponent<CharacterController>();
        initialYPos = transform.position.y;
    }

    void Update() 
    {
        Move(PI.inputVector);
    }

    private void Move(Vector3 inputVector)
    {
        if (inputVector == Vector3.zero)
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= moveDecel * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0);
            }
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, Time.deltaTime * moveAccel);
        }

        Vector3 movement = inputVector.normalized * currentSpeed * Time.deltaTime;
        playerControl.Move(movement);
        transform.position = new Vector3(transform.position.x, initialYPos, transform.position.z);

    }
}
