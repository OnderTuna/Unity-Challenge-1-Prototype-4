using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    float speed = 5.0f;
    public GameObject focalPoint;
    public bool hasPowerUp = false;
    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(speed * verticalInput * focalPoint.transform.forward);
        powerUpIndicator.transform.position = transform.position;
    }        

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerCountDown());
        }
    }

    IEnumerator PowerCountDown ()
    {
        yield return new WaitForSeconds(5f);
        powerUpIndicator.gameObject.SetActive(false);
        hasPowerUp = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp == true)
        {
            Rigidbody enemyRigid = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigid.AddForce(awayFromPlayer * 10f, ForceMode.Impulse);
        }
    }
}
