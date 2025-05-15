using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Coins: " + score;
    }

    public static void AddCoin()
    {
        score++;
    }
}
