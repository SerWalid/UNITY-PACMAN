using System;
using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public int coins;
    public float moveSpeed = 5f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            Debug.Log("Coin collected");
            coins = coins + 1;
            Debug.Log(coins);
            other.gameObject.SetActive(false);
            StartCoroutine(ReactivateCoinAfterDelay(other.gameObject, 2f));
        }
    }

    private IEnumerator ReactivateCoinAfterDelay(GameObject coinToReactivate, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (coinToReactivate != null)
        {
            coinToReactivate.SetActive(true);
        }
    }
}
