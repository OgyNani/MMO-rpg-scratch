using System.Collections.Generic;
using UnityEngine;

public abstract class Skin
{
    public abstract int GetID();
    public abstract Dictionary<string, AnimationClip> GetAnimations();
}
