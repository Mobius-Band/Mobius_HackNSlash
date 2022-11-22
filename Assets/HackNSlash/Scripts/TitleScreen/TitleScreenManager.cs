using System;
using HackNSlash.Scripts.GameManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace HackNSlash.Scripts.TitleScreen
{
    public class TitleScreenManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] sequentialScreens;
        private int sequenceIndex = 0;

        private void Start()
        {
            InputSystem.onAnyButtonPress.CallOnce(ctx => SequentiateScreens());
        }

        private void SequentiateScreens()
        {
            if (sequenceIndex >= sequentialScreens.Length - 1)
            {
                GameManager.Instance.LoadMainMenu();
                return;
            }
            sequentialScreens[sequenceIndex].SetActive(false);
            sequenceIndex++;
            sequentialScreens[sequenceIndex].SetActive(true);
            InputSystem.onAnyButtonPress.CallOnce(ctx => SequentiateScreens());
        }
    }
}