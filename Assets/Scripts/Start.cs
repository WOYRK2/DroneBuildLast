using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectAbout;
    public void OnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowAboutGame()
    {
        _gameObjectAbout.SetActive(true);
    }

    public void UnShowAboutGame()
    {
        _gameObjectAbout.SetActive(false);
    }
}
