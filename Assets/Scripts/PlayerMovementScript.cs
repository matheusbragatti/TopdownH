using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D playerRigidBody;
    public Vector2 movement;
    public Vector2 mousePosition;
    public Camera mainCamera;


    private void Start()
    {
        playerRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);


    }

    private void FixedUpdate()
    {
        playerRigidBody.MovePosition(playerRigidBody.position + movement * movementSpeed * Time.fixedDeltaTime);

        Vector2 lookDirection = mousePosition - playerRigidBody.position;
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        playerRigidBody.rotation = lookAngle;
    }

}
