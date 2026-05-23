using Task1.Interfaces;

namespace Homework_class02.Models
{
    public class Document : ISearchable
    {
        private string text;

        public Document(string text)
        {
            this.text = text;
        }

        public void Search(string word)
        {
            if (text.Contains(word))
            {
                Console.WriteLine($"Document contains the word: {word}");
            }
            else
            {
                Console.WriteLine($"This document doen NOT contain the word: {word}");
            }
        }
    }
}
