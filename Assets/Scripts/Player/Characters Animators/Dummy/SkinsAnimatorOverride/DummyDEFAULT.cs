using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDEFAULT : Skin
{
    public override int GetID()
    {
        return 0;
    }

    public override Dictionary<string, AnimationClip> GetAnimations()
    {
        var animations = new Dictionary<string, AnimationClip>
    {
        { "IdleDOWN", Resources.Load<AnimationClip>("Sprites/Characters/Dummy/SKINS/DEFAULT/Idle/Animation/IdleDOWM") },
        { "IdleUP", Resources.Load<AnimationClip>("Sprites/Characters/Dummy/SKINS/DEFAULT/Idle/Animation/IdleUP") },
        { "IdleLEFT", Resources.Load<AnimationClip>("Sprites/Characters/Dummy/SKINS/DEFAULT/Idle/Animation/IdleLEFT") },
        { "IdleRIGHT", Resources.Load<AnimationClip>("Sprites/Characters/Dummy/SKINS/DEFAULT/Idle/Animation/IdleRIGHT") },
        { "WalkDOWN", Resources.Load<AnimationClip>("Sprites/Characters/Dummy/SKINS/DEFAULT/Walk/Animation/WalkDOWN") },
        { "WalkUP", Resources.Load<AnimationClip>("Sprites/Characters/Dummy/SKINS/DEFAULT/Walk/Animation/WalkUP") },
        { "WalkLEFT", Resources.Load<AnimationClip>("Sprites/Characters/Dummy/SKINS/DEFAULT/Walk/Animation/WalkLEFT") },
        { "WalkRIGHT", Resources.Load<AnimationClip>("Sprites/Characters/Dummy/SKINS/DEFAULT/Walk/Animation/WalkRIGHT") }
    };

        return animations;
    }
}
