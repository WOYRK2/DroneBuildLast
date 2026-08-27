using UnityEngine;

public class TriggerConec : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectPanelWarning;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("plr"))
            _gameObjectPanelWarning.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("plr"))
            _gameObjectPanelWarning.SetActive(false);
    }
}
