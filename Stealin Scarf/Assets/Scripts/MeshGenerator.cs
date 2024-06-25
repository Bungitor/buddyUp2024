using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    public int xSize = 20;
    public int zSize = 20;

    public LayerMask buildingMask;

    public GameObject building;
    public GameObject bush;

    Vector3[] vertices;
    int[] triangles;
    
    void Start()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
        StartCoroutine(CreateShape());
        
    }

    private void Update()
    {
        UpdateMesh();
    }

    IEnumerator CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 2f;
                vertices[i] = new Vector3(x * 3, y, z * 3);
                i++;
            }
        }
        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
                

            }
            vert++;
        }
        yield return null;
        Debug.Log("Yippee");
        GenerateObjects(building, 23f, 1000, 5);
        GenerateObjects(bush, 5f, 100, 1);
        
        

    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null) return;

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }
    void GenerateObjects(GameObject GO, float distanceToNeighbour, int spawnAttempts, float heightDiff)
    {

        for (int i = 0; i < spawnAttempts; i++)
        {
            Vector3 vertex = vertices[Random.Range(0, vertices.Length - 1)];
            if ((vertex.x < 270 && vertex.z < 270 && vertex.x > 30 && vertex.z > 30) && (!Physics.CheckSphere(vertex, distanceToNeighbour, buildingMask)))
            {
                Instantiate(GO, new Vector3(vertex.x, vertex.y + heightDiff, vertex.z), new Quaternion(transform.rotation.x, Random.rotation.y, transform.rotation.z, transform.rotation.w));
            }
        }
    }
}
