using System.Text;
using Hangman.Words;

namespace Hangman.Game
{
  public enum GamePhase
  {
    Playing = 1,
    Won = 2,
    Lost = 3
  }
  public class GameState
  {
    public IWords WordsLogic { get; }

    public GameState(IWords wordsLogic)
    {
      WordsLogic = wordsLogic;
    }

    public GamePhase CurrentPhase { get; set; }
    public string CharactersGuessed { get; set; }

    public string CurrentAnswer { get; private set; }

    public int NumberIncorrectGuesses { get; set; }

    public int MaxGuesses { get; set; }

    public string CurrentMaskedAnswer { get; private set; }

    public int GuessesRemaining => MaxGuesses - NumberIncorrectGuesses;

    public void Initialise(int maxGuesses, string answer)
    {
      NumberIncorrectGuesses = 0;
      MaxGuesses = maxGuesses;
      CurrentPhase = GamePhase.Playing;
      CharactersGuessed = "";

      CurrentAnswer = answer;

      CurrentMaskedAnswer = "";
      for (var i = 0; i < CurrentAnswer.Length; i++)
      {
        CurrentMaskedAnswer = CurrentMaskedAnswer + "*";
      }
    }

    public void UpdateCurrentMaskedAnswer(char c)
    {
      StringBuilder sb = new StringBuilder(CurrentMaskedAnswer);

      for (var i = 0; i < CurrentAnswer.Length; i++)
      {
        if (CurrentAnswer[i] == c)
        {
          
          sb[i] = c;
        }
      }

      CurrentMaskedAnswer = sb.ToString();
    }
  }
}
