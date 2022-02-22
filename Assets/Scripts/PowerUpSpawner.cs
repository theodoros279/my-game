using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public ShieldPowerUp shieldPrefab;
    public bool stopSpawning = false;
    private float spawnTime;
    private float spawnDelay;    
    public float spawnDistance = 15.0f;
    public float trajectoryVariance = 3.0f; 

    void Start()
    {
        spawnTime = Random.Range(10.0f, 30.0f); 
        InvokeRepeating(nameof(Spawn), spawnTime, spawnTime);  
    } 

    private void Spawn()  
    {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection; 

            float variance = Random.Range(-this.trajectoryVariance, -this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward); 

            ShieldPowerUp shield = Instantiate(this.shieldPrefab, spawnPoint, rotation);
            shield.SetTrojectory(rotation * -spawnDirection);     
    }
}
