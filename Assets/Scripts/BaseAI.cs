using UnityEngine;
using System.Collections;

public class BaseAI : MonoBehaviour {

    Vector3 target;
    public float baseMovementSpeed;
    public float animationSpeedFactor = 0.5f;
    float currentMovementSpeed = 1;
    Animator animator;

    public GameObject character;

	void Start () {
        Invoke("StartWalking", 0.5f);         
    }
	
    void StartWalking()
    {
        animator = character.GetComponent<Animator>();
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
                       
           

            while (Mathf.Abs(transform.position.x - target.x) > 0.3f)
            {

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

                currentPosition.x += currentMovementSpeed * Time.deltaTime;
                transform.position = currentPosition;
                animator.speed = animationSpeedFactor;
                yield return new WaitForEndOfFrame();
            }

            currentPosition.x = target.x;
            transform.position = currentPosition;      

           

            while (Mathf.Abs(transform.position.z - target.z) > 0.3f)
            {

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

                currentPosition.z += currentMovementSpeed * Time.deltaTime;
                transform.position = currentPosition;
                animator.speed = animationSpeedFactor;
                yield return new WaitForEndOfFrame();
            }

            currentPosition.z = target.z;
            transform.position = currentPosition;

            ChooseDestination();
        }
    }
}
