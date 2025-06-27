using System.Collections.Generic;
using UnityEngine;

public class MastermindES : MonoBehaviour
{
    MastermindGame game;
    Colors notColor= Colors.notColor;
    Colors[] correctColors;
    Colors[] colorList= {Colors.Red,Colors.Green,Colors.Blue, Colors.Yellow,Colors.Brown,Colors.Orange,Colors.Black,Colors.White };
    List<Colors> colorTry = new List<Colors>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Solve()
    {
        
    }


    void SetColors()
    {
        while (notColor == Colors.notColor)
        {
            while (colorTry.Count < 4)
            {
                colorTry.Add(colorList[0]);
                game.TrySolve(colorTry);
            }
        }
    }
}
