using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;
using UnityEngine;


namespace VzapertiStudio
{
    public class MonobehExt
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        public static void OnRuntimeMethodLoad()
        {
            SimplePrefsSettings settings = Resources.Load<SimplePrefsSettings>("SimplePrefs/SimplePrefSettings");
            if (!settings.IsSimplePrefsEnabled)
                return;

            GameObject simplePrefsObj = Resources.Load<GameObject>("SimplePrefs/SimplePrefsConditionController");
            GameObject.Instantiate(simplePrefsObj);
        }
    }
}
