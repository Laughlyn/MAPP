using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubeController: MonoBehaviour
{

    public Material material;
    public int hitLimit;
    int hitCounter;

    public float hitDistance;
    public Vector3 hitVector = new Vector3(0 , 5.0f);
	public GameObject previousCube;
	public GameObject nextCube;

    Vector3 destination;
    Vector3 resetVector;

    Material CubeMaterial;
    Color CubeColor;

    // Use this for initialization
    void Start ()
	{
        destination = this.transform.position;
        resetVector.x = this.transform.position.x;

        //CubeMaterial = GetComponent<Renderer>().material;
        //CubeColor = new Color(Random.value, Random.value, Random.value);
        //CubeMaterial.SetColor("_Color", CubeColor);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(this.transform.position != destination)
        {
            this.transform.position += (destination - this.transform.position) * Time.deltaTime;
        }
        
        //CubeMaterial.SetColor("_EmissionColor", new Color(CubeMaterial.GetColor("_EmissionColor").r * 0.9f, CubeMaterial.GetColor("_EmissionColor").g * 0.9f, CubeMaterial.GetColor("_EmissionColor").b * 0.9f));
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            if (other.GetComponent<Rigidbody>().velocity.y > 0)
            {
                hitCounter++;
                destination += hitVector;
                //transform.position = new Vector3(transform.position.x, transform.position.y + hitDistance);
            }
            if (other.GetComponent<Rigidbody>().velocity.y < 0)
            {
                hitCounter--;
                destination -= hitVector;
                //transform.position = new Vector3(transform.position.x, transform.position.y - hitDistance);
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Player1")
        {
            other.GetComponent<PlayerMovement>().Harm(1);
            Debug.Log("Träffa Player1");
            destination = resetVector;
        }
        if (other.gameObject.tag == "Player2")
        {
            other.GetComponent<PlayerMovement>().Harm2(1);
            Debug.Log("Träffa Player2");
            destination = resetVector;
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
