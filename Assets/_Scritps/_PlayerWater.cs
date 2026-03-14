using UnityEngine;
using UnityEngine.InputSystem;

public class _PlayerWater : PlayerMovement
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnMove(InputValue value)
    {
        base.OnMove(value);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.gameObject.CompareTag("Grass"))
        {
            Destroy(gameObject); // destroys the player object this script is attached to
        }
    }
}
