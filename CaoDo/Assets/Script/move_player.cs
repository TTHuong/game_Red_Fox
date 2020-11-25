using System.Collections;
using UnityEngine;

public class move_player : MonoBehaviour
{
    GameObject obj;
    private float movePower = 1;
    private float moveSpeed = 6;
    public float jumPower = 4;
    private Animator anim;
    private bool D=false;
    private bool A=false;
    private bool S=false;
    private SpriteRenderer PlayerSpriteRenderer;
    public bool touchTheGround=false;
    // Start is called beore the first frame update
    void Start()
    {
        obj = gameObject;
        anim = obj.GetComponent<Animator>();
        anim.SetBool("die", false);
        anim.SetBool("jum", false);
        anim.SetBool("duck", false);
        anim.SetBool("move_right", false);
        anim.SetBool("move_left", false);
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            D=true;
            A=false;

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            D=false;
            anim.SetBool("move_right", false);
        }

        if(D==true){
            // obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed * Time.deltaTime * movePower, 0));
            obj.transform.Translate(new Vector3(moveSpeed * Time.deltaTime * movePower, 0, 0));
            // obj.transform.localScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y, obj.transform.localScale.z);
                anim.SetBool("move_right", true);
                PlayerSpriteRenderer.flipX = false;
            
        }

        ///khu cua a

        if (Input.GetKeyDown(KeyCode.A))
        {
            A=true;
            D=false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            A=false;
            anim.SetBool("move_left", false);
        }

        if(A==true){
            // obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveSpeed * Time.deltaTime * movePower, 0)); 
            obj.transform.Translate(new Vector3(-moveSpeed * Time.deltaTime * movePower, 0, 0));
            // obj.transform.localScale = new Vector3(-(obj.transform.localScale.x), obj.transform.localScale.y, obj.transform.localScale.z);
            anim.SetBool("move_left", true);
            PlayerSpriteRenderer.flipX = true;
        }

        ///khu cua w

        if(Input.GetKeyDown(KeyCode.W) &&  touchTheGround ){
            // obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumPower)); 
            // obj.transform.Translate(new Vector3(0, 8 * Time.deltaTime * jumPower , 0));
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumPower), ForceMode2D.Impulse);
            // obj.transform.localScale = new Vector3(-(obj.transform.localScale.x), obj.transform.localScale.y, obj.transform.localScale.z);
            anim.SetBool("jum", true);
            touchTheGround=false;   
        }

        ///khu cua s

        if (Input.GetKeyDown(KeyCode.S))
        {
            S=true;
            // D=false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            S=false;
            anim.SetBool("duck", false);
        }

        if(S==true){
            // obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveSpeed * Time.deltaTime * movePower, 0)); 
            // obj.transform.Translate(new Vector3(-moveSpeed * Time.deltaTime * movePower, 0, 0));
            // obj.transform.localScale = new Vector3(-(obj.transform.localScale.x), obj.transform.localScale.y, obj.transform.localScale.z);
            anim.SetBool("duck", true);
            // PlayerSpriteRenderer.flipX = true;
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag.Equals("wall"))
        {
            touchTheGround = true;
        }
    } 

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag.Equals("wall"))
        {
            touchTheGround = false;
            anim.SetBool("jum", false);
        }
    } 
}
