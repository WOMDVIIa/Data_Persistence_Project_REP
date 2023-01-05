using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string nowPlaying;
    public string bestPlayer;
    public int bestScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int bestScore;
        public string lastPlayer;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.bestPlayer = bestPlayer;
        data.bestScore = bestScore;
        data.lastPlayer = nowPlaying;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.bestPlayer;
            bestScore = data.bestScore;
            nowPlaying = data.lastPlayer;
        }
    }

}
