using UnityEngine;
using UnityEngine.UI;

public class Tamagotchi : MonoBehaviour
{
    float hunger=30; //0.00347222222 para modo realista
    float tiredness=30;//0.00277777777 para modo realista
    float boredom = 30;//0.01388888888 para modo realista
    [SerializeField]
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
            if (hunger > 50)
                kirbystates[2].SetActive(true);
            if (hunger > 100)
            { hunger = 100; }
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
        else if (kirbystates[1].activeSelf && kirbystates[2].activeSelf && kirbystates[4].activeSelf)
        {
            kirbystates[1].SetActive(false);
            kirbystates[2].SetActive(false);
            kirbystates[4].SetActive(false);
            kirbystates[3].SetActive(true);
        }
        else
        {
            kirbystates[3].SetActive(false);

        }
    }
}
