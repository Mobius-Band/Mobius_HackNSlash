using System;
using UnityEngine;

namespace HackNSlash.Scripts.UI
{
    public class GameplayUIManager : MonoBehaviour
    {
        private void Start()
        {
            //SetPlayMode(true);
        }

        public void SetPlayMode(bool isPlayMode)
        {
            Cursor.visible = !isPlayMode;
            Cursor.lockState = isPlayMode ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}