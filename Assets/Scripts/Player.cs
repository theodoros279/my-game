using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IEntity
{
    public Bullet bulletPrefab;

    public float playerSpeed = 1.5f;  
    public float turnSpeed = 0.25f;  

    private Rigidbody2D rigidbody;
    private float turnDirection; 

    private CommandProcessor cmdProcessor;   

    private void Awake() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
        cmdProcessor = GetComponent<CommandProcessor>();  
    } 

    private void Update()
    {
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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) { 
            cmdProcessor.ExecuteCommand(new MoveCommand(this, transform.up, this.playerSpeed));        
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

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Asteroid") {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);  

            FindObjectOfType<GameManager>().PlayerDied();
        }
    }

}
