using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    Rigidbody2D rig;
    public GameObject ponto;
    public GameObject arm;
    public Vector3 direction;
    public float force;

    public float[] minMax = new float[2];

    public bool atirou = false;
    public bool diminui = false;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        tirinho();
    }

    private void tirinho()
    {
        if(atirou == false)
        {
            rig.Sleep();
        }
        else
        {
            
        }
        
        if(Input.GetKey(KeyCode.B))
        {

            if(diminui == false)
            {
                force += Time.fixedDeltaTime * 0.01f;
                if(force > minMax[1])
                {
                    diminui = true;
                }
            }
            if (diminui == true)
            {
                force -= Time.fixedDeltaTime * 0.01f;
                if (force < minMax[0])
                {
                    diminui = false;
                }
            }


        }

        if (Input.GetKey(KeyCode.V))
        {
            atirou = true;
            transform.position = arm.transform.position;
            direction =  transform.position - ponto.transform.position;
            
            rig.AddForce(new Vector2(-direction.normalized.x * force, -direction.normalized.y * force),ForceMode2D.Impulse);

            force = minMax[0];

        }


    }


            


}
