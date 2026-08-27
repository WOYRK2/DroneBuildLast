using UnityEngine;
using System.Collections.Generic;

public class SpawnObjecttAwake : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _gameObjectBoomAnim;
    [SerializeField] private GameObject _gameObjectBaseCoin;
    [SerializeField] private GameObject _gameObjectRareCoin;
    [SerializeField] private GameObject _gameObjectEpicCoin;
    [Header("Ramdom Spawn and player")]
    [SerializeField] private float _minSpawn = 3f;
    [SerializeField] private float _maxSpawn = 6f;
    [SerializeField] private Transform _transformPlyaer;
    [Header("Await part")]
    [SerializeField] private int _MinRandomAwait = 0;
    [SerializeField] private int _MaxRandomAwat = 4;
    private SpriteRenderer _gameObjectArea;
    private List<int> NtDelay = new List<int>();
    private int RandomDelay = 0;
    private bool isPlayerOnColider = false;
    void Awake()
    {
        _gameObjectArea = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        // Реализовать рандом который будет решать спавнить щас или нет
        // Монета или дрон (На монету шанс будет больше)
        // И сделать рандом выбор местности

        Invoke("Random", 0.5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("plr"))
            isPlayerOnColider = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("plr"))
            isPlayerOnColider = false;
    }
    private void instancePrefab(GameObject gameObjectPrefab)
    {   
        Vector2 RandomPosition = new Vector2(1f, 2f);
        if (isPlayerOnColider){
            Vector2 RandomDir = UnityEngine.Random.insideUnitCircle.normalized;
            float RandomPosFromPlr = UnityEngine.Random.Range(_minSpawn, _maxSpawn);

            RandomPosition = (Vector2)_transformPlyaer.position + RandomDir * RandomPosFromPlr;

            Bounds boundsArena = _gameObjectArea.bounds;
            RandomPosition.x = Mathf.Clamp(RandomPosition.x, boundsArena.min.x, boundsArena.max.x);
            RandomPosition.y = Mathf.Clamp(RandomPosition.y, boundsArena.min.y, boundsArena.max.y);
        }
        else if (!isPlayerOnColider)
        {   
            Bounds _bounds = _gameObjectArea.bounds; 
            RandomPosition = new Vector2
            (UnityEngine.Random.Range(_bounds.min.x, _bounds.max.x),
            UnityEngine.Random.Range(_bounds.min.y, _bounds.max.y));
        }

        Instantiate(
            gameObjectPrefab,
            RandomPosition,
            Quaternion.identity
        );
    }
    private void GenRanNum()
    {
        bool IsWhile = false;

        while (!IsWhile)
        {
            RandomDelay = UnityEngine.Random.Range(_MinRandomAwait, _MaxRandomAwat);

            if (!NtDelay.Contains(RandomDelay))
            {
                IsWhile = true;
                NtDelay.Add(RandomDelay);
            }
        }

        if (NtDelay.Count >= 3)
        {
            NtDelay.RemoveAt(0);
            NtDelay.RemoveAt(0);
        }
    }
    private void Random()
    {
        Bounds _bounds = _gameObjectArea.bounds;
        Vector2 RandomPos = new Vector2(
        // Random X
        UnityEngine.Random.Range(_bounds.min.x, _bounds.max.x),
        // Random Y
        UnityEngine.Random.Range(_bounds.min.y, _bounds.max.y));

        int random = 0;
        random = UnityEngine.Random.Range(0, 100);

        Debug.Log("Random");
        if (random <= 20)
        {
            Debug.Log("Nothing to spawn");
        }

        if (random >= 21 && random <= 39)
        {
            Debug.Log("Base coin");

            instancePrefab(_gameObjectBaseCoin);
        }

        if (random >= 40 && random <= 54)
        {
            Debug.Log("Rare coin");

            instancePrefab(_gameObjectRareCoin);
        }

        if (random >= 55 && random <= 64)
        {
            Debug.Log("Epic coin");

            instancePrefab(_gameObjectEpicCoin);
        }

        if (random >= 65)
        {
            Debug.Log("Boom");

            instancePrefab(_gameObjectBoomAnim);
        }
        /* Сделать отдельную функции Check в которой будет проверятся
        есть ли число уже в массиве если есть то перезапускать рандом отдельной функцией\

        также если в массиве уже 5 чисел, то удалять первые две. Записывать первые два числа в отдельную переменную и потом уже удалять
        */
        GenRanNum();
        Invoke("Random", RandomDelay);
    }
}
