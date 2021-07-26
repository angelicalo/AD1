/******************************************************************************
Trabalho ED1 - UFU 
Angelica Lourenco Oliveira - 11711GIN061
*******************************************************************************/
using System;

class Trabalho1 {
  // Exercicio A)
    public class Ponto {
        // As coordenadas x, y e z devem ser atributos privados, do tipo float
        private float x, y, z;
        
        // Construtor contendo três parâmetros
        public Ponto (float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        // Getters
        public float GetX(){
            return this.x;}
            
        public float GetY(){
            return this.y;}
            
        public float GetZ(){
            return this.z;}
        
        // Calcula a distância entre os pontos
        public double Distancia(Ponto P) {
            return Math.Sqrt(Math.Pow(P.GetX() - this.x,2)+
                             Math.Pow(P.GetY() - this.y,2)+
                             Math.Pow(P.GetZ() - this.z,2));
        }
    }
  
    // Exercicio B)
    public class Vetor {
        // As coordenadas A, B, C devem ser atributos públicos, do tipo float
        public float A, B, C;
        
        // construtor contendo três parâmetros
        public Vetor (float A, float B, float C) {
            this.A = A;
            this.B = B;
            this.C = C;
        }
        
        // calcular e retornar o módulo (ou norma) do vetor
        public double Norma() {
            return Math.Sqrt(Math.Pow(this.A,2)+
                             Math.Pow(this.B,2)+
                             Math.Pow(this.C,2));
        }
        
        // Normaliza um vetor
        public void Normalize(){
            Vetor v = new Vetor(this.A,this.B,this.C);
            float n = Convert.ToSingle(v.Norma());
            this.A = this.A/n;
            this.B = this.B/n;
            this.C = this.C/n;
            return;
        }
    }
    
    // Exercicio C)
    public class Plano {
        // dois atributos Ponto e Vetor normal
        public Ponto P;
        public Vetor v;
        
        // Construtor contendo dois parâmetros
        public Plano(Ponto ponto, Vetor vetor){
            this.P = ponto;
            this.v = vetor;
        }
    } 
    
    // Exercicio D)
    // Código principal
    static void Main () {
        // Exercicio A)
        Console.WriteLine("\n\nExercicio A)");
        
        Ponto p1 = new Ponto(1,2,3);
        Ponto p2 = new Ponto(3,2,3);
        Console.WriteLine("A distância entre ({0},{1},{2}) e ({3},{4},{5}) é {6}.",
                            p1.GetX(),p1.GetY(),p1.GetZ(),
                            p2.GetX(),p2.GetY(),p2.GetZ(),
                            p1.Distancia(p2));
        
        // Exercicio B)
        Console.WriteLine("\n\nExercicio B)");
        
        Vetor v1 = new Vetor(0.707106781f,0,0.707106781f);
        Console.WriteLine("A norma de ({0},{1},{2}) é {3}.",v1.A,v1.B,v1.C,v1.Norma());
        v1.Normalize();
        Console.WriteLine("Este vetor após normalizar é ({0},{1},{2}).",v1.A,v1.B,v1.C);
        
        // Exercicio C)
        Console.WriteLine("\n\nExercicio C)");
        
        Ponto P = new Ponto(1,2,3);
        Vetor v = new Vetor(3,2,3);
        v.Normalize();
        Plano PN = new Plano(P,v);
        
        Console.WriteLine("Atributos do Plano PN: \n- usando os construtores:\nPonto ({0},{1},{2}) \nVetor ({3},{4},{5}).",
        P.GetX(),P.GetY(),P.GetZ(),v.A,v.B,v.C);
        
        Console.WriteLine("\n- usando o proprio plano: \nPonto ({0},{1},{2}) \nVetor ({3},{4},{5}).",
        PN.P.GetX(),PN.P.GetY(),PN.P.GetZ(),PN.v.A,PN.v.B,PN.v.C);
        
        
    }
}
