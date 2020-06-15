using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームスタートの演出処理
/// 担当：笹之内
/// </summary>
public class StartDirecting : MonoBehaviour
{
    // カウントを待つ変数
    public bool ISWaitingStart { get; set; } = true;

    // ステージ番号を修正する変数
    private const int StageNumberOffsetThirdd = 1;

    // ステージ番号のフォントサイズを変更す変数
    private const int StageNumberFontSize = 120;

    // ステージ番号背景が目的地までに着く時間
    private const float StageNumberBackGroundTimeMove = 0.75f;

    // "-"と表示させる変数
    private const string HyphenText = ("  -  ");

    // ステージの面の総数
    private const int StageWorldMax = 5;

    // ステージレベル数の種類
    private const int StageLevelMax = 3;

    // カウントダウンをする秒数
    private const int CountDownMax = 3;

    // カウントダウンが終了するライン
    private const int CountDownMin = 0;

    // カウントダウンを更新するまでのクールタイム
    private const int CountCoolTime = 1;
 
    // カウントダウンのローテーション値の変動値
    private const float CountDownRotationSpeed = 0.02f;

    // カウントダウンのアルファー値の変動値
    private const float CountDownAlphaSpeed = 0.01f;

    // カウントダウンのスケール値の変動値
    private const float CountDwonScaleSpeed = 0.02f;

    // スタートのフォントのサイズ値
    private const int StartFontSize = 100;

    // スタートのアルファー値を変動させる変数
    private const float StartAlphaSpeed = 0.01f;

    // "スタート"と表示させる変数
    private const string StartText = ("スタート");

    // テキストのアルファー値が終了するライン
    private const int TextAlphaEnd = 0;

    // キャンバスのプレハブを取得するオブジェクト
    private GameObject CanvasPrefab;

    // キャンバスを取得するオブジェクト
    private GameObject Canvas;

    // ステージの面を取得する変数
    private int stageWorld;

    // 現在のステージの面を調べる変数
    private int[] stageWorldNow = new int[5] {2, 6, 10, 15, 20};

    // ステージのレベルを取得する変数
    private int stageLevel;

    // ステージ番号を取得する変数
    private int stageNumber;

    // 現在のステージ番号を調べる変数
    private int[] stageNumberNow = new int[3] {2, 10, 21};

    // ステージ番号を表示する際に数値を修正する
    private int[] stageNumberOffSetFirst = new int[3] {0, 1, 4 };
    private int[] stageNumberOffSetSecond = new int[3] {3, 4, 5 };

    // 各ステージごとの色データの変数
    private List<string> StageNumberColorCode = new List<string>
    {
        "#72fdfd",
        "#fddf72",
        "#fd72a1",
        "#8dfd72",
        "#9a72fd",
        "#000000"
    };

    // ステージ番号を取得するオブジェクト
    private GameObject StageNumber;

    // ステージ番号のテキストを取得する変数
    private Text StageNumberText;

    // ステージ番号背景のデータを取得する変数
    private string stageNumberbackGroundFile = "Textures/StartDirecting/StageNumberBackGround";

    // ステージ番号背景を取得するオブジェクト
    private GameObject StageNumberBackGround;

    // ステージ番号背景の画像を取得する変数
    private Image StageNumberBackGroundImage;

    // ステージ番号背景の画像を取得する変数
    private Sprite StageNumberBackGroundSprite;

    // ステージ番号背景と目的地までの距離を取得する変数
    private Vector2 StageNumberBackGroundDistance;

    // ステージ番号背景の座標を変動させる変数
    private Vector2 StageNumberBackGroundDestination = new Vector2(730, 400);

    // ステージ番号背景の動く速さ取得する変数
    private Vector2 StageNumberBackGroundMoveSpeed;

    // ステージ番号背景のスケールを取得する変数
    private Vector3 StageNumberBackGroundScale;

    // ステージ番号背景のサイズを変更する変数
    private Vector2 StageNumberBackGroundRectTransformValue = new Vector2(400, 250);

    // ステージ番号背景のサイズを取得する変数
    private RectTransform StageNumberBackGroundRectTransform;

    // 現在のカウントを取得する変数
    private int count;

    // カウントダウンのアルファー値の初期値を取得する変数
    private float CountDownAlphaInitialization;

    // カウントダウンを取得するオブジェクト
    private GameObject CountDown;

    // カウントダウンのテキストを取得する変数
    private Text CountDownText;

    // カウントダウンのローテーションを取得する変数
    private Quaternion CountDownRotation;

    // カウントダウンのローテーションの初期値を取得する変数
    private Quaternion CountDownRotationInitialization;

    // カウントダウンのスケールを取得する変数
    private Vector3 CountDwonScale;

    // カウントダウンのスケールの初期値を取得する変数
    private Vector3 CountDownScaleInitialization;

    // テキストの座標を取得する変数
    private Vector2 TextPosition;

    // テキストのカラーを取得する変数
    private Color TextColor;

    // チュートリアルを参照する変数
    private Tutorial tutorial;

    // チュートリアルを取得するオブジェクト
    private GameObject TutorialObj;

    // Start is called before the first frame update
    void Start()
    {
        // キャンバスを取得
        CanvasPrefab = (GameObject)Resources.Load("Prefabs/Directing/Start/Canvas");

        // チュートリアルを取得
        TutorialObj = GameObject.Find("TutorialController");

        // チュートリアルを参照
        tutorial = TutorialObj.GetComponent<Tutorial>();

        // キャンバスを複製
        Canvas = Instantiate(CanvasPrefab);

        // ステージ番号背景を取得
        StageNumberBackGround = Canvas.transform.GetChild(0).gameObject;

        // ステージ番号背景をイメージを取得
        StageNumberBackGroundImage = StageNumberBackGround.GetComponent<Image>();

        // ステージ番号背景を非表示にする
        StageNumberBackGround.SetActive(false);

        // ステージ番号を取得
        StageNumber = StageNumberBackGround.transform.GetChild(0).gameObject;

        // カウントダウンを取得
        CountDown = Canvas.transform.GetChild(1).gameObject;

        // カウントダウンを非表示にする
        CountDown.SetActive(false);

        // テキストのローテーション値の初期値を取得
        CountDownRotationInitialization = CountDown.transform.localRotation;
        
        // テキストのローテーション値に初期値を代入
        CountDownRotation = CountDownRotationInitialization;

        // テキストのスケール値の初期値を取得
        CountDownScaleInitialization = CountDown.transform.localScale;

        // テキストのスケール値に初期値を代入
        CountDwonScale = CountDownScaleInitialization;

        // ステージ番号のテキストを取得
        StageNumberText = StageNumber.GetComponent<Text>();

        // カウントダウンのテキストを取得
        CountDownText = CountDown.GetComponent<Text>();

        // テキストのアルファー値の初期値を取得
        CountDownAlphaInitialization = CountDownText.color.a;

        // テキストのアルファー値に初期値を代入
        TextColor.a = CountDownAlphaInitialization;

        // ステージ番号を取得
        stageNumber = SelectStage.SceneController.number;

        // ステージ番号を更新
        for(int i = 0; i < StageLevelMax; i++)
        {
            // ステージの面ごとにステージのレベルを変える
            if(stageNumber <= stageNumberNow[i])
            {
                // ステージの面を取得
                stageWorld = (stageNumber + stageNumberOffSetFirst[i]) / stageNumberOffSetSecond[i] + StageNumberOffsetThirdd;

                // ステージのレベルを取得
                stageLevel = (stageNumber + stageNumberOffSetFirst[i]) % stageNumberOffSetSecond[i] + StageNumberOffsetThirdd;

                // 処理を終了する
                break;
            }
        }

        // ステージ番号のテキストカラーを更新
        for(int i = 0; i < StageWorldMax; i++)
        {
            // ステージの面ごとにステージ番号のテキストカラーを変える
            if (stageNumber <= stageWorldNow[i])
            {
                // ステージ番号のテキストカラーをステージごとに変更
                ColorUtility.TryParseHtmlString(StageNumberColorCode[i], out TextColor);

                // ステージ番号のテキストカラーを更新
                StageNumberText.color = TextColor;

                // ステージ番号背景画像を取得
                StageNumberBackGroundSprite = Resources.Load<Sprite>(stageNumberbackGroundFile + i.ToString());

                // ステージ番号背景画像を更新
                StageNumberBackGroundImage.sprite = StageNumberBackGroundSprite;

                // 処理を終了する
                break;
            }
        }

        // カウントダウンをする秒数を代入
        count = CountDownMax;

        // スタート演出を表示
        StartCoroutine("Display");
    }

    // Update is called isOnce per frame
    void Update()
    {

    }

    /// <summary>
    /// スタート演出の表示処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator Display()
    {
        // 毎フレーム更新
        while(true)
        {
            // チュートリアルが終ればスタート演出に入る
            if (tutorial.ISWaitingStart == false)
            {
                // 次のフレームを待機
                yield return null;

                // ステージ番号の表示
                StartCoroutine("StageNumberDisplay");

                yield break;
            }

            // 次のフレームを待機
            yield return null;
        }
    }

    /// <summary>
    /// ステージ番号の表示処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator StageNumberDisplay()
    {
        // ステージ番号をの背景を表示
        StageNumberBackGround.SetActive(true);

        // ステージ番号のテキストを更新
        StageNumberText.text = stageWorld.ToString() + HyphenText + stageLevel.ToString();

        // 毎フレーム更新
        while(true)
        {
            // 決定キーが入力されたらカウントダウンを開始する
            if (Input.GetButtonDown("Submit"))
            {
                // テキストカラーを黒に変更
                ColorUtility.TryParseHtmlString(StageNumberColorCode[5], out TextColor);

                // テキストカラーを更新
                CountDownText.color = TextColor;

                // 秒数の初期値を代入
                CountDownText.text = count.ToString();

                // テキストを表示する
                CountDown.SetActive(true);

                // ステージ番号を移動
                StartCoroutine("StageNumberMove");

                // クールタイムを呼び出す
                StartCoroutine("CoolTime");

                // カウントダウンを表示
                StartCoroutine("CountDownMove");

                // 処理を終了
                yield break;
            }

            // 次のフレームまで待機
            yield return null;
        }
    }

    /// <summary>
    /// ステージ番号を画面端に移動させる
    /// </summary>
    /// <returns></returns>
    private IEnumerator StageNumberMove()
    {
        // ステージ番号背景の座標を取得
        TextPosition = StageNumberBackGround.transform.localPosition;

        // ステージ番号背景と目的地までの距離を取得
        StageNumberBackGroundDistance = StageNumberBackGroundDestination - TextPosition;

        // ステージ番号背景が動くスピードを取得
        StageNumberBackGroundMoveSpeed = StageNumberBackGroundDistance / StageNumberBackGroundTimeMove;

        // ステージ番号背景のスケールを取得
        StageNumberBackGroundScale = StageNumber.transform.localScale;

        // ステージ番号背景のサイズを取得
        StageNumberBackGroundRectTransform = StageNumberBackGround.GetComponent<RectTransform>();

        // ステージ番号背景のサイズを変更
        StageNumberBackGroundRectTransform.sizeDelta = StageNumberBackGroundRectTransformValue;

        // ステージ番号背景のスケールを更新
        StageNumberBackGround.transform.localScale = StageNumberBackGroundScale;

        // ステージ番号のフォントサイズを変更
        StageNumberText.fontSize = StageNumberFontSize;

        // 毎フレーム更新
        while (true)
        {
            // ステージ番号背景に座標を代入
            TextPosition += StageNumberBackGroundMoveSpeed * Time.deltaTime;

            // ステージ番号背景の座標を更新
            StageNumberBackGround.transform.localPosition = TextPosition;

            // ステージ番号背景が一定の座標を超えたら動きを止める
            if(TextPosition.x >= StageNumberBackGroundDistance.x
            && TextPosition.y >= StageNumberBackGroundDistance.y)
            {
                // ステージ番号背景の座標を修正
                TextPosition = StageNumberBackGroundDistance;

                // ステージ番号背景の座標を更新
                StageNumberBackGround.transform.localPosition = TextPosition;

                // 処理を終了する
                yield break;
            }

            // 次のフレームまで待機
            yield return null;
        }
    }

    /// <summary>
    /// 1秒間待つ
    /// </summary>
    /// <returns></returns>
    private IEnumerator CoolTime()
    {
        // 一定時間待つ
        yield return new WaitForSeconds(CountCoolTime);

        // テキストを初期化
        TextInitialization();

        // 処理を終了する
        yield break;
    }

    /// <summary>
    /// テキストの初期化
    /// </summary>
    private void TextInitialization()
    {
        // カウントを減少
        count--;

        // テキストのローテーション値に初期値を代入
        CountDownRotation = CountDownRotationInitialization;

        // テキストのローテーション値を初期化
        CountDown.transform.localRotation = CountDownRotation;

        // テキストのスケール値に初期値を代入
        CountDwonScale = CountDownScaleInitialization;

        // テキストのスケール値を初期化
        CountDown.transform.localScale = CountDwonScale;

        // テキストのアルファー値に初期値を代入
        TextColor.a = CountDownAlphaInitialization;

        // テキストのアルファー値を初期化
        CountDownText.color = TextColor;

        // カウントが定数値以下ならスタートを表示
        if (count <= CountDownMin)
        {
            // スタートを表示する
            StartCoroutine("StartMove");

            // 処理を終了する
            return;
        }
        else
        {
            // 秒数を更新
            CountDownText.text = count.ToString();

            // クールタイムを呼び出す
            StartCoroutine("CoolTime");

            // 処理を終了する
            return;
        }
    }

    /// <summary>
    /// カウントダウンの挙動処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator CountDownMove()
    {
        // 毎フレーム更新
        while (true)
        {
            // スタートを表示するまでカウントする
            if (ISWaitingStart)
            {
                // カウントダウンを回転させる
                CountDownRotation.z -= CountDownRotationSpeed;

                // カウントダウンのローテーション値を更新
                CountDown.transform.localRotation = CountDownRotation;

                // カウントダウンのスケール値を下げる
                CountDwonScale.x -= CountDwonScaleSpeed; // スケール値Xを下げる
                CountDwonScale.y -= CountDwonScaleSpeed; // スケール値Yを下げる

                // カウントダウンのスケール値を更新
                CountDown.transform.localScale = CountDwonScale;

                // カウントダウンのアルファー値を下げる
                TextColor.a -= CountDownAlphaSpeed;

                // カウントダウンのアルファー値を更新
                CountDownText.color = TextColor;
            }
            else
            {
                // 処理を終了する
                yield break;
            }

            // 次のフレームまで待機
            yield return null;
        }
    }

    /// <summary>
    /// スタートの挙動処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartMove()
    {
        // スタートのフォントのサイズ値を代入
        CountDownText.fontSize = StartFontSize;

        // スタートを表示する
        CountDownText.text = StartText;

        // ゲームを開始する
        ISWaitingStart = false;

        // 毎フレーム更新する
        while(true)
        {
            // テキストのアルファー値が定数値以下ならカウントダウンを消す
            if (TextColor.a < TextAlphaEnd)
            {
                Destroy(CountDown);

                // 処理を終了する
                yield break;
            }
            else
            {
                // テキストのスケール値を上げる
                CountDwonScale.x += CountDwonScaleSpeed; // スケール値Xを上げる
                CountDwonScale.y += CountDwonScaleSpeed; // スケール値Yを上げる

                // テキストのスケール値を代入
                CountDown.transform.localScale = CountDwonScale;

                // テキストのアルファー値を下げる
                TextColor.a -= StartAlphaSpeed;

                // テキストのアルファー値を代入
                CountDownText.color = TextColor;
            }

            // 次のフレームまで待機する
            yield return null;
        }
    }
}