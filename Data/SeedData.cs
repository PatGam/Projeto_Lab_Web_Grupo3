﻿using Microsoft.AspNetCore.Mvc;
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

        internal static void PreencheDados(Projeto_Lab_WebContext bd)
        {
            InserePromocoes(bd);
            InsereFuncionarios(bd);
            InsereServicos(bd);
            InsereClientes(bd);
            //Insere(bd);

        }
        //-------------------PROMOÇÕES--------------------------
        private static void InserePromocoes(Projeto_Lab_WebContext bd)
        {
            if (bd.Promocoes.Any()) return;


            bd.Promocoes.AddRange(new Promocoes[] {
                new Promocoes
                {
                    //Promocoes_Id="",
                    Nome="PascoaS",
                    Descricao="Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes pequenos",
                    DataInicio=new DateTime(2021,03,01),
                    DataFim=new DateTime(2021,04,30),
                    PromocaoDesc=2.99m,
                },
                new Promocoes
                {
                    //Promocoes_Id="",
                    Nome="PascoaM",
                    Descricao="Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes médios",
                    DataInicio=new DateTime(2021,03,01),
                    DataFim=new DateTime(2021,04,30),
                    PromocaoDesc=3.99m,
                },
                new Promocoes
                {
                    //Promocoes_Id="",
                    Nome="PascoaL",
                    Descricao="Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes grandes",
                    DataInicio=new DateTime(2021,03,01),
                    DataFim=new DateTime(2021,04,30),
                    PromocaoDesc=4.99m,
                },
                new Promocoes
                {
                    //Promocoes_Id="",
                    Nome="VerãoS",
                    Descricao="Desconto aplicável durante a época de Verão para novas adesões, para pacotes pequenos",
                    DataInicio=new DateTime(2021,07,01),
                    DataFim=new DateTime(2021-08-31),
                    PromocaoDesc=1.99m,
                },
                new Promocoes
                {
                    //Promocoes_Id="",
                    Nome="VerãoM",
                    Descricao="Desconto aplicável durante a época de Verão para novas adesões, para pacotes médios",
                    DataInicio=new DateTime(2021,07,01),
                    DataFim=new DateTime(2021-08-31),
                    PromocaoDesc=2.59m,
                },
                new Promocoes
                {
                    //Promocoes_Id="",
                    Nome="VerãoL",
                    Descricao="Desconto aplicável durante a época de Verão para novas adesões, para pacotes grandes",
                    DataInicio=new DateTime(2021,07,01),
                    DataFim=new DateTime(2021-08-31),
                    PromocaoDesc=3.99m,
                },
                new Promocoes
                {
                    //Promocoes_Id="",
                    Nome="NatalS",
                    Descricao="Desconto aplicável durante a época de Natal para novas adesões, para pacotes pequenos",
                    DataInicio=new DateTime(2021,12,01),
                    DataFim=new DateTime(2022,01,31),
                    PromocaoDesc=3.99m,
                },
                 new Promocoes
                {
                    //Promocoes_Id="",
                    Nome="NatalM",
                    Descricao="Desconto aplicável durante a época de Natal para novas adesões, para pacotes médios",
                    DataInicio=new DateTime(2021,12,01),
                    DataFim=new DateTime(2022,01,31),
                    PromocaoDesc=4.99m,
                },
                  new Promocoes
                {
                    //Promocoes_Id="",
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
                    //FuncionarioId="",
                    Nome="Nuno Forte",
                    DataNascimento=new DateTime(1998,09,29),
                    Morada="Rua das Flores",
                    Telemovel=925258737,
                    Email="nuno_rpf@hotmail.com",
                    CodigoPostal="6300-706",
                    Role="Administrador",
                },
                    new Funcionarios
                {
                    //FuncionarioId="",
                    Nome="João Matos",
                    DataNascimento=new DateTime(1970,04,21),
                    Morada="Rua da Maurícia Aradas",
                    Telemovel=965111755,
                    Email="joao_matos@hotmail.com",
                    CodigoPostal="3810-433",
                    Role="Operador",
                },
                    new Funcionarios
                {
                    //FuncionarioId="",
                    Nome="Maria de Fátima",
                    DataNascimento=new DateTime(1963-02-02),
                    Morada="Rua da Prata",
                    Telemovel=927895737,
                    Email="m.fatima@hotmail.com",
                    CodigoPostal="1149-005",
                    Role="Administrador",
                },
                    new Funcionarios
                {
                    //FuncionarioId="",
                    Nome="Joana Pereira",
                    DataNascimento=new DateTime(1992-11-29),
                    Morada="Avenida Nossa Senhora de Fátima",
                    Telemovel=91746251,
                    Email="J_pereira@hotmail.com",
                    CodigoPostal="2414-003",
                    Role="Operador",
                },
                    new Funcionarios
                {
                    //FuncionarioId="",
                    Nome="Justina Paulo",
                    DataNascimento=new DateTime(1978-07-17),
                    Morada="Rua de São Gonçalo",
                    Telemovel=912211797,
                    Email="justina_paulo@hotmail.com",
                    CodigoPostal="4814-508",
                    Role="Operador",
                },
                     new Funcionarios
                {
                    //FuncionarioId="",
                    Nome="Inês Reis",
                    DataNascimento=new DateTime(1998,03,07),
                    Morada="Rua Quinta do Fojo Canidelo",
                    Telemovel=969193547,
                    Email="reis_ines@hotmail.com",
                    CodigoPostal="4400-658",
                    Role="Operador",
                },
                      new Funcionarios
                {
                    //FuncionarioId="",
                    Nome="Luís Madeira",
                    DataNascimento=new DateTime(1989,10,29),
                    Morada="Rua do Campo Alegre",
                    Telemovel=915111852,
                    Email="luis.madeira@hotmail.com",
                    CodigoPostal="4169-008",
                    Role="Operador",
                },
                    new Funcionarios
                {
                    //FuncionarioId="",
                    Nome="Paula Melo",
                    DataNascimento=new DateTime(1984,12,29),
                    Morada="Canada dos Melancólicos",
                    Telemovel=925897737,
                    Email="melo.paula@hotmail.com",
                    CodigoPostal="9701-870",
                    Role="Operador",
                },
                    new Funcionarios
                {
                    //FuncionarioId="",
                    Nome="Paulo Mota",
                    DataNascimento=new DateTime(2000,06,06),
                    Morada="Rua General Humberto Delgado",
                    Telemovel=969687125,
                    Email="paulo_mota@hotmail.com",
                    CodigoPostal="1499-004",
                    Role="Operador",
                },
                   new Funcionarios
                {
                    //FuncionarioId="",
                    Nome="Marta Machado",
                    DataNascimento=new DateTime(2000,08,01),
                    Morada="Rua Central Mesura",
                    Telemovel=962154873,
                    Email="m.machado@hotmail.com",
                    CodigoPostal="3049-002",
                    Role="Operador",
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
                    //ServicoId="",
                    Nome="m4o",
                    Descricao="",
                    TipoServico="Tv, Internet, Telemóvel",
                },
                     new Servicos
                     {
                    //ServicoId="",
                    Nome="m3o",
                    Descricao="",
                    TipoServico="Tv, Internet",
                },
                      new Servicos
                     {
                    //ServicoId="",
                    Nome="Pré-Pago 25",
                    Descricao="25 gbs para levares para todo o lado",
                    TipoServico="Internet",
                },
                       new Servicos
                     {
                    //ServicoId="",
                    Nome="M Gaming",
                    Descricao="A melhor internet para jogares",
                    TipoServico="Internet",
                },
                       new Servicos
                     {
                    //ServicoId="",
                    Nome="M Gaming + tv",
                    Descricao="A melhor internet para jogares e 150 canais",
                    TipoServico="'Tv, Internet",
                },
                       new Servicos
                     {
                    //ServicoId="",
                    Nome="M1 tv",
                    Descricao="130 canais",
                    TipoServico="Tv",
                },
                     new Servicos
                     {
                    //ServicoId="",
                    Nome="M1 tv",
                    Descricao="130 canais",
                    TipoServico="Telemóvel",
                },
                     new Servicos
                     {
                    //ServicoId="",
                    Nome="Serviço móvel extra",
                    Descricao="10 gb de net e 10000 minutos de chamadas e 10000 sms para ti todos os meses",
                    TipoServico="Telemóvel",
                },
                     new Servicos
                     {
                    //ServicoId="",
                    Nome="TV premium",
                    Descricao="Todos os canais desbloqueados para ti",
                    TipoServico="Tv",
                },

            });
            bd.SaveChanges();
        }
        //-------------------SERVICOS--------------------------
        private static void InsereClientes(Projeto_Lab_WebContext bd)
        {
            if (bd.Clientes.Any()) return;
            bd.Clientes.AddRange(new Clientes[] {
                  new Clientes
                     {
                    //Cliente_Id="",
                    Nome="Pedro Machado",
                    DataNascimento=new DateTime(1971,07,14),
                    Nif=922257185,
                    Morada="Colónia Agrícola Casal 63",
                    Telemovel=935559453,
                    Email="pedromachado@gmail.com",
                    CodigoPostal="3870-358",

                },
                   new Clientes
                     {
                    //Cliente_Id="",
                    Nome="Joaquim Mendez",
                    DataNascimento=new DateTime(1987,12,24),
                    Nif=920099457,
                    Morada="R Indústria Porta 47",
                    Telemovel=915556899,
                    Email="joaquimmendez@outlook.com",
                    CodigoPostal="3300-040",

                },
                    new Clientes
                     {
                    //Cliente_Id="",
                    Nome="Pedro Machado",
                    DataNascimento=new DateTime(1977,02,23),
                    Nif=921359357,
                    Morada="R Poeta João Ruiz 6",
                    Telemovel=929355531,
                    Email="sandravieira@gmail.com",
                    CodigoPostal="6230-355",

                },
                     new Clientes
                     {
                    //Cliente_Id="",
                    Nome="Sara Siqueira",
                    DataNascimento=new DateTime(1977,01,22),
                    Nif=929388769,
                    Morada="R Doutor Alfredo Freitas 108",
                    Telemovel=915551820,
                    Email="sarasiqueiraa@gmail.com",
                    CodigoPostal="3700-501",

                },
                     new Clientes
                     {
                    //Cliente_Id="",
                    Nome="Nelson Ramos",
                    DataNascimento=new DateTime(1945,07,10),
                    Nif=927822662,
                    Morada="R Indústria Porta 56",
                    Telemovel=929455563,
                    Email="nelsonramos@outlook.com",
                    CodigoPostal="3220-066",

                },
                     new Clientes
                     {
                    //Cliente_Id="",
                    Nome="Danilo Pires",
                    DataNascimento=new DateTime(1999,06,26),
                    Nif=925387029,
                    Morada="Rua Jorge Sena 99",
                    Telemovel=965559604,
                    Email="danilopires@live.com",
                    CodigoPostal="2650-499",
                },

                     new Clientes
                     {
                    //Cliente_Id="",
                    Nome="Mônica Torres",
                    DataNascimento=new DateTime(197,02,05),
                    Nif=922534195,
                    Morada="Avenida Guerra Junqueiro 114",
                    Telemovel=921555922,
                    Email="minicatorrees@gmail.com",
                    CodigoPostal="2610-116",
                },

                     new Clientes
                     {
                    //Cliente_Id="",
                    Nome="Daniela Mata",
                    DataNascimento=new DateTime(1974,03,13),
                    Nif=925581543,
                    Morada="R Portela 64",
                    Telemovel=915551704,
                    Email="daielamatta@gmail.com",
                    CodigoPostal="3550-171",
                },

                     new Clientes
                     {
                    //Cliente_Id="",
                    Nome="Virgílio Abreu",
                    DataNascimento=new DateTime(1987,04,16),
                    Nif=928360508,
                    Morada="R Padre João A L Ribeiro 88",
                    Telemovel=915559352,
                    Email="virgabremu@outlook.com",
                    CodigoPostal="3440-376",
                },

                     new Clientes
                     {
                    //Cliente_Id="",
                    Nome="Martim Moniz",
                    DataNascimento=new DateTime(1984,08,15),
                    Nif=927251038,
                    Morada="R Poeta João Ruiz 90",
                    Telemovel=929455556,
                    Email="martir_moniz@live.com",
                    CodigoPostal="6230-691",
                },

            });
            bd.SaveChanges();

        }
    }
}
