using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    Camera mainCamera = new Camera();
    Transform originalPosition;
    Vector3 startPosition;
    Quaternion startRotation;

    // Use this for initialization
    void Start () {
        mainCamera = GetComponent<Camera>();
        //originalPosition = mainCamera.transform.transform;//new Transform(new Vector3(0f, 0f , -10f), new Quaternion() fainCamera.transform.transform;
        //originalPosition = new Transform(new Vector3(0f, 0f , -10f), new Quaternion(0f, 0f, 0f, 1f), new Vector3(0f,0f,0f));
        startPosition = new Vector3(0f, 0f, -10f);
        startRotation = new Quaternion(0f, 0f, 0f, 1f);
        //Debug.Log("startCamera::" + originalPosition.transform.position);
        //Debug.Log("startCamera::" + originalPosition.transform.rotation);

    }

    // Update is called once per frame
    void Update () {
		
	}

    public IEnumerator Shake(float duration, float magnitude)
    {
       Vector3 originalPosition = transform.localPosition;
        //Quaternion originalRotation = transform.localRotation;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);
            transform.Rotate(Vector3.forward * Random.Range(-1f ,1f) * magnitude);

            elapsed += Time.deltaTime;

            yield return null;
        }

       // transform.localPosition = originalPosition;
       // transform.localRotation = originalRotation;
        resetCamera();
    }

    void resetCamera()
    {
        mainCamera.transform.SetPositionAndRotation(startPosition, startRotation);
        //Debug.Log("resetCamera::" + originalPosition.transform.position);
    }
}
