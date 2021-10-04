/***************************************************
    Angelica Lourenco Oliveira - 11711GIN061 - UFU 
***************************************************/
using System;

class Trabalho3 {
    
    // Deque Circular
    class DequeInArray {
        int[] items;
        int inicio;
        int final;
        int count;
        
        public DequeInArray (int capacity) {
            this.items = new int[capacity];
            this.inicio = 0;
            this.final = -1;
            this.count = 0;
        }
        
        public void AddRear(int newItem) {
            if (IsFull())
                throw new Exception("Deque cheia");
            final = (final + 1) % items.Length;
            items[final] = newItem;
            count++;
        }
        
        public void AddFront(int newItem) {
            if (IsFull())
                throw new Exception("Deque cheia");
            if (inicio==0){
                inicio = items.Length - 1; 
            }else{
                inicio--;
            }
            items[inicio] = newItem;
            count++;
        }
        
        public int RemoveRear() {
            if (IsEmpty())
                throw new Exception("Deque vazia");
            int item = items[final];
            final--;
            count--;
            return item;
        }
        
        public int RemoveFront() {
            if (IsEmpty())
                throw new Exception("Deque vazia");
            int item = items[inicio];
            if (inicio==items.Length - 1){
                inicio = 0;
            }else{
                inicio++;
            }
            count--;
            return item;
        }
        
        public bool IsEmpty() {
            return (count == 0);
        }
        
        public bool IsFull() {
            return (count == items.Length);
        }
        
        public void Display() {
            if (count==0)
                Console.WriteLine("Deque Vazia");
            for (int i=inicio; i<inicio+count; i++){
                Console.WriteLine(items[i%items.Length]);
            }
        }
    }
    
    // Parte 2 
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
                Console.WriteLine(items[i]);
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
        
    }

    static void Main () {
        // Parte 1
        Console.WriteLine("################    Parte 1 -  TAD  Deque   ################");
        DequeInArray deque = new DequeInArray(5);
        // Display
        Console.WriteLine("\nMostrando elementos");
        deque.Display();
        
        // AddRear
        Console.WriteLine("\nAdcionando os elementos 0 e 1 no final");
        deque.AddRear(0);
        deque.AddRear(1);
        deque.Display();
        
        // AddFront
        Console.WriteLine("\nAdcionando os elementos -1, -2 e -3 no inicio, nesta ordem");
        deque.AddFront(-1);
        deque.AddFront(-2);
        deque.AddFront(-3);
        deque.Display();
        
        // RemoveFront
        Console.WriteLine("\nRemovendo o elemento do inicio");
        deque.RemoveFront();
        deque.Display();
        
        // AddRear
        Console.WriteLine("\nAdcionando 2 no final");
        deque.AddRear(2);
        deque.Display();
        Console.WriteLine("\nRemovendo o elemento do inicio");
        deque.RemoveFront();
        deque.Display();
        
        // RemoveRear
        Console.WriteLine("\nRemovendo o elemento do final");
        deque.RemoveRear();
        deque.Display();
        
        // Parte 2
        Console.WriteLine("\n\n################    Parte 2 - TAD  Lista   ################");
        ListInArray lista = new ListInArray(10);
        
        // AddFirst
        lista.AddFirst(20);
        
        // AddLast
        lista.AddLast(10);
        lista.AddLast(30);
        lista.AddLast(40);
        
        //InsertAt
        lista.InsertAt(1,15);
        Console.WriteLine("\nInserindo 15 na pos 1");
        lista.Display();
        lista.Remove(20);
        Console.WriteLine("\nRemovendo o elemento  20");
        lista.Display();
        
        // RemoveFirst
        lista.RemoveFirst();
        Console.WriteLine("\nSem o primeiro elemento");
        lista.Display();
        
        // RemoveLast
        lista.RemoveLast();
        Console.WriteLine("\nSem o ultimo elemento");
        lista.Display();
        
        // RemoveAt
        lista.RemoveAt(0);
        Console.WriteLine("\nSem elemento da pos 0");
        lista.Display();
        
        // Set
        lista.Set(0,35);
        Console.WriteLine("\nMudando o elemento da pos 0 para 35");
        lista.Display();
        
        // Find
        Console.WriteLine("\nEncontrando a pos do elemento 35");
        Console.WriteLine(lista.Find(35));
        
        
        // AddSorted
        ListInArray lista1 = new ListInArray(10);
        lista1.AddSorted(20);
        lista1.AddSorted(25);
        lista1.AddSorted(10);
        Console.WriteLine("\nTodos ordenados");
        lista1.Display();
        
        // inserindo ordenado ou não
        lista1.AddFirst(20);
        lista1.AddLast(11);
        lista1.AddSorted(7);
        lista1.AddSorted(5);
        lista1.AddSorted(37);
        Console.WriteLine("\nTodos inseridos, ordenado ou não");
        lista1.Display();
    }
}
