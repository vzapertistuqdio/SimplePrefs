using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


namespace VzapertiStudio
{
    public class RotationLoader : MonoBehaviour
    {
        private Dictionary<MonoBehaviour, Vector3> monobehsRot = new Dictionary<MonoBehaviour, Vector3>(5);
        
        private List<MonoBehaviour> listOfMonobehs = new List<MonoBehaviour>();

        private void Start()
        {
            LoadAllRotations();
            DontDestroyOnLoad(this);
            
            foreach (KeyValuePair<MonoBehaviour, Vector3> keyValue in monobehsRot)
            {
                keyValue.Key.transform.rotation =Quaternion.Euler(keyValue.Value);
            }
        }
        
        private void OnEnable()
        {
            PrefsSaverEvents.OnRequareSaveDataObjectSpawned += LoadRotationForMonobeh;
        }

        private void OnDisable()
        {
            PrefsSaverEvents.OnRequareSaveDataObjectSpawned -= LoadRotationForMonobeh;
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
                        listOfMonobehs.Add(monobeh);
                        Vector3 rot = new Vector3(PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForRotationX(monobeh)), PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForRotationY(monobeh)), PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForRotationZ(monobeh)));
                        monobehsRot.Add(monobeh, rot);
                    }
                }
            }
            
            CheckRepeatingName();
        }
        
        private bool CheckHasSaveRotation(MonoBehaviour monobeh)
           => PlayerPrefs.HasKey(KeyBuilder.BuildKeyForRotationX(monobeh)) && PlayerPrefs.HasKey(KeyBuilder.BuildKeyForRotationY(monobeh)); //Two components because if 2d game position hasnt z part

        private void LoadRotationForMonobeh(MonoBehaviour monobeh)
        {
            RotationSaveAttribute dnAttribute = monobeh.GetType().GetCustomAttribute(typeof(RotationSaveAttribute), true) as RotationSaveAttribute;
            if (dnAttribute != null)
            {
                if (CheckHasSaveRotation(monobeh))
                {
                    listOfMonobehs.Add(monobeh);
                    Vector3 rot = new Vector3(PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForRotationX(monobeh)), PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForRotationY(monobeh)), PlayerPrefs.GetFloat(KeyBuilder.BuildKeyForRotationZ(monobeh)));
                    monobeh.transform.rotation =Quaternion.Euler(monobehsRot[monobeh]);
                }
            }
        }
        
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
