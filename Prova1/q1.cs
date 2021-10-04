/******************************************************************************
Angélica Lourenço Oliveira - 11711GIN061
*******************************************************************************/

using System;
class Questao1 {
    class Triangulo {
        float b,h;
        
        public Triangulo(float b, float h){
            this.b = b;
            this.h = h;
        }
        
        public float Area(){
            return (b*h)/2;
        }
    }
    
    static void Main() {
        Triangulo t1 = new Triangulo(5.0f,1.0f);
        Triangulo t2 = new Triangulo(5.0f,3.0f);
        Console.WriteLine(t1.Area());
        Console.WriteLine(t2.Area());
    }
}
