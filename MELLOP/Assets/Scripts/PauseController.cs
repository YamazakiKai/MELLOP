using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PauseController : MonoBehaviour
{
    // ゲームを止める変数
    public bool ISStopGame { get; set; } = false;

    // カーソルの移動値
    private const int CursorMoveValue = 1;

    // カーソルの移動値を制限する変数
    private const int CursorMin = 0;
    private const int CursorMax = 2;

    // カーソルの座標を修正する変数
    private const float CursorPosOffsetX = 300;

    // テキストオブジェクトのざひょを修正する変数
    private const float TextObjectPosOffsetY = 200;

    // テキストファイルの末尾まで取得するための変数
    private const int FileReadEnd = -1;

    // バーティカルの入力軸を調べる変数
    private const int VerticalAxis = 0;

    // プレハブからオブジェクトを取得する際の変数
    private const string PrefabLoad = "Prefabs/Pause/";

    // キャバスのプレハブを取得する変数
    private GameObject CanvasPrefab;

    // キャンバスを取得するオブジェクト
    private GameObject Canvas;

    // 背景を取得するオブジェクト
    private GameObject BackGround;

    // カーソルの位置を数値で管理する変数
    private int cursorNumber = 0;

    // 現在のcursorNumberの数値を調べる変数
    private List<int> cursorNumberValue = new List<int>();

    // カーソルを取得するオブジェクト
    private GameObject Cursor;

    // カーソルの座標を取得する構造体
    private Vector2 CursorPos;

    // テキストを格納するリスト
    private List<string> TextCount = new List<string>();

    // 操作確認のプレハブを取得するオブジェクト
    private GameObject OperationScreenPrefab;

    // 操作確認を取得するオブジェクト
    private GameObject OperationScreen;

    // テキストオブジェクトのプレハブを取得する変数
    private GameObject TextObjectPrefab;

    // テキストオブジェクトを取得する変数
    private GameObject TextObject;

    // テキストを格納するリスト
    private List<GameObject> TextObjectNumber = new List<GameObject>();

    // テキストオブジェクトの座標を取得する変数
    private Vector2 TextObjectPos;

    // テキストを取得する変数
    private Text text;

    // テキストファイルを取得する変数
    private TextAsset CsvFile;

    // テキストファイルを読み込む変数
    private StringReader stringReader;

    // コントローラー操作を受け取る変数
    private float vertical;

    // バーティカルの取得を変数で管理する
    private bool isInputVertical = true;

    // 操作確認を表示する変数
    private bool isOperation = false;

    // スタート演出を取得するオブジェクト
    private StartDirecting startDirecting;

    // スタート演出のスクリプトを取得する変数
    private GameObject startDirectingObj;

    // Start is called before the first frame update
    void Start()
    {
        // キャンバスのプレハブを取得
        CanvasPrefab = (GameObject)Resources.Load(PrefabLoad + "Canvas");

        // キャンバスを複製
        Canvas = Instantiate(CanvasPrefab);

        // キャバスを非表示
        Canvas.SetActive(false);

        // 背景を複製
        BackGround = Canvas.transform.GetChild(0).gameObject;

        // カーソルを取得
        Cursor = Canvas.transform.GetChild(1).gameObject;

        // カーソルの座標を取得
        CursorPos = Cursor.transform.localPosition;

        // テキストオブジェクトのプレハブを取得
        TextObjectPrefab = (GameObject)Resources.Load(PrefabLoad + "Text");

        // テキストファイルを取得
        CsvFile = Resources.Load("PauseFiles/PauseText") as TextAsset;

        // テキストファイルを読み込む
        stringReader = new StringReader(CsvFile.text);

        // テキストの末尾まで取得する
        while (stringReader.Peek() > FileReadEnd)
        {
            // 一行ずつ格納する
            TextCount.Add(stringReader.ReadLine());
        }

        // 座標を初期化する
        TextObjectPos = TextObjectPrefab.transform.localPosition;

        // テキストオブジェクトを定数分複製する
        for (int i = 0; i < TextCount.Count; i++)
        {
            // テキストオブジェクトを複製
            TextObject = Instantiate(TextObjectPrefab);

            // テキストオブジェクトのテキストを取得
            text = TextObject.GetComponent<Text>();

            // テキストオブジェクトのテキストに内容を格納
            text.text = TextCount[i];

            // テキストオブジェクトをリストに追加
            TextObjectNumber.Add(TextObject);

            // オブジェクトを背景に格納
            TextObjectNumber[i].transform.SetParent(Canvas.transform, false);

            // テキストオブジェクトに座標を代入
            TextObjectPos.y -= TextObjectPosOffsetY;

            // 最初のテキストのみ初期座標を代入する
            if(i == 0)
            {
                TextObjectPos = TextObjectPrefab.transform.localPosition;
            }

            // テキストオブジェクトの座標を更新
            TextObjectNumber[i].transform.localPosition = TextObjectPos;
        }

        // 操作確認の複製を取得
        OperationScreenPrefab = (GameObject)Resources.Load(PrefabLoad + "OperationScreen");

        // 操作確認を取得
        OperationScreen = Instantiate(OperationScreenPrefab);

        // 操作確認をキャバスに格納する
        OperationScreen.transform.SetParent(Canvas.transform, false);

        // 操作確認を非表示
        OperationScreen.SetActive(false);

        // カーソルに初期座標を代入
        CursorPos.x -= CursorPosOffsetX;

        // カーソルの座標を更新
        Cursor.transform.localPosition = CursorPos;

        // テキストオブジェクトの数だけ数値を取得する
        for(int i = 0; i < TextCount.Count; i++)
        {
            cursorNumberValue.Add(i);
        }

        // スタート演出を取得する
        startDirectingObj = GameObject.Find("StartDirecting");
        startDirecting = startDirectingObj.GetComponent<StartDirecting>();

        // ポーズ画面の表示を受け付ける
        StartCoroutine("Display");
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ポーズ画面の表示処理
    /// </summary>
    private IEnumerator Display()
    {
        // 次のフレームまで待機
        yield return null;

        // 毎フレーム更新
        while (true)
        {
            // カウントダウンが終っている、かつポーズ画面が表示してないとき
            if (startDirecting.ISWaitingStart == false && !ISStopGame)
            {
                // エスケープキーまたはYボタンが入力されたらポーズ画面を表示する
                if (Input.GetButton("PauseButton"))
                {
                    // ゲームを止める
                    ISStopGame = true;

                    // キャバスを表示
                    Canvas.SetActive(true);

                    // 操作確認のテキストのY座標を代入
                    CursorPos.y = TextObjectNumber[0].transform.localPosition.y;

                    // カーソルの初期座標を代入
                    Cursor.transform.localPosition = CursorPos;

                    // カーソルの入力処理を呼び出す
                    StartCoroutine("InputKey");

                    // 処理を終了
                    yield break;
                }
            }

            // 次のフレームまで待機
            yield return null;
        }
    }

    /// <summary>
    /// キー入力の処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator InputKey()
    {
        // 連続で入力されないように、次のフレームまで待機
        yield return null;

        // 毎フレーム更新
        while (true)
        {
            // バーティカルの値が0なら矢印入力を受け付けを再開する
            if(vertical == VerticalAxis)
            {
                isInputVertical = true;
            }

            // 操作確認が非表示時に矢印キーの入力操作を受け取る
            if (!isOperation)
            {
                // Vertical値を取得
                vertical = Input.GetAxis("Vertical");
            }

            // 矢印キーが入力されたらカーソルを動かす
            if (isInputVertical && (vertical < VerticalAxis || vertical > VerticalAxis))
            {
                CursorMove();

                // 矢印キーの入力の受け付けをやめる
                isInputVertical = false;
            }

            // 決定キーが入力されたら画面を切り替える
            if (Input.GetButtonDown("Submit"))
            {
                SelectScreen();
            }

            // エスケープキーまたはYボタンが入力されたらポーズ画面を消す
            if (Input.GetButtonDown("PauseButton"))
            {
                // 操作確認を非表示
                if (isOperation)
                {
                    OperationScreen.SetActive(false);

                    isOperation = false;
                }
                else // ポーズ画面を非表示
                {
                    // キャバスを非表示にする
                    Canvas.SetActive(false);

                    // ゲームを再始動
                    ISStopGame = false;

                    // 毎フレーム更新
                    while(true)
                    {
                        // エスケープキーまたはYボタンが入力されて、指を離したらポーズ画面を消す
                        if (Input.GetButtonUp("PauseButton"))
                        {
                            // ポーズ画面の表示を受け付ける
                            StartCoroutine("Display");

                            // 処理を終了
                            yield break;
                        }

                        // 次のフレームまで待機
                        yield return null;
                    }
                }
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
        // 上キーが押されたらカーソルの座標を変更
        if (vertical > VerticalAxis)
        {
            // cursorNumber が CursorMin 以上大きい数値であればカーソルを上へ動かす
            if (cursorNumber > CursorMin)
            {
                // cursorNumber の値を減少
                cursorNumber -= CursorMoveValue;

                // カーソルに代入するY座標を取得
                CursorPos.y = TextObjectNumber[cursorNumber].transform.localPosition.y;

                // カーソルの座標を更新
                Cursor.transform.localPosition = CursorPos;
            }
        }
        else if (vertical < VerticalAxis) // 下キーが押されたらカーソルの座標を変更
        {
            // cursorNumber が CursorMax より小さい数値であればカーソルを下へ動かす
            if (cursorNumber < CursorMax)
            {
                // cursorNumberの値を増やす
                cursorNumber += CursorMoveValue;

                // カーソルに代入するY座標を取得
                CursorPos.y = TextObjectNumber[cursorNumber].transform.localPosition.y;

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
        if (cursorNumber == cursorNumberValue[0]) // 操作方法を表示
        {
            isOperation = true;

            OperationScreen.SetActive(true);
        }
        else if (cursorNumber == cursorNumberValue[1]) // 現在のシーンをリロード
        {
            // 現在のシーンを取得
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // シーンをリロード
            SceneManager.GetActiveScene();
        }
        else if (cursorNumber == cursorNumberValue[2]) // セレクト画面へ遷移
        {
            SceneManager.LoadScene("SelectStage");
        }

        // 処理を終了
        return;
    }
}