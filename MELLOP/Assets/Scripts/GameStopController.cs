using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アプリケーションの終了処理
/// 担当：笹之内
/// </summary>
public class GameStopController : MonoBehaviour
{
    // GameStopControllerを取得する変数
    private GameObject GameStopControllerObj;

    // Start is called before the first frame update
    void Start()
    {
        // GameStopControllerを取得
        GameStopControllerObj = GameObject.Find("GameStopController");

        // シーンを切り替えてもGameStopControllerを引き継ぎさせる
        DontDestroyOnLoad(GameStopControllerObj);
    }

    // Update is called DontDestroyOnce per frame
    void Update()
    {
        // キー入力が行われたらアプリケーションを終了させる
        if (Input.GetKeyDown(KeyCode.P))
        {
            Quit();
        }
    }

    /// <summary>
    /// アプリケーションの終了処理
    /// </summary>
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
