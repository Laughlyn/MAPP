using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    Camera mainCamera = new Camera();
    Transform originalPosition;

	// Use this for initialization
	void Start () {
        mainCamera = GetComponent<Camera>();
        originalPosition = mainCamera.transform.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;
        Quaternion originalRotation = transform.localRotation;

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

        transform.localPosition = originalPosition;
        transform.localRotation = originalRotation;
        resetCamera();
    }

    void resetCamera()
    {
        mainCamera.transform.SetPositionAndRotation(originalPosition.position, originalPosition.rotation);
    }
}
