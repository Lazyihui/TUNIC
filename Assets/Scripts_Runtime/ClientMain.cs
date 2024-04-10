using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TUNIC {

    public class ClientMain : MonoBehaviour {

        [SerializeField] RoleEntity roleEntity;

        MoudelInput input;
        ModuleAsstes asstes;

        GameContext ctx;
        bool isTearDown;



        void Awake() {
            isTearDown = false;
            input = new MoudelInput();
            asstes = new ModuleAsstes();
            ctx = new GameContext();

            ctx.Inject(asstes, input);

            BussinessGame.Enter(ctx);
        }
        float restDT = 0;
        void Update() {

            float dt = Time.deltaTime;
            Vector2 moveAxis = Vector2.zero;

            if (Input.GetKey(KeyCode.W)) {
                moveAxis.y = 1;
            } else if (Input.GetKey(KeyCode.S)) {
                moveAxis.y = -1;
            }
            if (Input.GetKey(KeyCode.A)) {
                moveAxis.x = -1;
            } else if (Input.GetKey(KeyCode.D)) {
                moveAxis.x = 1;
            }
            input.moveAxis = moveAxis;


            restDT += dt;
            float fixedDT = Time.fixedDeltaTime;
            if (restDT >= fixedDT) {
                while (restDT >= fixedDT) {

                    FixedTick(fixedDT);

                    restDT -= fixedDT;
                }
            } else {
                FixedTick(restDT);
                restDT = 0;
            }

            LateTick(dt);


        }

        void FixedTick(float dt) {

            BussinessGame.FixedTick(ctx, dt);

            Physics.Simulate(dt);
        }

        void LateTick(float dt) {
            BussinessGame.LateTick(ctx, dt);
        }


        void OnApplicationQuit() {
            TearDown();
        }
        void OnDestroy() {
            TearDown();
        }
        void TearDown() {
            if (isTearDown) {
                return;
            }
            isTearDown = true;
            asstes.UnLoad();
        }

    }
}