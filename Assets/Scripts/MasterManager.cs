using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MasterManager : MonoBehaviour
{
    public static MasterManager instance;
    public string playerName;
    public string bestScore;
    public int score;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string bestScore;
        public int score;
    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.bestScore = bestScore;
        data.score = score;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            bestScore = data.bestScore;
            score = data.score;
        }
    }
}
