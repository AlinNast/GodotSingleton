using Godot;

public partial class Menu : Control, ILevelScene
{
    private LevelManager _levelManager;

    [Export]
    public Label HighScore;

    public void Init(LevelManager levelManager)
    {
        _levelManager = levelManager;
        // Ask the Singleton for the score
        float topScore = GameManager.Instance.HighScore;
        HighScore.Text = $"High Score: {topScore}";
    }

    public void OnPlayButtonPressed()
    {
        _levelManager.LoadLevel(1); // Load Game Scene
    }
}