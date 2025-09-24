using UnityEngine;

//utilizing a static class so the script doesn't require a game object and be accessed from anywhere
public static class GameOverSummary 
{
    public static int totalResearch = 0; //keeping track of the total points in the game
    public static float totalTime = 0f; //keeping track of the total time in the game
}
