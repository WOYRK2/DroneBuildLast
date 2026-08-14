using Unity.VisualScripting;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    private GameManager _gameManager;
    private Rigidbody2D _rigidbody2D;

    void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            _gameManager.IMDEATH();
        }
    }
    */

    void OnTriggerEnter2D(Collider2D other)
    {
        // Deaths
        if (other.gameObject.CompareTag("Death"))
        {
            _gameManager.IMDEATH();
        }
        
        // Coins
        if (other.gameObject.CompareTag("CoinBase"))
        {
            _gameManager.ADDCOIN(1);
        }

        if (other.gameObject.CompareTag("CoinRare"))
        {
            _gameManager.ADDCOIN(2);
        }

        if (other.gameObject.CompareTag("CoinEpic"))
        {
            _gameManager.ADDCOIN(5);
        }

        // FPV drone battery

        if (other.gameObject.CompareTag("DroneBatt"))
        {
            _gameManager.ADDBATT(1);
        }

        // Corps

        if (other.gameObject.CompareTag("Corps"))
        {
            _gameManager.ADDCORPS(1);
        }

        // EXPL

        if (other.gameObject.CompareTag("EXPL"))
        {
            _gameManager.ADDEXPL(1);
        }
    }
}