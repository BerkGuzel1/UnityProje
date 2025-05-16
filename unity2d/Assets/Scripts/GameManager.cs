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

    public GameObject gameOverPanel; 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartsUI();
        gameOverPanel.SetActive(false);  // Hide at start
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
        Time.timeScale = 0f; // Pause the game
        gameOverPanel.SetActive(true);
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
