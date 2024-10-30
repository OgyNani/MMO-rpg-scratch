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
        //IDLE
        { "IdleDOWN", Resources.Load<AnimationClip>("Animations/Characters/Dummy/SKINS/DEFAULT/Idle/Animation/IdleDOWM") },
        { "IdleUP", Resources.Load<AnimationClip>("Animations/Characters/Dummy/SKINS/DEFAULT/Idle/Animation/IdleUP") },
        { "IdleLEFT", Resources.Load<AnimationClip>("Animations/Characters/Dummy/SKINS/DEFAULT/Idle/Animation/IdleLEFT") },
        { "IdleRIGHT", Resources.Load<AnimationClip>("Animations/Characters/Dummy/SKINS/DEFAULT/Idle/Animation/IdleRIGHT") },
        //WALK
        { "WalkDOWN", Resources.Load<AnimationClip>("Animations/Characters/Dummy/SKINS/DEFAULT/Walk/Animation/WalkDOWN") },
        { "WalkUP", Resources.Load<AnimationClip>("Animations/Characters/Dummy/SKINS/DEFAULT/Walk/Animation/WalkUP") },
        { "WalkLEFT", Resources.Load<AnimationClip>("Animations/Characters/Dummy/SKINS/DEFAULT/Walk/Animation/WalkLEFT") },
        { "WalkRIGHT", Resources.Load<AnimationClip>("Animations/Characters/Dummy/SKINS/DEFAULT/Walk/Animation/WalkRIGHT") },
        //SHIELD
        { "ShieldDOWN", Resources.Load<AnimationClip>("Animations/Characters/Dummy/SKINS/DEFAULT/Shield/Animation/ShieldDOWN") },
        { "ShieldUP", Resources.Load<AnimationClip>("Animations/Characters/Dummy/SKINS/DEFAULT/Shield/Animation/ShieldUP") },
        { "ShieldLEFT", Resources.Load<AnimationClip>("Animations/Characters/Dummy/SKINS/DEFAULT/Shield/Animation/ShieldLEFT") },
        { "ShieldRIGHT", Resources.Load<AnimationClip>("Animations/Characters/Dummy/SKINS/DEFAULT/Shield/Animation/ShieldRIGHT") },
    };

        return animations;
    }
}
