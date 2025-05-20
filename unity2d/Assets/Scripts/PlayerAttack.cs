using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject fireballPrefab; // Inspector’dan vereceðiz
    public Transform firePoint;       // Ateþin çýkýþ noktasý
    public float fireSpeed = 10f;
    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("attack"); // Attack animasyonu
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        float direction = transform.rotation.y == 0 ? 1 : -1;
        rb.velocity = new Vector2(fireSpeed * direction, 0f);
    }
}
