using System;
using UnityEngine;

namespace Combat
{
    /// <summary>
    /// This class is used to store the data of a single attack.
    /// </summary>
    [Serializable]
    public class Combo
    {
        public Attack[] comboAttacks;
    }
}
