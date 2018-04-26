using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubeController: MonoBehaviour
{

    public Material material;
    public int hitLimit;
    int hitCounter;
    Material CubeMaterial;
    Color CubeColor;
	public GameObject previousCube;
	public GameObject nextCube;

	// Use this for initialization
	void Start ()
	{
        CubeMaterial = GetComponent<Renderer>().material;
        CubeColor = new Color(Random.value, Random.value, Random.value);
        CubeMaterial.SetColor("_Color", CubeColor);
    }
	
	// Update is called once per frame
	void Update ()
    {
       //CubeMaterial.SetColor("_EmissionColor", new Color(CubeMaterial.GetColor("_EmissionColor").r * 0.9f, CubeMaterial.GetColor("_EmissionColor").g * 0.9f, CubeMaterial.GetColor("_EmissionColor").b * 0.9f));
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            if (other.GetComponent<Rigidbody>().velocity.y > 0)
            {
                hitCounter++;
                transform.position = new Vector3(transform.position.x, transform.position.y + 1f);
            }
            if (other.GetComponent<Rigidbody>().velocity.y < 0)
            {
                hitCounter--;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1f);
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Player1"))
        {
            other.GetComponent<PlayerMovement>().Harm(1);
            Debug.Log("Träffa");
            this.transform.position = new Vector3(transform.position.x, 0);
        }
        if (other.CompareTag("Player2"))
        {
            other.GetComponent<PlayerMovement>().Harm2(1);
            Debug.Log("Träffa Player");
            this.transform.position = new Vector3(transform.position.x, 0);
        }
    }
}

    /*  void OnCollisionEnter(Collision collision)
      {
          if (collision.gameObject.tag == "Projectile")
          {
              if(collision.relativeVelocity.y > 0)
              {
                  Debug.Log(collision.relativeVelocity);
                  hitCounter++;
              }
              if(collision.relativeVelocity.y < 0)
              {
                  Debug.Log(collision.relativeVelocity);
                  hitCounter--;
              }
              if(hitCounter > hitLimit)
              {
                  GetComponent<Rigidbody>().velocity = new Vector3(0f, 30f);
                  Destroy(gameObject, 1.0f);
              }
              if(hitCounter < -hitLimit)
              {
                  //"Drop" the block
                  GetComponent<Rigidbody>().velocity = new Vector3(0f, -30f);

                  //Adjust the next block
                  nextCube.GetComponent<Transform>().Translate(-0.125f, 0f, 0f);
                  nextCube.GetComponent<Transform>().localScale = new Vector3(0.375f, 1f);
                  nextCube.GetComponent<CubeController>().hitCounter = 0;

                  //Adjust the previous block
                  previousCube.GetComponent<Transform>().Translate(0.125f, 0f, 0f);
                  previousCube.GetComponent<Transform>().localScale = new Vector3(-0.375f, 1f);
                  previousCube.GetComponent<CubeController>().hitCounter = 0;

                  //Unlink the dropped block
                  previousCube.GetComponent<CubeController>().nextCube = nextCube;
                  nextCube.GetComponent<CubeController>().previousCube = previousCube;

                  //Destroy the cube
                  Destroy(gameObject, 1.0f);
              }
              CubeMaterial.SetColor("_EmissionColor", new Color(1f, 1f, 1f));
          }
      }*/
