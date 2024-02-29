using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJoueur : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 5f;
    public float jumpForce = 25f;
    public float flyForce = 45f;
    public float rollSpeed = 100f;
    public float maxFlyTime = 3f;
    public bool isFlying ;
    public bool isGrounded ;
    public float flyCooldownTime = 2f;

    private Rigidbody rb;
    private float flyTime = 5f;
    private float flyCooldownTimer = 0f;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
        isFlying = true;
    }


    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.6f);

        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0f) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Roll on Y-axis (A or E)
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.back, -rollSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.back, rollSpeed * Time.deltaTime);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isFlying = true;
            flyCooldownTimer = flyCooldownTime;
        }

        // Fly
        if (Input.GetKey(KeyCode.Space) && isFlying == true)
        {
            rb.AddForce(Vector3.up * flyForce * Time.deltaTime, ForceMode.Impulse);
            flyTime += Time.deltaTime;
            flyCooldownTimer = flyCooldownTime;
            transform.Rotate(Vector3.back, -rollSpeed * Time.deltaTime);
        }

        // Reset flying state and time after leaving the ground
        if (!isGrounded)
        {
            isFlying = true;
            flyCooldownTimer = flyCooldownTime; // Reset cooldown timer when leaving the ground
        }
        else
        {
            isFlying = false;
            flyTime = 0f;

            // Reduce the cooldown timer
            if (flyCooldownTimer > 0)
            {
                flyCooldownTimer -= Time.deltaTime;
            }
        }
    }

    // Check if the player is still in the fly cooldown period
    bool IsInFlyCooldown()
    {
        return flyCooldownTimer > 0;
    }
}
