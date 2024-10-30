using System.Collections.Generic;
using UnityEngine;

public class MageSkinMoonKeeper : Skin
{
    public override int GetID()
    {
        return 1;
    }

    public override Dictionary<string, AnimationClip> GetAnimations()
    {
        var animations = new Dictionary<string, AnimationClip>
    {
        //IDLE
        { "IdleDOWN", Resources.Load<AnimationClip>("Animations/Characters/Mage/SKINS/MoonKeeper/Idle/Animation/IdleDOWMMoonKeeper") },
        { "IdleUP", Resources.Load<AnimationClip>("Animations/Characters/Mage/SKINS/MoonKeeper/Idle/Animation/IdleUPMoonKeeper") },
        { "IdleLEFT", Resources.Load<AnimationClip>("Animations/Characters/Mage/SKINS/MoonKeeper/Idle/Animation/IdleLEFTMoonKeeper") },
        { "IdleRIGHT", Resources.Load<AnimationClip>("Animations/Characters/Mage/SKINS/MoonKeeper/Idle/Animation/IdleRIGHTMoonKeeper") },
        //WALK
        { "WalkDOWN", Resources.Load<AnimationClip>("Animations/Characters/Mage/SKINS/MoonKeeper/Walk/Animation/WalkDOWNMoonKeeper") },
        { "WalkUP", Resources.Load<AnimationClip>("Animations/Characters/Mage/SKINS/MoonKeeper/Walk/Animation/WalkUPMoonKeeper") },
        { "WalkLEFT", Resources.Load<AnimationClip>("Animations/Characters/Mage/SKINS/MoonKeeper/Walk/Animation/WalkLEFTMoonKeeper") },
        { "WalkRIGHT", Resources.Load<AnimationClip>("Animations/Characters/Mage/SKINS/MoonKeeper/Walk/Animation/WalkRIGHTMoonKeeper") },
        //SHIELD
        { "ShieldDOWN", Resources.Load<AnimationClip>("Animations/Characters/Mage/SKINS/MoonKeeper/Shield/Animation/ShieldDOWNMoonKeeper") },
        { "ShieldUP", Resources.Load<AnimationClip>("Animations/Characters/Mage/SKINS/MoonKeeper/Shield/Animation/ShieldUPMoonKeeper") },
        { "ShieldLEFT", Resources.Load<AnimationClip>("Animations/Characters/Mage/SKINS/MoonKeeper/Shield/Animation/ShieldLEFTMoonKeeper") },
        { "ShieldRIGHT", Resources.Load<AnimationClip>("Animations/Characters/Mage/SKINS/MoonKeeper/Shield/Animation/ShieldRIGHTMoonKeeper") },
    };

        return animations;
    }

}
