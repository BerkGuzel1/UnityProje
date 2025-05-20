using UnityEngine;

public class Fire : MonoBehaviour
{
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime); // 3 saniye sonra kendini yok et
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // D��man� yok et
            Destroy(gameObject);       // Ate� topunu yok et
        }
        else if (!other.CompareTag("Player"))
        {
            Destroy(gameObject); // Ba�ka bir �eye �arparsa yine yok et
        }
    }
}
