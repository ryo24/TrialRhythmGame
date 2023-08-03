using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip clip; // 再生する音楽ファイル
    private ScoreModel score; // 楽譜情報
    private AudioSource audioSource; // 音楽の再生に使用するAudioSource

    public static MusicController Instance { get; private set; }

    private void Awake()
    {
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
    }
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        LoaDummyScore(); // ダミーデータの読み込み
    }

    // 楽譜情報のロード（ダミーデータ）
    private void LoaDummyScore()
    {
        score = new ScoreModel();
        score.notes = new List<NoteModel>();

        // 60秒分、3秒ごとにノーツを出現させる
        for (float i = 0; i < 60; i += 3)
        {
            NoteModel note = new NoteModel();
            note.time = i;
            note.type = NoteType.Single; // ノーツの種類はとりあえず1とする
            score.notes.Add(note);
        }
    }

    public void StartMusic()
    {
        audioSource.Play();
    }

    // ノーツの生成など、音楽の再生と連動した処理はUpdate()内で行う
    void Update()
    {
        // 例：音楽の再生時間に応じてノーツを生成する処理
    }
}
