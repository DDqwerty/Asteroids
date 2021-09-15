using UnityEngine;

public class Bullet : Collidable
{
    private float lifetime = 3f;
    private ProjectileMovement shot = new ProjectileMovement();

    private void FixedUpdate()
    {
        shot.Shot(transform);

        Destroy(gameObject, lifetime);
    }

    protected override void OnCollide(Collider2D coll)
    {
        Destroy(coll.gameObject);
        Destroy(gameObject);
    }

    protected override void ScreenPos()
    {
        
    }
}
