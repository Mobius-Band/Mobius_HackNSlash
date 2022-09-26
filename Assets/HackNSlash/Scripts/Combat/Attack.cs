using System;
using UnityEngine;

namespace Combat
{
    
    [Serializable]
    public struct Attack
    {
        public int damage;
        public Vector3 hitboxPosition;
        public Vector3 hitboxSize;
        public String animationName;
    }
}