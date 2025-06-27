using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MastermindGame : MonoBehaviour
{

    LinkedList<Colors> pickableColors = new LinkedList<Colors>();

    Colors[] colorList = { Colors.Red, Colors.Green, Colors.Blue, Colors.Yellow, Colors.Brown, Colors.Orange, Colors.Black, Colors.White };
    LinkedList<Colors> selectedColors = new LinkedList<Colors>();
    public bool win= false;
    int tryCounter = 0;
    int winCounter = 0;
    int loseCounter = 0;
    float winPercent;

    private void Start()
    {
        foreach (var color in colorList)
        {
            pickableColors.AddLast(color);
        }
        SelectColors();
    }
    private void Update()
    {
        
    }
    public void SelectColors()
    {
        
        for (int i = 0; i<4; i++)
            {
                int random =Random.Range(0,pickableColors.Count);
                selectedColors.AddFirst(colorList[random]);
                

            }
    }

    public List<int> TrySolve(List<Colors> answer)
    {
        List<int> result = new List<int>();
        tryCounter++;
        int order=0;
        foreach (var item in selectedColors)
        {
            if (item == answer[order])
            {
                result.Add(2);
                answer.RemoveAt(order);
            }
            
        }

        if (result.Count<4)
        {
        foreach (var color in answer)
        {
            foreach (var scolor in selectedColors)
            {
                if (color==scolor)
                {
                    result.Add(1);
                    answer.Remove(scolor);
                    break;
                }
            }
            
        }

        }
        while (result.Count<4)
        {
            result.Add(0);
        }
        win = true;
        foreach (int guess in  result)
        {
            if (guess!=4)
            {
                win = false; break;
            }
        }

       if (win)
        {
            winCounter++;
            winPercent = (winCounter) / winCounter + loseCounter;
        }
        else if (tryCounter == 4)
        {
            tryCounter = 00;
            loseCounter++;
            winPercent = (winCounter) / winCounter + loseCounter;
        }

        
        
        return result;
    }
}
public enum Colors
    {
        Red, 
        Green, 
        Blue, 
        Yellow, 
        Brown, 
        Orange, 
        Black, 
        White,
        notColor
    }