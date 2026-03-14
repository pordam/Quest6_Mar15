using UnityEngine;
using UnityEngine.InputSystem;

public class _PlayerGrass : PlayerMovement
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

        if (collision.gameObject.CompareTag("Fire"))
        {
            Destroy(gameObject); 
        }
    }
}
