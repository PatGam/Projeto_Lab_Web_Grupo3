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

        private const string NOME_UTILIZADOR_ADMIN_PADRAO = "admin@RDtelecom.com";
        private const string PASSWORD_UTILIZADOR_ADMIN_PADRAO = "Secret123$";
        private const string NOME_UTILIZADOR_CLIENTE_FICTICIO = "cliente@gmail.com";

        private const string ROLE_ADIMINISTRADOR = "Administrador";
        private const string ROLE_CLIENTE = "Cliente";
        private const string ROLE_OPERADOR = "Operador";

        internal static void PreencheDados(Projeto_Lab_WebContext bd)
        {
            InsereDistritos(bd);
            InserePromocoes(bd);
            InsereTiposServicos(bd);
            InsereServicos(bd);
            //InsereUtilizadores(bd);
            InserePacotes(bd);
            InsereServicosPacotes(bd);
            InserePromocoesPacotes(bd);

            //InsereContratos(bd);
            //InsereTiposClientes(bd);
            //InsereRoles(bd);

        }
        private static void InsereUtilizadores(Projeto_Lab_WebContext bd)
        {

            //    GaranteUtilizadores(bd, "Admin", "251286223", new DateTime(1998, 09, 29), "Rua das Flores Verde", "925258739", "admin@RDtelecom.com", "6300-706", "Administrador", false, 1);
            //    GaranteUtilizadores(bd, "Operador", "251223322", new DateTime(1998, 09, 29), "Rua das Flores", "925258737", "operador@RDtelecom.com", "6300-706", "Operador", false, 2);
            //    GaranteUtilizadores(bd, "Cliente", "223123321", new DateTime(1998, 09, 29), "Rua das Flores", "925258737", "cliente@RDtelecom.com", "6300-706", "Cliente", false, 3);

            //    GaranteUtilizadores(bd, "Nuno Forte", "255255212", new DateTime(1998, 09, 29), "Rua das Flores", "925258737", "nuno_rpf@RDtelecom.com", "6300-706", "Operador", false, 4);
            //    GaranteUtilizadores(bd, "João Matos", "224443321", new DateTime(1970, 04, 21), "Rua da Maurícia Aradas", "965111755", "joao_matos@RDtelecom.com", "3810-433", "Operador", false, 5);
            //    GaranteUtilizadores(bd, "Maria de Fátima", "256678987", new DateTime(1963, 02, 02), "Rua da Prata", "927895737", "m.fatima@RDtelecom.com", "1149-005", "Operador", false, 6);
            //    GaranteUtilizadores(bd, "Joana Pereira", "233122321", new DateTime(1992, 11, 29), "Avenida Nossa Senhora de Fátima", "91746251", "J_pereira@RDtelecom.com", "2414-003", "Operador", false, 7);
            //    GaranteUtilizadores(bd, "Justina Paulo", "221223224", new DateTime(1978, 07, 17), "Rua de São Gonçalo", "912211797", "justina_paulo@RDtelecom.com", "4814-508", "Operador", false, 8);
            //    GaranteUtilizadores(bd, "Inês Reis", "234231111", new DateTime(1998, 03, 07), "Rua Quinta do Fojo Canidelo", "969193547", "reis_ines@RDtelecom.com", "4400-658", "Operador", false, 9);
            //    GaranteUtilizadores(bd, "Luís Madeira", "223777543", new DateTime(1989, 10, 29), "Rua do Campo Alegre", "915111852", "luis.madeira@RDtelecom.com", "4169-008", "Operador", false, 10);
            //    GaranteUtilizadores(bd, "Paula Melo", "352111555", new DateTime(1984, 12, 29), "Canada dos Melancólicos", "925897737", "melo.paula@RDtelecom.com", "9701-870", "Operador", false, 11);
            //    GaranteUtilizadores(bd, "Paulo Mota", "332331345", new DateTime(2000, 06, 06), "Rua General Humberto Delgado", "969687125", "paulo_mota@RDtelecom.com", "1499-004", "Operador", false, 12);
            //    GaranteUtilizadores(bd, "Marta Machado", "201101321", new DateTime(2000, 08, 01), "Rua Central Mesura", "962154873", "m.machado@RDtelecom.com", "3049-002", "Operador", false, 13);

            //    //-------------------------- 1 AVEIRO------------------
            GaranteUtilizadores(bd, "Eduardo Pires", "286714957", new DateTime(2000, 01, 19), "Sargento Mor", "921234567", "eduardo.pires@RDtelecom.com", "3020-740", "Operador", false, "Aveiro", new DateTime(2020, 08, 05), 0, 1);
            GaranteUtilizadores(bd, "Glória da Ascenção", "218120460", new DateTime(1988, 09, 21), "Rua Fernando Caldeira", "937654321", "gloria.ascencao@RDtelecom.com", "3754-501", "Operador", false, "Aveiro", new DateTime(2020, 12, 12), 0, 1);
            GaranteUtilizadores(bd, "Maria Aparecida", "206602448", new DateTime(1977, 10, 01), "Rua Doutor Tomás Aquino", "927412589", "maria.aparecida@RDtelecom.com", "3800-523", "Operador", false, "Aveiro", new DateTime(2020, 10, 15), 0, 1);
            GaranteUtilizadores(bd, "Bernardo Ribeiro", "292565798", new DateTime(1969, 03, 25), "Avenida Manuel Álvaro Lopes Pereira", "929632587", "bernado.ribeiro@RDtelecom.com", "3800-625", "Operador", false, "Aveiro", new DateTime(2020, 10, 17), 0, 1);
            GaranteUtilizadores(bd, "Amadeu Almeida", "292565798", new DateTime(1979, 07, 16), "Avenida do Doutor Lourenço Peixinho", "921212145", "amadeu.almeida@RDtelecom.com", "3804-501", "Operador", false, "Aveiro", new DateTime(2020, 12, 28), 0, 1);
            GaranteUtilizadores(bd, "José Socrates", "250559102", new DateTime(1958, 05, 05), "Viela da Capela", "920123201", "jose.socrates@RDtelecom.com", "3810-002", "Operador", false, "Aveiro", new DateTime(2020, 08, 17), 0, 1);
            GaranteUtilizadores(bd, "Ana Brito", "275433641", new DateTime(2000, 09, 04), "Rua do Jardim", "929633230", "ana.brito@RDtelecom.com", "3054-001", "Operador", false, "Aveiro", new DateTime(2020, 08, 19), 0, 1);
            GaranteUtilizadores(bd, "Luís Neto", "142518093", new DateTime(1985, 04, 04), "Avenida Comendador Augusto Martins Pereira", "920258847", "luis.neto@RDtelecom.com", "3744-002", "Operador", false, "Aveiro", new DateTime(2020, 08, 28), 0, 1);
            GaranteUtilizadores(bd, "Freitas do Mondego", "172501482", new DateTime(1975, 02, 08), "Rua do Murtório Rochico ", "961477784", "freitas.mondego@RDtelecom.com", "3865-299", "Operador", false, "Aveiro", new DateTime(2020, 10, 02), 0, 1);
            GaranteUtilizadores(bd, "João Cardoso", "265371988", new DateTime(1958, 12, 27), "Travessa da Lomba", "923212322", "joao.cardoso@RDtelecom.com", "3865-003", "Operador", false, "Aveiro", new DateTime(2021, 01, 05), 0, 1); ;
            GaranteUtilizadores(bd, "Rita de Brandão", "244225834", new DateTime(1956, 08, 27), "Largo 5 de Outubro Jardim dos Campos Pares", "929988774", "rita.brandao@RDtelecom.com", "3880-006", "Operador", false, "Aveiro", new DateTime(2021, 02, 05), 0, 1);

            //    //-------------------------- 2 BEJA------------------
            GaranteUtilizadores(bd, "Ramos de Oliveira", "286714957", new DateTime(2001, 01, 19), "Beco da Rua Acima", "963125474", "eduardo.pires@RDtelecom.com", "7960-002", "Operador", false, "Beja", new DateTime(2021, 01, 05), 0, 2);
            GaranteUtilizadores(bd, "Catarina Alves", "218120460", new DateTime(1995, 09, 21), "Marmelar", "932789321", "gloria.ascencao@RDtelecom.com", "7960-001", "Operador", false, "Beja", new DateTime(2020, 10, 17), 0, 2);
            GaranteUtilizadores(bd, "Rui del Nascimiento", "206602448", new DateTime(1965, 10, 11), "Rua Longa", "921023951", "maria.aparecida@RDtelecom.com", "7940-160", "Operador", false, "Beja", new DateTime(2020, 10, 25), 0, 2);
            GaranteUtilizadores(bd, "Vasco Barreiros", "292565798", new DateTime(1962, 02, 25), "Avenida Manuel Álvaro Lopes Pereira", "927406381", "bernado.ribeiro@RDtelecom.com", "3800-625", "Operador", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            GaranteUtilizadores(bd, "Mário Botelho", "292565798", new DateTime(1987, 07, 16), "Albergaria dos Fusos", "923148620", "amadeu.almeida@RDtelecom.com", "7940-411", "Operador", false, "Beja", new DateTime(2020, 08, 26), 0, 2);
            GaranteUtilizadores(bd, "Lula de La Cruz", "250559102", new DateTime(1958, 04, 05), "Rua dos Lobos", "932951753", "jose.socrates@RDtelecom.com", "7920-005", "Operador", false, "Beja", new DateTime(2020, 08, 28), 0, 2);
            GaranteUtilizadores(bd, "Paula Piruvato", "275433641", new DateTime(1992, 09, 04), "Largo dos Cadeirões", "935751153", "ana.brito@RDtelecom.com", "7920-002", "Operador", false, "Beja", new DateTime(2021, 02, 30), 0, 2);
            GaranteUtilizadores(bd, "Thomas Lourenço", "142518093", new DateTime(1979, 04, 06), "Praça do Ultramar", "928963321", "luis.neto@RDtelecom.com", "7801-857", "Operador", false, "Beja", new DateTime(2020, 10, 28), 0, 2);
            GaranteUtilizadores(bd, "Luís Smith", "172501482", new DateTime(1975, 06, 08), "Moitinhas", "960154784", "freitas.mondego@RDtelecom.com", "7665-803", "Operador", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            GaranteUtilizadores(bd, "Márcia Wood", "265371988", new DateTime(1972, 11, 27), "Ribeira de Torquinhos", "921789321", "joao.cardoso@RDtelecom.com", "7665-814", "Operador", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            GaranteUtilizadores(bd, "Jerónimo Graciano", "244225834", new DateTime(1956, 05, 22), "Rua da Cova da Burra", "928032965", "rita.brandao@RDtelecom.com", "7700-003", "Operador", false, "Beja", new DateTime(2021, 01, 05), 0, 2);

            //    //-------------------------- 3 BRAGA------------------
            //    GaranteUtilizadores(bd, "Fernando Couto", "239833252", new DateTime(1977, 03, 19), "Rua dos Bombeiros Voluntários", "960023231", "fernado.couto@RDtelecom.com", "4700-002", "Operador", false, 3);
            //    GaranteUtilizadores(bd, "Deolinda Bacalhau", "292716222", new DateTime(2001, 05, 21), "Rua Professora Alda Brandão Real", "933584787", "deolinda.bacalhau@RDtelecom.com", "4700-002", "Operador", false, 3);
            //    GaranteUtilizadores(bd, "Ivanilda Pessoa", "206870523", new DateTime(1977, 08, 01), "Rua da Sobreira Frossos", "923001221", "ivanilda.pessoa@RDtelecom.com", "4700-441", "Operador", false, 3);
            //    GaranteUtilizadores(bd, "Onofre Galvão", "267894422", new DateTime(1969, 04, 30), "Largo de Maximinos", "928976413", "onofre.galvao@RDtelecom.com", "4700-999", "Operador", false, 3);
            //    GaranteUtilizadores(bd, "Ian Coelho", "249703238", new DateTime(2002, 01, 31), "Largo de São Tiago", "92587963", "ian.coelho@RDtelecom.com", "4704-504", "Operador", false, 3);
            //    GaranteUtilizadores(bd, "Ryan Oliveira", "240442571", new DateTime(1988, 03, 05), "Rua das Oliveiras", "920322333", "ryan.oliveira@RDtelecom.com", "4705-790", "Operador", false, 3);
            //    GaranteUtilizadores(bd, "Marizete Gillot", "285368559", new DateTime(1956, 10, 04), "Rua dos Caixoteiros", "922001789", "marizete.gillot@RDtelecom.com", "4705-001", "Operador", false, 3);
            //    GaranteUtilizadores(bd, "Beto da Alegria", "249227673", new DateTime(1957, 03, 17), "Rua Sem Nome", "925567841", "beto.alegria@RDtelecom.com", "4750-008", "Operador", false, 3);
            //    GaranteUtilizadores(bd, "Pinheiro dos Santos", "273654888", new DateTime(1970, 02, 28), "Travessa do Rio da Guarda", "921003288", "pinheiro.santos@RDtelecom.com", "4765-489", "Operador", false, 3);
            //    GaranteUtilizadores(bd, "Divina de Jesus", "268345139", new DateTime(1958, 11, 30), "Rua Cães de Pedra Lt 5", "921785432", "divina.jesus@RDtelecom.com", "4835-003", "Operador", false, 3);
            //    GaranteUtilizadores(bd, "Irina Leite", "263696340", new DateTime(1999, 10, 27), "Rua da Madalena", "929633600", "irina.leite@RDtelecom.com", "4835-511", "Operador", false, 3);

            //    //-------------------------- 4 BRAGANÇA------------------
            //    GaranteUtilizadores(bd, "Natally Domingues", "239833252", new DateTime(1974, 06, 19), "Bairro Moinho de Vento", "939007258", "natally.domingues@RDtelecom.com", "5140-005", "Operador", false, 4);
            //    GaranteUtilizadores(bd, "Nicolau Figueiras", "292716222", new DateTime(2001, 01, 21), "Quinta Lameira de Ferro", "932101491", "nicolau.figueiras@RDtelecom.com", "5140-135", "Operador", false, 4);
            //    GaranteUtilizadores(bd, "John Dias", "206870523", new DateTime(1987, 09, 03), "Rua Sem Nome 218 Bairro Além do Rio ", "966852031", "john.dias@RDtelecom.com", "5300-001", "Operador", false, 4);
            //    GaranteUtilizadores(bd, "Maria Leal", "267894422", new DateTime(1969, 09, 30), "Rua da Fragata", "923455896", "maria.leal@RDtelecom.com", "5385-101", "Operador", false, 4);
            //    GaranteUtilizadores(bd, "Isabel dos Santinhos", "249703238", new DateTime(1957, 05, 31), "Valbom Pitez", "922788996", "isabel.santinhos@RDtelecom.com", "5385-132", "Operador", false, 4);
            //    GaranteUtilizadores(bd, "Rui Fragona", "240442571", new DateTime(1988, 03, 07), "Azenha do Areal", "920335411", "rui.fragona@RDtelecom.com", "5370-131", "Operador", false, 4);
            //    GaranteUtilizadores(bd, "Dunildo de Boa Esperança", "285368559", new DateTime(2000, 10, 04), "Vale de Lobo", "929693914", "dunildo.esperanca@RDtelecom.com", "5370-102", "Operador", false, 4);
            //    GaranteUtilizadores(bd, "Carla Dorys", "249227673", new DateTime(1995, 08, 17), "Vilar Seco", "963321087", "carla.dorys@RDtelecom.com", "5350-204", "Operador", false, 4);
            //    GaranteUtilizadores(bd, "Birna de Oliveira", "273654888", new DateTime(1980, 02, 28), "Rua dos Combatentes da Grande Guerra", "930147852", "birna.oliveira@RDtelecom.com", "5301-861", "Operador", false, 4);
            //    GaranteUtilizadores(bd, "João Salgado", "268345139", new DateTime(1966, 11, 30), "Rua Cova da Beira", "926698230", "joao.salgado@RDtelecom.com", "5300-869", "Operador", false, 4);
            //    GaranteUtilizadores(bd, "Feitosa Pauleta", "263696340", new DateTime(1972, 10, 27), "Rotunda do Lavrador Bairro da Braguinha ", "921033025", "feitosa.pauleta@RDtelecom.com", "5300-420", "Operador", false, 4);

            //    //-------------------------- 5 CASTELO BRANCO------------------
            //    GaranteUtilizadores(bd, "Cláudia Vieira", "195173210", new DateTime(1965, 06, 19), "Rua das Rosas", "933896541", "claudia.vieira@RDtelecom.com", "6250-004", "Operador", false, 5);
            //    GaranteUtilizadores(bd, "Diogo Andrade", "136693199", new DateTime(1999, 01, 21), "Sítio do Cabecinho", "937258852", "diogo.andrade@RDtelecom.com", "6250-111", "Operador", false, 5);
            //    GaranteUtilizadores(bd, "Maria Ruah", "116663987", new DateTime(1988, 02, 03), "Quinta de Valverdinho", "963012547", "maria.ruah@RDtelecom.com", "6250-163", "Operador", false, 5);
            //    GaranteUtilizadores(bd, "Florbela Antunes", "127533818", new DateTime(1980, 09, 30), "Rua do Curral", "922013645", "florbela.antunes@RDtelecom.com", "6215-001", "Operador", false, 5);
            //    GaranteUtilizadores(bd, "António Antunes", "111712580", new DateTime(1974, 05, 31), "Rua Marquês de Ávila e Bolama", "928328961", "antonio.antunes@RDtelecom.com", "6201-001", "Operador", false, 5);
            //    GaranteUtilizadores(bd, "Liliana Aveiro", "183191404", new DateTime(2000, 03, 07), "Viela do Castelo", "927031759", "liliana.aveiro@RDtelecom.com", "6200-227", "Operador", false, 5);
            //    GaranteUtilizadores(bd, "Maria Pedroso", "161954464", new DateTime(2000, 10, 04), "Travessa das Trapas", "924630158", "maria.pedroso@RDtelecom.com", "6200-237", "Operador", false, 5);
            //    GaranteUtilizadores(bd, "Pedro Fernandes", "182518434", new DateTime(1957, 08, 17), "Bairro da Formiguinha Vila do Carvalho", "966332157", "pedro.fernandes@RDtelecom.com", "6200-241", "Operador", false, 5);
            //    GaranteUtilizadores(bd, "Miguel Moniz", "145814360", new DateTime(1962, 02, 30), "Rua das Tendas", "933212269", "miguel.moniz@RDtelecom.com", "6200-699", "Operador", false, 5);
            //    GaranteUtilizadores(bd, "Felisberto Ortiz", "114162123", new DateTime(1971, 02, 30), "Travessa dos Escabelados", "922100366", "felisberto.ortiz@RDtelecom.com", "6200-742", "Operador", false, 5);
            //    GaranteUtilizadores(bd, "António Sanchez", "163492115", new DateTime(1976, 11, 27), "Rua Canada", "925644710", "antonio.sanchez@RDtelecom.com", "6005-002", "Operador", false, 5);

            //    //-------------------------- 6 COIMBRA-----------------
            //    GaranteUtilizadores(bd, "Patrícia Gomes", "248858939", new DateTime(1999, 07, 01), "Rua do Norte", "929154121", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 6);
            //    GaranteUtilizadores(bd, "Marlene Santos", "123456789", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "933254121", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 6);
            //    GaranteUtilizadores(bd, "João Ferreira", "233333231", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "929154121", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 6);
            //    GaranteUtilizadores(bd, "Tânia Sousa", "233259627", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "927854121", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 6);
            //    GaranteUtilizadores(bd, "Rute Martins", "221639896", new DateTime(1979, 10, 30), "Cruz de Ferro", "929154199", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 6);
            //    GaranteUtilizadores(bd, "Paulo Pedra", "215922158", new DateTime(1999, 07, 01), "Rua do Norte", "929154121", "paulo.pedra@RDtelecom.com", "3000-295", "Operador", false, 6);
            //    GaranteUtilizadores(bd, "Helder Copeto", "209281472", new DateTime(1999, 07, 01), "Rua do Norte", "929154121", "helder.copeto@RDtelecom.com", "3000-295", "Operador", false, 6);
            //    GaranteUtilizadores(bd, "Miriam Falcão", "218052421", new DateTime(2000, 01, 01), "Vale Derradeiro", "929154121", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 6);
            //    GaranteUtilizadores(bd, "Célia Tomate", "224046284", new DateTime(1980, 09, 11), "Seladinhas", "929154121", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 6);
            //    GaranteUtilizadores(bd, "Tadeu Leão", "294178775", new DateTime(1975, 02, 08), "Flor da Rosa", "929154121", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 6);
            //    GaranteUtilizadores(bd, "Harley Guerra", "230936679", new DateTime(1955, 12, 24), "Beco da Alegria", "929154121", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 6);
            //    GaranteUtilizadores(bd, "Afonso Freira", "271671130", new DateTime(1956, 12, 05), "Beco das Cruzes", "929154121", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 6);


            //    //-------------------------- 7 EVORA-----------------
            //    GaranteUtilizadores(bd, "Andreia Alves", "238122549", new DateTime(2001, 07, 01), "Vale de Pegas", "921456654", "andreia.alves@RDtelecom.com", "7490-120", "Operador", false, 7);
            //    GaranteUtilizadores(bd, "João Correia", "270613994", new DateTime(1999, 11, 21), "Rua João de Deus", "936825714", "joao.correia@RDtelecom.com", "7250-142", "Operador", false, 7);
            //    GaranteUtilizadores(bd, "Ricardo da Gama", "205118615", new DateTime(1975, 07, 01), "Rua da Liberdade", "920147963", "ricardo.gama@RDtelecom.com", "7220-002", "Operador", false, 7);
            //    GaranteUtilizadores(bd, "Inês Castro", "278968724", new DateTime(1969, 06, 08), "Rua dos Irmãos", "927369148", "ines.castro@RDtelecom.com", "7220-003", "Operador", false, 7);
            //    GaranteUtilizadores(bd, "Andressa Ribeiro", "220236410", new DateTime(1962, 03, 30), "Praceta do Brasil", "928741147", "andressa.ribeiro@RDtelecom.com", "7200-479", "Operador", false, 7);
            //    GaranteUtilizadores(bd, "Pablo Abrunhosa", "201957060", new DateTime(1980, 07, 01), "Rua Projectada à Avenida Tomás Alcaide", "926951753", "pablo.abrunhosa@RDtelecom.com", "7100-130", "Operador", false, 7);
            //    GaranteUtilizadores(bd, "Ramon Marques", "246386339", new DateTime(1999, 07, 01), "Travessa das Amendoeiras", "920147895", "ramon.marques@RDtelecom.com", "7090-006", "Operador", false, 7);
            //    GaranteUtilizadores(bd, "Mariana da Serenidade", "269577556", new DateTime(1999, 01, 01), "Bairro Ferragolo", "922333698", "mariana.serenidade@RDtelecom.com", "7080-109", "Operador", false, 7);
            //    GaranteUtilizadores(bd, "Dilma Rosas", "253854040", new DateTime(1958, 09, 21), "Casa de Pau", "920032147", "dilma.rosas@RDtelecom.com", "7050-634", "Operador", false, 7);
            //    GaranteUtilizadores(bd, "Vicente Silva", "281567182", new DateTime(1965, 02, 08), "Largo das Alterações", "931456321", "vicente.silva@RDtelecom.com", "7000-502", "Operador", false, 7);
            //    GaranteUtilizadores(bd, "Flascotter Pereira", "286365723", new DateTime(1995, 03, 24), "Rua Francisco Soares Lusitano", "966333210", "flascotter.pereira@RDtelecom.com", "7004-511", "Operador", false, 7);
            //    GaranteUtilizadores(bd, "Sara Moedas", "278661610", new DateTime(1956, 05, 05), "Largo dos Colegiais 2", "933225871", "sara.moedas@RDtelecom.com", "7004-516", "Operador", false, 7);

            //    //-------------------------- 8 FARO-----------------
            //    GaranteUtilizadores(bd, "Miguel Rossi", "298933896", new DateTime(1999, 07, 01), "Rua da Viola ", "925874100", "miguel.rossi@RDtelecom.com", "8000-274", "Operador", false, 8);
            //    GaranteUtilizadores(bd, "Martina Castilho", "290825091", new DateTime(1988, 11, 21), "Rua do Bocage", "933302145", "martina.castilho@RDtelecom.com", "8004-002", "Operador", false, 8);
            //    GaranteUtilizadores(bd, "Romeo Ximenes", "256438676", new DateTime(1978, 07, 01), "Areal Gordo", "932587410", "romeo.ximenes@RDtelecom.com", "8005-409", "Operador", false, 8);
            //    GaranteUtilizadores(bd, "John Pitt", "200101447", new DateTime(1969, 06, 06), "Travessa do Borrego", "933666520", "john.pitt@RDtelecom.com", "8125-002", "Operador", false, 8);
            //    GaranteUtilizadores(bd, "Zézinho Camarrinha", "213627736", new DateTime(1979, 10, 30), "Beco das Palmeiras", "921230002", "zezinho.camarrinha@RDtelecom.com", "8125-609", "Operador", false, 8);
            //    GaranteUtilizadores(bd, "Luna Smith", "254704085", new DateTime(1999, 07, 01), "Beco Condestável", "925666417", "luna.smith@RDtelecom.com", "8125-636", "Operador", false, 8);
            //    GaranteUtilizadores(bd, "Luísa Salvador", "261746227", new DateTime(1999, 06, 01), "Beco dos Bitas", "936254102", "luisa.salvador@RDtelecom.com", "8200-002", "Operador", false, 8);
            //    GaranteUtilizadores(bd, "Ana Cacho", "255512546", new DateTime(2000, 01, 01), "Rua das Telecomunicações", "920320001", "ana.cacho@RDtelecom.com", "8201-871", "Operador", false, 8);
            //    GaranteUtilizadores(bd, "Fernando Rock", "203265424", new DateTime(1980, 09, 11), "Caminho Municipal", "967369874", "fernando.rock@RDtelecom.com", "8201-877", "Operador", false, 8);
            //    GaranteUtilizadores(bd, "Miguel Feliz", "299944611", new DateTime(1975, 02, 08), "Avenida dos Descobrimentos", "921321111", "miguel.feliz@RDtelecom.com", "8601-852", "Operador", false, 8);
            //    GaranteUtilizadores(bd, "Maria Ferrari", "226395324", new DateTime(1955, 12, 24), "Rua 25 de Abril", "917854123", "maria.ferrari@RDtelecom.com", "8801-005", "Operador", false, 8);
            //    GaranteUtilizadores(bd, "Bruno da Câmara Pereira", "231898975", new DateTime(1956, 12, 05), "Monte Olimpio", "917364825", "bruno.pereira@RDtelecom.com", "8900-106", "Operador", false, 8);


            //    //-------------------------- 9 GUARDA-----------------
            //    GaranteUtilizadores(bd, "Alicia Sancho", "240315170", new DateTime(1988, 07, 01), "Ponte do Abade", "926999852", "alicia.sancho@RDtelecom.com", "3570-191", "Operador", false, 9);
            //    GaranteUtilizadores(bd, "Mateo Jesus", "216994918", new DateTime(1964, 11, 21), "Rua Quebra Costas", "933022589", "mateo.jesus@RDtelecom.com", "5155-003", "Operador", false, 9);
            //    GaranteUtilizadores(bd, "Antonnella Conti", "262339374", new DateTime(1954, 08, 01), "Zurrão", "922557410", "antonnella.conti@RDtelecom.com", "6260-196", "Operador", false, 9);
            //    GaranteUtilizadores(bd, "Nuno Gatti", "281167222", new DateTime(1970, 02, 06), "Carvalhal da Louça", "923654789", "nuno.gatti@RDtelecom.com", "6270-131", "Operador", false, 9);
            //    GaranteUtilizadores(bd, "Patrícia Carbone", "253533643", new DateTime(1980, 03, 30), "Rua Amadeus Mozart", "966968749", "patricia.carbone@RDtelecom.com", "6300-509", "Operador", false, 9);
            //    GaranteUtilizadores(bd, "Pedro Guerra", "254138349", new DateTime(1999, 08, 01), "Muxagata", "923456987", "pedro.guerra@RDtelecom.com", "6370-361", "Operador", false, 9);
            //    GaranteUtilizadores(bd, "Célia Valente", "263953840", new DateTime(1999, 07, 01), "Juncais", "910002658", "celia.valente@RDtelecom.com", "6370-332", "Operador", false, 9);
            //    GaranteUtilizadores(bd, "Rosa Serra", "281900361", new DateTime(2000, 01, 01), "Quinta da Costa", "92888632", "rosa.serra@RDtelecom.com", "6324-004", "Operador", false, 9);
            //    GaranteUtilizadores(bd, "Ricardo Estrela", "206569327", new DateTime(1987, 09, 17), "Parada", "963011456", "ricardo.estrla@RDtelecom.com", "6355-142", "Operador", false, 9);
            //    GaranteUtilizadores(bd, "Carlos Fechaduras", "220640610", new DateTime(1859, 05, 08), "Senouras", "925666874", "carlos.fechaduras@RDtelecom.com", "6355-170", "Operador", false, 9);
            //    GaranteUtilizadores(bd, "Álvaro Bruxelas", "210346760", new DateTime(1958, 12, 31), "Beco da Alegria", "91025800", "alvaro.bruxelas@RDtelecom.com", "6355-170", "Operador", false, 9);
            //    GaranteUtilizadores(bd, "Isamara Lobão", "215494725", new DateTime(1956, 12, 05), "Lajeosa", "936058777", "isamara.lobao@RDtelecom.com", "6320-161", "Operador", false, 9);

            //    //-------------------------- 10 LEIRIA-----------------
            //    GaranteUtilizadores(bd, "Amílcar Malho", "119888068", new DateTime(1967, 03, 01), "Rua dos Inácios", "923600144", "amilcar.malho@RDtelecom.com", "2400-773", "Operador", false, 10);
            //    GaranteUtilizadores(bd, "Joana de Sá", "131092812", new DateTime(1966, 11, 21), "Rua do Futuro", "930054711", "joana.sa@RDtelecom.com", "2400-760", "Operador", false, 10);
            //    GaranteUtilizadores(bd, "João Cabral", "161270441", new DateTime(2000, 06, 01), "Moinho do Rato", "925632008", "joao.cabral@RDtelecom.com", "2410-528", "Operador", false, 10);
            //    GaranteUtilizadores(bd, "Ilídio Brazeta", "140129375", new DateTime(1999, 06, 09), "Rua de Saint-Maur-Des-Fosses", "963012547", "ilidio.brazeta@RDtelecom.com", "2414-001", "Operador", false, 10);
            //    GaranteUtilizadores(bd, "Ricardo Caramelo", "161728219", new DateTime(1984, 02, 30), "Estrada da Mata Marrazes", "921456920", "ricardo.caramelo@RDtelecom.com", "2419-001", "Operador", false, 10);
            //    GaranteUtilizadores(bd, "João Figo", "175938652", new DateTime(1999, 07, 11), "Rua de Santa Margarida", "923001458", "joao.figo@RDtelecom.com", "2420-999", "Operador", false, 10);
            //    GaranteUtilizadores(bd, "Romina Santos", "163520500", new DateTime(1999, 07, 01), "Beco Grilo", "931478569", "romina.santos@RDtelecom.com", "2460-005", "Operador", false, 10);
            //    GaranteUtilizadores(bd, "Rui Rosa", "103294708", new DateTime(2000, 01, 01), "Rua Mercedes e Carlos Campeão", "968547000", "rui.rosa@RDtelecom.com", "2460-006", "Operador", false, 10);
            //    GaranteUtilizadores(bd, "Vanda Ruivo", "109509552", new DateTime(1980, 10, 11), "Bolo", "922365009", "vanda.ruivo@RDtelecom.com", "3280-113", "Operador", false, 10);
            //    GaranteUtilizadores(bd, "Tiago Andrade", "163600937", new DateTime(1975, 08, 08), "Sapateira", "967896333", "tiago.andrade@RDtelecom.com", "3280-123", "Operador", false, 10);
            //    GaranteUtilizadores(bd, "Marta Martinelli", "195614313", new DateTime(1988, 12, 24), "Rua dos Lavadouros", "910258963", "marta.martinelli@RDtelecom.com", "2525-123", "Operador", false, 10);
            //    GaranteUtilizadores(bd, "Joaquim Vitale", "116386428", new DateTime(1996, 12, 05), "Picha", "939391250", "joaquim.vitale@RDtelecom.com", "3270-143", "Operador", false, 10);


            //    //-------------------------- 11 LISBOA-----------------
            //    GaranteUtilizadores(bd, "Geraldo Fraga", "126914966", new DateTime(1968, 08, 01), "Rua Brito Aranha", "924141230", "geraldo.fraga@RDtelecom.com", "1000-007", "Operador", false, 11);
            //    GaranteUtilizadores(bd, "Celeste Djata", "196656087", new DateTime(1969, 11, 28), "Avenida dos Defensores de Chaves", "937182456", "celeste.djata@RDtelecom.com", "1049-004", "Operador", false, 11);
            //    GaranteUtilizadores(bd, "Carla Costa", "176965173", new DateTime(1978, 05, 01), "Largo das Palmeiras", "931773910", "carla.costa@RDtelecom.com", "1050-168", "Operador", false, 11);
            //    GaranteUtilizadores(bd, "Daniele Lucas", "110466721", new DateTime(1973, 08, 06), "Avenida de Berna", "917182935", "daniele.lucas@RDtelecom.com", "1067-001", "Operador", false, 11);
            //    GaranteUtilizadores(bd, "Davide Ramos", "171941195", new DateTime(1986, 10, 30), "Vila Celeste Rua Garcia", "961455620", "davide.ramos@RDtelecom.com", "1070-136", "Operador", false, 11);
            //    GaranteUtilizadores(bd, "Diana Leite", "164398112", new DateTime(1999, 07, 01), "Beco Benformoso", "967410226", "diana.leite@RDtelecom.com", "1100-008", "Operador", false, 11);
            //    GaranteUtilizadores(bd, "Dunildo Fernandes", "133792285", new DateTime(1988, 07, 01), "Largo Cabeço da Bola", "937852013", "dunildo.fernandes@RDtelecom.com", "1150-008", "Operador", false, 11);
            //    GaranteUtilizadores(bd, "Beatriz Testa", "141553898", new DateTime(2000, 01, 01), "Beco da Bempostinha", "931456110", "beatriz.testa@RDtelecom.com", "1150-006", "Operador", false, 11);
            //    GaranteUtilizadores(bd, "Pedro Farina", "177572280", new DateTime(2000, 09, 29), "Rua dos Anjos", "969391789", "pedro.farina@RDtelecom.com", "1169-004", "Operador", false, 11);
            //    GaranteUtilizadores(bd, "Bernardino Caputo", "150336322", new DateTime(1975, 02, 08), "Rua dos Lusíadas", "919320365", "bernardino.caputo@RDtelecom.com", "1349-006", "Operador", false, 11);
            //    GaranteUtilizadores(bd, "Pablo Medina", "153510340", new DateTime(1955, 08, 24), "Cabeça Gorda", "932514789", "pablo.medina@RDtelecom.com", "2565-001", "Operador", false, 11);
            //    GaranteUtilizadores(bd, "Eva Simões", "170633977", new DateTime(1969, 12, 18), "Avenida João de Belas", "930258789", "eva.simoes@RDtelecom.com", "2605-203", "Operador", false, 11);

            //    //-------------------------- 12 PORTALEGRE-----------------
            //    GaranteUtilizadores(bd, "Paula Neves", "246991585", new DateTime(1987, 05, 01), "Torre Cimeira", "969691321", "paula.neves@RDtelecom.com", "6040-003", "Operador", false, 12);
            //    GaranteUtilizadores(bd, "Filipe Pinto", "207370133", new DateTime(1988, 10, 21), "Rua do Poço", "936285714", "filipe.pinto@RDtelecom.com", "6050-106", "Operador", false, 12);
            //    GaranteUtilizadores(bd, "Ryan Vieira", "258078286", new DateTime(1968, 07, 13), "Ribeiro do Buraco", "921326554", "ryan.vieira@RDtelecom.com", "7300-351", "Operador", false, 12);
            //    GaranteUtilizadores(bd, "Rodrigo Amarelo", "292120265", new DateTime(1970, 06, 28), "Cubos", "925632214", "rodrigo.amarelo@RDtelecom.com", "7300-316", "Operador", false, 12);
            //    GaranteUtilizadores(bd, "Rita Abrantes", "210764333", new DateTime(1984, 10, 07), "Praça do Município", "960321123", "rita.abrantes@RDtelecom.com", "7301-855", "Operador", false, 12);
            //    GaranteUtilizadores(bd, "Luís Rico", "246103230", new DateTime(1982, 07, 18), "Travessa da Rua do Comércio", "911233698", "luis.rico@RDtelecom.com", "7301-857", "Operador", false, 12);
            //    GaranteUtilizadores(bd, "Helder Conceição", "247266221", new DateTime(1973, 07, 01), "Rua das Encruzilhadas", "936200145", "helder.conceicao@RDtelecom.com", "7320-123", "Operador", false, 12);
            //    GaranteUtilizadores(bd, "Mariza Falcão", "265156343", new DateTime(2000, 01, 01), "Portas do Sol", "968574123", "mariza.falcao@RDtelecom.com", "7350-002", "Operador", false, 12);
            //    GaranteUtilizadores(bd, "Lúcio Junior", "284225959", new DateTime(1980, 09, 16), "Rua da Guarda", "961425632", "lucio.junior@RDtelecom.com", "7350-002", "Operador", false, 12);
            //    GaranteUtilizadores(bd, "Tiago Silva", "256300291", new DateTime(1975, 02, 24), "Rua do Escorregadio", "916914785", "tiago.silva@RDtelecom.com", "7350-002", "Operador", false, 12);
            //    GaranteUtilizadores(bd, "Ana Godinho", "274980398", new DateTime(1968, 12, 19), "Rua do Emigrante", "923654782", "ana.godinho@RDtelecom.com", "7370-001", "Operador", false, 12);
            //    GaranteUtilizadores(bd, "Filipa Oliveira", "270511059", new DateTime(1956, 12, 05), "Rua Marciano Cipriano", "923654741", "filipa.oliveira@RDtelecom.com", "7370-002", "Operador", false, 12);

            //    //------------------------------------------------
            //    //-------------------------- 13 PORTO-----------------
            GaranteUtilizadores(bd, "Patrícia Amaral", "232501173", new DateTime(1999, 07, 01), "Largo Escultor José Moreira da Silva", "968574000", "patricia.amaral@RDtelecom.com", "4000-312", "Operador", false, "Porto", new DateTime(2020, 08, 05), 0, 13);
            GaranteUtilizadores(bd, "João Santos", "255170262", new DateTime(1988, 11, 21), "Rua Latino Coelho Pares", "933220655", "joao.santos@RDtelecom.com", "4000-314", "Operador", false, "Porto", new DateTime(2021, 01, 05), 0, 13);
            GaranteUtilizadores(bd, "João Ferreira", "279641966", new DateTime(1978, 07, 01), "Rua de Moreira Ímpares", "923002564", "joao.ferreira@RDtelecom.com", "4000-346", "Operador", false, "Porto", new DateTime(2020, 10, 11), 0, 13);
            GaranteUtilizadores(bd, "Tânia Pereira", "265227186", new DateTime(1969, 06, 06), "Rua do Alto da Fontinha", "968321008", "tania.pereira@RDtelecom.com", "4000-007", "Operador", false, "Porto", new DateTime(2020, 08, 12), 0, 13);
            GaranteUtilizadores(bd, "Rute Pequena", "220300828", new DateTime(1979, 10, 30), "Rua Júlio Dinis Fast-Food Mister Pick Wick", "925654197", "rute.pequena@RDtelecom.com", "4050-001", "Operador", false, "Porto", new DateTime(2020, 10, 17), 0, 13);
            GaranteUtilizadores(bd, "Paulo Jorge", "215830300", new DateTime(1999, 07, 01), "Rua Júlio Dinis", "923685203", "paulo.jorge@RDtelecom.com", "4050-322", "Operador", false, "Porto", new DateTime(2020, 08, 18), 0, 13);
            GaranteUtilizadores(bd, "Helder Reis", "222960540", new DateTime(1999, 07, 01), "Travessa Marracuene", "923654780", "helder.reis@RDtelecom.com", "4050-357", "Operador", false, "Porto", new DateTime(2020, 08, 26), 0, 13);
            GaranteUtilizadores(bd, "Lucas Castilho", "204095387", new DateTime(2000, 01, 01), "Rua Guerra Junqueiro", "936002365", "tome.fernandes@RDtelecom.com", "4169-009", "Operador", false, "Porto", new DateTime(2020, 08, 27), 0, 13);
            GaranteUtilizadores(bd, "Tomé Fernades", "240389263", new DateTime(1980, 09, 11), "Rua do Campo Alegre", "927183608", "tome.fernandes@RDtelecom.com", "4169-007", "Operador", false, "Porto", new DateTime(2020, 08, 25), 0, 13);
            GaranteUtilizadores(bd, "Paula Andrade", "210053895", new DateTime(1975, 02, 08), "Rua Gonçalo Sampaio", "925328961", "paula.andrade@RDtelecom.com", "4169-001", "Operador", false, "Porto", new DateTime(2020, 11, 10), 0, 13);
            GaranteUtilizadores(bd, "Jacinto Dias", "267983921", new DateTime(1955, 12, 24), "Rua do Campo Alegre", "968321520", "jacinto.dias@RDtelecom.com", "4169 - 007", "Operador", false, "Porto", new DateTime(2020, 10, 05), 0, 13);
            GaranteUtilizadores(bd, "Amélia Paz", "207692670", new DateTime(1956, 12, 05), "Rua Professora Lucília Fernandes Canidelo", "930221459", "amelia.paz@RDtelecom.com", "4400-651", "Operador", false, "Porto", new DateTime(2020, 12, 05), 0, 13);

            //    //-------------------------- 14 SANTAREM-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "102923698", new DateTime(1999, 07, 01), "Casal dos Florindos", "917896325", "patricia.gomes@RDtelecom.com", "2000-320", "Operador", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);
            GaranteUtilizadores(bd, "Marlene Santos", "167804812", new DateTime(1988, 11, 21), "Casal da Igreja", "969587542", "marlene.satos@RDtelecom.com", "2000-336", "Operador", false, "Santarém", new DateTime(2020, 08, 19), 0, 14);
            GaranteUtilizadores(bd, "João Ferreira", "179394614", new DateTime(1978, 07, 01), "Dona Belida", "932102548", "joao.ferreira@RDtelecom.com", "2000-342", "Operador", false, "Santarém", new DateTime(2021, 01, 17), 0, 14);
            GaranteUtilizadores(bd, "Pedro Martins", "134904710", new DateTime(1969, 06, 06), "Avenida Bernardo Santareno", "963214520", "pedro.martins@RDtelecom.com", "2009-004", "Operador", false, "Santarém", new DateTime(2021, 01, 05), 0, 14);
            GaranteUtilizadores(bd, "Joana Lima", "194846377", new DateTime(1979, 10, 30), "Largo do Infante Santo", "925874100" ,"joana.lima@RDtelecom.com", "2009-002", "Operador", false, "Santarém", new DateTime(2021, 01, 05), 0, 14);
            GaranteUtilizadores(bd, "Patrícia Gomes", "130908010", new DateTime(1999, 07, 01), "Estrada Nacional 10", "925964874", "patricia.gomes@RDtelecom.com", "2139-503", "Operador", false, "Santarém", new DateTime(2020, 12, 28), 0, 14);
            GaranteUtilizadores(bd, "Irís Copeto", "137377924", new DateTime(1999, 07, 01), "Agolada", "965412088", "iris.copeto@RDtelecom.com", "2100-001", "Operador", false, "Santarém", new DateTime(2020, 11, 12), 0, 14);
            GaranteUtilizadores(bd, "Filipe Pais", "193317842", new DateTime(2000, 01, 01), "Varejola", "924863210", "filipe.pais@RDtelecom.com", "2100-377", "Operador", false, "Santarém", new DateTime(2020, 12, 12), 0, 14);
            GaranteUtilizadores(bd, "Amadeu Lourenço", "187836825", new DateTime(1980, 09, 11), "Louriceira", "920258885", "amadeu.lourenço@RDtelecom.com", "6120-116", "Operador", false, "Santarém", new DateTime(2020, 11, 05), 0, 14);
            GaranteUtilizadores(bd, "Amílcar Oliveira", "116024879", new DateTime(1975, 02, 08), "Estrada Nacional 10", "967862111", "amilcar.oliveira@RDtelecom.com", "2139-503", "Operador", false, "Santarém", new DateTime(2020, 10, 05), 0, 14);
            GaranteUtilizadores(bd, "Luísa Guerra", "194892441", new DateTime(1955, 12, 24), "Casal de Além", "922587456", "luisa.guerra@RDtelecom.com", "2025-150", "Operador", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);
            GaranteUtilizadores(bd, "Afonso Freira", "143171410", new DateTime(1956, 12, 05), "Pisão", "932008521", "afonso.freira@RDtelecom.com", "2230-009", "Operador", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);

            //    //-------------------------- 15 SETUBAL-----------------
            GaranteUtilizadores(bd, "Patrícia Varandas", "159738296", new DateTime(1999, 07, 01), "Praceta Bernardim Ribeiro", "914753951", "patricia.varandas@RDtelecom.com", "2800-002", "Operador", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            GaranteUtilizadores(bd, "Miguel Santos", "115818910", new DateTime(1988, 11, 21), "Praça Doutora Adelaide Coutinho", "960225478", "miguel.santos@RDtelecom.com", "2800-002", "Operador", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            GaranteUtilizadores(bd, "João Ferreira", "125484038", new DateTime(1978, 07, 01), "Rua Bulhão Pato", "926715826", "joao.ferreira@RDtelecom.com", "2800-003", "Operador", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            GaranteUtilizadores(bd, "Tânia Sousa", "120730464", new DateTime(1969, 06, 06), "Rua Capitão Leitão Ímpares", "965874100", "tania-sousa@RDtelecom.com", "2800-137", "Operador", false, "Setúbal", new DateTime(2020, 11, 05), 0, 15);
            GaranteUtilizadores(bd, "Rute Martins", "107984512", new DateTime(1979, 10, 30), "Pátio Albers", "926548222", "rute.martins@RDtelecom.com", "2830-320", "Operador", false, "Setúbal", new DateTime(2020, 12, 11), 0, 15);
            GaranteUtilizadores(bd, "Bernardo Pinto", "140414878", new DateTime(1999, 07, 01), "Travessa do Alto José Ferreira", "960321489", "bernardo.pinto@RDtelecom.com", "2830-381", "Operador", false, "Setúbal", new DateTime(2020, 08, 19), 0, 15); ;
            GaranteUtilizadores(bd, "Paula Neves", "174218990", new DateTime(1999, 07, 01), "Rua da Bandeira", "966999852", "paula.neves@RDtelecom.com", "2830-330", "Operador", false, "Setúbal", new DateTime(2020, 08, 20), 0, 15);
            GaranteUtilizadores(bd, "Miriam Palito", "147726387", new DateTime(2000, 01, 01), "Rua Professor Egas Moniz", "914852684", "miriam.palito@RDtelecom.com", "2830-357", "Operador", false, "Setúbal", new DateTime(2021, 02, 27), 0, 15);
            GaranteUtilizadores(bd, "Vanessa Albino", "188485481", new DateTime(1980, 09, 11), "Rua Fernando de Sousa", "923355874", "vanessa.albino@RDtelecom.com", "2844-001", "Operador", false, "Setúbal", new DateTime(2020, 12, 30), 0, 15);
            GaranteUtilizadores(bd, "Rosa Amarelo", "180639439", new DateTime(1975, 02, 08), "2890-200", "920333658", "rosa.amarelo@RDtelecom.com", "2890-200", "Operador", false, "Setúbal", new DateTime(2020, 11, 05), 0, 02);
            GaranteUtilizadores(bd, "Vanessa Rodrigues", "164580247", new DateTime(1955, 12, 24), "Estrada Nacional 5", "968321450", "vanessa.roduigues@RDtelecom.com", "2959-501", "Operador", false, "Setúbal", new DateTime(2020, 09, 10), 0, 15);
            GaranteUtilizadores(bd, "Afonso Pereira", "178949655", new DateTime(1956, 12, 05), "Monte das Parchanas", "968532000", "afonso.pereira@RDtelecom.com", "7595-002", "Operador", false, "Setúbal", new DateTime(2020, 10, 28), 0, 15);

            //    //-------------------------- 16 VIANA DO CASTELO-----------------
            GaranteUtilizadores(bd, "Pedro Gomes", "283312491", new DateTime(1999, 07, 01), "Largo da Oliveira", "918654654", "pedro.gomes@RDtelecom.com", "4900-003", "Operador", false, "Viana do Castelo", new DateTime(2020, 08, 05), 0, 16);
            GaranteUtilizadores(bd, "Marlene Pereira", "292990308", new DateTime(1988, 11, 21), "Estrada de Santo António", "965888970", "marlene.pereira@RDtelecom.com", "4900-006", "Operador", false, "Viana do Castelo", new DateTime(2020, 10, 05), 0, 16);
            GaranteUtilizadores(bd, "João Ferreira", "237628317", new DateTime(1978, 07, 01), "Largo do Pião", "963210337", "joao.ferreira@RDtelecom.com", "4900-102", "Operador", false, "Viana do Castelo", new DateTime(2020, 11, 05), 0, 16);
            GaranteUtilizadores(bd, "Tânia Sousa", "250558637", new DateTime(1969, 06, 06), "Rua Paula Ferreira", "967520147", "tania-sousa@RDtelecom.com", "4900-862", "Operador", false, "Viana do Castelo", new DateTime(2020, 09, 05), 0, 16);
            GaranteUtilizadores(bd, "Rute Martins", "266466117", new DateTime(1979, 10, 30), "Rua de São Pedro de Areosa", "923117852", "rute.martins@RDtelecom.com", "4900-902", "Operador", false, "Viana do Castelo", new DateTime(2021, 01, 05), 0, 16);
            GaranteUtilizadores(bd, "Luís Bernardo", "296425150", new DateTime(1999, 07, 01), "Travessa dos Sobreiros", "935888723", "luis.bernardo@RDtelecom.com", "4900-914", "Operador", false, "Viana do Castelo", new DateTime(2021, 02, 05), 0, 16);
            GaranteUtilizadores(bd, "Helder Vicente", "286887100", new DateTime(1999, 07, 01), "Rua de Monserrate", "966541112", "helder.vicente@RDtelecom.com", "4904 - 859", "Operador", false, "Viana do Castelo", new DateTime(2020, 11, 17), 0, 16);
            GaranteUtilizadores(bd, "António Santos", "238294749", new DateTime(2000, 01, 01), "Rua Pedro Homem de Melo", "963325559", "antonio.santos@RDtelecom.com", "4904-861", "Operador", false, "Viana do Castelo", new DateTime(2020, 09, 28), 0, 16);
            GaranteUtilizadores(bd, "Célia pimento", "241415659", new DateTime(1980, 09, 11), "Rua Santiago da Barra", "923698777", "celia.pimento@RDtelecom.com", "4904-882", "Operador", false, "Viana do Castelo", new DateTime(2020, 08, 30), 0, 16);
            GaranteUtilizadores(bd, "Paulo Feliz", "291340725", new DateTime(1975, 02, 08), "Estrada de Santa Luzia", "912152033", "paulo.feliz@RDtelecom.com", "4904-858", "Operador", false, "Viana do Castelo", new DateTime(2020, 10, 14), 0, 16);
            GaranteUtilizadores(bd, "Joaquim Guerra", "292585438", new DateTime(1955, 12, 24), "Avenida Capitão Gaspar de Castro", "965321111", "joaquim.guerra@RDtelecom.com", "4904-873", "Operador", false, "Viana do Castelo", new DateTime(2020, 12, 17), 0, 16);
            GaranteUtilizadores(bd, "Afonso Freira", "280477228", new DateTime(1956, 12, 05), "Monterrão", "932654780", "afonso.freira@RDtelecom.com", "4940-003", "Operador", false, "Viana do Castelo", new DateTime(2020, 10, 13), 0, 16);

            //    //-------------------------- 17 VILA REAL-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "226746380", new DateTime(1999, 07, 01), "Passagem", "966987785", "patricia.gomes@RDtelecom.com", "5000-004", "Operador", false, "Vila Real", new DateTime(2020, 08, 05), 0, 17);
            GaranteUtilizadores(bd, "Marlene Santos", "278338682", new DateTime(1988, 11, 21), "Cabana", "932654120", "marlene.satos@RDtelecom.com", "5000-008", "Operador", false, "Vila Real", new DateTime(2020, 10, 05), 0, 17);
            GaranteUtilizadores(bd, "João Ferreira", "242584799", new DateTime(1978, 07, 01), " Camatoga", "925669850", "joao.ferreira@RDtelecom.com", "5040-001", "Operador", false, "Vila Real", new DateTime(2020, 08, 27), 0, 17);
            GaranteUtilizadores(bd, "Tânia Sousa", "203240995", new DateTime(1969, 06, 06), "Porto Rei", "920357892", "tania-sousa@RDtelecom.com", "5040-117", "Operador", false, "Vila Real", new DateTime(2020, 08, 28), 0, 17);
            GaranteUtilizadores(bd, "Rute Martins", "215600061", new DateTime(1979, 10, 30), "Covinhas", "968321025", "rute.martins@RDtelecom.com", "5050-103", "Operador", false, "Vila Real", new DateTime(2020, 10, 05), 0, 17);
            GaranteUtilizadores(bd, "Paulo Pedra", "206368330", new DateTime(1999, 07, 01), "Salgueiral", "925841003", "patricia.gomes@RDtelecom.com", "5050-007", "Operador", false, "Vila Real", new DateTime(2020, 11, 05), 0, 17);
            GaranteUtilizadores(bd, "Helder Copeto", "261055097", new DateTime(1999, 07, 01), "Rua da Barreira", "925632145", "patricia.gomes@RDtelecom.com", "5070-003", "Operador", false, "Vila Real", new DateTime(2021, 01, 05), 0, 17);
            GaranteUtilizadores(bd, "Miriam Falcão", "222266902", new DateTime(2000, 01, 01), "Rua da Ponte Nova", "963221058", "miriam.falcao@RDtelecom.com", "5070-003", "Operador", false, "Vila Real", new DateTime(2020, 12, 05), 0, 17);
            GaranteUtilizadores(bd, "Célia Tomate", "243715790", new DateTime(1980, 09, 11), "Rua Amadeu Necho", "925621489", "celia.tomate@RDtelecom.com", "5070-008", "Operador", false, "Vila Real", new DateTime(2020, 08, 19), 0, 17);
            GaranteUtilizadores(bd, "Tadeu Leão", "233428267", new DateTime(1975, 02, 08), "Estrada Municipal", "962087536", "tadeu.leao@RDtelecom.com", "5070-173", "Operador", false, "Vila Real", new DateTime(2020, 08, 27), 0, 17);
            GaranteUtilizadores(bd, "Harley Guerra", "268256683", new DateTime(1955, 12, 24), "Porto Rei", "923698520", "harley.guerra@RDtelecom.com", "5040-117", "Operador", false, "Vila Real", new DateTime(2020, 08, 01), 0, 17);
            GaranteUtilizadores(bd, "Afonso Freira", "277466563", new DateTime(1956, 12, 05), "Povoação", "938219227", "afonso.freira@RDtelecom.com", "5040-295", "Operador", false, "Vila Real", new DateTime(2020, 11, 05), 0, 17);

            //    //-------------------------- 18 VISEU-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "183894359", new DateTime(1999, 07, 01), "Beco do Areal", "965412200", "patricia.gomes@RDtelecom.com", "3430-505", "Operador", false, "Viseu", new DateTime(2021, 02, 05), 0, 18);
            GaranteUtilizadores(bd, "Marlene Santos", "103467882", new DateTime(1988, 11, 21), "Avenida Madre Rita Amada de Jesus", "928321485", "marlene.satos@RDtelecom.com", "3500-179", "Operador", false, "Viseu", new DateTime(2021, 01, 05), 0, 18);
            GaranteUtilizadores(bd, "João Ferreira", "155241869", new DateTime(1978, 07, 01), "Rua Nova Jugueiros", "965874448", "joao.ferreira@RDtelecom.com", "3500-003", "Operador", false, "Viseu", new DateTime(2020, 08, 05), 0, 18);
            GaranteUtilizadores(bd, "Tânia Sousa", "143563157", new DateTime(1969, 06, 06), "Rua Imaculado Coração de Maria", "932335920", "tania-sousa@RDtelecom.com", "3500-236", "Operador", false, "Viseu", new DateTime(2020, 10, 05), 0, 18);
            GaranteUtilizadores(bd, "Rute Martins", "172309840", new DateTime(1979, 10, 30), "Rua 31 de Janeiro", "935852005", "rute.martins@RDtelecom.com", "3500-217", "Operador", false, "Viseu", new DateTime(2020, 12, 05), 0, 18);
            GaranteUtilizadores(bd, "Paulo Pedra", "182643603", new DateTime(1999, 07, 01), "Rua Viscondessa de São Caetano", "910223658", "patricia.gomes@RDtelecom.com", "3500-185", "Operador", false, "Viseu", new DateTime(2021, 02, 12), 0, 18);
            GaranteUtilizadores(bd, "Helder Copeto", "165569204", new DateTime(1999, 07, 01), "Rua do Hospital", "923620018", "patricia.gomes@RDtelecom.com", "3500-161", "Operador", false, "Viseu", new DateTime(2021, 01, 17), 0, 18);
            GaranteUtilizadores(bd, "Miriam Falcão", "176401890", new DateTime(2000, 01, 01), "Estrada Nacional 16", "968412339", "miriam.falcao@RDtelecom.com", "3519-002", "Operador", false, "Viseu", new DateTime(2020, 11, 28), 0, 18);
            GaranteUtilizadores(bd, "Célia Tomate", "194866360", new DateTime(1980, 09, 11), "Cadraço", "925896552", "celia.tomate@RDtelecom.com", "3475-003", "Operador", false, "Viseu", new DateTime(2020, 10, 25), 0, 18);
            GaranteUtilizadores(bd, "Tadeu Leão", "173792294", new DateTime(1975, 02, 08), "Pedrogão", "921332068", "tadeu.leao@RDtelecom.com", "3475-004", "Operador", false, "Viseu", new DateTime(2020, 12, 17), 0, 18);
            GaranteUtilizadores(bd, "Harley Guerra", "103649492", new DateTime(1955, 12, 24), "Abóboda", "915735255", "harley.guerra@RDtelecom.com", "3475-007", "Operador", false, "Viseu", new DateTime(2020, 11, 09), 0, 18);
            GaranteUtilizadores(bd, "Afonso Freira", "156449307", new DateTime(1956, 12, 05), "Rua Doutor Sebastião Alcantara", "937190258", "afonso.freira@RDtelecom.com", "3534-002", "Operador", false, "Viseu", new DateTime(2021, 03, 14), 0, 18);

            //    //-------------------------- 19 AÇORES-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "120771314", new DateTime(1999, 07, 01), "À Fonseca ", "930005874", "patricia.gomes@RDtelecom.com", "9700-302", "Operador", false, "Açores", new DateTime(2020, 07, 01), 0, 19);
            GaranteUtilizadores(bd, "Marlene Santos", "137971443", new DateTime(1988, 11, 21), "Outeiro de São Mateus", "965320005", "marlene.satos@RDtelecom.com", "9700-305", "Operador", false, "Açores", new DateTime(2021, 01, 01), 0, 19);
            GaranteUtilizadores(bd, "João Ferreira", "152267387", new DateTime(1978, 07, 01), "Presas", "961742008", "joao.ferreira@RDtelecom.com", "9700-308", "Operador", false, "Açores", new DateTime(2020, 09, 01), 0, 19);
            GaranteUtilizadores(bd, "Tânia Sousa", "142615889", new DateTime(1969, 06, 06), "Rua Nova", "961325698", "tania-sousa@RDtelecom.com", "9700-132", "Operador", false, "Açores", new DateTime(2020, 12, 10), 0, 19);
            GaranteUtilizadores(bd, "Rute Martins", "144505665", new DateTime(1979, 10, 30), "Praça Doutor Sousa Júnior ", "930014789", "rute.martins@RDtelecom.com", "9700-007", "Operador", false, "Açores", new DateTime(2020, 10, 11), 0, 19);
            GaranteUtilizadores(bd, "Paulo Pedra", "167301900", new DateTime(1999, 07, 01), "Abaixo do Fragoso", "965874123", "patricia.gomes@RDtelecom.com", "9880-101", "Operador", false, "Açores", new DateTime(2020, 12, 28), 0, 19);
            GaranteUtilizadores(bd, "Helder Copeto", "174189800", new DateTime(1999, 07, 01), "Bairro do Carrapacho", "91523321", "patricia.gomes@RDtelecom.com", "9880-120", "Operador", false, "Açores", new DateTime(2020, 11, 01), 0, 19);
            GaranteUtilizadores(bd, "Miriam Falcão", "139100873", new DateTime(2000, 01, 01), "Bacelo", "925879411", "miriam.falcao@RDtelecom.com", "9880-103", "Operador", false, "Açores", new DateTime(2020, 07, 16), 0, 19);
            GaranteUtilizadores(bd, "Célia Tomate", "174957050", new DateTime(1980, 09, 11), "Avenida Mousinho de Albuquerque", "926557201", "celia.tomate@RDtelecom.com", "9880-999", "Operador", false, "Açores", new DateTime(2020, 09, 21), 0, 19);
            GaranteUtilizadores(bd, "Tadeu Leão", "119348470", new DateTime(1975, 02, 08), "Pedras Brancas", "961741211", "tadeu.leao@RDtelecom.com", "9880-171", "Operador", false, "Açores", new DateTime(2020, 09, 05), 0, 19);
            GaranteUtilizadores(bd, "Harley Guerra", "117424919", new DateTime(1955, 12, 24), "Fajã da Isabel Pereira", "911577821", "harley.guerra@RDtelecom.com", "9800-101", "Operador", false, "Açores", new DateTime(2020, 10, 01), 0, 19);
            GaranteUtilizadores(bd, "Afonso Freira", "107167727", new DateTime(1956, 12, 05), "Ribeira D'Água", "937888541", "afonso.freira@RDtelecom.com", "9800-209", "Operador", false, "Açores", new DateTime(2021, 02, 05), 0, 19);

            //    //-------------------------- 20 MADEIRA-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "113150814", new DateTime(1999, 07, 01), "Caminho Ribeira dos Socorridos ", "965321002", "patricia.gomes@RDtelecom.com", "9000-617", "Operador", false, "Madeira" , new DateTime(2020, 07, 01), 0, 20);
            GaranteUtilizadores(bd, "Marlene Santos", "184785715", new DateTime(1988, 11, 21), "2ª Travessa Caminho Arieiro de Baixo", "938520366", "marlene.satos@RDtelecom.com", "9000-602", "Operador", false, "Madeira", new DateTime(2020, 08, 01), 0, 20);
            GaranteUtilizadores(bd, "João Ferreira", "170288900", new DateTime(1978, 07, 01), "Azinhaga Vargem", "968741250", "joao.ferreira@RDtelecom.com", "9000-730", "Operador", false, "Madeira", new DateTime(2021, 01, 01), 0, 20);
            GaranteUtilizadores(bd, "Tânia Sousa", "129628522", new DateTime(1969, 06, 06), "Avenida Colégio Militar ", "912335620", "tania-sousa@RDtelecom.com", "9000-996", "Operador", false, "Madeira", new DateTime(2021, 02, 01), 0, 20);
            GaranteUtilizadores(bd, "Rute Martins", "137275862", new DateTime(1979, 10, 30), "Beco Virtudes", "927415620", "rute.martins@RDtelecom.com", "9000-616", "Operador", false, "Madeira", new DateTime(2020, 09, 21), 0, 20);
            GaranteUtilizadores(bd, "Paulo Pedra", "100247520", new DateTime(1999, 07, 01), "Caminho Arieiro", "965327882", "patricia.gomes@RDtelecom.com", "9000-243 ", "Operador", false, "Madeira", new DateTime(2020, 10, 28), 0, 20);
            GaranteUtilizadores(bd, "Helder Copeto", "127523502", new DateTime(1999, 07, 01), "Rua Hospital Velho", "924710655", "patricia.gomes@RDtelecom.com", "9064-507", "Operador", false, "Madeira", new DateTime(2020, 11, 28), 0, 20);
            GaranteUtilizadores(bd, "Miriam Falcão", "172885205", new DateTime(2000, 01, 01), "Rua Nova Rochinha", "974521333", "miriam.falcao@RDtelecom.com", "9064-509", "Operador", false, "Madeira", new DateTime(2020, 12, 17), 0, 20);
            GaranteUtilizadores(bd, "Célia Tomate", "170898610", new DateTime(1980, 09, 11), "Travessa Contracta e Corujeira", "965824110", "celia.tomate@RDtelecom.com", "9125-003", "Operador", false, "Madeira", new DateTime(2020, 09, 10), 0, 20);
            GaranteUtilizadores(bd, "Tadeu Leão", "169789560", new DateTime(1975, 02, 08), "Estrada do Garajau Vargem", "932226987", "tadeu.leao@RDtelecom.com", "9125-253", "Operador", false, "Madeira", new DateTime(2021, 02, 10), 0, 20);
            GaranteUtilizadores(bd, "Harley Guerra", "139861750", new DateTime(1955, 12, 24), "Rua Abegoaria", "915738522", "harley.guerra@RDtelecom.com", "9125-122", "Operador", false, "Madeira", new DateTime(2020, 12, 08), 0, 20);
            GaranteUtilizadores(bd, "Afonso Freira", "158218310", new DateTime(1956, 12, 05), "Cruz", "932165420", "afonso.freira@RDtelecom.com", "9225-007", "Operador", false, "Madeira", new DateTime(2020, 12, 12), 0, 20);

            //    GaranteUtilizadores(bd, "Paulo Pimentel", "234018283", new DateTime(2001, 12, 02), "Estrada Marmeleiros Ímpares", "966632147", "paulo.pimentel@RDtelecom.com", "9050-216", "Operador", false, 20);
            //    GaranteUtilizadores(bd, "Maria Silva", "293714630", new DateTime(2001, 09, 09), "Vinha Brava", "960201333", "maria.silva@RDtelecom.com", "9701-872", "Operador", false, 19);





            //    GaranteUtilizadores(bd, "Pedro Machado", "212545585", new DateTime(1971, 07, 14), "Colónia Agrícola Casal 63", "935559453", "pedromachado@gmail.com", "3870-358", "Cliente", false, 14);
            //    GaranteUtilizadores(bd, "Joaquim Mendez", "532344565", new DateTime(1987, 12, 24), "R Indústria Porta 47", "915556899", "joaquimmendez@outlook.com", "3300-040", "Cliente", false, 15);
            //    GaranteUtilizadores(bd, "Sandra Vieira", "221344545", new DateTime(1977, 02, 23), "R Poeta João Ruiz 6", "929355531", "sandravieira@gmail.com", "6230-355", "Cliente", false, 16);
            //    GaranteUtilizadores(bd, "Sara Siqueira", "543333222", new DateTime(1977, 01, 22), "R Doutor Alfredo Freitas 108", "915551820", "sarasiqueiraa@gmail.com", "3700-501", "Cliente", false, 17);
            //    GaranteUtilizadores(bd, "Nelson Ramos", "321123456", new DateTime(1945, 07, 10), "R Indústria Porta 56", "929455563", "nelsonramos@outlook.com", "3220-066", "Cliente", false, 18);
            //    GaranteUtilizadores(bd, "Danilo Pires", "332223455", new DateTime(1999, 06, 26), "Rua Jorge Sena 99", "965559604", "danilopires@live.com", "2650-499", "Cliente", false, 19);
            //    GaranteUtilizadores(bd, "Mônica Torres", "344321789", new DateTime(1976, 02, 05), "Avenida Guerra Junqueiro 114", "921555922", "monicatorres@gmail.com", "2610-116", "Cliente", false, 20);
            //    GaranteUtilizadores(bd, "Daniela Mata", "698767555", new DateTime(1974, 03, 13), "R Portela 64", "915551704", "daielamata@gmail.com", "3550-171", "Cliente", false, 3);
            //    GaranteUtilizadores(bd, "Virgílio Abreu", "678567454", new DateTime(1987, 04, 16), "R Padre João A L Ribeiro 88", "915559352", "virgilio_abreu@outlook.com", "3440-376", "Cliente", false, 2);
            //    GaranteUtilizadores(bd, "Amável Pinto", "259149179", new DateTime(1966, 08, 27), "Rua da Mãe de Água", "910070026", "pinto_amavel@outlook.com", "4805-276", "Cliente", false, 1);
            //    GaranteUtilizadores(bd, "António Pechincha", "214118959", new DateTime(2000, 07, 19), "Rua das Alminhas", "912333480", "antonio.pechincha@outlook.com", "4815-159", "Cliente", false, 21);
            //    GaranteUtilizadores(bd, "José Machuca", "272659886", new DateTime(1966, 04, 15), "Além do Rio", "966654789", "jose.machuca@live.com", "4860-121", "Cliente", false, 3);
            //    GaranteUtilizadores(bd, "Luís Cabrita", "296644307", new DateTime(1974, 10, 03), "Rua de Cartas", "961728395", "cabrita.luis@live.com", "4765-417", "Cliente", false, 3);
            //    GaranteUtilizadores(bd, "Miguel do Amaral", "219048401", new DateTime(1955, 07, 09), "Pedra Chã", "929229647", "miguel.amaral@gmail.com", "4850-144", "Cliente", false, 3);
            //    GaranteUtilizadores(bd, "Carla Mamona", "221888012", new DateTime(1967, 01, 01), "Avenida Conde de Margaride", "969171654", "carla.mamona@live.com", "4839-001", "Cliente", false, 3);
            //    GaranteUtilizadores(bd, "Celeste Pires", "270559299", new DateTime(1980, 05, 01), "Rua do Picôto São Paio", "917854369", "celeste.pires@hotmail.com", "4800-006", "Cliente", false, 3);
            //    GaranteUtilizadores(bd, "Filipe Gil", "298022699", new DateTime(1928, 05, 03), "Avenida 9 de Julho", "929455556", "filipe_gil@gmail.com", "4760-831", "Cliente", false, 3);
            //    GaranteUtilizadores(bd, "Vitória Rodrigues", "293958033", new DateTime(1994, 01, 10), "R Poeta João Ruiz 90", "931478962", "vitoria_rodrigues@gmail.com", "6230-691", "Cliente", false, 3);
            //    GaranteUtilizadores(bd, "André Pereira", "204357039", new DateTime(1969, 06, 09), "Travessa da Boca Antas", "919474456", "andre_pereira@live.com", "4760-870", "Cliente", false, 3);
            //    GaranteUtilizadores(bd, "Pedro Guedes", "230045359", new DateTime(1955, 07, 09), "Rua Mata da Naia Gondizalves", "967455521", "pedro.l.guedes@gmail.com", "4700-183", "Cliente", false, 3);
            //    GaranteUtilizadores(bd, "Luísa Lourenço", "253438691", new DateTime(1974, 11, 24), "Rua do Muro Dume", "912675574", "l.loureco@hotmail.com", "4700-397 ", "Cliente", false, 3);
            //    GaranteUtilizadores(bd, "Suzete Farinha", "249712768", new DateTime(1930, 03, 15), "Cangosta do Pulo Dume", "921257556", "suzete.farinha@gmail.com", "4700-007", "Cliente", false, 3);
            //    GaranteUtilizadores(bd, "Manuel dos Descobrimentos", "248776304", new DateTime(2002, 03, 15), "Azinhaga Casa Branca", "919154001", "manuel.descobrimentos@gmail.com", "9004-543", "Cliente", false, 19);
            //    GaranteUtilizadores(bd, "Gonçalo Velho ", "202733122", new DateTime(2002, 05, 15), "Largo dos Remédios", "968523147", "velho.goncalo@gmail.com", "9701-855", "Cliente", false, 20);


        }

        private static Utilizadores GaranteUtilizadores(Projeto_Lab_WebContext bd, string nome, string nif, DateTime datanascimento,
            string morada, string telemovel, string email, string codigopostal, string role, bool inactivo, string concelho, DateTime dataativacao, int pontos, int distrito)
        {
            Utilizadores utilizadores = bd.Utilizadores.FirstOrDefault(c => c.Nome == nome);
            if (utilizadores == null)
            {
                utilizadores = new Utilizadores { Nome = nome, Nif = nif, DataNascimento = datanascimento, Morada = morada, Telemovel = telemovel, Email = email, CodigoPostal = codigopostal, Role = role, Inactivo = inactivo, Concelho = concelho, DataAtivacao = dataativacao, Pontos=pontos, DistritosId = distrito };
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
        //-------------------DISTRITOS-----------------------------------


        private static void InsereDistritos(Projeto_Lab_WebContext bd)
        {
            GaranteDistritos(bd,  "Aveiro");
            GaranteDistritos(bd,  "Beja");
            GaranteDistritos(bd,  "Braga");
            GaranteDistritos(bd,  "Bragança");
            GaranteDistritos(bd, "Castelo Branco");
            GaranteDistritos(bd, "Coimbra");
            GaranteDistritos(bd, "Évora");
            GaranteDistritos(bd, "Faro");
            GaranteDistritos(bd, "Guarda");
            GaranteDistritos(bd, "Leiria");
            GaranteDistritos(bd, "Lisboa");
            GaranteDistritos(bd, "Portalegre");
            GaranteDistritos(bd, "Porto");
            GaranteDistritos(bd, "Santarém");
            GaranteDistritos(bd, "Setúbal");
            GaranteDistritos(bd, "Viana do Castelo");
            GaranteDistritos(bd, "Vila Real");
            GaranteDistritos(bd, "Viseu");
            GaranteDistritos(bd, "Açores");
            GaranteDistritos(bd, "Madeira");
        }

        private static Distritos GaranteDistritos(Projeto_Lab_WebContext bd,  string nome)
        {
            Distritos distritos = bd.Distritos.FirstOrDefault(e => e.Nome == nome);
            if (distritos == null)
            {
                distritos = new Distritos(){  Nome = nome };
                bd.Distritos.Add(distritos);
                bd.SaveChanges();
            }
            return distritos;

        }

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


            var pacoteRD4 = GarantePacotes(bd, "Pacote RD4", 55, "O pacote RD4 destacou-se por apresentar a melhor relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade", false, new DateTime(2021, 03, 01), 1);
            var pacoteRD3 = GarantePacotes(bd, "Pacote RD3", 45, "O pacote RD3 destacou-se por apresentar a uma ótima relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade para quem não quer ter um telemóvel associado ao pacote.", false, new DateTime(2021, 03, 01), 1);
            var pacoteRDGaming = GarantePacotes(bd, "Pacote RD - Gaming", 55, "A oferta Pacote RD - Gaming é ideal para", false, new DateTime(2021, 03, 01), 1);
            var pacoteRDGPremium = GarantePacotes(bd, "Pacote RD - TV Premium + gaming", 65, "A oferta Pacote RD - TV Premium + gaming destacou - se na categoria de “Melhor pacote para Gaming” por apresentar a melhor relação ao nível do número de canais dedicado ao universo cinematográfico(canais base, exclusivos e premium) face ao custo mensal, bem como uma internet de alta velocidade para não haver falhas durante os jogos.", false, new DateTime(2021, 03, 01), 1);
            var pacoteTvVoz = GarantePacotes(bd, "RD TV e Voz", 25, "Este Pacote RD TV e Voz é ideal para os clientes que querem ver televisão", false, new DateTime(2021, 03, 01), 1);
            var pacoteRDFamiliar = GarantePacotes(bd, "RD Familiar", 45, "Pacote ideal para os momentos de lazer em família.", false, new DateTime(2021, 03, 01), 1);

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
            GarantePacotes(bd, "Pacote RD4", 55, "O pacote RD4 destacou-se por apresentar a melhor relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade", false, new DateTime(2021, 03, 01), 1);
            GarantePacotes(bd, "Pacote RD3", 45, "O pacote RD3 destacou-se por apresentar a uma ótima relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade para quem não quer ter um telemóvel associado ao pacote.", false, new DateTime(2021, 03, 01), 1);
            GarantePacotes(bd, "Pacote RD - Gaming", 55, "O pacote indicado para quem procura uma internet forte e estável. Sem LAG! Sem delay! Apenas, a melhor internet ao preço mais acessivel!", false, new DateTime(2021, 03, 01), 1);
            GarantePacotes(bd, "Pacote RD - TV Premium", 65, "O pack Premium é o pacote mais completo que temos! Tendo mais de 180 canais disponiveis, velocidades de Download e Upload imabtíveis, chamadas fixas e para numeros estrangeiros sem custos associados e ainda até 4 cartões de telemovel associados que podem ter até 10GB de dados móveis cada!", false, new DateTime(2021, 03, 01), 1);
            GarantePacotes(bd, "RD TV e Voz", 25, "Um pack simples seja para ter acesso aos nossos canais exclusivos ou beneficiar das nossas incriveis promoções em chamadas!", false, new DateTime(2021, 03, 01), 1);
            GarantePacotes(bd, "RD Familiar", 45, "O pacote indicado para toda a familia! Desde uma variedade de canais, até à melhor velocidade de internet no mercado, até aos diferentes plafonds de telemovel que procura, este é o pacote ideal!", false, new DateTime(2021, 03, 01), 1);
        }
        private static Pacotes GarantePacotes(Projeto_Lab_WebContext bd, string nome, decimal preco, string descricao, bool inactivo, DateTime dataInicio, int distrito)
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
                    DistritosId = distrito

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

            var pacoteRD4 = GarantePacotes(bd, "Pacote RD4", 55, "O pacote RD4 destacou-se por apresentar a melhor relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade", false, new DateTime(2021, 03, 01), 1);
            var pacoteRD3 = GarantePacotes(bd, "Pacote RD3", 45, "O pacote RD3 destacou-se por apresentar a uma ótima relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade para quem não quer ter um telemóvel associado ao pacote.", false, new DateTime(2021, 03, 01), 1);
            var pacoteRDGaming = GarantePacotes(bd, "Pacote RD - Gaming", 55, "A oferta Pacote RD - Gaming é ideal para", false, new DateTime(2021, 03, 01), 1);
            var pacoteRDGPremium = GarantePacotes(bd, "Pacote RD - TV Premium + gaming", 65, "A oferta Pacote RD - TV Premium + gaming destacou - se na categoria de “Melhor pacote para Gaming” por apresentar a melhor relação ao nível do número de canais dedicado ao universo cinematográfico(canais base, exclusivos e premium) face ao custo mensal, bem como uma internet de alta velocidade para não haver falhas durante os jogos.", false, new DateTime(2021, 03, 01), 1);
            var pacoteTvVoz = GarantePacotes(bd, "RD TV e Voz", 25, "Este Pacote RD TV e Voz é ideal para os clientes que querem ver televisão", false, new DateTime(2021, 03, 01), 1);
            var pacoteRDFamiliar = GarantePacotes(bd, "RD Familiar", 45, "Pacote ideal para os momentos de lazer em família.", false, new DateTime(2021, 03, 01), 1);

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

         

          

            var pedro = GaranteUtilizadores(bd, "Pedro Machado", "212545585", new DateTime(1971, 07, 14), "Colónia Agrícola Casal 63", "935559453", "pedromachado@gmail.com", "3870-358", "Cliente", false, "Anadia", new DateTime(2020, 01, 01), 0, 14);
            var joaquim = GaranteUtilizadores(bd, "Joaquim Mendez", "532344565", new DateTime(1987, 12, 24), "R Indústria Porta 47", "915556899", "joaquimmendez@outlook.com", "3300-040", "Cliente", false, "Anadia", new DateTime(2020, 01, 01), 0, 15);
            var sandra = GaranteUtilizadores(bd, "Sandra Vieira", "221344545", new DateTime(1977, 02, 23), "R Poeta João Ruiz 6", "929355531", "sandravieira@gmail.com", "6230-355", "Cliente", false, "Anadia", new DateTime(2020, 01, 01), 0, 16);
            var sara = GaranteUtilizadores(bd, "Sara Siqueira", "543333222", new DateTime(1977, 01, 22), "R Doutor Alfredo Freitas 108", "915551820", "sarasiqueiraa@gmail.com", "3700-501", "Cliente", false, "Anadia", new DateTime(2020, 01, 01), 0, 17);
            var nelson = GaranteUtilizadores(bd, "Nelson Ramos", "321123456", new DateTime(1945, 07, 10), "R Indústria Porta 56", "929455563", "nelsonramos@outlook.com", "3220-066", "Cliente", false, "Anadia", new DateTime(2020, 01, 01), 0, 18);
            var danilo = GaranteUtilizadores(bd, "Danilo Pires", "332223455", new DateTime(1999, 06, 26), "Rua Jorge Sena 99", "965559604", "danilopires@live.com", "2650-499", "Cliente", false, "Anadia", new DateTime(2020, 01, 01), 0, 19);
            var monica = GaranteUtilizadores(bd, "Mônica Torres", "344321789", new DateTime(197, 02, 05), "Avenida Guerra Junqueiro 114", "921555922", "monicatorres@gmail.com", "2610-116", "Cliente", false, "Anadia", new DateTime(2020, 01, 01), 0, 20);
            var daniela = GaranteUtilizadores(bd, "Daniela Mata", "698767555", new DateTime(1974, 03, 13), "R Portela 64", "915551704", "daielamata@gmail.com", "3550-171", "Cliente", false, "Anadia", new DateTime(2020, 01, 01), 0, 3);
            var virgilio = GaranteUtilizadores(bd, "Virgílio Abreu", "678567454", new DateTime(1987, 04, 16), "R Padre João A L Ribeiro 88", "915559352", "virgilio_abreu@outlook.com", "3440-376", "Cliente", false, "Anadia", new DateTime(2020, 01, 01), 0, 2);
            var martim = GaranteUtilizadores(bd, "Martim Moniz", "612345432", new DateTime(1984, 08, 15), "R Poeta João Ruiz 90", "929455556", "martim_moniz@live.com", "6230-691", "Cliente", false, "Anadia", new DateTime(2020, 01, 01), 0, 1);

            var operador1 = GaranteUtilizadores(bd, "Nuno Forte", "255255212", new DateTime(1998, 09, 29), "Rua das Flores", "925258737", "nuno_rpf@RDtelecom.com", "6300-706", "Operador", false, "Anadia", new DateTime(2020, 01, 01), 0, 4);
            var operador2 = GaranteUtilizadores(bd, "João Matos", "224443321", new DateTime(1970, 04, 21), "Rua da Maurícia Aradas", "965111755", "joao_matos@RDtelecom.com", "3810-433", "Operador", false, "Anadia", new DateTime(2020, 01, 01), 0, 5);
            var operador3 = GaranteUtilizadores(bd, "Maria de Fátima", "256678987", new DateTime(1963, 02, 02), "Rua da Prata", "927895737", "m.fatima@RDtelecom.com", "1149-005", "Operador", false, "Anadia", new DateTime(2020, 01, 01), 0, 6);

            var pacoteRD4 = GarantePacotes(bd, "Pacote RD4", 55, "O pacote RD4 destacou-se por apresentar a melhor relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade", false, new DateTime(2021, 03, 01),1);
            var pacoteRD3 = GarantePacotes(bd, "Pacote RD3", 45, "O pacote RD3 destacou-se por apresentar a uma ótima relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade para quem não quer ter um telemóvel associado ao pacote.", false, new DateTime(2021, 03, 01),1);
            var pacoteRDGaming = GarantePacotes(bd, "Pacote RD - Gaming", 55, "A oferta Pacote RD - Gaming é ideal para", false, new DateTime(2021, 03, 01),1);
            var pacoteRDGPremium = GarantePacotes(bd, "Pacote RD - TV Premium + gaming", 65, "A oferta Pacote RD - TV Premium + gaming destacou - se na categoria de “Melhor pacote para Gaming” por apresentar a melhor relação ao nível do número de canais dedicado ao universo cinematográfico(canais base, exclusivos e premium) face ao custo mensal, bem como uma internet de alta velocidade para não haver falhas durante os jogos.", false, new DateTime(2021, 03, 01), 1);
            var pacoteTvVoz = GarantePacotes(bd, "RD TV e Voz", 25, "Este Pacote RD TV e Voz é ideal para os clientes que querem ver televisão", false, new DateTime(2021, 03, 01), 1);
            var pacoteRDFamiliar = GarantePacotes(bd, "RD Familiar", 45, "Pacote ideal para os momentos de lazer em família.", false, new DateTime(2021, 03, 01), 1);


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

