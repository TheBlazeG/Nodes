using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GeneticAlgorithm : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    public Sprite[] parts = new Sprite[4];
    List<LilGuy> lilGuys = new List<LilGuy>();
    [SerializeField] float mutationRate = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
           LilGuy temp = Instantiate(prefab, transform.position+Vector3.right*(i*5),Quaternion.identity).GetComponent<LilGuy>();
            temp.head.sprite = parts[temp.chromosomes[0]];
            temp.body.sprite = parts[temp.chromosomes[1]];
            temp.armL.sprite = parts[temp.chromosomes[2]];
            temp.armR.sprite = parts[temp.chromosomes[3]];
            temp.legL.sprite = parts[temp.chromosomes[4]];
            temp.legR.sprite = parts[temp.chromosomes[5]];
            lilGuys.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EvolveChromosomes() 
    {       
        
        int squareCount;    
        int circleCount;
        int triangleCount;
        int hexCount;
        List<LilGuy> squareGuys = new List<LilGuy>();
        List<LilGuy> circleGuys = new List<LilGuy>();
        List<LilGuy> triangleGuys = new List<LilGuy>();
        List<LilGuy> hexGuys = new List<LilGuy>();
        
        //assigning each  lilguy a count and assigning them to a list
        foreach (var item in lilGuys)
        {
            item.squareCount = 0;
            item.circleCount = 0;
            item.triangleCount = 0;
            item.hexCount = 0;

            //assigning count
            for (int i = 0; i < item.chromosomes.Length; i++)
            {
                switch (item.chromosomes[i])
                {
                    case 0:
                        item.squareCount++;
                        break;
                    
                    case 1:
                        item.circleCount++; 
                        break;
                        
                    case 2: 
                        item.triangleCount++; 
                        break;
                        
                    case 3: 
                        item.hexCount++; 
                        break;
                    default:
                        Debug.Log("nacio mal");
                        break;
                }
                
            }
            //assigning to list
            if (item.squareCount >= item.triangleCount && item.squareCount >= item.circleCount && item.squareCount >= item.hexCount)
            {
                squareGuys.Add(item);
            }

            else if (item.circleCount >= item.triangleCount && item.circleCount >= item.hexCount)
            {
                circleGuys.Add(item);
            }
            else if (item.triangleCount >= item.hexCount)
            {
                triangleGuys.Add(item);
            }
            else
            {
                hexGuys.Add(item);
            }   
        }

        //temp list to be assigned anothers values
         List<LilGuy> temp;

        //compaaring to find the largest list
        if (squareGuys.Count >= circleGuys.Count && squareGuys.Count >= triangleGuys.Count && squareGuys.Count >= hexGuys.Count)
        {
            temp = squareGuys;
            
                temp.Sort((a, b) => b.squareCount.CompareTo(a.squareCount));
            
        }
        else if (circleGuys.Count >= triangleGuys.Count || circleGuys.Count >= hexGuys.Count)
        {
            temp = circleGuys;
            
                temp.Sort((a, b) => b.circleCount.CompareTo(a.circleCount));
            
        }
        else if (triangleGuys.Count >= hexGuys.Count)
        {
            temp = triangleGuys;
            
                temp.Sort((a, b) => b.triangleCount.CompareTo(a.triangleCount));
            
        }
        else
        {
            temp = hexGuys;
            
                temp.Sort((a, b) => b.hexCount.CompareTo(a.hexCount));
            
        }

        int[] templilguy1 = new int[6] ;
        int[] templilguy2 = new int[6] ;
        for (int i = 0; i < 3; i++)
        {
            templilguy1[i] = temp[0].chromosomes[i];
            templilguy2[i] = temp[1].chromosomes[i];
        }
        for (int i = 3; i < 6; i++)
        {
            templilguy1[i] = temp[1].chromosomes[i];
            templilguy2[i] = temp[0].chromosomes[i];
        }

        for (int i = 0; i < 4; i++)
        {
            lilGuys[i].chromosomes = templilguy1.ToArray();
        }
        for (int i = 4; i < 8; i++)
        {
            lilGuys[i].chromosomes = templilguy2.ToArray();
        }

        foreach (var item in lilGuys)
        {
            for (int i = 0; i < item.chromosomes.Length; i++)
            {
                bool mutation= Random.Range(0,100f) < mutationRate ? true : false;
                if (mutation) 
                {
                    item.chromosomes[i] = Random.Range(0, 4);
                }
            }
            assignSprites(item);
        }
    }


    void assignSprites(LilGuy temp)
    {
        temp.head.sprite = parts[temp.chromosomes[0]];
        temp.body.sprite = parts[temp.chromosomes[1]];
        temp.armL.sprite = parts[temp.chromosomes[2]];
        temp.armR.sprite = parts[temp.chromosomes[3]];
        temp.legL.sprite = parts[temp.chromosomes[4]];
        temp.legR.sprite = parts[temp.chromosomes[5]];
    }

}
