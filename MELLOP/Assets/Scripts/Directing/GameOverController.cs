using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームオーバー画面の処理
/// 担当：笹之内
/// </summary>
public class GameOverController : MonoBehaviour
{
    // テキストオブジェクトのY座標を初期化する変数
    private const int TextObjPosYOffset = 150;

    // テキストオブジェクトの数
    private const int TextObjMax = 2;

    // カーソルのX座標を初期化する変数
    private const int CursorPosXOffset = 350;

    // カーソルの移動量
    private const int CursorMoveValue = 1;

    // カーソルの移動量を制限する変数
    private const int CursorMin = 0;

    // cursorMaxの値を修正する変数
    private const int CursorMaxOffset = 1;

    // ステージ番号の数値を増加させる変数
    private const int StageNumberValue = 1;

    // 上下キーの入力軸を調べる変数
    private const int VerticalAxis = 0;

    // ゲームオーバー画面の表示を遅延する変数
    private const float DerayTime = 1.5f;

    // キャンバスの子オブジェクトを取得させる変数
    private int[] canvasChild = new int[2] {1, 2 };

    // カーソルの位置を数値で管理する変数
    private int cursorNumber = 0;

    // カーソルの最大移動量を制限する変数
    private int cursorMax;

    // 現在のカーソルナンバーを調べる変数
    private int[] cursorNumberNow;

    // 上下キーの入力を取得する変数
    private float vertical;

    // 矢印キーの入力の受付を管理する変数
    private bool isInputArrow = true;

    // キャンバスのプレハブを取得する変数
    private GameObject CanvasPrefab;

    // キャンバスを取得する変数
    private GameObject Canvas;

    // カーソルを取得する変数
    private GameObject Cursor;

    // テキストを取得する変数
    private Text text;

    // カーソルの座標をを取得する変数
    private Vector2 TextObjPos;

    // カーソルの座標をを取得する変数
    private Vector2 CursorPos;

    // テキストオブジェクトを格納する変数
    private List<GameObject> TextObj = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // キャンバスを取得
        CanvasPrefab = (GameObject)Resources.Load("Prefabs/Directing/GameOver/Canvas");

        // キャンバスを複製
        Canvas = Instantiate(CanvasPrefab);

        // キャンバスを非表示にする
        Canvas.SetActive(false);

        // カーソルを取得
        Cursor = Canvas.transform.GetChild(canvasChild[0]).gameObject;

        // テキストオブジェクトの数だけ要素数を追加
        cursorNumberNow = new int[TextObjMax];

        // 一定数テキストオブジェクトをリストに格納する
        for (int i = 0; i < TextObjMax; i++)
        {
            // テキストオブジェクトをリストに追加
            TextObj.Add(Canvas.transform.GetChild(i + canvasChild[1]).gameObject);

            // テキストオブジェクトにY座標を代入
            TextObjPos.y = TextObjPosYOffset - TextObjPosYOffset * i;

            // テキストオブジェクトの座標を初期化
            TextObj[i].transform.localPosition = TextObjPos;

            // 要素に値を代入
            cursorNumberNow[i] = i;
        }

        // テキストオブジェクトの座標を取得
        CursorPos = TextObj[0].transform.localPosition;

        // カーソルにX座標を代入
        CursorPos.x -= CursorPosXOffset;

        // カーソルの座標を初期化
        Cursor.transform.localPosition = CursorPos;

        // カーソルの最大移動値を取得
        cursorMax = TextObjMax - CursorMaxOffset;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR // デバック

        // コントロールキー(左)が入力されている、かつVキーが入力されたらゲームオーバー画面を表示する
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.V))
        {
            Display();
        }
#endif
    }

    /// <summary>
    /// ゲームオーバー画面を表示する処理
    /// </summary>
    public void Display()
    {
        StartCoroutine("InputKey");
    }

    /// <summary>
    /// キー入力処理
    /// </summary>
    private IEnumerator InputKey()
    {
        // ゲームオーバー演出を待つ
        yield return new WaitForSeconds(DerayTime);

        // キャンバスを表示する
        Canvas.SetActive(true);

        // 毎フレーム更新
        while (true)
        {
            // 上下キーの入力を取得
            vertical = Input.GetAxis("Vertical");

            // バーティカルの値が0なら矢印キーの入力を受け付けを再開する
            if (vertical == VerticalAxis)
            {
                isInputArrow = true;
            }

            // 上下どちらかのキーが入力されたらカーソルを動かす
            if (isInputArrow && (vertical < VerticalAxis || vertical > VerticalAxis))
            {
                CursorMove();

                // 矢印キーの入力の受付を一時的に止める
                isInputArrow = false;
            }

            // 決定キーが入力されたらシーン遷移をする
            if(Input.GetButtonDown("Submit"))
            {
                SelectScreen();

                // 処理を終了
                yield break;
            }

            // 次のフレームまで待機
            yield return null;
        }
    }

    /// <summary>
    /// カーソルの移動処理
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
                CursorPos.y = TextObj[cursorNumber].transform.localPosition.y;

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
                CursorPos.y = TextObj[cursorNumber].transform.localPosition.y;

                // カーソルの座標を更新
                Cursor.transform.localPosition = CursorPos;
            }
        }

        // 処理を終了
        return;
    }

    /// <summary>
    /// シーン遷移処理
    /// </summary>
    private void SelectScreen()
    {
        // 現在のステージをリトライ
        if (cursorNumberNow[0] == cursorNumber)
        {
            // 現在のシーンを取得
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // シーンをリロード
            SceneManager.GetActiveScene();

        }

        // セレクト画面へ遷移
        if (cursorNumberNow[1] == cursorNumber)
        {
            SceneManager.LoadScene("SelectStage");
        }

        // 処理を終了
        return;
    }
}