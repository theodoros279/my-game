using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayAgain() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
    } 

    public void BackToMenu() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);  
    } 
}
