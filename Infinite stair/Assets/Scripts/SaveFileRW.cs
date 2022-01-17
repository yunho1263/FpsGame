using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class UserData
{
    public int maxScore;
    public int CurCharIndex;
}

public class SaveFileRW : MonoBehaviour
{
    string fileName = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData), "InfiniteStair", "Data.sv");

    BinaryReader reader;
    BinaryWriter writer;

    public void ReadFile()
    {
        UserData userdata = GameManager.Instance.userdata;
        if (File.Exists(fileName))
        {
            reader = new BinaryReader(File.Open(fileName, FileMode.Open));
            userdata.maxScore = reader.ReadInt32();
            userdata.CurCharIndex = reader.ReadInt32();
            reader.Close();
        }
        else
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            userdata.maxScore = 0;
            userdata.CurCharIndex = 0;
        }
    }

    public void WriteFile()
    {
        writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate));
        writer.Write(GameManager.Instance.userdata.maxScore);
        writer.Write(GameManager.Instance.userdata.CurCharIndex);
        writer.Close();
    }
}
