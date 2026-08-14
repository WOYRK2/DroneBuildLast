using Unity.VisualScripting;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    [Header("Ui panel")]
    [SerializeField] private GameObject _ShopPanel;
    [SerializeField] private GameObject _PlrValuePanel;
    private GameManager _gameManager;
    private Rigidbody2D _rigidbody2D;

    void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Death":
                _gameManager.IMDEATH();
                break;

            case "CoinBase":
                _gameManager.ADDCOIN(1);
                break;

            case "CoinRare":
                _gameManager.ADDCOIN(2);
                break;

            case "CoinEpic":
                _gameManager.ADDCOIN(5);
                break;

            case "DroneBatt":
                _gameManager.ADDBATT(1);
                break;

            case "Corps":
                _gameManager.ADDCORPS(1);
                break;

            case "EXPL":
                _gameManager.ADDEXPL(1);
                break;
            case "Shop":
                _PlrValuePanel.SetActive(false);
                _ShopPanel.SetActive(true);

                break;
        }
    }
}