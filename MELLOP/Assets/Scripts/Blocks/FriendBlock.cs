using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBlock : Block
{
    public int level { get; private set; }
    Animator animator = null;
    Animator cylinderAnimator = null;
    public static Block Instantiate(int level)
    {
        GameObject prefab = Resources.Load("Prefabs/Blocks/FriendBlock") as GameObject;
        var obj = Instantiate(prefab).GetComponent<FriendBlock>();
        obj.level = level;
        GameObject[] models = new GameObject[3];
        models[0] = obj.transform.Find("Cylinders/Cylinder1").gameObject;
        models[1] = obj.transform.Find("Cylinders/Cylinder2").gameObject;
        models[2] = obj.transform.Find("Cylinders/Cylinder3").gameObject;
        foreach (var model in models)
            model.SetActive(false);
        models[obj.level].SetActive(true);

        obj.animator = obj.transform.Find("friend1").GetComponent<Animator>();
        obj.cylinderAnimator = models[obj.level].GetComponent<Animator>();
        return obj;
    }

    public override void OnRotation(Rotation rotation)
    {
        animator.SetTrigger(rotation == Rotation.Left ? "RotL" : "RotR");
    }

    public void OnMelt()
    {
        animator.SetTrigger("Open");
        cylinderAnimator.SetTrigger("Open");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
