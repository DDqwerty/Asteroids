using UnityEngine;

public class PlayerMovement: Movement
{
    public float acceleration = 0f;
    private float rotate_acc = 0f;
    private float rotate_speed=10.5f;
    private float last_rotate;

    public void Accelerate(float input, Transform transform)
    {
        acceleration += input * Time.deltaTime - Time.deltaTime*0.4f;
        if (acceleration > 1)
            acceleration = 1;
        if (acceleration < 0)
            acceleration = 0;

        float rotate = (transform.eulerAngles.z+45)*Mathf.Deg2Rad;
        // если нет ускорения, направление движения не меняется
        if (input < 1)
            rotate = last_rotate;
        else
            last_rotate = rotate;
        //Move(acceleration * transform.up, transform);
        Move(new Vector3(acceleration * (Mathf.Cos(rotate) - Mathf.Sin(rotate)), acceleration * (Mathf.Sin(rotate) + Mathf.Cos(rotate)), 0), transform);
        
        GameManager.instance.OnAccelerate();
    }

    public void Rotation(float input, Transform transform)
    {
        rotate_acc *= 0.95f;
        rotate_acc += input * Time.deltaTime;
        if (rotate_acc > 1)
            rotate_acc = 1;
        if (rotate_acc < -1)
            rotate_acc = -1;

        transform.Rotate(0, 0, -rotate_acc*rotate_speed);
    }
}
