using UnityEngine;
using UnityEngine.UI;

public class KillsText : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Kills: " + GameController.GameControllerInstance.GetKills();
    }
}
