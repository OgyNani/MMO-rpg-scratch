using System.Collections.Generic;
using UnityEngine;

public class Mage
{
    private List<Skin> skins;

    public Mage()
    {
        skins = new List<Skin>
        {
            new MageSkinDefault(),
            new MageSkinMoonKeeper()
        };
    }


    public Skin GetSkinByID(int id)
    {
        foreach (Skin skin in skins)
        {
            if (skin.GetID() == id)
                return skin;
        }

        return null;
    }
}
