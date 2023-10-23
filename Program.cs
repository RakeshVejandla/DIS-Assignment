﻿/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                IList<IList<int>> output = new List<IList<int>>();

                // Handle the case of missing ranges before the first element
                if (lower < nums[0])
                {
                    output.Add(MakeRange(lower, nums[0] - 1));
                }

                // Handle the case of missing ranges between elements of nums
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] - nums[i - 1] > 1)
                    {
                        output.Add(MakeRange(nums[i - 1] + 1, nums[i] - 1));
                    }
                }

                // Handle the case of missing ranges after the last element
                if (upper > nums[nums.Length - 1])
                {
                    output.Add(MakeRange(nums[nums.Length - 1] + 1, upper));
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }

            //Adding the range for the first and last of the Array Values
            static IList<int> MakeRange(int start, int end)
            {
                return new List<int> { start, end };
            }

        }

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Create a dictionary to map opening brackets to their corresponding closing brackets.
                Dictionary<char, char> brackets = new Dictionary<char, char>
                {
                    {'{',  '}'},
                    {'(',  ')'},
                    {'[',  ']'},
                };

                // Initialize a stack to keep track of the encountered brackets.
                Stack<char> output = new Stack<char>();

                // Iterate through each character in the input string.
                foreach (char b in s)
                {
                    // If the character is an opening bracket, push it onto the stack.
                    if (brackets.ContainsKey(b))
                    {
                        output.Push(b);
                    }
                    else
                    {
                        // If the stack is empty, there's no corresponding opening bracket; return false.
                        if (output.Count == 0)
                        {
                            return false;
                        }
                        // Check if the closing bracket matches the last encountered opening bracket.
                        if (brackets[output.Pop()] == b)
                        {
                            // Continue to the next character.
                            continue;
                        }
                        // If there's no match, return false.
                        return false;
                    }
                }
                // If the stack is empty at the end, all brackets were properly closed; return true.
                return output.Count == 0;
            }
            catch (Exception)
            {
                // If an exception is thrown during execution, rethrow it.
                throw;
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Initialize variables to keep track of the maximum profit and the minimum price.
                int maxValue = 0;
                int minValue = int.MaxValue;

                for (int i = 0; i < prices.Length; i++)
                {
                    // Check if the current price is lower than the recorded minimum price.
                    if (prices[i] < minValue)
                    {
                        minValue = prices[i]; // Update the minimum price.
                    }

                    // Calculate the profit (difference between the current price and the minimum price).
                    int complement = prices[i] - minValue;

                    // Check if the current profit is greater than the recorded maximum profit.
                    if (complement > maxValue)
                    {
                        maxValue = complement; // Update the maximum profit.
                    }
                }
                return maxValue;
            }
            catch (Exception)
            {
                // If an exception is thrown during execution, rethrow it.
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                // Define a dictionary to store pairs of strobogrammatic characters.
                Dictionary<char, char> rotatedPairs = new Dictionary<char, char>
                {
                    {'0', '0'},
                    {'1', '1'},
                    {'6', '9'},
                    {'8', '8'},
                    {'9', '6'}
                };

                // Initialize two pointers, 'first' and 'last', to check characters from both ends.
                int first = 0;
                int last = s.Length - 1;

                while (first <= last)
                {
                    char firstChar = s[first];
                    char lastChar = s[last];

                    // Check if the first and last characters are valid strobogrammatic characters.
                    if (!rotatedPairs.ContainsKey(firstChar) || !rotatedPairs.ContainsKey(lastChar))
                    {
                        return false; // If either character is not valid, the string is not strobogrammatic.
                    }

                    // Check if the pair of characters is a valid strobogrammatic pair.
                    if (rotatedPairs[firstChar] != lastChar)
                    {
                        return false; // If the pair is not strobogrammatic, return false.
                    }

                    // Move the 'first' pointer forward and the 'last' pointer backward.
                    first++;
                    last--;
                }

                return true;
            }
            catch (Exception)
            {
                // If an exception is thrown during execution, rethrow it.
                throw;
            }
        }


        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                int count = 0;
                int i = 0;

                while (i < nums.Length)
                {
                    // Store the current element in 'temp' for comparison.
                    var temp = nums[i];

                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        // Additionally, check that value and 'i' is less than 'j' to avoid counting pairs twice.
                        if (nums[i] == nums[j] && i < j)
                        {
                            count++; // Increment the count for each identical pair found.
                        }
                    }

                    // Move to the next element in the outer loop.
                    i++;
                }

                return count;
            }
            catch (Exception)
            {
                // If an exception is thrown during execution, rethrow it.
                throw;
            }
        }


        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Use LINQ to remove duplicates and order the unique elements in descending order.
                var maximum_nums = nums.Distinct().OrderByDescending(x => x).ToList();

                // Check if there are at least three unique elements.
                if (maximum_nums.Count > 2)
                {
                    // Return the third maximum element.
                    return maximum_nums[2];
                }

                return maximum_nums.First();
            }
            catch (Exception)
            {
                // If an exception is thrown during execution, rethrow it.
                throw;
            }
        }


        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                List<string> output = new List<string>();

                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    // Check if the current and next characters are both '+'.
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // Create a new string 'nextState' by replacing "++" with "--" in 'currentState'.
                        string nextState = currentState.Substring(0, i) + "--" + currentState.Substring(i + 2);

                        // Add the 'nextState' to the list of possible next moves.
                        output.Add(nextState);
                    }
                }
                return output;
            }
            catch (Exception)
            {
                // If an exception is thrown during execution, rethrow it.
                throw;
            }
        }


        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            string vowels = "AEIOUaeiou";
            string output = "";

            foreach (var c in s)
            {
                // Check if the current character 'c' is not a vowel.
                if (vowels.IndexOf(c) == -1)
                {
                    // If 'c' is not a vowel, add it to the 'output' string.
                    output += c;
                }
            }

            return output;
        }


        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
