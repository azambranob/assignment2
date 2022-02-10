/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/
using System;
using System.Collections.Generic;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //use if statements to return the position. the first if statement rturns the maximum number based on the lenght of the array if the target is greater than the last number in the array. if the target is less than the first number in the array return 0.
                if (nums[nums.Length - 1] < target)
                    return nums.Length;
                if (nums[0] > target)
                    return 0;
                //use binary search to find numbers inside the range of the array.
                int binarysearch = Array.BinarySearch(nums, target);
                if (binarysearch > -1) // if the binarysearch is greater than -1 return the position
                    return binarysearch;
                binarysearch = Array.BinarySearch(nums, target - 1);
                if (binarysearch > -1)
                {
                    //if the binarysearch postion in the array is less than the the target then return the binary search and add one postion
                    if (nums[binarysearch] < target)
                        return binarysearch + 1;
                }
                binarysearch = Array.BinarySearch(nums, target + 1);
                if (binarysearch > -1)
                {
                    //if the binarysearch postion in the array is greater than the the target then return the binary search
                    if (nums[binarysearch] > target)
                        return binarysearch;
                }
                // return -1 if none of the cirterias are met
                return -1;

            }
            catch (Exception)
            {
                throw;
            }
        }

        // the solution took me about an hour it was my first time using binary search. It was a great excersise since I learned how to use binary search which is faster than just looping trough the array.

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.

        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                // stored all punctuation symbols in an array
                char[] pun = { ' ', '!', '?', ',', ';', '.', '\'' };
                // remove punctuaations form the paragrpah
                string[] arr = paragraph.Split(pun, StringSplitOptions.RemoveEmptyEntries);
                //use dictionaty to store the count of the words
                Dictionary<string, int> dict = new Dictionary<string, int>();
                HashSet<string> hash = new HashSet<string>();


                foreach (var w in arr)
                {
                    //makes the word lower case
                    string word = w.ToLower();
                    // then use the hash function to convert the string to an integer to count the number of similar words
                    if (hash.Contains(word))
                        continue;
                    dict.TryAdd(word, 0);
                    dict[word]++;
                }

                int maxCount = 0;
                string ans = "";
                // loop through every key in the dictionary and gets the key with the highest count and stores it in a ans variable
                foreach (var key in dict)
                {
                    if (key.Value > maxCount)
                    {
                        maxCount = key.Value;
                        ans = key.Key;
                    }
                }
                return ans;
            

                
            }
            catch (Exception)
            {

                throw;
            }
        }

        // the question took me more than an hour as I had to learn to use Dictionary and hash. I learned how to count the number of strings using the hash function

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                // creates a dictionary to store the count of values 
                IDictionary<int, int> val2Count = new Dictionary<int, int>();
                // loops through all the number in  
                foreach (var num in arr)
                {
                    //use containskey to search for especific values in the dictionary and if it does not find the value adds it to the  
                    if (!val2Count.ContainsKey(num))
                    {
                        val2Count[num] = 0;
                    }

                    // if the number is there then increment by one 
                    val2Count[num]++;
                }

               
                if (val2Count.Count == 0)
                {
                    return -1;
                }

                int res = -1;
                //  loop to go through all values in the directory and and if statement that helps find the matching values and return the one witht the max value 
                foreach (var p in val2Count)
                {
                    //FindLucky matching key and value and returns the maximum count  
                    if (p.Key == p.Value)
                    {
                        res = Math.Max(res, p.Value);
                    }
                }

                return res;
               
            }
            catch (Exception)
            {

                throw;
            }

        }

       
        // the soultion took me about an hour. I had to learned how to use ditionaries and look for specific keys in the dictionary.

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"

        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int[] count = new int[10];

                int Bulls = 0;
                int i;
                // loop through all secret characters and checks if the characters in the secret and guess match and increment the variable bull by one
                for (i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == guess[i]) { Bulls++; }
                    else { count[secret[i] - '0']++; }
                }

                int Cows = 0;

                // loop through all guess characters and checks if the characters do not macth and if they dont it increment the count in Cows variable
                for (i = 0; i < guess.Length; i++)
                {
                    if (secret[i] != guess[i] && count[guess[i] - '0'] > 0)
                    {
                        count[guess[i] - '0']--;
                        Cows++;
                    }
                }

                string result = (Bulls + "A" + Cows + 'B');

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //took me about an hour. It was a good excersise where I learned how to match one array to the other one and do different counts

        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int[] positions = new int[26];
                int i;
                //loops through the string and looks fot the last index array for each character
                for (i = 0; i < s.Length; i++)
                    positions[s[i] - 'a'] = i;
                var result = new List<int>();
                // to keep track of the beggining and ending 
                int maxPosition = 0;
                int previous = 0;

                // loops through string characters to find the current max position and if the max position matches the position then the variable resul is 
                for ( i = 0; i < s.Length; i++)
                {
                  // it hepls to find the current max position of each character 
                    maxPosition = Math.Max(maxPosition, positions[s[i] - 'a']);
                    
                    // shows that we have reached to the max postion of the character and found the partition and we can add it to the output array
                    if (maxPosition == i)
                    {
       
                        result.Add(i - previous + 1);
                      
                        previous = i + 1;
                    }
                }

                return result;

              
            }
            catch (Exception)
            {
                throw;
            }
        }

        // the soulution took me about two hours. I ahd trouble trying to figure out how to find the current max postion of each character 

        /*
        Question 6

        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.



         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {

                // Create alphabet letter to width index map and use dictionary to store the alphabet and the index
                var alphabet = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();
                var index = Enumerable.Range(0, 26).ToArray();
                var map = alphabet.Zip(index, (key, value) => new { key, value }).ToDictionary(x => x.key, x => x.value);

                // loops through every letter in the string to increase the reading fram until it gets to 100 and adds a row when it gets to 100 
                int rows = 1, currReadingFrame = 0;
                foreach (var letter in s)
                {
                    //maps letter weight to the width of the letter 
                    var letterWeight = widths[map[letter]];
                    // condition to check if the currReadingFrame is less than 100 to add to it or start a new row and currreadingframe
                    if (currReadingFrame + letterWeight <= 100)
                       
                        currReadingFrame += letterWeight;
                    else
                    {
                        rows += 1;
                        currReadingFrame = letterWeight;
                    }
                }


                return new List<int>() { rows, currReadingFrame};
            }
            catch (Exception)
            {
                throw;
            }

        }

        //took me about an hour. I had to learn how to use dictionary to map alphabet and index.

        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                // use Stack to 
                Stack<char> charsStack = new Stack<char>();

               // loops through every character in the string and goes through the four different cases to make sure that meets the requirment of open and closing symbols
                foreach (char c in bulls_string10)
                {
                    switch (c)
                    {
                        case ']':
                            { // checks if the total element in the stack is 0 and if the item of the top of the stack is not the open bracket and if any of the cases are not met then return False
                                if (charsStack.Count == 0 || charsStack.Pop() != '[')
                                {
                                    return false;
                                }

                                break;
                            }
                        case '}':
                            {
                                if (charsStack.Count == 0 || charsStack.Pop() != '{')
                                {
                                    return false;
                                }

                                break;
                            }
                        case ')':
                            {
                                if (charsStack.Count == 0 || charsStack.Pop() != '(')
                                {
                                    return false;
                                }

                                break;
                            }
                        default:
                            { // characters are added to the stack
                                charsStack.Push(c);
                                break;
                            }
                    }
                }

                // return True if none of the cases below are met
                return charsStack.Count == 0;


            }
            catch (Exception)
            {
                throw;
            }


        }

        // the solution took me about an hour. I learned hot to use Stack to be able to go through to all the characters in the string and check if the conditions is met for each case

        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                // use dictionary to stare the the morse code for each letter and number
                Dictionary<char, String> morse = new Dictionary<char, String>()
            {
                {'a' , ".-"},
                {'b' , "-..."},
                {'c' , "-.-."},
                {'d' , "-.."},
                {'e' , "."},
                {'f' , "..-."},
                {'g' , "--."},
                {'h' , "...."},
                {'i' , ".."},
                {'j' , ".---"},
                {'k' , "-.-"},
                {'l' , ".-.."},
                {'m' , "--"},
                {'n' , "-."},
                {'o' , "---"},
                {'p' , ".--."},
                {'q' , "--.-"},
                {'r' , ".-."},
                {'s' , "..."},
                {'t' , "-"},
                {'u' , "..-"},
                {'v' , "...-"},
                {'w' , ".--"},
                {'x' , "-..-"},
                {'y' , "-.--"},
                {'z' , "--.."},
                {'0' , "-----"},
                {'1' , ".----"},
                {'2' , "..---"},
                {'3' , "...--"},
                {'4' , "....-"},
                {'5' , "....."},
                {'6' , "-...."},
                {'7' , "--..."},
                {'8' , "---.."},
                {'9' , "----."},
            };

                int i = 0;
                // use hash to store the values to help them match wich allows them to dont have duplicates
                HashSet<string> hash = new HashSet<string>();
                string str = string.Empty;
                
                // loops through every word in the string and for each word transform to morse and stores it in the string str 
                foreach (var word in words)
                {
                    str = string.Empty;
                    for (i = 0; i < word.Length; i++)
                    {
                        str += morse[word[i]];
                    }
                    hash.Add(str);
                }
                // return the count of all the items in the hash
                return hash.Count;


            }
            catch (Exception)
            {
                throw;
            }

        }

        // solution took me about an hour. it was a good excercise where I had to use hash to store the morse item and eliminates duplicates



        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                int t1Length = word1.Length, t2Length = word2.Length;
                var x = new int[t1Length + 1, t2Length + 1];

                // loops using enumerable range to loop from 0 to the lenght of each word
                foreach (var i in Enumerable.Range(0, t1Length + 1))
                {
                    foreach (var j in Enumerable.Range(0, t2Length + 1))
                    {
                        // the if statmenets help move the letters, replace the letters, and remove the letter
                        if (i == 0 && j == 0) x[i, j] = 0; 
                        else if (i == 0) x[i, j] = x[i, j - 1] + 1;
                        else if (j == 0) x[i, j] = x[i - 1, j] + 1;
                        else if (word1[i - 1] == word2[j - 1]) x[i, j] = x[i - 1, j - 1];
                        else
                        {
                            var minInherited = (new int[] { x[i - 1, j - 1], x[i - 1, j], x[i, j - 1] }.Min());
                            x[i, j] = 1 + minInherited;
                        }
                    }
                }
                return x[t1Length, t2Length];
                

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
