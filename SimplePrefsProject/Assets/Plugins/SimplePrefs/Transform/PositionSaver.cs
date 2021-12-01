using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace VzapertiStudio
{
    public class PositionSaver : MonoBehaviour
    {

        private List<MonoBehaviour> listOfMonobehs = new List<MonoBehaviour>();
        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                SaveAllPositions();
            }
        }


        private void OnApplicationQuit()
        => SaveAllPositions();

        private void SaveAllPositions()
        {
            MonoBehaviour[] monobehs = GameObject.FindObjectsOfType<MonoBehaviour>();

            foreach (var monobeh in monobehs)
            {
                PositionSaveAttribute dnAttribute = monobeh.GetType().GetCustomAttribute(typeof(PositionSaveAttribute), true) as PositionSaveAttribute;

                if (dnAttribute != null)
                {
                    listOfMonobehs.Add(monobeh);
                    SaveMonobehPos(monobeh);
                }
            }

            CheckRepeatingName();
        }

        private void SaveMonobehPos(MonoBehaviour monobeh)
        {
            PlayerPrefs.SetFloat(KeyBuilder.BuildKeyForPositionX(monobeh),monobeh.transform.position.x);
            PlayerPrefs.SetFloat(KeyBuilder.BuildKeyForPositionY(monobeh), monobeh.transform.position.y);
            PlayerPrefs.SetFloat(KeyBuilder.BuildKeyForPositionZ(monobeh), monobeh.transform.position.z);
        }

        private void CheckRepeatingName()
        {
            for (int i = 0; i < listOfMonobehs.Count; i++)
            {
                for (int j = i+1; j < listOfMonobehs.Count; j++)
                {

                    if (listOfMonobehs[i].name == listOfMonobehs[j].name)
                    {
                        Debug.LogError("Detect duplicated names of Gameobjects:" + listOfMonobehs[i].name + "." +
                                       " Names must be different");
                        
                    }
                }
            }
        }
    }
}
