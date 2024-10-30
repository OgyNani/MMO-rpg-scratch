using System.Collections.Generic;
using UnityEngine;

public class Dummy
{
    private List<Skin> skins;

    public Dummy()
    {
        skins = new List<Skin>
        {
            new DummyDEFAULT(),
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
