using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;

    public float playerSpeed = 1.0f;
    public float turnSpeed = 1.0f;

    private Rigidbody2D rigidbody;
    private bool thrusting;
    private float turnDirection;

    private void Awake() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
    } 

    private void Update()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            turnDirection = 1.0f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            turnDirection = -1.0f;
        } else {
            turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private void FixedUpdate() 
    {
        if (thrusting) {
            rigidbody.AddForce(this.transform.up * this.playerSpeed);
        }

        if (turnDirection != 0.0f) {
            rigidbody.AddTorque(turnDirection * this.turnSpeed);
        }
    }

    /*  
        Instantiates a bullet at player's position and rotation and 
        then it projects the bullet where player is facing.
    */
    private void Shoot() 
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }
}
