using UnityEngine;

public class ProjectileMovement : Movement
{
    private float acceleration=10f;

    public void Shot(Transform transform)
    {
        Move(transform.up * acceleration, transform);
        acceleration *= 0.97f;
    }
}
