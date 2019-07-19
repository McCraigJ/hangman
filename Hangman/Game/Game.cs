using System;
using Hangman.Words;

namespace Hangman.Game
{
  public class Game
  {
    public void RunGame(IWords wordsLogic)
    {
      var gameState = new GameState(wordsLogic);

      InitialiseNewGame(gameState, wordsLogic);
      bool run = true;

      RenderState(gameState);

      while (run)
      {
        var keyInfo = Console.ReadKey();

        run = keyInfo.Key != ConsoleKey.Escape;

        if (run)
        {

          if ((gameState.CurrentPhase == GamePhase.Lost || gameState.CurrentPhase == GamePhase.Won))
          {
            if (keyInfo.KeyChar == 'y')
            {
              InitialiseNewGame(gameState, wordsLogic);
            }
            else
            {
              run = false;
            }
          }
          else
          {
            if (gameState.CurrentPhase == GamePhase.Playing)
            {
              AddGuess(gameState, keyInfo.KeyChar);
            }
          }

          if (run)
          {
            RenderState(gameState);
          }
        }
      }
    }

    private void InitialiseNewGame(GameState gameState, IWords wordsLogic)
    {
      gameState.Initialise(5, GetAnswer(wordsLogic));
    }

    private string GetAnswer(IWords wordsLogic)
    {
      var words = wordsLogic.GetWords();

      var rnd = new Random();

      return words[rnd.Next(words.Count)];
    }

    private void RenderState(GameState gameState)
    {
      Console.Clear();
      Console.WriteLine(gameState.CurrentMaskedAnswer);
      Console.WriteLine("Guesses: " + gameState.CharactersGuessed);
      Console.WriteLine("Guesses Remaining: " + gameState.GuessesRemaining);

      switch (gameState.CurrentPhase)
      {
        case GamePhase.Playing:
          GameGraphics.RenderHangmanIncorrect(gameState.NumberIncorrectGuesses);
          break;

        case GamePhase.Won:
          GameGraphics.RenderHangmanCorrect();
          Console.WriteLine("You have won! Would you like to play again? (y/n)");
          break;

        case GamePhase.Lost:
          GameGraphics.RenderHangmanIncorrect(gameState.NumberIncorrectGuesses);
          Console.WriteLine("You have lost! Would you like to play again? (y/n)");
          break;
      }
    }

    private void AddGuess(GameState gameState, char c)
    {
      if (gameState.CharactersGuessed.Contains(c))
      {
        return;
      }

      gameState.CharactersGuessed = gameState.CharactersGuessed + c;

      if (gameState.CurrentAnswer.Contains(c))
      {
        gameState.UpdateCurrentMaskedAnswer(c);
      }
      else
      {
        gameState.NumberIncorrectGuesses++;
      }

      if (gameState.GuessesRemaining == 0)
      {
        gameState.CurrentPhase = GamePhase.Lost;
      }
      else if (!gameState.CurrentMaskedAnswer.Contains("*"))
      {
        gameState.CurrentPhase = GamePhase.Won;
      }
    }
  }
}
