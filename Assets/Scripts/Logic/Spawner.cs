using UnityEngine;

public class Spawner 
{
    public int asteroids_count=0;
    public int asteroids_max_count = 5;
    public int aliens_count = 0;
    public int aliens_max_count = 3;

    private float asteroids_spawn_cd = 3f;
    private float asteroids_last_spawn = 0f;
    private float aliens_spawn_cd = 5f;
    private float aliens_last_spawn = 0f;

    public void Spawn()
    {
        if (asteroids_count < asteroids_max_count & asteroids_last_spawn>asteroids_spawn_cd)
        {
            GameManager.instance.SpawnAsteroid();
            asteroids_last_spawn = 0f;
            asteroids_count++;
        }

        if (aliens_count < aliens_max_count & aliens_last_spawn > aliens_spawn_cd)
        {
            GameManager.instance.SpawnAlien();
            aliens_last_spawn = 0f;
            aliens_count++;
        }

        asteroids_last_spawn += Time.deltaTime;
        aliens_last_spawn += Time.deltaTime;
    }
}
