using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace _02._Scripts.Study
{
    public class StudyPolygon : MonoBehaviour
    {
        void Start()
        {
            var mesh = new Mesh();

            var vertices = new[]
            {
                new Vector3(0, 0, 0),
                new Vector3(1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(1, 1, 0)
            };

            var triangles = new[]
            {
                0, 2, 1,
                2, 3, 1
            };

            var uv = new[]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(0, 1),
                new Vector2(1, 1)
            };

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uv;

            var meshFilter = gameObject.AddComponent<MeshFilter>();
            meshFilter.mesh = mesh;
            
            var meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshRenderer.material = new Material(Shader.Find("Sprites/Default"));
        }
    }
}