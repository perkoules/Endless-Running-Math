using UnityEngine;

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
