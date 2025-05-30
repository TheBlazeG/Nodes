using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GridGen : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;

    [SerializeField] GameObject node;

    [SerializeField] LayerMask nodeMask;


    private void Awake()
    {
        GenerateGrid();
    }

    public List<List<Node>> GenerateGrid()
    {
        float xOffset = node.transform.localScale.x + 0.25f;
        float zOffset = node.transform.localScale.z + 0.25f;
        List<List<Node>> gridMatrix;

        gridMatrix = new List<List<Node>>();

        for (int i = 0; i < width; i++)
        {
            gridMatrix.Add(new List<Node>());
            for (int j = 0; j < height; j++)
            {
                int weight = Random.Range(0, 10);
                if (weight > 7) { weight = int.MaxValue; }
                float xPos = xOffset * j;
                float zPos = zOffset * i;
                Vector3 postion = new Vector3(xPos, 0, zPos);
                GameObject cube = Instantiate(node, postion, node.transform.rotation);
                cube.name = "[" + i + "," + j + "]";
                Node currentNode = cube.AddComponent<Node>();
                
                currentNode.SetWeight(weight);
                gridMatrix[i].Add(currentNode);
            }
        }
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                //a
                if (CheckInRange(i - 1, j - 1, 0, width, 0, height))
                {
                    gridMatrix[i][j].siblings.Add(gridMatrix[i - 1][j - 1]);
                }

                if (CheckInRange(i - 1, j, 0, width, 0, height))
                {
                    gridMatrix[i][j].siblings.Add(gridMatrix[i - 1][j]);
                }
                if (CheckInRange(i - 1, j + 1, 0, width, 0, height))
                {
                    gridMatrix[i][j].siblings.Add(gridMatrix[i - 1][j + 1]);
                }

                //b
                if (CheckInRange(i, j - 1, 0, width, 0, height))
                {
                    gridMatrix[i][j].siblings.Add(gridMatrix[i][j - 1]);
                }
                if (CheckInRange(i, j + 1, 0, width, 0, height))
                {
                    gridMatrix[i][j].siblings.Add(gridMatrix[i][j + 1]);
                }

                //c
                if (CheckInRange(i + 1, j - 1, 0, width, 0, height))
                {
                    gridMatrix[i][j].siblings.Add(gridMatrix[i + 1][j - 1]);
                }
                if (CheckInRange(i + 1, j, 0, width, 0, height))
                {
                    gridMatrix[i][j].siblings.Add(gridMatrix[i + 1][j]);
                }
                if (CheckInRange(i + 1, j + 1, 0, width, 0, height))
                {
                    gridMatrix[i][j].siblings.Add(gridMatrix[i + 1][j + 1]);
                }
            }
        }
        node.SetActive(false);
        foreach (var i in gridMatrix)
        { foreach (var j in i)
            {
                j.SetMaterial();
            }
        }
        return gridMatrix;
    }

    bool CheckInRange(float x, float y, float minX, float maxX, float minY, float maxY)
    {
        return (x >= minX) && (x < maxX) && (y >= minY) && (y < maxY);
    }
}