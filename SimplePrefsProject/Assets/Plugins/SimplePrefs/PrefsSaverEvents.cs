using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsSaverEvents : MonoBehaviour
{
   public static Action<MonoBehaviour> OnRequareSaveDataObjectSpawned;

   public static void CallOnRequareSaveDataObjectSpawned(MonoBehaviour monobeh)
      => OnRequareSaveDataObjectSpawned?.Invoke(monobeh);

}
