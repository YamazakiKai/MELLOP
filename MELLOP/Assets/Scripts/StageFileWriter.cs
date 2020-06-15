using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// ステージファイルの書き出しを行います
/// 担当：吉中
/// </summary>
public class StageFileWriter : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //// 仮のステージデータ
        //Block[] blocks = new Block[16];
        //blocks[0] = NormalBlock.Instantiate();
        //blocks[1] = ArrowBlock.Instantiate(ArrowBlock.Direction.Right);
        //blocks[2] = ArrowBlock.Instantiate(ArrowBlock.Direction.Right);
        //blocks[3] = AcidBlock.Instantiate();
        //blocks[4] = ArrowBlock.Instantiate(ArrowBlock.Direction.Right);
        //blocks[5] = ArrowBlock.Instantiate(ArrowBlock.Direction.Down);
        //blocks[6] = ArrowBlock.Instantiate(ArrowBlock.Direction.Right);
        //blocks[7] = ArrowBlock.Instantiate(ArrowBlock.Direction.Right);
        //blocks[8] = ArrowBlock.Instantiate(ArrowBlock.Direction.Right);
        //blocks[9] = ArrowBlock.Instantiate(ArrowBlock.Direction.Down);
        //blocks[10] = ArrowBlock.Instantiate(ArrowBlock.Direction.Left);
        //blocks[11] = ArrowBlock.Instantiate(ArrowBlock.Direction.Right);
        //blocks[12] = GoalBlock.Instantiate();
        //blocks[13] = ArrowBlock.Instantiate(ArrowBlock.Direction.Down);
        //blocks[14] = ArrowBlock.Instantiate(ArrowBlock.Direction.Down);
        //blocks[15] = CannotBlock.Instantiate();
        //SaveFile(blocks);
        //for (int i = 0; i < blocks.Length; i++)
        //{
        //    Destroy(blocks[i].gameObject);
        //}
    }

    /// <summary>
    /// ステージデータの書き出しを行います
    /// </summary>
    /// <param name="stage">書き出すステージデータ配列</param>
    /// <param name="fileName">ステージには名前をつけてね</param>
    public void SaveFile(Block[] stage, string fileName = "Stage0")
    {
        string path = Application.dataPath + "/Resources/StageFiles/" + fileName + ".csv";
        FileInfo fileInfo = new FileInfo(path);
        FileStream fileStream = fileInfo.OpenWrite();
        StreamWriter streamWriter = new StreamWriter(fileStream);
        // 今後のことを考えて一応何マス構成かも書き出しておく
        streamWriter.WriteLine("Length," + stage.Length);
        for (int i = 0; i < stage.Length; i++)
        {
            string str;
            // 矢印ブロックの場合方向も書き出す
            if (stage[i] is ArrowBlock arrow)
            {
                str = nameof(ArrowBlock);
                str += "," + ((int)arrow.direction).ToString();
            }
            // その他は型名だけ書き出せば事足りる
            else
                str = stage[i].GetType().ToString();
            // バッファに一行ずつ書き込み
            streamWriter.WriteLine(str);
        }
        // バッファのデータをファイルに書き込み
        streamWriter.Flush();
        // 閉じる
        streamWriter.Close();
    }
}
