using Godot;

namespace DefaultNamespace;

public partial class Game : CharacterBody2D
{
    [Export]
    public float Speed { get; set; } = 300.0f;

    public override void _PhysicsProcess(double delta)
    {
        // 1. Movement Input
        Vector2 inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        Velocity = inputDirection * Speed;

        MoveAndSlide();

        // 2. Rotate towards Mouse Position
        LookAt(GetGlobalMousePosition());

        // 3. Shooting Input
        if (Input.IsActionJustPressed("ui_accept") || Input.IsMouseButtonPressed(MouseButton.Left))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Add project/bullet instantiation logic here
        GD.Print("Bang!");
    }
}