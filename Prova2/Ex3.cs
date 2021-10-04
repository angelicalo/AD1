using System;
class Ex3 {
    public class Node{
        public int item;
        public Node next;
        public Node prev;
        
        public Node(int newItem){
            this.item = newItem;
        }
    }
    
    public class ListaDuplaCirc{
        int count;
        Node inicio;
        
        public ListaDuplaCirc(){
            this.inicio = null;
            this.count = 0;
        }
        
        public void AddLast(int newItem){
            
            Node no = new Node(newItem);
            
            if (inicio == null) {
                no.prev = no;
                no.next = no;
                inicio = no;
            }else {
                no.prev = inicio.prev;
                no.next = inicio;
                inicio.prev.next = no;
                inicio.prev = no;
            }
        
            count++;
        }
        
        public bool IsEmpty(){
            return (inicio == null);
        }
        
        public void RemoveAt(int p){
            if (IsEmpty())
                throw new Exception("lista vazia");
                
            if (p >= count)
                throw new Exception("posicao invalida");
                
            if (count == 1){
                inicio = null;
                count--;
                return;
            }
            
            Node aux = inicio;
            
            if (p==0){
                inicio = inicio.next;
                inicio.prev.next = aux;
            }
            
            for (int i=0;i<p;i++)
                aux = aux.next;
            
            aux.prev.next = aux.next;
            aux.next.prev = aux.prev;
            count--;
        }
    }
}


