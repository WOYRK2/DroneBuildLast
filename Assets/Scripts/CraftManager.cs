using UnityEngine;

public class CraftManager : MonoBehaviour
{
    [SerializeField] GameObject _gameObjectCraftPanel;
    private AudioSource _audioSourceCraft;
    private GameManager _gameManager;

    void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
        _audioSourceCraft = GetComponent<AudioSource>();
    }

    public void onExitCraft()
    {
        _gameObjectCraftPanel.SetActive(false);
    }

    public void TryCraft()
    {
        if (_gameManager.fPV_drone_battery >= 1 &&
        _gameManager.Corps >= 1 &&
        _gameManager.explosive >= 3)
        {
            _gameManager.MINBATT(1);
            _gameManager.MINCORPS(1);
            _gameManager.MINEXPL(3);
            _gameManager.ADDFPVDRONE(1);
            _audioSourceCraft.Play();
        }

        if (_gameManager.Fpv_dronePLR >= 10)
        {
            _gameManager.RESETALLDATA();
            _gameManager.LOADNEXTLVL();
        }
    }
}
