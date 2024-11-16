using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class SC_FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    AudioSource audioSource;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    public AudioClip walkingSound; // Walking sound effect
    public AudioClip runningSound; // Running sound effect
    private bool isPlayingWalkingSound = false; // Tracks which sound is currently playing
    private bool wasGrounded = true; // Tracks if the player was grounded in the previous frame

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        // Set up the audio source
        audioSource.loop = true; // Loop the sound
        audioSource.playOnAwake = false; // Don't play on start

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Calculate move direction based on input
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y; // Preserve vertical movement
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed; // Jump when on the ground
        }
        else
        {
            moveDirection.y = movementDirectionY; // Retain current vertical velocity
        }

        // Apply gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Check if the player just landed
        if (characterController.isGrounded && !wasGrounded)
        {
            wasGrounded = true;
            RestartSound(isRunning); // Restart sound if the player lands while moving
        }
        else if (!characterController.isGrounded)
        {
            wasGrounded = false;
        }

        // Play appropriate sound based on movement and running state
        if (canMove && characterController.isGrounded && (moveDirection.x != 0 || moveDirection.z != 0))
        {
            if (isRunning && audioSource.clip != runningSound)
            {
                audioSource.clip = runningSound;
                audioSource.Play();
                isPlayingWalkingSound = false;
            }
            else if (!isRunning && !isPlayingWalkingSound)
            {
                audioSource.clip = walkingSound;
                audioSource.Play();
                isPlayingWalkingSound = true;
            }
        }
        else if (characterController.isGrounded)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        // Player and camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    // Helper function to restart the appropriate sound after landing
    private void RestartSound(bool isRunning)
    {
        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            audioSource.clip = isRunning ? runningSound : walkingSound;
            audioSource.Play();
        }
    }
}
