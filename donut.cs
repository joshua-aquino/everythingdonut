using Godot;
using System;

public class donut : StaticBody
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private bool rotating = false;
    private bool timerDone = true;
    private Vector2 previousMousePosition;
    private Vector2 nextMousePosition;
    private float swipeSpeed;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public void onSwipeTimerTimeout() {
        GD.Print("lol");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("Rotate")) 
        {
            rotating = true;
            previousMousePosition = GetViewport().GetMousePosition();
        }
        if (Input.IsActionJustReleased("Rotate"))
        {
            rotating = false;
        }
        if (rotating) {
            nextMousePosition = GetViewport().GetMousePosition();
            swipeSpeed = nextMousePosition.y - previousMousePosition.y;
            RotateY(swipeSpeed * .01f * delta);
            previousMousePosition = nextMousePosition;
        }
        if (swipeSpeed > 1 || swipeSpeed < -1) {
            RotateY(swipeSpeed * .01f * delta);
            if (swipeSpeed > 1)
            swipeSpeed -= 0.1f;
            else
            swipeSpeed += 0.1f;
        }
    }
}
