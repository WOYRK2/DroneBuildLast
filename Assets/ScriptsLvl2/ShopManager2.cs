using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.EventSystems;

public class ShopManager2 : MonoBehaviour
{
    [Header("Ui panel")]
    [SerializeField] private GameObject _ShopPanel;
    [SerializeField] private GameObject _PlrValuePanel;
    private AudioSource _audioSourceBuyAnyItems;
    private GameManager2 _gameManager;
    void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager2>();
        _audioSourceBuyAnyItems = GetComponent<AudioSource>();
    }

    private bool IsCanBuy(int cost)
    {
        if (_gameManager.Coins >= cost)
        {
            return true;
        }
        return false;
    }

    public void OnExitShop()
    {
        _ShopPanel.SetActive(false);
    }
    public void onBuyBatt(int howmuchtominus){
        if (IsCanBuy(howmuchtominus))
        {
            _gameManager.MINCOIN(howmuchtominus);
            _gameManager.ADDBATT(1);
            _audioSourceBuyAnyItems.Play();
        }
    }

    public void onBuyCorps(int howmuchtominus){
        if (IsCanBuy(howmuchtominus))
        {
            _gameManager.MINCOIN(howmuchtominus);
            _gameManager.ADDCORPS(1);
            _audioSourceBuyAnyItems.Play();
        }
    }

    public void onBuyEXPL(int howmuchtominus){
        if (IsCanBuy(howmuchtominus))
        {
            _gameManager.MINCOIN(howmuchtominus);
            _gameManager.ADDEXPL(1);
            _audioSourceBuyAnyItems.Play();
        }
    }
}
