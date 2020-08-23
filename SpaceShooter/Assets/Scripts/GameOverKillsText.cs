using UnityEngine;
using UnityEngine.UI;

public class GameOverKillsText : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Kills: " + GameController.GameControllerInstance.GetKills();
    }
}
