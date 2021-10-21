using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace VzapertiStudio
{
    public class RotationSaver : MonoBehaviour
    {
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
        }

        private void SaveMonobehRotation(MonoBehaviour monobeh)
        {
            PlayerPrefs.SetFloat(KeyBuilder.BuildKeyForRotationX(monobeh), monobeh.transform.rotation.eulerAngles.x);
            PlayerPrefs.SetFloat(KeyBuilder.BuildKeyForRotationY(monobeh), monobeh.transform.rotation.eulerAngles.y);
            PlayerPrefs.SetFloat(KeyBuilder.BuildKeyForRotationZ(monobeh), monobeh.transform.rotation.eulerAngles.z);
        }
    }
}

