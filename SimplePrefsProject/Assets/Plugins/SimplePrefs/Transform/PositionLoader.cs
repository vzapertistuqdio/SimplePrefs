using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


namespace VzapertiStudio
{
    public class PositionLoader : MonoBehaviour
    {
        private Dictionary<MonoBehaviour, Vector3> monobehsPos = new Dictionary<MonoBehaviour, Vector3>(5);

        private void Awake()
        {
            LoadAllPositions();
            DontDestroyOnLoad(this);
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
                        Vector3 pos = new Vector3(PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForPositionX(monobeh)), PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForPositionY(monobeh)), PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForPositionZ(monobeh)));
                        monobehsPos.Add(monobeh, pos);
                    }
                }
            }
        }

        private void Start()
        {
            foreach(KeyValuePair<MonoBehaviour, Vector3> keyValue in monobehsPos)
            {
                keyValue.Key.transform.position = keyValue.Value;
            }
        }

        private bool CheckHasSavePosition(MonoBehaviour monobeh)
           => PlayerPrefs.HasKey(KeyBuilder.BuildKeyForPositionX(monobeh)) && PlayerPrefs.HasKey(KeyBuilder.BuildKeyForPositionY(monobeh)); //Two components because if 2d game position hasnt z part
    }
}
