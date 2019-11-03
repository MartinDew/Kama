using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyController : MonoBehaviour
{
    public float visionRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    Animator anim;
    Vector3 startPosition;
    float stoppingDistance;
    public bool death;
    public float coolDown = 1f;
    public float coolDownTime;
    EnnemyComponent ennemy;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Main Character").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        death = false;
        
        coolDownTime = coolDown;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        stoppingDistance = agent.stoppingDistance;
        anim.SetInteger("moving", 0);
        ennemy = GetComponent<EnnemyComponent>();
    }

    void Update()
    {
        coolDown -= Time.deltaTime;
        if (!death)
        {
            float distance = Vector3.Distance(target.position, transform.position);


            if (distance <= visionRadius)
            {

                anim.SetInteger("battle", 1);
                agent.SetDestination(target.position);
                anim.SetInteger("moving", 1);

                if (distance <= agent.stoppingDistance)
                { 
                    // Stop moving and face the player
                    if (anim.GetInteger("moving") == 1)
                        anim.SetInteger("moving", 0);
                    FaceTarget();
                    // Attack...
                    if (coolDown <= 0)
                    {
                        target.gameObject.SendMessage("TakeDamage", ennemy.AttackComponent.Attack());
                        anim.SetInteger("moving", Random.Range(3, 5));
                        coolDown = coolDownTime / ennemy.AttackComponent.getTotalSpeed();
                    }

                }
            }
            else
            {
                float startingDistance = Vector3.Distance(startPosition, transform.position);
                anim.SetInteger("battle", 0);
                agent.SetDestination(startPosition);
                if (startingDistance >= agent.stoppingDistance)
                    anim.SetInteger("moving", 1);
                else
                    anim.SetInteger("moving", 0);
            }
        }
    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireCube(startPosition, new Vector3(1, 1, 1));
    }

    public void Die()
    {
        int result = Random.Range(12, 14);
        anim.SetInteger("moving", result);
        anim.SetTrigger("die");
        //agent.SetDestination(transform.position); 
        GetComponent<CharacterController>().enabled = false;
        death = true;
    }   

}
