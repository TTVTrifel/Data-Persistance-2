using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.Analytics.IAnalytic;

public class SaveThing : MonoBehaviour
{
    public static SaveThing Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        if (File.Exists(Application.persistentDataPath + "/saveFile.json") == false)
        {
            StartSaveFile();
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    
    private void StartSaveFile()
    {
        SaveData data = new SaveData();
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void SaveName(string name)
    {
        

        SaveData data = new SaveData();
        string json = File.ReadAllText(Application.persistentDataPath + "/saveFile.json");
        data = JsonUtility.FromJson<SaveData>(json);

        data.Name = name;
        UpdateSaveData(data);

        json = File.ReadAllText(Application.persistentDataPath + "/saveFile.json");
        data = JsonUtility.FromJson<SaveData>(json);
        Debug.Log(data.Name);

    }
    public void SaveScore(int score)
    {


        SaveData data = new SaveData();
        string json = File.ReadAllText(Application.persistentDataPath + "/saveFile.json");
        data = JsonUtility.FromJson<SaveData>(json);

        data.bestScore = score;
        UpdateSaveData(data);

        json = File.ReadAllText(Application.persistentDataPath + "/saveFile.json");
        data = JsonUtility.FromJson<SaveData>(json);
        Debug.Log(data.bestScore);

    }



    public string GetName()
    {

        string json = File.ReadAllText(Application.persistentDataPath + "/saveFile.json");
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        Debug.LogWarning(data.Name);
        return data.Name;
    }

    public int GetBestScore()
    {
        
        string json = File.ReadAllText(Application.persistentDataPath + "/saveFile.json");
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        int score = (int)data.bestScore;
        
        Debug.LogWarning(score);
        return score;
    }
    private void UpdateSaveData(SaveData data)
    {

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    [System.Serializable]
    public class SaveData
    {
        public string Name;
        public int bestScore;

    }



}
