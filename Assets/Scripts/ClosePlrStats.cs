using UnityEngine;
using UnityEngine.UI;

public class ClosePlrStats : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectPlrValuePanel;
    [SerializeField] private GameObject _gameObjectNeedToUpLvlPanel;
    [SerializeField] private Text _textCloaseTab;
    private bool _isClosed = false;

    public void CloseTab()
    {
        _gameObjectNeedToUpLvlPanel.SetActive(_isClosed);
        _gameObjectPlrValuePanel.SetActive(_isClosed);
        
        _isClosed = !_isClosed;

        if (_isClosed)
            _textCloaseTab.text = "<";
        if (!_isClosed)
            _textCloaseTab.text = ">";
    }
}
