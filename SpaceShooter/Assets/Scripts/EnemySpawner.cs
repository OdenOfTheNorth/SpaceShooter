using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner enemySpawnerInstance = null;

    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private int enemiesPerWave = 15;
    [SerializeField] private int waveSizeIncrease = 10;

    private int enemiesAlive = 0;

    private void Awake()
    {
        enemySpawnerInstance = this;
    }

    private void Start()
    {
        SpawnWave();
    }

    public void EnemyDied()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0)
        {
            SpawnWave();
        }
    }

    private void SpawnWave()
    {
        float angle = 0.0f;
        float magnitude = 0.0f;

        for (int i = 0; i < enemiesPerWave; i++)
        {
            angle = Random.Range(0.0f, 2.0f * Mathf.PI);
            magnitude = Random.Range(15.0f, 20.0f);

            Instantiate(enemyPrefab,
                GameController.GameControllerInstance.playerTransform.position
                 + new Vector3(magnitude * Mathf.Cos(angle), magnitude * Mathf.Sin(angle)),
                Quaternion.identity);

            enemiesAlive++;
        }

        enemiesPerWave += waveSizeIncrease;
    }
}
