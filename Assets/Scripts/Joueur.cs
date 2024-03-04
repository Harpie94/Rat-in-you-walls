using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    //1 ou 2
    public int PlayerID;
    public int TeamID;
    public float jetpackForce = 10f;
    public float jetpackFuelConsumptionRate = 1f;
    public float jetpackFuelRegenRate = 0.5f;
    public float maxJetpackFuel = 100f;

    public float currentJetpackFuel;
    private bool isUsingJetpack;

    public GameObject Respawnpoint;

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
        {
            isFlying = false;
        }

        // Movement
        float horizontal = 0f;
        float vertical = 0f;

        if (PlayerID == 1)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }
        else if (PlayerID == 2)
        {
            horizontal = Input.GetAxis("P2_Horizontal");
            vertical = Input.GetAxis("P2_Vertical");
        }
        Vector3 inputDirection = new Vector3(horizontal, vertical, 0f).normalized;
        Vector3 movement = transform.TransformDirection(inputDirection);
        rb.AddForce(movement.normalized * movementSpeed);

        if ((PlayerID == 1 && Input.GetKey(KeyCode.Q))||(PlayerID == 2 && Input.GetKey(KeyCode.I)))
        {
            transform.Rotate(Vector3.back, -rollSpeed * Time.deltaTime);
        }
        else if ((PlayerID == 1 && Input.GetKey(KeyCode.E)) || (PlayerID == 2 && Input.GetKey(KeyCode.P)))
        {
            transform.Rotate(Vector3.back, rollSpeed * Time.deltaTime);
        }
            // Jump
        if ((PlayerID == 1 && Input.GetKeyDown(KeyCode.LeftAlt) && isGrounded) || (PlayerID == 2 && Input.GetKeyDown(KeyCode.RightAlt)))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isFlying = true;
        }

        // Jetpack
        if (isGrounded)
        {
            isFlying = false; // Player is not flying if grounded
        }
        else if ((PlayerID == 1 && !isGrounded && Input.GetKey(KeyCode.LeftAlt) && currentJetpackFuel > 0f) || (PlayerID == 2 && !isGrounded && Input.GetKey(KeyCode.RightAlt) && currentJetpackFuel > 0f))
        {
            rb.AddForce(Vector3.up * jetpackForce * Time.deltaTime, ForceMode.Impulse);
            currentJetpackFuel -= jetpackFuelConsumptionRate * Time.deltaTime;
            isUsingJetpack = true;
            isFlying = true; // Player is flying if not grounded and using jetpack
        }
        else if ((PlayerID == 1 && isUsingJetpack && (!Input.GetKey(KeyCode.LeftAlt) || currentJetpackFuel <= 0f) || (PlayerID == 1 && isUsingJetpack && (!Input.GetKey(KeyCode.RightAlt) || currentJetpackFuel <= 0f))))
        {
            isUsingJetpack = false;
            isFlying = true; // Player is still flying if using jetpack but not holding Space or out of fuel
        }

        // Regenerate jetpack fuel when not using it
        if ((PlayerID == 1 && !isUsingJetpack && currentJetpackFuel < maxJetpackFuel) || (PlayerID == 1 && !isUsingJetpack && currentJetpackFuel < maxJetpackFuel))
        {
            currentJetpackFuel += jetpackFuelRegenRate * Time.deltaTime;
        }

        // Clamp jetpack fuel
        currentJetpackFuel = Mathf.Clamp(currentJetpackFuel, 0f, maxJetpackFuel);



    }
}

