using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    void Update()
    {
        AchievementService achServ = FindObjectOfType<AchievementService>();
        if (achServ) 
        {
            achServ.UnlockAchievement();
        }
        else 
        {
            Debug.Log("achievement sevice NOT found"); 
        }
    }
}
