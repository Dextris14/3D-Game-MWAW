using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class SavingScript : MonoBehaviour
{
    string SavePath;
    SaveData Data;

    float SaveDelay = 5f;

    public Text SaveMessageBox;
    float SaveMessageTime = 3f;

    void Start()
    {
        SavePath = Application.persistentDataPath + "/" + gameObject.name + "MySave.dat";
        Debug.Log(SavePath);
    }

    void Update()
    {
        SaveMessageTime -= Time.deltaTime;
        SaveDelay -= Time.deltaTime;
        if(SaveMessageTime <= 0)
        {
            SaveMessageBox.text = " ";
        }
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    Save();
        //}
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Load();
            SaveMessageBox.text = "Game Loaded";
            SaveMessageTime = 3f;
            SaveDelay = 5f;
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
        Data = new SaveData(transform.position, GameObject.FindGameObjectWithTag("Giant").transform.position, GetComponent<HealthAndMana>().Health, GetComponent<HealthAndMana>().Mana);
        BF.Serialize(file, Data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(SavePath))
        {
            BinaryFormatter BF = new BinaryFormatter();
            FileStream file = File.Open(SavePath, FileMode.Open);
            Data = (SaveData)BF.Deserialize(file);
            file.Close();
            transform.position = Data.GetPlayerVector3();
            GameObject.FindGameObjectWithTag("Giant").transform.position = Data.GetEnemyVector3();
            GetComponent<HealthAndMana>().Health = Data.GetHealth();
            GetComponent<HealthAndMana>().Mana = Data.GetMana();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Checkpoint" && SaveDelay <= 0)
        {
            Save();
            SaveMessageBox.text = "Game Saved";
            SaveMessageTime = 3f;
            SaveDelay = 5f;
        }
    }
}

[System.Serializable]
public class SaveData
{
    public float x;
    public float y;
    public float z;

    public float a;
    public float b;
    public float c;

    public float h;
    public float m;

    public SaveData(Vector3 PlayerPosition, Vector3 EnemyPosition, float Health, float Mana)
    {
        x = PlayerPosition.x;
        y = PlayerPosition.y;
        z = PlayerPosition.z;

        a = EnemyPosition.x;
        b = EnemyPosition.y;
        c = EnemyPosition.z;

        h = Health;
        m = Mana;
    }
    public Vector3 GetPlayerVector3()
    {
        return new Vector3(x, y, z);
    }
    public Vector3 GetEnemyVector3()
    {
        return new Vector3(a, b, c);
    }
    public float GetHealth()
    {
        return h;
    }
    public float GetMana()
    {
        return m;
    }
}

