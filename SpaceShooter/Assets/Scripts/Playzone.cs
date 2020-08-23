using UnityEngine;

public class Playzone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.position = transform.position;
    }
}
