using Godot;

public partial class Menu : Control, ILevelScene
{
    private LevelManager _levelManager;

    [Export]
    public Label HighScore;

    public void Init(LevelManager levelManager)
    {
        _levelManager = levelManager;
        if (levelManager == null)
        {
            GD.Print("DI FAILED");
        }
        // Ask the Singleton for the score
        float topScore = GameManager.HighScore;

        HighScore.Text = $"High Score: {topScore}";
    }

    public void OnPlayButtonPressed()
    {
        _levelManager.LoadLevel(1); // Load Game Scene
    }

    public void OnOptionsButtonPressed()
    {
        _levelManager.LoadLevel(2);
    }

    public void OnExitButtonPressed()
    {
        GameManager.Instance.QuitGame();
    }
}