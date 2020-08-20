using UnityEngine;

public class GameController : MonoBehaviour
{

    private static GameController gameControllerInstance = null;
    public static GameController GameControllerInstance
    {
        get
        {
            if (gameControllerInstance == null)
            {
                gameControllerInstance = FindObjectOfType<GameController>();
            }
            return gameControllerInstance;
        }
    }

    public Transform playerTransform = null;

    private int killedEnemies = 0;

    private void Awake()
    {
        gameControllerInstance = this;
    }

    public void EnemyKilled()
    {
        killedEnemies += 1;
    }
}
