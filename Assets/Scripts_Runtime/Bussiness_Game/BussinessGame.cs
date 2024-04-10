using System;
using UnityEngine;

namespace TUNIC {
    public static class BussinessGame {

        public static void Enter(GameContext ctx) {

            RoleEntity owner = RoleDomain.Spawn(ctx, 1);
            ctx.ownerRoleID = owner.id;

        }

        public static void FixedTick(GameContext ctx, float fixdt) {
            MoudelInput input = ctx.input;

            bool hasOwner = ctx.roleRepository.TryGet(ctx.ownerRoleID, out RoleEntity owner);
            if (!hasOwner) {
                return;
            }
            owner.Move(input.moveAxis, fixdt);
            owner.MoveFace(input.moveAxis, fixdt);
        }

        public static void LateTick(GameContext ctx, float dt) {

        }
    }
}