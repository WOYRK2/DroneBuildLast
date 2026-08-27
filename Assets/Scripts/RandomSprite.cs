using System;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    [SerializeField] private Sprite _spriteVar1;
    [SerializeField] private Sprite _spriteVar2;
    private SpriteRenderer _spriteRenderer;
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        int num = UnityEngine.Random.Range(0, 100);
        Debug.Log(num);

        if (num <= 49)
            _spriteRenderer.sprite = _spriteVar1;
        else if (num >= 50)
            _spriteRenderer.sprite = _spriteVar2;
    }
}
