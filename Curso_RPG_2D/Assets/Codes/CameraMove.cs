using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

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
    void Update()
    {
        //transform.position = new Vector3(target.transform.position.x, 
        //                          target.transform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        Vector3 des = target.transform.position + offset;
        
        des = new Vector3(
            Mathf.Clamp(des.x, xMin, xMax), 
            Mathf.Clamp(des.y, yMin, yMax), 
            offset.z);

        /* Quao menor o valor, mais lenta a câmera segue */
        Vector3 smooth = Vector3.Lerp(transform.position, des, 0.125f);

        transform.position = smooth;
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
