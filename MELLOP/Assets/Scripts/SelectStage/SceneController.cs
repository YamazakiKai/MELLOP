using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelectStage
{
    /// <summary>
    /// セレクトステージのシーン管理
    /// 担当：山崎
    /// </summary>
    public class SceneController : MonoBehaviour
    {
        //このクラスのシングルトンインスタンス
        public static SceneController Instance { get; private set; } = null;

        // Gameシーンで参照するためpublicでstaticな変数にする
        public static int number;
        // ステージクリアチェック配列
        private static bool[] StageReleaseFlags = new bool[21];
        // 生成するステージの数(この数を変更するだけでステージ複製可)
        private static int StageNum = 21;

        // コマンド入力処理チェック
        private bool Processing = true;
        bool sceneFlag = false;
        bool Move = false;  // stageの移動フラグ
        // stageの移動スピード
        [SerializeField]
        public float speed = 0.3f;

        // 移動用ターゲット
        Vector3 Target;

        // stage親オブジェクト
        GameObject StageParent;
        // 子オブジェクトの格納変数
        GameObject Child;

        // 選択カーソル
        GameObject Cursor;
        Vector2 CursorPos;
        // ステージ
        Stage stage;

        // サウンド
        AudioSource audioSource;
        [SerializeField]
        AudioClip Scroll;   // スクロール音
        [SerializeField]
        AudioClip Decision; // 決定音
        
        // Start is called before the first frame update
        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else if (!(Instance == this))
            {
                Destroy(gameObject);
                return;
            }
        }
        void StartScene()
        {
            // コマンド入力許可
            Processing = true;
            // コンポーネントの取得
            audioSource = GetComponent<AudioSource>();
            // Cursorのポジション取得
            Cursor = GameObject.Find("Cursor");
            CursorPos = Cursor.transform.position;
            // 管理オブジェクトの参照
            StageParent = GameObject.Find("StagesParent");
            // 一番最初のステージは解放状態にいておきたいのでtrue
            StageReleaseFlags[0] = true;
            // ステージ数のList
            var StageNunber = new List<int>();
            for (int i = 0; i < StageNum; i++)
            {
                // Listに値を追加
                StageNunber.Add(i);
                // stageをロードして管理オブジェクトの子オブジェクトにする
                stage = (Instantiate(Resources.Load("Prefabs/stage"), StageParent.transform) as GameObject).GetComponent<Stage>(); ;
                // それぞれに番号を与える
                stage.number = StageNunber[i]; // ステージ番号
                // ステージのクリア情報を入れる
                stage.ClearFlag = StageReleaseFlags[i];
            }
            // 直前に遊んだステージにポジションセット
            Target = StageParent.transform.position;
            Target.x = number * -stage.WidthInterval;
            StageParent.transform.position = Target;
        }

        // Update is called once per frame
        void Update()
        {
            if (!(SceneManager.GetActiveScene().name == "SelectStage"))
            {
                sceneFlag = false;
                return;
            }
            else if (sceneFlag == false)
            {
                sceneFlag = true;
                // start
                StartScene();
                //return;
            }
            // 選択カーソルが何番のステージを選んでるか検索
            Search();
            // コマンド入力処理
            InputCommand();
            // 移動
            if (Move)
            {
                // ステージ移動
                StageMove();
            }
        }

        /// <summary>
        /// コマンド入力
        /// </summary>
        void InputCommand()
        {
            // Horizontalの値を取得
            var horizontal = Input.GetAxis("Horizontal");
            // XBOXコントローラーのLB、RBの値取得
            var action_LB = Input.GetAxis("Action_LB");
            var action_RB = Input.GetAxis("Action_RB");

            // コマンド入力処理中かチェック
            if (Processing)
            {
                // ゲームパットの左スティックまたはLB、RB入力時
                if (action_LB > 0 || action_RB > 0 ||
                    horizontal > 0 || horizontal < 0)
                {
                    // 処理が終わるまで他のコマンドを入力させない
                    Processing = false;
                    // 右移動(RBまたは左スティックを右に傾ける)
                    if (action_RB > 0 || horizontal > 0)
                    {
                        // 次の移動先にステージがない時移動させない
                        if (number == StageNum - 1)
                        {
                            // 移動先のターゲットに現在位置を代入
                            Target.x = StageParent.transform.position.x;
                            stage.Scale();
                        }
                        else
                        {
                            audioSource.PlayOneShot(Scroll);
                            // 右隣のステージまでの距離分ｘ座標に値をセット
                            Target.x -= stage.WidthInterval;
                        }
                        // 右移動
                        Move = true;
                    }
                    // 左移動(LBまたは左スティックを左に傾ける)
                    else if (action_LB > 0 || horizontal < 0)
                    {
                        // 次の移動先にステージがない時移動させない
                        if (number == 0)
                        {
                            // 移動先のターゲットに現在位置を代入
                            Target.x = StageParent.transform.position.x;
                            stage.Scale();
                        }
                        else
                        {
                            // スクロール音
                            audioSource.PlayOneShot(Scroll);
                            // 左隣のステージまでの距離分ｘ座標に値をセット
                            Target.x += stage.WidthInterval;
                        }
                        // 左移動
                        Move = true;
                    }
                }
                // LB、RB、左スティックどれも入力してない時
                else if (action_LB == 0 || action_RB == 0 ||
                         horizontal == 0)
                {
                    // 移動処理が終了したまたは何も入力してないときは入力許可
                    Processing = true;
                    // 選択ステージの拡大処理
                    stage.Scale();
                }

                // 決定(ゲームシーンに遷移)
                if (stage.ClearFlag && Input.GetButtonDown("Submit"))
                {
                    // 処理が終わるまで他のコマンドを入力させない
                    Processing = false;
                    // 決定音
                    audioSource.PlayOneShot(Decision);
                    // サウンドが鳴り終わったら関数呼び出し
                    Invoke("SceneLoader", Decision.length);
                }
                // タイトルに戻る
                if (Input.GetButtonDown("Fire3"))
                {
                    // 処理が終わるまで他のコマンドを入力させない
                    Processing = false;
                    SceneManager.LoadScene("TitleScene");
                }
                // デバック F5が入力されたら全ステージを解放
                if (Input.GetKeyDown(KeyCode.F5))
                {
                    // クリア状態管理配列すべてをtrueにする
                    for (int i = 0; i < StageNum; i++)
                    {
                        StageReleaseFlags[i] = true;
                        stage.Clear();
                    }
                    Debug.Log("裏コマンド:F5を認証　全ステージ解放");
                }
            }
        }

        /// <summary>
        /// 何番目のステージを選択してるか検索
        /// </summary>
        void Search()
        {
            // Stage管理オブジェクトの子オブジェクトすべてを調べる
            for (int i = 0; i < StageNum; i++)
            {
                // 子オブジェクト格納
                Child = StageParent.transform.GetChild(i).gameObject;
                // 子オブジェクトのポジション取得
                Vector2 ChildPos = Child.transform.position;
                // コンポーネントの取得
                stage = Child.GetComponent<Stage>();
                // 裏コマンド用：それぞれのステージにクリア報告を送る
                stage.ClearFlag = StageReleaseFlags[i];

                // Cursorと同じ位置にあるオブジェクトのNumberを取得
                if (ChildPos == CursorPos)
                {
                    // Stageのナンバーを取得
                    number = stage.number;

                    break;
                }
            }
        }

        /// <summary>
        /// 移動
        /// </summary>
        void StageMove()
        {
            // 指定したオブジェクトまで移動
            StageParent.transform.position = Vector2.MoveTowards(StageParent.transform.position, Target, speed);
            // 到着
            if (StageParent.transform.position == Target)
            {
                // 初期化
                Move = false;
                Processing = true;
            }
        }

        // シーン遷移
        private void SceneLoader()
        {
            //SceneManager.sceneLoaded += GameSceneLoad;
            // シーン遷移
            SceneManager.LoadScene("GameScene");
            //Debug.Log(number);
        }

        // クリアの報告
        public static void ReleaseReport()
        {
            // 今遊んでいたステージの次のステージのクリア情報を書き換え
            if(number != StageNum - 1)
            {
                StageReleaseFlags[number + 1] = true;
            }
        }

        // シーン遷移の際に呼び出す処理
        private void GameSceneLoad(Scene next , LoadSceneMode mode)
        {
            var StageData = GameObject.Find("stage").GetComponent<Stage>();
        }

        
    }
}
