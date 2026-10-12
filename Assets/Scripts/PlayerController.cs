using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;
    private float zBound = 10;
    public InputAction moveAction;
    public InputAction jumpAction;
    public float speed = 10;
    public float jumpFoce = 5;
    public bool isJumping;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction.Enable();
        jumpAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        ClampPosition();
        if (jumpAction.WasPressedThisFrame() && !isJumping)
        {
            Jump();
            isJumping = true;
        }
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(movement * Time.deltaTime * speed);
    }
    void ClampPosition()
    {
        Vector3 pos = transform.position;
        pos.z = Mathf.Clamp(pos.z, -zBound, zBound);
        transform.position = pos;
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpFoce, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(collision.gameObject.name);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("tawng sm");
            Destroy(other.gameObject);
        }
    }
}
