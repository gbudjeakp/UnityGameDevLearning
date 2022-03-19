using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinateCoordinates;

    Node startNode;
    Node destinationNode;
    Node currentSearchNode;
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();
    Queue<Node> frontier = new Queue<Node>();



    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }
        startNode = new Node(startCoordinates, true);
        destinationNode = new Node(destinateCoordinates, true);

    }
    void Start()
    {
        BreadthFirstSearch();
    }

    private void ExploreNeighbours()
    {
        List<Node> neighbours = new List<Node>();

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = currentSearchNode.coordinates + direction;

            if (grid.ContainsKey(neighbourCoords))
            {
                neighbours.Add(grid[neighbourCoords]);
            }

        }

        foreach(Node neighbour in neighbours)
        {
            if(!reached.ContainsKey(neighbour.coordinates) && neighbour.isWalkable)
            {
                reached.Add(neighbour.coordinates, neighbour);
                frontier.Enqueue(neighbour);
            }
        }
    }

    void BreadthFirstSearch() 
    {
        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);

        while(frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExlored = true;
            ExploreNeighbours();
            if(currentSearchNode.coordinates == destinateCoordinates)
            {
                isRunning = false;
            }
        }
    }
}
