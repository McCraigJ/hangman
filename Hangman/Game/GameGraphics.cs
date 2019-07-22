using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Game
{
  public static class GameGraphics
  {
    public static void RenderHangmanIncorrect(int numberOfIncorrectGuesses)
    {

      switch (numberOfIncorrectGuesses)
      {
        case 1:
          Console.WriteLine(" O ");
          break;
        case 2:
          Console.WriteLine(" O ");
          Console.WriteLine("<  ");
          break;
        case 3:
          Console.WriteLine(" O ");
          Console.WriteLine("< >");
          break;
        case 4:
          Console.WriteLine(" O ");
          Console.WriteLine("< >");
          Console.WriteLine("/  ");
          break;
        case 5:
          Console.WriteLine("  |");
          Console.WriteLine(" x|");
          Console.WriteLine("< >");
          Console.WriteLine("/ \\");
          break;
      }

    }

    public static void RenderHangmanCorrect()
    {
      Console.WriteLine(" O ");
      Console.WriteLine("< >");
      Console.WriteLine("/ \\");
    }

  }
}

//  O
// < >
// / \ 