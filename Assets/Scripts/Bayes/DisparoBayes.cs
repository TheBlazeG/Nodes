using TMPro;
using UnityEngine;

public class DisparoBayes : MonoBehaviour
{
    public float easyOrHardPercent = 60;
    public bool easyOrHard;
    public float easyHitChance = 60;
    public float hardHitChance = 30;
    bool hit;
    public TextMeshProUGUI easyText;
    public TextMeshProUGUI hardText;
    public TextMeshProUGUI hitText;
    public TextMeshProUGUI timesShotText;
    int timesShot=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        easyText.text=easyOrHardPercent.ToString();
        hardText.text=(100-easyOrHardPercent).ToString();
        if (Shoot() <= easyOrHardPercent)
        {
            easyOrHard = true;
        }
        else
        {
            easyOrHard=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void EasyOrHardShoot()
    {
        
        if (easyOrHard)
        {
            //easy
            if (Shoot()<=easyHitChance)
            {
                //hit
                hit = true;
            }
            else
            {
                //miss
                hit=false;
            }
        }
        else
        {
            //hard
            if (Shoot() <= hardHitChance)
            {
                //hit
                hit=true;
            }
            else
            {
                //miss
                hit=false;
            }
        }
            float easy = easyOrHardPercent / 100;
        float easyMissChance = (100 - easyHitChance) / 100;
            float hard = (100 - easyOrHardPercent) / 100;
        float hardMissChance = (100 - hardHitChance) / 100;

        if (hit) 
        {
            easyOrHardPercent = 100*(easy * (easyHitChance / 100)) / (easy*(easyHitChance / 100) + hard*(hardHitChance / 100));
            easyText.text=easyOrHardPercent.ToString();
            hardText.text=(100-easyOrHardPercent).ToString();
            hitText.text = "HIT!";
        }
        else
        {
            easyOrHardPercent =100* (easy*easyMissChance)/(easy*easyMissChance+hard*hardMissChance);
            hitText.text = "NO HIT!";
            hardText.text = (100 - easyOrHardPercent).ToString();
            easyText.text = easyOrHardPercent.ToString();

        }
        TimesShot();
    }

    int Shoot()
    {
        return Random.Range(0, 101);
    }

    public void TimesShot()
    {
        timesShotText.text=(++timesShot).ToString();
    }

}
