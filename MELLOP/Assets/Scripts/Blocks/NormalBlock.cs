using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBlock : Block
{
    public static Block Instantiate()
    {
       //Sprite Sprite = Resources.Load<Sprite>("Textures/Blocks/Normal/tempnormal");

        GameObject prefab = Resources.Load("Prefabs/Blocks/NormalBlock") as GameObject;

        var obj = Instantiate(prefab).GetComponent<NormalBlock>();
        //obj.sprite = Sprite;
        return obj;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
