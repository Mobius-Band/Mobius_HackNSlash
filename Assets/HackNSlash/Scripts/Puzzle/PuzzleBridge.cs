using System;
using System.Collections;
using System.Collections.Generic;
using HackNSlash.Scripts.Puzzle;
using UnityEngine;

public class PuzzleBridge : MonoBehaviour
{
    [SerializeField] private PuzzleSwitch[] _puzzleSwitches;
    [SerializeField] private PuzzleReactor _puzzleReactor;

    private bool areAllSwitchesActivated => Array.TrueForAll(_puzzleSwitches, p => p.isActivated);
    public event Action<bool> OnAnySwitchActivated;
    
    private void Start()
    {
        foreach (var puzzleSwitch in _puzzleSwitches)
        {
            puzzleSwitch.OnSwitchActivated += CheckSwitches;
            puzzleSwitch.OnSwitchDeactivated += CheckSwitches;
        }
        OnAnySwitchActivated += _puzzleReactor.React;
    }

    private void CheckSwitches()
    {
        OnAnySwitchActivated?.Invoke(areAllSwitchesActivated);
    }
}
