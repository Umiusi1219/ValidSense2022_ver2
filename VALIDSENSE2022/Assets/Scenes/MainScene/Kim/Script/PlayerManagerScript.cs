using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerScript
{
    /// <summary>
    /// プレイヤー選択キャラクター記憶用
    /// </summary>
    public static int[] playerWinCount = { 0, 0 };
    /// <summary>
    /// プレイヤーの勝利数記憶用
    /// </summary>
    public static int[] playerCharaNum = { 0, 0 };
    /// <summary>
    /// 現在選択楽曲番号記憶用
    /// </summary>
    public static int[] nowMusicNum = { 0, 0 };
    /// <summary>
    /// 難易度記憶用
    /// </summary>
    public static int[] nowMusicLevel = { 0, 0 };
    /// <summary>
    /// スコア記憶用
    /// </summary>
    public static int[] score = { 0, 0 };
    /// <summary>
    /// 奪ったレーン数記憶用
    /// </summary>
    public static int[] stolenLane = { 0, 0 };
    /// <summary>
    /// 奪われたレーン数記憶用
    /// </summary>
    public static int[] losLanes = { 0, 0 };
    /// <summary>
    /// 総打数記憶用
    /// </summary>
    public static int[] totalHitsNum = { 0, 0 };
    /// <summary>
    /// 勝利キャラクター記憶用
    /// </summary>
    public static int winCharaNum;
    /// <summary>
    /// キャラクターsightのカラーコード
    /// </summary>
    public static string sightColorCode;
    /// <summary>
    /// キャラクターhearのカラーコード
    /// </summary>
    public static string hearColorCode;
    /// <summary>
    /// キャラクターtactileのカラーコード
    /// </summary>
    public static string tactileColorCode;
}
