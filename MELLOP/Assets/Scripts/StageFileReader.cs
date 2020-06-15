using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/// <summary>
/// ステージファイルの読み込みを行います
/// 担当：吉中
/// </summary>
public class StageFileReader
{
    public static Block[] StageLoad(string stagename)
    {
        string path = Application.dataPath + "/Resources/StageFiles/" + stagename + ".csv";
        FileInfo fileInfo = new FileInfo(path);
        FileStream fileStream = fileInfo.OpenRead();
        StreamReader streamReader = new StreamReader(fileStream);
        string data = streamReader.ReadToEnd();
#if UNITY_EDITOR
        Debug.Log(data);
#endif
        // 改行で分割（各ブロックごとに
        string[] enter = { "\n" };
        string[] arr = data.Split(enter, StringSplitOptions.None);
        // １行目のLength情報を取得
        string[] comma = { "," };
        string[] temp = arr[0].Split(comma, StringSplitOptions.None);
        Block[] stage = new Block[int.Parse(temp[1])];
        // 最後の改行を除くので－１
        for (int i = 1; i < arr.Length - 1; i++)
        {
            Block block = null;
            // それぞれ型名で書き出しているので型名で検索かければOK
            if (arr[i].IndexOf(nameof(GoalBlock)) >= 0)
                block = GoalBlock.Instantiate();
            else if (arr[i].IndexOf(nameof(NormalBlock)) >= 0)
                block = NormalBlock.Instantiate();
            else if (arr[i].IndexOf(nameof(CannotBlock)) >= 0)
                block = CannotBlock.Instantiate();
            else if (arr[i].IndexOf(nameof(AcidBlock)) >= 0)
                block = AcidBlock.Instantiate();
            else if (arr[i].IndexOf(nameof(FixedBlock)) >= 0)
                block = FixedBlock.Instantiate();
            // 矢印は方向プロパティも読み込む
            else if (arr[i].IndexOf(nameof(ArrowBlock)) >= 0)
            {
                string[] direction = arr[i].Split(comma, StringSplitOptions.None);
                block = ArrowBlock.Instantiate((ArrowBlock.Direction)int.Parse(direction[1]));
            }
            // 中間ブロックはレベルプロパティも読み込む
            else if (arr[i].IndexOf(nameof(FriendBlock)) >= 0)
            {
                string[] level = arr[i].Split(comma, StringSplitOptions.None);
                block = FriendBlock.Instantiate(int.Parse(level[1]));
            }
            // どれにも一致しなければファイル破損として扱う
            else
            {
                Debug.Log(stagename + " is corrupted!");
                Debug.Log(arr[i]);
                return null;
            }
            stage[i - 1] = block;

        }
        return stage;
    }

    // ステージ番号だけで呼び出せたほうが色々便利なのでオーバーロード
    public static Block[] StageLoad(int stageNo)
    {
        return StageLoad("No." + stageNo.ToString());
    }
}
