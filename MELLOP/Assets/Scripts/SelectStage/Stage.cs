using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージUIの処理
/// 担当：山崎
/// </summary>
public class Stage : MonoBehaviour
{
    // ステージナンバーの格納変数
    public int number;
    // 1エリアのステージ数
    public int StageNumMax = 5;
    public int StageGroupMax = 3;

    public int[] StageNumber = new int[5]{2 ,6 ,10 ,15 ,20};
    public int[] StageGrouping = new int[3] { 2, 10, 21 };
    public int[] stageNumberOffSetFirst = new int[3] { 0, 1, 4 };
    public int[] stageNumberOffSetSecond = new int[3] { 3, 4, 5 };
    // ステージ間の横幅
    public int WidthInterval = 6;

    private const float Expansion = 1.3f;

    // ステージポジション
    Transform Position;
    Vector3 pos;

    // ステージがクリアされてるかどうか
    public bool ClearFlag;

    // Start is called before the first frame update
    void Start()
    {
        // テクスチャ読み込み
        TextureLoad();
        // ポジションセット
        SetPosition();
        if (number == 0)
            ClearFlag = true;
        // クリアチェック
        Clear();
    }
    void Update()
    {
        // テキスト表示
        Text();
        // Horizontalの値を取得
        var horizontal = Input.GetAxis("Horizontal");

        if (gameObject.transform.position != new Vector3(0, 0, 0))
        {
            gameObject.transform.localScale = new Vector2(1,1);
        }
        // デバック
        Clear();
    }
    
    /// <summary>
    ///　拡大縮小
    /// </summary>
    public void Scale()
    {
        if (gameObject.transform.position == new Vector3(0, 0, 0))
        {
            gameObject.transform.localScale = new Vector2(Expansion, Expansion);
        }
        else
        {
            gameObject.transform.localScale = new Vector2(1, 1);
        }
    }
    
    /// <summary>
    /// ポジションセット
    /// </summary>
    void SetPosition()
    {
        Position = gameObject.transform;
        pos = Position.localPosition;

        // 等間隔にステージを配置する
        pos.x = number * WidthInterval;

        Position.localPosition = pos;
    }

    /// <summary>
    /// テクスチャの読み込み
    /// </summary>
    void TextureLoad()
    {
        string path = " ";
        int TextureNumber;
        // エリアごとにによってロードする画像を変更する
        for (TextureNumber = 0; TextureNumber < StageNumMax; TextureNumber++)
        {
            if(number <= StageNumber[TextureNumber])
            {
                break;
            }
        }
        // 画像の指定
        switch (TextureNumber)
        {
            case 0:
                path = "Textures/stage/Select_stageplate1";
                break;
            case 1:
                path = "Textures/stage/Select_stageplate2";
                break;
            case 2:
                path = "Textures/stage/Select_stageplate3";
                break;
            case 3:
                path = "Textures/stage/Select_stageplate4";
                break;
            case 4:
                path = "Textures/stage/Select_stageplate5";
                break;
        }
        // 指定した画像をscriptに読み込む
        var sprite = Resources.Load<Sprite>(path);
        // spriteRendererに指定したpathをLoadする
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }

    /// <summary>
    /// テキスト表示
    /// </summary>
    void Text()
    {
        string Num = " ";
        var TextNumber = 0;
        // ステージがエリア分けされてるため4つのステージを5つ作る
        for (int i = 0; i < StageGroupMax; i++)
        {
            // ステージの面ごとにステージのレベルを変える
            if (number <= StageGrouping[i])
            {
                // ステージのレベルを取得
                TextNumber = (number + stageNumberOffSetFirst[i]) % stageNumberOffSetSecond[i] + 1;
                // 処理を終了する
                break;
            }
        }
        Num = TextNumber.ToString();
        // 自分の配下のNumberを探す
        var Text = transform.Find("StageNumber").GetComponent<TextMesh>();
        // Numをtextに入れる
        Text.text = Num;
    }

    /// <summary>
    /// クリアチェック
    /// </summary>
    public void Clear()
    {
        if(ClearFlag)
        {
            // 元の色にする
            GetComponent<Renderer>().material.color = Color.white;
        }
        else if (!ClearFlag)
        {
            // カラーをグレーにする
            GetComponent<Renderer>().material.color = Color.gray;
        }
    }
}
