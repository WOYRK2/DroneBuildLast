using Unity.Mathematics;
using UnityEngine;

public class SpawnKillBoomTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectBoomPrefab;
    [SerializeField] private GameObject _gameObjectWarningPanel;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("plr"))
        {
            Vector2 pos = (Vector2)collision.transform.position;

            _gameObjectWarningPanel.SetActive(false);

            Instantiate(
                _gameObjectBoomPrefab,
                pos,
                quaternion.identity
            );
        }
    }
}
