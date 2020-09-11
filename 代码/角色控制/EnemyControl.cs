using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{

    public Transform[] wayPoint;
    public float DisRange = 8.0f;
    public float AttackDisRange = 1.0f;
    public float lerpTarget;
    //public Combatant combatant;
    public Slider slider;
   // public PlayerInput pi;
    
  

    int index = 0;

    private Transform player;
    private Animator anim;
    private NavMeshAgent agent;
    private Rigidbody rig;
    private BoxCollider col;


    private bool IsDead = false;
    private float enemyCurrentHealth = 100.0f;//敌人当前血量
    private float enemyMaxHealth =100.0f;//敌人最大血量
   
   


    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        agent.speed = Random.Range(1.0f, 3.0f);
        //enemyCurrentHealth = combatant.health;
        //enemyMaxHealth = combatant.health;
        slider.value = enemyCurrentHealth / enemyMaxHealth;//初始化血条
    }


    void Update()
    {
        float Dis = Vector3.Distance(player.position, transform.position);//获得距离
        //边跑边打
        if (Dis < DisRange && IsDead == false)
        {
            anim.SetFloat("speed", agent.speed);
            //Vector3 Moveforward = Vector3.MoveTowards(transform.position, player.transform.position, agent.speed * Time.deltaTime);
            agent.SetDestination(player.position);
            agent.transform.LookAt(player.position);
          
            if (Dis < AttackDisRange)
            {
                anim.SetTrigger("attack");

            }
        }
        else 
        {
            Partrol();//做导航运动;
        }

        //enemyCurrentHealth = combatant.health;
        enemyCurrentHealth = Mathf.Clamp(enemyCurrentHealth, 0, enemyMaxHealth);
        slider.value = enemyCurrentHealth / enemyMaxHealth; //更新血条
        if (slider.value == 0)
        {
            // print("敌人血量为0，死亡了");
            IsDead = true;
            anim.SetBool("death", IsDead);
            //死亡之后禁用碰撞和刚体，敌人就死在地面上不用管了
            col.enabled = false;
            Destroy(rig);
            Destroy(gameObject, 4.0f);
                 
        }
        else
        {
            IsDead = false;
        }
    }

    public void OnAttackIdleEnter()
    {
        lerpTarget = 0f; //从攻击状态进入idle状态的时候把图层权重设为0
    }

    public void OnAttackIdleUpdate()
    {
        float currentWeight = anim.GetLayerWeight(anim.GetLayerIndex("Attack"));
        currentWeight = Mathf.Lerp(currentWeight, lerpTarget, 0.5f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack"), currentWeight);
    }

    //攻击图层的attack状态（这里就真正控制了攻击动画的播放）
    public void OnAttackEnter()
    {
        lerpTarget = 1.0f;
    }
    //攻击动画权重 做一个平滑处理
    public void OnAttackUpdate()
    {
        float currentWeight = anim.GetLayerWeight(anim.GetLayerIndex("Attack"));//获取攻击图层的权重值
        currentWeight = Mathf.Lerp(currentWeight, lerpTarget, 0.5f);//lerp
        anim.SetLayerWeight(anim.GetLayerIndex("Attack"), currentWeight);//设置攻击层权重值
    }
   
    void Partrol()
    {
        if (wayPoint.Length == 0)
        { return; }

        agent.stoppingDistance = 0;

        if (IsDead == false)
        {
            agent.SetDestination(wayPoint[index].position);
            transform.LookAt(wayPoint[index].position);

            if (agent.remainingDistance < 0.5f && !agent.pathPending)
            {
                index = (index + 1) % wayPoint.Length;
            }
        }
        else if(IsDead ==true)
        {
            agent.isStopped = true;
        }
    }
    public void takedamage(float damage)
    {
        enemyCurrentHealth -= damage;
    }
}

       



