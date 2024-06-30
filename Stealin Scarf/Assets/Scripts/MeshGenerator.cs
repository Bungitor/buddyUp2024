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

    public GameObject[] buildings;
    public GameObject[] bushes;
    public GameObject platyer;

    Vector3[] vertices;
    int[] triangles;
    

    MeshCollider meshCollider;
    
    void Start()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        meshCollider = gameObject.AddComponent<MeshCollider>();

    }

    private void Update()
    {
        UpdateMesh();
    }

    void CreateShape()
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
        Debug.Log("Yippee");
        GenerateRandomObjects(buildings, 23f, 1000, 0);
        GenerateRandomObjects(bushes, 5f, 100, 1);
        //PlacePlayer();
    }

    //private void PlacePlayer()
    //{
    //    int count = 0;
    //    do
    //    {
    //        Vector3 vertex = vertices[Random.Range(0, vertices.Length - 1)];
    //        if ((vertex.x < 270 && vertex.z < 270 && vertex.x > 30 && vertex.z > 30) && (!Physics.CheckSphere(vertex, 6, buildingMask)))
    //        {
    //            Instantiate(platyer, new Vector3(vertex.x, vertex.y + 6, vertex.z), new Quaternion(transform.rotation.x, Random.rotation.y, transform.rotation.z, transform.rotation.w));
    //        }
    //        count++;
    //    } while (GameObject.Find("Platyer") == null && count < 1000);

    //    //if (GameObject.Find("Platyer") == null) PlacePlayer();
    //}

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();

        meshCollider.sharedMesh = mesh;
        meshCollider.sharedMesh.RecalculateBounds();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null) return;

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }
    void GenerateRandomObjects(GameObject[] GO, float distanceToNeighbour, int spawnAttempts, float heightDiff)
    {
        for (int i = 0; i < spawnAttempts; i++)
        {
            Vector3 vertex = vertices[Random.Range(0, vertices.Length - 1)];
            if ((vertex.x < 270 && vertex.z < 270 && vertex.x > 30 && vertex.z > 30) && (!Physics.CheckSphere(vertex, distanceToNeighbour, buildingMask)))
            {
                GameObject bingus = GO[Random.Range(0, GO.Length)];
                Instantiate(bingus, new Vector3(vertex.x, vertex.y + heightDiff, vertex.z), new Quaternion(transform.rotation.x, Random.rotation.y, transform.rotation.z, transform.rotation.w));
            }
        }
    }




}
