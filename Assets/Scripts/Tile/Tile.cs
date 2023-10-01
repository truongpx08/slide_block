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
        this.debugOriPos.text = $"T {this.Data.originColumn} {this.Data.originRow}";
        this.debugCurPos.text = $"{this.Data.id}";
    }

    public void SetEmpty()
    {
        this.model.gameObject.SetActive(false);
    }

    public void SetName()
    {
        this.name = "Tile " + data.currentColumn + " " + data.currentRow;
    }

    public void MoveToCell(Cell cell)
    {
        var thisTransform = this.transform;
        thisTransform.parent = cell.TileSpawner.Holder.transform;
        thisTransform.localPosition = Vector3.zero;
    }

    public void SetModel()
    {
        this.model.sprite = Cells.Instance.CellsSpawner.Sprites[this.Data.id];
    }

    public void DisableDebug()
    {
        this.debugCurPos.gameObject.SetActive(false);
        this.debugOriPos.gameObject.SetActive(false);
    }
}