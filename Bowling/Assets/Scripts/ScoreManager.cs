using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int[] rolls=new int[21];
    //private int[] frame = new int[10];
    private int currentRoll = 0;
    int selectFrame;
    public TMP_Text ScoreUI;

    /// <summary>
    /// 每滾一球執行一次，用於計算分數
    /// </summary>
    /// <param name="pins"></param>
    public void Roll(int pins)
    {
        rolls[currentRoll] = pins;
    }

    /// <summary>
    /// 保齡球總分數計算
    /// </summary>
    /// <returns>分數</returns>
    public int Score()
    {
        int score = 0;
        int frameIndex = 0;

        for(int frame = 0; frame < selectFrame; frame++)
        {
            if (IsStrike(frameIndex))
            {
                score += 10 + StrikeBonus(frameIndex);
                frameIndex++;
            }
            else if (IsSpare(frameIndex))
            {
                score += 10 + SpareBonus(frameIndex);
                frameIndex += 2;
            }
            else
            {
                score += SumOfBallsInFrame(frameIndex);
                frameIndex += 2;
            }
        }
        Debug.Log($"Score = {score}, currentRolls = {currentRoll}");
        ScoreUI.text = score.ToString();
        return score;
    }

    public bool IsStrike(int frameIndex)
    {
        return rolls[frameIndex] == 10;
    }

    public int SumOfBallsInFrame(int frameIndex)
    {
        return rolls[frameIndex] + rolls[frameIndex + 1];
    }

    public int SpareBonus(int frameIndex)
    {
        return rolls[frameIndex + 2];
    }

    public int StrikeBonus(int frameIndex)
    {
        return rolls[frameIndex + 1] + rolls[frameIndex + 2];
    }

    public bool IsSpare(int frameIndex)
    {
        return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
    }

    public void SetSelectFrame(int selectFrame)
    {
        this.selectFrame = selectFrame;
    }
}
