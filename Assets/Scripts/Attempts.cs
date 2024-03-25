using UnityEngine;
using UnityEngine.UI;

public class Attempts : MonoBehaviour
{
    public int maxAttempts = 3;
    private int attemptsLeft;
    public Text attemptsText;
    public StartPosition restart;

    void Start()
    {
        attemptsLeft = maxAttempts;
        UpdateAttemptsText();
    }

    private void Update()
    {
        GameLose();
    }

    void UpdateAttemptsText()
    {
        attemptsText.text = "Попыток осталось: " + attemptsLeft.ToString();
    }

    public void DecreaseAttempts()
    {
        attemptsLeft--;
        UpdateAttemptsText();
    }

    public void GameLose()
    {
        if (attemptsLeft == 0)
        {
            attemptsLeft = maxAttempts;
            restart.Restart();
        }
    }


}