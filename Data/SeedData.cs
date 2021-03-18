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

        private const string NOME_UTILIZADOR_ADMIN_PADRAO = "admin@RDtelecom.com";
        private const string PASSWORD_UTILIZADOR_ADMIN_PADRAO = "Secret123$";
        private const string NOME_UTILIZADOR_CLIENTE_FICTICIO = "cliente@gmail.com";

        private const string ROLE_ADIMINISTRADOR = "Administrador";
        private const string ROLE_CLIENTE = "Cliente";
        private const string ROLE_OPERADOR = "Operador";

        internal static void PreencheDados(Projeto_Lab_WebContext bd)
        {
            InserePromocoes(bd);
            InsereTiposServicos(bd);
            InsereServicos(bd);
            InsereUtilizadores(bd);
            InserePacotes(bd);
            InsereServicosPacotes(bd);
            InserePromocoesPacotes(bd);
            InsereDistritos(bd);
            //InsereContratos(bd);
            //InsereTiposClientes(bd);
            //InsereRoles(bd);

        }
        private static void InsereUtilizadores(Projeto_Lab_WebContext bd)
        {
            GaranteUtilizadores(bd, "Admin", "251286223", new DateTime(1998, 09, 29), "Rua das Flores Verde", "925258739", "admin@RDtelecom.com", "6300-706", "Administrador", false, 1);
            GaranteUtilizadores(bd, "Operador", "251223322", new DateTime(1998, 09, 29), "Rua das Flores", "925258737", "operador@RDtelecom.com", "6300-706", "Operador", false, 2);
            GaranteUtilizadores(bd, "Cliente", "223123321", new DateTime(1998, 09, 29), "Rua das Flores", "925258737", "cliente@RDtelecom.com", "6300-706", "Cliente", false, 3);

            GaranteUtilizadores(bd, "Nuno Forte", "255255212", new DateTime(1998, 09, 29), "Rua das Flores", "925258737", "nuno_rpf@RDtelecom.com", "6300-706", "Operador", false, 4);
            GaranteUtilizadores(bd, "João Matos", "224443321", new DateTime(1970, 04, 21), "Rua da Maurícia Aradas", "965111755", "joao_matos@RDtelecom.com", "3810-433", "Operador", false, 5);
            GaranteUtilizadores(bd, "Maria de Fátima", "256678987", new DateTime(1963, 02, 02), "Rua da Prata", "927895737", "m.fatima@RDtelecom.com", "1149-005", "Operador", false, 6);
            GaranteUtilizadores(bd, "Joana Pereira", "233122321", new DateTime(1992, 11, 29), "Avenida Nossa Senhora de Fátima", "91746251", "J_pereira@RDtelecom.com", "2414-003", "Operador", false, 7);
            GaranteUtilizadores(bd, "Justina Paulo", "221223224", new DateTime(1978, 07, 17), "Rua de São Gonçalo", "912211797", "justina_paulo@RDtelecom.com", "4814-508", "Operador", false, 8);
            GaranteUtilizadores(bd, "Inês Reis", "234231111", new DateTime(1998, 03, 07), "Rua Quinta do Fojo Canidelo", "969193547", "reis_ines@RDtelecom.com", "4400-658", "Operador", false, 9);
            GaranteUtilizadores(bd, "Luís Madeira", "223777543", new DateTime(1989, 10, 29), "Rua do Campo Alegre", "915111852", "luis.madeira@RDtelecom.com", "4169-008", "Operador", false, 10);
            GaranteUtilizadores(bd, "Paula Melo", "352111555", new DateTime(1984, 12, 29), "Canada dos Melancólicos", "925897737", "melo.paula@RDtelecom.com", "9701-870", "Operador", false, 11);
            GaranteUtilizadores(bd, "Paulo Mota", "332331345", new DateTime(2000, 06, 06), "Rua General Humberto Delgado", "969687125", "paulo_mota@RDtelecom.com", "1499-004", "Operador", false, 12);
            GaranteUtilizadores(bd, "Marta Machado", "201101321", new DateTime(2000, 08, 01), "Rua Central Mesura", "962154873", "m.machado@RDtelecom.com", "3049-002", "Operador", false, 13);
            //--------------------------AVEIRO------------------
            GaranteUtilizadores(bd, "Eduardo Pires", "286714957", new DateTime(2000, 01, 19), "Sargento Mor", "929154121", "eduardo.pires@RDtelecom.com", "3020-740", "Operador", false, 1);
            GaranteUtilizadores(bd, "Glória da Ascenção", "218120460", new DateTime(1988, 09, 21), "Rua Fernando Caldeira", "933254121", "gloria.ascencao@RDtelecom.com", "3754-501", "Operador", false, 1);
            GaranteUtilizadores(bd, "Maria Aparecida", "206602448", new DateTime(1977, 10, 01), "Rua Doutor Tomás Aquino", "929154121", "maria.aparecida@RDtelecom.com", "3800-523", "Operador", false, 1);
            GaranteUtilizadores(bd, "Bernardo Ribeiro", "292565798", new DateTime(1969, 03, 25), "Avenida Manuel Álvaro Lopes Pereira", "927854121", "bernado.ribeiro@RDtelecom.com", "3800-625", "Operador", false, 1);
            GaranteUtilizadores(bd, "Amadeu Almeida", "292565798", new DateTime(1979, 07, 16), "Avenida do Doutor Lourenço Peixinho", "929154199", "amadeu.almeida@RDtelecom.com", "3804-501", "Operador", false, 1);
            GaranteUtilizadores(bd, "José Socrates", "250559102", new DateTime(1958, 05, 05), "Viela da Capela", "929154121", "jose.socrates@RDtelecom.com", "3810-002", "Operador", false, 1);
            GaranteUtilizadores(bd, "Ana Brito", "275433641", new DateTime(2000, 09, 04), "Rua do Jardim", "929154121", "ana.brito@RDtelecom.com", "3054-001", "Operador", false, 1);
            GaranteUtilizadores(bd, "Luís Neto", "142518093", new DateTime(1985, 04, 04), "Avenida Comendador Augusto Martins Pereira", "929154121", "luis.neto@RDtelecom.com", "3744-002", "Operador", false, 1);
            GaranteUtilizadores(bd, "Freitas do Mondego", "172501482", new DateTime(1975, 02, 08), "Rua do Murtório Rochico ", "929154121", "freitas.mondego@RDtelecom.com", "3865-299", "Operador", false, 1);
            GaranteUtilizadores(bd, "João Cardoso", "265371988", new DateTime(1958, 12, 27), "Travessa da Lomba", "929154121", "joao.cardoso@RDtelecom.com", "3865-003", "Operador", false, 1);
            GaranteUtilizadores(bd, "Rita de Brandão", "244225834", new DateTime(1956, 08, 27), "Largo 5 de Outubro Jardim dos Campos Pares", "929154121", "rita.brandao@RDtelecom.com", "3880-006", "Operador", false, 1);



            GaranteUtilizadores(bd, "Patrícia Gomes", "248858939", new DateTime(1999, 07, 01), "Rua do Norte", "929154121", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 6);
            GaranteUtilizadores(bd, "Marlene Santos", "123456789", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "933254121", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 6);
            GaranteUtilizadores(bd, "João Ferreira", "233333231", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "929154121", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 6);
            GaranteUtilizadores(bd, "Tânia Sousa", "233259627", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "927854121", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 6);
            GaranteUtilizadores(bd, "Rute Martins", "221639896", new DateTime(1979, 10, 30), "Cruz de Ferro", "929154199", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 6);
            GaranteUtilizadores(bd, "Paulo Pedra", "215922158", new DateTime(1999, 07, 01), "Rua do Norte", "929154121", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 6);
            GaranteUtilizadores(bd, "Helder Copeto", "209281472", new DateTime(1999, 07, 01), "Rua do Norte", "929154121", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 6);
            GaranteUtilizadores(bd, "Miriam Falcão", "218052421", new DateTime(2000, 01, 01), "Vale Derradeiro", "929154121", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 6);
            GaranteUtilizadores(bd, "Célia Tomate", "224046284", new DateTime(1980, 09, 11), "Seladinhas", "929154121", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 6);
            GaranteUtilizadores(bd, "Tadeu Leão", "294178775", new DateTime(1975, 02, 08), "Flor da Rosa", "929154121", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 6);
            GaranteUtilizadores(bd, "Harley Guerra", "230936679", new DateTime(1955, 12, 24), "Beco da Alegria", "929154121", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 6);
            GaranteUtilizadores(bd, "Afonso Freira", "271671130", new DateTime(1956, 12, 05), "Beco das Cruzes", "929154121", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 6);
            GaranteUtilizadores(bd, "Paulo Pimentel", "234018283", new DateTime(2001, 12, 02), "Estrada Marmeleiros Ímpares", "966632147", "paulo.pimentel@RDtelecom.com", "9050-216", "Operador", false, 20);
            GaranteUtilizadores(bd, "Maria Silva", "293714630", new DateTime(2001, 09, 09), "Vinha Brava", "960201333", "maria.silva@RDtelecom.com", "9701-872", "Operador", false, 19);





            GaranteUtilizadores(bd, "Pedro Machado", "212545585", new DateTime(1971, 07, 14), "Colónia Agrícola Casal 63", "935559453", "pedromachado@gmail.com", "3870-358", "Cliente", false, 14);
            GaranteUtilizadores(bd, "Joaquim Mendez", "532344565", new DateTime(1987, 12, 24), "R Indústria Porta 47", "915556899", "joaquimmendez@outlook.com", "3300-040", "Cliente", false, 15);
            GaranteUtilizadores(bd, "Sandra Vieira", "221344545", new DateTime(1977, 02, 23), "R Poeta João Ruiz 6", "929355531", "sandravieira@gmail.com", "6230-355", "Cliente", false, 16);
            GaranteUtilizadores(bd, "Sara Siqueira", "543333222", new DateTime(1977, 01, 22), "R Doutor Alfredo Freitas 108", "915551820", "sarasiqueiraa@gmail.com", "3700-501", "Cliente", false, 17);
            GaranteUtilizadores(bd, "Nelson Ramos", "321123456", new DateTime(1945, 07, 10), "R Indústria Porta 56", "929455563", "nelsonramos@outlook.com", "3220-066", "Cliente", false, 18);
            GaranteUtilizadores(bd, "Danilo Pires", "332223455", new DateTime(1999, 06, 26), "Rua Jorge Sena 99", "965559604", "danilopires@live.com", "2650-499", "Cliente", false, 19);
            GaranteUtilizadores(bd, "Mônica Torres", "344321789", new DateTime(1976, 02, 05), "Avenida Guerra Junqueiro 114", "921555922", "monicatorres@gmail.com", "2610-116", "Cliente", false, 20);
            GaranteUtilizadores(bd, "Daniela Mata", "698767555", new DateTime(1974, 03, 13), "R Portela 64", "915551704", "daielamata@gmail.com", "3550-171", "Cliente", false, 3);
            GaranteUtilizadores(bd, "Virgílio Abreu", "678567454", new DateTime(1987, 04, 16), "R Padre João A L Ribeiro 88", "915559352", "virgilio_abreu@outlook.com", "3440-376", "Cliente", false, 2);
            GaranteUtilizadores(bd, "Amável Pinto", "259149179", new DateTime(1966, 08, 27), "Rua da Mãe de Água", "910070026", "pinto_amavel@outlook.com", "4805-276", "Cliente", false, 1);
            GaranteUtilizadores(bd, "António Pechincha", "214118959", new DateTime(2000, 07, 19), "Rua das Alminhas", "912333480", "antonio.pechincha@outlook.com", "4815-159", "Cliente", false, 21);
            GaranteUtilizadores(bd, "José Machuca", "272659886", new DateTime(1966, 04, 15), "Além do Rio", "966654789", "jose.machuca@live.com", "4860-121", "Cliente", false, 3);
            GaranteUtilizadores(bd, "Luís Cabrita", "296644307", new DateTime(1974, 10, 03), "Rua de Cartas", "961728395", "cabrita.luis@live.com", "4765-417", "Cliente", false, 3);
            GaranteUtilizadores(bd, "Miguel do Amaral", "219048401", new DateTime(1955, 07, 09), "Pedra Chã", "929229647", "miguel.amaral@gmail.com", "4850-144", "Cliente", false, 3);
            GaranteUtilizadores(bd, "Carla Mamona", "221888012", new DateTime(1967, 01, 01), "Avenida Conde de Margaride", "969171654", "carla.mamona@live.com", "4839-001", "Cliente", false, 3);
            GaranteUtilizadores(bd, "Celeste Pires", "270559299", new DateTime(1980, 05, 01), "Rua do Picôto São Paio", "917854369", "celeste.pires@hotmail.com", "4800-006", "Cliente", false, 3);
            GaranteUtilizadores(bd, "Filipe Gil", "298022699", new DateTime(1928, 05, 03), "Avenida 9 de Julho", "929455556", "filipe_gil@gmail.com", "4760-831", "Cliente", false, 3);
            GaranteUtilizadores(bd, "Vitória Rodrigues", "293958033", new DateTime(1994, 01, 10), "R Poeta João Ruiz 90", "931478962", "vitoria_rodrigues@gmail.com", "6230-691", "Cliente", false, 3);
            GaranteUtilizadores(bd, "André Pereira", "204357039", new DateTime(1969, 06, 09), "Travessa da Boca Antas", "919474456", "andre_pereira@live.com", "4760-870", "Cliente", false, 3);
            GaranteUtilizadores(bd, "Pedro Guedes", "230045359", new DateTime(1955, 07, 09), "Rua Mata da Naia Gondizalves", "967455521", "pedro.l.guedes@gmail.com", "4700-183", "Cliente", false, 3);
            GaranteUtilizadores(bd, "Luísa Lourenço", "253438691", new DateTime(1974, 11, 24), "Rua do Muro Dume", "912675574", "l.loureco@hotmail.com", "4700-397 ", "Cliente", false, 3);
            GaranteUtilizadores(bd, "Suzete Farinha", "249712768", new DateTime(1930, 03, 15), "Cangosta do Pulo Dume", "921257556", "suzete.farinha@gmail.com", "4700-007", "Cliente", false, 3);
            GaranteUtilizadores(bd, "Manuel dos Descobrimentos", "248776304", new DateTime(2002, 03, 15), "Azinhaga Casa Branca", "919154001", "manuel.descobrimentos@gmail.com", "9004-543", "Cliente", false, 19);
            GaranteUtilizadores(bd, "Gonçalo Velho ", "202733122", new DateTime(2002, 05, 15), "Largo dos Remédios", "968523147", "velho.goncalo@gmail.com", "9701-855", "Cliente", false, 20);

        }

        private static Utilizadores GaranteUtilizadores(Projeto_Lab_WebContext bd, string nome, string nif, DateTime datanascimento,
            string morada, string telemovel, string email, string codigopostal, string role, bool inactivo, int distrito)
        {
            Utilizadores utilizadores = bd.Utilizadores.FirstOrDefault(c => c.Nome == nome);
            if (utilizadores == null)
            {
                utilizadores = new Utilizadores { Nome = nome, Nif = nif, DataNascimento = datanascimento, Morada = morada, Telemovel = telemovel, Email = email, CodigoPostal = codigopostal, Role = role, Inactivo = inactivo, DistritosId = distrito };
                bd.Utilizadores.Add(utilizadores);
                bd.SaveChanges();
            }

            return utilizadores;
        }

        internal static async Task InsereUtilizadoresFicticiosAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            IdentityUser admin = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "admin@RDtelecom.com", "Secret123$");
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, admin, ROLE_ADIMINISTRADOR);

            IdentityUser operador = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "operador@RDtelecom.com", "Secret123$");
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, operador, ROLE_OPERADOR);

            IdentityUser cliente = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "cliente@RDtelecom.com", "Secret123$");
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, cliente, ROLE_CLIENTE);
        }

        //private static void InsereRoles(Projeto_Lab_WebContext bd)
        //{
        //    if (bd.Roles.Any()) return;

        //    bd.Roles.AddRange(new Roles[] {
        //        new Roles
        //        {
        //            Roles_Nome="Administrador",
        //        },

        //         new Roles
        //        {
        //            Roles_Nome="Operador",
        //        },
        //    });

        //}


        private static void InserePromocoes(Projeto_Lab_WebContext bd)
        {
            GaranteExistenciaPromocoes(bd, "PascoaS", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes pequenos", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 2, 99m, false, 1);
            GaranteExistenciaPromocoes(bd, "PascoaM", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes médios", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 3, 99m, false, 2);
            GaranteExistenciaPromocoes(bd, "PascoaL", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes grandes", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 4, 99m, false, 4);
            GaranteExistenciaPromocoes(bd, "VerãoS", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes pequenos", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 1, 99m, false, 5);
            GaranteExistenciaPromocoes(bd, "VerãoM", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes médio", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 2, 59m, false, 3);
            GaranteExistenciaPromocoes(bd, "VerãoL", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes grandes", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 3, 99m, false, 9);
            GaranteExistenciaPromocoes(bd, "NatalS", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes pequenos", new DateTime(2021, 12, 01), new DateTime(2022, 01, 31), 3, 99m, false, 7);
            GaranteExistenciaPromocoes(bd, "NatalM", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes médios", new DateTime(2021, 12, 01), new DateTime(2022, 01, 31), 4, 99m, false, 19);
            GaranteExistenciaPromocoes(bd, "NatalL", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes grandes", new DateTime(2021, 12, 01), new DateTime(2022, 01, 31), 5, 99m, false, 5);

        }

        private static Promocoes GaranteExistenciaPromocoes(Projeto_Lab_WebContext bd, string nome, string descricao, DateTime dataInicio, DateTime datafim, int promocaoDesc, decimal v, bool inactivo, int distritos)
        {
            Promocoes promocoes = bd.Promocoes.FirstOrDefault(c => c.Nome == nome);
            if (promocoes == null)
            {
                promocoes = new Promocoes { Nome = nome, Descricao = descricao, DataInicio = dataInicio, DataFim = datafim, PromocaoDesc = promocaoDesc, Inactivo = inactivo, DistritosId = distritos };
                bd.Promocoes.Add(promocoes);
                bd.SaveChanges();
            }
            return (promocoes);
        }


        //-------------------SERVICOS--------------------------
        private static void InsereServicos(Projeto_Lab_WebContext bd)
        {
            GaranteNulos(bd);
            GaranteExistenciaServico(bd, "Canais Fibra", "Temos vários Pacotes á sua escolha", 3, false);
            GaranteExistenciaServico(bd, "Telémovel Pré-Pago e Pós-Pago", "Temos vários Pacotes á sua escolha", 2, false);
            GaranteExistenciaServico(bd, "Internet Fixa", "A melhor internet para si , disponível em varios pacotes.", 1, false);
            GaranteExistenciaServico(bd, "Internet Móvel", "Vários Pacotes com vários plafonds para ti", 5, false);
            GaranteExistenciaServico(bd, "Internet 100/100mbps", "A velocidade da internet é medida e certificada no dia da instalação.", 1, false);
            GaranteExistenciaServico(bd, "Internet 1.000/400 Mbps", "Somos a única operadora a nível mundial com uma rede própria de circuitos de internet internacionais, garantindo sempre a largura de banda necessária.", 1, false);
            GaranteExistenciaServico(bd, "1 cartão, 500 minutos + 500 SMS por cartão", "Tenha uma experiência de voz sem falhas, com qualidade superior nas suas chamadas.", 2, false);
            GaranteExistenciaServico(bd, "1 cartão, 3.500 minutos + 3.500 SMS", "Tenha uma experiência de voz sem falhas, com qualidade superior nas suas chamadas.", 2, false);
            GaranteExistenciaServico(bd, "Pack standard 150 canais", "O melhor entretenimento num só lugar.", 3, false);
            GaranteExistenciaServico(bd, "Pack standard 200 canais", "A televisão do futuro em sua casa.", 3, false);
            GaranteExistenciaServico(bd, "Chamadas telefónicas World", "Redes fixas nacionais 24h + 50 destinos internacionais (noite, 1.000 min)", 4, false);
            GaranteExistenciaServico(bd, "Chamadas telefónicas Light", "Redes fixas nacionais 24h + 20 destinos internacionais (noite, 100 min)", 4, false);
            GaranteExistenciaServico(bd, "Internet móvel 500MB", "Ativa no teu smartphone, a qualquer hora e em qualquer lugar 500 MB de dados", 5, false);
            GaranteExistenciaServico(bd, "Internet móvel 1GB", "Ativa no teu smartphone, a qualquer hora e em qualquer lugar 1 GB de dados", 5, false);
            GaranteExistenciaServico(bd, "teste", "teste", 5, true);
        }
        private static Servicos GaranteExistenciaServico(Projeto_Lab_WebContext bd, string nome, string descricao, int tiposervicoId, bool inactivo)
        {
            Servicos servicos = bd.Servicos.FirstOrDefault(c => c.Nome == nome);
            if (servicos == null)
            {
                servicos = new Servicos { Nome = nome, Descricao = descricao, TipoServicoId = tiposervicoId, Inactivo = inactivo };
                bd.Servicos.Add(servicos);
                bd.SaveChanges();
            }
            return servicos;
        }

        private static void GaranteNulos(Projeto_Lab_WebContext bd)
        {
            if (bd.Servicos.Any()) return;
            bd.Servicos.AddRange(new Servicos[] {
                  new Servicos
                     {
                    Nome="---",
                    TipoServicoId = 1,
                    Inactivo = false

                    },

                  new Servicos
                     {
                    Nome="---",
                    TipoServicoId = 2,
                    Inactivo = false

                    },

                   new Servicos
                     {
                    Nome="---",
                    TipoServicoId = 3,
                    Inactivo = false

                    },

                    new Servicos
                     {
                    Nome="---",
                    TipoServicoId = 4,
                    Inactivo = false

                    },

                     new Servicos
                     {
                    Nome="---",
                    TipoServicoId = 5,
                    Inactivo = false

                    },
            });
        }


        private static void InsereServicosPacotes(Projeto_Lab_WebContext bd)
        {
            if (bd.ServicosPacotes.Any()) return;


            var pacoteRD4 = GarantePacotes(bd, "Pacote RD4", 55, "O pacote RD4 destacou-se por apresentar a melhor relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade", false, new DateTime(2021, 03, 01));
            var pacoteRD3 = GarantePacotes(bd, "Pacote RD3", 45, "O pacote RD3 destacou-se por apresentar a uma ótima relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade para quem não quer ter um telemóvel associado ao pacote.", false, new DateTime(2021, 03, 01));
            var pacoteRDGaming = GarantePacotes(bd, "Pacote RD - Gaming", 55, "A oferta Pacote RD - Gaming é ideal para", false, new DateTime(2021, 03, 01));
            var pacoteRDGPremium = GarantePacotes(bd, "Pacote RD - TV Premium + gaming", 65, "A oferta Pacote RD - TV Premium + gaming destacou - se na categoria de “Melhor pacote para Gaming” por apresentar a melhor relação ao nível do número de canais dedicado ao universo cinematográfico(canais base, exclusivos e premium) face ao custo mensal, bem como uma internet de alta velocidade para não haver falhas durante os jogos.", false, new DateTime(2021, 03, 01));
            var pacoteTvVoz = GarantePacotes(bd, "RD TV e Voz", 25, "Este Pacote RD TV e Voz é ideal para os clientes que querem ver televisão", false, new DateTime(2021, 03, 01));
            var pacoteRDFamiliar = GarantePacotes(bd, "RD Familiar", 45, "Pacote ideal para os momentos de lazer em família.", false, new DateTime(2021, 03, 01));

            var fibra = GaranteExistenciaServico(bd, "Canais Fibra", "Temos vários Pacotes á sua escolha", 3, false);
            var tlm = GaranteExistenciaServico(bd, "Telémovel Pré-Pago e Pós-Pago", "Temos vários Pacotes á sua escolha", 4, false);
            var internetfixa = GaranteExistenciaServico(bd, "Internet Fixa", "A melhor internet para si , disponível em varios pacotes.", 5, false);
            var internetmovel = GaranteExistenciaServico(bd, "Internet Móvel", "Vários Pacotes com vários plafonds para ti", 5, false);
            var internet100 = GaranteExistenciaServico(bd, "Internet 100/100mbps", "A velocidade da internet é medida e certificada no dia da instalação.", 5, false);
            var internet400 = GaranteExistenciaServico(bd, "Internet 1.000/400 Mbps", "Somos a única operadora a nível mundial com uma rede própria de circuitos de internet internacionais, garantindo sempre a largura de banda necessária.", 5, false);
            var tlm500 = GaranteExistenciaServico(bd, "1 cartão, 500 minutos + 500 SMS por cartão", "Tenha uma experiência de voz sem falhas, com qualidade superior nas suas chamadas.", 4, false);
            var tlm3500 = GaranteExistenciaServico(bd, "1 cartão, 3.500 minutos + 3.500 SMS", "Tenha uma experiência de voz sem falhas, com qualidade superior nas suas chamadas.", 4, false);
            var TV150 = GaranteExistenciaServico(bd, "Pack standard 150 canais", "O melhor entretenimento num só lugar.", 3, false);
            var TV200 = GaranteExistenciaServico(bd, "Pack standard 200 canais", "A televisão do futuro em sua casa.", 3, false);
            var tlfWorld = GaranteExistenciaServico(bd, "Chamadas telefónicas World", "Redes fixas nacionais 24h + 50 destinos internacionais (noite, 1.000 min)", 2, false);
            var tlfLight = GaranteExistenciaServico(bd, "Chamadas telefónicas Light", "Redes fixas nacionais 24h + 20 destinos internacionais (noite, 100 min)", 2, false);
            var intMovel500 = GaranteExistenciaServico(bd, "Internet móvel 500MB", "Ativa no teu smartphone, a qualquer hora e em qualquer lugar 500 MB de dados", 1, false);
            var intMovel1GB = GaranteExistenciaServico(bd, "Internet móvel 1GB", "Ativa no teu smartphone, a qualquer hora e em qualquer lugar 1 GB de dados", 1, false);



            bd.ServicosPacotes.AddRange(new ServicosPacotes[] {
                  new ServicosPacotes
                     {
                    PacoteId=pacoteRD4.PacoteId,
                    ServicoId=TV150.ServicoId,
                },

                  new ServicosPacotes
                     {
                    PacoteId=pacoteRD4.PacoteId,
                    ServicoId=internet100.ServicoId,
                },

                  new ServicosPacotes
                     {
                    PacoteId=pacoteRD4.PacoteId,
                    ServicoId=intMovel500.ServicoId,
                },

                  new ServicosPacotes
                     {
                    PacoteId=pacoteRD4.PacoteId,
                    ServicoId=tlm500.ServicoId,
                },

                   new ServicosPacotes
                     {
                    PacoteId=pacoteRD4.PacoteId,
                    ServicoId=tlfWorld.ServicoId,
                },

                   new ServicosPacotes
                     {
                    PacoteId=pacoteRD3.PacoteId,
                    ServicoId=TV150.ServicoId,
                },

                   new ServicosPacotes
                     {
                    PacoteId=pacoteRD3.PacoteId,
                    ServicoId=tlfWorld.ServicoId,
                },

                   new ServicosPacotes
                     {
                    PacoteId=pacoteRD3.PacoteId,
                    ServicoId=internet400.ServicoId,
                },

                   new ServicosPacotes
                     {
                    PacoteId=pacoteRDGaming.PacoteId,
                    ServicoId=TV150.ServicoId,
                },
                   new ServicosPacotes
                     {
                    PacoteId=pacoteRDGaming.PacoteId,
                    ServicoId=internet400.ServicoId,
                },
                     new ServicosPacotes
                     {
                    PacoteId=pacoteRDGaming.PacoteId,
                    ServicoId=tlfLight.ServicoId,
                },

                             new ServicosPacotes
                     {
                    PacoteId=pacoteRDGPremium.PacoteId,
                    ServicoId=TV150.ServicoId,
                },
                   new ServicosPacotes
                     {
                    PacoteId=pacoteRDGPremium.PacoteId,
                    ServicoId=internet400.ServicoId,
                },
                     new ServicosPacotes
                     {
                    PacoteId=pacoteRDGPremium.PacoteId,
                    ServicoId=tlfLight.ServicoId,
                },
                     new ServicosPacotes
                     {
                    PacoteId=pacoteRDGPremium.PacoteId,
                    ServicoId=internetmovel.ServicoId,
                },

                      new ServicosPacotes
                     {
                    PacoteId=pacoteTvVoz.PacoteId,
                    ServicoId=TV150.ServicoId,
                },
                      new ServicosPacotes
                     {
                    PacoteId=pacoteTvVoz.PacoteId,
                    ServicoId=tlfLight.ServicoId,
                },

                      new ServicosPacotes
                     {
                    PacoteId=pacoteRDFamiliar.PacoteId,
                    ServicoId=TV200.ServicoId,
                },
                      new ServicosPacotes
                     {
                    PacoteId=pacoteRDFamiliar.PacoteId,
                    ServicoId=internet400.ServicoId,
                },
                      new ServicosPacotes
                     {
                    PacoteId=pacoteRDFamiliar.PacoteId,
                    ServicoId=tlfWorld.ServicoId,
                },

                      new ServicosPacotes
                     {
                    PacoteId=pacoteRDFamiliar.PacoteId,
                    ServicoId=tlm3500.ServicoId,
                },

            });
            bd.SaveChanges();
        }

        private static void InserePacotes(Projeto_Lab_WebContext bd)
        {
            GarantePacotes(bd, "Pacote RD4", 55, "O pacote RD4 destacou-se por apresentar a melhor relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade", false, new DateTime(2021, 03, 01));
            GarantePacotes(bd, "Pacote RD3", 45, "O pacote RD3 destacou-se por apresentar a uma ótima relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade para quem não quer ter um telemóvel associado ao pacote.", false, new DateTime(2021, 03, 01));
            GarantePacotes(bd, "Pacote RD - Gaming", 55, "O pacote indicado para quem procura uma internet forte e estável. Sem LAG! Sem delay! Apenas, a melhor internet ao preço mais acessivel!", false, new DateTime(2021, 03, 01));
            GarantePacotes(bd, "Pacote RD - TV Premium", 65, "O pack Premium é o pacote mais completo que temos! Tendo mais de 180 canais disponiveis, velocidades de Download e Upload imabtíveis, chamadas fixas e para numeros estrangeiros sem custos associados e ainda até 4 cartões de telemovel associados que podem ter até 10GB de dados móveis cada!", false, new DateTime(2021, 03, 01));
            GarantePacotes(bd, "RD TV e Voz", 25, "Um pack simples seja para ter acesso aos nossos canais exclusivos ou beneficiar das nossas incriveis promoções em chamadas!", false, new DateTime(2021, 03, 01));
            GarantePacotes(bd, "RD Familiar", 45, "O pacote indicado para toda a familia! Desde uma variedade de canais, até à melhor velocidade de internet no mercado, até aos diferentes plafonds de telemovel que procura, este é o pacote ideal!", false, new DateTime(2021, 03, 01));
        }
        private static Pacotes GarantePacotes(Projeto_Lab_WebContext bd, string nome, decimal preco, string descricao, bool inactivo, DateTime dataInicio)
        {
            Pacotes pacotes = bd.Pacotes.FirstOrDefault(c => c.Nome == nome);
            if (pacotes == null)
            {
                pacotes = new Pacotes
                {
                    Nome = nome,
                    Descricao = descricao,
                    Preco = preco,
                    Inactivo = inactivo,
                    DataCriacao = dataInicio,
                    DataInactivo = new DateTime(2020, 12, 30),
                    Imagem = new byte[0],

                };
                bd.Pacotes.Add(pacotes);
                bd.SaveChanges();
            }
            return pacotes;
        }

        //-------------------TIPOS DE SERVIÇOS--------------------------
        private static void InsereTiposServicos(Projeto_Lab_WebContext bd)
        {
            GaranteExistenciaTiposServicos(bd, "Internet", "fa-wifi black");
            GaranteExistenciaTiposServicos(bd, "Telemóvel", "fas fa-mobile-alt");
            GaranteExistenciaTiposServicos(bd, "Televisão", "fas fa-tv");
            GaranteExistenciaTiposServicos(bd, "Telefone Fixo", "fas fa-phone-alt");
            GaranteExistenciaTiposServicos(bd, "Internet Móvel", "fas fa - paper - plane");
        }
        internal static void GaranteExistenciaTiposServicos(Projeto_Lab_WebContext bd, string nome, string icone)
        {
            Tipos_Sevicos tipos_Sevicos = bd.TiposServicos.FirstOrDefault(s => s.Nome == nome);
            if (tipos_Sevicos == null)
            {
                tipos_Sevicos = new Tipos_Sevicos { Nome = nome, Icone = icone };
                bd.TiposServicos.Add(tipos_Sevicos);
                bd.SaveChanges();
            }
        }


        //-------------------DISTRITOS-----------------------------------


        private static void InsereDistritos(Projeto_Lab_WebContext bd)
        {
            GaranteDistritos(bd, 1, "Aveiro");
            GaranteDistritos(bd, 2, "Beja");
            GaranteDistritos(bd, 3, "Braga");
            GaranteDistritos(bd, 4, "Bragança");
            GaranteDistritos(bd, 5, "Castelo Branco");
            GaranteDistritos(bd, 6, "Coimbra");
            GaranteDistritos(bd, 7, "Évora");
            GaranteDistritos(bd, 8, "Faro");
            GaranteDistritos(bd, 9, "Guarda");
            GaranteDistritos(bd, 10, "Leiria");
            GaranteDistritos(bd, 11, "Lisboa");
            GaranteDistritos(bd, 12, "Portalegre");
            GaranteDistritos(bd, 13, "Porto");
            GaranteDistritos(bd, 14, "Santarém");
            GaranteDistritos(bd, 15, "Setúbal");
            GaranteDistritos(bd, 16, "Viana do Castelo");
            GaranteDistritos(bd, 17, "Vila Real");
            GaranteDistritos(bd, 18, "Viseu");
            GaranteDistritos(bd, 19, "Açores");
            GaranteDistritos(bd, 20, "Madeira");
        }

        private static Distritos GaranteDistritos(Projeto_Lab_WebContext bd, int distritoId, string nome)
        {
            Distritos distritos = bd.Distritos.FirstOrDefault(e => e.Nome == nome);
            if (distritos == null)
            {
                distritos = new Distritos()
                {
                    DistritosId = distritoId,
                    Nome = nome
                };
                bd.Distritos.Add(distritos);
                bd.SaveChanges();
            }
            return distritos;

        }

        //-------------------TIPOS DE CLIENTES--------------------------

        private static void InsereTiposClientes(Projeto_Lab_WebContext bd)

        {
            GaranteExistenciaTiposClientes(bd, "Particular");
            GaranteExistenciaTiposClientes(bd, "Empresa");
        }
        internal static void GaranteExistenciaTiposClientes(Projeto_Lab_WebContext bd, string nome)
        {
            Tipos_Clientes tipos_Clientes = bd.Tipos_Clientes.FirstOrDefault(c => c.Nome == nome);
            if (tipos_Clientes == null)
            {
                tipos_Clientes = new Tipos_Clientes { Nome = nome };
                bd.Tipos_Clientes.Add(tipos_Clientes);
                bd.SaveChanges();
            }
        }

        //---------------------------------PromocoesPacotes------------------------------
        private static void InserePromocoesPacotes(Projeto_Lab_WebContext bd)
        {

            var pacoteRD4 = GarantePacotes(bd, "Pacote RD4", 55, "O pacote RD4 destacou-se por apresentar a melhor relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade", false, new DateTime(2021, 03, 01));
            var pacoteRD3 = GarantePacotes(bd, "Pacote RD3", 45, "O pacote RD3 destacou-se por apresentar a uma ótima relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade para quem não quer ter um telemóvel associado ao pacote.", false, new DateTime(2021, 03, 01));
            var pacoteRDGaming = GarantePacotes(bd, "Pacote RD - Gaming", 55, "A oferta Pacote RD - Gaming é ideal para", false, new DateTime(2021, 03, 01));
            var pacoteRDGPremium = GarantePacotes(bd, "Pacote RD - TV Premium + gaming", 65, "A oferta Pacote RD - TV Premium + gaming destacou - se na categoria de “Melhor pacote para Gaming” por apresentar a melhor relação ao nível do número de canais dedicado ao universo cinematográfico(canais base, exclusivos e premium) face ao custo mensal, bem como uma internet de alta velocidade para não haver falhas durante os jogos.", false, new DateTime(2021, 03, 01));
            var pacoteTvVoz = GarantePacotes(bd, "RD TV e Voz", 25, "Este Pacote RD TV e Voz é ideal para os clientes que querem ver televisão", false, new DateTime(2021, 03, 01));
            var pacoteRDFamiliar = GarantePacotes(bd, "RD Familiar", 45, "Pacote ideal para os momentos de lazer em família.", false, new DateTime(2021, 03, 01));

            var pascoaS = GaranteExistenciaPromocoes(bd, "PascoaS", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes pequenos", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 2, 99m, false, 1);
            var pascoaM = GaranteExistenciaPromocoes(bd, "PascoaM", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes médios", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 3, 99m, false, 2);
            var pascoaL = GaranteExistenciaPromocoes(bd, "PascoaL", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes grandes", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 4, 99m, false, 4);
            var VeraoS = GaranteExistenciaPromocoes(bd, "VerãoS", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes pequenos", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 1, 99m, false, 5);
            var VeraoM = GaranteExistenciaPromocoes(bd, "VerãoM", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes médio", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 2, 59m, false, 3);
            var VeraoL = GaranteExistenciaPromocoes(bd, "VerãoL", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes grandes", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 3, 99m, false, 9);
            var NatalS = GaranteExistenciaPromocoes(bd, "NatalS", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes pequenos", new DateTime(2021, 12, 01), new DateTime(2022, 01, 31), 3, 99m, false, 7);
            var NatalM = GaranteExistenciaPromocoes(bd, "NatalM", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes médios", new DateTime(2021, 12, 01), new DateTime(2022, 01, 31), 4, 99m, false, 19);
            var NatalL = GaranteExistenciaPromocoes(bd, "NatalL", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes grandes", new DateTime(2021, 12, 01), new DateTime(2022, 01, 31), 5, 99m, false, 5);


            if (bd.PromocoesPacotes.Any()) return;
            bd.PromocoesPacotes.AddRange(new PromocoesPacotes[]
            {
                new PromocoesPacotes
                {
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId= pascoaM.PromocoesId,
                },

                new PromocoesPacotes
                {
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId= VeraoM.PromocoesId,
                },

                  new PromocoesPacotes
                {
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId= NatalM.PromocoesId,
                },
                        new PromocoesPacotes
                {
                    PacoteId = pacoteRD3.PacoteId,
                    PromocoesId= pascoaM.PromocoesId,
                },

                new PromocoesPacotes
                {
                    PacoteId = pacoteRD3.PacoteId,
                    PromocoesId= VeraoM.PromocoesId,
                },

                new PromocoesPacotes
                {
                    PacoteId = pacoteRD3.PacoteId,
                    PromocoesId= NatalM.PromocoesId,
                },

                new PromocoesPacotes
                {
                    PacoteId = pacoteRDGaming.PacoteId,
                    PromocoesId= pascoaM.PromocoesId,
                },

                new PromocoesPacotes
                {
                    PacoteId = pacoteRDGaming.PacoteId,
                    PromocoesId= VeraoM.PromocoesId,
                },

                 new PromocoesPacotes
                {
                    PacoteId = pacoteRDGaming.PacoteId,
                    PromocoesId= NatalM.PromocoesId,
                },

                new PromocoesPacotes
                {
                    PacoteId = pacoteRDGPremium.PacoteId,
                    PromocoesId= NatalL.PromocoesId,
                },

                new PromocoesPacotes
                {
                    PacoteId = pacoteRDGPremium.PacoteId,
                    PromocoesId= VeraoL.PromocoesId,
                },

                new PromocoesPacotes
                {
                    PacoteId = pacoteRDGPremium.PacoteId,
                    PromocoesId= pascoaL.PromocoesId,
                },

                new PromocoesPacotes
                {
                    PacoteId = pacoteTvVoz.PacoteId,
                    PromocoesId= pascoaS.PromocoesId,
                },


                new PromocoesPacotes
                {
                    PacoteId = pacoteTvVoz.PacoteId,
                    PromocoesId= VeraoS.PromocoesId,
                },


                new PromocoesPacotes
                {
                    PacoteId = pacoteTvVoz.PacoteId,
                    PromocoesId= NatalS.PromocoesId,
                },


                new PromocoesPacotes
                {
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId= NatalL.PromocoesId,
                },


                new PromocoesPacotes
                {
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId= pascoaL.PromocoesId,
                },


                new PromocoesPacotes
                {
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId= VeraoS.PromocoesId,
                },

            });
            bd.SaveChanges();
        }


        private static void InsereContratos(Projeto_Lab_WebContext bd)
        {
            var pedro = GaranteUtilizadores(bd, "Pedro Machado", "212545585", new DateTime(1971, 07, 14), "Colónia Agrícola Casal 63", "935559453", "pedromachado@gmail.com", "3870-358", "Cliente", false, 14);
            var joaquim = GaranteUtilizadores(bd, "Joaquim Mendez", "532344565", new DateTime(1987, 12, 24), "R Indústria Porta 47", "915556899", "joaquimmendez@outlook.com", "3300-040", "Cliente", false, 15);
            var sandra = GaranteUtilizadores(bd, "Sandra Vieira", "221344545", new DateTime(1977, 02, 23), "R Poeta João Ruiz 6", "929355531", "sandravieira@gmail.com", "6230-355", "Cliente", false, 16);
            var sara = GaranteUtilizadores(bd, "Sara Siqueira", "543333222", new DateTime(1977, 01, 22), "R Doutor Alfredo Freitas 108", "915551820", "sarasiqueiraa@gmail.com", "3700-501", "Cliente", false, 17);
            var nelson = GaranteUtilizadores(bd, "Nelson Ramos", "321123456", new DateTime(1945, 07, 10), "R Indústria Porta 56", "929455563", "nelsonramos@outlook.com", "3220-066", "Cliente", false, 18);
            var danilo = GaranteUtilizadores(bd, "Danilo Pires", "332223455", new DateTime(1999, 06, 26), "Rua Jorge Sena 99", "965559604", "danilopires@live.com", "2650-499", "Cliente", false, 19);
            var monica = GaranteUtilizadores(bd, "Mônica Torres", "344321789", new DateTime(197, 02, 05), "Avenida Guerra Junqueiro 114", "921555922", "monicatorres@gmail.com", "2610-116", "Cliente", false, 20);
            var daniela = GaranteUtilizadores(bd, "Daniela Mata", "698767555", new DateTime(1974, 03, 13), "R Portela 64", "915551704", "daielamata@gmail.com", "3550-171", "Cliente", false, 3);
            var virgilio = GaranteUtilizadores(bd, "Virgílio Abreu", "678567454", new DateTime(1987, 04, 16), "R Padre João A L Ribeiro 88", "915559352", "virgilio_abreu@outlook.com", "3440-376", "Cliente", false, 2);
            var martim = GaranteUtilizadores(bd, "Martim Moniz", "612345432", new DateTime(1984, 08, 15), "R Poeta João Ruiz 90", "929455556", "martim_moniz@live.com", "6230-691", "Cliente", false, 1);

            var operador1 = GaranteUtilizadores(bd, "Nuno Forte", "255255212", new DateTime(1998, 09, 29), "Rua das Flores", "925258737", "nuno_rpf@RDtelecom.com", "6300-706", "Operador", false, 4);
            var operador2 = GaranteUtilizadores(bd, "João Matos", "224443321", new DateTime(1970, 04, 21), "Rua da Maurícia Aradas", "965111755", "joao_matos@RDtelecom.com", "3810-433", "Operador", false, 5);
            var operador3 = GaranteUtilizadores(bd, "Maria de Fátima", "256678987", new DateTime(1963, 02, 02), "Rua da Prata", "927895737", "m.fatima@RDtelecom.com", "1149-005", "Operador", false, 6);

            var pacoteRD4 = GarantePacotes(bd, "Pacote RD4", 55, "O pacote RD4 destacou-se por apresentar a melhor relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade", false, new DateTime(2021, 03, 01));
            var pacoteRD3 = GarantePacotes(bd, "Pacote RD3", 45, "O pacote RD3 destacou-se por apresentar a uma ótima relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade para quem não quer ter um telemóvel associado ao pacote.", false, new DateTime(2021, 03, 01));
            var pacoteRDGaming = GarantePacotes(bd, "Pacote RD - Gaming", 55, "A oferta Pacote RD - Gaming é ideal para", false, new DateTime(2021, 03, 01));
            var pacoteRDGPremium = GarantePacotes(bd, "Pacote RD - TV Premium + gaming", 65, "A oferta Pacote RD - TV Premium + gaming destacou - se na categoria de “Melhor pacote para Gaming” por apresentar a melhor relação ao nível do número de canais dedicado ao universo cinematográfico(canais base, exclusivos e premium) face ao custo mensal, bem como uma internet de alta velocidade para não haver falhas durante os jogos.", false, new DateTime(2021, 03, 01));
            var pacoteTvVoz = GarantePacotes(bd, "RD TV e Voz", 25, "Este Pacote RD TV e Voz é ideal para os clientes que querem ver televisão", false, new DateTime(2021, 03, 01));
            var pacoteRDFamiliar = GarantePacotes(bd, "RD Familiar", 45, "Pacote ideal para os momentos de lazer em família.", false, new DateTime(2021, 03, 01));

            var pascoaS = GaranteExistenciaPromocoes(bd, "PascoaS", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes pequenos", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 2, 99m, false, 1);
            var pascoaM = GaranteExistenciaPromocoes(bd, "PascoaM", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes médios", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 3, 99m, false, 2);
            var pascoaL = GaranteExistenciaPromocoes(bd, "PascoaL", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes grandes", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 4, 99m, false, 4);
            var VeraoS = GaranteExistenciaPromocoes(bd, "VerãoS", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes pequenos", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 1, 99m, false, 5);
            var VeraoM = GaranteExistenciaPromocoes(bd, "VerãoM", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes médio", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 2, 59m, false, 3);
            var VeraoL = GaranteExistenciaPromocoes(bd, "VerãoL", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes grandes", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 3, 99m, false, 9);
            var NatalS = GaranteExistenciaPromocoes(bd, "NatalS", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes pequenos", new DateTime(2021, 12, 01), new DateTime(2022, 01, 31), 3, 99m, false, 7);
            var NatalM = GaranteExistenciaPromocoes(bd, "NatalM", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes médios", new DateTime(2021, 12, 01), new DateTime(2022, 01, 31), 4, 99m, false, 19);
            var NatalL = GaranteExistenciaPromocoes(bd, "NatalL", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes grandes", new DateTime(2021, 12, 01), new DateTime(2022, 01, 31), 5, 99m, false, 5);


            if (bd.Contratos.Any()) return;
            bd.Contratos.AddRange(new Contratos[] {
                    new Contratos
                {
                    UtilizadorId= pedro.UtilizadorId,
                    ClienteId= pedro.UtilizadorId,
                    FuncionarioId=operador1.UtilizadorId,
                    PacoteId = pacoteRD3.PacoteId,
                    PromocoesId = pascoaL.PromocoesId,
                    DataInicio=new DateTime(2021,07,02),
                    DataFim=new DateTime(2023,07,02),
                    Telefone=213695748,
                    PrecoPacote = pacoteRD3.Preco,
                    PromocaoDesc = pascoaL.PromocaoDesc,
                    PrecoFinal = pacoteRD3.Preco - pascoaL.PromocaoDesc,
                    Inactivo = false,

                },
            new Contratos
                {
                   UtilizadorId= sandra.UtilizadorId,
                    ClienteId= sandra.UtilizadorId,
                    FuncionarioId=operador2.UtilizadorId,
                    PacoteId = pacoteRDGaming.PacoteId,
                    PromocoesId = pascoaL.PromocoesId,
                    DataInicio=new DateTime(2021,07,03),
                    DataFim=new DateTime(2023,07,03),
                    Telefone=213695748,
                    PrecoPacote = pacoteRDGaming.Preco,
                    PromocaoDesc = pascoaL.PromocaoDesc,
                    PrecoFinal = pacoteRDGaming.Preco - pascoaL.PromocaoDesc,
                    Inactivo = false,

                },
             new Contratos
                {
                    UtilizadorId= monica.UtilizadorId,
                    ClienteId= monica.UtilizadorId,
                    FuncionarioId=operador2.UtilizadorId,
                    PacoteId = pacoteRDGaming.PacoteId,
                    PromocoesId = pascoaL.PromocoesId,
                    DataInicio=new DateTime(2021,07,02),
                    DataFim=new DateTime(2023,07,02),
                    Telefone=215421367,
                    PrecoPacote = pacoteRDGaming.Preco,
                    PromocaoDesc = pascoaL.PromocaoDesc,
                    PrecoFinal = pacoteRDGaming.Preco - pascoaL.PromocaoDesc,
                    Inactivo = false,
             },
                    
                    
             
             //new Contratos
             //   {
             //       //ContratoId=4,
             //       ClienteId=4,
             //       FuncionarioId=8,
             //       DataInicio=new DateTime(2021,07,03),
             //       PrecoFinal=42.41m,
             //       DataFim=new DateTime(2023,07,03),
             //       PromocoesPacotes=2,
             //       PrecoPacote=45.00m,
             //       PromocaoDesc=2.59m,
             //       NomeCliente="Sara Siqueira",
             //       NomeFuncionario="Paula Melo",
             //       Telefone=219632541,
             //   },
             //new Contratos
             //   {
             //       //ContratoId=5,
             //       ClienteId=5,
             //       FuncionarioId=7,
             //       DataInicio=new DateTime(2021,03,05),
             //       PrecoFinal=60.01m,
             //       DataFim=new DateTime(2023,03,05),
             //       PromocoesPacotes=4,
             //       PrecoPacote=65.00m,
             //       PromocaoDesc=4.99m,
             //       NomeCliente="Nelson Ramos",
             //       NomeFuncionario="Luís Madeira",
             //       Telefone=213564789,
             //   },
             //new Contratos
             //   {
             //       //ContratoId=6,
             //       ClienteId=6,
             //       FuncionarioId=7,
             //       DataInicio=new DateTime(2021,03,25),
             //       PrecoFinal=51.01m,
             //       DataFim=new DateTime(2023,03,25),
             //       PromocoesPacotes=5,
             //       PrecoPacote=50.00m,
             //       PromocaoDesc=3.99m,
             //       NomeCliente="Danilo Pires",
             //       NomeFuncionario="Luís Madeira",
             //       Telefone=215632123,
             //   },
             //new Contratos
             //   {
             //       //ContratoId=7,
             //       ClienteId=7,
             //       FuncionarioId=6,
             //       DataInicio=new DateTime(2021,04,01),
             //       PrecoFinal=22.01m,
             //       DataFim=new DateTime(2023,04,01),
             //       PromocoesPacotes=6,
             //       PrecoPacote=25.00m,
             //       PromocaoDesc=2.99m,
             //       NomeCliente="Mônica Torres",
             //       NomeFuncionario="Inês Reis",
             //       Telefone=213154689,
             //   },
             //new Contratos
             //   {
             //       //ContratoId=8,
             //       ClienteId=8,
             //       FuncionarioId=10,
             //       DataInicio=new DateTime(2021,07,03),
             //       PrecoFinal=42.41m,
             //       DataFim=new DateTime(2023,07,03),
             //       PromocoesPacotes=2,
             //       PrecoPacote=45.00m,
             //       PromocaoDesc=2.59m,
             //       NomeCliente="Daniela Mata",
             //       NomeFuncionario="Marta Machado",
             //       Telefone=216335559,
             //   },
             //new Contratos
             //   {
             //       //ContratoId=9,
             //       ClienteId=9,
             //       FuncionarioId=1,
             //       DataInicio=new DateTime(2021,08,01),
             //       PrecoFinal=61.01m,
             //       DataFim=new DateTime(2023,08,01),
             //       PromocoesPacotes=1,
             //       PrecoPacote=65.00m,
             //       PromocaoDesc=3.99m,
             //       NomeCliente="Virgílio Abreu",
             //       NomeFuncionario="Nuno Forte",
             //       Telefone=211145965,
             //   },
             //new Contratos
             //   {
             //       //ContratoId=10,
             //       ClienteId=10,
             //       FuncionarioId=3,
             //       DataInicio=new DateTime(2021,08,04),
             //       PrecoFinal=61.01m,
             //       DataFim=new DateTime(2023,08,04),
             //       PromocoesPacotes=1,
             //       PrecoPacote=65.00m,
             //       PromocaoDesc=3.99m,
             //       NomeCliente="Martim Moniz",
             //       NomeFuncionario="Maria de Fátima",
             //       Telefone=215648565,
             //   },
          });
            bd.SaveChanges();
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

        //internal static async Task InsereAdministradorPadraoAsync(UserManager<IdentityUser> gestorUtilizadores)
        //{
        //    IdentityUser utilizador = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, NOME_UTILIZADOR_ADMIN_PADRAO, PASSWORD_UTILIZADOR_ADMIN_PADRAO);
        //    await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, utilizador, ROLE_ADIMINISTRADOR);
        //}

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

