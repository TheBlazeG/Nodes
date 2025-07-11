using UnityEngine;
using UnityEngine.UI;

public class Tamagotchi : MonoBehaviour
{
    float hunger=30; //0.00347222222 para modo realista
    float tiredness=30;//0.00277777777 para modo realista
    float boredom = 30;//0.01388888888 para modo realista
    GameObject[] kirbystates;// 0 Feliz, 1 triste, 2 aburrido 3 enojado 4 con sueño
                             


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hunger < 100)
        {
            hunger += Time.deltaTime * .1f;
            if (hunger > 100)
            { hunger = 100; }
        }
        else
        {
            
        }


        if (tiredness < 100)
        {
            tiredness += Time.deltaTime * .1f;
            if (tiredness > 100)
            { tiredness = 100; }
        }

        if (boredom < 100)
        {
            boredom += Time.deltaTime * .1f;
            if (boredom > 100)
            { boredom = 100; }
        }
    }
}
