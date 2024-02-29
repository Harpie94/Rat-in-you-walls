using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    public float jetpackForce = 10f;
    public float jetpackFuelConsumptionRate = 1f;
    public float jetpackFuelRegenRate = 0.5f;
    public float maxJetpackFuel = 100f;

    public float currentJetpackFuel;
    private bool isUsingJetpack;


    // Start is called before the first frame update
    public float movementSpeed = 5f;
    public float jumpForce = 25f;
    public float flyForce = 45f;
    public float rollSpeed = 100f;
    public bool isFlying;
    public bool isGrounded;

    private Rigidbody rb;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
        isFlying = true;

        currentJetpackFuel = maxJetpackFuel;
        isUsingJetpack = false;
    }


    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.6f);
        if (isGrounded)
            isFlying = false;

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


        // Jetpack
        if (isGrounded)
        {
            isFlying = false; // Player is not flying if grounded
        }
        else if (!isGrounded && Input.GetKey(KeyCode.Space) && currentJetpackFuel > 0f)
        {
            rb.AddForce(Vector3.up * jetpackForce * Time.deltaTime, ForceMode.Impulse);
            currentJetpackFuel -= jetpackFuelConsumptionRate * Time.deltaTime;
            isUsingJetpack = true;
            isFlying = true; // Player is flying if not grounded and using jetpack
        }
        else if (isUsingJetpack && (!Input.GetKey(KeyCode.Space) || currentJetpackFuel <= 0f))
        {
            isUsingJetpack = false;
            isFlying = true; // Player is still flying if using jetpack but not holding Space or out of fuel
        }

        // Regenerate jetpack fuel when not using it
        if (!isUsingJetpack && currentJetpackFuel < maxJetpackFuel)
        {
            currentJetpackFuel += jetpackFuelRegenRate * Time.deltaTime;
        }

        // Clamp jetpack fuel
        currentJetpackFuel = Mathf.Clamp(currentJetpackFuel, 0f, maxJetpackFuel);


        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isFlying = true;
        }

    }
}

