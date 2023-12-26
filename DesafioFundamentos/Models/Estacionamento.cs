using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        //Implementado!
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placa = Console.ReadLine().ToUpper();
            
            try
            {
                if (!IsValidPlacaFormat(placa))
                {
                    throw new FormatException ("Placa inválida. Insira uma placa no formato correto (ABC1234 ou ABC1D23).");
                }

                else if (veiculos.Contains(placa))
                {
                    throw new InvalidOperationException ("Não é possível cadastrar este veículo, pois ele já está registrado. Por favor, insira uma placa válida.");
                }

                else
                {
                    veiculos.Add(placa);
                    Console.WriteLine("Veículo estacionado com sucesso!");
                }
            }

            //Erro de formatação
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            //Erro de operação
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private bool IsValidPlacaFormat(string placa)
        {
              string pattern = @"^[A-Z]{3}\d{4}$|^[A-Z]{3}\d[A-Z]\d{2}$";
              return Regex.IsMatch(placa, pattern);
        }


        //Implementado!
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe na lista e verifica se a condição está sendo atendida.
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper())) 
            {
                int horas;

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
                // codigo usado para receber a qtdHoras digitada pelo usuário e armazenar o valor da string que foi convertida para um inteiro, onde será validado a conversão.
                if(int.TryParse(Console.ReadLine(), out horas)) 
                {
                
                decimal valorTotal;

                valorTotal = precoInicial + precoPorHora * horas;
                veiculos.Remove(placa); 

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                } 
                
                else
                
                {
                    Console.WriteLine("As horas que você digitou está inválida. Por favor, insira um valor válido para as horas.");
                }

            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        //Implementado!
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                int count = 1;

                Console.WriteLine("Os veículos estacionados são:");
                
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine($"Veiculo {count} - {veiculo}");
                    count++;
                }

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
