using UnityEngine;
using System.Collections;

public class ShieldProjectile : Projectile {

    protected override void init() {
        base.init();

        this.life = 100000f;
    }

    protected override void tick() {
        
    }

}
