using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Joueur : MonoBehaviour
{
    //1 ou 2
    public int PlayerID;
    public int TeamID;

    //Force du Jetpack et valeurs qui vont avec
    public float jetpackForce = 10f;
    public float jetpackFuelConsumptionRate = 1f;
    public float jetpackFuelRegenRate = 0.5f;
    public float maxJetpackFuel = 100f;
    public float currentJetpackFuel;
    private bool isUsingJetpack;


    public GameObject Respawnpoint;



    //Mouvements des joueurs et valeurs qui vont avec
    public float movementSpeed = 5f;
    public float jumpForce = 25f;
    public float flyForce = 45f;
    public float rollSpeed = 100f;
    public bool isFlying;
    public bool isGrounded;
    public Animator animator;
    private Rigidbody rb;
    
    
    
    public float sprintMovementSpeed = 10f;
    public bool isSprinting;


    public float FOVStandard;
    public float FOVSprint;
    public Camera PlayerCamera;
    public float TimerFOV = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
        isFlying = true;
        animator = GetComponent<Animator>();
        
        currentJetpackFuel = maxJetpackFuel;
        isUsingJetpack = false;
        isSprinting = false;
    }


    void Update()
    {
        //Regarde si le joueur touche le sol à l'aide d'un Raycast
        isGrounded = Physics.Raycast(rb.position,-transform.up, 0.6f);
        Debug.DrawRay(transform.position, -transform.up *0.6f, Color.red);
        if (isGrounded)
        {
            isFlying = false;
            animator.SetBool("Jump", false);
            animator.SetBool("Idle", true);

        }
        else
        {
            isFlying = true;
            animator.SetBool("Jump", true);
            animator.SetBool("Idle", false);
        }


        //Permet aux joueurs de controler les personnages 
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

        // Vérifier si le joueur veut courir
        if ((PlayerID == 1 && Input.GetKey(KeyCode.LeftShift)) || (PlayerID == 2 && Input.GetKey(KeyCode.Semicolon)))
        {
            isSprinting = true;
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, FOVSprint, TimerFOV);
        }
        else
        {
            isSprinting = false;
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, FOVStandard, TimerFOV);
        }
        
        // Modifier la vitesse en fonction de la condition de course
        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 movement = transform.TransformDirection(inputDirection);
        float currentSpeed = isSprinting ? sprintMovementSpeed : movementSpeed;
        rb.AddForce(movement.normalized * currentSpeed);


        if ((PlayerID == 1 && Input.GetKey(KeyCode.Q))||(PlayerID == 2 && Input.GetKey(KeyCode.U)))
        {
            transform.Rotate(Vector3.up, -rollSpeed * Time.deltaTime);
        }
        else if ((PlayerID == 1 && Input.GetKey(KeyCode.E)) || (PlayerID == 2 && Input.GetKey(KeyCode.O)))
        {
            transform.Rotate(Vector3.up, rollSpeed * Time.deltaTime);
        }
        

        
        //Vérifie si le joueur bouge et change l'animation en fonction
        if (movement.x != 0 || movement.z != 0)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);

        }



        //Saut
        if ((PlayerID == 1 && Input.GetKeyDown(KeyCode.LeftAlt) && isGrounded) || (PlayerID == 2 && Input.GetKeyDown(KeyCode.RightAlt) && isGrounded))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isFlying = true;
        }

        //Fonctions du Jetpack
        //Vérif si le joueur veux voler, si se dernier est en saut, si il à assez de carburant dans le jetpack
        else if ((PlayerID == 1 && !isGrounded && Input.GetKey(KeyCode.LeftAlt) && currentJetpackFuel > 0f) || (PlayerID == 2 && !isGrounded && Input.GetKey(KeyCode.RightAlt) && currentJetpackFuel > 0f))
        {
            rb.AddForce(Vector3.up * jetpackForce * Time.deltaTime, ForceMode.Impulse);
            currentJetpackFuel -= jetpackFuelConsumptionRate * Time.deltaTime;
            isUsingJetpack = true;
            isFlying = true;
        }
        else if ((PlayerID == 1 && isUsingJetpack && (!Input.GetKey(KeyCode.LeftAlt) || currentJetpackFuel <= 0f) || (PlayerID == 2 && isUsingJetpack && (!Input.GetKey(KeyCode.RightAlt) || currentJetpackFuel <= 0f))))
        {
            isUsingJetpack = false;
            isFlying = true;
        }

        // Si le jestpack n'est pas utilisé, se dernier se régenère
        if ((PlayerID == 1 && !isUsingJetpack && currentJetpackFuel < maxJetpackFuel) || (PlayerID == 2 && !isUsingJetpack && currentJetpackFuel < maxJetpackFuel))
        {
            currentJetpackFuel += jetpackFuelRegenRate * Time.deltaTime;
        }

        // Clamp jetpack fuel
        currentJetpackFuel = Mathf.Clamp(currentJetpackFuel, 0f, maxJetpackFuel);

    }

    //Bloque la posistion du joueur
    public void PlayerFreezePos()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;

    }
    //Débloque la posistion du joueur et bloque la rotation
    public void PlayerUnFreezePos()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}

