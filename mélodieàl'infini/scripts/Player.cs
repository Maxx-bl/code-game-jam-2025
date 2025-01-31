using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private Vector2 _targetPosition;
    private bool _isMoving = false;
    public float _defaultSpeed = 800f;
    public float _maxSpeed = 6000f;
    public float Speed;
    private double _elapsedTime;
    private bool retryMenuOn = false;
    private Control hud;
    private AnimationPlayer deathAnim;
    private Node2D deathNode;

    Area2D areaShield;

    public int Hp;

    Vector2 ScreenSize;

    public override void _Ready()
    {
        Speed = _defaultSpeed;
        _targetPosition = Position;
        ScreenSize = GetViewportRect().Size;
        Hp = 3;
        hud = GetNode<Control>("hud");
        deathAnim = hud.GetNode<AnimationPlayer>("CanvasLayer/Death/Lifebar16x16/AnimationPlayer");
        deathAnim.Stop();
        deathNode = hud.GetNode<Node2D>("CanvasLayer/Death");
        deathNode.Hide();
        areaShield = GetNode<Area2D>("AreaExplosion");
        DisableShield();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion eventMouseMotion && _isMoving)
        {
            _targetPosition = GetGlobalMousePosition();
        }

        if (@event is InputEventMouseButton eventMouseClick && eventMouseClick.Pressed)
        {
            _targetPosition = GetGlobalMousePosition();
            _isMoving = true;
        }
        else if (@event is InputEventMouseButton eventMouseClick1 && !eventMouseClick1.Pressed)
        {
            _isMoving = false;
        }
    }

    public override void _Process(double delta)
    {
        if (_isMoving)
        {
            MouseMovement(delta);
        }
        else
        {
            KeyboardMovement(delta);
        }

        IncrementSpeed(delta);
    }

    private void MouseMovement(double delta)
    {
        Vector2 move = _targetPosition - Position;
        if (move.Length() > 5f)
        {
            Velocity = move.Normalized() * Speed;
            MoveAndSlide();
        }
    }

    private void KeyboardMovement(double delta)
    {
        Vector2 velocity = new Vector2();

        if (Input.IsActionPressed("player_up"))
        {
            velocity.Y -= 1;
        }
        if (Input.IsActionPressed("player_down"))
        {
            velocity.Y += 1;
        }
        if (Input.IsActionPressed("player_left"))
        {
            velocity.X -= 1;
        }
        if (Input.IsActionPressed("player_right"))
        {
            velocity.X += 1;
        }

        Velocity = velocity.Normalized() * Speed;
        MoveAndSlide();
    }

    private void IncrementSpeed(double delta)
    {
        _elapsedTime += delta;
        if (Math.Floor(_elapsedTime) > Math.Floor(_elapsedTime - delta))
        {
            if (Speed < _maxSpeed)
            {
                Speed += 50f;
                GetParent<Map>().glowMap.SpeedScale+=0.05f;
            }
        }
    }

    public void CollideWithEnemy()
    {
        if (Hp > 1)
        {
            deathNode.Show();
            Hp--;
            deathAnim.Play("Death");
        }
        else
        {
            if (!retryMenuOn)
            {
                retryMenuOn = true;
                GoToRetryMenu();
            }
        }
    }

    private void GoToRetryMenu()
    {
        PackedScene retryMenu = GD.Load<PackedScene>("res://HUD_RetryMenu/RetryMenu.tscn");
        Control retry = retryMenu.Instantiate<Control>();
        GetParent().AddChild(retry);
    }

    public async void EnableShield() {
        areaShield.Show();
        areaShield.AddToGroup("explosion");
        await ToSignal(GetTree().CreateTimer(4f), "timeout");
        DisableShield();
    }

    public void DisableShield() {
        areaShield.Hide();
        areaShield.RemoveFromGroup("explosion");
    }   
}
