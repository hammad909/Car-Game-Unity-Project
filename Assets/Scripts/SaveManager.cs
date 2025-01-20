using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    // What we want to save
    public int currentCar;
    public int money;
    public bool[] carsUnlocked = new bool[6] { true, false, false, false, false, false };

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        currentCar = PlayerPrefs.GetInt("CurrentCar", 0);

        carsUnlocked = new bool[6];
        for (int i = 0; i < carsUnlocked.Length; i++)
        {
            carsUnlocked[i] = PlayerPrefs.GetInt($"CarUnlocked_{i}", i == 0 ? 1 : 0) == 1;
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("CurrentCar", currentCar);
        for (int i = 0; i < carsUnlocked.Length; i++)
        {
            PlayerPrefs.SetInt($"CarUnlocked_{i}", carsUnlocked[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

}

[Serializable]
class PlayerData_Storage
{
    public int currentCar;
    public int money;
    public bool[] carsUnlocked;
}