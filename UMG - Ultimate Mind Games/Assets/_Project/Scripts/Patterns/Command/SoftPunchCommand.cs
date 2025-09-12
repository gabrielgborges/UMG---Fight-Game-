using UnityEngine;

public class SoftPunchCommand : HitCommand
{
    public Vector2 Value { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public override void Execute(Combatent combatent)
    {
        combatent.Attack("SoftPunch");
    }
}
