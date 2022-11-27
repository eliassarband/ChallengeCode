// See https://aka.ms/new-console-template for more information

using ChallengeCode;
using System.Net.Http.Headers;

Solution sln = new Solution();

int[] tokens = { 100 , 200 , 300 , 400};
int score = sln.BagOfTokenScore(tokens, 200);

Console.WriteLine(score);

bool str = sln.isValid("([]){}");

Console.WriteLine(str);
