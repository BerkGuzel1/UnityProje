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
            Destroy(other.gameObject); // Düþmaný yok et
            Destroy(gameObject);       // Ateþ topunu yok et
        }
        else if (!other.CompareTag("Player"))
        {
            Destroy(gameObject); // Baþka bir þeye çarparsa yine yok et
        }
    }
}
