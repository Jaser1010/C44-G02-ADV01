using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C44_G02_ADV01
{
    #region Question 1: Generic Range<T> Class
    /// Represents a generic range of values.
    public class Range<T> where T : IComparable<T>
    {
        public T Minimum { get; }
        public T Maximum { get; }

        /// Initializes a new instance of the Range class.
        public Range(T min, T max)
        {
            if (min == null) throw new ArgumentNullException(nameof(min));
            if (max == null) throw new ArgumentNullException(nameof(max));

            // Ensure min is less than or equal to max
            if (min.CompareTo(max) > 0)
            {
                throw new ArgumentException("Minimum value cannot be greater than maximum value.");
            }
            Minimum = min;
            Maximum = max;
        }

        /// Checks if a given value is within the range (inclusive).
        public bool IsInRange(T value)
        {
            if (value == null) return false; // Or throw ArgumentNullException depending on desired behavior
            // value >= Minimum && value <= Maximum
            return value.CompareTo(Minimum) >= 0 && value.CompareTo(Maximum) <= 0;
        }

        /// Calculates the length of the range.
        /// Note: This method assumes T is a numeric type convertible to double.
        public double Length()
        {
            // Convert to a common numeric type (double) to perform subtraction
            // This avoids using 'dynamic' and works for all standard numeric types.
            return Convert.ToDouble(Maximum) - Convert.ToDouble(Minimum);
        }
    }
    #endregion

    #region Question 4: FixedSizeList<T> Class
    /// Represents a generic list with a fixed capacity.
    public class FixedSizeList<T>
    {
        private readonly T[] _items;
        private int _count;

        public int Capacity => _items.Length;
        public int Count => _count;

        /// Initializes a new instance of the FixedSizeList class with a specified capacity.
        public FixedSizeList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be a positive integer.", nameof(capacity));
            }
            _items = new T[capacity];
            _count = 0;
        }

        /// Adds an element to the list.
        public void Add(T item)
        {
            if (_count >= Capacity)
            {
                throw new InvalidOperationException("The list is full. Cannot add more items.");
            }
            _items[_count] = item;
            _count++;
        }

        /// Retrieves the element at a specific index.
        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException($"Index must be between 0 and {_count - 1}.");
            }
            return _items[index];
        }
    }
    #endregion

    internal class Program
    {
        #region Question 2: Reverse ArrayList
        /// Reverses the elements in an ArrayList in-place.
        public static void ReverseArrayListInPlace(ArrayList list)
        {
            if (list is null) return;

            int n = list.Count;
            for (int i = 0; i < n / 2; i++)
            {
                // Swap elements from the beginning and end
                object temp = list[i];
                list[i] = list[n - 1 - i];
                list[n - 1 - i] = temp;
            }
        }
        #endregion

        #region Question 3: Filter Even Numbers
        /// Filters a list of integers to return only the even numbers.
        public static List<int> GetEvenNumbers(List<int> numbers)
        {
            List<int> evenNumbers = new List<int>();
            if (numbers is null) return evenNumbers; // Return empty list if input is null

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            return evenNumbers;
        }
        #endregion

        #region Question 5: First Non-Repeated Character
        /// Finds the index of the first non-repeated character in a string.
        public static int FirstNonRepeatedCharIndex(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return -1;
            }

            Dictionary<char, int> charCounts = new Dictionary<char, int>();

            // First pass: count character frequencies
            foreach (char c in input)
            {
                if (charCounts.ContainsKey(c))
                {
                    charCounts[c]++;
                }
                else
                {
                    charCounts[c] = 1;
                }
            }

            // Second pass: find the first character with a count of 1
            for (int i = 0; i < input.Length; i++)
            {
                if (charCounts[input[i]] == 1)
                {
                    return i;
                }
            }

            return -1; // No non-repeated character found
        }
        #endregion

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n==============================================");
                Console.WriteLine("Please select a question to run (1-5) or 0 to exit:");
                Console.WriteLine("1. Generic Range<T> Class");
                Console.WriteLine("2. Reverse ArrayList In-Place");
                Console.WriteLine("3. Filter Even Numbers");
                Console.WriteLine("4. FixedSizeList<T>");
                Console.WriteLine("5. First Non-Repeated Character");
                Console.WriteLine("==============================================");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                if (choice == 0) break;

                Console.Clear(); // Clear console for better readability
                switch (choice)
                {
                    case 1:
                        RunQuestion1();
                        break;
                    case 2:
                        RunQuestion2();
                        break;
                    case 3:
                        RunQuestion3();
                        break;
                    case 4:
                        RunQuestion4();
                        break;
                    case 5:
                        RunQuestion5();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a number between 1 and 5.");
                        break;
                }
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        #region Demonstration Runners

        #region  RunQuestion1
        /*
        private static void RunQuestion1()
        {
            Console.WriteLine("--- Question 1: Generic Range<T> Class ---");
            try
            {
                Console.Write("Enter the minimum value for the integer range: ");
                int min = int.Parse(Console.ReadLine());
                Console.Write("Enter the maximum value for the integer range: ");
                int max = int.Parse(Console.ReadLine());

                Range<int> intRange = new Range<int>(min, max);
                Console.WriteLine($"Range created from {min} to {max}. Length: {intRange.Length()}");

                Console.Write("Enter a value to check if it's in the range: ");
                int valueToCheck = int.Parse(Console.ReadLine());

                Console.WriteLine($"Is {valueToCheck} in range? {intRange.IsInRange(valueToCheck)}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid number format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        */
        #endregion

        #region RunQuestion2
        /*
        private static void RunQuestion2()
        {
            Console.WriteLine("\n--- Question 2: Reverse ArrayList In-Place ---");
            // Creating a sample list as user input for mixed types is complex for this demo.
            ArrayList myArrayList = new ArrayList() { 1, "two", 3.0, 'f', "five" };
            Console.WriteLine("Original ArrayList: " + string.Join(", ", myArrayList.ToArray()));
            ReverseArrayListInPlace(myArrayList);
            Console.WriteLine("Reversed ArrayList: " + string.Join(", ", myArrayList.ToArray()));
        }
        */
        #endregion

        #region RunQuestion3
        /*
        private static void RunQuestion3()
        {
            Console.WriteLine("\n--- Question 3: Filter Even Numbers ---");
            Console.WriteLine("Enter a list of numbers separated by commas (e.g., 1,2,3,4):");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("No input provided.");
                return;
            }

            List<int> numberList = new List<int>();
            try
            {
                numberList = input.Split(',').Select(int.Parse).ToList();
                Console.WriteLine("Original List: " + string.Join(", ", numberList));
                List<int> evenNumbers = GetEvenNumbers(numberList);
                Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input. Please ensure all values are integers separated by commas.");
            }
        }
        */
        #endregion

        #region RunQuestion4
        /*
        private static void RunQuestion4()
        {
            Console.WriteLine("\n--- Question 4: FixedSizeList<T> ---");
            try
            {
                Console.Write("Enter the fixed capacity for the list: ");
                int capacity = int.Parse(Console.ReadLine());
                FixedSizeList<string> fixedList = new FixedSizeList<string>(capacity);
                Console.WriteLine($"Created a list with capacity: {fixedList.Capacity}");

                while (fixedList.Count < fixedList.Capacity)
                {
                    Console.Write($"Enter item {fixedList.Count + 1} of {fixedList.Capacity} (or type 'done' to stop): ");
                    string item = Console.ReadLine();
                    if (item?.ToLower() == "done") break;
                    fixedList.Add(item);
                }

                Console.WriteLine("\nList is now full or you stopped adding items.");
                Console.WriteLine($"Current item count: {fixedList.Count}");

                // Demonstrate getting an item
                if (fixedList.Count > 0)
                {
                    Console.Write($"Enter an index to retrieve (0 to {fixedList.Count - 1}): ");
                    int index = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Item at index {index}: {fixedList.Get(index)}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid number format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        */
        #endregion

        #region RunQuestion5
        /*
        private static void RunQuestion5()
        {
            Console.WriteLine("\n--- Question 5: First Non-Repeated Character ---");
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            int index = FirstNonRepeatedCharIndex(input);
            if (index != -1)
            {
                Console.WriteLine($"The first non-repeated character is '{input[index]}' at index {index}.");
            }
            else
            {
                Console.WriteLine("No non-repeated characters found.");
            }
        }
        */
        #endregion

        #endregion
    }
}