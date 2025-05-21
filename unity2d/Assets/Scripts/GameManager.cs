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
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            score = 0;
        }
        currentHealth = maxHealth;
        UpdateHeartsUI();
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Animator anim = player.GetComponent<Animator>();
            anim.SetTrigger("death");
        }
        Invoke("RestartScene", 1.5f); 
    }

    void RestartScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
