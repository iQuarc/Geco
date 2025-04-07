using Humanizer;
using Microsoft.Extensions.DependencyInjection;

namespace Geco.Common.Inflector;

[Service(typeof(IInflector), ServiceLifetime.Singleton)]
public class HumanizerInflector : IInflector
{
   public string Pluralise(string word)
   {
      return word.Pluralize(false);
   }

   public string Singularise(string word)
   {
      return word.Singularize(false);
   }

   public string Titleise(string word)
   {
      return word.Titleize();
   }

   public string Humanise(string lowercaseAndUnderscoredWord)
   {
      return lowercaseAndUnderscoredWord.Humanize();
   }

   public string Pascalise(string lowercaseAndUnderscoredWord)
   {
      return lowercaseAndUnderscoredWord.Humanize().Pascalize();
   }

   public string Camelise(string lowercaseAndUnderscoredWord)
   {
      return lowercaseAndUnderscoredWord.Humanize(LetterCasing.LowerCase).Camelize().Replace(" ", "");
   }

   public string Underscore(string pascalCasedWord)
   {
      return pascalCasedWord.Underscore().Replace(" ", "");
   }

   public string Capitalise(string word)
   {
      return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
   }

   public string Uncapitalise(string word)
   {
      return word.Substring(0, 1).ToLower() + word.Substring(1);
   }

   public string Ordinalise(string number)
   {
      return number.Ordinalize();
   }

   public string Ordinalise(int number)
   {
      return number.Ordinalize();
   }

   public string Dasherise(string underscoredWord)
   {
      return underscoredWord.Dasherize();
   }
}