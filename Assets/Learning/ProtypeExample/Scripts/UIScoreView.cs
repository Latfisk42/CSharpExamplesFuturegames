using UnityEngine;
using TMPro;
public class UIScoreView : UIView
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;

    private int highScore;
    private int score;
    public override void Initialize() {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        AddScore(50); // Initial score for testing
    }

    public void AddScore(int s) {

        score += s;
        scoreText.text = score.ToString();

        if(score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = highScore.ToString();
        }
    }
}
