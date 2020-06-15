using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 「消えないブロック」
/// 担当：吉中
/// </summary>
public class CannotBlock : Block
{
    public static Block Instantiate()
    {
        Sprite Sprite = Resources.Load<Sprite>("Textures/Blocks/Cannot/tempbatu");

        GameObject prefab = Resources.Load("Prefabs/Blocks/CannotBlock") as GameObject;

        var obj = Instantiate(prefab).GetComponent<CannotBlock>();
        obj.sprite = Sprite;
        return obj;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
