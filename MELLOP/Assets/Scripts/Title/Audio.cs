using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルのサウンドの制御
/// 担当：笹之内
/// </summary>
namespace TitleScene
{
    public class Audio : MonoBehaviour
    {
        // 指定の音源を取得する変数
        private AudioClip SoundEffect_Decision;   // 決定音
        private AudioClip SoundEffect_SyuwaSyuwa;  // シュワシュワ音

        // AudioSourceを取得する変数
        private AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            // 指定の音楽を取得
            SoundEffect_Decision = Resources.Load<AudioClip>("Sounds/Title/決定音decision20");
            SoundEffect_SyuwaSyuwa = Resources.Load<AudioClip>("Sounds/Title/シュワ～gas1");

            // AudioSourceを取得
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 効果音を鳴らす
        /// </summary>
        public void RingSound()
        {
            audioSource.PlayOneShot(SoundEffect_Decision);
            audioSource.PlayOneShot(SoundEffect_SyuwaSyuwa);

            // シュワシュワ音が鳴り終わったらセレクトステージへシーン遷移
            Invoke("SceneFlag", SoundEffect_SyuwaSyuwa.length);
        }

        /// <summary>
        /// セレクトステージへ遷移
        /// </summary>
        private void SceneFlag()
        {
            SceneManager.LoadScene("SelectStage");
        }
    }
}