/*
 * Project: Assignment_One Fall 2020
 * Date: 09/04/2020
 * Author: Qian Wang
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Assignment1_Fall20_QianWang
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Print Triangle based on user input.
            Console.WriteLine("Please enter a number to display a pyrimad...");
            string user_input_1 = Console.ReadLine();  // get user input
            try
            {
                int user_num_1 = int.Parse(user_input_1);  // parse data type
                PrintTriangle(user_num_1); // Call the method
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter integer like 1, 2, 3...");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();


            // Question 2: Print out n terms of odd series and their sum.
            Console.WriteLine("Please enter a number to display a series of odd numbers and their sum..."); // Ask user to enter a number
            string user_input_2 = Console.ReadLine();  // get user input
            try
            {
                int user_num_2 = int.Parse(user_input_2);  // parse user input
                PrintSeriesSum(user_num_2); // Call the method and display the output
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter integer like 1, 2, 3...");
            } 
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();


            // Question 3: Print out whehter an array is monotonic
            Console.WriteLine("Please enter array length...");
            string user_input_3 = Console.ReadLine();
            int user_num_3 = int.Parse(user_input_3);
            Console.WriteLine("Please enter a number as the lower bound of the array..."); // Ask user to enter a lower bound of the array
            string user_min = Console.ReadLine();
            Console.WriteLine("Please enter a number as the upper bound of the array..."); // Ask user to enter an upper bound of the array
            string user_max = Console.ReadLine();
            int lower_bound = int.Parse(user_min);  // Convert to integer
            int upper_bound = int.Parse(user_max);  // Convert to integer
            int[] random_array = RandomArray(lower_bound, upper_bound, user_num_3); // Generate an array according to user input
            Console.WriteLine("The array generated is " + string.Join(",", random_array)); // Display the array generated
            Console.WriteLine("The array is monotonic: " + MonotonicCheck(random_array));   // Call the function and display the result
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();


            // Question 4: Find K-diff pairs in the given array based on a specific value od absolute difference
            int[] a = new int[5] { 3, 1, 4, 1, 5 };  // Declare a new array with 5 elements
            int k = 2; // Declare a new int variable of absolute difference
            Console.WriteLine("The array is " + string.Join(", ", a) + " and k is " + k + ".");  // Display the array and k to the user
            Console.WriteLine("There are " + DiffPairs(a, 1) + " pairs of elements in the array that their absolute diference is 2."); // Call the method.
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();


            // Question 5: Calculate the time of typing a given word
            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "dis";
            Console.WriteLine("The keyboard is " + keyboard + " and the word is " + word + "."); // Display the keyboard and word to the user
            Console.WriteLine("It takes " + BullKeyBoard(keyboard, word) + " seconds to type " + word + "."); // Dispay the output
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();


            // Question 6: Find minimun number of edits required to convert string 1 to string 2.
            string str1 = "sunday";
            string str2 = "saturday";
            Console.WriteLine("String 1 is " + str1 + " and string 2 is " + str2 + ".");  // Display two strings to the screen
            int minEdits = StringEdit(str1, str2);
            Console.WriteLine("The minimum number of edits required to convert " + str1 + " to " + str2 + " is " + minEdits + ".");  // Display the result
            Console.WriteLine();
        }

        // Method that prints out a triangle based on user input
        public static void PrintTriangle(int num)
        {
            try
            {
                // Initialize spaces before *
                int spaces = num;  // Initialize the spaces for the first row

                // For loop to handle number of rows
                for (int i = 1; i < 2 * num; i+=2) // Initialize i from 1 and increment by 2 each time
                {
                    Console.Write((" ".PadLeft(spaces)));  // Print out spaces for each row first
                    Console.Write(String.Concat(Enumerable.Repeat("*",i)));  // Print out number of stars for each row after spaces
                    spaces -= 1;  // Decrement space by one each iteration
                    Console.WriteLine();
                }
                
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintTriangle");
            }
        }

        // Method that prints out the sum of n terms of odd numbers
        public static void PrintSeriesSum(int n2)
        {
            try
            {
                int sum = 0; // Initialize a variable to store the sum value
                Console.Write("The odd numbers are: ");
                for (int i = 0; i < n2; i++)
                {
                    Console.Write(2 * i + 1 + " ");  // Each odd number is equal to 2 times its index plus one
                    sum += 2 * i + 1;  // Add each value of the odd number to sum
                }  
                Console.WriteLine();
                Console.WriteLine("The sum of the odd numbers is: " + sum); // Display the sum 
                
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintSeriesSum()");
            }
        }

        // Method to determine whether an array is monotonic
        public static bool MonotonicCheck(int[] n)
        {
            try
            {
                
                // Corner case: when there are less than 3 element in the array, it should be monotonic
                if (n.Length < 3)
                {
                    return true;
                }

                // Cases when the first element is less or equal to the last one, Check whether it is an increasing array
                if (n[0] <= n[n.Length - 1])
                {
                    for (int i = 1; i < n.Length; i++)
                    {
                        if (n[i - 1] > n[i]) // If the previous element is greater than the current oone return falsse
                        {
                            return false;
                        }
                    }
                }
                // If the first elemnt is greater than the last one, check whether it is decreasing
                else
                {
                    for (int i = 1; i < n.Length; i++)
                    {
                        if (n[i - 1] < n[i])   // If the previous element is less than the current oone return falsse
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MonotonicCheck()");
                
            }
            return false;
        }

        // Method to find k-diffpairs
        public static int DiffPairs(int[] num_array, int k)
        {
            int result = 0;
            try
            {
                if (k < 0)
                {
                    return result;
                } // Corner case when k is less then 0, return 0. The absolute different cannot be a negative number

                Hashtable hash = new Hashtable(); // Initialize a new hashtable to store key-value pairs

                foreach (var item in num_array)
                {
                    if (!hash.ContainsKey(item))
                    {
                        hash.Add(item, 1);
                    } // If the value is not in the hashtable store it into the table
                    else
                    {
                        hash[item] = (int)hash[item] + 1; // if the value is in the hashtable. increment the value by 1
                    }
                } // Add all elements to the hashtable

                foreach (var item in hash.Keys)
                {
                    if (k == 0)
                    {
                        if ((int)hash[item] > 1)  // for each element, check if count of element > 1
                        {
                            result++;
                        }
                    }
                    else if (hash.ContainsKey((int)item + k)) // for each element check if i + k exist.
                    {
                        result++;
                    }
                }
                return result;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing DiffPairs()");
            }
            return result;
        }

        // Method to calculate typing time with one finger
        public static int BullKeyBoard(string keyboard, string word)
        {
            
            try
            {
                // Initialize a dictionary that stores each character in the string to it
                var myDictionary = new Dictionary<char, int>();
                for (int i = 0; i < keyboard.Length; i++)
                {
                    myDictionary.Add(keyboard[i], i);
                } // Store each letter in the keyboard in a hashtable as key-value pairs.

                int time = 0;          // Declare time variable to store the total time used and initialize it with 0
                int current_index = 0; //Declare current index which is 0 initially
                foreach (char c in word)
                {
                    time += Math.Abs((int)myDictionary[c] - current_index); // For each character in word, calculate the distance to the previous one
                    current_index = (int)myDictionary[c];  // Update the current index each time
                }  
                return time;


            }
            catch
            {
                Console.WriteLine("Exception occured while computing BullsKeyboard()");
            }
            return 0;
        }

        // Method to find minimum number of edits between two strings.
        public static int StringEdit(string str1, string str2)
        {
            try
            {
                // Handle corner cases when one of the strings is empty
                if (str1.Length == 0)
                {
                    return str2.Length;
                } // If string one is empty, return the length of string 2
                if (str2.Length == 0)
                {
                    return str1.Length;
                } // If string 2 is empty return the length of string 1
                
                // Initialize a table to store the results of subproblems
                int m = str1.Length + 1; 
                int n = str2.Length + 1;
                int[,] dp = new int[m, n];

                // For loop to dill dp[ , ] in the bottom up manner
                for (int i = 1; i < m; i++)
                {
                    dp[i, 0] = i;  // If the second string is empty, only option is to remove all characters
                }
                for (int i = 1; i < n; i++)
                {
                    dp[0, i] = i;  // If the first string is empty, insert all characters of second string
                }
                for (int i = 1; i < m; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        //int min = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1]));
                        if (str1[i - 1] == str2[j - 1])
                        {
                            dp[i, j] = dp[i - 1, j - 1]; // If last characters are the same, decrement index and recur for remaining string
                        }
                        else
                        {
                            int min = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1])); // Find the min steps of insert=dp[i, j-1], remove=dp[i-1,j], and replace = dp[i - 1, j - 1]
                            dp[i, j] = 1 + min;
                        } // If the last characters do not match
                    }
                }
                return dp[m - 1, n - 1];

            }
            catch
            {
                Console.WriteLine("Exception occured while computing StringEdit()");
            }
            return 0;
        }

        // Method to generate random arrays
        public static int[] RandomArray(int min, int max, int n)
        {
            int[] result = null;
            try
            {
                // Declares an integer array with n elements and initializes all the element to a default value 0
                int[] num_array = new int[n];
                Random randNum = new Random();
                // Generate and add values to the array
                for (int i = 0; i < n; i++)
                {
                    num_array[i] = randNum.Next(min, max);
                }
                return result = num_array;
                
            }
            catch
            {
                Console.WriteLine("Exception occured while computing DiffPairs()");
            }
            return result;
        }
    }
}
