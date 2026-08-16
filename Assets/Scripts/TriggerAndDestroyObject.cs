using UnityEngine;

public class TriggerAndDestroyObject : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("plr"))
            Destroy(gameObject);
    }
}
