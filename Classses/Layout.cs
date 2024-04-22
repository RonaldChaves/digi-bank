namespace DigiBank.Classses
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        public static int opcao = 0;    
        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            Console.WriteLine("                                                          ");
            Console.WriteLine("            Digite a Opção desejada:                      ");
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");
            Console.WriteLine("            1 - Criar Conta                               ");
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");
            Console.WriteLine("            2 - Entrar com CPF e Senha                    ");
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");

#pragma warning disable CS8604 // Possible null reference argument.
            opcao = int.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Possible null reference argument.

            switch (opcao)
            {
                case 1:
                    TelaCriarConta();
                    break;
                case 2:
                    TelaLogin();
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
        }

        private static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine("                                                          ");
            Console.WriteLine("            Digite seu Nome:                              ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string nome = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");
            Console.WriteLine("            Digite o CPF:                                 ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string cpf = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");
            Console.WriteLine("            Digite sua Senha:                             ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string senha = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");

            //criar conta

            ContaCorrente contacorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();

            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = contacorrente;

            pessoas.Add(pessoa);

            Console.Clear();

            Console.WriteLine("            Conta criada com sucesso                      ");
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");

            Thread.Sleep(1000);

            TelaContaLogada(pessoa);
        }

        private static void TelaLogin()
        {
            Console.Clear();

            Console.WriteLine("                                                          ");
            Console.WriteLine("            Digite o CPF:                                 ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string cpf = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");
            Console.WriteLine("            Digite seua senha                             ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string senha = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (pessoa != null)
            {
                TelaBoasVindas(pessoa);
                TelaContaLogada(pessoa);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("            Pessoa não cadastrada!!                       ");
                Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");
                Console.WriteLine("");
                Console.WriteLine("");

                TelaPrincipal();
            }
        }

        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string msgTelaBemVindo =
                $"{pessoa.Nome} | Banco: {pessoa.Conta.GetCodigoDoBanco()} | Agência: {pessoa.Conta.GetNumeroAgencia()}" +
                $" Conta: {pessoa.Conta.GetNumeroDaConta()}";
            Console.WriteLine("");
            Console.WriteLine($"      Seja Bem Vindo, {msgTelaBemVindo}           ");
            Console.WriteLine("");
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("            Digite a opção desejada                       ");
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");
            Console.WriteLine("            1 - Realizar um Depósito                      ");
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");
            Console.WriteLine("            2 - Realizar um Saque                         ");
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");
            Console.WriteLine("            3 - Consultar Saldo                           ");
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");
            Console.WriteLine("            4 - Extrato                                   ");
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");
            Console.WriteLine("            5 - Sair                                      ");
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1: TelaDeposito(pessoa);
                    break;
                case 2: TelaSaque(pessoa);
                    break;
                case 3: TelaSaldo(pessoa);
                    break;
                case 4: TelaExtrato(pessoa);
                    break;
                case 5:
                    TelaPrincipal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("            Opção Inválida!                               ");
                    Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");
                    break;
            }                  
        }

        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("            Digite o valor do depósito:                   ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");

            pessoa.Conta.Deposita(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                          ");
            Console.WriteLine("                                                          ");
            Console.WriteLine("            Depósito realizado com sucesso!               ");
            Console.WriteLine("           :::::::::::::::::::::::::::::::::              ");
            Console.WriteLine("                                                          ");
            Console.WriteLine("                                                          ");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("            Digite o valor do saque   :                   ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("           ::::::::::::::::::::::::::::::                 ");

            bool oksaque = pessoa.Conta.Saca(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                          ");
            Console.WriteLine("                                                          ");

            if (oksaque)
            {
                Console.WriteLine("            Saque realizado com sucesso!                  ");
                Console.WriteLine("           :::::::::::::::::::::::::::::::::              ");
            }
            else
            {
                Console.WriteLine("            Saldo insuficiente!                           ");
                Console.WriteLine("           :::::::::::::::::::::::::::::::::              ");
            }

            Console.WriteLine("                                                          ");
            Console.WriteLine("                                                          ");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaSaldo(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine($"            Seu saldo é: {pessoa.Conta.ConsultaSaldo()}  ");
            Console.WriteLine("           :::::::::::::::::::::::::::::::::              ");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaExtrato(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            if (pessoa.Conta.Extrato().Any())
            {
                double total = pessoa.Conta.Extrato().Sum(x => x.Valor);

                foreach(Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine("                                                          ");
                    Console.WriteLine("                                                          ");
                    Console.WriteLine($"         Data: {extrato.Data.ToString("dd/MM/yyyy HH:mm:ss")}      ");
                    Console.WriteLine($"         Tipo de Movimentação: {extrato.Descricao}      ");
                    Console.WriteLine($"         Valor: {extrato.Valor}      ");
                    Console.WriteLine("         :::::::::::::::::::::::::::::::::              ");
                }

                Console.WriteLine("                                                          ");
                Console.WriteLine("                                                          ");                
                Console.WriteLine($"                SUB TOTAL {total}                        ");
                Console.WriteLine("           :::::::::::::::::::::::::::::::::              ");
            }
            else
            {
                Console.WriteLine("           Não há extrato a ser exibido!                  ");
                Console.WriteLine("           :::::::::::::::::::::::::::::::::              ");
            }


            OpcaoVoltarLogado(pessoa);
        }

        private static void OpcaoVoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("           Entre com uma opção abaixo?                    ");
            Console.WriteLine("           :::::::::::::::::::::::::::::::::              ");
            Console.WriteLine("            1 - Voltar para menu principal                ");
            Console.WriteLine("           :::::::::::::::::::::::::::::::::              ");
            Console.WriteLine("            2 - Sair                                      ");
            Console.WriteLine("           :::::::::::::::::::::::::::::::::              ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                TelaContaLogada(pessoa);
            }
            else
            {
                TelaPrincipal();
            }
                
        }

        private static void OpcaoVoltarDeslogado()
        {
            Console.WriteLine("           Entre com uma opção abaixo?                    ");
            Console.WriteLine("           :::::::::::::::::::::::::::::::::              ");
            Console.WriteLine("            1 - Voltar para menu principal                ");
            Console.WriteLine("           :::::::::::::::::::::::::::::::::              ");
            Console.WriteLine("            2 - Sair                                      ");
            Console.WriteLine("           :::::::::::::::::::::::::::::::::              ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1 )
            {
                TelaPrincipal();
            }
            else
            {
                Console.WriteLine("               Opção Inválida!                        ");
                Console.WriteLine("           ::::::::::::::::::::::::::::::             ");
            }

        }
    }
} 