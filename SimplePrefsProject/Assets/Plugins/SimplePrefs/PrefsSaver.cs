using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

namespace VzapertiStudio
{
    public class PrefsSaver : MonoBehaviour
    {
        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                SaveAllSimpePrefs();
            }
        }

        private void OnApplicationQuit()
        => SaveAllSimpePrefs();

        private void SaveAllSimpePrefs()
        {
            MonoBehaviour[] monobehs = GameObject.FindObjectsOfType<MonoBehaviour>();

            foreach (var monobeh in monobehs)
            {
                List<FieldInfo> options = monobeh.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
                    .Where(n => Attribute.IsDefined(n, typeof(PrefsSaverAttribute))).ToList();
                foreach (FieldInfo info in options)
                {
                    if (info.FieldType == typeof(int))
                    {
                        PlayerPrefs.SetInt(KeyBuilder.BuildKeyForPrefsSaver(info,monobeh), (int)info.GetValue(monobeh));
                    }
                    if (info.FieldType == typeof(string))
                    {
                        PlayerPrefs.SetString(KeyBuilder.BuildKeyForPrefsSaver(info, monobeh), (string)info.GetValue(monobeh));
                    }
                    if (info.FieldType == typeof(float))
                    {
                        PlayerPrefs.SetFloat(KeyBuilder.BuildKeyForPrefsSaver(info, monobeh), (float)info.GetValue(monobeh));
                    }
                }
            }
        }
        
    }
}
