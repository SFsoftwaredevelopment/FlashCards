using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ScoreBoard
{
    // Board is a priority queue with increasing value
    static ScoreBoard SB = null;
    public ArrayList Board;

    public ScoreBoard(int count)
    {
        Board = new ArrayList();
        for (int i = 0; i < count; i++)
        {
            Score n = new Score();
            n.index = i;
            n.value = 0;

            Board.Insert(i, n);
        }
    }

    public static ScoreBoard getScoreBoard(int count)
    {
        SB = new ScoreBoard(count);
        return SB;
    }

    // priority queue insert function
    // insert in the order of increasing value
    public void insertOrder(Score n)
    {
        for (int i = 0; i < SB.Board.Count; i++)
        {
            Score s = (Score)SB.Board[i];

            if (s.value > n.value)
            {
                SB.Board.Insert(i, n);
                return; 
            }
        }
        // if still not inserted, add at the end
        SB.Board.Add(n);
    }


    public void insert(Score n)
    {
        for (int i = 0; i < Board.Count; i++)
        {
            Score s = (Score)Board[i];

            if (s.value > n.value)
            {
                Board.Insert(i, n);
                return;
            }
        }
        // if still not inserted, add at the end
        Board.Add(n);
    }
}
