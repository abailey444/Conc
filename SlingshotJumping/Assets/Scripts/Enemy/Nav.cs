using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Nav : MonoBehaviour {
    [SerializeField] public Vector2Int bounds;
    //[SerializeField] public int nodeSize;
    [SerializeField] public Vector3Int origin;
    public List<Vector3Int> nodes;
    private Tilemap map;

    private void Awake() {
        map = GetComponent<Tilemap>();
        origin += map.origin;
        SetNodes();
    }

    private void SetNodes() {
        for(int x=0; x < bounds.x; x++) {
            for(int y=0; y < bounds.y; y++) {
                Vector3Int checkedTile = new Vector3Int(origin.x + x, origin.y + y, 0);
                if(map.GetTile(checkedTile) != null)
                    nodes.Add(checkedTile);
            }
        }
    }
}
