/******************************************************************************
Angélica Lourenço Oliveira - 11711GIN061
*******************************************************************************/
using System;
class Questao3 {
    public class StackInArray {
        // Não acrescente outros atributos
        char[] items;
        int top;
        
        public StackInArray(int capacity) {
            this.items = new char[capacity];
            // complete o código aqui
            this.top = 0;
        }
        
        public void Push(char item) {
            // preencha com o código adequado
            if (IsFull ())
    	        throw new Exception ("Pilha cheia");
            top++;
            items[top-1] = item;
        }
        
        public char Pop() {
            // preencha com o código adequado
            if (IsEmpty ())
    	        throw new Exception ("Pilha vazia");
            char item = items[top-1];
            top--;
            return item;
        }
        
        public bool IsEmpty() {
            // preencha com o código adequado
            return (top == 0);
        }
        
        public bool IsFull() {
            // preencha com o código adequado
            return (top == (items.Length));
        }
    }
    
    static void Main() {
        
        String str = Console.ReadLine();
        int l = str.Length;
        
        StackInArray Pilha1 = new StackInArray (l/2);
        
        for (int i = 0; i < l/2; i++){
            Pilha1.Push(str[i]);
        }
        
        for (int i = l/2; i<l; i++){
            if (Pilha1.Pop()==str[i]){
                continue;
            }else{
                Console.WriteLine("Não é um palíndromo");
                break;
            }
        }
    }
}