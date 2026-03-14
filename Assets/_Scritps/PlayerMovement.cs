using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Shoot Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float deleteDelay = 2f;

    protected Rigidbody2D rb;
    protected Vector2 moveInput;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.linearVelocity = firePoint.right * bulletSpeed;

            // Attach a BulletCollision script dynamically so bullets know how to behave
            BulletCollision bulletLogic = bullet.AddComponent<BulletCollision>();
            bulletLogic.deleteDelay = deleteDelay;

            Destroy(bullet, deleteDelay);
        }
    }

    public virtual void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    protected virtual void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // Player collision logic
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Fire"))
        {
            Destroy(gameObject);
        }
    }

    public class BulletCollision : MonoBehaviour
    {
        public float deleteDelay = 2f;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
        }
    }
}
