using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 「酸ブロック」
/// 担当：吉中
/// </summary>
public class AcidBlock : Block
{
    /// <summary>
    /// オブジェクト生成
    /// </summary>
    public static Block Instantiate()
    {
        return Instantiate(Resources.Load("Prefabs/Blocks/AcidBlock") as GameObject).GetComponent<AcidBlock>();
    }

    PuzzleManager manager = null;
    PauseController pauseController = null;
    Slider slider;
    Text meltCountText = null;
    AudioSource audioSource = null;
    AudioClip audioClip = null;
    public float duration { get; private set; } = 5.0f;
    Animator animator = null;
    Animator faceAnimator = null;

    Coroutine countDown;

    private void Awake()
    {
        manager = GameObject.Find(nameof(PuzzleManager)).GetComponent<PuzzleManager>();
        pauseController = manager.pauseController;
        var canvas = Instantiate(Resources.Load("Prefabs/Canvas") as GameObject);
        slider = canvas.transform.Find("CountDown").GetComponent<Slider>();
        meltCountText=canvas.transform.Find("MeltCount/Number").GetComponent<Text>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioClip = Resources.Load("Sounds/syuwasyuwasound（5sec)") as AudioClip;
        animator = GetComponent<Animator>();
        faceAnimator = transform.Find("shuwachanface").GetComponent<Animator>();
    }

    public void StartCountDown()
    {
        countDown = StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        int meltCount = 0;
        while (true)
        {
            float _t = 0.0f;
            while (true)
            {
                // ポーズ中はカウントストップ
                if (pauseController.ISStopGame)
                {
                    yield return null;
                    continue;
                }
                _t += Time.deltaTime;
                slider.value = Mathf.Max((duration - _t) / duration, 0);
                //slider.image.color = Color.red;
                // 回転中はカウントストップはしないが溶けるのは待機する
                if (_t > duration
                    && manager.isMovable
                    || Input.GetKeyDown(KeyCode.W)
                    || Input.GetKeyDown("joystick button 1"))
                {
                    manager.isMovable = false;
                    audioSource.PlayOneShot(audioClip);
                    yield return StartCoroutine(manager.Melt(ArrowBlock.Direction.Down));
                    manager.isMovable = true;
                    meltCount++;
                    meltCountText.text=meltCount.ToString();
                    break;
                }
                yield return null;
            }
        }
    }

    public void StopCountDown() { StopCoroutine(countDown); }

    public override void OnRotation(Rotation rotation)
    {
        animator.SetTrigger(rotation == Rotation.Right ? "RotR" : "RotL");
        faceAnimator.SetTrigger(rotation == Rotation.Right ? "RotR" : "RotL");
    }

    public void OnMelt()
    {
        animator.SetTrigger("Melt");
        faceAnimator.SetTrigger("Melt");
    }

    public void OnCannotMelt()
    {
        faceAnimator.SetTrigger("CannotMelt");
    }
}
