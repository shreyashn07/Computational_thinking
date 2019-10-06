using System;
using System.Collections;
using System.Collections.Generic;

namespace _2019_Fall_Assignment2
{
    class Compare2DArray : System.Collections.Generic.IComparer<int[]>
    {
        int ix;

        public int Compare(int[] x, int[] y)
        {
            return x[0].CompareTo(y[0]);
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            //int target = 2;
            //int[] nums = { 1, 3, 5, 6 };
            //Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            //int[] nums1 = { 1, 2, 2, 1 };
            //int[] nums2 = { 2, 2 };
            //int[] intersect = Intersect(nums1, nums2);
            //Console.WriteLine("Intersection of two arrays is: ");
            //DisplayArray(intersect);
            //Console.WriteLine("\n");

            //int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            //Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            //string keyboard = "abcdefghijklmnopqrstuvwxyz";
            //string word = "cba";
            //Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            //int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            //int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            //Console.WriteLine("The resulting flipped and inverted image is:\n");
            //Display2DArray(flipAndInvertedImage);
            //Console.Write("\n");

            //int[,] intervals = { { 2, 15 }, { 36, 45 }, { 9, 29 }, { 16, 23 }, { 4, 9 } };
            //int minMeetingRooms = MinMeetingRooms(intervals);
            //Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            //string s = "madam";
            //if (ValidPalindrome(s))
            //{
            //    Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            //}
            //else
            //{
            //    Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            //}
        }

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int start = 0;
                int end = nums.Length - 1;
                while (start + 1 < end)
                {
                    int mid = (start + end) / 2;
                    if (nums[mid] == target)
                    {
                        return mid;
                    }
                    else if (nums[mid] > target)
                    {
                        end = mid; // update end position to current mid poition 
                    }
                    else
                    {
                        start = mid; // update start to current mid position
                    }
                }
                if (nums[end] < target)
                {
                    return end + 1;
                }
                else if (nums[start] >= target)
                {
                    return start;
                }
                else
                {
                    return end;
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            List<int> list = new List<int>();
            try
            {
                Dictionary<int, int> dic = new Dictionary<int, int>();
                for (int i = 0; i < nums1.Length; i++)
                {
                    if (!dic.ContainsKey(nums1[i]))
                    { dic.Add(nums1[i], 0); }//For elements that do not appear, set the number of occurrences to 0
                    else
                    {
                        dic[nums1[i]]++;// Already exists elements and increase.
                    }
                }

                for (int i = 0; i < nums2.Length; i++)
                {   // the element that has already appeared and the number of occurrences is not less than 0
                    if (dic.ContainsKey(nums2[i]) && dic[nums2[i]] >= 0)
                    {
                        list.Add(nums2[i]);// add the element to the list
                        dic[nums2[i]]--;// Reduce the number of occurrences of the element
                    }
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return list.ToArray();
        }

        public static int LargestUniqueNumber(int[] A)
        {
            try
            {
                
                Dictionary<int, int> My_dict1 = new Dictionary<int, int>();
                foreach (int i in A)
                {
                    if ((My_dict1.ContainsKey(i)))
                    {
                        My_dict1[i]++;

                    }
                    else
                    {
                        My_dict1.Add(i, 1);
                    }
                }
                int max = -1;
                foreach (KeyValuePair<int, int> ele in My_dict1)
                {
                    if (ele.Value == 1 && ele.Key >= max)
                    {
                        max = ele.Key;
                    }
                }
                return max;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
               

                Dictionary<char, int> My_dict2 = new Dictionary<char, int>();
                int i = 0;
                foreach (char a in keyboard)
                {
                    My_dict2.Add(a, i);
                    i++;

                }
                int sum = 0;
                char prev = 'a';
                foreach (char a in word)
                {
                    int x = My_dict2[a] - My_dict2[prev];
                    prev = a;
                    if (x < 0)
                    {
                        sum += (-1 * x);
                    }
                    else
                    {
                        sum += (x);
                    }
                }
                return sum;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {
                int m = 0, n = 0, i = 0, j = 0;

                m = A.GetLength(0);

                n = A.GetLength(1);

                

                

                for (i = 0; i < m; i++)

                {

                    for (j = 0; j < n / 2; j++)

                    {

                        int temp = A[i, j];

                        A[i, j] = A[i, (n - j) - 1];

                        A[i, (n - j) - 1] = temp;

                        //Console.WriteLine(array[i,j]);

                    }

                }

                for (i = 0; i < m; i++)

                {

                    for (j = 0; j < n; j++)

                    {

                        if (A[i, j] == 0)

                        {

                            A[i, j] = 1;

                        }

                        else if (A[i, j] == 1)

                        {

                            A[i, j] = 0;

                        }

                        else

                        {

                            Console.WriteLine("Invalid Input!!");

                        }

                    }
                }
            }

            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return A;
        }

        public static int MinMeetingRooms(int[,] intervals)
        {

            int n = intervals.GetLength(0);
            try
            {
                intervals = sort2darray(intervals);
                int pointer = 0, count = 0;
                SortedList sortedList = new SortedList();
                for (int i = 0; i < n; i++)
                {
                    if (sortedList.Count == 0)
                    {
                        count++;
                        sortedList.Add(intervals[i, 1], i);

                    }
                    else
                    {
                        int var =(int)sortedList.GetKey(0);
                        if (intervals[i, 0] >= var)
                        {
                            pointer++;
                        }
                        else
                        {
                            count++;
                        }
                        sortedList.Add(intervals[i, 1], i);
                    }
                    

                }
                return count;
               
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return 0;
        }

        public static int[,] sort2darray(int[,] intervals) {
            int n = intervals.GetLength(0);

            


            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (intervals[j,1] > intervals[j + 1,1])
                    {
                        // swap temp and arr[i] 
                        int temp = intervals[j,1];
                        intervals[j,1] = intervals[j + 1,1];
                        intervals[j + 1,1] = temp;

                        int temp1 = intervals[j, 0];
                        intervals[j, 0] = intervals[j + 1, 0];
                        intervals[j + 1, 0] = temp1;
                    }
            

            

            





            

           
            

            return intervals;


        }
        

        public static int[] SortedSquares(int[] A)
        {
            try
            {
                int n = A.Length;
                int indexPos;
                for (indexPos = 0; indexPos < n; indexPos++)
                {
                    if (A[indexPos] >= 0)
                        break;
                }
                int i = indexPos - 1;
                int j = indexPos;
                int index = 0;
                int[] temp = new int[n];
                while (i >= 0 && j < n)
                {
                    if (A[i] * A[i] > A[j] * A[j])
                    {
                        temp[index] = A[j]*A[j];
                        index++;
                        j++;

                    }
                    else
                    {
                        temp[index] = A[i]*A[i];
                        index++;
                        i--;
                    }


                }
                while (i>=0) {
                    temp[index++] = A[i] * A[i];
                    i--;

                }
                while (j < n) {
                    temp[index++] = A[j] * A[j];
                    j++;
                }

                for (int l = 0; l < n; l++)
                    A[l] = temp[l];

                return A;



            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new int[] { };
        }

        public static bool ValidPalindrome(string s)
        {
            try
            {
                char[] str = s.ToCharArray();
                int start, end;
                bool once = true;
                start = 0;
                end = str.Length - 1;
                bool var = true;
                while ((start <= end) && var)
                {
                    if (str[start] == str[end])
                    {
                        start++;
                        end--;
                        var = true;
                    }
                    else
                    {

                        if ((str[start] == str[end - 1]) && once)
                        {
                            end--;
                            var = true;
                            once = false;
                        }
                        else if ((str[start + 1] == str[end]) && once)
                        {
                            var = true;
                            once = false;
                        }
                        else
                        {
                            var = false;

                        }

                    }

                }
                return var;
            }
            
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }
    }
}
