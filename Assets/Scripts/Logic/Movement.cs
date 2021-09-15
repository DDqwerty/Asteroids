using UnityEngine;

public class Movement 
{
    protected Vector3 moveDelta;
    protected float ySpeed = 0.015f;
    protected float xSpeed = 0.02f;
    protected float duration = 0.1f;

    public virtual void Move(Vector3 target, Transform transform)
    {
        if (target !=Vector3.zero)
            moveDelta += new Vector3(target.x*xSpeed, target.y * ySpeed, 0);

        moveDelta = Vector3.Lerp(moveDelta, Vector3.zero, duration);

        transform.position += moveDelta;
    }
}
