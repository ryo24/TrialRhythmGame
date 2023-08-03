using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ノーツ情報を表現するモデルクラス
[System.Serializable]
public class NoteModel
{
    public float time; // ノーツの発生時間（曲の開始からの秒数）
    public NoteType type;   // ノーツの種類（単押し、長押し、同時押しなどを区別するためのID）
    // 必要に応じて他の情報（例：レーン番号）も追加できます。
}

public enum NoteType
{
    Single,      // 単押しノーツ
    Long,        // 長押しノーツ
    Simultaneous // 同時押しノーツ
}


// ノーツ情報のリストを持つ楽譜クラス
[System.Serializable]
public class ScoreModel
{
    public List<NoteModel> notes; // 楽譜に含まれる全ノーツ情報のリスト
}
