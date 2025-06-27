using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MastermindES : MonoBehaviour
{
    MastermindGame game;
    Colors notColor = Colors.notColor;
    List<Colors> correctColors= new List<Colors>();
    Colors[] colorList = { Colors.Red, Colors.Green, Colors.Blue, Colors.Yellow, Colors.Brown, Colors.Orange, Colors.Black, Colors.White };
    List<Colors> colorTry = new List<Colors>();
    List<int> result;
    int curIndex = 0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void Solve()
    {

        foreach (var item in colorList)
        {
            while (colorTry.Count < 4)
            {
                colorTry.Add(item);
                result = game.TrySolve(colorTry);
                notColor = item;
                foreach (var i in result)
                {
                    if (i != 0)
                    {
                        notColor = Colors.notColor;
                        break;
                    }
                    correctColors[curIndex] = colorTry[curIndex];
                    curIndex++;
                }
                if (notColor != Colors.notColor)
                {
                    if (correctColors.Count!=0)
                    {
                        if (correctColors.Count==1)
                        {

                        }
                        else
                        {

                        }
                    }
                    else
                    {
                    if (curIndex == 0)
                    {
                        colorTry[1] = colorList[curIndex + 1];
                        colorTry[2] = colorList[curIndex + 2];
                        colorTry[3] = notColor;
                        colorTry[4] = notColor;
                    }
                    else if (curIndex == 1)
                    {
                        colorTry[1] = colorList[0];
                        colorTry[2] = colorList[2];
                        colorTry[3] = notColor;
                        colorTry[4] = notColor;
                    }
                    else
                    {
                    colorTry[1] = colorList[0];
                    colorTry[2] = colorList[1];
                    colorTry[3] = notColor;
                    colorTry[4] = notColor;

                    }
                    }
                }
                
            }
        }
        if (game.win)
        {
            game.win = false;
            return;
        }
    }
}
                    
    

