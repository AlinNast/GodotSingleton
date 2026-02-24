using Godot;
using System;

public partial class GameManager : Node
{
    // The static reference to the one and only instance
    public static GameManager Instance { get; private set; }

    public static float HighScore; //{ get; set; }

    private string SavePath = OS.GetExecutablePath().GetBaseDir().PathJoin("highscoree.save");

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
        if (newScore < HighScore || HighScore == 0)
        {
            HighScore = newScore;
            using var file = FileAccess.Open(SavePath, FileAccess.ModeFlags.Write);
            file.StoreFloat(HighScore);
            GD.Print(file);
        }
    }

    private void LoadHighScore()
    {
        if (FileAccess.FileExists(SavePath))
        {
            using var file = FileAccess.Open(SavePath, FileAccess.ModeFlags.Read);
            HighScore = file.GetFloat();
        }
        
    }

    public void ClearHighScore()
    {
        HighScore = 0;
        using var file = FileAccess.Open(SavePath, FileAccess.ModeFlags.Write);
        file.StoreFloat(0);
    }


    public void QuitGame()
    {
        GetTree().Quit();
    }
}