using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    [Header("Panels")]

    [SerializeField] private GameObject _gameObject_DeathPanel;
    [SerializeField] private GameObject _gameObject_PlrValuesPanel;
    [SerializeField] private GameObject _gameObject_NeededToUpLvl;

    [Header("Ui text")]

    [SerializeField] private Text _textCoins;
    [SerializeField] private Text _textFPVdroneBattery;
    [SerializeField] private Text _textCorps;
    [SerializeField] private Text _textExplosives;
    [SerializeField] private Text _textNeedToUpLvl;

    private PlayerMovent _playerMovent;
    private int coins = 0;
    private int FPV_drone_battery = 0;
    private int corps = 0;
    private int Explosives = 0;
    private int fpv_dronePLR = 0;

    public int Coins
    {
        get
        {
            return coins;
        }
        private set{}
    }

    public int fPV_drone_battery
    {
        get
        {
            return FPV_drone_battery;
        }
        private set{}
    }

    public int Corps
    {
        get
        {
            return corps;
        }
        private set{}
    }

    public int explosive
    {
        get
        {
            return Explosives;
        }
        private set{}
    }
    public int Fpv_dronePLR
    {
        get
        {
            return fpv_dronePLR;
        }
        private set{}
    }
    void Awake()
    {
        _playerMovent = FindAnyObjectByType<PlayerMovent>();

        coins = LOADCOINS();
        FPV_drone_battery = LOADBATT();
        corps = LOADCORPS();
        Explosives = LOADEXPL();
        fpv_dronePLR = LOADFPVDRONE();

        _textCorps.text = "Corps: " + corps;
        _textFPVdroneBattery.text = "FPV drone battery: " + FPV_drone_battery;
        _textExplosives.text = "Explosives: " + Explosives;
        _textCoins.text = "Coins: " + coins;
        _textNeedToUpLvl.text = "NEED " + fpv_dronePLR + "/6 FPV DRONE";
    }

    // Scene defs
    public void IMDEATH()
    {
        _playerMovent.enabled = false;

        _gameObject_DeathPanel.SetActive(true);
        _gameObject_PlrValuesPanel.SetActive(false);
        _gameObject_NeededToUpLvl.SetActive(false);

        SAVEALLDATAS();
    }

    public void RESTARTLVL()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RESETALLDATA()
    {
        coins = 0;
        FPV_drone_battery = 0;
        corps = 0;
        Explosives = 0;
        fpv_dronePLR = 0;

        _textCoins.text = "Coins: 0";
        _textFPVdroneBattery.text = "FPV drone battery: 0";
        _textCorps.text = "Corps: 0";
        _textExplosives.text = "Explosives: 0";
        _textNeedToUpLvl.text = "NEED 0/6 FPV DRONE";

        PlayerPrefs.DeleteKey("Coin");
        PlayerPrefs.DeleteKey("Batt");
        PlayerPrefs.DeleteKey("Corps");
        PlayerPrefs.DeleteKey("Expl");
        PlayerPrefs.DeleteKey("Fpv_drone");
        PlayerPrefs.Save();
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
    public void ADDFPVDRONE(int howmuchtoplus)
    {
        fpv_dronePLR += howmuchtoplus;
        _textNeedToUpLvl.text = "NEED " + fpv_dronePLR + "/6 FPV DRONE";
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
        PlayerPrefs.SetInt("Fpv_drone", fpv_dronePLR);
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

    public int LOADFPVDRONE()
    {
        return PlayerPrefs.GetInt("Fpv_drone");
    }
}