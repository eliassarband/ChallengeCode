using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCode
{
    public class Solution
    {
        static int finalScore = 0;
        public int BagOfTokenScore(int[] tokens, int power)
        {

            for (int i = 0; i < tokens.Length; ++i)
            {
                List<int> tempToken = tokens.ToList<int>();
                tempToken.RemoveAt(i);

                RecursiveBag(i, tokens[i], tempToken.ToArray<int>(), power, 'U', "", 0);
                RecursiveBag(i, tokens[i], tempToken.ToArray<int>(), power, 'D', "", 0);


            }

            return finalScore;
        }

        public void RecursiveBag(int tokenIndex,int tokenValue,int[] tokens, int power,char face, string path, int score)
        {
            if (face == 'U' && tokenValue <= power)
            {
                power -= tokenValue;
                ++score;
                path += tokenIndex.ToString() + face;
            }

            if (face == 'D' && score > 0)
            {
                power += tokenValue;
                --score;
                path += tokenIndex.ToString() + face;
            }

            if (tokens.Length > 0)
            {
                
                for (int i = 0; i < tokens.Length; ++i)
                {
                    List<int> tempToken = tokens.ToList<int>();
                    tempToken.RemoveAt(i);

                    RecursiveBag(i, tokens[i], tempToken.ToArray<int>(), power, 'U', "", score);
                    RecursiveBag(i, tokens[i], tempToken.ToArray<int>(), power, 'D', "", score);
                }
            }
            else
            {
                if (score > finalScore)
                {
                    finalScore = score;
                }
            }
        }

        public bool isValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            char[] str = s.ToCharArray();

            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i]== '(' || str[i] == '[' || str[i] == '{')
                {
                    stack.Push(str[i]);
                }
                else if (str[i] == ')')
                {
                    if (stack.Pop() != '(')
                    {
                        return false;
                    }
                }
                else if (str[i] == ']')
                {
                    if (stack.Pop() != '[')
                    {
                        return false;
                    }
                }
                else if (str[i] == '}')
                {
                    if (stack.Pop() != '{')
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

    }
}
