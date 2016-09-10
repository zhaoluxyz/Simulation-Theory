using UnityEngine;
using System.Collections;
using System;

public class Settings : MonoBehaviour
{
    //all settings the user can change will be here.
    public int mouseXSensitivity = 10;
    public int mouseYSensitivity = 10;
    string PlayerSettingsAvailable;


    void Start ()
    {
        mouseXSensitivity = PlayerPrefs.GetInt("MouseXSensitivity", 10);
        mouseYSensitivity = PlayerPrefs.GetInt("MouseYSensitivity", 10);
        PlayerSettingsAvailable = PlayerPrefs.GetString("PlayerSettingsAvailable", "False");

        if (!Convert.ToBoolean(PlayerSettingsAvailable))
            SaveSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("MouseXSensitivity", mouseXSensitivity);
        PlayerPrefs.SetInt("MouseYSensitivity", mouseXSensitivity);
        PlayerPrefs.SetString("PlayerSettingsAvailable", "True");
    }
}
