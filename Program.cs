using System;
using System.Globalization;
using System.Collections.Generic;
using System.Threading;

namespace TrabalhoPC1Bim
{
    class Program
    {
        static void Main(string[] args)
        { 
            Boolean exec = true;
            List<Loja> ListaLoja = new List<Loja>();
            do
            {
                Console.WriteLine("\nMenu de Cadastro");
                Console.WriteLine("01 - Incluir");
                Console.WriteLine("02 - Alterar");
                Console.WriteLine("03 - Excluir");
                Console.WriteLine("04 - Listar");
                Console.WriteLine("05 - Pesquisar");
                Console.WriteLine("09 - Sair");
                Console.Write("Digite a opção desejada: ");
                string opc = Console.ReadLine();

                switch (opc)
                {
                    case "01": ListaLoja.Add(InlcuirProduto());
                        break;

                    case "02":
                        Console.WriteLine("\nAlterar dados do produto");
                        Console.WriteLine("Lista de produtos cadastrados até o momento: ");
                        foreach (Loja obj in ListaLoja)
                        {
                            Console.WriteLine(obj);
                        }
                        Console.Write("\nDigite o Id do produto que deseja alterar:#");
                        int searchId = int.Parse(Console.ReadLine());
                        Loja busca = ListaLoja.Find(x => x.Id == searchId);

                        if(busca != null)
                        {
                            Console.WriteLine("O que gostaria de alterar: ");
                            Console.WriteLine("01 - Produto");
                            Console.WriteLine("02 - Preço(porcentagem)\n");
                            string opcAlt = Console.ReadLine();

                            switch (opcAlt)
                            {
                                case "01":
                                    if (busca != null)
                                    {
                                        Console.Write("Digite o novo nome do produto: ");
                                        string newtextProd = Console.ReadLine();
                                        busca.AlteraNomeProd(newtextProd);
                                        Console.WriteLine("Lista de produtos atualizada: ");
                                        foreach (Loja obj in ListaLoja)
                                        {
                                            Console.WriteLine(obj);
                                        }
                                    }
                                    break;
                                case "02":
                                    if (busca != null)
                                    {
                                        Console.Write("Digite a porcetagem que deseja aumentar:%");
                                        double porcentagem = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                                        busca.AlterarProduto(porcentagem);
                                        Console.WriteLine();
                                        Console.WriteLine("Lista de produtos atualizada: ");
                                        foreach (Loja obj in ListaLoja)
                                        {
                                            Console.WriteLine(obj);
                                        }
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Opção não existente!!");
                                    break;

                            }
                        }
                        else
                        {
                            Console.Write("Id do produto não existente!!\n");
                        }            
                        
                        break;

                    case "03":
                        foreach (Loja cadastrados in ListaLoja)
                        {
                            Console.WriteLine(cadastrados);
                        }
                        Console.Write("\nQual o Id do produto a ser excluído:#");
                        int index = int.Parse(Console.ReadLine());
                        Loja busca1 = ListaLoja.Find(x => x.Id == index);
                        if (busca1 != null)
                        {
                            ListaLoja.Remove(new Loja() { Id = index });
                            Console.WriteLine("Lista de produtos atualizada:");
                            foreach (Loja cadastrados in ListaLoja)
                            {
                                Console.WriteLine(cadastrados);
                            }
                        }
                          else
                        {
                            Console.WriteLine("Id do produto não existente!!");
                        }
                        break;

                    case "04":
                        Console.WriteLine("\nLista Ordenada por Id");
                            ListaLoja.Sort(delegate (Loja p1, Loja p2)
                            {
                                return p1.Id.CompareTo(p2.Id);
                            });
                            ListaLoja.ForEach(delegate (Loja p)
                            {
                                Console.WriteLine(String.Format("{0}|{1}|{2}", p.Id, p.Produto, p.Preco));
                            });
                        break;

                    case "05":
                        Console.Write("\nQual Id deseja localizar:#");
                        int filtro = int.Parse(Console.ReadLine());
                        Loja localizar = ListaLoja.Find(x => x.Id == filtro);
                        if (localizar != null)
                        {
                            Console.WriteLine("\nLocalizado: " + localizar);
                        }
                        else
                        {
                            Console.WriteLine("Id do produto não existente!!");
                        }
                        break;

                    case "09": Console.WriteLine("\nAplicação encerrada");
                        Thread.Sleep(2000);
                        Environment.Exit(1);
                        exec = false;
                        break;

                    default:
                        Console.WriteLine("\nOpção não existente!!");
                        break;
                }

            }
            while (exec);
            
        }
        private static Loja InlcuirProduto()
        {
            Loja loja = new Loja();
            Console.WriteLine("\nCadastro de Produto");
            Console.Write("Id: #");
            loja.Id = int.Parse(Console.ReadLine());
            Console.Write("Produto: ");
            loja.Produto = Console.ReadLine();
            Console.Write("Preço: ");
            loja.Preco = double.Parse(Console.ReadLine());
            return loja;
        }
    }
}
