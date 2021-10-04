/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
class Questao2 {
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
        StackInArray Fila = new StackInArray (2);
        Fila.Push('a');
        Fila.Push('a');
        Fila.Pop();
    }
}