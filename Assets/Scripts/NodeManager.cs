using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public Node start;
    public Node end;
    private LinkedList <Node> traversed= new LinkedList<Node>();
    public Node current;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current=start;
        traversed.AddLast(current);
        Search();
        foreach (Node node in traversed) { Debug.Log(node.name); };
        traversed.Clear();
    }

    public void Search()
    {
        //while (current != end)
       // {
            for (int i = 0; i < current.connections.Length; i++)
            {
            //if ( i <= current.connections.Length-1 )
            //{
            if (traversed != null)
            {
                if ((!IsTraversed(current.connections[i]) && current != end))
                {

                    traversed.AddLast(current.connections[i]);
                    current = current.connections[i];
                    Search();
                }
            }
            
                   

                    
                //}   
                
                

            }
            if (current != end)
            {
                traversed.RemoveLast();
            }
            
       // }
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

    public void ClearList()
        {
        foreach (Node node in traversed) { Debug.Log(node.name); };
        traversed.Clear(); }
}
