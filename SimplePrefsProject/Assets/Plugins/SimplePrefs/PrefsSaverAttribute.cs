using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace VzapertiStudio
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PrefsSaverAttribute : Attribute
    {
        public PrefsSaverAttribute(object val)
        {
            Value = val;
        }

        public PrefsSaverAttribute()
        {
            Value = null;
        }

        public object Value { get; set; }
    }
}
