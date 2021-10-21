using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SimplePrefSettings", menuName = "SimplePrefs/Settings")]
public class SimplePrefsSettings : ScriptableObject
{
    [Header("Settings", order = 1)]
    [Tooltip("Enable/Disable")]
    public bool IsSimplePrefsEnabled=true;
}
