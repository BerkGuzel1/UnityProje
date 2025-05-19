using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;
    public Animator animator;

    float speedAmount = 5f;
    float jumpAmount = 6f;


    void Start()
    {
     rgb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.linearVelocity.y,0))
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
           animator.SetBool("isJumping", true);
        }

        if(animator.GetBool("isJumping") && Mathf.Approximately(rgb.linearVelocity.y, 0))
        {
            animator.SetBool("isJumping", false);

        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        }
        else if(Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().TakeDamage(1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().TakeDamage(1);
        }
    }

}
