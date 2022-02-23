using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastPowerUp : MonoBehaviour
{
    
    public float duration = 6.0f; 
    private Rigidbody2D rigidbody;
    public float speed = 3.0f; 
    public float maxLifetime = 30.0f; 
    // public Player player; 

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
        Player player = FindObjectOfType<Player>(); 
        player.playerSpeed += 1.0f;  

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false; 

        // Duration of power up
        yield return new WaitForSeconds(duration);  

        player.playerSpeed -= 1.0f;  
        Destroy(this.gameObject);   
    }

    public void SetTrojectory(Vector2 direction) 
    {
        rigidbody.AddForce(direction * speed); 
        Destroy(this.gameObject, maxLifetime);
    }  
}