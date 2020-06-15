using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 「ゴール」ブロック
/// 担当：吉中
/// </summary>
public class GoalBlock : Block
{
    public static Block Instantiate()
    {
        Sprite Sprite = Resources.Load<Sprite>("Textures/Blocks/Goal/tempgoal");

        GameObject prefab = Resources.Load("Prefabs/Blocks/GoalBlock") as GameObject;

        var obj = Instantiate(prefab).GetComponent<GoalBlock>();
        obj.sprite = Sprite;
        return obj;
    }

    public void OnMelt()
    {
#if UNITY_EDITOR
        Debug.Log("Clear!!!");
#endif

    }
}
