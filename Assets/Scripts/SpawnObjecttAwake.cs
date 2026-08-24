using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class SpawnObjecttAwake : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectBoomAnim;
    [SerializeField] private GameObject _gameObjectBaseCoin;
    [SerializeField] private GameObject _gameObjectRareCoin;
    [SerializeField] private GameObject _gameObjectEpicCoin;
    private SpriteRenderer _gameObjectArea;
    private List<int> NtDelay = new List<int>();
    private int RandomDelay = 0; 
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

    void Random()
    {
        Bounds _bounds = _gameObjectArea.bounds;
        Vector2 RandomPos = new Vector2(UnityEngine.Random.Range(_bounds.min.x, _bounds.max.x),
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

            Instantiate(
                _gameObjectBaseCoin,
                RandomPos,
                Quaternion.identity
            );
        }

        if (random >= 40 && random <= 54)
        {
            Debug.Log("Rare coin");

            Instantiate(
                _gameObjectRareCoin,
                RandomPos,
                Quaternion.identity
            );
        }

        if (random >= 55 && random <= 64)
        {
            Debug.Log("Epic coin");

            Instantiate(
                _gameObjectEpicCoin,
                RandomPos,
                Quaternion.identity
            );
        }

        if (random >= 65)
        {
            Debug.Log("Boom");

            Instantiate(
                _gameObjectBoomAnim,
                RandomPos,
                Quaternion.identity
            );
        }
        /* Сделать отдельную функции Check в которой будет проверятся
        есть ли число уже в массиве если есть то перезапускать рандом отдельной функцией\

        также если в массиве уже 5 чисел, то удалять первые две. Записывать первые два числа в отдельную переменную и потом уже удалять
        */
        GenRanNum();
        Invoke("Random", RandomDelay);
    }

    void GenRanNum()
    {
        bool IsWhile = false;

        while (!IsWhile)
        {
            RandomDelay = UnityEngine.Random.Range(0,4);

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
}
