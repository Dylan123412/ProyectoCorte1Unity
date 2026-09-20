using UnityEngine;

public class teleporter : MonoBehaviour
{

    public GameObject teleport;
    public GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            player.transform.position = teleport.transform.position;

            

        }


    }
}
