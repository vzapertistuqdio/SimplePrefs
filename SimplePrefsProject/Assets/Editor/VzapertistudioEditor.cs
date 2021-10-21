using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VzapertistudioEditor : UnityEditor.Editor
{
    [MenuItem("Vzapertistudio/SimplePrefsSettings")]
    private static void EditSettings()
    {
        Selection.activeObject = GetSettings();
    }

    private static SimplePrefsSettings GetSettings()
    {
        SimplePrefsSettings settings = Resources.Load<SimplePrefsSettings>("SimplePrefs/SimplePrefSettings");
        return settings;
    }
}
