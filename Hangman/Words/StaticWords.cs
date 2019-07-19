using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Words
{
  public class StaticWords : IWords
  {
    public List<string> GetWords()
    {
      return new List<string>
      {
        "banana",
        "apple",
        "orange"
      };
    }
  }
}
