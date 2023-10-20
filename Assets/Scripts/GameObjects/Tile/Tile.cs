using Sirenix.OdinInspector;
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
        this.debugOriPos.text = $"T {this.Data.column} {this.Data.row}";
        this.debugCurPos.text = $"{this.Data.id}";
    }

    public void SetEmpty()
    {
        this.model.gameObject.SetActive(false);
    }

    public void SetName()
    {
        this.name = "Tile " + data.column + " " + data.row;
    }

    [Button]
    public void SetTransformAfterShuffled()
    {
        Cell cell = Cells.Instance.CellSpawner.GetCell(this.Data.column, this.Data.row);
        SetParent(cell);
    }

    public void SetModel(Vector2 modelSize)
    {
        EnableModel();
        SetSpriteModel();
        SetSizeModel(modelSize);
    }

    public void SetParent(Cell cell)
    {
        if (Cells.Instance.CellsShuffling.IsShuffling) return;
        var thisTransform = this.transform;
        thisTransform.parent = cell.TileSpawner.Holder.transform;
        thisTransform.localPosition = Vector3.zero;
    }

    private void SetSpriteModel()
    {
        this.model.sprite = Cells.Instance.CellSpawner.Sprites[this.Data.id];
    }

    private void SetSizeModel(Vector2 modelSize)
    {
        this.model.size = modelSize;
    }

    public void DisableDebug()
    {
        this.debugCurPos.gameObject.SetActive(false);
        this.debugOriPos.gameObject.SetActive(false);
    }


    private void EnableModel()
    {
        this.model.gameObject.SetActive(true);
    }
}