
using UnityEngine;
using Version_1;

public static class Controls
{
    private static Player _player;
    private static readonly InputSystem_Actions Actions = new InputSystem_Actions();
    
    public static void Init(Player p)
    {
        _player = p;
        
        Actions.Enable();

        Actions.Player.Attack.performed += ctx => _player.Attack(ctx.ReadValueAsButton());
        Actions.Player.Look.performed += ctx => _player.Look(ctx.ReadValue<Vector2>());
        Actions.Player.Move.performed += ctx => _player.Move(ctx.ReadValue<Vector2>());
    }

}
