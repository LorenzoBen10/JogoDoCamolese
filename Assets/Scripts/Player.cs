using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Player : MonoBehaviour
{
    Rigidbody2D rig;
    [SerializeField] SpriteRenderer sr;
    public int speed=5;
    public int jump=4;
    public Animator anima;
    bool chao, puloDuplo;
    // Start is called before the first frame update
    void Start()
    {
        rig=GetComponent<Rigidbody2D>();
        anima=GetComponent<Animator>();
    }
 
    // Update is called once per frame
    void Update()
    {
        mover();
        pular();
    }
 
    void mover(){
        rig.velocity=new Vector2(Input.GetAxis("Horizontal") * speed,rig.velocity.y);

        if(Input.GetAxis("Horizontal") == 0)
        {
            anima.Play("Idle");
        }
        else if(Input.GetAxis("Horizontal") != 0)
        {
            anima.Play("andando");
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX=false;
        }
    }
 
    void pular(){
        if(Input.GetButtonDown("Jump")){
            if(chao){
                rig.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                chao=false;
                puloDuplo=true;
            }
            else if(puloDuplo){
                rig.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                chao=false;
                puloDuplo=false;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D colisao){
        if(colisao.gameObject.CompareTag("Plataforma")){
            chao=true;
            puloDuplo=false;
        }
    }
}
