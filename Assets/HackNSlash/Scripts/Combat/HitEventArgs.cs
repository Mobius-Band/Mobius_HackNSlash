using System;
using UnityEngine;

namespace Combat
{
    public class HitEventArgs : EventArgs
    {
        public int Damage { get; set; }
        public Transform hitOriginTransform { get; set;}
    }
}