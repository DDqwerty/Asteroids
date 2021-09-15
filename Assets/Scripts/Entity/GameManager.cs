using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject speedImage;
    public Player player;
    public Asteroid asteroid_prefab;
    public Alien alien_prefab;
    public GameObject HUD;
    public GameObject InfoPanel;

    public bool gameOver=false;
    public Vector2 bounds;
    public Spawner spawner = new Spawner();
    public int scorepoints = 0;


    private void Awake()
    {
        instance = this;
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 1));
    }

    private void Update()
    {
        spawner.Spawn();
        InfoPanel.transform.Find("Score").gameObject.GetComponent<Text>().text = "Score: "+scorepoints;
    }

    public void OnAccelerate()
    {
        speedImage.GetComponent<Image>().fillAmount = player.movement.acceleration;
    }

    public void SpawnAsteroid()
    {
        Vector3 random_position = new Vector3(Random.Range(-bounds.x, bounds.x), Random.Range(-bounds.y, bounds.y), 0);
        if ((random_position - player.transform.position).magnitude < 2f)
            random_position += Vector3.up;
        Asteroid asteroid = Instantiate(asteroid_prefab, random_position, transform.rotation);
    }

    public void AsteroidDivision(Vector3 position)
    {
        Asteroid asteroid = Instantiate(asteroid_prefab, position, transform.rotation);
        asteroid.big = false;
        asteroid.speed *= 2f;
        asteroid.transform.localScale *= 0.5f;
    }

    public void SpawnAlien()
    {
        Vector3 random_position = new Vector3(Random.Range(-bounds.x, bounds.x), new float[2]{ -bounds.y, bounds.y }[Random.Range(0,2)], 0);
        Alien alien = Instantiate(alien_prefab, random_position, transform.rotation);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    public void GameOver()
    {
        gameOver = true;
        HUD.transform.Find("GameOver").gameObject.GetComponent<Animator>().SetTrigger("show");
        spawner.aliens_count = spawner.aliens_max_count;
    }

    public void LaserCD(float fill)
    {
        InfoPanel.transform.Find("Laser_cd").gameObject.GetComponent<Image>().fillAmount=fill;
    }

    public void LaserCount(int count,int max_count)
    {
        InfoPanel.transform.Find("Laser_count").gameObject.GetComponent<Text>().text = count+"/"+max_count;
    }

    public void Coords(Vector3 position)
    {
        InfoPanel.transform.Find("Coords").gameObject.GetComponent<Text>().text = position.x.ToString("F0")+":"+position.y.ToString("F0");
    }

    public void Rotation(float degrees)
    {
        InfoPanel.transform.Find("Rotation").gameObject.GetComponent<Text>().text = degrees.ToString("F0");
    }
}
