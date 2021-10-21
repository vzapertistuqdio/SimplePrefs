using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class KeyBuilder : MonoBehaviour
{
    public static string BuildKeyForPrefsSaver(FieldInfo info, MonoBehaviour monobeh)
        => info.Name + "_" + info.DeclaringType + "_" + monobeh.GetHashCode();

    public static string BuildKeyForPositionX(MonoBehaviour monobeh)
        => monobeh.GetType() + "_" + "X" + "_" + monobeh.GetHashCode();

    public static string BuildKeyForPositionY(MonoBehaviour monobeh)
        => monobeh.GetType() + "_" + "Y" + "_" + monobeh.GetHashCode();

    public static string BuildKeyForPositionZ(MonoBehaviour monobeh)
        => monobeh.GetType() + "_" + "Z" + "_" + monobeh.GetHashCode();

    public static string BuildKeyForRotationX(MonoBehaviour monobeh)
     => monobeh.GetType() + "_" + "rotX" + "_" + monobeh.GetHashCode();

    public static string BuildKeyForRotationY(MonoBehaviour monobeh)
        => monobeh.GetType() + "_" + "rotY" + "_" + monobeh.GetHashCode();

    public static string BuildKeyForRotationZ(MonoBehaviour monobeh)
        => monobeh.GetType() + "_" + "rotZ" + "_" + monobeh.GetHashCode();
}
