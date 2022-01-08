using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OptionDataManager
{
    private const string OPTION_KEY = "Option";

    public static UserOption Option;

    public static void Load()
    {

        //Cek apakah sudah ada data yang tersimpan
        if (!PlayerPrefs.HasKey(OPTION_KEY))
        {

            Option = new UserOption();
            Save();
        }
        else
        {

            string json = PlayerPrefs.GetString(OPTION_KEY);
            Option = JsonUtility.FromJson<UserOption>(json);
        }
    }

    public static void Save()
    {
        string json = JsonUtility.ToJson(Option);
        PlayerPrefs.SetString(OPTION_KEY, json);
    }

}
