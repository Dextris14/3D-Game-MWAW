using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SavingScript : MonoBehaviour
{
    string SavePath;
    SaveData Data;

    public Text SaveMessageBox;
    float SaveMessageTime = 3f;

    public bool[] Gems = new bool[4];

    void Start()
    {
        SavePath = Application.persistentDataPath + "/" + gameObject.name + "MySave.dat";
        Debug.Log(SavePath);
        Load();
    }

    void Update()
    {
        SaveMessageTime -= Time.deltaTime;
        if(SaveMessageTime <= 0)
        {
            SaveMessageBox.text = " ";
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.KeypadDivide))
        {
            Load();
        }
    }

    void Save()
    {
        BinaryFormatter BF = new BinaryFormatter();
        FileStream file;
        if (!File.Exists(SavePath))
        {
            file = File.Create(SavePath);
        }
        else
        {
            file = File.Open(SavePath, FileMode.Open);
        }
        Data = new SaveData(Gems);
        BF.Serialize(file, Data);
        file.Close();
        SaveMessageBox.text = "Game Saved";
        SaveMessageTime = 3f;
    }

    public void Load()
    {
        if (File.Exists(SavePath))
        {
            BinaryFormatter BF = new BinaryFormatter();
            FileStream file = File.Open(SavePath, FileMode.Open);
            Data = (SaveData)BF.Deserialize(file);
            file.Close();
            Gems = Data.GetGems();
            SaveMessageBox.text = "Game Loaded";
            SaveMessageTime = 3f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Gem")
        {
            if(other.name == "FireGem")
            {
                Gems[0] = true;
                Save();
                SceneManager.LoadScene("LevelSelect");
            }
            if (other.name == "LightningGem")
            {
                Gems[1] = true;
                Save();
                SceneManager.LoadScene("LevelSelect");
            }
            if (other.name == "IceGem")
            {
                Gems[2] = true;
                Save();
                SceneManager.LoadScene("LevelSelect");
            }
            if (other.name == "SlimeGem")
            {
                Gems[3] = true;
                Save();
                SceneManager.LoadScene("LevelSelect");
            }
        }
    }
}

[System.Serializable]
public class SaveData
{
    public bool[] G;

    public SaveData(bool []Gems)
    {
        G = Gems;
    }
    public bool[] GetGems()
    {
        return G;
    }
}

