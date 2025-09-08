using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Start and Update methods are deleted as they are not used
    public static DataManager Instance;
    public string PlayerName = "";
    public int BestScore = 0;
    public string BestPlayer = "";


    private void Awake()
    {
        // if there has already an instance of MainManager, destroy this one
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNameandScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int bestScore;
    }

    public void SaveNameandScore()
    {
        SaveData data = new SaveData();
        data.bestPlayer = BestPlayer;
        data.bestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameandScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestPlayer = data.bestPlayer;
            BestScore = data.bestScore;
        }
    }
    // Call this when the current run ends
    public void TrySetNewBestScore(int score)
    {
        if (score > BestScore)
        {
            BestScore = score;
            BestPlayer = PlayerName;
            SaveNameandScore();
        }
    }
}
