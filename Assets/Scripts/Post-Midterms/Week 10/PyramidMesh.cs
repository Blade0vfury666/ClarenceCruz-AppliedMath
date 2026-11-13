using System.Collections.Generic;
using UnityEngine;

public class PyramidMesh : MonoBehaviour
{
    [SerializeField] private Material lineMaterial;
    [SerializeField] private Vector3 position = Vector3.zero;
    [SerializeField] private float scale = 1.0f;
    [SerializeField] private float focalLength = 20.0f;
    [SerializeField] private float xRotation = 0.0f;
    [SerializeField] private float yRotation = 0.0f;

    private Mesh mesh;
    private List<Vector3> actualPosition = new List<Vector3>();
    private List<int> visibleEdges = new List<int>();

    private Vector3[] vertices = new Vector3[]
    {
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(-1.0f, -1.0f, 1.0f),
        new Vector3(1.0f, -1.0f, 1.0f),
        new Vector3(1.0f, -1.0f, -1.0f),
        new Vector3(-1.0f, -1.0f, -1.0f)
    };

    private int[][] faces = new int[][]
    {
        new int[] { 4, 3, 0 },
        new int[] { 3, 2, 0 },
        new int[] { 2, 1, 0 },
        new int[] { 1, 4, 0 },
        new int[] { 1, 2, 3, 4 }
    };

    private void Awake()
    {
        mesh = new Mesh();
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = lineMaterial;
    }

    private void LateUpdate()
    {
        actualPosition.Clear();
        foreach (Vector3 vertex in vertices)
        {
            actualPosition.Add(Project(vertex));
        }

        mesh.vertices = actualPosition.ToArray();
        visibleEdges.Clear();

        foreach (int[] face in faces)
        {
            if (FacesCamera(actualPosition[face[0]], actualPosition[face[1]], actualPosition[face[2]]))
            {
                for (int i = 0; i < face.Length; i++)
                {
                    visibleEdges.Add(face[i]);
                    visibleEdges.Add(face[(i + 1) % face.Length]);
                }
            }
        }

        mesh.SetIndices(visibleEdges, MeshTopology.Lines, 0);
        mesh.RecalculateBounds();
    }

    private Vector2 Project(Vector3 point)
    {
        point = point * 0.5f;

        float radX = xRotation * Mathf.Deg2Rad;
        float y = (point.y * Mathf.Cos(radX)) - (point.z * Mathf.Sin(radX));
        float z = (point.y * Mathf.Sin(radX)) + (point.z * Mathf.Cos(radX));
        point = new Vector3(point.x, y, z);

        float radY = yRotation * Mathf.Deg2Rad;
        float x = (point.x * Mathf.Cos(radY)) - (point.z * Mathf.Sin(radY));
        z = (point.x * Mathf.Sin(radY)) + (point.z * Mathf.Cos(radY));
        point = new Vector3(x, point.y, z);

        point = point + position;

        float perspective = focalLength / (focalLength + point.z);

        return new Vector2(point.x, point.y) * scale * perspective;
    }

    private bool FacesCamera(Vector2 a, Vector2 b, Vector2 c)
    {
        return ((b.x - a.x) * (c.y - a.y)) - ((b.y - a.y) * (c.x - a.x)) > 0.0f;
    }
}