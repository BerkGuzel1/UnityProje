using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.AddCoin(); // Update score
            Destroy(gameObject);  // Remove the coin
        }
    }
}
