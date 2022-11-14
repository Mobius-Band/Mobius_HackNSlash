using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public Action OnAnimationHit;
    public Action OnAnimationSuspendRotation;
    
    void AnimationHit()
    {
        OnAnimationHit?.Invoke();
    }
    
    void AnimationSuspendRotation()
    {
        OnAnimationSuspendRotation?.Invoke();
    }
}
