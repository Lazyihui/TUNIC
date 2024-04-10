using System;
using UnityEngine;

namespace TUNIC {


    public static class RoleDomain {
        public static RoleEntity Spawn(GameContext ctx, int typeID) {

            RoleEntity role = GameFactory.Role_Create(ctx.asstes, typeID, ctx.idService);

            ctx.roleRepository.Add(role);
            return role;
        }
    }
}