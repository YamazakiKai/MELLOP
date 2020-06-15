using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 「酸」「矢印」などのブロックの親クラス
/// ポリモーフィズムであわよくば楽をしたい
/// 担当：吉中
/// </summary>
public abstract class Block : MonoBehaviour
{
    // 画像sprite
    public Sprite sprite { get; protected set; }
    // 落下可能か否か→これは今のところ全て落ちるのでいらなかった
    //public bool CanFall { get; protected set; } = true;

    // 酸ブロックから溶けろと命令が来たときに呼び出す
    //public abstract ArrowBlock.Direction OnMelt();
    // 回転方向の指定enumはここに書くべきじゃなかったかもしれない、要整理
    public enum Rotation { Right, Left }
    // 盤面が回転したときに矢印の方向を変えたりするようなやつ
    public virtual void OnRotation(Rotation rotation) { }
}
