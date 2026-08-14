using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Ui panel")]
    [SerializeField] private GameObject _ShopPanel;
    [SerializeField] private GameObject _PlrValuePanel;
    private GameManager _gameManager;
    public enum Type
    {
        Batt,
        Corps,
        Expl
    };

    void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }

    public void OnExitShop()
    {
        _ShopPanel.SetActive(false);
        _PlrValuePanel.SetActive(true);
    }

    public void OnBuy(Type itemType)
    {
        switch (itemType)
        {
            
        }
    }
}
