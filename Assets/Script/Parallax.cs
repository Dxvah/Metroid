using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float effect;
    private Transform camera;
    private Vector3 lastPostCamera;

    private void Start()
    {

        camera = Camera.main.transform;
        lastPostCamera = camera.position;
    }

    private void LastUpdate()
    {
        Vector3 movBackground = camera.position - lastPostCamera;
        transform.position += new Vector3(movBackground.x * effect, movBackground.y, 0);
        lastPostCamera = camera.position;
    }





}

