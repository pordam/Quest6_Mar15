using UnityEngine;

public class _BulletGrass : BulletBase
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            base.OnCollisionEnter2D(collision);
        }
    }
}
