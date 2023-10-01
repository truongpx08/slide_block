using TMPro;
using UnityEngine;

public class Tile : TruongMonoBehaviour
{
    [SerializeField] private TextMeshPro debugOriPos;
    [SerializeField] private TextMeshPro debugCurPos;
    [SerializeField] private SpriteRenderer model;

    [SerializeField] private TileData data;
    public TileData Data => data;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDebugOriPos();
        LoadDebugCurPos();
        LoadModel();
    }

    private void LoadModel()
    {
        this.model = transform.Find(TruongConstants.MODEL).GetComponent<SpriteRenderer>();
    }

    private void LoadDebugCurPos()
    {
        this.debugCurPos = transform.Find("Debug").Find("CurrentPos").GetComponent<TextMeshPro>();
    }

    private void LoadDebugOriPos()
    {
        this.debugOriPos = transform.Find("Debug").Find("OriginPos").GetComponent<TextMeshPro>();
    }

    public void SetData(TileData value)
    {
        this.data = value;
    }

    public void SetDebug()
    {
        this.debugOriPos.text = $"{this.Data.originColumn} {this.Data.originRow}";
        this.debugCurPos.text = $"[{this.Data.currentColumn},{this.Data.currentRow}]";
    }

    public void SetEmpty()
    {
        this.model.gameObject.SetActive(false);
    }
}