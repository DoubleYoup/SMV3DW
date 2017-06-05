using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour {

    public Mesh[] meshes;
    public Material material;
    public int maxDepth;
    private int depth;
    public float childScale;
    private Material[,] materials;
    public float spawnProbablility;
    public float maxRatationSpeed;
    private float rotationSpeed;
    public float maxTwist;

	// Use this for initialization
	void Start () 
    {
        
        if (materials == null)
        {
            InitializeMaterials();
        }
        rotationSpeed = Random.Range(-maxRatationSpeed, maxRatationSpeed);
        transform.Rotate((Random.Range(-maxTwist, maxTwist)), 0f,0f);
        gameObject.AddComponent<MeshFilter>().mesh = meshes[Random.Range(0,meshes.Length)];
        gameObject.AddComponent<MeshRenderer>().material = material;
        GetComponent<MeshRenderer>().material = materials[depth, Random.Range(0,2)];
        if (depth < maxDepth)
        {
            StartCoroutine(CreateChildren());
        }
	}

    private void Update ()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f); 
    }
	
    private IEnumerator CreateChildren()
    {
        for (int i = 0; i < childrenDirection.Length; i++)
        {
            if(Random.value < spawnProbablility)
            {
                yield return new WaitForSeconds (Random.Range(0.1f, 0.5f));
                new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, i);
            }
        }
         
    }

    private void Initialize (Fractal parent, int childIndex)
    {
        maxRatationSpeed = parent.maxRatationSpeed;
        spawnProbablility = parent.spawnProbablility;
        meshes = parent.meshes;
        materials = parent.materials;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        transform.parent = parent.transform;
        childScale = parent.childScale;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = childrenDirection[childIndex] *(0.5f +0.5f * childScale);
        transform.localRotation = childrenOrientation[childIndex];
    }

    private void InitializeMaterials()
    {
        materials = new Material[maxDepth + 1, 2];
        for (int i = 0; i <=maxDepth; i++)
        {
            float t = i / (maxDepth - 1f);
            t *= t;
            materials[i, 0] = new Material(material);
            materials[i, 0].color =  Color.Lerp (Color.white, Color.yellow, (float)i/maxDepth);
            materials[i, 1] = new Material(material);
            materials[i, 1].color =  Color.Lerp (Color.white, Color.cyan, (float)i/maxDepth);
        }
        materials[maxDepth, 0].color = Color.magenta;
        materials[maxDepth, 1].color = Color.red;
    }


    private static Vector3[] childrenDirection =
    {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back

    };

    private static Quaternion[] childrenOrientation =
    {
        Quaternion.identity,
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, 90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f)
    };
}
