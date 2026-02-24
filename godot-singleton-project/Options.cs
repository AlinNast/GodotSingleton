using Godot;
using System;

public partial class Options : Control, ILevelScene
{
    private LevelManager _levelManager;

    // Called when the node enters the scene tree for the first time.
    public void Init(LevelManager levelManager)
    {
        _levelManager = levelManager;
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}

    public void ClearScoreButtonPressed()
    {
        GameManager.Instance.ClearHighScore();
    }

    public void MainMenuButtonPressed()
    {
        _levelManager.LoadLevel(0);
    }
}
