using UnityEngine;
using UnityEngine.UI;

public class Tamagotchi : MonoBehaviour
{ 
    [SerializeField]
    float hunger=30; //0.00347222222 para modo realista
    [SerializeField]
    float tiredness=30;//0.00277777777 para modo realista
    [SerializeField]
    float boredom = 30;//0.01388888888 para modo realista
    [SerializeField]
    Slider hungerSlider,tirednessSlider,boredomSlider;
   
    bool sleeping = false;
    [SerializeField]
    GameObject[] kirbystates;// 0 Feliz, 1 triste, 2 aburrido 3 enojado 4 con sueño
                             


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        kirbystates[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (sleeping)
            tiredness-= Time.deltaTime;
        
if (hunger < 100 )
        {
            hunger += Time.deltaTime * .1f;
                
                    kirbystates[2].SetActive(hunger >60 ? true : false);
                

            if (hunger > 100)
            { hunger = 100; }
            hungerSlider.value = hunger;
        }



        if (tiredness < 100 & !sleeping )
        {
            tiredness += Time.deltaTime * .1f;
             kirbystates[4].SetActive(tiredness >70 ? true : false);
            if (tiredness > 100)
            { tiredness = 100; }
                tirednessSlider.value = tiredness;

            }

            if (boredom < 100)
        {
            boredom += Time.deltaTime * .1f;

                kirbystates[1].SetActive(boredom > 50 ? true : false);
                if (boredom > 100)
            { boredom = 100; }
                boredomSlider.value = boredom;

            }
        
        
        if (kirbystates[1].activeSelf && kirbystates[2].activeSelf && kirbystates[4].activeSelf && !kirbystates[0].activeSelf)
        {
           
            kirbystates[1].SetActive(false);
            kirbystates[2].SetActive(false);
            kirbystates[4].SetActive(false);
            kirbystates[3].SetActive(true);
        }
        
        if(hunger<60 || tiredness <70 || boredom < 50)
        {
            kirbystates[3].SetActive(false);

        }

        
        




            if (hunger < 60 && tiredness < 70 && boredom < 50)
            {
            kirbystates[0].SetActive(true);
        }
        else
        {
            kirbystates[0].SetActive(false);

        }
    }

    public void Feed() { hunger -= 30; }
    public void Play() { boredom -= 40; }
    public void Sleep() { sleeping = sleeping ? false : true; }



}
