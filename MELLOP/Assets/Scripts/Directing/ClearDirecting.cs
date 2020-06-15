using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

/// <summary>
/// クリア後の遷移処理
/// 担当：笹之内
/// </summary>
public class ClearDirecting : MonoBehaviour
{
    // カーソルの移動値
    private const int CursorMoveValue = 1;

    // カーソルのX座標の初期値
    private const int CursorPosXOffset = 250;

    // カーソルの移動量を制限する変数
    private const int CursorMin = 0;

    // CursorNumberの現在の数値を調べる変数
    private List<int> CursorNumberValue = new List<int>();

    // テキストオブジェクトのY座標を初期化する変数
    private const int FirstTextObjPosY = 170;

    // テキストオブジェクトのX座標を初期化する変数
    private const int FirstTextObjPosX = 100;

    // テキストオブジェクトのY座標を初期化する変数
    private const int TextObjPosY = 150;

    // 上下キーの入力軸を調べる変数
    private const int VerticalAxis = 0;

    // ステージ番号の数値を増加させる変数
    private const int StageNumberValue = 1;

    // 最後のステージをする変数
    private const int FinalStageNumber = 20;

    // テキストファイルの末尾まで取得するための変数
    private const int FileReadEnd = -1;

    // セレクトステージへシーン遷移するための変数
    private const string LodeSelectStage = "SelectStage";

    // キャンバスのプレハブを取得する変数
    private GameObject CanvasPrefab;

    // キャンバスを取得する変数
    private GameObject Canvas;

    private GameObject BackGround;

    // テキストオブジェクトの総数を取得する変数
    private int textNumberMax;

    // テキストの総数を取得する変数
    private int textCountMax;

    // テキストを格納するリスト
    private List<string> TextCount = new List<string>();

    // テキストファイルを取得する変数
    private TextAsset CsvFile;

    // テキストファイルを読み込む変数
    private StringReader stringReader;

    // クリア画面で表示するテキストのプレハブを取得するオブジェクト
    private GameObject TextPrefab;

    // クリア画面で表示するのテキストを取得するオブジェクト
    private GameObject Text;

    // テキストオブジェクトを格納するリスト
    private List<GameObject> TextNumber = new List<GameObject>();

    // テキストオブジェクトのテキストを取得する変数
    private Text text;

    // テキストオブジェクトの座標を取得する変数
    private Vector2 TextObjPos;

    // カーソルの移動量を制限する変数
    private int cursorMax;

    // カーソルの位置を数値で管理する変数
    private int cursorNumber = 0;

    // 矢印の入力を管理する変数
    private bool isInputArrow = true;

    // キャンバスにあるカーソルまでの子オブジェクトを数を取得する変数
    private int canvasChildCountUntilCorsor;

    // カーソルを取得する変数
    private GameObject Cursor;

    // カーソルの座標を取得する変数
    private Vector2 CursorPos;

    // 現在のステージ番号を取得する変数
    private int stageNumber;

    // コントローラーで操作する変数
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        // キャンバスを取得
        CanvasPrefab = (GameObject)Resources.Load("Prefabs/Directing/Clear/Canvas");

        // キャンバスを複製
        Canvas = Instantiate(CanvasPrefab);

        // キャンバスを非表示
        Canvas.SetActive(false);

        // 背景を取得
        BackGround = Canvas.transform.GetChild(0).gameObject;

        // ネクストのプレハブを取得
        TextPrefab = (GameObject)Resources.Load("Prefabs/Directing/Clear/Text");

        // テキストファイルを取得
        CsvFile = Resources.Load("ClearFile/ClearText") as TextAsset;

        // テキストファイルを読み込む
        stringReader = new StringReader(CsvFile.text);

        // 現在のステージ番号を取得
        stageNumber = SelectStage.SceneController.number;

        // キャンバスにあるカーソルまでの子オブジェクトを数を取得
        canvasChildCountUntilCorsor = Canvas.transform.childCount;

        // 現在のステージ番号が最後であればネクストを表示しない
        if (stageNumber == FinalStageNumber)
        {
            // 一行捨てる
            stringReader.ReadLine();
        }

        // テキストの末尾まで取得する
        while (stringReader.Peek() > FileReadEnd)
        {
            // 一行ずつ格納する
            TextCount.Add(stringReader.ReadLine());
        }

        // テキストの総数を取得
        textCountMax = TextCount.Count;

        // テキストオブジェクトを定数分複製する
        for (int i = 0; i < textCountMax; i++)
        {
            // オブジェクトを複製
            Text = Instantiate(TextPrefab);

            // オブジェクトのテキストを取得
            text = Text.GetComponent<Text>();

            // オブジェクトのテキストに内容を格納
            text.text = TextCount[i];

            // オブジェクトをリストに追加
            TextNumber.Add(Text);

            // オブジェクトを背景に格納
            Text.transform.SetParent(Canvas.transform, false);
        }

        // テキストオブジェクトの総数を取得
        textNumberMax = TextNumber.Count;

        // 最初のテキストオブジェクトの座標を初期化
        TextObjPos.y = FirstTextObjPosY;
        TextObjPos.x = FirstTextObjPosX;

        // テキストオブジェクトの座標を更新
        TextNumber[0].transform.localPosition = TextObjPos;

        // 最初のテキストオブジェクト以降の座標を初期化
        for (int i = 1; i < textNumberMax; i++)
        {
            // オブジェクトにY座標を代入
            TextObjPos.y -= TextObjPosY;

            // オブジェクトの座標を更新
            TextNumber[i].transform.localPosition = TextObjPos;
        }

        // カーソルを取得
        Cursor = Canvas.transform.GetChild(1).gameObject;

        // カーソルの初期座標を代入
        CursorPos = Cursor.transform.localPosition;

        // カーソルのX座標を初期化
        CursorPos.x = CursorPos.x - CursorPosXOffset;

        // カーソルにテキストオブジェクトの座標を代入
        CursorPos.y = TextNumber[0].transform.localPosition.y;

        // カーソルの初期座標を更新
        Cursor.transform.localPosition = CursorPos;

        // キャンバスにあるカーソル以降子オブジェクトの数を取得
        for (int i = 0; i < Canvas.transform.childCount - canvasChildCountUntilCorsor; i++)
        {
            CursorNumberValue.Add(i);

            // カーソルの最大移動値を取得
            cursorMax = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR // デバック
        // コントロールキー(左)を押しながらCキーが入力されたらクリア画面を表示
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C))
        {
            Clear();
        }
#endif 
    }

    /// <summary>
    /// クリア画面を表示する処理
    /// PuzzleManagerで呼び出す関数
    /// </summary>
    public void Clear()
    {
        // 背景を表示
        Canvas.SetActive(true);

        // カーソルの入力処理
        StartCoroutine("InputKey");

        // 処理を終了
        return;
    }

    /// <summary>
    /// キー入力処理
    /// </summary>
    private IEnumerator InputKey()
    {
        // 次のフレームまで待機
        yield return null;

        // 毎フレーム更新
        while (true)
        {
            // Vertical値を取得
            vertical = Input.GetAxis("Vertical");

            // バーティカルの値が0なら矢印キーの入力を受け付けを再開する
            if (vertical == VerticalAxis)
            {
                isInputArrow = true;
            }

            // 矢印キーが入力されたらカーソルを動かす
            if (isInputArrow && (vertical < VerticalAxis || vertical > VerticalAxis))
            {
                CursorMove();

                // 矢印キーの入力の受付を一時的に止める
                isInputArrow = false;
            }

            // 決定キーが入力されたらシーンを遷移する
            if (Input.GetButtonDown("Submit"))
            {
                SelectScreen();

                // 処理を終了する
                yield break;
            }

            // 次のフレームまで待機
            yield return null;
        }
    }

    /// <summary>
    /// カーソルの挙動処理
    /// </summary>
    private void CursorMove()
    {
        // 上キーが入力されたらカーソルを上へ移動
        if (vertical > VerticalAxis)
        {
            // 現在の移動量が最小値より大きい数値であればカーソルを上へ動かす
            if (cursorNumber > CursorMin)
            {
                // cursorNumber の値を減らす
                cursorNumber -= CursorMoveValue;

                // カーソルに代入するY座標を取得
                CursorPos.y = TextNumber[cursorNumber].transform.localPosition.y;

                // カーソルの座標を更新
                Cursor.transform.localPosition = CursorPos;
            }
        }
        else if (vertical < VerticalAxis) // 下キーが入力されたらカーソルを下へ移動
        {
            // 現在の移動量が最大値より小さい数値であればカーソルを下へ動かす
            if (cursorNumber < cursorMax)
            {
                // cursorNumber の値を増やす
                cursorNumber += CursorMoveValue;

                // カーソルに代入するY座標を取得
                CursorPos.y = TextNumber[cursorNumber].transform.localPosition.y;

                // カーソルの座標を更新
                Cursor.transform.localPosition = CursorPos;
            }
        }

        // 処理を終了
        return;
    }

    /// <summary>
    /// 画面を切り替える
    /// </summary>
    private void SelectScreen()
    {
        // 最後のステージの時のみ次のステージに遷移しない
        if(stageNumber == FinalStageNumber)
        {
            // 現在のシーンをリロード
            if (cursorNumber == CursorNumberValue[0])
            {
                // 現在のシーンを取得
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                // シーンをリロード
                SceneManager.GetActiveScene();
            }

            // セレクト画面へ遷移
            if (cursorNumber == CursorNumberValue[1])
            {
                SceneManager.LoadScene(LodeSelectStage);
            }
        }
        else
        {
            // 次のステージへ遷移
            if (cursorNumber == CursorNumberValue[0])
            {
                // ステージを番号を増加
                SelectStage.SceneController.number += StageNumberValue;

                // 現在のシーンを取得
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                // シーンをリロード
                SceneManager.GetActiveScene();
            }

            // 現在のステージをリトライ
            if (cursorNumber == CursorNumberValue[1])
            {
                // 現在のシーンを取得
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                // シーンをリロード
                SceneManager.GetActiveScene();
            }

            // セレクト画面へ遷移
            if (cursorNumber == CursorNumberValue[2])
            {
                SceneManager.LoadScene(LodeSelectStage);
            }
        }

        // 処理を終了
        return;
    }
}