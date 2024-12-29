using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity<Player>
{
    private PlayerController playerController;
    private PlayerCamera playerCamera;

    private float xRotation;
    private float yRotation;
    public static class Cache_LayerMask
    {
        public static readonly LayerMask lmPLayer = 3;
    }
    protected override void Awake()
    {
        base.Awake();
        playerController = GetEntityComponent<PlayerController>();
        //playerCamera = GetComponent<PlayerCamera>();
        Game.ToggleCursor();
    }
    private void Update()
    {
        xRotation -= Input.GetAxisRaw("Mouse Y");
        yRotation += Input.GetAxisRaw("Mouse X");
        //playerCamera.SetCameraRotation(xRotation, yRotation);
    }
    private void FixedUpdate()
    {
        //Transform camTransform = playerCamera.GetCameraTransform;
        //Vector3 camForward = camTransform.forward;
        //camForward.y = 0;
        //camForward.Normalize();
        //Vector3 camRight = camTransform.right;
        //Vector3 inputVec = camForward * Input.GetAxis("Vertical") + camRight * Input.GetAxis("Horizontal");
        //
        //inputVec = inputVec.sqrMagnitude < 1 ? inputVec : inputVec.normalized;
        //playerController.Move(inputVec);

        void Jump()
        {
            //playerController.
        }
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }
}
