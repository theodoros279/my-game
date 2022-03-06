using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementService : MonoBehaviour
{
    private IAchievement achievementImplementation;
    
    private void Awake()
    {
        achievementImplementation = GetComponent<IAchievement>();
    }

    public void UnlockAchievement() 
    {
        achievementImplementation.UnlockAchievement();
    }
}
