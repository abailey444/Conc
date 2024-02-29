using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using SimplexNoise;

public class Generator : MonoBehaviour {
    [SerializeField] public Tilemap tm;
    [SerializeField] public Tile tile;
    private float[,] noise;
    
    private void Start() {
        // Create an array of simplex noise floats.
        noise = Noise.Calc2D(100,100, 0.1f); 

        // Set the grid to the noise pattern with a threshold "if(noise[x,y] > 75)"
        SetBaseGrid();

        // Find list of every empty space in the scene.
        FindAllEmptyTiles();
    }

    private void SetBaseGrid() {
        for(int x=0; x<100; x++) {
            for(int y=0; y<100; y++) {
                if(noise[x,y] > 75) {
                    tm.SetTile(new Vector3Int(x-50,y-50,0), tile);
                }
            }
        }
    }

    private Vector3Int[] FindAllEmptyTiles() {
        int x = 0, y = 0;
        Vector3Int[] ran_out_of_time_so_im_leaving_this = {new Vector3Int(x,y,0)};
        return ran_out_of_time_so_im_leaving_this;
    }
}
