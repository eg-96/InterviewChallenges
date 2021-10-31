using System;
using System.Linq;
using Xunit;

namespace InterviewChallenges
{
    public class UnitTest
    {
        [Fact]
        public void ValidatePalindromeWithLinQ()
        {
            var word = "Ana".ToLower();
            var isPalindrome = word.SequenceEqual(word.Reverse());

            Assert.True(isPalindrome);
        }

        [Fact]
        public void ValidatePalindrome()
        {
            var word = "Ana".ToLower();
            var firstHalf = word.Substring(0, word.Length / 2);
            var wordArray = word.ToCharArray();

            Array.Reverse(wordArray);

            var tempWord = new string(wordArray);
            var secondHalf = tempWord.Substring(0, tempWord.Length / 2);

            var isPalindrome = firstHalf.Equals(secondHalf);

            Assert.True(isPalindrome);
        }
    }
}
