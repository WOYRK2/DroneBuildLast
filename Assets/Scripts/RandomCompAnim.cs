using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class RandomCompAnim : MonoBehaviour
{   
    [Header("Prefabs")]
    [SerializeField] private GameObject _gameObjectDeathTriger; // Prefab
    [SerializeField] private GameObject _gameObjectDroneBattaryTriger;
    [SerializeField] private GameObject _gameObjectCorpsBatteryTriger;

    [Header("Another")]
    [SerializeField] private float _delayOnDestroyDT;
    private AudioSource _audioSourceBoom;

    void Awake()
    {
        _audioSourceBoom = GetComponent<AudioSource>();
    }
    public void StartRandom()
    {
        int Random = 0;
        Random = UnityEngine.Random.Range(0, 100);

        if (Random <= 50)
        {
            Instantiate(
                _gameObjectCorpsBatteryTriger,
                transform.position,
                Quaternion.identity
            );
        }

        if (Random >= 50)
        {
            Instantiate(
                _gameObjectDroneBattaryTriger,
                transform.position,
                Quaternion.identity
            );
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void PlaySoundAndSpawnDeathTrigger()
    {
        GameObject DTClone = Instantiate(
            _gameObjectDeathTriger,
            transform.position,
            Quaternion.identity
        );

        Destroy(DTClone, _delayOnDestroyDT);
        _audioSourceBoom.Play();
    }
}
