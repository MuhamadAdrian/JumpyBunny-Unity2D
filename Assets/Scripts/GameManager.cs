using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState{
        Menu, 
        InGame,
        GameOver
    };

    public GameState currentGameState = GameState.Menu;
    private static GameManager sharedInstance;

    private void Awake() {
        sharedInstance = this;
    }

    private void Start() 
    {
        currentGameState = GameState.Menu;

    }

    private void Update() {
        
        if (currentGameState != GameState.InGame && Input.GetButtonDown("s"))
        {
            this.currentGameState = GameState.InGame;
            StartGame();
        }
    }

    public static GameManager GetInstance(){
        return sharedInstance;
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        LevelGenerator.sharedInstance.RemoveAllBlock();
        LevelGenerator.sharedInstance.createInitializeBlock();
        PlayerController.GetInstance().StartGame();
        ChangeGameState(GameState.InGame);
    }

    // Update is called when player is die
    public void GameOver()
    {

        ChangeGameState(GameState.GameOver);
    }

    public void BackToMainMenu()
    {
        ChangeGameState(GameState.Menu);
    }

    void ChangeGameState(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.Menu : 
                //load Menu Scene
                break;
            case GameState.InGame : 
                //load In Game Scene
                break;
            case GameState.GameOver : 
                currentGameState = GameState.GameOver;
                break;
            default : 
                currentGameState = GameState.Menu;
                break;
        }
        currentGameState = newGameState;
    }
}
