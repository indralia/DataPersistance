using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    // Start is called before the first frame update
    public string playerName;
    public string highScoreHolder;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            // im not the original, destroy !
            Debug.Log("Destroying copy");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        // charger les données ici
        LoadHighScore();
    }
    public void HandleScore(int score)
    {
        if (score > highScore)
        {
            // new high score
            highScore = score;
            SaveHighScore();
        }
    }
    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "infos.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "infos.json";
        if (File.Exists(path))
        {
            // we got a saved score, let's load it !
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            highScoreHolder = data.playerName;
        }
    }
    // Update is called once per frame

}
