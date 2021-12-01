using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;
using UnityEngine.SceneManagement;


namespace VzapertiStudio
{
    public class PrefsLoader : MonoBehaviour
    {
        private Dictionary<string, MonoBehaviour> monobehsFieldInfo = new Dictionary<string, MonoBehaviour>(5);
        private void OnEnable()
        {
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += LoadAllSimplePrefsCallbackOnSceneLoad;
            PrefsSaverEvents.OnRequareSaveDataObjectSpawned += LoadSimplePrefsForMonobeh;
        }

        private void LoadSimplePrefsForMonobeh(MonoBehaviour monobeh)
        {
            List<FieldInfo> options = monobeh.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
                .Where(n => Attribute.IsDefined(n, typeof(PrefsSaverAttribute))).ToList();
            
            foreach (FieldInfo info in options)
            {
                if (info.FieldType != typeof(float) && info.FieldType != typeof(string) &&
                    info.FieldType != typeof(int))
                {
                    Debug.LogError("This type " + info.FieldType + " is no supported by SimplePrefs");
                    return;
                }

                if (info.FieldType == typeof(int))
                {
                    SetValueToIntVariable(info, monobeh);
                }

                if (info.FieldType == typeof(string))
                {
                    SetValueToStringVariable(info, monobeh);
                }

                if (info.FieldType == typeof(float))
                {
                    SetValueToFloatVariable(info, monobeh);
                }
                
                try
                {
                    monobehsFieldInfo.Add(info.Name + "_" + info.DeclaringType+ "_" + monobeh.name,monobeh);
                }
                catch (Exception e)
                {
                    Debug.LogError("Detect duplicated names of Gameobjects:"+monobeh.gameObject.name+"."+"Loading save data for this object will not be correct.Please rename objects");
                }
            }
        }

        private void LoadAllSimpePrefs()
        {
            MonoBehaviour[] monobehs = GameObject.FindObjectsOfType<MonoBehaviour>();
            foreach (var monobeh in monobehs)
            {
                LoadSimplePrefsForMonobeh(monobeh);
            }
        }

        private void LoadAllSimplePrefsCallbackOnSceneLoad(Scene scene,LoadSceneMode mode)
        {
            LoadAllSimpePrefs();
        }

        private void SetValueToFloatVariable(FieldInfo info, MonoBehaviour monobeh)
        {
            if ((float)info.GetValue(monobeh) != 0)
                Debug.LogWarning("Variables with attribute 'PrefsSaver' must be initialized in Attribute property or Monobehaviors methods");
            
            if (PlayerPrefs.HasKey(KeyBuilder.BuildKeyForPrefsSaver(info, monobeh)))
            {
                info.SetValue(monobeh, PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForPrefsSaver(info, monobeh)));
            }
            else
            {
                object[] attrs = info.GetCustomAttributes(false);
                List<PrefsSaverAttribute> prefsSaverAttrList = GetPrefsSaverAtribbutesFromSttribuutesObjects(attrs);

                foreach (PrefsSaverAttribute attr in prefsSaverAttrList)
                {
                    if (attr.Value == null)
                    {
                        info.SetValue(monobeh, default);
                    }
                    else
                    {
                        float res;
                        if (float.TryParse(attr.Value.ToString(), out res))
                        {
                            info.SetValue(monobeh, attr.Value);
                        }
                        else
                            Debug.LogError("PrefsSaver value type ofattribute property != field type");
                    }
                }
            }
        }

        private void SetValueToIntVariable(FieldInfo info, MonoBehaviour monobeh)
        {
            if ((int)info.GetValue(monobeh) != 0)
                Debug.LogWarning("Variables with attribute 'PrefsSaver' must be initialized in Attribute property or Monobehaviors methods");

            if (PlayerPrefs.HasKey(KeyBuilder.BuildKeyForPrefsSaver(info, monobeh)))
            {
                info.SetValue(monobeh, PlayerPrefs.GetInt(KeyBuilder.BuildKeyForPrefsSaver(info, monobeh)));
            }
            else
            {
                object[] attrs = info.GetCustomAttributes(false);
                List<PrefsSaverAttribute> prefsSaverAttrList = GetPrefsSaverAtribbutesFromSttribuutesObjects(attrs);
                foreach (PrefsSaverAttribute attr in prefsSaverAttrList)
                {
                    if (attr.Value == null)
                    {
                        info.SetValue(monobeh, default);
                    }
                    else
                    {
                        int res;
                        if (int.TryParse(attr.Value.ToString(), out res))
                            info.SetValue(monobeh, attr.Value);
                        else
                            Debug.LogError("PrefsSaver value type of attribute property != field type");
                    }
                }
            }
        }

        private void SetValueToStringVariable(FieldInfo info, MonoBehaviour monobeh)
        {
            if (info.GetValue(monobeh) != null)
                Debug.LogWarning("Variables with attribute 'PrefsSaver' must be initialized in Attribute property or Monobehaviors methods");

            if (PlayerPrefs.HasKey(KeyBuilder.BuildKeyForPrefsSaver(info, monobeh)))
            {
                info.SetValue(monobeh, KeyBuilder.BuildKeyForPrefsSaver(info, monobeh));
            }
            else
            {
                object[] attrs = info.GetCustomAttributes(false);
                List<PrefsSaverAttribute> prefsSaverAttrList = GetPrefsSaverAtribbutesFromSttribuutesObjects(attrs);

                foreach (PrefsSaverAttribute attr in prefsSaverAttrList)
                {
                    if (attr.Value == null)
                    {
                        info.SetValue(monobeh, default);
                    }
                    else
                    {
                        if (attr.Value.GetType() == typeof(string))
                            info.SetValue(monobeh, attr.Value);
                        else
                            Debug.LogError("PrefsSaver value type of attribute property != field type");
                    }
                }
            }
        }

        private List<PrefsSaverAttribute> GetPrefsSaverAtribbutesFromSttribuutesObjects(object[] attrs)
        {
            List<object> attributesListToObject = attrs.Where(t => t.GetType() == typeof(PrefsSaverAttribute)).ToList();

            List<PrefsSaverAttribute> attributesListToPrefsSave = new List<PrefsSaverAttribute>();

            foreach (var atr in attributesListToObject)
            {
                attributesListToPrefsSave.Add(atr as PrefsSaverAttribute);
            }

            return attributesListToPrefsSave;
        }
    }
}
