using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Lab_Web_Grupo3.Models;


namespace Projeto_Lab_Web_Grupo3.Data
{
    public class SeedData
    {

        private const string NOME_UTILIZADOR_ADMIN_PADRAO = "nuno_rpf@RDtelecom.com";
        private const string PASSWORD_UTILIZADOR_ADMIN_PADRAO = "Secret123$";
        private const string NOME_UTILIZADOR_CLIENTE_FICTICIO = "pedromachado@gmail.com";

        private const string ROLE_ADIMINISTRADOR = "Administrador";
        private const string ROLE_CLIENTE = "Cliente";
        private const string ROLE_OPERADOR = "Operador";

        internal static void PreencheDados(Projeto_Lab_WebContext bd)
        {
            InserePromocoes(bd);
            InsereTiposServicos(bd);
            InsereServicos(bd);
            //InsereFuncionarios(bd);
            InsereTiposClientes(bd);
            InsereClientes(bd);
            InserePacotes(bd);
            InsereRoles(bd);
            //InsereServicosPacotes(bd);
            //Insere(bd);
            //InserePromocoesPacotes(bd);
            //InsereContratos(bd);
        }


        private static void InsereRoles(Projeto_Lab_WebContext bd)
        {
            if (bd.Roles.Any()) return;

            bd.Roles.AddRange(new Roles[] {
                new Roles
                {
                    Roles_Nome="Administrador",
                },

                 new Roles
                {
                    Roles_Nome="Operador",
                },
            });

        }

        //-------------------PROMOÇÕES--------------------------
        private static void InserePromocoes(Projeto_Lab_WebContext bd)
        {
            if (bd.Promocoes.Any()) return;


            bd.Promocoes.AddRange(new Promocoes[] {
                new Promocoes
                {
                    //PromocoesId=1,
                    Nome="PascoaS",
                    Descricao="Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes pequenos",
                    DataInicio=new DateTime(2021,03,01),
                    DataFim=new DateTime(2021,04,30),
                    PromocaoDesc=2.99m,
                },
                new Promocoes
                {
                    //PromocoesId=2,
                    Nome="PascoaM",
                    Descricao="Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes médios",
                    DataInicio=new DateTime(2021,03,01),
                    DataFim=new DateTime(2021,04,30),
                    PromocaoDesc=3.99m,
                },
                new Promocoes
                {
                    //PromocoesId=3,
                    Nome="PascoaL",
                    Descricao="Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes grandes",
                    DataInicio=new DateTime(2021,03,01),
                    DataFim=new DateTime(2021,04,30),
                    PromocaoDesc=4.99m,
                },
                new Promocoes
                {
                    //PromocoesId=4,
                    Nome="VerãoS",
                    Descricao="Desconto aplicável durante a época de Verão para novas adesões, para pacotes pequenos",
                    DataInicio=new DateTime(2021,07,01),
                    DataFim=new DateTime(2021,08,31),
                    PromocaoDesc=1.99m,
                },
                new Promocoes
                {
                    //PromocoesId=5,
                    Nome="VerãoM",
                    Descricao="Desconto aplicável durante a época de Verão para novas adesões, para pacotes médios",
                    DataInicio=new DateTime(2021,07,01),
                    DataFim=new DateTime(2021,08,31),
                    PromocaoDesc=2.59m,
                },
                new Promocoes
                {
                    //PromocoesId=6,
                    Nome="VerãoL",
                    Descricao="Desconto aplicável durante a época de Verão para novas adesões, para pacotes grandes",
                    DataInicio=new DateTime(2021,07,01),
                    DataFim=new DateTime(2021,08,31),
                    PromocaoDesc=3.99m,
                },
                new Promocoes
                {
                    //PromocoesId=7,
                    Nome="NatalS",
                    Descricao="Desconto aplicável durante a época de Natal para novas adesões, para pacotes pequenos",
                    DataInicio=new DateTime(2021,12,01),
                    DataFim=new DateTime(2022,01,31),
                    PromocaoDesc=3.99m,
                },
                 new Promocoes
                {
                    //PromocoesId=8,
                    Nome="NatalM",
                    Descricao="Desconto aplicável durante a época de Natal para novas adesões, para pacotes médios",
                    DataInicio=new DateTime(2021,12,01),
                    DataFim=new DateTime(2022,01,31),
                    PromocaoDesc=4.99m,
                },
                  new Promocoes
                {
                    //PromocoesId=9,
                    Nome="NatalL",
                    Descricao="Desconto aplicável durante a época de Natal para novas adesões, para pacotes grandes",
                    DataInicio=new DateTime(2021,12,01),
                    DataFim=new DateTime(2022,01,31),
                    PromocaoDesc=5.99m,
                },

            });
            bd.SaveChanges();
        }
        //-------------------FUNCIONARIOS--------------------------
        private static void InsereFuncionarios(Projeto_Lab_WebContext bd)
        {
            if (bd.Funcionarios.Any()) return;
            bd.Funcionarios.AddRange(new Funcionarios[] {
                    new Funcionarios
                {
                    //FuncionarioId=1,
                    Nome="Nuno Forte",
                    DataNascimento=new DateTime(1998,09,29),
                    Morada="Rua das Flores",
                    Telemovel=925258737,
                    Email="nuno_rpf@RDtelecom.com",
                    CodigoPostal="6300-706",
                    //Role="Administrador",
                },
                    new Funcionarios
                {
                    //FuncionarioId=2,
                    Nome="João Matos",
                    DataNascimento=new DateTime(1970,04,21),
                    Morada="Rua da Maurícia Aradas",
                    Telemovel=965111755,
                    Email="joao_matos@RDtelecom.com",
                    CodigoPostal="3810-433",
                    //Role="Operador",
                },
                    new Funcionarios
                {
                    //FuncionarioId=3,
                    Nome="Maria de Fátima",
                    DataNascimento=new DateTime(1963-02-02),
                    Morada="Rua da Prata",
                    Telemovel=927895737,
                    Email="m.fatima@RDtelecom.com",
                    CodigoPostal="1149-005",
                    //Role="Administrador",
                },
                    new Funcionarios
                {
                    //FuncionarioId=4,
                    Nome="Joana Pereira",
                    DataNascimento=new DateTime(1992-11-29),
                    Morada="Avenida Nossa Senhora de Fátima",
                    Telemovel=91746251,
                    Email="J_pereira@RDtelecom.com",
                    CodigoPostal="2414-003",
                    //Role="Operador",
                },
                    new Funcionarios
                {
                    //FuncionarioId=5,
                    Nome="Justina Paulo",
                    DataNascimento=new DateTime(1978-07-17),
                    Morada="Rua de São Gonçalo",
                    Telemovel=912211797,
                    Email="justina_paulo@RDtelecom.com",
                    CodigoPostal="4814-508",
                    //Role="Operador",
                },
                     new Funcionarios
                {
                    //FuncionarioId=6,
                    Nome="Inês Reis",
                    DataNascimento=new DateTime(1998,03,07),
                    Morada="Rua Quinta do Fojo Canidelo",
                    Telemovel=969193547,
                    Email="reis_ines@RDtelecom.com",
                    CodigoPostal="4400-658",
                    //Role="Operador",
                },
                      new Funcionarios
                {
                    //FuncionarioId=7,
                    Nome="Luís Madeira",
                    DataNascimento=new DateTime(1989,10,29),
                    Morada="Rua do Campo Alegre",
                    Telemovel=915111852,
                    Email="luis.madeira@RDtelecom.com",
                    CodigoPostal="4169-008",
                    //Role="Operador",
                },
                    new Funcionarios
                {
                    //FuncionarioId=8,
                    Nome="Paula Melo",
                    DataNascimento=new DateTime(1984,12,29),
                    Morada="Canada dos Melancólicos",
                    Telemovel=925897737,
                    Email="melo.paula@RDtelecom.com",
                    CodigoPostal="9701-870",
                    //Role="Operador",
                },
                    new Funcionarios
                {
                    //FuncionarioId=9,
                    Nome="Paulo Mota",
                    DataNascimento=new DateTime(2000,06,06),
                    Morada="Rua General Humberto Delgado",
                    Telemovel=969687125,
                    Email="paulo_mota@RDtelecom.com",
                    CodigoPostal="1499-004",
                    //Role="Operador",
                },
                   new Funcionarios
                {
                    //FuncionarioId=10,
                    Nome="Marta Machado",
                    DataNascimento=new DateTime(2000,08,01),
                    Morada="Rua Central Mesura",
                    Telemovel=962154873,
                    Email="m.machado@RDtelecom.com",
                    CodigoPostal="3049-002",
                    //Role="Operador",
                },

            });
            bd.SaveChanges();

        }

        //-------------------SERVICOS--------------------------
        private static void InsereServicos(Projeto_Lab_WebContext bd)
        {
            if (bd.Servicos.Any()) return;


            bd.Servicos.AddRange(new Servicos[] {
                    new Servicos
                     {
                    //ServicoId=1,
                    Nome="Canais Fibra",
                    Descricao="Temos vários Pacotes á sua escolha",
                    TipoServicoId= 3,
                },
                     new Servicos
                     {
                    //ServicoId=2,
                    Nome="Telémovel Pré-Pago e Pós-Pago",
                    Descricao="Temos vários Pacotes á sua escolha ",
                     TipoServicoId= 4,
                },
                      new Servicos
                     {
                    //ServicoId=3,
                    Nome="Internet Fixa",
                    Descricao="A melhor internet para si , disponível em varios pacotes.",
                     TipoServicoId= 5,
                },
                       new Servicos
                     {
                    //ServicoId=4,
                    Nome="Internet Móvel",
                    Descricao="Vários Pacotes com vários plafonds para ti",
                    TipoServicoId= 5,
                },

                       new Servicos
                     {

                    Nome="Internet 100/100mbps",
                    Descricao="A velocidade da internet é medida e certificada no dia da instalação.",
                    TipoServicoId= 5,
                },

                    new Servicos
                     {
                    Nome="Internet 1.000/400 Mbps",
                    Descricao="Somos a única operadora a nível mundial com uma rede própria de circuitos de internet internacionais, garantindo sempre a largura de banda necessária.",
                    TipoServicoId= 5,
                },

                    new Servicos
                     {
                    Nome="1 cartão, 500 minutos + 500 SMS por cartão",
                    Descricao="Tenha uma experiência de voz sem falhas, com qualidade superior nas suas chamadas.",
                    TipoServicoId= 4,
                },

                    new Servicos
                     {
                    Nome="1 cartão, 3.500 minutos + 3.500 SMS",
                    Descricao="Tenha uma experiência de voz sem falhas, com qualidade superior nas suas chamadas.",
                    TipoServicoId= 4,
                },

                    new Servicos
                     {
                    Nome="Pack standard 150 canais",
                    Descricao="O melhor entretenimento num só lugar.",
                    TipoServicoId= 3,
                },

                         new Servicos
                     {
                    Nome="Pack standard 200 canais",
                    Descricao="A televisão do futuro em sua casa.",
                    TipoServicoId= 3,
                },

                    new Servicos
                     {
                    Nome="Chamadas telefónicas World",
                    Descricao="Redes fixas nacionais 24h + 50 destinos internacionais (noite, 1.000 min)",
                    TipoServicoId= 2,
                },

                    new Servicos
                     {
                    Nome="Chamadas telefónicas Light",
                    Descricao="Redes fixas nacionais 24h + 20 destinos internacionais (noite, 100 min)",
                    TipoServicoId= 2,
                },

                    new Servicos
                     {
                    Nome="Internet móvel 500MB",
                    Descricao="Ativa no teu smartphone, a qualquer hora e em qualquer lugar 500 MB de dados",
                    TipoServicoId= 1,
                },

                    new Servicos
                     {
                    Nome="Internet móvel 1GB",
                    Descricao="Ativa no teu smartphone, a qualquer hora e em qualquer lugar 1 GB de dados",
                    TipoServicoId= 1,
                },

            });
            bd.SaveChanges();

        }

        private static void InsereServicosPacotes(Projeto_Lab_WebContext bd)
        {
            if (bd.ServicosPacotes.Any()) return;

            bd.ServicosPacotes.AddRange(new ServicosPacotes[] {
                  new ServicosPacotes
                     {
                    PacoteId=1,
                    ServicoId=13,
                },

                  new ServicosPacotes
                     {
                    PacoteId=1,
                    ServicoId=9,
                },

                  new ServicosPacotes
                     {
                    PacoteId=1,
                    ServicoId=17,
                },

                  new ServicosPacotes
                     {
                    PacoteId=1,
                    ServicoId=11,
                },

                   new ServicosPacotes
                     {
                    PacoteId=1,
                    ServicoId=15,
                },

                   new ServicosPacotes
                     {
                    PacoteId=2,
                    ServicoId=13,
                },

                   new ServicosPacotes
                     {
                    PacoteId=2,
                    ServicoId=10,
                },

                   new ServicosPacotes
                     {
                    PacoteId=2,
                    ServicoId=16,
                },

            });
            bd.SaveChanges();
        }

            //-------------------CLIENTES--------------------------
            private static void InsereClientes(Projeto_Lab_WebContext bd)
            {
                if (bd.Clientes.Any()) return;
                bd.Clientes.AddRange(new Clientes[] {
                  new Clientes
                     {
                    //ClienteId=1,
                    Nome="Pedro Machado",
                    DataNascimento=new DateTime(1971,07,14),
                    Nif="922257185",
                    Morada="Colónia Agrícola Casal 63",
                    Telemovel="935559453",
                    Email="pedromachado@gmail.com",
                    CodigoPostal="3870-358",
                    TipoClienteId = 2,


                },
                   new Clientes
                     {
                    //ClienteId=2,
                    Nome="Joaquim Mendez",
                    DataNascimento=new DateTime(1987,12,24),
                    Nif="920099457",
                    Morada="R Indústria Porta 47",
                    Telemovel="915556899",
                    Email="joaquimmendez@outlook.com",
                    CodigoPostal="3300-040",
                    TipoClienteId = 2,

                },
                    new Clientes
                     {
                    //ClienteId=3,
                    Nome="Sandra Vieira",
                    DataNascimento=new DateTime(1977,02,23),
                    Nif="921359357",
                    Morada="R Poeta João Ruiz 6",
                    Telemovel="929355531",
                    Email="sandravieira@gmail.com",
                    CodigoPostal="6230-355",
                    TipoClienteId = 2,

                },
                     new Clientes
                     {
                    //ClienteId=4,
                    Nome="Sara Siqueira",
                    DataNascimento=new DateTime(1977,01,22),
                    Nif="929388769",
                    Morada="R Doutor Alfredo Freitas 108",
                    Telemovel="915551820",
                    Email="sarasiqueiraa@gmail.com",
                    CodigoPostal="3700-501",
                    TipoClienteId = 2,

                },
                     new Clientes
                     {
                    //ClienteId=5,
                    Nome="Nelson Ramos",
                    DataNascimento=new DateTime(1945,07,10),
                    Nif="927822662",
                    Morada="R Indústria Porta 56",
                    Telemovel="929455563",
                    Email="nelsonramos@outlook.com",
                    CodigoPostal="3220-066",
                    TipoClienteId = 2,

                },
                     new Clientes
                     {
                    //ClienteId=6,
                    Nome="Danilo Pires",
                    DataNascimento=new DateTime(1999,06,26),
                    Nif="925387029",
                    Morada="Rua Jorge Sena 99",
                    Telemovel="965559604",
                    Email="danilopires@live.com",
                    CodigoPostal="2650-499",
                    TipoClienteId = 2,
                },

                     new Clientes
                     {
                    //ClienteId=7,
                    Nome="Mônica Torres",
                    DataNascimento=new DateTime(197,02,05),
                    Nif="922534195",
                    Morada="Avenida Guerra Junqueiro 114",
                    Telemovel="921555922",
                    Email="monicatorres@gmail.com",
                    CodigoPostal="2610-116",
                    TipoClienteId = 2,
                },

                     new Clientes
                     {
                    //ClienteId=8,
                    Nome="Daniela Mata",
                    DataNascimento=new DateTime(1974,03,13),
                    Nif="925581543",
                    Morada="R Portela 64",
                    Telemovel="915551704",
                    Email="daielamata@gmail.com",
                    CodigoPostal="3550-171",
                    TipoClienteId = 2,
                },

                     new Clientes
                     {
                    //ClienteId=9,
                    Nome="Virgílio Abreu",
                    DataNascimento=new DateTime(1987,04,16),
                    Nif="928360508",
                    Morada="R Padre João A L Ribeiro 88",
                    Telemovel="915559352",
                    Email="virgilio_abreu@outlook.com",
                    CodigoPostal="3440-376",
                    TipoClienteId = 2,
                },

                     new Clientes
                     {
                    //ClienteId=10,
                    Nome="Martim Moniz",
                    DataNascimento=new DateTime(1984,08,15),
                    Nif="927251038",
                    Morada="R Poeta João Ruiz 90",
                    Telemovel="929455556",
                    Email="martim_moniz@live.com",
                    CodigoPostal="6230-691",
                    TipoClienteId = 2,
                },
            });
                bd.SaveChanges();

            }
            //-------------------PACOTES--------------------------
            private static void InserePacotes(Projeto_Lab_WebContext bd)
            {
                if (bd.Pacotes.Any()) return;


                bd.Pacotes.AddRange(new Pacotes[] {
                 new Pacotes
                     {
                    //PacoteId=1,
                    Nome="Pacote RD4",
                    Descricao="O pacote RD4 destacou-se por apresentar a melhor relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade",
                    Preco=55,
                },
                   new Pacotes
                     {
                    //PacoteId=2,
                    Nome="Pacote RD3",
                    Descricao="O pacote RD3 destacou-se por apresentar a uma ótima relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade para quem não quer ter um telemóvel associado ao pacote.",
                    Preco=45,
                },
                    new Pacotes
                     {
                    //PacoteId=3,
                    Nome="Pacote RD - Gaming",
                    Descricao="A oferta Pacote RD - Gaming é ideal para",
                    Preco=55,
                },
                    new Pacotes
                     {
                    //PacoteId=4,
                    Nome="Pacote RD - TV Premium + gaming",
                    Descricao="A oferta Pacote RD - TV Premium + gaming destacou-se na categoria de “Melhor pacote para Gaming” por apresentar a melhor relação ao nível do número de canais dedicado ao universo cinematográfico  (canais base, exclusivos e premium) face ao custo mensal, bem como uma internet de alta velocidade para não haver falhas durante os jogos.",
                    Preco=65,
                },
                    new Pacotes
                     {
                    //PacoteId=5,
                    Nome="RD TV e Voz",
                    Descricao="Este Pacote RD TV e Voz é ideal para os clientes que querem ver televisão",
                    Preco=25,
                },

                    new Pacotes
                     {
                    //PacoteId=5,
                    Nome="RD Familiar",
                    Descricao="Pacote ideal para os momentos de lazer em família.",
                    Preco=45,
                },

            });
                bd.SaveChanges();
            }

            //-------------------TIPOS DE SERVIÇOS--------------------------
            private static void InsereTiposServicos(Projeto_Lab_WebContext bd)
            {
                if (bd.TiposServicos.Any()) return;


                bd.TiposServicos.AddRange(new Tipos_Sevicos[] {
                      new Tipos_Sevicos
                     {
                   // TipoServicoId=1,
                    Nome="Internet",
                },
                      new Tipos_Sevicos
                     {
                   // TipoServicoId=2,
                    Nome="Telemóvel",
                },
                      new Tipos_Sevicos
                     {
                   // TipoServicoId=3,
                    Nome="Televisão",
                },
                      new Tipos_Sevicos
                     {
                    //TipoServicoId=4,
                    Nome="Telefone Fixo",
                },
                      new Tipos_Sevicos
                     {
                    //TipoServicoId=5,
                    Nome="Internet Móvel",
                },
            });
                bd.SaveChanges();
            }

            //-------------------TIPOS DE CLIENTES--------------------------

            private static void InsereTiposClientes(Projeto_Lab_WebContext bd)
            {
                if (bd.Tipos_Clientes.Any()) return;


                bd.Tipos_Clientes.AddRange(new Tipos_Clientes[] {
                     new Tipos_Clientes
                     {
                   // TipoClienteId=1,
                    Nome="Particular",
                },
                     new Tipos_Clientes
                     {
                   // TipoClienteId=2,
                    Nome="Empresa",
                },
            });
                bd.SaveChanges();
            }
            //---------------------------------PromocoesPacotes------------------------------
            private static void InserePromocoesPacotes(Projeto_Lab_WebContext bd)
            {
                if (bd.PromocoesPacotes.Any()) return;
                bd.PromocoesPacotes.AddRange(new PromocoesPacotes[]
                {
                new PromocoesPacotes
                {
                    PacoteId = 4,
                    PromocoesId= 1,
                    NomePacote = "M30",
                    NomePromocoes="PáscoaS"
                },
                new PromocoesPacotes
                {
                    PacoteId=5,
                    PromocoesId=2,
                    NomePacote="M4O",
                    NomePromocoes="PáscoaM"
                },
                new PromocoesPacotes
                {
                    PacoteId=1,
                    PromocoesId=3,
                    NomePacote="Tv Premium + Mgaming",
                    NomePromocoes="PáscoaL"
                },
                new PromocoesPacotes
                {
                    PacoteId=3,
                    PromocoesId=4,
                    NomePacote="Pré-Pago 25",
                    NomePromocoes="VerãoS"
                },
                new PromocoesPacotes
                {
                    PacoteId=2,
                    PromocoesId=5,
                    NomePacote="MGaming",
                    NomePromocoes="VerãoM"
                },
                new PromocoesPacotes
                {
                    PacoteId=1,
                    PromocoesId=6,
                    NomePacote="TvPremium + MGaming",
                    NomePromocoes="VerãoL"
                },


                });
                bd.SaveChanges();
            }

            private static void InsereContratos(Projeto_Lab_WebContext bd)
            {
                if (bd.Contratos.Any()) return;
                bd.Contratos.AddRange(new Contratos[] {
                    new Contratos
                {
                    //ContratoId=1,
                    ClienteId=1,
                    FuncionarioId=3,
                    DataInicio=new DateTime(2021,07,02),
                    PrecoFinal=61.01m,
                    DataFim=new DateTime(2023,07,02),
                    PromocoesPacotes=1,
                    PrecoPacote=65.00m,
                    PromocaoDesc=3.99m,
                    NomeCliente="Pedro Machado",
                    NomeFuncionario="Maria de Fátima",
                    Telefone=213695748,
                },
            new Contratos
                {
                    //ContratoId=2,
                    ClienteId=2,
                    FuncionarioId=5,
                    DataInicio=new DateTime(2021,07,03),
                    PrecoFinal=23.01m,
                    DataFim=new DateTime(2023,07,03),
                    PromocoesPacotes=3,
                    PrecoPacote=25.00m,
                    PromocaoDesc=1.99m,
                    NomeCliente="Joaquim Mendez",
                    NomeFuncionario="Justina Paulo",
                    Telefone=214569874,
                },
             new Contratos
                {
                    //ContratoId=3,
                    ClienteId=3,
                    FuncionarioId=7,
                    DataInicio=new DateTime(2021,07,02),
                    PrecoFinal=61.01m,
                    DataFim=new DateTime(2023,07,02),
                    PromocoesPacotes=1,
                    PrecoPacote=65.00m,
                    PromocaoDesc=3.99m,
                    NomeCliente="Sandra Vieira",
                    NomeFuncionario="Luís Madeira",
                    Telefone=215421367,
                },
             new Contratos
                {
                    //ContratoId=4,
                    ClienteId=4,
                    FuncionarioId=8,
                    DataInicio=new DateTime(2021,07,03),
                    PrecoFinal=42.41m,
                    DataFim=new DateTime(2023,07,03),
                    PromocoesPacotes=2,
                    PrecoPacote=45.00m,
                    PromocaoDesc=2.59m,
                    NomeCliente="Sara Siqueira",
                    NomeFuncionario="Paula Melo",
                    Telefone=219632541,
                },
             new Contratos
                {
                    //ContratoId=5,
                    ClienteId=5,
                    FuncionarioId=7,
                    DataInicio=new DateTime(2021,03,05),
                    PrecoFinal=60.01m,
                    DataFim=new DateTime(2023,03,05),
                    PromocoesPacotes=4,
                    PrecoPacote=65.00m,
                    PromocaoDesc=4.99m,
                    NomeCliente="Nelson Ramos",
                    NomeFuncionario="Luís Madeira",
                    Telefone=213564789,
                },
             new Contratos
                {
                    //ContratoId=6,
                    ClienteId=6,
                    FuncionarioId=7,
                    DataInicio=new DateTime(2021,03,25),
                    PrecoFinal=51.01m,
                    DataFim=new DateTime(2023,03,25),
                    PromocoesPacotes=5,
                    PrecoPacote=50.00m,
                    PromocaoDesc=3.99m,
                    NomeCliente="Danilo Pires",
                    NomeFuncionario="Luís Madeira",
                    Telefone=215632123,
                },
             new Contratos
                {
                    //ContratoId=7,
                    ClienteId=7,
                    FuncionarioId=6,
                    DataInicio=new DateTime(2021,04,01),
                    PrecoFinal=22.01m,
                    DataFim=new DateTime(2023,04,01),
                    PromocoesPacotes=6,
                    PrecoPacote=25.00m,
                    PromocaoDesc=2.99m,
                    NomeCliente="Mônica Torres",
                    NomeFuncionario="Inês Reis",
                    Telefone=213154689,
                },
             new Contratos
                {
                    //ContratoId=8,
                    ClienteId=8,
                    FuncionarioId=10,
                    DataInicio=new DateTime(2021,07,03),
                    PrecoFinal=42.41m,
                    DataFim=new DateTime(2023,07,03),
                    PromocoesPacotes=2,
                    PrecoPacote=45.00m,
                    PromocaoDesc=2.59m,
                    NomeCliente="Daniela Mata",
                    NomeFuncionario="Marta Machado",
                    Telefone=216335559,
                },
             new Contratos
                {
                    //ContratoId=9,
                    ClienteId=9,
                    FuncionarioId=1,
                    DataInicio=new DateTime(2021,08,01),
                    PrecoFinal=61.01m,
                    DataFim=new DateTime(2023,08,01),
                    PromocoesPacotes=1,
                    PrecoPacote=65.00m,
                    PromocaoDesc=3.99m,
                    NomeCliente="Virgílio Abreu",
                    NomeFuncionario="Nuno Forte",
                    Telefone=211145965,
                },
             new Contratos
                {
                    //ContratoId=10,
                    ClienteId=10,
                    FuncionarioId=3,
                    DataInicio=new DateTime(2021,08,04),
                    PrecoFinal=61.01m,
                    DataFim=new DateTime(2023,08,04),
                    PromocoesPacotes=1,
                    PrecoPacote=65.00m,
                    PromocaoDesc=3.99m,
                    NomeCliente="Martim Moniz",
                    NomeFuncionario="Maria de Fátima",
                    Telefone=215648565,
                },
          });
                bd.SaveChanges();
            }

            internal static async Task InsereUtilizadoresFicticiosAsync(UserManager<IdentityUser> gestorUtilizadores)
            {
                IdentityUser cliente = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, NOME_UTILIZADOR_CLIENTE_FICTICIO, "Secret123$");
                await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, cliente, ROLE_CLIENTE);

                IdentityUser gestor = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "maria@ipg.pt", "Secret123$");
                await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, gestor, ROLE_OPERADOR);
            }

            //---------------------ADMINISTRADORES-----------------------

            internal static async Task InsereRolesAsync(RoleManager<IdentityRole> gestorRoles)
            {
                await CriaRoleSeNecessario(gestorRoles, ROLE_ADIMINISTRADOR);
                await CriaRoleSeNecessario(gestorRoles, ROLE_CLIENTE);
                await CriaRoleSeNecessario(gestorRoles, ROLE_OPERADOR);
                //await CriaRoleSeNecessario(gestorRoles, "PodeAlterarPrecoProdutos");
            }

            private static async Task CriaRoleSeNecessario(RoleManager<IdentityRole> gestorRoles, string funcao)
            {
                if (!await gestorRoles.RoleExistsAsync(funcao))
                {
                    IdentityRole role = new IdentityRole(funcao);
                    await gestorRoles.CreateAsync(role);
                }
            }

            internal static async Task InsereAdministradorPadraoAsync(UserManager<IdentityUser> gestorUtilizadores)
            {
                IdentityUser utilizador = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, NOME_UTILIZADOR_ADMIN_PADRAO, PASSWORD_UTILIZADOR_ADMIN_PADRAO);
                await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, utilizador, ROLE_ADIMINISTRADOR);
            }

            private static async Task AdicionaUtilizadorRoleSeNecessario(UserManager<IdentityUser> gestorUtilizadores, IdentityUser utilizador, string role)
            {
                if (!await gestorUtilizadores.IsInRoleAsync(utilizador, role))
                {
                    await gestorUtilizadores.AddToRoleAsync(utilizador, role);
                }
            }

            private static async Task<IdentityUser> CriaUtilizadorSeNaoExiste(UserManager<IdentityUser> gestorUtilizadores, string nomeUtilizador, string password)
            {
                IdentityUser utilizador = await gestorUtilizadores.FindByNameAsync(nomeUtilizador);

                if (utilizador == null)
                {
                    utilizador = new IdentityUser(nomeUtilizador);
                    await gestorUtilizadores.CreateAsync(utilizador, password);
                }

                return utilizador;
            }
        }
    }

