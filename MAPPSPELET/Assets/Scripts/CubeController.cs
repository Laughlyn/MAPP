using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubeController: MonoBehaviour {

    public Material material;
    Material CubeMaterial;
    Color CubeColor;
   // Color ZeroColor = new Color(0,0,0);

	// Use this for initialization
	void Start () {
        CubeMaterial = GetComponent<Renderer>().material;
        CubeColor = new Color(Random.value, Random.value, Random.value);
        CubeMaterial.SetColor("_Color", CubeColor);
    }

	
	// Update is called once per frame
	void Update ()
    {
       CubeMaterial.SetColor("_EmissionColor", new Color(CubeMaterial.GetColor("_EmissionColor").r * 0.9f, CubeMaterial.GetColor("_EmissionColor").g * 0.9f, CubeMaterial.GetColor("_EmissionColor").b * 0.9f));
	}


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            CubeMaterial.SetColor("_EmissionColor", new Color(1f, 1f, 1f));
            Debug.Log("Hit!");
            Destroy(collision.gameObject);
        }
    }
}
