using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


namespace VzapertiStudio
{
    public class RotationLoader : MonoBehaviour
    {
        private Dictionary<MonoBehaviour, Vector3> monobehsRot = new Dictionary<MonoBehaviour, Vector3>(5);

        private void Awake()
        {
            LoadAllRotations();
            DontDestroyOnLoad(this);
        }

        private void LoadAllRotations()
        {
            MonoBehaviour[] monobehs = GameObject.FindObjectsOfType<MonoBehaviour>();
            foreach (var monobeh in monobehs)
            {
                RotationSaveAttribute dnAttribute = monobeh.GetType().GetCustomAttribute(typeof(RotationSaveAttribute), true) as RotationSaveAttribute;
                if (dnAttribute != null)
                {
                    if (CheckHasSaveRotation(monobeh))
                    {
                        Vector3 rot = new Vector3(PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForRotationX(monobeh)), PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForRotationY(monobeh)), PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForRotationZ(monobeh)));
                        monobehsRot.Add(monobeh, rot);
                    }
                }
            }
        }

        private void Start()
        {
            foreach (KeyValuePair<MonoBehaviour, Vector3> keyValue in monobehsRot)
            {
                keyValue.Key.transform.rotation =Quaternion.Euler(keyValue.Value);
            }
        }

        private bool CheckHasSaveRotation(MonoBehaviour monobeh)
           => PlayerPrefs.HasKey(KeyBuilder.BuildKeyForRotationX(monobeh)) && PlayerPrefs.HasKey(KeyBuilder.BuildKeyForRotationY(monobeh)); //Two components because if 2d game position hasnt z part
    }
}
