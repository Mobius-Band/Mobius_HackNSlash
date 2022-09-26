using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public Action OnAnimationEnd;
    public Action OnAnimationHit;
    
    void EndAnimation()
    {
        OnAnimationEnd?.Invoke();
    }

    void AnimationHit()
    {
        OnAnimationHit?.Invoke();
    }
}
