using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Node[] connections;
    public List<Node> siblings = new List<Node>();
    public Node father;
    public float weight;
    public int baseWeight;
    public float heuristic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    

    public void UpdateFatherAndCost(float newWeight, Node newFather)
    { 
        weight = newWeight;
        father = newFather;
    }

    public void SetWeight(int startWeight)
    { 
        baseWeight = startWeight;
        SetMaterial();

    }

    public void SetHeuristic()
    {
        heuristic = Mathf.Abs(AStarSearch.Instance.end.transform.position.magnitude - transform.position.magnitude);
    }

    public void SetMaterial()
    {
        Material material = GetComponent<Renderer>().material;

        Debug.Log(material.ToString());

        if (baseWeight > 7)
        {
            material.SetInt("_IsAccessible", 0);
        }
        else
        {
            material.SetFloat("_Weight_1", baseWeight);
        }
    }
}
