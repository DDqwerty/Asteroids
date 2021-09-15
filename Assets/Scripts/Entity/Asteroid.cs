using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Collidable
{
    public List<Sprite> sprites;
    private Movement move = new Movement();
    public bool big = true;
    public float speed = 5f;
    public int scorepoints = 50;
    Vector3 randomVector;

    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
        randomVector = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
    }

    private void FixedUpdate()
    {
        move.Move(randomVector*speed, transform);
    }



    private void OnDestroy()
    {
        if (big & !GameManager.instance.gameOver)
        {
            GameManager.instance.AsteroidDivision(transform.position);
            GameManager.instance.AsteroidDivision(transform.position);
        }
        GameManager.instance.scorepoints += scorepoints;
    }
}
