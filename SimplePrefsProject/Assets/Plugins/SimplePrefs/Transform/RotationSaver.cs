using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace VzapertiStudio
{
    public class RotationSaver : MonoBehaviour
    {
        private List<MonoBehaviour> listOfMonobehs = new List<MonoBehaviour>();
        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                SaveAllRotations();
            }
        }


        private void OnApplicationQuit()
        => SaveAllRotations();

        private void SaveAllRotations()
        {
            MonoBehaviour[] monobehs = GameObject.FindObjectsOfType<MonoBehaviour>();

            foreach (var monobeh in monobehs)
            {
                RotationSaveAttribute dnAttribute = monobeh.GetType().GetCustomAttribute(typeof(RotationSaveAttribute), true) as RotationSaveAttribute;

                if (dnAttribute != null)
                {
                    SaveMonobehRotation(monobeh);
                }
            }
            
            CheckRepeatingName();
        }

        private void SaveMonobehRotation(MonoBehaviour monobeh)
        {
            PlayerPrefs.SetFloat(KeyBuilder.BuildKeyForRotationX(monobeh), monobeh.transform.rotation.eulerAngles.x);
            PlayerPrefs.SetFloat(KeyBuilder.BuildKeyForRotationY(monobeh), monobeh.transform.rotation.eulerAngles.y);
            PlayerPrefs.SetFloat(KeyBuilder.BuildKeyForRotationZ(monobeh), monobeh.transform.rotation.eulerAngles.z);
        }
        
        private void CheckRepeatingName()
        {
            for (int i = 0; i < listOfMonobehs.Count; i++)
            {
                for (int j = i+1; j < listOfMonobehs.Count; j++)
                {
                    if(listOfMonobehs[i].name==listOfMonobehs[j].name)
                        Debug.LogError("Detect duplicated names of Gameobjects:"+listOfMonobehs[i].name+"."+" Names must be different");
                }
            }
        }
    }
}

