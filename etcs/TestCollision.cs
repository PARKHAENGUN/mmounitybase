using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{   
    //1) 나 or 상대한테 RigidBody 있어야 한다 (isKinematic : off)
    //2) 나한테 Collider가 있어야 한다 (IsTrigger : off)
    //3) 상대한테 Collider가 있어야 한다 (IsTrigger : off)

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @{collision.gameObject.name} ! ");
    }

    //1) 둘 다 Collider 가 있어야 한다
    //2) 둘 중 하나는 IsTrigger : On
    //3) 둘 중 하나는 RigidBody 가 있어야 한다
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger @ {other.gameObject.name} ! ");
    }

    void Start()
    {
        
    }

   
    void Update()
    {

        //Local -> World <-> Viewport <-> Screen (화면)
        //Debug.Log(Input.mousePosition); //Screen    
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); //Viewport 화면 비율
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");

            //int mask = (1 << 8) | (1 << 9);

            RaycastHit hit;
            if (Physics.Raycast(ray,out hit, 100.0f,mask))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }
       

        /*if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            Vector3 dir = mousePos - Camera.main.transform.position;
            dir = dir.normalized;

            Debug.DrawRay(Camera.main.transform.position, dir*100.0f, Color.red, 1.0f);

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, dir, out hit,100.0f))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }*/
        
    }
}
