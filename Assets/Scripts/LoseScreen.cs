using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    private TextMeshProUGUI txtScoreDisplay;
    private PlayerPrefsScript scoreHolderScript;
    void Start()
    {
        txtScoreDisplay = GetComponent<TextMeshProUGUI>();
        scoreHolderScript = FindObjectOfType<PlayerPrefsScript>();
        txtScoreDisplay.text = scoreHolderScript.GetStoredScore().ToString();
    }

}
