using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    // public Text scoreText;
    public TextMeshProUGUI scoreText; 

    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}