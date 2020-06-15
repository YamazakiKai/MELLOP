using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 「矢印ブロック」
/// 担当：吉中
/// </summary>
public class ArrowBlock : Block
{
    // ブロックの方向を指定します。
    public enum Direction
    {
        Up, Down, Right, Left
    }
    public Direction direction { get; private set; }

    private static Sprite[] sprites;

    Animator animator;

    [SerializeField] GameObject particlePrefab = null;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="direction">方向プロパティの初期化が必要です</param>
    public static Block Instantiate(Direction direction)
    {
        //sprites = new Sprite[] {
        // Resources.Load<Sprite>("Textures/Blocks/Arrows/arrow_up"),    // Up
        // Resources.Load<Sprite>("Textures/Blocks/Arrows/arrow_down"),  // Down
        // Resources.Load<Sprite>("Textures/Blocks/Arrows/arrow_right"), // Right
        // Resources.Load<Sprite>("Textures/Blocks/Arrows/arrow_left")   // Left
        //};
        GameObject prefab = Resources.Load("Prefabs/Blocks/ArrowBlock") as GameObject;
        var obj = Instantiate(prefab).GetComponent<ArrowBlock>();
        obj.direction = direction;
        //obj.sprite = sprites[(int)direction];
        //obj.gameObject.GetComponent<SpriteRenderer>().sprite = obj.sprite;
        obj.RotArrow();
        return obj;
    }

    void RotArrow()
    {
        var model = transform.Find("Model");
        float rotZ = 0;
        switch (direction)
        {
            case Direction.Up: rotZ = 90; break;
            case Direction.Down: rotZ = 270; break;
            case Direction.Right: rotZ = 0; break;
            case Direction.Left: rotZ = 180; break;
        }
        model.eulerAngles = new Vector3(rotZ, -90, 0);
    }

    public override void OnRotation(Rotation rotation)
    {
        switch (this.direction)
        {
            case Direction.Up:   /**/ direction = (rotation == Rotation.Right) ? Direction.Right : Direction.Left; break;
            case Direction.Down: /**/ direction = (rotation == Rotation.Right) ? Direction.Left : Direction.Right; break;
            case Direction.Right:/**/ direction = (rotation == Rotation.Right) ? Direction.Down : Direction.Up; break;
            case Direction.Left: /**/ direction = (rotation == Rotation.Right) ? Direction.Up : Direction.Down; break;
        }
        //gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)this.direction];
        RotArrow();
    }

    public Direction OnMelt()
    {
        // 未実装
        Instantiate(particlePrefab).transform.position = transform.position;
        transform.Find("Model").GetComponent<Animator>().SetTrigger("Melt");
        return direction;
    }
}
