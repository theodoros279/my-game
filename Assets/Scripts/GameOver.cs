using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText; 

    void Start() 
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();   
    } 

    public void PlayAgain() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
    } 

    public void BackToMenu() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);  
    } 
}
