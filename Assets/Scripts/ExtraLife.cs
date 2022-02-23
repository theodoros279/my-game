using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    
    public float duration = 6.0f; 
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
        GameManager getManager = FindObjectOfType<GameManager>(); 
        getManager.lives += 1;   
        getManager.livesText.text = "Lives: " + getManager.lives.ToString();    

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;  

        // Duration of power up
        yield return new WaitForSeconds(duration);  

        Destroy(this.gameObject);  
    }

    public void SetTrojectory(Vector2 direction) 
    {
        rigidbody.AddForce(direction * speed); 
        Destroy(this.gameObject, maxLifetime);
    }  
}