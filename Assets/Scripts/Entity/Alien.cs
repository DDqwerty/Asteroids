using UnityEngine;

public class Alien : Collidable
{
    private Movement move = new Movement();
    Vector3 player_pos;
    public int scorepoints=100;

    private void FixedUpdate()
    {
        move.Move((GameManager.instance.player.transform.position - transform.position).normalized * 0.7f, transform);
    }

    private void OnDestroy()
    {
        GameManager.instance.spawner.aliens_count--;
        GameManager.instance.scorepoints += scorepoints;
    }
}
