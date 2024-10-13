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
        { "IdleDOWN", Resources.Load<AnimationClip>("Sprites/Characters/Mage/SKINS/MoonKeeper/Idle/Animation/IdleDOWMMoonKeeper") },
        { "IdleUP", Resources.Load<AnimationClip>("Sprites/Characters/Mage/SKINS/MoonKeeper/Idle/Animation/IdleUPMoonKeeper") },
        { "IdleLEFT", Resources.Load<AnimationClip>("Sprites/Characters/Mage/SKINS/MoonKeeper/Idle/Animation/IdleLEFTMoonKeeper") },
        { "IdleRIGHT", Resources.Load<AnimationClip>("Sprites/Characters/Mage/SKINS/MoonKeeper/Idle/Animation/IdleRIGHTMoonKeeper") },
        { "WalkDOWN", Resources.Load<AnimationClip>("Sprites/Characters/Mage/SKINS/MoonKeeper/Walk/Animation/WalkDOWNMoonKeeper") },
        { "WalkUP", Resources.Load<AnimationClip>("Sprites/Characters/Mage/SKINS/MoonKeeper/Walk/Animation/WalkUPMoonKeeper") },
        { "WalkLEFT", Resources.Load<AnimationClip>("Sprites/Characters/Mage/SKINS/MoonKeeper/Walk/Animation/WalkLEFTMoonKeeper") },
        { "WalkRIGHT", Resources.Load<AnimationClip>("Sprites/Characters/Mage/SKINS/MoonKeeper/Walk/Animation/WalkRIGHTMoonKeeper") }
    };

        return animations;
    }

}
