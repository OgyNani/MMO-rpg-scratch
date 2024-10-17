using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "FriendlyTile", menuName = "Tile/FriendlyTile")]
public class FriendlyTile : RuleTile
{
    public List<FriendlyTile> friendlyTiles = new List<FriendlyTile>();

    public bool IsFriendly(FriendlyTile otherTile)
    {
        return friendlyTiles.Contains(otherTile);
    }

    public override bool RuleMatch(int neighbor, TileBase tile)
    {
        FriendlyTile neighborTile = tile as FriendlyTile;
        if (neighborTile != null && IsFriendly(neighborTile))
        {
            return true;
        }

        return base.RuleMatch(neighbor, tile);
    }
}
