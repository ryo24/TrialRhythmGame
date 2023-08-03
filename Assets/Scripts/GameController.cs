using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening; // DoTween namespace

public class GameController : MonoBehaviour
{
    // シングルトンインスタンス
    public static GameController Instance { get; private set; }

    // 現在のゲーム状態
    public GameState CurrentGameState { get; private set; }
    public MusicState MusicState { get; private set; }
    

    private void Awake()
    {
        // シングルトンの設定
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        CurrentGameState = GameState.Title;
        SceneManager.sceneLoaded += OnSceneLoaded; // シーンロード時のイベントを登録
    }

    public void StartGame()
    {
        // ここで曲選択やその他の初期設定を行います。

        // ゲームを開始するための状態を設定します。
        CurrentGameState = GameState.Playing;

        // GamePlayシーンへ移動します。
        SceneManager.LoadScene("GamePlay");

        // Instantiate CountDownView and register its CountDownFinished event
        //var countDownView = Instantiate(Resources.Load<CountDownView>("CountDownView"));
        //countDownView.CountDownFinishedEvent += OnCountDownFinished;
        //TODO: ここはあとで必ず直す！
        //DontDestroyOnLoad(countDownView); // Add this line to prevent CountDownView from being destroyed. 


    }

    public void EndGame()
    {
        // ゲームの終了処理を行います。

        // ゲーム終了状態を設定します。
        CurrentGameState = GameState.GameOver;

        // Resultシーンへ移動します。
        SceneManager.LoadScene("Result");
    }

    public void OnCountDownFinished()
    {
        MusicState = MusicState.Playing;
        // Start music
        Debug.Log("StartPlaying!!");
        BeatController.Instance.StartBeats();
        MusicController.Instance.StartMusic();
    }

    public void StopGame()
    {
        MusicState = MusicState.Stopped;
        // Stop music

        //ここでゲームの中断処理書くかも。つまりEndGame呼び出す？
        //EndGame();
        //GameState = GameState.Stopped;

    }

    public void PauseGame()
    {
        //GameState = GameState.Paused;
        MusicState = MusicState.Paused;
        // Pause music
    }

    public void ResumeGame()
    {
        //GameState = GameState.Playing;
        MusicState = MusicState.Playing;
        // Resume music
    }


    // シーンロード時に実行されるメソッド
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // シーンがGamePlayであればCountDownViewを探し、デリゲートを設定
        if (scene.name == "GamePlay")
        {
            var countDownView = GameObject.FindObjectOfType<CountDownView>();
            if (countDownView != null)
            {
                countDownView.CountDownFinishedEvent += OnCountDownFinished;
            }
        }
    }

    // OnDestroy時にイベントの登録を解除
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
