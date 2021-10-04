using System;
class Ex1 {
    public class Queue {
        int[] items;
        int final;
        
        public Queue (int capacity) {
            this.items = new int[capacity];
            this.final = -1;
        }
        
        public void Enqueue (int newItem) {
            if (final == items.Length - 1)
                return;
            final++;
            items[final] = newItem;
        }
        
        public bool IsEmpty () {
            return (final == -1);
        }
        
        public int Dequeue () {
            if (IsEmpty ())
    	        throw new Exception ("Fila vazia");
    	    
    	    int item = items[0];
    	    
    	    for (int i=0;i<final;i++){
    	        items[i] = items[i+1];
    	    }
            final --;
            return item;
        }
    }
}