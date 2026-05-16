using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    private int score = 0;

    public void AddScore()
    {
        score++;

        scoreText.SetText("Score: " + score);
    }
}
