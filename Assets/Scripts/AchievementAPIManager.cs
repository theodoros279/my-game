using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementAPIManager : MonoBehaviour, IAchievement
{
    private int points = 1500; 
    public GameObject achPanel; 
    public Text achievementText; 
    private float duration = 2.0f;   

    public void UnlockAchievement()   
    {  
        GameManager gameManager = FindObjectOfType<GameManager>();
        int score = gameManager.GetScore();  

        for (int i = 0; i < 100; i++) {
            if (score >= points) {
                StartCoroutine(Pickup());  
                achievementText.text = "You scored " + points + " points!"; 
                points += 500;   
            } 
        }
    }

    IEnumerator Pickup() 
    {
        achPanel.SetActive(true); 

        yield return new WaitForSeconds(duration);  

        achPanel.SetActive(false);  
    }
}
