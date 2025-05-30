using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AStarSearch : MonoBehaviour
{
    public static AStarSearch Instance { get; private set; }
    public Node start;
    public Node end;
    public LinkedList<Node> traversed = new LinkedList<Node>();
    public LinkedList<Node> accessibleNodes = new LinkedList<Node>();
    public LinkedList<Node> path = new LinkedList<Node>();
    public Node current;
    bool noPath=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Search()
    {
        SetStart();
       while (current != end && noPath!=true) 
        { 
        
        for (int i = 0; i < current.siblings.Count; i++)
        {
           
            if (traversed != null)
            {
                if (!IsTraversed(current.siblings[i]) && current != end && current.siblings[i].baseWeight<=7 && !accessibleNodes.Contains(current.siblings[i]))
                {

                    accessibleNodes.AddFirst(current.siblings[i]);
                        current.siblings[i].SetHeuristic();
                }
            }
                
        }
            if (accessibleNodes.Count == 0) 
                {
                    Debug.Log("No path available");
                noPath = true;
                }
        foreach (Node node in accessibleNodes)
        {
            if (node.weight == 0)
            {
                node.UpdateFatherAndCost(GetNewWeight(node),current);
            }
            else if (node.weight >= GetNewWeight(node))
                {
                node.UpdateFatherAndCost(GetNewWeight(node), current);
            }

            
        }
            Node nextNode = null;
        foreach(Node node in accessibleNodes)
            {
                if (nextNode== null)
                {
                    nextNode = node;    
                }
                else if (nextNode.weight>=node.weight)
                {
                    nextNode=node;
                }
                
            }
            current = nextNode;
            traversed.AddFirst(current);
            accessibleNodes.Remove(current);

            
        }
        while (current != start)
        {
            path.AddFirst(current);
            current=current.father;

        }
        foreach(Node node in path)
        {
            Debug.Log(node.name);
        }
        
    }
    bool IsTraversed(Node next)
    {
        foreach (Node node in traversed)
        {
            if (node == next)
            {
                return true;
            }
        }
        return false;
    }
    float GetNewWeight(Node node)
    {
        
        return current.weight + node.baseWeight + 1+ node.heuristic;
    }

   public void ShowAccessibleNodes()
    {
        foreach (Node node in accessibleNodes)
        {
            Debug.Log(node.name);
        }

    }

    public void SetStart() 
    {
        current = start;
        traversed.AddLast(current);
        current.UpdateFatherAndCost(0, current);
    }
}
