using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if(gameController == null) {
            Debug.Log("Cannot find GameController script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boundary"))
        {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);

        Instantiate(explosion, transform.position, transform.rotation);
        if(other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);

    }
}
