using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private float time = 0f;

    private Material material;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = Vector3.one * 1.5f;

        material = Renderer.material;

        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }

    void Update()
    {
        time += Time.deltaTime;
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

        if (time >= 3)
        {
            material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 0.04f);
            time = 0f;
        }
    }
}
