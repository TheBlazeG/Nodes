using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MastermindGame : MonoBehaviour
{

    LinkedList<Colors> pickableColors = new LinkedList<Colors>();

    Colors[] colorList = { Colors.Red, Colors.Green, Colors.Blue, Colors.Yellow, Colors.Brown, Colors.Orange, Colors.Black, Colors.White };
    LinkedList<Colors> selectedColors = new LinkedList<Colors>();
    public bool win= false;
    public int tryCounter = 0;
    int winCounter = 0;
    int loseCounter = 0;
    float winPercent;
    public TextMeshPro winPercentText;

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
            if (guess!=2)
            {
                win = false; break;
            }
        }

       if (win)
        {
            winCounter++;
            winPercent = (float)winCounter / (float)winCounter + (float)loseCounter;
            winPercentText.text= winPercent.ToString();
        }
        else if (tryCounter == 10)
        {
            tryCounter = 00;
            loseCounter++;
            winPercent = (float)winCounter / (float)winCounter + (float)loseCounter;
            winPercentText.text = winPercent.ToString();

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