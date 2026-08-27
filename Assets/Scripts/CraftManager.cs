using UnityEngine;

public class CraftManager : MonoBehaviour
{
    [SerializeField] GameObject _gameObjectCraftPanel;
    [Header("FPV drone craft part")]
    [SerializeField] private bool _EnbledCraftFPVDrone = true;
    [SerializeField] private int _MinBatt = 1;
    [SerializeField] private int _MinCorps = 1;
    [SerializeField] private int _MinEXPL = 1;
    [SerializeField] private int _PlusFPVDrone = 1;
    [SerializeField] private int _NeedFPVDroneToUpLvl = 5;
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

    public void TryCraftFPVDRONE()
    {
        if (_gameManager.fPV_drone_battery >= _MinBatt &&
        _gameManager.Corps >= _MinCorps &&
        _gameManager.explosive >= _MinEXPL)
        {
            _gameManager.MINBATT(_MinBatt);
            _gameManager.MINCORPS(_MinCorps);
            _gameManager.MINEXPL(_MinEXPL);
            _gameManager.ADDFPVDRONE(_PlusFPVDrone);
            _audioSourceCraft.Play();
        }

        if (_gameManager.Fpv_dronePLR >= _NeedFPVDroneToUpLvl && _EnbledCraftFPVDrone)
        {
            _gameManager.RESETALLDATA();
            _gameManager.LOADNEXTLVL();
        }
    }
}
