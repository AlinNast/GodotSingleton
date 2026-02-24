using Godot;
using System;

public partial class LevelManager : Node
{
    [Export] 
    public PackedScene[] Levels; // Assign Menu, Game, and Options in the Inspector
    [Export] 
    public Node LevelContainer; // Drag the 'LevelContainer' node here in Inspector


    public override void _Ready()
    {
        // Automatically load Menu at startup assuming Menu is at index 0
        LoadLevel(0);
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= Levels.Length) return;

        // clear previous level nodes if any
        foreach (Node child in LevelContainer.GetChildren())
        {
            child.QueueFree();
        }

        // Instantiate the new scene
        Node nextScene = Levels[levelIndex].Instantiate();

      
        LevelContainer.AddChild(nextScene);

        // 3. Dependency Injection
        if (nextScene is ILevelScene levelScript)
        {
            levelScript.Init(this);
            GD.Print("Injected LevelManager into " + nextScene.Name);
        }
    }
}