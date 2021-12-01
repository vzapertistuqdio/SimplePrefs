using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


namespace VzapertiStudio
{
    public class PositionLoader : MonoBehaviour
    {
        private Dictionary<MonoBehaviour, Vector3> monobehsPos = new Dictionary<MonoBehaviour, Vector3>(5);
        
        private List<MonoBehaviour> listOfMonobehs = new List<MonoBehaviour>();

        private void OnEnable()
        {
            PrefsSaverEvents.OnRequareSaveDataObjectSpawned += LoadPositionForMonobeh;
        }

        private void OnDisable()
        {
            PrefsSaverEvents.OnRequareSaveDataObjectSpawned -= LoadPositionForMonobeh;
        }

        private void LoadAllPositions()
        {
            MonoBehaviour[] monobehs = GameObject.FindObjectsOfType<MonoBehaviour>();
            foreach (var monobeh in monobehs)
            {
                PositionSaveAttribute dnAttribute = monobeh.GetType().GetCustomAttribute(typeof(PositionSaveAttribute), true) as PositionSaveAttribute;
                if (dnAttribute != null)
                {
                    if(CheckHasSavePosition(monobeh))
                    {
                        listOfMonobehs.Add(monobeh);
                        Vector3 pos = new Vector3(PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForPositionX(monobeh)), PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForPositionY(monobeh)), PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForPositionZ(monobeh)));
                        Debug.Log(pos);
                        monobehsPos.Add(monobeh, pos);
                    }
                }
            }
            CheckRepeatingName();
        }

        private void LoadPositionForMonobeh(MonoBehaviour monobeh)
        {
            PositionSaveAttribute dnAttribute = monobeh.GetType().GetCustomAttribute(typeof(PositionSaveAttribute), true) as PositionSaveAttribute;
            if (dnAttribute != null)
            {
                if(CheckHasSavePosition(monobeh))
                {
                    Vector3 pos = new Vector3(PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForPositionX(monobeh)), PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForPositionY(monobeh)), PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForPositionZ(monobeh)));
                    monobeh.transform.position = monobehsPos[monobeh];
                }
            }
        }

        private void Start()
        {
            LoadAllPositions();
            DontDestroyOnLoad(this);
            foreach(KeyValuePair<MonoBehaviour, Vector3> keyValue in monobehsPos)
            {
                keyValue.Key.transform.position = keyValue.Value;
            }
        }

        private bool CheckHasSavePosition(MonoBehaviour monobeh)
           => PlayerPrefs.HasKey(KeyBuilder.BuildKeyForPositionX(monobeh)) && PlayerPrefs.HasKey(KeyBuilder.BuildKeyForPositionY(monobeh)); //Two components because if 2d game position hasnt z part
        
        private void CheckRepeatingName()
        {
            for (int i = 0; i < listOfMonobehs.Count; i++)
            {
                for (int j = i+1; j < listOfMonobehs.Count; j++)
                {
                    if(listOfMonobehs[i].name==listOfMonobehs[j].name)
                        Debug.LogError("Detect duplicated names of Gameobjects:"+listOfMonobehs[i].name+"."+"Loading save data for this object will not be correct.Please rename objects");
                }
            }
        }
    }
}
