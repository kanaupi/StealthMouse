using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WayPointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    //プレイヤーを見失う距離
    public float loseSightDistance = 1.0f;

    //ステージ内を巡回するポイント
    public Transform[] waypoints;

    public GameEnding gameEnding;

    public GameObject detected;

    Transform player;

    public GameObject exclamationPop;

    //プレイヤー発見時にwaypointにタゲをなすりつけるのを防止
    bool isDetected=false;

    int currentWaypointIndex;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        navMeshAgent.SetDestination(waypoints[0].position);
        audioSource = detected.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(navMeshAgent.stoppingDistance);
        //waypoint到着時に呼ばれる
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance&&!isDetected)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
     
        if ((navMeshAgent.remainingDistance > loseSightDistance) && isDetected)
        {
            exclamationPop.SetActive(false);
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
            isDetected = false;
        }
    }
    //プレイヤーを発見した時に呼び出される
    public void DetectPlayer()
    {
        isDetected = true;
        exclamationPop.SetActive(true);
        navMeshAgent.SetDestination(player.position);
        audioSource.Play();
    }

    //プレイヤー到着時に呼ばれる
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            exclamationPop.SetActive(false);
            gameEnding.IsCaught();
            Destroy(this);
        }
    }
}
