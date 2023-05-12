using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    public float detectRadius;

    //code to change transition from zombie scream and zombie walk according to detectRadius
    private Animator animator;


    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 player_position = player.transform.position;
        player_position.y = transform.position.y; // Ensure enemy stays upright
        //enemy will look at player   
        transform.LookAt(player_position);
        float distance = Vector3.Distance(transform.position, player.transform.position);

        //if the player is under detect radius
        if(distance <= detectRadius){
            agent.SetDestination(player.transform.position); 
            Debug.Log("Check distance" + distance);

              //check if the player is inside than 2.5 distance to activate attack animation 
             if (distance < 2.5){
                animator.SetBool("inRange", true);
                Debug.Log("Check close" + distance);
                 
            }
            else{
                // if the player is under detect radius but not inside 2.5 radius it will start walk towards player animation
                animator.SetBool("Aware",true);
                animator.SetBool("inRange", false);
            }
        }
        
        else{
            // activates zombie scream animation
           animator.SetBool("Aware",false);
           animator.SetBool("inRange", false);
           //stop enemy after transitioning form walking to screaming 
           agent.SetDestination(transform.position);
        }
        
    }
}
