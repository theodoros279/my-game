using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public ShieldPowerUp shieldPrefab;
    public ExtraLife extraLifePrefab; 
    public FastPowerUp fastPrefab;    
    public LoseLife loseLifePrefab;
    public float spawnDistance = 15.0f;
    public float trajectoryVariance = 3.0f; 

    void Start()
    {
        InvokeRepeating(nameof(SpawnShield), 19.0f, 19.0f);    
        InvokeRepeating(nameof(SpawnExtraLife), 25.0f, 25.0f); 
        InvokeRepeating(nameof(SpawnFast), 31.0f, 31.0f); 
        InvokeRepeating(nameof(SpawnPowerDown), 27.0f, 27.0f);            
    } 

    private void SpawnShield()  
    {
        Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
        Vector3 spawnPoint = this.transform.position + spawnDirection; 

        float variance = Random.Range(-this.trajectoryVariance, -this.trajectoryVariance);
        Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward); 

        ShieldPowerUp shield = Instantiate(this.shieldPrefab, spawnPoint, rotation);
        shield.SetTrojectory(rotation * -spawnDirection);          
    }

    private void SpawnExtraLife()
    { 
        Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
        Vector3 spawnPoint = this.transform.position + spawnDirection; 

        float variance = Random.Range(-this.trajectoryVariance, -this.trajectoryVariance);
        Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward); 

        ExtraLife life = Instantiate(this.extraLifePrefab, spawnPoint, rotation);
        life.SetTrojectory(rotation * -spawnDirection); 
    }

    private void SpawnFast()
    { 
        Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
        Vector3 spawnPoint = this.transform.position + spawnDirection; 

        float variance = Random.Range(-this.trajectoryVariance, -this.trajectoryVariance);
        Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward); 

        FastPowerUp fast = Instantiate(this.fastPrefab, spawnPoint, rotation);
        fast.SetTrojectory(rotation * -spawnDirection);  
    }

    private void SpawnPowerDown() 
    {
        Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
        Vector3 spawnPoint = this.transform.position + spawnDirection; 

        float variance = Random.Range(-this.trajectoryVariance, -this.trajectoryVariance);
        Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward); 

        LoseLife loseLife = Instantiate(this.loseLifePrefab, spawnPoint, rotation);
        loseLife.SetTrojectory(rotation * -spawnDirection);
    }
}
