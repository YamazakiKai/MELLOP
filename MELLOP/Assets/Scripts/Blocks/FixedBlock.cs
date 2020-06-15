using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedBlock : Block
{
    public static Block Instantiate()
    {
        Sprite Sprite = Resources.Load<Sprite>("Textures/Blocks/Fixed/tempfix");

        GameObject prefab = Resources.Load("Prefabs/Blocks/FixedBlock") as GameObject;

        var obj = Instantiate(prefab).GetComponent<FixedBlock>();
        return obj;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
