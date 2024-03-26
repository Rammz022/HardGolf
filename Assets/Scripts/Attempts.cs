using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Attempts : MonoBehaviour
{
    public int maxAttempts = 3;
    private int attemptsLeft;
    public Text attemptsText;
    public StartPosition restart;
    public Rigidbody Rigidbody;

    void Start()
    {
        attemptsLeft = maxAttempts;
        UpdateAttemptsText();
    }

    private void Update()
    {
        UpdateAttemptsText();
    }

    void UpdateAttemptsText()
    {
        attemptsText.text = "Попыток осталось: " + attemptsLeft.ToString();
    }

    public void DecreaseAttempts()
    {
        attemptsLeft--;
        UpdateAttemptsText();
        GameLose();
    }

    private IEnumerator GameOver()
    {
        while(Rigidbody.velocity.magnitude > 0.01f)
        {
            yield return null;
        }
        Debug.Log("Пройгрыш");
        restart.Restart();

    }
    public void GameLose()
    {
        if (attemptsLeft == 0)
        {
            Debug.Log("Пройгрыш");
            attemptsLeft = maxAttempts;
            StartCoroutine(GameOver());
        }
    }


}