using UnityEngine;
using System.Collections;

public class BaseAI : MonoBehaviour {

    Vector3 target;
    public float baseMovementSpeed;
    float currentMovementSpeed = 1;
    
    public GameObject character;

	void Start () {
        ChooseDestination();
        StartCoroutine(KeepWalking());
	}
	
	void ChooseDestination()
    {
        int randomX = Random.Range(0, 10);
        int randomZ = Random.Range(0, 10);
        target = new Vector3(randomX, 0, randomZ);
    }

    IEnumerator KeepWalking()
    {
        while (true)
        {
            Vector3 currentPosition = transform.position;

            Vector3 modelRotation = character.transform.eulerAngles;
                       
            if (transform.position.x < target.x)
            {
                modelRotation.y = 90;
                currentMovementSpeed = baseMovementSpeed;
            }
            else
            {
                modelRotation.y = -90;
                currentMovementSpeed = -baseMovementSpeed;
            }

            character.transform.eulerAngles = modelRotation;

            while (Mathf.Abs(transform.position.x - target.x) > 0.1f)
            {
                currentPosition.x += currentMovementSpeed * Time.deltaTime;
                transform.position = currentPosition;
                yield return new WaitForEndOfFrame();
            }

            currentPosition.x = target.x;
            transform.position = currentPosition;      

            if (transform.position.z < target.z)
            {
                modelRotation.y = 0;
                currentMovementSpeed = baseMovementSpeed;
            }
            else
            {
                modelRotation.y = 180;
                currentMovementSpeed = -baseMovementSpeed;
            }

            character.transform.eulerAngles = modelRotation;

            while (Mathf.Abs(transform.position.z - target.z) > 0.1f)
            {
                currentPosition.z += currentMovementSpeed * Time.deltaTime;
                transform.position = currentPosition;
                yield return new WaitForEndOfFrame();
            }

            currentPosition.z = target.z;
            transform.position = currentPosition;

            ChooseDestination();
        }
    }
}
