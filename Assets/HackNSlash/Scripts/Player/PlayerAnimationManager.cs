using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public Action OnAnimationEnd;
    
    void EndAnimation()
    {
        OnAnimationEnd?.Invoke();
    }
}
