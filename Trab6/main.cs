/***************************************************
    Angelica Lourenco Oliveira - 11711GIN061 - UFU 
***************************************************/

using System;

class Trabalho6 {
    
    class Pessoa{
        public int codigo;
        public string nome;
        public int idade;
        
        public Pessoa(int codigo, string nome, int idade){
            this.codigo = codigo;
            this.nome = nome;
            this.idade = idade;
        }
    }
    
    class ListInArray {
        Pessoa[] pessoas;
        int count;
        
        public ListInArray(int capacity) {
            this.pessoas = new Pessoa[capacity];
            this.count = 0;
        }
        
        public bool IsFull() {
            return (count == pessoas.Length);
        }
        
        public bool IsEmpty() {
            return (count == 0);
        }
        
        public void Display() {
            if (IsEmpty())
                Console.WriteLine("lista Vazia");
                
            for (int i=0;i<count;i++)
                Console.WriteLine("Nome: {0}\nCodigo: {1}\nIdade: {2}\n",pessoas[i].nome,pessoas[i].codigo,pessoas[i].idade);
        }
        
        // Inclui somente essa opção para inserir as Pessoas já ordenadas pelos codigos, já que a busca necessita de ordenação
        public void AddSorted(Pessoa newPessoa) {
            if (IsFull())
                throw new Exception("lista cheia");
            int k = 0;
            while (k < count && pessoas[k].codigo <= newPessoa.codigo)
                k++;
                
            for (int i = count; i > k; i--)
                pessoas[i] = pessoas[i - 1];
                
            pessoas[k] = newPessoa;
            count++;
        }
        
        // Funcao de busca binaria
        public bool Contains_BinarySearch(int cod) {
            if (IsEmpty())
                throw new Exception("Lista vazia\n");
                
            int min = 0;
            int max = count - 1;
            
            while (min <= max) {
                int mid = (min + max) / 2;
                if (cod == pessoas[mid].codigo){
                    Console.WriteLine("\nPessoa encontrada!\nDados:");
                    Console.WriteLine("Nome: {0}\nCodigo: {1}\nIdade: {2}",pessoas[mid].nome,pessoas[mid].codigo,pessoas[mid].idade);
                    return true;
                }else if (cod < pessoas[mid].codigo)
                    max = mid - 1;
                else
                    min = mid + 1;
            }
            Console.WriteLine("\nPessoa nao encontrada!");
            return false;
        }
    }

    static void Main () {
        
        ListInArray pessoas = new ListInArray(1000000);
        
        int op = 0;
        while (op != 4){
            //Menu
            Console.WriteLine("********************MENU*********************");
            Console.WriteLine("* 1 – Cadastrar pessoa                      *");
            Console.WriteLine("* 2 – Buscar pessoa no cadastro pelo código *");
            Console.WriteLine("* 3 – Mostrar todas as pessoas cadastradas  *");
            Console.WriteLine("* 4 – Sair                                  *");
            Console.WriteLine("*********************************************");
            Console.WriteLine("\nEscolha uma opção do menu:");
            op = Convert.ToInt32(Console.ReadLine());
            
            if (op == 1){
                Console.WriteLine("Entre com o codigo");
                int codigo = Convert.ToInt32(Console.ReadLine());
                
                if (pessoas.Contains_BinarySearch(codigo)) {
                    Console.WriteLine("Codigo ja cadastrado.");
                    continue;
                }
                
                Console.WriteLine("Entre com o nome");
                string nome = Console.ReadLine();
                
                Console.WriteLine("Entre com a idade");
                int idade = Convert.ToInt32(Console.ReadLine());
                
                Pessoa p = new Pessoa(codigo,nome,idade);
                pessoas.AddSorted(p);
            } else if (op == 2){
                if (pessoas.IsEmpty()){
                    Console.WriteLine("Lista vazia\n");
                    continue;
                }
                    Console.WriteLine("Entre com o codigo de busca");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    pessoas.Contains_BinarySearch(codigo);
            }else if (op == 3)
                pessoas.Display();
        }
    }
}
