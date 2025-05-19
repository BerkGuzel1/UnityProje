using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;

    public int maxHealth = 3;
    public int currentHealth;
    public Image[] hearts;


    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartsUI();
    }

    void Update()
    {
        scoreText.text = "Coins: " + score;
    }

    public static void AddCoin()
    {
        score++;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHeartsUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = (i < currentHealth);
        }
    }

    void Die()
    {
        SceneManager.LoadScene(0);
    }
}
