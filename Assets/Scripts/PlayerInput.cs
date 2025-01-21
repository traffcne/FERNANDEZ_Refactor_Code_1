using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Controls")]
    [Tooltip("Keys to Move")]
    [SerializeField] private KeyCode forwardKey;
    [SerializeField] private KeyCode backKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;

    public Vector3 inputVector;

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        float xInput = 0;
        float zInput = 0;

        if (Input.GetKey(forwardKey))
        {
            zInput++;
        }

        if (Input.GetKey(backKey))
        {
            zInput--;
        }

        if (Input.GetKey(leftKey))
        {
            xInput--;
        }

        if (Input.GetKey(rightKey))
        {
            xInput++;
        }

        inputVector = new Vector3(xInput, 0, zInput);
    }
}
