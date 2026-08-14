using UnityEngine;

public class OnExit : MonoBehaviour
{
    [Header("Ui panel")]
    [SerializeField] private GameObject _ShopPanel;
    [SerializeField] private GameObject _PlrValuePanel;
    public void OnExitShop()
    {
        _ShopPanel.SetActive(false);
        _PlrValuePanel.SetActive(true);
    }
}
