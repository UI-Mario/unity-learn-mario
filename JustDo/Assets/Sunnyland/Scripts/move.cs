using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class move : MonoBehaviour {
    public enum TriggerType
    {
        CollisionEnter,
        CollisionExit,
        TriggerEnter,
        TriggerExit
    };
    //移动速度和跳跃给的力
    public float Jumpforce = 1;
    public float MoveSpeed = 1;
    public bool isGrounded ;
    //物体与地面接触检测/挑起来的动画与其他动画切换
    public GameObject Foot; 
    public float radius = 0.3f;

    private bool m_jump = false;
    [SerializeField]
    private Animator m_animator;
    //声明游戏人物 
    private Rigidbody2D mario;
    //初始化
    private float horizontal = 0;
    private float mv = 0;
	// Use this for initialization
	void Start () {
        //获取mario和animator
        mario = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        //预防措施。缺陷：player下如果有两个foot，调bug到天荒地老
        if (Foot == null) 
        {
            Foot = GameObject.Find("player/foot");
        }
	}
	public void StopControl()
    {
        this.enabled = false;
        m_animator.SetBool("die", true);
        mario.velocity = new Vector2(mario.velocity.x, 0);
    }
	// Update is called once per frame
	void Update () {
        //按下空格键，跳跃的动画切换的判断布尔值为真
        if (m_jump == false && (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)))
        {
            mario.AddForce(new Vector2(0, Jumpforce));
            m_animator.SetBool("jump", true);

        }

        //趴下的判断布尔值为真
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            m_animator.SetBool("crouch", true);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) 
        {
            m_animator.SetBool("crouch", false);
        }

        horizontal = Input.GetAxis("Horizontal");
        
        //速度
        mv = horizontal * MoveSpeed;
        //人物向左走向右走，做一个翻转
        if (mv > 0) 
        {
            
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x),
                this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (mv < 0) 
        {
            this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x),
                this.transform.localScale.y, this.transform.localScale.z);
        }

        mario.velocity = new Vector2(mv, mario.velocity.y);

            //与地面碰撞检测
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(Foot.transform.position, radius);
        if (colliders!=null) 
        {
            for (int i = 0; i < colliders.Length; i++) 
            {
                if (colliders[i].gameObject.Equals(this.gameObject))
                    continue;
                else
                    isGrounded = true;
            }
        }

        if (isGrounded == false)
        {
            m_jump = true;

        }
        else
        {
            m_jump = false;
        }


        //不在地面就进行“跳”
        m_animator.SetBool("jump", !isGrounded);
        //跳的时候往上一个动画，往下一个动画
        m_animator.SetFloat("YSpeed", mario.velocity.y);
        //速度超过0.01（可能会改），开始“跑”的动画
        m_animator.SetFloat("movespeed", Mathf.Abs(mv));
        //

        if (mario.position.y < -30) 
        {
            ResourceManager.Instance().gameMenuCtr.showGameOverPanel();
            ResourceManager.Instance().characterCtr.StopControl();
        }
	}

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (m_jump == true && collision != null)
            
    //}
}
