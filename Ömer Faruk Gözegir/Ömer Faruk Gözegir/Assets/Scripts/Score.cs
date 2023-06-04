using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int scoreAmount;
    public TextMeshProUGUI scoreText;

    private void Update() 
    {
        scoreText.text = (int)scoreAmount + " ";
    }

    public void ScorePlus()
    {
        scoreAmount += 1;
    }
}
