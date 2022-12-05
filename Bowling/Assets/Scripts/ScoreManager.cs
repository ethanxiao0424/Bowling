using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]private int[] rolls=new int[21];
    private int currentRoll = 0;

    public void Roll(int pins)
    {
        rolls[currentRoll++] = pins;
    }

    /// <summary>
    /// 保齡球分數計算
    /// </summary>
    /// <returns>分數</returns>
    public int Score()
    {
        int score = 0;
        int frameIndex = 0;

        for(int frame = 0; frame < 10; frame++)
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
        return score;
    }

    private bool IsStrike(int frameIndex)
    {
        return rolls[frameIndex] == 10;
    }

    private int SumOfBallsInFrame(int frameIndex)
    {
        return rolls[frameIndex] + rolls[frameIndex + 1];
    }

    private int SpareBonus(int frameIndex)
    {
        return rolls[frameIndex + 2];
    }
    
    private int StrikeBonus(int frameIndex)
    {
        return rolls[frameIndex + 1] + rolls[frameIndex + 2];
    }

    private bool IsSpare(int frameIndex)
    {
        return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
    }
}
