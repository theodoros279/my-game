using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    
    public float duration = 4.0f; 
    private Rigidbody2D rigidbody;
    public float speed = 3.0f; 
    public float maxLifetime = 30.0f; 

    void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.gameObject.tag == "Player") {
            StartCoroutine (Pickup());  
        } 
    }

    private void Awake() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
    } 
 
    IEnumerator Pickup() 
    {
        // Set to ignore asteroids layer
        GameObject player = GameObject.FindWithTag("Player"); 
        player.gameObject.layer = LayerMask.NameToLayer("Ignore Asteroids"); 

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false; 

        // Duration of power up
        yield return new WaitForSeconds(duration);

        // Change back to player layer 
        player.gameObject.layer = LayerMask.NameToLayer("Player");  
        Destroy(this.gameObject);  
    }

    public void SetTrojectory(Vector2 direction) 
    {
        rigidbody.AddForce(direction * speed); 
        Destroy(this.gameObject, maxLifetime);
    }  
}