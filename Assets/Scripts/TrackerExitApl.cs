using UnityEngine;

public class TrackerExitApl : MonoBehaviour
{
    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("Coin");
        PlayerPrefs.DeleteKey("Batt");
        PlayerPrefs.DeleteKey("Corps");
        PlayerPrefs.DeleteKey("Expl");
        PlayerPrefs.DeleteKey("Fpv_drone");
        PlayerPrefs.Save();
    }
}
