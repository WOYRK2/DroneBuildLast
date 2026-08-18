using UnityEngine;

public class CraftManager2 : MonoBehaviour
{
    [SerializeField] GameObject _gameObjectCraftPanel;
    private AudioSource _audioSourceCraft;
    private GameManager2 _gameManager;

    void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager2>();
        _audioSourceCraft = GetComponent<AudioSource>();
    }

    public void onExitCraft()
    {
        _gameObjectCraftPanel.SetActive(false);
    }

    public void TryCraft()
    {
        if (_gameManager.fPV_drone_battery >= 3 &&
        _gameManager.Corps >= 2 &&
        _gameManager.explosive >= 3)
        {
            _gameManager.MINBATT(1);
            _gameManager.MINCORPS(1);
            _gameManager.MINEXPL(3);
            _gameManager.ADDFPVDRONE(2);
            _audioSourceCraft.Play();
        }

        if (_gameManager.Fpv_dronePLR >= 6)
        {
            _gameManager.RESETALLDATA();
            _gameManager.LOADNEXTLVL();
        }
    }
}
