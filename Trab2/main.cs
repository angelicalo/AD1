//Angelica Lourenco Oliveira - 11711GIN061
using System;

class Trabalho2 {
    // Parte1
    class StackInArray {

        char[] array;
        int top;
    
        public StackInArray (int capacity) {
            this.array = new char[capacity];
            this.top = -1;
        }
    
        public void Push (char item) {
            if (IsFull())
    	        throw new Exception ("Pilha cheia");
            top++;
            array[top] = item;
        }
    
        public char Pop() {
            if (IsEmpty())
    	        throw new Exception ("Pilha vazia");
            char item = array[top];
            top--;
            return item;
        }
    
        public char Peek() {
            if (IsEmpty())
    	        throw new Exception ("Pilha vazia");
            return array[top];
        }
    
        public bool IsEmpty() {
            return (top == -1);
        }
    
        public bool IsFull() {
            return (top == (array.Length - 1));}
    
        public int Count() {
            return (top + 1);
        }
    }
    
    // Parte2
    class Node {
        public char item;		
        public Node next;		
        
        public Node (char newItem, Node nextNode) {
            this.item = newItem;
            this.next = nextNode;
        }
    }
    
    class StackInList {
        Node top;
        int count;
        
        public StackInList() {
            this.top = null;
        }
    
        public void Push(char item) {
            Node newNode = new Node (item, top);
            top = newNode;
            count++;
            return;
        }
        
        public char Pop() {
            if (IsEmpty())
            throw new Exception ("Pilha vazia");
            char item = top.item;
            top = top.next;
            count--;
            return item;
        }
        
        public char Peek() {
            if (IsEmpty())
                throw new Exception ("Pilha vazia");
            return top.item;
        }
        
        public bool IsEmpty() {
            return (top == null);
        }
        
        public int Count() {
            return (count);
        }
    }
    
    // Parte3
    static bool Parte3(String str) {
        StackInList Pilha = new StackInList();
        foreach (char x in str) {
            if (x == '(') {
                Pilha.Push(x);
                continue;
            }
            if (x == ')') {
                if (!Pilha.IsEmpty()){
                    if (Pilha.Peek() == '(') {
                        Pilha.Pop();
                    }
                }else{
                    return false;
                }
            }
        }
        
        if (Pilha.IsEmpty()){
            return true;
        }else{
            return false;
        }
    }
    
    // Parte4
    static bool Parte4(String str) {
        
        StackInList Pilha = new StackInList();
        foreach (char x in str) {
            
            if (x == '(' || x == '{' || x == '[') {
                Pilha.Push (x);
                continue;
            }
            
            if (x == ')' || x == '}' || x == ']') {
                if (!Pilha.IsEmpty()) {
                    
                    if (Pilha.Peek() == '(' && x == ')') {
                        Pilha.Pop();
                        continue;
                    }
                    
                    if (Pilha.Peek() == '{' && x == '}') {
                        Pilha.Pop();
                        continue;
                    }
                    
                    if (Pilha.Peek() == '[' && x == ']') {
                        Pilha.Pop();
                        continue;
                    }
                    
                    return false;
                }else{
                    return false;
                }
            }
        }
        
        if (Pilha.IsEmpty()) {
            return true;
        }else{
            return false;
        }
    }
    
    static void Main() {
        //Parte1
        Console.WriteLine("Parte 1");
        StackInArray Pilha1 = new StackInArray(5);
        Pilha1.Push('a');
        Pilha1.Push('n');
        Pilha1.Push('g');
        Console.WriteLine(Pilha1.Peek());
        Console.WriteLine(Pilha1.Pop());
        Console.WriteLine(Pilha1.Peek());
        Pilha1.Push('e');
        Pilha1.Push('l');
        Console.WriteLine(Pilha1.Peek());
        
        //Parte2
        Console.WriteLine("\nParte 2");
        StackInList Pilha2 = new StackInList();
        Pilha2.Push('a');
        Pilha2.Push('n');
        Pilha2.Push('g');
        Console.WriteLine(Pilha2.Peek());
        Console.WriteLine(Pilha2.Pop());
        Console.WriteLine(Pilha2.Peek());
        Pilha2.Push('e');
        Pilha2.Push('l');
        Console.WriteLine(Pilha2.Peek());
        
        // Parte3
        Console.WriteLine("\nParte 3 - exemplos professor");
        Console.WriteLine("\nTRUE...");
        String[] str3True = new String[] { 
            "3 * (10 + 5)",
            "2 + ((3 - 5) + (3 * 6))",
            "( ( ( ) ( ) ) ) ( ) ( )",
            "Ab (cd) (ef) (aa(dde(n)234)) h"};
        for(int i = 0 ; i < str3True.Length ; i++) {
            Console.WriteLine(Parte3(str3True[i]));
        }
        
        Console.WriteLine("\nFALSE...");
        String[] str3False = new String[] { 
            "3 * (10 + 5",
            "( 23 + 35 ) + )",
            "Ab cd) (ef)",
            "(2 + 5) ) 23 + 35 ( 4",
            "2 + ((3 – 5))) + (3 * 6))",
            "( ( (",
            "( ) ) ) ( ) ( )"};
        for(int i = 0 ; i < str3False.Length ; i++) {
            Console.WriteLine(Parte3(str3False[i]));
        }
        
        // Parte4
        Console.WriteLine("\nParte 4 - exemplos professor");
        Console.WriteLine("\nTRUE...");
        String[] str4True = new String[] { 
            "3 * [10 + (30 – 5) * 8]", 
            "25 + { [(3 - 5) + (3 * 6)] * 10 + 3 } / 2", 
            "[] () { { () } } [ ( { abc } ) ]"};
        for(int i = 0 ; i < str4True.Length ; i++) {
            Console.WriteLine(Parte4(str4True[i]));
        }
        
        Console.WriteLine("\nFALSE...");
        String[] str4False = new String[] {
            "3 * [10 + 5", 
            "{ 23 + 35 ) + (3 – 1)", 
            "[ ( } ] { ( abcd ) + 40", 
            "( ) { { { }} 5 ]"};
        for(int i = 0 ; i < str4False.Length ; i++) {
            Console.WriteLine(Parte4(str4False[i]));
        }
        
        Console.WriteLine("\nParte 3 com Usuario...");
        //Parte 3 com usuario
        Console.WriteLine("Entre com uma expressao para verificar o balanceamento de parenteses:");
        Console.WriteLine("Balanceada: {0}",Parte3(Console.ReadLine()));
        
        Console.WriteLine("\nParte 4 com Usuario...");
        //Parte 4 com usuario
        Console.WriteLine("Entre com uma expressao para verificar o balanceamento de (), {} e []:");
        Console.WriteLine("Balanceada: {0}",Parte4(Console.ReadLine()));
        
    }
}


