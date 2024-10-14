using System.Collections.Generic;
using UnityEngine;

public class MageSkinDefault : Skin
{
    public override int GetID()
    {
        return 0;
    }

    public override Dictionary<string, AnimationClip> GetAnimations()
    {
        return new Dictionary<string, AnimationClip>
        {
            { "IdleDOWN", Resources.Load<AnimationClip>("Mage/Default/IdleDOWN") },
            { "IdleUP", Resources.Load<AnimationClip>("Mage/Default/IdleUP") },
            { "IdleLEFT", Resources.Load<AnimationClip>("Mage/Default/IdleLEFT") },
            { "IdleRIGHT", Resources.Load<AnimationClip>("Mage/Default/IdleRIGHT") },
            { "WalkDOWN", Resources.Load<AnimationClip>("Mage/Default/WalkDOWN") },
            { "WalkUP", Resources.Load<AnimationClip>("Mage/Default/WalkUP") },
            { "WalkLEFT", Resources.Load<AnimationClip>("Mage/Default/WalkLEFT") },
            { "WalkRIGHT", Resources.Load<AnimationClip>("Mage/Default/WalkRIGHT") }
        };
    }
}
