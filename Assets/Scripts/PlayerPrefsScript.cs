using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsScript : MonoBehaviour
{
    public void ScoreHolder(float score)
    {
        PlayerPrefs.SetFloat("Score", score);
    }

    public float GetStoredScore()
    {
        return PlayerPrefs.GetFloat("Score");
    }
    

}
