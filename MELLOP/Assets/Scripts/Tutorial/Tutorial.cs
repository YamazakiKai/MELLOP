using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Tutorial : MonoBehaviour
{
    // スタートを待つフラグ
    public bool ISWaitingStart { get; set; } = true;

    // チュートリアルテキストの最大表示数
    private const int TextMax = 4;

    // 矢印の最大表示数
    private const int ArrowMax = 2;

    // 矢印の最大スケール値の倍率値
    private const float ArrowScaleMagnification = 1.3f;

    // 矢印を左右反転を行う変数
    private const int ArrowScaleReverse = -1;

    // チュートリアルステージの番号
    private const int TutorialStage = 0;

    // 現在のステージ番号を取得する変数
    private int stageNumber;

    // キャンバスのプレハブを取得するオブジェクト
    private GameObject CanvasPrefab;

    // キャンバスを取得するオブジェクト
    private GameObject Canvas;

    // チュートリアルテキストを切り替えた回数をカウントする変数
    private int textCount = 0;

    // チュートリアルテキストのファイルデータを取得する変数
    private string TutorialTextFile = "Textures/Tutorial/TutorialText";

    // チュートリアルテキストを取得するオブジェクト
    private GameObject TutorialText;

    // チュートリアルテキストの画像を取得する変数
    private Sprite TutorialTextSprite;

    // チュートリアルテキストの<Image>を取得する変数
    private Image TutorialTextImage;

    // チュートリアルテキストの座標に値を入れる変数
    private List<Vector2> TutorialTextPos = new List<Vector2>
    {
        new Vector2(0,-300),
        new Vector2(-250,-300),
        new Vector2(0,-300),
        new Vector2(0,-300),
    };

    // チュートリアルテキストの初期座標を取得する変数
    private Vector2 TutorialTextPosInitialization;

    // 矢印のスケール値を変動させる変数
    private float arrowScaleSpeed = 0.012f;

    // 矢印の最大スケール値を取得する変数
    private float arrowScaleMax;

    // 矢印のスケール値を取得する変数
    private float arrowScaleNormal;

    // 矢印のマイナススケール値を取得する変数
    private float arrowScaleAnotherNormal;

    // 矢印の最小スケール値を取得する変数
    private float arrowScaleMin;

    // 矢印2の表示を管理する変数
    private List<bool> SecondArrowDisplay = new List<bool>
    {
        false,
        true,
        false,
        false,
    };

    // 矢印のプレハブを取得するオブジェクト
    private GameObject ArrowPrefab;

    // 矢印を取得するオブジェクト
    private List<GameObject> Arrow = new List<GameObject>();

    // 矢印1の座標を取得する変数
    private List<Vector2> FirstArrowPos = new List<Vector2>
    {
        new Vector2(-100, 300),
        new Vector2(300, 100),
        new Vector2(-600, 0),
    };
    
    // 矢印2の座標を取得する変数
    private List<Vector2> SecondArrowPos = new List<Vector2>
    {
        new Vector2(0, 0),
        new Vector2(500, -300),
        new Vector2(0, 0),
        new Vector2(0, 0),
    };

    // 矢印1の座標を修正する変数
    private Vector2 FirstArrowPosOffSet = new Vector2(-300, 50);

    // 矢印のスケール値を取得する変数
    private Vector2 ArrowScale;

    // 矢印の初期スケール値を取得する変数
    private List<Vector2> ArrowScaleInitialization = new List<Vector2>
    {
        new Vector2(1,1),
        new Vector2(1,1),
        new Vector2(-1,-1),
        new Vector2(-1,-1),
    };

    // ヒントが表示されているUIを取得する変数
    private GameObject SkipPauseUi;

    // ヒントが表示されているUIの座標を取得する変数
    private Vector2 SkipPauseUiPos;

    // 音源を取得する変数
    private AudioSource audioSource;

    // 決定音を取得する変数
    private AudioClip SoundEffectDecision;

    // Start is called before the first frame update
    void Start()
    {
        // 現在のステージ番号を取得
        stageNumber = SelectStage.SceneController.number;

        // チュートリアルステージであればチュートリアルを表示する
        if (stageNumber == TutorialStage)
        {
            // キャンバスのプレハブを取得
            CanvasPrefab = (GameObject)Resources.Load("Prefabs/Tutorial/Canvas");

            // 矢印のプレハブを取得
            ArrowPrefab = (GameObject)Resources.Load("Prefabs/Tutorial/Arrow");

            // スキップを取得
            SkipPauseUi = GameObject.Find("Canvas/SkipPauseUi");

            // 音源を取得
            audioSource = GetComponent<AudioSource>();

            // 決定音を取得
            SoundEffectDecision = Resources.Load<AudioClip>("Sounds/Tutorial/3.12");

            // キャンバスを複製する
            Canvas = Instantiate(CanvasPrefab);

            // キャンバスからチュートリアルテキストを取得
            TutorialText = Canvas.transform.GetChild(0).gameObject;

            // チュートリアルテキストの初期座標を取得
            TutorialTextPosInitialization = TutorialText.transform.localPosition;

            // チュートリアルテキストの画像を取得
            TutorialTextImage = TutorialText.GetComponent<Image>();

            // 最初のチュートリアルテキストを取得
            TutorialTextSprite = Resources.Load<Sprite>(TutorialTextFile + textCount.ToString());

            // チュートリアルテキストの画像を更新
            TutorialTextImage.sprite = TutorialTextSprite;

            // 矢印を複製
            for(int i = 0; i < ArrowMax; i++)
            {
                Arrow.Add(Instantiate(ArrowPrefab));

                // 矢印をキャンバスに格納
                Arrow[i].transform.SetParent(Canvas.transform, false);
            }

            // 矢印のスケール値を初期化
            ArrowScale = ArrowScaleInitialization[0];

            // 矢印の最大スケール値を取得
            arrowScaleMax = ArrowScale.x * ArrowScaleMagnification;

            // 矢印のスケール値を取得
            arrowScaleNormal = ArrowScale.x;

            // 矢印のマイナススケール値を取得
            arrowScaleAnotherNormal = arrowScaleNormal * ArrowScaleReverse;

            // 矢印の最大スケール値を取得
            arrowScaleMin = arrowScaleMax * ArrowScaleReverse;

            // ヒントUIの座標を取得
            SkipPauseUiPos = SkipPauseUi.transform.localPosition;

            // 矢印1の座標を修正
            SkipPauseUiPos += FirstArrowPosOffSet;

            // ヒントUIの座標を取得
            FirstArrowPos.Add(SkipPauseUiPos);

            // 各UIの初期化
            UISet();

            // 矢印を拡大縮小する
            StartCoroutine("ArrowScaling");

            // テキストを切り替える
            StartCoroutine("Display");
        }
        else // カウントダウンを開始
        {
            ISWaitingStart = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// チュートリアルを表示する処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator Display()
    {
        // 毎フレーム更新
        while (true)
        {
            // 決定キーが入力されたらテキストを切り替える
            if (Input.GetButtonDown("Submit"))
            {
                // 決定音を鳴らす
                audioSource.PlayOneShot(SoundEffectDecision);

                // テキストを切り替えた回数をカウント
                textCount++;

                // 最後のテキストが表示されるまでテキストの切り替えを行う
                if (textCount < TextMax)
                {
                    // チュートリアルテキストを取得
                    TutorialTextSprite = Resources.Load<Sprite>(TutorialTextFile + textCount.ToString());

                    // チュートリアルテキストの画像を更新
                    TutorialTextImage.sprite = TutorialTextSprite;

                    // 各UIの初期化
                    UISet();
                }
                else // 最後のテキストを表示してたら処理を終了
                {
                    // キャンパスを消す
                    Destroy(Canvas.gameObject);

                    // ゲームをスタート
                    ISWaitingStart = false;

                    // 処理を終了
                    yield break;
                }
            }

            // 次のフレームまで待機
            yield return null;
        }
    }

    /// <summary>
    /// 各場面に合わせて各UIの挙動を設定する処理
    /// </summary>
    private void UISet()
    {
        // 矢印2の表示を更新
        Arrow[1].SetActive(SecondArrowDisplay[textCount]);

        // 矢印1の座標を更新
        Arrow[0].transform.localPosition = FirstArrowPos[textCount];

        // 矢印2の座標を更新
        Arrow[1].transform.localPosition = SecondArrowPos[textCount];
        
        // 矢印のスケール値を初期化
        ArrowScale = ArrowScaleInitialization[textCount];

        // チュートリアルテキストの座標を更新
        TutorialText.transform.localPosition = TutorialTextPos[textCount];
    }

    /// <summary>
    /// 矢印を拡大縮小する処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator ArrowScaling()
    {
        // 毎フレーム更新
        while (true)
        {
            // カウントダウンが開始したら処理を終了
            if (!ISWaitingStart)
            {
                yield break;
            }

            // 矢印のスケール値を変動
            ArrowScale.x += arrowScaleSpeed;
            ArrowScale.y += arrowScaleSpeed;

            // 矢印のスケール値を更新
            for(int i = 0; i< ArrowMax; i++)
            {
                Arrow[i].transform.localScale = ArrowScale;
            }

            // 場面3以降は処理を変える
            if(textCount >= 2)
            {
                // 矢印が一定の数値を越したら拡大縮小を逆転する
                if (ArrowScale.x > arrowScaleAnotherNormal
                || ArrowScale.x < arrowScaleMin)
                {
                    // 値を逆転する
                    arrowScaleSpeed = arrowScaleSpeed * ArrowScaleReverse;
                }
            }
            else
            {
                // 矢印が一定の数値を越したら拡大縮小を逆転する
                if (ArrowScale.x > arrowScaleMax
                || ArrowScale.x < arrowScaleNormal)
                {
                    // 値を逆転する
                    arrowScaleSpeed = arrowScaleSpeed * ArrowScaleReverse;
                }
            }

            // 次のフレームまで待機
            yield return null;
        }
    }
}