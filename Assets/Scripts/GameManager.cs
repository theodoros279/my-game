using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosion;

    public int lives = 3;
    public Text livesText;

    public float respawnTime = 3.0f;

    public int score = 0; 
    public Text scoreText; 

    private int targetScore = 2000; 

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 && Input.GetKeyDown(KeyCode.Return)) { 
            NewGame();
        }

        IncreaseDifficulty();  
    }

    // The amount of asteroids are increased every 2000 points scored
    private void IncreaseDifficulty()
    {
        AsteroidSpawner spawner = FindObjectOfType<AsteroidSpawner>();
        
        for (int i = 0; i < 100; i++) {
            if (score >= targetScore) { 
                spawner.IncreaseSpawnAmount();
                Debug.Log("asteroids amount increased");  
                targetScore += 2000;    
            } 
        } 
    }

    public void NewGame()
    {
        Asteroid[] asteroids = FindObjectsOfType<Asteroid>();

        for (int i = 0; i < asteroids.Length; i++) {
            Destroy(asteroids[i].gameObject);
        }

        SetScore(0);
        SetLives(3);
        Respawn();
    }

    public void AsteroidDestroyed(Asteroid asteroid) 
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        // increase score
        if (asteroid.size < 0.6f) { 
            SetScore(score + 100);
        } else if (asteroid.size < 0.8) {
            SetScore(score + 50);
        } else {
            SetScore(score + 25); 
        }
    }

    public void PlayerDied() 
    {
        // explosion effect when player dies
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        SetLives(lives - 1);

        Invoke(nameof(Respawn), this.respawnTime);
    }

    private void Respawn() 
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Asteroids"); 
        this.player.gameObject.SetActive(true); 
        this.player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);     
        Invoke(nameof(TurnOnCollisions), this.respawnTime);  
    }

    private void TurnOnCollisions() {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
        this.player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1); 
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = "Score: " + score.ToString(); 
        PlayerPrefs.SetInt("Score", score);  

        if (score > PlayerPrefs.GetInt("HighScore")) {
            PlayerPrefs.SetInt("HighScore", score);  
        }  
    }

    public int GetScore()
    {
        return this.score;
    }

    public void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = "Lives: " + lives.ToString(); 

        if (this.lives == 0) {
            GameOver(); 
        }
    }
}
