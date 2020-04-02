using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballmovement : MonoBehaviour
{
    public int speed=30;
    public Rigidbody2D sesuatu;

    public Animator animtr;
    // Start is called before the first frame update
    void Start()
    {
        sesuatu.velocity = new Vector2(-1,-1) * speed;
        animtr.SetBool("isMove", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(sesuatu.velocity.x > 0){ //bola bergerak kekanan
            sesuatu.GetComponent<Transform>().localScale = new Vector3(1,1,1);
        }else{
            sesuatu.GetComponent<Transform>().localScale = new Vector3(-1,1,1);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.name=="dindingKanan" || other.collider.name=="dindingKiri"){
            StartCoroutine(jeda());
        }
    }
    IEnumerator jeda(){
        sesuatu.velocity = new Vector2(0,0);
        animtr.SetBool("isMove", false);
        sesuatu.GetComponent<Transform>().position = new Vector2(0,0);
        yield return new WaitForSeconds(1);
        sesuatu.velocity = new Vector2(-1,-1) * speed;
        animtr.SetBool("isMove", true);
    }
}
