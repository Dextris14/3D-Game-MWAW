using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SavingScript : MonoBehaviour
{
    string SavePath;
    SaveData Data;

    void Start()
    {
        SavePath = Application.persistentDataPath + "/" + gameObject.name + "MySave.dat";
        Debug.Log(SavePath);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    Save();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    Load();
        //}
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
        Data = new SaveData(transform.position);
        BF.Serialize(file, Data);
        file.Close();
    }

    void Load()
    {
        if (File.Exists(SavePath))
        {
            BinaryFormatter BF = new BinaryFormatter();
            FileStream file = File.Open(SavePath, FileMode.Open);
            Data = (SaveData)BF.Deserialize(file);
            file.Close();
            transform.position = Data.GetVector3();
        }
    }
}

[System.Serializable]
public class SaveData
{
    public float x;
    public float y;
    public float z;

    public SaveData(Vector3 Position)
    {
        x = Position.x;
        y = Position.y;
        z = Position.z;
    }
    public Vector3 GetVector3()
    {
        return new Vector3(x, y, z);
    }
}

