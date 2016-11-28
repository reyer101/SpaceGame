using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController Script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            if (tag == "Star")
            {
                Destroy(other.gameObject);
                return;
            }
        }
        if (other.tag == "Star")
        {
            return;
        }
        if (other.tag == "Hazard")
        {
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            return;
        }
        if (other.tag == "Bolt" && tag == "Star")
        {
            Destroy(other.gameObject);
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        gameController.AddScore(scoreValue);       
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
	
}
