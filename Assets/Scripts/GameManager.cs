using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Panels")]

    [SerializeField] private GameObject _gameObject_DeathPanel;
    [SerializeField] private GameObject _gameObject_PlrValuesPanel;

    [Header("Ui text")]

    [SerializeField] private Text _textCoins;
    [SerializeField] private Text _textFPVdroneBattery;
    [SerializeField] private Text _textCorps;
    [SerializeField] private Text _textExplosives;

    private PlayerMovent _playerMovent;
    private int coins = 0;
    private int FPV_drone_battery = 0;
    private int corps = 0;
    private int Explosives = 0;
    void Awake()
    {
        _playerMovent = FindAnyObjectByType<PlayerMovent>();

        coins = LOADCOINS();
        FPV_drone_battery = LOADBATT();
        corps = LOADCORPS();
        Explosives = LOADEXPL();

        _textCorps.text = "Corps: " + corps;
        _textFPVdroneBattery.text = "FPV drone battery: " + FPV_drone_battery;
        _textExplosives.text = "Explosives: " + Explosives;
        _textCoins.text = "Coins: " + coins;
    }

    // Scene defs
    public void IMDEATH()
    {
        _playerMovent.enabled = false;

        _gameObject_DeathPanel.SetActive(true);
        _gameObject_PlrValuesPanel.SetActive(false);

        SAVEALLDATAS();
    }

    public void RESTARTLVL()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LOADNEXTLVL()
    {
        Debug.Log("load new lvl");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Value plr defs
    // PLUS
    public void ADDCOIN(int howmuchtoplus)
    {
        coins += howmuchtoplus;
        _textCoins.text = "Coins: " + coins;
        SAVEALLDATAS();
    }

    public void ADDBATT(int howmuchtoplus)
    {
        FPV_drone_battery += howmuchtoplus;
        _textFPVdroneBattery.text = "FPV drone battery: " + FPV_drone_battery;
        SAVEALLDATAS();
    }

    public void ADDCORPS(int howmuchtoplus)
    {
        corps += howmuchtoplus;
        _textCorps.text = "Corps: " + corps;
        SAVEALLDATAS();
    }

    public void ADDEXPL(int howmuchtoplus)
    {
        Explosives += howmuchtoplus;
        _textExplosives.text = "Explosives: " + Explosives;
        SAVEALLDATAS();
    }
    
    // MINUS
    public void MINCOIN(int howmuchtominus)
    {
        coins -= howmuchtominus;
        _textCoins.text = "Coins: " + coins;
        SAVEALLDATAS();
    }

    public void MINBATT(int howmuchtominus)
    {
        FPV_drone_battery -= howmuchtominus;
        _textFPVdroneBattery.text = "FPV drone battery: " + FPV_drone_battery;
        SAVEALLDATAS();
    }

    public void MINCORPS(int howmuchtominus)
    {
        corps -= howmuchtominus;
        _textCorps.text = "Corps: " + corps;
        SAVEALLDATAS();
    }

    public void MINEXPL(int howmuchtominus)
    {
        Explosives -= howmuchtominus;
        _textExplosives.text = "Explosives: " + Explosives;
        SAVEALLDATAS();
    }

    // CHECK

    public bool CHECKCOINS(int valuetocheck)
    {
        return coins >= valuetocheck;
    }

    // Save/Load datas defs
    public void SAVEALLDATAS()
    {
        PlayerPrefs.SetInt("Coin", coins);
        PlayerPrefs.SetInt("Batt", FPV_drone_battery);
        PlayerPrefs.SetInt("Corps", corps);
        PlayerPrefs.SetInt("Expl", Explosives);
    }

    public int LOADCOINS()
    {
        return PlayerPrefs.GetInt("Coin");
    }

    public int LOADBATT()
    {
        return PlayerPrefs.GetInt("Batt");
    }

    public int LOADCORPS()
    {
        return PlayerPrefs.GetInt("Corps");
    }

    public int LOADEXPL()
    {
        return PlayerPrefs.GetInt("Expl");
    }
}
