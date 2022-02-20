using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public Player player;
    public float duration = 4.0f; 

    void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.gameObject.tag == "Player") {
            StartCoroutine (Pickup()); 
        } 
    }

    IEnumerator Pickup() 
    {
        // Set to ignore asteroids layer
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Asteroids");

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false; 

        // Duration of power up
        yield return new WaitForSeconds(duration);

        // Change back to player layer 
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");  
        Destroy(this.gameObject); 
    }
}
