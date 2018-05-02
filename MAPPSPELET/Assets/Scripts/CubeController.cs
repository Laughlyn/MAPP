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
    public Vector3 destinationMax;
    public Vector3 hitVector = new Vector3(0 , 5.0f);
	public GameObject previousCube;
	public GameObject nextCube;

    public AudioClip impact;
    private AudioSource source;

    Vector3 destination;
    Vector3 resetVector;

    Material CubeMaterial;
    Color CubeColor;

    // Use this for initialization
    void Start ()
	{
        destination = transform.position;
        resetVector.x = transform.position.x;

        //Random color for blocks
        //CubeMaterial = GetComponent<Renderer>().material;
        //CubeColor = new Color(Random.value, Random.value, Random.value);
        //CubeMaterial.SetColor("_Color", CubeColor);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(transform.position != destination)
        {
            transform.position += (destination - transform.position) * Time.deltaTime;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            if (other.GetComponent<Rigidbody>().velocity.y > 0)
            {
                hitCounter++;
                destination += hitVector;
                destination.y = Mathf.Clamp(destination.y, -destinationMax.y, destinationMax.y);
            }
            if (other.GetComponent<Rigidbody>().velocity.y < 0)
            {
                hitCounter--;
                destination -= hitVector;
                destination.y = Mathf.Clamp(destination.y, -destinationMax.y, destinationMax.y);
            }
            source = GetComponent<AudioSource>();
            source.PlayOneShot(impact);
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
