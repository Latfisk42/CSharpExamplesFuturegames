using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIHealthView : UIView
{
    public TextMeshProUGUI livesText;
    public Image healthBar;
     static int lives = 3;

     public override void Initialize() {
         lives = PlayerPrefs.GetInt("Lives", 3);
         UpdatelivesUI(lives);
         //playerHealth.OnHealthChanged += UpdateHealthbar;
     }
    public void UpdatelivesUI(int newLives) {
        livesText.text = lives.ToString();
    }

    public void UpdateHealthbar(float healthPercent) {
        Debug.Log("Health Percent: " + healthPercent);
        healthBar.fillAmount = healthPercent;
    }

}
