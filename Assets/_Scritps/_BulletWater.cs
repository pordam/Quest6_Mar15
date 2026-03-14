using UnityEngine;

public class _BulletWater : BulletBase
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grass"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Fire"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            base.OnCollisionEnter2D(collision);
        }
    }
}
