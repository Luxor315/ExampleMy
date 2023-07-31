using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Example : MonoBehaviour
{
    public string s;
    public int Level = 85;
    public float Health = 100.0f;
    public float Speed = 8f;
    public float[] fs = new float[] { 3, 5, 7, 7 };

    private void Start()
    {
        string j = JsonUtility.ToJson(this);

        //var obj = JsonUtility.FromJson<Example>(s);
        //JsonUtility.FromJsonOverwrite(s, this);



        ///llll
        ///

        //lll

        string path = Application.persistentDataPath  + "/filename.random";//"C:/";
        Debug.Log(path);
        Debug.Log(j);

        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine("Расширение этого файла .RANDOM");
        }

        using (StreamReader sr = new StreamReader(path))
        {
            string line = sr.ReadToEnd();
            Debug.Log(line);
        }
    }
}