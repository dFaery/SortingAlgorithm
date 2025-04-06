using SortingAlgorithm.SinglyLinkedListSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace SortingAlgorithm
{
    
    public class Solution
    {
        #region SELECT SORTING ALGORITHM
        public static int[] SelectSortingAlgorithm(int[] dataset)
        {
            int[] result = new int[dataset.Length];

            //Interface
            Console.WriteLine("Choose Algorithm :");
            Console.WriteLine("1. Insertion Sort");
            Console.WriteLine("2. Bubble Sort");
            Console.WriteLine("3. Merge Sort");
            Console.WriteLine("4. Quick Sort :");
            Console.WriteLine("5. Quick Sort 3 Partition:");
            Console.WriteLine("6. Heap Sort");
            Console.WriteLine("7. Radix Sort");
            Console.WriteLine("8. All");
            Console.WriteLine("Select the sorting algorithm you wanted : ");
            int algorithmChosen = int.Parse(Console.ReadLine());

            switch(algorithmChosen)
            {
                case 1 :
                    SinglyLinkedListSort(dataset);
                    break;
                      
                case 2 :
                    BubbleSort(dataset);
                    break;
            }
            return result;
        }
        #endregion


        #region SINGLY LINKED LIST SORTING SOLUTION
        public static int[] SinglyLinkedListSort(int[] array)
        {
            //To Calculate Time
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //Algorithm
            int size = array.Length;
            int[] result = new int[size];
            Node head = new Node(array[0], null);
            SinglyLinkedList list = new SinglyLinkedList(null);
            Node tempBuf;
            for (int i = 0; i < size; i++)
            {
                tempBuf = new Node(array[i], null);
                //Set First Item as Head
                if (i == 0)
                {
                    list.Head = tempBuf;
                }
                else
                {
                    Node helper = list.Head;
                    //Check List.head
                    if(list.Head.Key > tempBuf.Key)
                    {
                        //Insert Node as head and head.next refers to previous list.head
                        tempBuf.Next = list.Head;
                        Node buffer = tempBuf;
                        tempBuf = list.Head;
                        list.Head = buffer;
                    }
                    else
                    {
                        SinglyLinkedList.CheckNextNode(ref tempBuf, helper);
                    }
                }
            }
            result = SinglyLinkedList.TranslateToArray(list, size);

            //Timer End
            watch.Stop();
            double elapsedMs = watch.ElapsedMilliseconds;

            //Print to call 
            Console.WriteLine("Sorted With Singly Linked List in " + elapsedMs + " ms");
            return result;
        }
        #endregion

        #region HEAP SORT

        #endregion

        #region Bubble Sort
        public static int[] BubbleSort(int[] array)
        {
            //Calulate time
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int size =  array.Length;
            int[] result = new int[size];
            int temp;
            for(int i = 1; i<array.Length; i++)
            {
                for(int j=0;j<array.Length-1;j++)
                {
                    if(array[j] == array[i+1])
                    {
                        temp = array[j];
                        array[j] = array[i+1];
                        array[i+1] = temp;
                    }
                }
            }
            //Waktu stop
            watch.Stop();
            double elapsedMs = watch.ElapsedMilliseconds;

            //Print total waktu
            Console.WriteLine("Sorted With Bubble Sort List in " + elapsedMs + " ms");
            return result;
        }
        #endregion
    }
}
