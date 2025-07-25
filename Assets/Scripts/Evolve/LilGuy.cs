using UnityEngine;

public class LilGuy : MonoBehaviour
{

    public SpriteRenderer head;
    public SpriteRenderer body;
    public SpriteRenderer armL;
    public SpriteRenderer armR;
    public SpriteRenderer legL;
    public SpriteRenderer legR;
    public int squareCount, circleCount, triangleCount,  hexCount;

   

    public int[] chromosomes = new int[6];
    private void Awake()
    {
        for (int i = 0; i < chromosomes.Length; i++)
        {
            chromosomes[i] = Random.Range(0,4);
        }

    }
}
