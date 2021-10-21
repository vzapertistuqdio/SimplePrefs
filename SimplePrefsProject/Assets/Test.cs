using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;
using UnityEngine;
using VzapertiStudio;

[RotationSave] [PositionSave]
public class Test : MonoBehaviour
{
    [PrefsSaver]
    [SerializeField]
    private int health;

    public int Health => health;

    private void Start()
    {
        //transform.position += Vector3.up;
    }
}
