using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerScript
{
    /// <summary>
    /// �v���C���[�I���L�����N�^�[�L���p
    /// </summary>
    public static int[] playerWinCount = { 0, 0 };
    /// <summary>
    /// �v���C���[�̏������L���p
    /// </summary>
    public static int[] playerCharaNum = { 0, 0 };
    /// <summary>
    /// ���ݑI���y�Ȕԍ��L���p
    /// </summary>
    public static int[] nowMusicNum = { 0, 0 };
    /// <summary>
    /// ��Փx�L���p
    /// </summary>
    public static int[] nowMusicLevel = { 0, 0 };
    /// <summary>
    /// �X�R�A�L���p
    /// </summary>
    public static int[] score = { 0, 0 };
    /// <summary>
    /// �D�������[�����L���p
    /// </summary>
    public static int[] stolenLane = { 0, 0 };
    /// <summary>
    /// �D��ꂽ���[�����L���p
    /// </summary>
    public static int[] losLanes = { 0, 0 };
    /// <summary>
    /// ���Ő��L���p
    /// </summary>
    public static int[] totalHitsNum = { 0, 0 };
    /// <summary>
    /// �����L�����N�^�[�L���p
    /// </summary>
    public static int winCharaNum;
    /// <summary>
    /// �L�����N�^�[sight�̃J���[�R�[�h
    /// </summary>
    public static string sightColorCode;
    /// <summary>
    /// �L�����N�^�[hear�̃J���[�R�[�h
    /// </summary>
    public static string hearColorCode;
    /// <summary>
    /// �L�����N�^�[tactile�̃J���[�R�[�h
    /// </summary>
    public static string tactileColorCode;
}
