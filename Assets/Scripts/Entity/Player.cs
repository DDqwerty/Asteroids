using UnityEngine;

public class Player : Collidable
{
    public PlayerMovement movement = new PlayerMovement();
    public Bullet bullet_prefab;
    public Laser laser_prefab;
    public float laser_cd = 5f;
    public int laser_count = 3;
    public int laser_max_count = 3;

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement.Accelerate(y, transform);
        movement.Rotation(x, transform);
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))
        {
            Laser();
        }

        laser_cd -= Time.deltaTime;
        GameManager.instance.LaserCD(laser_cd/5f);

        if (laser_cd<=0 & laser_count<laser_max_count)
        {
            laser_count++;
            laser_cd = 5f;
            GameManager.instance.LaserCount(laser_count,laser_max_count);
        }
        GameManager.instance.Coords(transform.position);
        GameManager.instance.Rotation(transform.rotation.eulerAngles.z);

    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bullet_prefab, transform.position + transform.up * 0.5f, transform.rotation);
    }

    private void Laser()
    {
        if (laser_count <= 0)
            return;
        Laser laser = Instantiate(laser_prefab, transform.position + transform.up * 0.35f, transform.rotation, transform);
        laser_count--;
        GameManager.instance.LaserCount(laser_count, laser_max_count);
    }

    protected override void OnCollide(Collider2D coll)
    {
        GameManager.instance.GameOver();
        gameObject.active = false;
    }
}
