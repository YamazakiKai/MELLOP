using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// パズル全体の挙動管理
/// 担当：吉中
/// </summary>
public class PuzzleManager : MonoBehaviour
{
    // ゲームスタート演出、ポーズすべき場面の取得のみ
    [SerializeField] StartDirecting startDirecting = null;
    // ポーズ画面
    public PauseController pauseController = null;
    // GAME OVER
    [SerializeField] GameOverController gameOver = null;
    // クリア演出
    [SerializeField] ClearDirecting clearDirecting = null;

    [SerializeField] GameObject ouensekiPrefab = null;
    // 入力を手打ちしなくて良いように（ここでなく定数クラスでも作ればよかったか？
    public enum KeyAssign
    {
        UpArrow,
        DownArrow,
        RightArrow,
        LeftArrow,
        W,
        A,
        S,
        D,
        RightTrigger,
        LeftTrigger,
    }
    public static readonly string[] KeyNames =
    {
        "up",                   // UpArrow,
        "down",                 // DownArrow,
        "right",                // RightArrow,
        "left",                 // LeftArrow,
        "w",                    // W,
        "a",                    // A,
        "s",                    // S,
        "d",                    // D,
        "joystick button 5",    // RightTrigger,
        "joystick button 4",    // LeftTrigger,
    };

    // 実際のブロックの配列
    Block[] blocks;
    int rowColumn = 0;
    // 操作入力を許可するか
    public bool isMovable { get; set; } = false;

    /// <summary>
    /// ブロック全体の親オブジェクト
    /// 回転などで全体を動かすときに使用します
    /// </summary>
    GameObject puzzle = null;

    // フレーム
    GameObject frame = null;

    // 仲間レベル？の管理
    int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        blocks = StageFileReader.StageLoad(SelectStage.SceneController.number);
        rowColumn = (int)Mathf.Sqrt(blocks.Length);
        // 親オブジェクト（empty）の生成
        puzzle = new GameObject("Puzzle");
        // このスクリプトがアタッチされたオブジェクトの子に設定
        puzzle.transform.parent = transform;

        float positionOffset = (rowColumn / 2.0f - 0.5f);

        // 生成したステージブロックをpuzzleの子とし、所定の位置にセット
        for (int i = 0; i < blocks.Length; i++)
        {
            var obj = blocks[i].gameObject;
            obj.transform.parent = puzzle.transform;
            obj.transform.localPosition = new Vector2(
                i / rowColumn - positionOffset,
                i % rowColumn - positionOffset);
        }

        frame = transform.Find("Frame").gameObject;
        frame.transform.parent = puzzle.transform;
        frame.transform.localScale = new Vector3(1.0f, rowColumn / 4.0f, rowColumn / 4.0f);

        var camera = Camera.main;
        var cameraPos = camera.transform.position;
        cameraPos += new Vector3(0, 0, -(rowColumn - 4.0f));
        camera.transform.position = cameraPos;
        StartCoroutine(GameStart());
        //CreatePuzzleFrame();
    }

    // カウントダウンが終了するまで開始を待機
    IEnumerator GameStart()
    {
        // これが突然消えた
        while (startDirecting.ISWaitingStart)
            yield return null;
        foreach (var block in blocks)
            if (block is AcidBlock)
            {
                var acid = block as AcidBlock;
                acid.StartCountDown();
                isMovable = true;
                break;
            }
    }


    // Update is called once per frame
    void Update()
    {
        // コントローラ入力確認用
        {
#if UNITY_EDITOR

            for (int i = 0; i < 20; i++)
            {
                var name = "joystick button " + i.ToString();
                if (Input.GetKeyDown(name))
                    Debug.Log(name);
            }

            for (int i = 0; i < 10; i++)
                if (Input.GetKeyDown(KeyNames[i]))
                    Debug.Log(KeyNames[i]);
#endif
        }
        if (isMovable && !pauseController.ISStopGame)
        {
            if (Input.GetKeyDown(KeyNames[(int)KeyAssign.RightArrow])
            || Input.GetKeyDown(KeyNames[(int)KeyAssign.D])
            || Input.GetKeyDown(KeyNames[(int)KeyAssign.RightTrigger]))
                Rotation(RotDirection.Right);
            if (Input.GetKeyDown(KeyNames[(int)KeyAssign.LeftArrow])
            || Input.GetKeyDown(KeyNames[(int)KeyAssign.A])
            || Input.GetKeyDown(KeyNames[(int)KeyAssign.LeftTrigger]))
                Rotation(RotDirection.Left);
        }
    }

    #region 回転関係
    // 回転方向の指定に使用します。
    private enum RotDirection { Right, Left };
    /// <summary>
    /// パズルの回転を行います。
    /// </summary>
    /// <param name="direction">回転方向</param>
    void Rotation(RotDirection direction)
    {
        var buffer = new Block[blocks.Length];
        Array.Copy(blocks, buffer, blocks.Length);
        for (int y = 0; y < rowColumn; y++)
            for (int x = 0; x < rowColumn; x++)
                switch (direction)
                {
                    case RotDirection.Right:
                        buffer[(rowColumn - 1) - y + rowColumn * x] = blocks[(y * rowColumn) + x];
                        break;
                    case RotDirection.Left:
                        buffer[(y * rowColumn) + x] = blocks[(rowColumn - 1) - y + rowColumn * x];
                        break;
                }
        // ここは参照の代入でOK
        blocks = buffer;
        // 回転アニメーションを開始
        StartCoroutine(RotationAnim(direction));
    }

    /// <summary>
    /// パズルの回転に伴うアニメーション
    /// </summary>
    /// <param name="direction">回転方向</param>
    /// <returns></returns>
    IEnumerator RotationAnim(RotDirection direction)
    {
        isMovable = false;
        // 回転に合わせたアニメーションがあるAcid,Friendのみここで呼び出し
        foreach (var block in blocks)
        {
            if (block != null && block is AcidBlock)
                block.OnRotation(direction == RotDirection.Right ? Block.Rotation.Right : Block.Rotation.Left);
            if (block != null && block is FriendBlock)
                block.OnRotation(direction == RotDirection.Right ? Block.Rotation.Right : Block.Rotation.Left);
        }

        // 全体で0.5
        var duration = 0.5f;
        var _t = 0.0f;
        // 前フレームまでの回転量を保存しておく
        float angle = 0.0f;
        while (true)
        {
            _t += Time.deltaTime;
            if (_t > duration) break;
            // 0~1比率計算
            var ratio = _t / duration;
            // ease_out
            var ease = Mathf.Abs(90.0f * ratio * (ratio - 2.0f) + duration);
            // (今フレームで回転させる量)=(現フレームまでの回転量)-(前フレームまでの回転量)
            var perFrame = ease * (direction == RotDirection.Right ? -1 : 1) - angle;
            // 回転量を更新
            angle += perFrame;
            // 回転を加算
            puzzle.transform.Rotate(
                new Vector3(0, 0, 1),
                perFrame);
            yield return null;
        }
        puzzle.transform.localRotation = Quaternion.Euler(0, 0, 0);
        FixRotation(direction);
        // ここのコルーチンの流れ要整理
        yield return new WaitForSeconds(0.5f);
        isMovable = true;
    }

    // 回転後のデータを反映
    void FixRotation(RotDirection rotation)
    {
        // Acidの回転アニメーションはここでは呼び出さない（設計ミスか？
        // 矢印の方向更新を行っています
        foreach (var block in blocks)
            if (block != null && !(block is AcidBlock))
                // ここのキャストはよくなさすぎるが一旦変にいじらない前提として放置で。。。
                block.OnRotation((Block.Rotation)(int)rotation);
        // 一度落下前の状態に移動
        for (int i = 0; i < blocks.Length; i++)
            if (blocks[i] != null)
                blocks[i].transform.localPosition = new Vector2(i / rowColumn - (rowColumn / 2.0f - 0.5f), i % rowColumn - (rowColumn / 2.0f - 0.5f));
        // 回転後落下させる
        Drop(0.5f);
    }
    #endregion

    /// <summary>
    /// 「溶ける」
    /// </summary>
    /// <param name="direction">Down、もしくは矢印ブロックのプロパティ</param>
    public IEnumerator Melt(ArrowBlock.Direction direction)
    {
        // Acidの探索
        int acid = -1;
        for (int i = 0; i < blocks.Length; i++)
            if (blocks[i] is AcidBlock) { acid = i; break; }
        // 一応酸ブロックがなくなってしまっている場合のことも考えておく
        if (acid == -1) { Debug.Log("Acid is missing!"); yield break; }
        /// 3 7 11 15
        /// 2 6 10 14
        /// 1 5  9 13
        /// 0 4  8 12
        /// 
        int meltIndex = -1;

        // 壁判定（ゲームオーバー
        if (direction == ArrowBlock.Direction.Up && acid % rowColumn == rowColumn - 1 ||
            direction == ArrowBlock.Direction.Down && acid % rowColumn == 0 ||
            direction == ArrowBlock.Direction.Right && acid % acid >= rowColumn * rowColumn - rowColumn ||
            direction == ArrowBlock.Direction.Left && acid < rowColumn)
        {
            OnGameOver();
            yield break;
        }

        // 方向検知
        switch (direction)
        {
            case ArrowBlock.Direction.Up: meltIndex = acid + 1; break;
            case ArrowBlock.Direction.Down: meltIndex = acid - 1; break;
            case ArrowBlock.Direction.Right: meltIndex = acid + rowColumn; break;
            case ArrowBlock.Direction.Left: meltIndex = acid - rowColumn; break;
        }

        // 矢印に溶けたら
        if (blocks[meltIndex] is ArrowBlock arrow)
        {
            // 矢印が溶けたときに方向を取得
            var dir = arrow.OnMelt();
            // 酸に置き換え
            //Destroy(arrow.gameObject);
            // ここでの表示オフはAnimationClipに丸投げしてしまうことにする（正しくはないと思う
            blocks[meltIndex] = blocks[acid];
            blocks[acid] = null;
            yield return StartCoroutine(Replace(0.5f));
            yield return StartCoroutine(Melt(dir));
        }
        // ゴールした場合
        else if (blocks[meltIndex] is GoalBlock goal)
        {
            // 仲間が残っていないことを確認
            foreach (var block in blocks)
                if (block is FriendBlock)
                    yield break;
            goal.OnMelt();
            isMovable = false;
            var acidBlock = blocks[acid] as AcidBlock;
            acidBlock.StopCountDown();
            SelectStage.SceneController.ReleaseReport();
            clearDirecting.Clear();
        }
        // 消えないブロックの場合
        else if (blocks[meltIndex] is CannotBlock
            || blocks[meltIndex] is FixedBlock)
        {
            // 消さない（何もしない）
            var acidBlock = blocks[acid] as AcidBlock;
            acidBlock.OnCannotMelt();
            // パーティクルを出せぃ！
            yield break;
        }
        // 仲間ブロックと通常ブロックはアニメーションに共通点あり
        else
        {
            // 仲間ブロックの場合
            if (blocks[meltIndex] is FriendBlock friend)
            {
                if (level == friend.level)
                {
                    level++;
                    friend.OnMelt();
                    var obj = Instantiate(ouensekiPrefab);
                    obj.transform.position = new Vector3(rowColumn - 4 + 3 + (level - 1) * 0.7f, -0.8f, 0);
                    obj.transform.localScale *= rowColumn / 4.0f;
                }
            }
            else
            {
                // 通常ブロックの場合
                // 溶けたブロックを酸に置き換えてDestroy
                // AnimationはAcid側で必要なアニメーションを行うのでこれでOK
                if (blocks[meltIndex] != null)
                    Destroy(blocks[meltIndex].gameObject);
            }
            var acidBlock = blocks[acid] as AcidBlock;
            blocks[meltIndex] = acidBlock;
            acidBlock.OnMelt();
            blocks[acid] = null;

            //yield return StartCoroutine(Replace(0.5f));
            yield return new WaitForSeconds(2.0f);
            Drop(0);
        }
    }
    #region 落下関係
    /// <summary>
    /// ドロップの落下
    /// </summary>
    /// <param name="duration">秒数を指定するとアニメーションを行います</param>
    void Drop(float duration)
    {
        DropData();
        StartCoroutine(Replace(duration));
    }

    /// <summary>
    /// データ移動部分のみ分割
    /// </summary>
    void DropData()
    {
        for (int x = 0; x < rowColumn; x++)
            for (int i = 0; i < rowColumn - 1; i++)
                for (int y = 0; y < rowColumn - 1; y++)
                    if (blocks[x * rowColumn + y] == null
                        && !(blocks[x * rowColumn + y + 1] is FixedBlock))
                    {
                        blocks[x * rowColumn + y] = blocks[x * rowColumn + y + 1];
                        blocks[x * rowColumn + y + 1] = null;
                    }
    }
    #endregion
    /// <summary>
    /// ブロックの置き換え（移動
    /// </summary>
    /// <param name="duration">移動間隔（秒）</param>
    /// <returns></returns>
    private IEnumerator Replace(float duration)
    {
        float positionOffset = (rowColumn / 2.0f - 0.5f);
        if (duration > 0)
        {
            // 経過時間カウント
            float _time = 0;
            // 秒間移動量ベクトル配列
            Vector3[] perSeconds = new Vector3[blocks.Length];
            for (int i = 0; i < blocks.Length; i++)
                if (blocks[i] != null)
                    perSeconds[i] = (new Vector3(
                            /* x */(i / rowColumn - positionOffset),
                            /* y */(i % rowColumn - positionOffset),
                            /* z */blocks[i].transform.localPosition.z
                            )
                        - blocks[i].transform.localPosition)
                        / //-------------------------------------------------------------------------------------------------
                        duration;
            // 単純な等速移動
            while (true)
            {
                _time += Time.deltaTime;
                for (int i = 0; i < blocks.Length; i++)
                    if (blocks[i] != null)
                        blocks[i].transform.localPosition += perSeconds[i] * Time.deltaTime;
                if (_time > duration)
                    break;
                yield return null;
            }
        }
        // 移動後に端数を補正して正しくあるべき位置に
        for (int i = 0; i < blocks.Length; i++)
            if (blocks[i] != null)
                blocks[i].transform.localPosition = new Vector2(
                    i / rowColumn - positionOffset,
                    i % rowColumn - positionOffset);
    }

    void OnGameOver()
    {
        // Frameの破壊アニメーション
        frame.GetComponent<Animator>().SetTrigger("Fire");
        //frame.SetActive(false);
        // 落下の演出を手っ取り早く行いたいのでPhysics追加
        foreach (var block in blocks)
        {
            if (block == null) continue;
            // 爆発で飛び散らせる
            block.gameObject.AddComponent<Rigidbody>().AddExplosionForce(100, puzzle.transform.position, 30);
            // カウントストップ
            if (block is AcidBlock)
            {
                var acid = block as AcidBlock;
                acid.StopCountDown();
            }
        }
        // 操作の停止
        isMovable = false;
        // ゲームオーバー画面の表示
        gameOver.Display();
    }
}
