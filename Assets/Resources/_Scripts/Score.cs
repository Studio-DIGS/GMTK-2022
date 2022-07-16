using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private int points = 0;

    public void AddPoints(int _points)
    {
        points += _points;
    }
    public void AddPoints(int _points, float _multipler)
    {
        points += Mathf.RoundToInt(_points * _multipler);
    }
    public void SubtractPoints(int _points)
    {
        points -= _points;
    }
    public void SubtractPoints(int _points, float _multipler)
    {
        points -= Mathf.RoundToInt(_points * _multipler);
    }
    public int GetPoints()
    {
        return points;
    }
}
