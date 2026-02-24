using Godot;
using System;

public partial class PlayScene : Control, ILevelScene
{

    private LevelManager _levelManager;

    [Export]
    public Label Timer;

    [Export]
    public Button TryAgainButton;

    private float currentTime = 10.0f;
    private bool isPlaying = true;


    // Called when the node enters the scene tree for the first time.
    public void Init(LevelManager levelManager)
    {
        _levelManager = levelManager;
        if (levelManager == null)
        {
            GD.Print("DI FAILED");
        }
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
        if (isPlaying)
        {
            currentTime -= (float)delta;
            Timer.Text = currentTime.ToString();
        }
    }

    public void OnPlayTestPressed()
    {
        isPlaying = false;
        TryAgainButton.Visible = true;
        if(currentTime > 0)
        {
            GD.Print(currentTime);
            GameManager.Instance.SaveHighScore(currentTime);
        }
    }

    public void OnTryAgainPressed()
    {
        currentTime = 10.0f;
        isPlaying = true;
        TryAgainButton.Visible = false;

    }

    public void OnMainMenuButtonPressed()
    {
        _levelManager.LoadLevel(0);
    }
}
