using System;
using UnityEngine;
using UnityEngine.AI;

namespace TUNIC {


    public class RoleEntity : MonoBehaviour {

        [SerializeField] Transform bodyTF;

        [SerializeField] Rigidbody rb;
        // 试一下
        [SerializeField] public float moveSpeed;

        // [SerializeField ] Animation anim;

        public int id;



        public void Ctor() { }

        public void Init() { }        //用四元数做面向 
        public void MoveFace(Vector2 moveAxis, float dt) {
            if (moveAxis == Vector2.zero) {
                return;
            }
            Vector3 newForward = new Vector3(moveAxis.x, 0, moveAxis.y);
            transform.rotation = Quaternion.LookRotation(newForward);
            rb.angularVelocity = Vector3.zero;
        }
        public void Move(Vector3 moveAxis, float dt) {
            Move(moveAxis, this.moveSpeed, dt);
        }

        public void Move(Vector3 moveAxis, float moveSpeed, float dt) {
            Vector3 moveDir = new Vector3(moveAxis.x, 0, moveAxis.y);
            moveAxis.Normalize();
            // velocity 速度
            rb.velocity = moveDir * moveSpeed;
        }
    }
}