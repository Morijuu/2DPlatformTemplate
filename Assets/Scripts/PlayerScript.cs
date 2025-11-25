using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    PlayerInput input;
    Rigidbody2D rb;
    public float force = 3.0f;
    private float speed = 5.0f;
    public Vector2 move;

// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        move = input.actions["Move"].ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = move.x * speed;
    }
    public void Jump(InputAction.CallbackContext callbackcontext)
    {
        Debug.Log(callbackcontext.phase);
        if(callbackcontext.performed)
        {
            Debug.Log("Jumping");
            rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
    }
}
