using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour {
    // Use this for initialization
    public float speed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.y += (Time.deltaTime * speed);
        mat.mainTextureOffset = offset;
	}
}
