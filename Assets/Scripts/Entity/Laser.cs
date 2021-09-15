using UnityEngine;

public class Laser : Collidable
{
    private float lifetime = 3f;

    private void FixedUpdate()
    {
        transform.localScale += new Vector3(0.03f,3,0);

        Destroy(gameObject, lifetime);
    }

    protected override void OnCollide(Collider2D coll)
    {
        Destroy(coll.gameObject);
    }

    protected override void ScreenPos()
    {

    }
}
