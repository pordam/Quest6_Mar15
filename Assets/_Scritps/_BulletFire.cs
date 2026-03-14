using UnityEngine;

public class _BulletFire : BulletBase
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Grass"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            base.OnCollisionEnter2D(collision);
        }
    }
}
