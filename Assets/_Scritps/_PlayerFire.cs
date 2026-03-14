using UnityEngine;
using UnityEngine.InputSystem;

public class _PlayerFire : PlayerMovement
{
    private Vector2 lastDirection = Vector2.right; // default facing right

    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnMove(InputValue value)
    {
        base.OnMove(value);

        // Update lastDirection only if moving
        if (moveInput.sqrMagnitude > 0.01f)
        {
            lastDirection = moveInput.normalized;
        }
    }

    public override void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            // Use lastDirection instead of firePoint.right
            bulletRb.linearVelocity = lastDirection * bulletSpeed;

            // Optional: rotate bullet to face direction
            float angle = Mathf.Atan2(lastDirection.y, lastDirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Destroy(bullet, deleteDelay);
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if(collision.gameObject.CompareTag("Water"))
        {
            Destroy(gameObject); // destroys the player object this script is attached to
        }
    }
}
