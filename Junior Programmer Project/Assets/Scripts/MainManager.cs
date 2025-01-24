using System;
using System.IO;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using Application = UnityEngine.Application;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Color TeamColor;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }


    [Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData savedData = new();
        savedData.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(savedData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData savedData = JsonUtility.FromJson<SaveData>(json);

            TeamColor = savedData.TeamColor;
            Debug.Log(savedData);
        }
    }
}
