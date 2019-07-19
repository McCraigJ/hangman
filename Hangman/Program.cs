using System;
using Hangman.Words;
using Microsoft.Extensions.DependencyInjection;

namespace Hangman
{
  class Program
  {
    static void Main(string[] args)
    {
      //var serviceProvider = new ServiceCollection()
      //  .AddScoped<IWords, StaticWords>()
      //  .BuildServiceProvider();

      var game = new Game.Game();
      game.RunGame(new StaticWords());

      //serviceProvider.Dispose();
    }
  }
}
