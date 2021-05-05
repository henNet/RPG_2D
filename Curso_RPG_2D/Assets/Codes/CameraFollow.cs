using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private float xMax, xMin, yMax, yMin;
    [SerializeField]
    private Tilemap tileM;
    private Vector3 minTile, maxTile;


    // Start is called before the first frame update
    void Start()
    {
        minTile = tileM.CellToWorld(tileM.cellBounds.min);
        maxTile = tileM.CellToWorld(tileM.cellBounds.max);
        limits(minTile, maxTile);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, xMin, xMax), 
            Mathf.Clamp(target.position.y, yMin, yMax), -10f
        );
    }

    void limits(Vector3 minTile, Vector3 maxTile)
    {
        Camera cam = Camera.main;
        float altura = 2f * cam.orthographicSize;
        float largura = altura * cam.aspect;

        xMin = minTile.x + largura/2;
        xMax = maxTile.x - largura/2;
        yMin = minTile.y + altura/2;
        yMax = maxTile.y - altura/2;
    }
}
