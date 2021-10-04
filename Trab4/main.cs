/***************************************************
    Angelica Lourenco Oliveira - 11711GIN061 - UFU 
***************************************************/
using System;

class Trabalho4 {
    
    // Parte 1
    class Node {
        public int item;
        public Node next;
        public Node prev;
        
        // Construct Node
        public Node(int newItem) {
            this.item = newItem;
        }
    }
    
    // class List
    class DoubleLinkedCircularList {
        int count;   
        Node inicio;  
        Node partida;
        
        // Construct List
        public DoubleLinkedCircularList() {
            this.inicio = null;
            this.partida = null;
            this.count = 0;
        }
        
        // Aux for insert
        private void InsertBefore(Node aux, Node newNode) {
            newNode.prev = aux.prev;
            newNode.next = aux;
            aux.prev.next = newNode;
            aux.prev = newNode;
        } 
        
        // AddFirst
        public void AddFirst(int newItem) { 
            AddLast(newItem);
            inicio = inicio.prev;
        }
        
        // AddLast
        public void AddLast(int newItem) { 
            Node newNode = new Node(newItem);
            if (inicio == null) {
                newNode.prev = newNode; 
                newNode.next = newNode; 
                inicio = newNode;
            }else 
                InsertBefore(inicio, newNode);
            count++;
        }
        
        // InsertAt
        public void InsertAt(int p, int newItem) {
            if (p < 0 || p > count) 
                throw new Exception("Pos. Invalida");
            
            Node newNode = new Node(newItem);
            
            if (inicio == null) {
                newNode.prev = newNode; 
                newNode.next = newNode; 
            }else {
                Node aux = inicio;
                for (int i = 0; i < p; i++) 
                    aux = aux.next;
                InsertBefore(aux, newNode);   
            }
            if (p == 0) 
                inicio = newNode;
            count++;
        } 
        
        // Aux for remove nodes
        public void RemoveNode(Node aux) {
            if (count <= 1) 
                throw new Exception("Nao permitido");
            aux.prev.next = aux.next;
            aux.next.prev = aux.prev;
        }
        
        // RemoveFirst
        public void RemoveFirst() { 
            if (IsEmpty())
                throw new Exception("Lista vazia");
                
            if (count == 1)
                inicio = null;
            else {
                RemoveNode(inicio);
                inicio = inicio.next;
            }
            count--;
        }
        
        // RemoveLast
        public void RemoveLast() { 
            if (IsEmpty())
                throw new Exception("Lista vazia");
            if (count == 1)
                inicio = null;
            else
                RemoveNode(inicio.prev);
            count--;
        }
        
        // Remove
        public bool Remove(int item) { 
            if (IsEmpty()) 
                throw new Exception("Lista vazia");
            
            Node aux = inicio;
            while (aux != inicio.prev && aux.item != item)
                aux = aux.next;
                
            if (aux.item != item) 
                return false;
                
            if (count == 1){
                inicio = null;
            }else {
                if (aux == inicio)
                    inicio = inicio.next;
                RemoveNode(aux); 
            }   
            count--; 
            return true;
        }
        
        // Get
        public int Get(int p) { 
            if (p >= count )
                throw new Exception("Pos. invalida");
                
            Node aux = inicio;
            for (int i=0; i<p; i++){
                aux = aux.next;
            }
            return aux.item; 
        } 
        
        // Set
        public void Set(int p, int newItem) {
            if (p >= count )
                throw new Exception("Pos. invalida");
                
            Node aux;
            
            if (p < count/2){
                aux = inicio;
                for (int i=0; i<p;i++)
                    aux = aux.next;
            }else{
                aux = inicio.prev;
                for (int i=count-1;i>p;i--)
                    aux = aux.prev;
            }
            
            aux.item = newItem;
        }
        
        // Find
        public int Find(int item) { 
            Node aux = inicio;
            
            for (int i=0; i<count; i++){
                if (item == aux.item)
                    return i;
                aux = aux.next;
            }
            return -1;
        }  
        
        // DisplayFirstToLast
        public void DisplayFirstToLast() {
            if (IsEmpty())
                throw new Exception("Lista vazia");
                
            Node aux = inicio;
            
            for (int i=0; i<count;i++){
                Console.Write(aux.item);
                Console.Write(" ");
                aux = aux.next;
            }
                
            Console.Write("\n");
        }
        
        // DisplayLastToFirst
        public void DisplayLastToFirst() {
            if (IsEmpty())
                throw new Exception("Lista vazia");
            
            Node aux = inicio.prev;
            
            for (int i=0; i<count;i++){
                Console.Write(aux.item);
                Console.Write(" ");
                aux = aux.prev;
            }
            
            Console.Write("\n");
        }
        
        // aux 
        public bool IsEmpty() {
            return (count == 0);
        }
        
        public int Count(){
            return count;
        }
        
        // CountNodesAndRemove
        public void CountNodesAndRemove(int m) {
            if (IsEmpty())
                throw new Exception("Lista vazia");
                
            if (count==1)
                throw new Exception("Operacao Invalida");
                
            if (partida==null)
                partida = inicio;
                
            Node aux = partida;
            
            for (int i=0; i < m;i++){
                aux = aux.prev;
            }
            
            if (aux==inicio){
                RemoveFirst();
            }else 
                if (aux==inicio.prev) {
                    RemoveLast();
            }else{
                RemoveNode(aux);
                count--;
            }
            
            partida = aux.next;
        }
        
        
    }
    
    static void Main () {
        // Parte 1
        Console.WriteLine("***********************************************************************");
        Console.WriteLine("******************************* PARTE 1 *******************************");
        Console.WriteLine("***********************************************************************");
        
        DoubleLinkedCircularList newList = new DoubleLinkedCircularList();
        
        Console.WriteLine("Adicionando itens na lista...");
        
        // AddFirst and AddLast
        Console.WriteLine("\nAdicionando 3 no inicio e 1 no final");
        newList.AddFirst(3);
        newList.AddLast(1);
        newList.DisplayFirstToLast();
        
        Console.WriteLine("\nAdicionando no final na seguinte ordem: o 2 e depois o 21. Em seguida, o 31 foi adicionado no inicio");
        newList.AddLast(2); 
        newList.AddLast(21);
        newList.AddFirst(31);
        newList.DisplayFirstToLast();
        
        // InsertAt
        Console.WriteLine("\nAdicionando na seguinte ordem: na posição 0 o 4 e na posicao 2 o 41");
        newList.InsertAt(0,4);
        newList.InsertAt(2,41);
        newList.DisplayFirstToLast();
        
        Console.WriteLine("\nDepois, foi adcionado na posicao 1 o 5 e na posicao 1 o 6");
        newList.InsertAt(1,5);
        newList.InsertAt(1,6);
        newList.DisplayFirstToLast();
        
        // RemoveFirst
        Console.WriteLine("\nRemovendo o primeiro elemento");
        newList.RemoveFirst();
        newList.DisplayFirstToLast();
        
        // RemoveLast
        Console.WriteLine("\nRemovendo o ultimo elemento");
        newList.RemoveLast();
        newList.DisplayFirstToLast();
        
        // Remove
        Console.WriteLine("\nRemovendo o elemento 1 se existir");
        newList.Remove(1);
        newList.DisplayFirstToLast();
        
        // Get
        Console.WriteLine("\nElemento da posicao 2");
        Console.WriteLine(newList.Get(2));
        newList.DisplayFirstToLast();
        
        // Set
        Console.WriteLine("\nSubstituindo o elemento da posicao 0 pelo elemento 51");
        newList.Set(0,51);
        newList.DisplayFirstToLast();
        
        // Find
        Console.WriteLine("\nPosicao do elemento 31 se existir. Se nao existir, retorna -1");
        Console.WriteLine(newList.Find(31));
        newList.DisplayFirstToLast();
        
        Console.WriteLine("\nPosicao do elemento 0 se existir. Se nao existir, retorna -1");
        Console.WriteLine(newList.Find(0));
        
        // DisplayFirstToLast
        Console.WriteLine("\nElementos da lista na ordem natural");
        newList.DisplayFirstToLast();
        
        // DisplayLastToFirst
        Console.WriteLine("\nElementos da lista na ordem invertida");
        newList.DisplayLastToFirst();
        
        // Parte 2
        Console.WriteLine("\n\n***********************************************************************");
        Console.WriteLine("******************************* PARTE 2 *******************************");
        Console.WriteLine("***********************************************************************");
        
        Console.WriteLine("\nElementos da lista na ordem natural");
        newList.DisplayFirstToLast();
        
        int count = newList.Count();
        
        int m = 6;
        Console.WriteLine("\nUsando a função para remover com passo igual a {0}", m);
        for (int i = 0; i < count-1;i++){
            // CountNodesAndRemove
            newList.CountNodesAndRemove(m); // exemplo reomover com passo m
            Console.WriteLine("\nApos remocao");
            newList.DisplayFirstToLast();
        }
        Console.WriteLine("\nSobrevivente: {0}",newList.Get(0));
        
        Console.WriteLine("\nElementos da lista na ordem natural");
        newList.DisplayFirstToLast();
    }
            
}


