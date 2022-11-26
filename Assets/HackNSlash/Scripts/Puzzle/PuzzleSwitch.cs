using System;
using UnityEngine;

namespace HackNSlash.Scripts.Puzzle
{
    public abstract class PuzzleSwitch : MonoBehaviour
    {
        public bool isActivated;
        
        public event Action OnSwitchActivated;
        public event Action OnSwitchDeactivated;
        
        
    }
}