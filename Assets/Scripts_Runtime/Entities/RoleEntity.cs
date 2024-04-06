using System;
using UnityEngine;
using UnityEngine.AI;

namespace TUNIC {


    public class RoleEntity : MonoBehaviour {

        [SerializeField]  Transform bodyTF;

        // [SerializeField] Rigidbody rb;

        // [SerializeField ] Animation anim;

        public int id;

        // 试一下
        [SerializeField] public float moveSpeed;


        public void Ctor() { }

        public void Move(Vector3 moveAxis, float dt) { }

        public void Move(Vector3 moveAxis, float moveSpeed, float dt) {

        }
    }
}