using UnityEngine;
using System.Collections;

public class MorphUIHandler : MonoBehaviour {

    public Player player;

    public void MorphShape() {
        player.SpendSkillPoint(MorphType.Shape);
    }

    public void MorphMove() {
        player.SpendSkillPoint(MorphType.Movement);
    }

    public void MorphRotation() {
        player.SpendSkillPoint(MorphType.Rotation);
    }

    public void MorphProjectile() {
        player.SpendSkillPoint(MorphType.Projectiles);
    }

    public void MorphShields() {
        player.SpendSkillPoint(MorphType.Shields);
    }

    public void MorphHealth() {
        player.SpendSkillPoint(MorphType.Health);
    }

}
