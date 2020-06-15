using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// テキストの動作制御
/// 担当：笹之内
/// </summary>
public class PressButton : MonoBehaviour
{
    // テキストの拡大縮小を変更する変数
    private const int ScaleReverse = -1;
    
    // テキストスケールが最大まで大きくなる倍率
    private const float ScaleMagnification = 1.1f;

    // テキストが拡大縮小する初期の速さ
    private const float ScaleSpeedInitialization = 0.001f;

    // テキストの現在の透明度を調べる
    private const int AlphaValue = 0;

    // 透明度を変更する速さ
    private const float AlphaSpeed = 0.01f;

    // テキストが拡大縮小する速さを格納する変数
    private float scaleSpeed;

    // テキストの最大スケール値を格納する変数
    private float scaleMaxX;
    private float scaleMaxY;

    // テキストの最小スケール値を格納する変数
    private float scaleMinX;
    private float scaleMinY;

    // オーディオのコンポーネントを取得する変数
    private TitleScene.Audio AudioController;

    // オーディオを取得するオブジェクト
    private GameObject AudioObj;

    // テキストの色を取得するオブジェクト
    private Color color;

    // テキストを取得するオブジェクト
    private Text text;

    // テキストの初期スケールを格納する構造体
    private Vector2 ScaleInitialization;

    // テキストのスケールを格納する構造体
    private Vector2 Scale;

    // タイトルにあるオブジェクトを取得する変数
    private GameObject FaceMelt;

    // アニメーターを取得する変数
    private Animator FaceMeltAnimator;

    // シュワちゃんを取得する変数
    private GameObject Shuwa;

    // バブルを取得する変数
    private GameObject BubbleOne;
    private GameObject BubbleTwo;

    // バブルのシェーダーを取得する変数
    private Renderer BubbleOneRenderer;
    private Renderer BubbleTwoRenderer;

    // バブルのカラーを変更する変数
    private Color BubbleOneColor;
    private Color BubbleTwoColor;

    // バブルのカラーを減少させる変数
    private const float BubbleColorDecrease = 0.005f;

    // バブルのアルファー値が0かを調べる変数
    private const int BubbleRendererEndLine = 0;

    // Start is called before the first frame update
    void Start()
    {
        // オーディオを取得
        AudioObj = GameObject.Find("AudioSource");

        // オーディオのコンポーネントを取得
        AudioController = AudioObj.GetComponent<TitleScene.Audio>();

        // テキストを取得
        text = this.GetComponent<Text>();

        // テキストのカラーを取得
        color = text.color;
        
        // テキストのスケール値を代入
        ScaleInitialization = this.transform.localScale;

        // テキストの初期スケール値を代入
        Scale = ScaleInitialization;

        // テキストが拡大縮小する速さを代入
        scaleSpeed = ScaleSpeedInitialization;

        // テキストのスケール値の最大値を代入
        scaleMaxX = ScaleInitialization.x * ScaleMagnification;
        scaleMaxY = ScaleInitialization.y * ScaleMagnification;

        // テキストのスケール値の最小値を代入
        scaleMinX = ScaleInitialization.x;
        scaleMinY = ScaleInitialization.y;

        // オブジェクトを取得
        FaceMelt = GameObject.Find("title_face");

        // オブジェクトのアニメーターを取得
        FaceMeltAnimator = FaceMelt.GetComponent<Animator>();

        // シュワちゃんを取得
        Shuwa = GameObject.Find("title_face/shuwa_mouth_title");

        // バブルを取得
        BubbleOne = GameObject.Find("title_face/babbleTimeLine/Titlebabble");
        BubbleTwo = GameObject.Find("title_face/babbleTimeLine/Titlebabble2");

        // バブルのシェーダーを取得
        BubbleOneRenderer = BubbleOne.GetComponent<Renderer>();
        BubbleTwoRenderer = BubbleTwo.GetComponent<Renderer>();

        // バブルのカラーを取得
        BubbleOneColor = BubbleOneRenderer.material.GetColor("_TintColor");
        BubbleTwoColor = BubbleTwoRenderer.material.GetColor("_TintColor");

        // テキストを拡大縮小
        StartCoroutine("Scaling");
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    /// <summary>
    /// テキストスケールを拡大縮小
    /// </summary>
    /// <returns></returns>
    private IEnumerator Scaling()
    {
        // 毎フレーム更新
        while (true)
        {
            // テキストのスケールを拡大縮小
            Scale.x += scaleSpeed;
            Scale.y += scaleSpeed;

            // テキストのスケール値を代入
            this.transform.localScale = Scale;

            // テキストのスケール値が最大値より上回った、または、テキストスケールが最小値より下回った時、スケールの拡大縮小を逆転させる
            if (Scale.x > scaleMaxX && Scale.y > scaleMaxY
             || Scale.x < scaleMinX && Scale.y < scaleMinY)
            {
                scaleSpeed = scaleSpeed * ScaleReverse;
            }

            // 何かボタンが押されたらテキストを消す
            if(Input.GetButtonDown("AnyButton"))
            {
                // 効果音を鳴らす
                AudioController.RingSound();

                // スケール値を初期化
                Scale = ScaleInitialization;

                // テキストを拡大するために、変数に正の数値を代入
                scaleSpeed = ScaleSpeedInitialization;

                // アニメーターを切り替える
                FaceMeltAnimator.SetBool("FaceMelt", true);

                // テキストを消す
                StartCoroutine("Destroy");

                // バブルの追尾処理
                StartCoroutine("BubbleChase");

                // 処理を終了
                yield break;
            }

            // 次のフレームまで待機
            yield return null;
        }
    }

    /// <summary>
    /// テキストを消す
    /// </summary>
    private IEnumerator Destroy()
    {
        // 毎フレーム更新
        while(true)
        {
            // テキストスケールを拡大させる
            Scale.x += scaleSpeed;
            Scale.y += scaleSpeed;

            // テキストのスケール値を代入
            this.transform.localScale = Scale;

            // テキストの透明度を薄くする
            color.a -= AlphaSpeed;
            text.color = color;

            // テキストの透明度が一定値を下回ったら処理を終了
            if(color.a < AlphaValue)
            {
                yield break;
            }

            // 次のフレームまで待機
            yield return null;
        }
    }

    /// <summary>
    /// バブルの追尾処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator BubbleChase()
    {
        // 毎フレーム更新
        while (true)
        {
            // シュワちゃんを追尾
            BubbleOne.transform.position = Shuwa.transform.position;
            BubbleTwo.transform.position = Shuwa.transform.position;

            // バブルのアルファー値を減少
            BubbleOneColor.a -= BubbleColorDecrease;
            BubbleTwoColor.a -= BubbleColorDecrease;

            // バブルのカラーを更新
            BubbleOneRenderer.material.SetColor("_TintColor", BubbleOneColor);
            BubbleTwoRenderer.material.SetColor("_TintColor", BubbleTwoColor);
            
            // バブルが消えたら処理を終える
            if(BubbleOneColor.a <= BubbleRendererEndLine)
            {
                // バブルを消す
                Destroy(BubbleOne);
                Destroy(BubbleTwo);

                yield break;
            }

            // 次のフレームまで待機
            yield return null;
        }
    }
}