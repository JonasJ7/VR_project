using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    private Vr input;
    private Vector2 movementDir;
    private bool movementPressed;
    public GameObject player;
    public Camera cam;
    public float moveSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        input = new Vr();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementPressed)
        {
            Vector3 forward = cam.transform.forward;
            forward.y = 0;
            forward.Normalize();
            forward *= movementDir.y;
            Vector3 right = cam.transform.right;
            right.y = 0;
            right.Normalize();
            right *= movementDir.x;
            forward += right;

            player.transform.position += forward * Time.deltaTime * moveSpeed;
        }
    }



    public void GetMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movementDir = context.ReadValue<Vector2>();
            movementPressed = true;
        }
        if (context.canceled)
        {
            movementDir = Vector2.zero;
            movementPressed = false;
        }
    }


    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
