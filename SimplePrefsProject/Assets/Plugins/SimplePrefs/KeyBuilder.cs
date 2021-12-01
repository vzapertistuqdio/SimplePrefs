using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class KeyBuilder : MonoBehaviour
{
    public static string BuildKeyForPrefsSaver(FieldInfo info, MonoBehaviour monobeh)
        => info.Name + "_" + info.DeclaringType+ "_" + monobeh.name;

    public static string BuildKeyForPositionX(MonoBehaviour monobeh)
        => monobeh.GetType() + "_" + "X" + "_" + monobeh.name;

    public static string BuildKeyForPositionY(MonoBehaviour monobeh)
        => monobeh.GetType() + "_" + "Y" + "_" + monobeh.name;

    public static string BuildKeyForPositionZ(MonoBehaviour monobeh)
        => monobeh.GetType() + "_" + "Z" + "_" +monobeh.name;

    public static string BuildKeyForRotationX(MonoBehaviour monobeh)
     => monobeh.GetType() + "_" + "rotX" + "_" +monobeh.name;

    public static string BuildKeyForRotationY(MonoBehaviour monobeh)
        => monobeh.GetType() + "_" + "rotY" + "_" +monobeh.name;

    public static string BuildKeyForRotationZ(MonoBehaviour monobeh)
        => monobeh.GetType() + "_" + "rotZ" + "_" + monobeh.name;
}
