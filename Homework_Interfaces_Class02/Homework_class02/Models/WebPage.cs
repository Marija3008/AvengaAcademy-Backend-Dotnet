using Task1.Interfaces;

namespace Homework_class02.Models
{
    public class WebPage : ISearchable
    {
        private string content;

        public WebPage(string content)
        {
            this.content = content;
        }
        public void Search(string word)
        {
            if(content.Contains(word))
            {
                Console.WriteLine($"WebPage contains the word: {word}");
            }
            else
            {
                Console.WriteLine($"WebPage does NOT contains the word: {word}");
            }
        }
    }
}
