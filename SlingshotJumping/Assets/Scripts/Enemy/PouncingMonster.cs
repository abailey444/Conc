using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouncingMonster : MonoBehaviour {
    public Nav grid;
    [SerializeField] public Transform seeker;
    private List<Vector3Int> posList;
    private Vector3Int seekerNode, currentNode;

    private void Start() {
        // make the list local
        foreach(var node in grid.nodes) { posList.Add(node); }
    }

    private void FixedUpdate() {
        FindCurrentNodes(seeker.position, transform.position);
        FindClosestPath(seekerNode, currentNode);
    }

    private void FindCurrentNodes(Vector3 seekerPos, Vector3 currentPos) {
        seekerNode = Vector3Int.zero;
        seekerNode.x = Mathf.FloorToInt(seeker.position.x);
        seekerNode.y = Mathf.FloorToInt(seeker.position.y);
        seekerNode.z = 0;

        currentNode = Vector3Int.zero;
        currentNode.x = Mathf.FloorToInt(transform.position.x);
        currentNode.y = Mathf.FloorToInt(transform.position.y);
        currentNode.z = 0;
    }

    private void FindClosestPath(Vector3Int seeker, Vector3Int self) {
        foreach(Vector3Int pos in posList) {

        }


    }

    private void FindAdjacentOpenCells(Vector3Int origin) {
        Vector3Int[] potentialAdjacents = { new Vector3Int(origin.x + 1, origin.y, 0),
                                            new Vector3Int(origin.x + 1, origin.y + 1, 0),
                                            new Vector3Int(origin.x, origin.y + 1, 0),
                                            new Vector3Int(origin.x - 1, origin.y + 1, 0),
                                            new Vector3Int(origin.x - 1, origin.y, 0),
                                            new Vector3Int(origin.x - 1, origin.y - 1, 0),
                                            new Vector3Int(origin.x, origin.y - 1, 0),
                                            new Vector3Int(origin.x + 1, origin.y - 1, 0) };
    }
}
