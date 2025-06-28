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
    int inPlace;
    private int wrongPlace;



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
                        curIndex++;
                        notColor = Colors.notColor;
                        break;
                    }
                    correctColors[curIndex] = colorTry[curIndex];
                }
                if (notColor != Colors.notColor)
                {
                    
                        if (curIndex == 0)
                        {
                            colorTry[0] = colorList[curIndex + 1];
                            colorTry[1] = colorList[curIndex + 2];
                            colorTry[2] = notColor;
                            colorTry[3] = notColor;
                            result = game.TrySolve(colorTry);
                            CountInPlaceAndWrongPlace();
                            switch (inPlace)
                            {
                              case 2:
                            
                                colorTry[2] = colorList[curIndex + 3];
                                colorTry[3] = colorList[curIndex + 4];
                                inPlace = 0;
                                result = game.TrySolve(colorTry);
                                CountInPlaceAndWrongPlace();
                                switch (inPlace)
                                {
                                    case 4:
                                        return;
                                        
                                    case 3:
                                        colorTry[3] = colorList[curIndex + 5];
                                        inPlace = 0;
                                        result = game.TrySolve(colorTry);
                                        CountInPlaceAndWrongPlace();
                                        while (inPlace==3)
                                        { 
                                            curIndex++;
                                            colorTry[3] = colorList[curIndex + 5];
                                            inPlace = 0;
                                            result = game.TrySolve(colorTry);
                                            CountInPlaceAndWrongPlace();
                                            
                                        }
                                        if (inPlace==4)
                                        {
                                            return;
                                        }
                                        
                                        break;
                                    case 2:
                                        wrongPlace = 0;
                                        CountInPlaceAndWrongPlace();
                                        switch (wrongPlace)
                                        {
                                            case 2:
                                                colorTry[2] = colorList[curIndex + 4];
                                                colorTry[3] = colorList[curIndex + 3];
                                                result = game.TrySolve(colorTry);

                                                break;
                                            case 1:
                                                //cambiamos una de lugar para confirmar posicion y color del par
                                                colorTry[2] = colorList[curIndex + 5];
                                                colorTry[3] = colorList[curIndex + 3];
                                                inPlace = 0;
                                                wrongPlace = 0;
                                                result = game.TrySolve(colorTry);
                                                CountInPlaceAndWrongPlace();
                                                if (wrongPlace == 1)
                                                {

                                                    colorTry[2] = colorList[curIndex + 4];
                                                    colorTry[3] = colorList[curIndex + 5];
                                                    result = game.TrySolve(colorTry);


                                                }
                                                else {
                                                        while (inPlace == 3)
                                                        {
                                                            curIndex++;
                                                            colorTry[2] = colorList[curIndex + 4];
                                                            result = game.TrySolve(colorTry);
                                                            inPlace = 0;
                                                            CountInPlaceAndWrongPlace();
                                                            if (inPlace == 4)
                                                            {
                                                                return;
                                                            }
                                                        }

                                                        //if (wrongPlace==0)
                                                        //{//XD
                                                        //    colorTry[2] = colorList[curIndex + 4];
                                                        //    while (inPlace!=4)
                                                        //    {
                                                        //        curIndex++;
                                                        //        colorTry[3] = colorList[curIndex+4];
                                                        //        result = game.TrySolve(colorTry);
                                                        //        inPlace = 0;
                                                        //        CountInPlaceAndWrongPlace();
                                                        //    }
                                                        //}

                                                        
                                                }
                                                break;
                                            case 0:
                                                while (wrongPlace==0 && inPlace<3)
                                                {
                                                    curIndex+=2;
                                                    colorTry[2] = colorList[curIndex + 3];
                                                    colorTry[3] = colorList[curIndex + 4];
                                                    wrongPlace = 0;
                                                    result = game.TrySolve(colorTry);
                                                    CountInPlaceAndWrongPlace();
                                                }
                                                if (inPlace==4)
                                                {
                                                    return;
                                                }
                                                if (inPlace==3)
                                                {
                                                    colorTry[3] = colorList[curIndex + 5];
                                                    TryClearandCount();
                                                    while (inPlace==3)
                                                    {
                                                        curIndex++;
                                                    colorTry[3] = colorList[curIndex + 5];

                                                    }
                                                    if (inPlace==2)
                                                    {
                                                        colorTry[3] = colorList[curIndex + 4];
                                                        while (inPlace==3)
                                                        {
                                                            curIndex++;
                                                            colorTry[2] = colorList[curIndex+5];
                                                            TryClearandCount();
                                                            if (inPlace==4)
                                                                return;
                                                        }
                                                    }
                                                }

                                                if (wrongPlace==2)
                                                {
                                                    colorTry[2] = colorList[curIndex + 4];
                                                    colorTry[3] = colorList[curIndex + 3];
                                                }
                                                else
                                                {
                                                    colorTry[2] = colorList[curIndex + 5];
                                                    colorTry[3] = colorList[curIndex + 3];
                                                    wrongPlace = 0;
                                                    result = game.TrySolve(colorTry);
                                                    CountInPlaceAndWrongPlace();
                                                    if (wrongPlace==1)
                                                    {
                                                        colorTry[2] = colorList[curIndex + 4];
                                                        colorTry[3] = colorList[curIndex + 5];
                                                        inPlace = 0;
                                                        result = game.TrySolve(colorTry);
                                                        
                                                        }
                                                    }
                                                if (wrongPlace==0)
                                                {
                                                    colorTry[3] = colorList[curIndex + 4];

                                                    while (inPlace != 4)
                                                    {
                                                        curIndex++;
                                                        colorTry[2] = colorList[curIndex + 5];
                                                        result = game.TrySolve(colorTry);
                                                    }
                                                }

                                                break;
                                        }
                                        break;
                                }
                              break;
                            case 1:
                                //1 posicion correcta
                                wrongPlace = 0;
                                CountInPlaceAndWrongPlace();
                                if (wrongPlace==1)
                                {

                                    colorTry[0] = notColor;
                                    colorTry[1] = colorList[curIndex + 2];
                                    colorTry[2] = colorList[curIndex+1];
                                    colorTry[3] = notColor;
                                    result = game.TrySolve(colorTry);
                                    inPlace = 0;
                                    wrongPlace = 0;
                                    CountInPlaceAndWrongPlace() ;
                                    if (inPlace==2)
                                    {

                                    }
                                    if (inPlace==1 && wrongPlace==1)
                                    {
                                        //una posicion correcta
                                        colorTry[0] = colorList[curIndex + 3];
                                        colorTry[2] = colorList[curIndex + 4];
                                        colorTry[3] = colorList[curIndex + 1];
                                    }
                                    if (inPlace==0 && wrongPlace==2)
                                    {
                                        //dos posiciones incorrectas originalmente solo una
                                        colorTry[0] = colorList[curIndex + 1];
                                        colorTry[1] = notColor;
                                        colorTry[2] = colorList[curIndex + 2];
                                        colorTry[3] = notColor;
                                        result = game.TrySolve(colorTry);
                                        inPlace = 0;
                                        wrongPlace=0;
                                        CountInPlaceAndWrongPlace() ;
                                        if(inPlace==2)
                                        {
                                            colorTry[1] = colorList[curIndex+3];
                                            colorTry[3] = colorList[curIndex+4];
                                            TryClearandCount();
                                            if (inPlace == 4)
                                            {
                                                return;
                                            }
                                            else if (inPlace == 3)
                                            {
                                                colorTry[4] = colorList[curIndex + 5];
                                                TryClearandCount();
                                                while (inPlace == 3)
                                                {
                                                    curIndex++;
                                                    colorTry[4] = colorList[curIndex + 5];
                                                    TryClearandCount();
                                                    if (inPlace == 4)
                                                        return;
                                                }
                                            }
                                            else
                                            {
                                                if (wrongPlace==2)
                                                {
                                                colorTry[1] = colorList[curIndex + 4];
                                                colorTry[3] = colorList[curIndex + 3];
                                                    TryClearandCount();
                                                }
                                                else if(wrongPlace==1)
                                                {
                                                    colorTry[1] = colorList[curIndex + 5];
                                                    colorTry[3] = colorList[curIndex + 3];
                                                    TryClearandCount();
                                                    if(inPlace == 4)
                                                    { return; }
                                                    else
                                                    {
                                                        while (inPlace==3)
                                                        {
                                                            curIndex++;
                                                    colorTry[1] = colorList[curIndex + 5];
                                                            TryClearandCount();
                                                            if (inPlace==4)
                                                            {
                                                                return;
                                                            }

                                                        }
                                                        if (inPlace==2 && wrongPlace ==1)
                                                        {
                                                            colorTry[1] = colorList[curIndex + 4];
                                                            colorTry[3] = colorList[curIndex + 5];
                                                        }
                                                        else
                                                        {
                                                            while(wrongPlace==0 && inPlace<3)
                                                            {
                                                                curIndex += 2;
                                                                colorTry[1] = colorList[curIndex + 3];
                                                                colorTry[3] = colorList[curIndex + 4];
                                                                TryClearandCount();
                                                            }//aaaaa
                                                                if (inPlace == 4)
                                                            {
                                                                return;
                                                            }
                                                            if (inPlace == 3)
                                                            {
                                                                colorTry[3] = colorList[curIndex + 5];
                                                                TryClearandCount();
                                                                while (inPlace == 3)
                                                                {
                                                                    curIndex++;
                                                                    colorTry[3] = colorList[curIndex + 5];

                                                                }
                                                                if (inPlace == 2)
                                                                {
                                                                    colorTry[3] = colorList[curIndex + 4];
                                                                    while (inPlace == 3)
                                                                    {
                                                                        curIndex++;
                                                                        colorTry[1] = colorList[curIndex + 5];
                                                                        TryClearandCount();
                                                                        if (inPlace == 4)
                                                                            return;
                                                                    }
                                                                }
                                                            }

                                                            if (wrongPlace == 2)
                                                            {
                                                                colorTry[1] = colorList[curIndex + 4];
                                                                colorTry[3] = colorList[curIndex + 3];
                                                            }
                                                            else
                                                            {
                                                                colorTry[1] = colorList[curIndex + 5];
                                                                colorTry[3] = colorList[curIndex + 3];
                                                                wrongPlace = 0;
                                                                inPlace = 0;
                                                                result = game.TrySolve(colorTry);
                                                                CountInPlaceAndWrongPlace();
                                                                if (wrongPlace == 1)
                                                                {
                                                                    colorTry[1] = colorList[curIndex + 4];
                                                                    colorTry[3] = colorList[curIndex + 5];
                                                                    TryClearandCount();
                                                                    
                                                                }   
                                                                
                                                                else  if(wrongPlace == 0 && inPlace<3)
                                                                {
                                                                    colorTry[1] = colorList[curIndex + 4];
                                                                    while (inPlace == 3) 
                                                                    {curIndex++;
                                                                        colorTry[1]= colorList[curIndex+4];
                                                                        TryClearandCount();
                                                                    }
                                                                    
                                                                }
                                                                else while (inPlace==3)
                                                                {
                                                                        curIndex++;
                                                                        colorTry[1] = colorList[curIndex + 5];

                                                                    }
                                                            }

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //posicion 1 y 4 correctas
                                            colorTry[0] = colorList[curIndex + 1];
                                            colorTry[1] = colorList[curIndex+3];
                                            colorTry[2] = colorList[curIndex + 4];
                                            colorTry[3] = colorList[curIndex + 2];

                                            TryClearandCount();
                                            if(inPlace==4)
                                                return;
                                            if (inPlace==3)
                                            {
                                                colorTry[2] = colorList[curIndex + 5];
                                                TryClearandCount();
                                                if(inPlace==4) return;
                                                while(inPlace==3)
                                                {
                                                    curIndex++;
                                                    colorTry[2] = colorList[curIndex + 5];
                                                    TryClearandCount();
                                                }
                                                if (inPlace==2 && wrongPlace==1)
                                                {
                                                    colorTry[1] = colorList[curIndex + 5];
                                                    colorTry[2] = colorList[curIndex + 4];
                                                    TryClearandCount();
                                                }
                                            }
                                            else
                                            {
                                                if (wrongPlace==2)
                                                {
                                                    colorTry[1] = colorList[curIndex + 4];
                                                    colorTry[2] = colorList[curIndex + 3];
                                                    TryClearandCount() ;
                                                }
                                                if (wrongPlace==1)
                                                {
                                                    colorTry[1] = colorList[curIndex + 5];
                                                    colorTry[2] = colorList[curIndex + 3];
                                                    
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {

                                }
                                break;
                            case 0:
                                break;
                            }

                            


                        }
                        else if (curIndex == 1)
                        {
                            colorTry[0] = correctColors[0];
                            colorTry[1] = colorList[2];
                            colorTry[2] = notColor;
                            colorTry[3] = notColor;
                            TryClearandCount();
                        while (game.tryCounter < 10)
                        { 
                            for (int i = 0; i < colorTry.Count; i++)
                            {
                                colorTry[i]=colorList[Random.Range(0, colorList.Length)];
                            }
                            game.TrySolve(colorTry);
                        }
                            
                                 
                            
                        
                        }
                        else
                        {
                            colorTry[0] = correctColors[0];
                            colorTry[1] = correctColors[1];
                            colorTry[2] = notColor;
                            colorTry[3] = notColor;
                        while (game.tryCounter < 10)
                        {
                            for (int i = 0; i < colorTry.Count; i++)
                            {
                                colorTry[i] = colorList[Random.Range(0, colorList.Length)];
                            }
                            game.TrySolve(colorTry);
                        }
                    }
                    
                }
                
            }
        }
        if (!game.win)
        {
            return;
            
        }
        game.win = false;
        return;
    }

    private void TryClearandCount()
    {
        result = game.TrySolve(colorTry);
        inPlace = 0;
        wrongPlace = 0;
        CountInPlaceAndWrongPlace();
    }
    private void CountInPlaceAndWrongPlace()
    {
        foreach (var VARIABLE in result)
        {
            if (VARIABLE == 2)
            {
                inPlace++;
            }

            if (VARIABLE==1)
            {
                wrongPlace++;
            }
        }
    }

}
                    
    

