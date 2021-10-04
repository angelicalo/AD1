/***************************************************
    Angelica Lourenco Oliveira - 11711GIN061 - UFU 
***************************************************/
using System;

class Trabalho3 {
    class ListInArray {
        int[] items;
        int count;
        
        public ListInArray(int capacity) {
            this.items = new int[capacity];
            this.count = 0;
        }
        
        public void AddFirst(int newItem) { 
            if (IsFull())
                throw new Exception("lista cheia");
                
            for (int i = count; i > 0; i--)
                items[i] = items[i - 1]; 
                
            items[0] = newItem;
            count++;
        }
        
        public void AddLast(int newItem) { 
            if (IsFull())
                throw new Exception("lista cheia");
                
            items[count] = newItem;
            count++;
        }
        
        public void InsertAt(int i, int newItem) {
            if (IsFull())
                throw new Exception("lista cheia");
                
            if (i >= count){
                 items[count] = newItem;
                 count++;
                 return;
            }
            
            for (int j = count; j > i; j--)
                items[j] = items[j - 1]; 
                
            items[i] = newItem;
            count++;
        }
        
        public void RemoveFirst() { 
            if (IsEmpty())
                throw new Exception("lista vazia");
                
            for (int i = 0; i < count-1; i++)
                items[i] = items[i + 1];
            count--;
        }
        
        public void RemoveLast() { 
            if (IsEmpty())
                throw new Exception("lista vazia");
            count--;
        }
        
        public void Remove(int item) {
            if (IsEmpty())
                throw new Exception("lista vazia");
                
            if (Find(item) != -1){
                int i = Find(item);
                for (int j = i; j < count; j++){
                    items[j] = items[j + 1]; 
                }
                count--;
            }
        }
        
        public void RemoveAt(int i) {
            if (IsEmpty())
                throw new Exception("lista vazia");
                
            if (i >= count){
                throw new Exception("posicao invalida");
            }else{
                for (int j = i; j < count; j++)
                    items[j] = items[j + 1]; 
                count--;
            }
        }
        
        public int Find(int item) { 
            for (int i = 0; i < count; i++){
                if (items[i] == item)
                    return i;
            }
            return -1;
        }
        
        
        public int Get(int i) { 
            if (i >= count){
                throw new Exception("posicao invalida");
            }else{
                return items[i];
            }
        }
        
        public void Set(int i, int newItem) { 
            if (i > count){
                throw new Exception("posicao invalida");
            }else{
                items[i] = newItem;
            }
        }
        
        public bool IsEmpty() {
            return (count == 0);
        }
        
        public bool IsFull() {
            return (count == items.Length);
        }
        
        public int Count() {
            return count;
        }
        
        public void Display() {
            if (count==0)
                Console.WriteLine("lista Vazia");
            for ( int i=0;i<count;i++)
                Console.Write("{0} ",items[i]);
            Console.WriteLine("");
        }
        
        public void AddSorted(int newItem) {
            if (IsFull())
                throw new Exception("lista cheia");
            int k = 0;
            while (k < count && items[k] <= newItem)
                k++;
                
            for (int i = count; i > k; i--)
                items[i] = items[i - 1];
                
            items[k] = newItem;
            count++;
        }
        
        public bool Contains_LinearSearch_Sorted(int key) { 
            int k = 0; 
            while (k < this.count && this.items[k] < key) 
                k++; 
 
            if (k == count) 
                return false; // não encontrado 
 
            return this.items[k] == key; 
        }
        
        public bool Contains_BinarySearch(int key) {
            int min = 0;
            int max = this.count - 1;
            
            while (min <= max) {
                int mid = (min + max) / 2;
                if (key == this.items[mid])
                return true;
            else if (key < this.items[mid])
                max = mid - 1;
            else
                min = mid + 1;
            }
            return false;
        }
        
        public void SortList() {
            Array.Sort(items, 0, count);
        }
    }

    static void Main () {
        int MAX = 100000; // valor maximo
        Random random = new Random();
        
        int[] Ns = new int[9];
        
        Ns[0] = 1000;
        Ns[1] = 50000;
        Ns[2] = 100000;
        Ns[3] = 500000;
        Ns[4] = 1000000;
        Ns[5] = 5000000;
        Ns[6] = 10000000;
        Ns[7] = 50000000;
        Ns[8] = 100000000;
        
        Console.WriteLine("BUSCA BINARIA");
        for (int j=0; j<Ns.Length;j++){
            int N = Ns[j];
            ListInArray lista = new ListInArray(N);
            
            for (int i=0;i < N;i++){
                int x = random.Next(0,MAX);
                lista.AddLast(x);
            }
            
            lista.SortList();
            
            Console.Write("N: {0} \t ",N);
            var watch1 = new System.Diagnostics.Stopwatch();
            
            watch1.Start();
            for (int i=0;i < 200;i++){
                int x = random.Next(0,2*MAX);
                lista.Contains_BinarySearch(x);
            }
            watch1.Stop();
            
            Console.WriteLine(watch1.Elapsed);
        }
        
        
        Console.WriteLine("\nBUSCA LINEAR");
        for (int j=0; j<Ns.Length;j++){
            int N = Ns[j];
            ListInArray lista = new ListInArray(N);
            
            for (int i=0;i < N;i++){
                int x = random.Next(0,MAX);
                lista.AddLast(x);
            }
            
            lista.SortList();
            
            Console.Write("N: {0} \t ",N);
            var watch1 = new System.Diagnostics.Stopwatch();
            
            watch1.Start();
            for (int i=0;i < 200;i++){
                int x = random.Next(0,2*MAX);
                lista.Contains_LinearSearch_Sorted(x);
            }
            watch1.Stop();
            
            Console.WriteLine(watch1.Elapsed);
        }
    }
}
