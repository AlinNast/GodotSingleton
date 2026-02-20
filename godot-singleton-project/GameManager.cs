using Godot;
using System;

public partial class GameManager : Node
{
    // The static reference to the one and only instance
    public static GameManager Instance { get; private set; }

    public float HighScore = 2.0f; //{ get; set; }

    private const string SavePath = "user://highscore.save";

    public override void _Ready()
    {
        // Singleton Enforcement
        if (Instance == null)
        {
            Instance = this;
            
            LoadHighScore();
        }
    }

    public void SaveHighScore(float newScore)
    {
        if (newScore > HighScore)
        {
            HighScore = newScore;
            using var file = FileAccess.Open(SavePath, FileAccess.ModeFlags.Write);
            file.Store32((uint)HighScore);
        }
    }

    private void LoadHighScore()
    {
        if (FileAccess.FileExists(SavePath))
        {
            using var file = FileAccess.Open(SavePath, FileAccess.ModeFlags.Read);
            HighScore = (float)file.Get32();
        }
        GD.Print("Loaded High Score: " + HighScore);
    }

    public void QuitGame()
    {
        GetTree().Quit();
    }
}