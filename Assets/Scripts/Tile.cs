using UnityEngine;

public class Tile : TruongMonoBehaviour
{
    [SerializeField] private TileData data;
    public TileData Data => data;

    public void SetData(TileData value)
    {
        this.data = value;
    }
}