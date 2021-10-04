/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
class Ex2 {
    public class Node {
        public int item;
        public Node next;
        
        public Node(int newItem) {
            this.item = newItem;
        }
    }
    
    public class ListaCirc {
        // Não acrescente outros atributos
        int count;
        Node final;
        public ListaCirc() {
            this.final = null;
            this.count = 0;
        }
        
        public void AddFirst(int newItem) {
            Node no = new Node(newItem);
            
            if (final == null) {
                no.next = no;
                final = no;
            }else {
                no.next = final.next;
                final.next = no;
            }
            count++;
        }
        
        public bool IsEmpty() {
            return (final == null);
        }
            
        public int Find(int item){
            
            Node aux = final.next;
            
            int i = 0;
            
            while (item >= aux.item && i < count){
                if (item == aux.item)
                    return i;
                aux = aux.next;
                i++;
                }
            return -1;
        }
    }
}


