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
        private const string NOME_UTILIZADOR_CLIENTE_FICTICIO = "cliente@RD-Telecom.com";

        private const string ROLE_ADIMINISTRADOR = "Administrador";
        private const string ROLE_CLIENTE = "Cliente";
        private const string ROLE_OPERADOR = "Operador";

        internal static void PreencheDados(Projeto_Lab_WebContext bd)
        {
            InsereDistritos(bd);
            InserePromocoes(bd);
            InsereTiposServicos(bd);
            InsereServicos(bd);
            InsereUtilizadores(bd);
            InserePacotes(bd);
            InsereServicosPacotes(bd);
            InserePromocoesPacotes(bd);
            //InsereReclamacoes(bd);

            //InsereContratos(bd);
            //InsereTiposClientes(bd);
            //InsereRoles(bd);

        }
        private static void InsereUtilizadores(Projeto_Lab_WebContext bd)
        {

            //---------------CLIENTES--------------------

            //    //-------------------------- 1 AVEIRO------------------
            GaranteUtilizadores(bd, "Eduardo Pires", "237051974", new DateTime(2000, 01, 19), "Sargento Mor", "921233367", "eduardo.pires@RD-Telecom.com", "3020-740", "Cliente", false, "Aveiro", new DateTime(2020, 08, 05), 0, 1);
            GaranteUtilizadores(bd, "Glória da Ascenção", "220613710", new DateTime(1988, 09, 21), "Rua Fernando Caldeira", "937654441", "gloria.ascencao@RD-Telecom.com", "3754-501", "Cliente", false, "Aveiro", new DateTime(2020, 12, 12), 0, 1);
            GaranteUtilizadores(bd, "Maria Aparecida", "287253333", new DateTime(1977, 10, 01), "Rua Doutor Tomás Aquino", "927411189", "maria.aparecida@RD-Telecom.com", "3800-523", "Cliente", false, "Aveiro", new DateTime(2020, 10, 15), 0, 1);
            GaranteUtilizadores(bd, "Bernardo Ribeiro", "291231438", new DateTime(1969, 03, 25), "Avenida Manuel Álvaro Lopes Pereira", "929662587", "bernado.ribeiro@RD-Telecom.com", "3800-625", "Cliente", false, "Aveiro", new DateTime(2020, 10, 17), 0, 1);
            GaranteUtilizadores(bd, "Amadeu Almeida", "249861585", new DateTime(1979, 07, 16), "Avenida do Doutor Lourenço Peixinho", "921212245", "amadeu.almeida@RD-Telecom.com", "3804-501", "Cliente", false, "Aveiro", new DateTime(2020, 12, 28), 0, 1);
            GaranteUtilizadores(bd, "José Socrates", "269768807", new DateTime(1958, 05, 05), "Viela da Capela", "920128801", "jose.socrates@RD-Telecom.com", "3810-002", "Cliente", false, "Aveiro", new DateTime(2020, 08, 17), 0, 1);
            GaranteUtilizadores(bd, "Ana Brito", "243552530", new DateTime(2000, 09, 04), "Rua do Jardim", "929630030", "ana.brito@RD-Telecom.com", "3054-001", "Cliente", false, "Aveiro", new DateTime(2020, 08, 19), 0, 1);
            GaranteUtilizadores(bd, "Luís Neto", "205291546", new DateTime(1985, 04, 04), "Avenida Comendador Augusto Martins Pereira", "920256647", "luis.neto@RD-Telecom.com", "3744-002", "Cliente", false, "Aveiro", new DateTime(2020, 08, 28), 0, 1);
            GaranteUtilizadores(bd, "Freitas do Mondego", "286228831", new DateTime(1975, 02, 08), "Rua do Murtório Rochico ", "961557784", "freitas.mondego@RD-Telecom.com", "3865-299", "Cliente", false, "Aveiro", new DateTime(2020, 10, 02), 0, 1);
            GaranteUtilizadores(bd, "João Cardoso", "266992528", new DateTime(1958, 12, 27), "Travessa da Lomba", "923298822", "joao.cardoso@RD-Telecom.com", "3865-003", "Cliente", false, "Aveiro", new DateTime(2021, 01, 05), 0, 1); ;
            //GaranteUtilizadores(bd, "Rita de Brandão", "204161746", new DateTime(1956, 08, 27), "Largo 5 de Outubro Jardim dos Campos Pares", "929985574", "rita.brandao1@RD-Telecom.com", "3880-006", "Cliente", false, "Aveiro", new DateTime(2021, 02, 05), 0, 1);
            //GaranteUtilizadores(bd, "Rita de Brandão2", "510065112", new DateTime(1956, 08, 27), "Largo 5 de Outubro Jardim dos Campos Pares", "929985575", "rita.brandao2@RD-Telecom.com", "3880-007", "Cliente", false, "Aveiro", new DateTime(2021, 02, 05), 0, 1);
            //GaranteUtilizadores(bd, "Rita de Brandão3", "509688977", new DateTime(1956, 08, 27), "Largo 5 de Outubro Jardim dos Campos Pares", "929985576", "rita.brandao3@RD-Telecom.com", "3880-008", "Cliente", false, "Aveiro", new DateTime(2021, 02, 05), 0, 1);
            //GaranteUtilizadores(bd, "Rita de Brandão4", "508948576", new DateTime(1956, 08, 27), "Largo 5 de Outubro Jardim dos Campos Pares", "929985577", "rita.brandao4@RD-Telecom.com", "3880-009", "Cliente", false, "Aveiro", new DateTime(2021, 02, 05), 0, 1);


            //    //-------------------------- 2 BEJA------------------
            GaranteUtilizadores(bd, "Ramos de Oliveira", "234325003", new DateTime(2001, 01, 19), "Beco da Rua Acima", "963125884", "eduardo.pires@RD-Telecom.com", "7960-002", "Cliente", false, "Beja", new DateTime(2021, 01, 05), 0, 2);
            GaranteUtilizadores(bd, "Catarina Alves", "274113490", new DateTime(1995, 09, 21), "Marmelar", "932789991", "gloria.ascencao@RD-Telecom.com", "7960-001", "Cliente", false, "Beja", new DateTime(2020, 10, 17), 0, 2);
            GaranteUtilizadores(bd, "Rui del Nascimiento", "255721188", new DateTime(1965, 10, 11), "Rua Longa", "921029661", "maria.aparecida@RD-Telecom.com", "7940-160", "Cliente", false, "Beja", new DateTime(2020, 10, 25), 0, 2);
            GaranteUtilizadores(bd, "Vasco Barreiros", "296928135", new DateTime(1962, 02, 25), "Avenida Manuel Álvaro Lopes Pereira", "927477781", "bernado.ribeiro@RD-Telecom.com", "3800-625", "Cliente", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            GaranteUtilizadores(bd, "Mário Botelho", "222784261", new DateTime(1987, 07, 16), "Albergaria dos Fusos", "923148000", "amadeu.almeida@RD-Telecom.com", "7940-411", "Cliente", false, "Beja", new DateTime(2020, 08, 26), 0, 2);
            GaranteUtilizadores(bd, "Lula de La Cruz", "227929160", new DateTime(1958, 04, 05), "Rua dos Lobos", "932951883", "jose.socrates@RD-Telecom.com", "7920-005", "Cliente", false, "Beja", new DateTime(2020, 08, 28), 0, 2);
            GaranteUtilizadores(bd, "Paula Piruvato", "213154145", new DateTime(1992, 09, 04), "Largo dos Cadeirões", "935777153", "ana.brito@RD-Telecom.com", "7920-002", "Cliente", false, "Beja", new DateTime(2021, 02, 28), 0, 2);
            GaranteUtilizadores(bd, "Thomas Lourenço", "244040737", new DateTime(1979, 04, 06), "Praça do Ultramar", "928969741", "luis.neto@RD-Telecom.com", "7801-857", "Cliente", false, "Beja", new DateTime(2020, 10, 28), 0, 2);
            GaranteUtilizadores(bd, "Luís Smith", "206451326", new DateTime(1975, 06, 08), "Moitinhas", "960155584", "freitas.mondego@RD-Telecom.com", "7665-803", "Cliente", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            GaranteUtilizadores(bd, "Márcia Wood", "226962938", new DateTime(1972, 11, 27), "Ribeira de Torquinhos", "921733321", "joao.cardoso@RD-Telecom.com", "7665-814", "Cliente", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            GaranteUtilizadores(bd, "Jerónimo Graciano", "294559604", new DateTime(1956, 05, 22), "Rua da Cova da Burra", "928999965", "rita.brandao@RD-Telecom.com", "7700-003", "Cliente", false, "Beja", new DateTime(2021, 01, 05), 0, 2);

            //    //-------------------------- 3 BRAGA------------------
            GaranteUtilizadores(bd, "Fernando Couto", "379524520", new DateTime(1977, 03, 19), "Rua dos Bombeiros Voluntários", "960999231", "fernado.couto@RD-Telecom.com", "4700-002", "Cliente", false, "Braga", new DateTime(2020, 12, 05), 0, 3);
            GaranteUtilizadores(bd, "Deolinda Bacalhau", "311778135", new DateTime(2001, 05, 21), "Rua Professora Alda Brandão Real", "938784787", "deolinda.bacalhau@RD-Telecom.com", "4700-002", "Cliente", false, "Braga", new DateTime(2020, 11, 17), 0, 3);
            GaranteUtilizadores(bd, "Ivanilda Pessoa", "398444773", new DateTime(1977, 08, 01), "Rua da Sobreira Frossos", "923088821", "ivanilda.pessoa@RD-Telecom.com", "4700-441", "Cliente", false, "Braga", new DateTime(2020, 12, 26), 0, 3);
            GaranteUtilizadores(bd, "Onofre Galvão", "314065806", new DateTime(1969, 04, 30), "Largo de Maximinos", "928777413", "onofre.galvao@RD-Telecom.com", "4700-999", "Cliente", false, "Braga", new DateTime(2020, 12, 10), 0, 3);
            GaranteUtilizadores(bd, "Ian Coelho", "349413444", new DateTime(2002, 01, 31), "Largo de São Tiago", "92577963", "ian.coelho@RD-Telecom.com", "4704-504", "Cliente", false, "Braga", new DateTime(2020, 11, 05), 0, 3);
            GaranteUtilizadores(bd, "Ryan Oliveira", "304309028", new DateTime(1988, 03, 05), "Rua das Oliveiras", "920324433", "ryan.oliveira@RD-Telecom.com", "4705-790", "Cliente", false, "Braga", new DateTime(2020, 11, 28), 0, 3);
            GaranteUtilizadores(bd, "Marizete Gillot", "351103988", new DateTime(1956, 10, 04), "Rua dos Caixoteiros", "922008889", "marizete.gillot@RD-Telecom.com", "4705-001", "Cliente", false, "Braga", new DateTime(2020, 10, 07), 0, 3);
            GaranteUtilizadores(bd, "Beto da Alegria", "381587959", new DateTime(1957, 03, 17), "Rua Sem Nome", "925599841", "beto.alegria@RD-Telecom.com", "4750-008", "Cliente", false, "Braga", new DateTime(2021, 01, 05), 0, 3);
            GaranteUtilizadores(bd, "Pinheiro dos Santos", "328112283", new DateTime(1970, 02, 28), "Travessa do Rio da Guarda", "921113288", "pinheiro.santos@RD-Telecom.com", "4765-489", "Cliente", false, "Braga", new DateTime(2021, 02, 05), 0, 3);
            GaranteUtilizadores(bd, "Divina de Jesus", "104815809", new DateTime(1958, 11, 30), "Rua Cães de Pedra Lt 5", "921786632", "divina.jesus@RD-Telecom.com", "4835-003", "Cliente", false, "Braga", new DateTime(2021, 02, 12), 0, 3);
            GaranteUtilizadores(bd, "Irina Leite", "169622398", new DateTime(1999, 10, 27), "Rua da Madalena", "929993600", "irina.leite@RD-Telecom.com", "4835-511", "Cliente", false, "Braga", new DateTime(2021, 01, 14), 0, 3);

            //    //-------------------------- 4 BRAGANÇA------------------
            GaranteUtilizadores(bd, "Natally Domingues", "190328274", new DateTime(1974, 06, 19), "Bairro Moinho de Vento", "939088858", "natally.domingues@RD-Telecom.com", "5140-005", "Cliente", false, "Bragança", new DateTime(2020, 11, 13), 0, 4);
            GaranteUtilizadores(bd, "Nicolau Figueiras", "128593598", new DateTime(2001, 01, 21), "Quinta Lameira de Ferro", "932100091", "nicolau.figueiras@RD-Telecom.com", "5140-135", "Cliente", false, "Bragança", new DateTime(2020, 10, 27), 0, 4);
            GaranteUtilizadores(bd, "John Dias", "106481150", new DateTime(1987, 09, 03), "Rua Sem Nome 218 Bairro Além do Rio ", "966853331", "john.dias@RD-Telecom.com", "5300-001", "Cliente", false, "Bragança", new DateTime(2020, 10, 25), 0, 4);
            GaranteUtilizadores(bd, "Maria Leal", "121325539", new DateTime(1969, 09, 30), "Rua da Fragata", "923456396", "maria.leal@RD-Telecom.com", "5385-101", "Cliente", false, "Bragança", new DateTime(2020, 11, 12), 0, 4);
            GaranteUtilizadores(bd, "Isabel dos Santinhos", "124336760", new DateTime(1957, 05, 31), "Valbom Pitez", "922788556", "isabel.santinhos@RD-Telecom.com", "5385-132", "Cliente", false, "Bragança", new DateTime(2020, 12, 07), 0, 4);
            GaranteUtilizadores(bd, "Rui Fragona", "133933784", new DateTime(1988, 03, 07), "Azenha do Areal", "920975411", "rui.fragona@RD-Telecom.com", "5370-131", "Cliente", false, "Bragança", new DateTime(2020, 12, 18), 0, 4);
            GaranteUtilizadores(bd, "Dunildo de Boa Esperança", "160594944", new DateTime(2000, 10, 04), "Vale de Lobo", "929693777", "dunildo.esperanca@RD-Telecom.com", "5370-102", "Cliente", false, "Bragança", new DateTime(2020, 12, 24), 0, 4);
            GaranteUtilizadores(bd, "Carla Dorys", "220963959", new DateTime(1995, 08, 17), "Vilar Seco", "963991087", "carla.dorys@RD-Telecom.com", "5350-204", "Cliente", false, "Bragança", new DateTime(2020, 10, 05), 0, 4);
            GaranteUtilizadores(bd, "Birna de Oliveira", "218499124", new DateTime(1980, 02, 28), "Rua dos Combatentes da Grande Guerra", "930100852", "birna.oliveira@RD-Telecom.com", "5301-861", "Cliente", false, "Bragança", new DateTime(2021, 03, 05), 0, 4);
            GaranteUtilizadores(bd, "João Salgado", "259012629", new DateTime(1966, 11, 30), "Rua Cova da Beira", "926698880", "joao.salgado@RD-Telecom.com", "5300-869", "Cliente", false, "Bragança", new DateTime(2021, 01, 05), 0, 4);
            GaranteUtilizadores(bd, "Feitosa Pauleta", "235592650", new DateTime(1972, 10, 27), "Rotunda do Lavrador Bairro da Braguinha ", "921038825", "feitosa.pauleta@RD-Telecom.com", "5300-420", "Cliente", false, "Bragança", new DateTime(2021, 02, 21), 0, 4);

            //    //-------------------------- 5 CASTELO BRANCO------------------
            GaranteUtilizadores(bd, "Cláudia Vieira", "187114781", new DateTime(1965, 06, 19), "Rua das Rosas", "933897771", "claudia.vieira@RD-Telecom.com", "6250-004", "Cliente", false, "Castelo Branco", new DateTime(2020, 10, 11), 0, 5);
            GaranteUtilizadores(bd, "Diogo Andrade", "151327912", new DateTime(1999, 01, 21), "Sítio do Cabecinho", "937333852", "diogo.andrade@RD-Telecom.com", "6250-111", "Cliente", false, "Castelo Branco", new DateTime(2020, 09, 05), 0, 5);
            GaranteUtilizadores(bd, "Maria Ruah", "137352603", new DateTime(1988, 02, 03), "Quinta de Valverdinho", "963013347", "maria.ruah@RD-Telecom.com", "6250-163", "Cliente", false, "Castelo Branco", new DateTime(2020, 11, 03), 0, 5);
            GaranteUtilizadores(bd, "Florbela Antunes", "132809338", new DateTime(1980, 09, 30), "Rua do Curral", "929913645", "florbela.antunes@RD-Telecom.com", "6215-001", "Cliente", false, "Castelo Branco", new DateTime(2020, 11, 20), 0, 5);
            GaranteUtilizadores(bd, "António Antunes", "137252226", new DateTime(1974, 05, 31), "Rua Marquês de Ávila e Bolama", "928329961", "antonio.antunes@RD-Telecom.com", "6201-001", "Cliente", false, "Castelo Branco", new DateTime(2020, 12, 22), 0, 5);
            GaranteUtilizadores(bd, "Liliana Aveiro", "188164138", new DateTime(2000, 03, 07), "Viela do Castelo", "928881759", "liliana.aveiro@RD-Telecom.com", "6200-227", "Cliente", false, "Castelo Branco", new DateTime(2020, 11, 18), 0, 5);
            GaranteUtilizadores(bd, "Maria Pedroso", "179189093", new DateTime(2000, 10, 04), "Travessa das Trapas", "924688158", "maria.pedroso@RD-Telecom.com", "6200-237", "Cliente", false, "Castelo Branco", new DateTime(2020, 11, 17), 0, 5);
            GaranteUtilizadores(bd, "Pedro Fernandes", "101788460", new DateTime(1957, 08, 17), "Bairro da Formiguinha Vila do Carvalho", "966333357", "pedro.fernandes@RD-Telecom.com", "6200-241", "Cliente", false, "Castelo Branco", new DateTime(2021, 01, 13), 0, 5);
            GaranteUtilizadores(bd, "Miguel Moniz", "116037490", new DateTime(1962, 02, 28), "Rua das Tendas", "933212789", "miguel.moniz@RD-Telecom.com", "6200-699", "Cliente", false, "Castelo Branco", new DateTime(2021, 01, 30), 0, 5);
            GaranteUtilizadores(bd, "Felisberto Ortiz", "123718805", new DateTime(1971, 02, 28), "Travessa dos Escabelados", "922111366", "felisberto.ortiz@RD-Telecom.com", "6200-742", "Cliente", false, "Castelo Branco", new DateTime(2021, 02, 20), 0, 5);
            GaranteUtilizadores(bd, "António Sanchez", "124414680", new DateTime(1976, 11, 27), "Rua Canada", "925688710", "antonio.sanchez@RD-Telecom.com", "6005-002", "Cliente", false, "Castelo Branco", new DateTime(2021, 01, 13), 0, 5);

            //    //-------------------------- 6 COIMBRA-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "132814714", new DateTime(1999, 07, 01), "Rua do Norte", "929152221", "patricia.gomes@RD-Telecom.com", "3000-295", "Cliente", false, "Coimbra", new DateTime(2020, 10, 05), 0, 6);
            GaranteUtilizadores(bd, "Marlene Santos", "146552504", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "933334121", "marlene.satos@RD-Telecom.com", "3030-253", "Cliente", false, "Coimbra", new DateTime(2020, 12, 01), 0, 6);
            GaranteUtilizadores(bd, "João Ferreira", "125308655", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "929150021", "joao.ferreira@RD-Telecom.com", "3084-501", "Cliente", false, "Coimbra", new DateTime(2020, 11, 26), 0, 6);
            GaranteUtilizadores(bd, "Tânia Sousa", "164157174", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "927004121", "tania-sousa@RD-Telecom.com", "3400-215", "Cliente", false, "Coimbra", new DateTime(2020, 10, 27), 0, 6);
            GaranteUtilizadores(bd, "Rute Martins", "137414625", new DateTime(1979, 10, 30), "Cruz de Ferro", "929152229", "rute.martins@RD-Telecom.com", "3000-295", "Cliente", false, "Coimbra", new DateTime(2020, 09, 25), 0, 6);
            GaranteUtilizadores(bd, "Paulo Pedra", "173407951", new DateTime(1999, 07, 01), "Rua do Norte", "929155521", "paulo.pedra@RD-Telecom.com", "3000-295", "Cliente", false, "Coimbra", new DateTime(2020, 10, 11), 0, 6);
            GaranteUtilizadores(bd, "Helder Copeto", "145533590", new DateTime(1999, 07, 01), "Rua do Norte", "929122221", "helder.copeto@RD-Telecom.com", "3000-295", "Cliente", false, "Coimbra", new DateTime(2020, 10, 11), 0, 6);
            GaranteUtilizadores(bd, "Miriam Falcão", "149807074", new DateTime(2000, 01, 01), "Vale Derradeiro", "928884121", "miriam.falcao@RD-Telecom.com", "3320-002", "Cliente", false, "Coimbra", new DateTime(2020, 10, 11), 0, 6);
            GaranteUtilizadores(bd, "Célia Tomate", "113263295", new DateTime(1980, 09, 11), "Seladinhas", "929133321", "celia.tomate@RD-Telecom.com", "3320-367", "Cliente", false, "Coimbra", new DateTime(2021, 02, 18), 0, 6);
            GaranteUtilizadores(bd, "Tadeu Leão", "174464681", new DateTime(1975, 02, 08), "Flor da Rosa", "929159991", "tadeu.leao@RD-Telecom.com", "3040-471", "Cliente", false, "Coimbra", new DateTime(2021, 03, 11), 0, 6);
            GaranteUtilizadores(bd, "Harley Guerra", "148342205", new DateTime(1955, 12, 24), "Beco da Alegria", "929222121", "harley.guerra@RD-Telecom.com", "3025-129", "Cliente", false, "Coimbra", new DateTime(2021, 02, 20), 0, 6);
            GaranteUtilizadores(bd, "Afonso Freira", "118233580", new DateTime(1956, 12, 05), "Beco das Cruzes", "929004121", "afonso.freira@RD-Telecom.com", "3000-133 ", "Cliente", false, "Coimbra", new DateTime(2021, 01, 11), 0, 6);


            //    //-------------------------- 7 EVORA-----------------
            GaranteUtilizadores(bd, "Andreia Alves", "226173461", new DateTime(2001, 07, 01), "Vale de Pegas", "921996654", "andreia.alves@RD-Telecom.com", "7490-120", "Cliente", false, "Évora", new DateTime(2020, 10, 17), 0, 7);
            GaranteUtilizadores(bd, "João Correia", "265149207", new DateTime(1999, 11, 21), "Rua João de Deus", "936889914", "joao.correia@RD-Telecom.com", "7250-142", "Cliente", false, "Évora", new DateTime(2020, 09, 28), 0, 7);
            GaranteUtilizadores(bd, "Ricardo da Gama", "278404324", new DateTime(1975, 07, 01), "Rua da Liberdade", "920111963", "ricardo.gama@RD-Telecom.com", "7220-002", "Cliente", false, "Évora", new DateTime(2020, 09, 26), 0, 7);
            GaranteUtilizadores(bd, "Inês Castro", "214553698", new DateTime(1969, 06, 08), "Rua dos Irmãos", "927000148", "ines.castro@RD-Telecom.com", "7220-003", "Cliente", false, "Évora", new DateTime(2020, 11, 13), 0, 7);
            GaranteUtilizadores(bd, "Andressa Ribeiro", "201479745", new DateTime(1962, 03, 30), "Praceta do Brasil", "928000147", "andressa.ribeiro@RD-Telecom.com", "7200-479", "Cliente", false, "Évora", new DateTime(2020, 11, 07), 0, 7);
            GaranteUtilizadores(bd, "Pablo Abrunhosa", "239385853", new DateTime(1980, 07, 01), "Rua Projectada à Avenida Tomás Alcaide", "926999953", "pablo.abrunhosa@RD-Telecom.com", "7100-130", "Cliente", false, "Évora", new DateTime(2020, 11, 05), 0, 7);
            GaranteUtilizadores(bd, "Ramon Marques", "286791862", new DateTime(1999, 07, 01), "Travessa das Amendoeiras", "920123395", "ramon.marques@RD-Telecom.com", "7090-006", "Cliente", false, "Évora", new DateTime(2020, 10, 03), 0, 7);
            GaranteUtilizadores(bd, "Mariana da Serenidade", "240339380", new DateTime(1999, 01, 01), "Bairro Ferragolo", "922999698", "mariana.serenidade@RD-Telecom.com", "7080-109", "Cliente", false, "Évora", new DateTime(2020, 11, 26), 0, 7);
            GaranteUtilizadores(bd, "Dilma Rosas", "264773268", new DateTime(1958, 09, 21), "Casa de Pau", "920888147", "dilma.rosas@RD-Telecom.com", "7050-634", "Cliente", false, "Évora", new DateTime(2020, 11, 26), 0, 7);
            GaranteUtilizadores(bd, "Vicente Silva", "249853442", new DateTime(1965, 02, 08), "Largo das Alterações", "931459321", "vicente.silva@RD-Telecom.com", "7000-502", "Cliente", false, "Évora", new DateTime(2021, 01, 26), 0, 7); ;
            GaranteUtilizadores(bd, "Flascotter Pereira", "250372339", new DateTime(1995, 03, 24), "Rua Francisco Soares Lusitano", "966321010", "flascotter.pereira@RD-Telecom.com", "7004-511", "Cliente", false, "Évora", new DateTime(2021, 01, 26), 0, 7);
            GaranteUtilizadores(bd, "Sara Moedas", "254578870", new DateTime(1956, 05, 05), "Largo dos Colegiais 2", "933299871", "sara.moedas@RD-Telecom.com", "7004-516", "Cliente", false, "Évora", new DateTime(2021, 02, 26), 0, 7);

            //    //-------------------------- 8 FARO-----------------
            GaranteUtilizadores(bd, "Miguel Rossi", "253871166", new DateTime(1999, 07, 01), "Rua da Viola ", "925874990", "miguel.rossi@RD-Telecom.com", "8000-274", "Cliente", false, "Faro", new DateTime(2020, 12, 28), 0, 8);
            GaranteUtilizadores(bd, "Martina Castilho", "287333248", new DateTime(1988, 11, 21), "Rua do Bocage", "930662145", "martina.castilho@RD-Telecom.com", "8004-002", "Cliente", false, "Faro", new DateTime(2020, 12, 06), 0, 8);
            GaranteUtilizadores(bd, "Romeo Ximenes", "247989940", new DateTime(1978, 07, 01), "Areal Gordo", "932777410", "romeo.ximenes@RD-Telecom.com", "8005-409", "Cliente", false, "Faro", new DateTime(2020, 11, 17), 0, 8);
            GaranteUtilizadores(bd, "John Pitt", "219245061", new DateTime(1969, 06, 06), "Travessa do Borrego", "933699520", "john.pitt@RD-Telecom.com", "8125-002", "Cliente", false, "Faro", new DateTime(2020, 09, 17), 0, 8);
            GaranteUtilizadores(bd, "Zézinho Camarrinha", "288869397", new DateTime(1979, 10, 30), "Beco das Palmeiras", "921238802", "zezinho.camarrinha@RD-Telecom.com", "8125-609", "Cliente", false, "Faro", new DateTime(2020, 10, 19), 0, 8);
            GaranteUtilizadores(bd, "Luna Smith", "205571000", new DateTime(1999, 07, 01), "Beco Condestável", "925677717", "luna.smith@RD-Telecom.com", "8125-636", "Cliente", false, "Faro", new DateTime(2020, 10, 27), 0, 8);
            GaranteUtilizadores(bd, "Luísa Salvador", "261067010", new DateTime(1999, 06, 01), "Beco dos Bitas", "936299902", "luisa.salvador@RD-Telecom.com", "8200-002", "Cliente", false, "Faro", new DateTime(2020, 10, 26), 0, 8);
            GaranteUtilizadores(bd, "Ana Cacho", "221649549", new DateTime(2000, 01, 01), "Rua das Telecomunicações", "920333001", "ana.cacho@RD-Telecom.com", "8201-871", "Cliente", false, "Faro", new DateTime(2020, 11, 17), 0, 8);
            GaranteUtilizadores(bd, "Fernando Rock", "200024078", new DateTime(1980, 09, 11), "Caminho Municipal", "967399974", "fernando.rock@RD-Telecom.com", "8201-877", "Cliente", false, "Faro", new DateTime(2021, 03, 17), 0, 8);
            GaranteUtilizadores(bd, "Miguel Feliz", "112022740", new DateTime(1975, 02, 08), "Avenida dos Descobrimentos", "921327771", "miguel.feliz@RD-Telecom.com", "8601-852", "Cliente", false, "Faro", new DateTime(2021, 02, 17), 0, 8);
            GaranteUtilizadores(bd, "Maria Ferrari", "175059500", new DateTime(1955, 12, 24), "Rua 25 de Abril", "917866623", "maria.ferrari@RD-Telecom.com", "8801-005", "Cliente", false, "Faro", new DateTime(2021, 01, 28), 0, 8);
            GaranteUtilizadores(bd, "Bruno da Câmara Pereira", "173713785", new DateTime(1956, 12, 05), "Monte Olimpio", "917300725", "bruno.pereira@RD-Telecom.com", "8900-106", "Cliente", false, "Faro", new DateTime(2021, 01, 15), 0, 8);


            //    //-------------------------- 9 GUARDA-----------------
            GaranteUtilizadores(bd, "Alicia Sancho", "191045012", new DateTime(1988, 07, 01), "Ponte do Abade", "926000852", "alicia.sancho@RD-Telecom.com", "3570-191", "Cliente", false, "Guarda", new DateTime(2020, 11, 03), 0, 9);
            GaranteUtilizadores(bd, "Mateo Jesus", "100156320", new DateTime(1964, 11, 21), "Rua Quebra Costas", "931122589", "mateo.jesus@RD-Telecom.com", "5155-003", "Cliente", false, "Guarda", new DateTime(2020, 10, 18), 0, 9);
            GaranteUtilizadores(bd, "Antonnella Conti", "124152384", new DateTime(1954, 08, 01), "Zurrão", "920007410", "antonnella.conti@RD-Telecom.com", "6260-196", "Cliente", false, "Guarda", new DateTime(2020, 09, 20), 0, 9);
            GaranteUtilizadores(bd, "Nuno Gatti", "188733698", new DateTime(1970, 02, 06), "Carvalhal da Louça", "923111789", "nuno.gatti@RD-Telecom.com", "6270-131", "Cliente", false, "Guarda", new DateTime(2020, 10, 28), 0, 9);
            GaranteUtilizadores(bd, "Patrícia Carbone", "140198016", new DateTime(1980, 03, 30), "Rua Amadeus Mozart", "966961149", "patricia.carbone@RD-Telecom.com", "6300-509", "Cliente", false, "Guarda", new DateTime(2020, 12, 28), 0, 9);
            GaranteUtilizadores(bd, "Pedro Guerra", "178896896", new DateTime(1999, 08, 01), "Muxagata", "923499987", "pedro.guerra@RD-Telecom.com", "6370-361", "Cliente", false, "Guarda", new DateTime(2020, 10, 28), 0, 9);
            GaranteUtilizadores(bd, "Célia Valente", "184714370", new DateTime(1999, 07, 01), "Juncais", "910999658", "celia.valente@RD-Telecom.com", "6370-332", "Cliente", false, "Guarda", new DateTime(2020, 11, 28), 0, 9);
            GaranteUtilizadores(bd, "Rosa Serra", "139163085", new DateTime(2000, 01, 01), "Quinta da Costa", "92800532", "rosa.serra@RD-Telecom.com", "6324-004", "Cliente", false, "Guarda", new DateTime(2020, 12, 05), 0, 9);
            GaranteUtilizadores(bd, "Ricardo Estrela", "138133743", new DateTime(1987, 09, 17), "Parada", "963991456", "ricardo.estrla@RD-Telecom.com", "6355-142", "Cliente", false, "Guarda", new DateTime(2021, 02, 28), 0, 9);
            GaranteUtilizadores(bd, "Carlos Fechaduras", "131192051", new DateTime(1859, 05, 08), "Senouras", "925999874", "carlos.fechaduras@RD-Telecom.com", "6355-170", "Cliente", false, "Guarda", new DateTime(2021, 03, 01), 0, 9);
            GaranteUtilizadores(bd, "Álvaro Bruxelas", "163833320", new DateTime(1958, 12, 31), "Beco da Alegria", "91055800", "alvaro.bruxelas@RD-Telecom.com", "6355-170", "Cliente", false, "Guarda", new DateTime(2021, 01, 20), 0, 9);
            GaranteUtilizadores(bd, "Isamara Lobão", "104089440", new DateTime(1956, 12, 05), "Lajeosa", "936000077", "isamara.lobao@RD-Telecom.com", "6320-161", "Cliente", false, "Guarda", new DateTime(2021, 01, 28), 0, 9);

            //    //-------------------------- 10 LEIRIA-----------------
            GaranteUtilizadores(bd, "Amílcar Malho", "174926960", new DateTime(1967, 03, 01), "Rua dos Inácios", "923888144", "amilcar.malho@RD-Telecom.com", "2400-773", "Cliente", false, "Leiria", new DateTime(2020, 10, 18), 0, 10);
            GaranteUtilizadores(bd, "Joana de Sá", "298515989", new DateTime(1966, 11, 21), "Rua do Futuro", "931114711", "joana.sa@RD-Telecom.com", "2400-760", "Cliente", false, "Leiria", new DateTime(2020, 09, 25), 0, 10);
            GaranteUtilizadores(bd, "João Cabral", "297389955", new DateTime(2000, 06, 01), "Moinho do Rato", "925687708", "joao.cabral@RD-Telecom.com", "2410-528", "Cliente", false, "Leiria", new DateTime(2020, 10, 25), 0, 10);
            GaranteUtilizadores(bd, "Ilídio Brazeta", "259304727", new DateTime(1999, 06, 09), "Rua de Saint-Maur-Des-Fosses", "963999547", "ilidio.brazeta@RD-Telecom.com", "2414-001", "Cliente", false, "Leiria", new DateTime(2020, 10, 08), 0, 10);
            GaranteUtilizadores(bd, "Ricardo Caramelo", "240926803", new DateTime(1984, 02, 28), "Estrada da Mata Marrazes", "921457880", "ricardo.caramelo@RD-Telecom.com", "2419-001", "Cliente", false, "Leiria", new DateTime(2020, 10, 03), 0, 10);
            GaranteUtilizadores(bd, "João Figo", "210911891", new DateTime(1999, 07, 11), "Rua de Santa Margarida", "923099958", "joao.figo@RD-Telecom.com", "2420-999", "Cliente", false, "Leiria", new DateTime(2020, 11, 28), 0, 10);
            GaranteUtilizadores(bd, "Romina Santos", "201022117", new DateTime(1999, 07, 01), "Beco Grilo", "931477779", "romina.santos@RD-Telecom.com", "2460-005", "Cliente", false, "Leiria", new DateTime(2020, 11, 17), 0, 10);
            GaranteUtilizadores(bd, "Rui Rosa", "248554140", new DateTime(2000, 01, 01), "Rua Mercedes e Carlos Campeão", "968541100", "rui.rosa@RD-Telecom.com", "2460-006", "Cliente", false, "Leiria", new DateTime(2020, 11, 12), 0, 10);
            GaranteUtilizadores(bd, "Vanda Ruivo", "251055809", new DateTime(1980, 10, 11), "Bolo", "922388809", "vanda.ruivo@RD-Telecom.com", "3280-113", "Cliente", false, "Leiria", new DateTime(2020, 11, 03), 0, 10);
            GaranteUtilizadores(bd, "Tiago Andrade", "219730024", new DateTime(1975, 08, 08), "Sapateira", "967365333", "tiago.andrade@RD-Telecom.com", "3280-123", "Cliente", false, "Leiria", new DateTime(2020, 11, 03), 0, 10);
            GaranteUtilizadores(bd, "Marta Martinelli", "280206054", new DateTime(1988, 12, 24), "Rua dos Lavadouros", "910258977", "marta.martinelli@RD-Telecom.com", "2525-123", "Cliente", false, "Leiria", new DateTime(2021, 03, 03), 0, 10);
            GaranteUtilizadores(bd, "Joaquim Vitale", "252516800", new DateTime(1996, 12, 05), "Picha", "939300650", "joaquim.vitale@RD-Telecom.com", "3270-143", "Cliente", false, "Leiria", new DateTime(2021, 01, 03), 0, 10);


            //    //-------------------------- 11 LISBOA-----------------
            GaranteUtilizadores(bd, "Geraldo Fraga", "283068396", new DateTime(1968, 08, 01), "Rua Brito Aranha", "924888230", "geraldo.fraga@RD-Telecom.com", "1000-007", "Cliente", false, "Lisboa", new DateTime(2020, 10, 13), 0, 11);
            GaranteUtilizadores(bd, "Celeste Djata", "245604693", new DateTime(1969, 11, 28), "Avenida dos Defensores de Chaves", "931182456", "celeste.djata@RD-Telecom.com", "1049-004", "Cliente", false, "Lisboa", new DateTime(2020, 10, 18), 0, 11);
            GaranteUtilizadores(bd, "Carla Costa", "216326117", new DateTime(1978, 05, 01), "Largo das Palmeiras", "931773888", "carla.costa@RD-Telecom.com", "1050-168", "Cliente", false, "Lisboa", new DateTime(2020, 10, 14), 0, 11);
            GaranteUtilizadores(bd, "Daniele Lucas", "290364272", new DateTime(1973, 08, 06), "Avenida de Berna", "917133335", "daniele.lucas@RD-Telecom.com", "1067-001", "Cliente", false, "Lisboa", new DateTime(2020, 11, 08), 0, 11);
            GaranteUtilizadores(bd, "Davide Ramos", "276497961", new DateTime(1986, 10, 30), "Vila Celeste Rua Garcia", "961999620", "davide.ramos@RD-Telecom.com", "1070-136", "Cliente", false, "Lisboa", new DateTime(2020, 12, 18), 0, 11);
            GaranteUtilizadores(bd, "Diana Leite", "214102351", new DateTime(1999, 07, 01), "Beco Benformoso", "967422226", "diana.leite@RD-Telecom.com", "1100-008", "Cliente", false, "Lisboa", new DateTime(2020, 11, 09), 0, 11);
            GaranteUtilizadores(bd, "Dunildo Fernandes", "252014456", new DateTime(1988, 07, 01), "Largo Cabeço da Bola", "937888813", "dunildo.fernandes@RD-Telecom.com", "1150-008", "Cliente", false, "Lisboa", new DateTime(2020, 11, 02), 0, 11);
            GaranteUtilizadores(bd, "Beatriz Testa", "249546264", new DateTime(2000, 01, 01), "Beco da Bempostinha", "933336110", "beatriz.testa@RD-Telecom.com", "1150-006", "Cliente", false, "Lisboa", new DateTime(2020, 10, 10), 0, 11);
            GaranteUtilizadores(bd, "Pedro Farina", "235700576", new DateTime(2000, 09, 29), "Rua dos Anjos", "969999789", "pedro.farina@RD-Telecom.com", "1169-004", "Cliente", false, "Lisboa", new DateTime(2020, 10, 18), 0, 11);
            GaranteUtilizadores(bd, "Bernardino Caputo", "280722664", new DateTime(1975, 02, 08), "Rua dos Lusíadas", "919320005", "bernardino.caputo@RD-Telecom.com", "1349-006", "Cliente", false, "Lisboa", new DateTime(2021, 03, 10), 0, 11);
            GaranteUtilizadores(bd, "Pablo Medina", "216419433", new DateTime(1955, 08, 24), "Cabeça Gorda", "935555789", "pablo.medina@RD-Telecom.com", "2565-001", "Cliente", false, "Lisboa", new DateTime(2021, 02, 23), 0, 11);
            GaranteUtilizadores(bd, "Eva Simões", "279983395", new DateTime(1969, 12, 18), "Avenida João de Belas", "930222789", "eva.simoes@RD-Telecom.com", "2605-203", "Cliente", false, "Lisboa", new DateTime(2021, 01, 18), 0, 11);

            //    //-------------------------- 12 PORTALEGRE-----------------

            GaranteUtilizadores(bd, "Paula Neves", "273840240", new DateTime(1987, 05, 01), "Torre Cimeira", "969693331", "paula.neves@gmail.com", "6040-003", "Cliente", false, "Portalegre", new DateTime(2020, 09, 27), 0, 12);
            GaranteUtilizadores(bd, "Filipe Pinto", "276500202", new DateTime(1988, 10, 21), "Rua do Poço", "936772214", "filipe.pinto@gmail.com", "6050-106", "Cliente", false, "Portalegre", new DateTime(2020, 10, 29), 0, 12);
            GaranteUtilizadores(bd, "Ryan Vieira", "138948780", new DateTime(1968, 07, 13), "Ribeiro do Buraco", "921322224", "ryan.vieira@gmail.com", "7300-351", "Cliente", false, "Portalegre", new DateTime(2020, 10, 07), 0, 12);
            GaranteUtilizadores(bd, "Rodrigo Amarelo", "166386367", new DateTime(1970, 06, 28), "Cubos", "928742214", "rodrigo.amarelo@gmail.com", "7300-316", "Cliente", false, "Portalegre", new DateTime(2020, 12, 06), 0, 12);
            GaranteUtilizadores(bd, "Rita Abrantes", "150944810", new DateTime(1984, 10, 07), "Praça do Município", "960000123", "rita.abrantes@gmail.com", "7301-855", "Cliente", false, "Portalegre", new DateTime(2020, 11, 20), 0, 12);
            GaranteUtilizadores(bd, "Luís Rico", "109665619", new DateTime(1982, 07, 18), "Travessa da Rua do Comércio", "911288898", "luis.rico@gmail.com", "7301-857", "Cliente", false, "Portalegre", new DateTime(2020, 10, 25), 0, 12);
            GaranteUtilizadores(bd, "Helder Conceição", "157260070", new DateTime(1973, 07, 01), "Rua das Encruzilhadas", "936236545", "helder.conceicao@gmail.com", "7320-123", "Cliente", false, "Portalegre", new DateTime(2020, 10, 19), 0, 12);
            GaranteUtilizadores(bd, "Mariza Falcão", "186849087", new DateTime(2000, 01, 01), "Portas do Sol", "968555523", "mariza.falcao@gmail.com", "7350-002", "Cliente", false, "Portalegre", new DateTime(2020, 11, 13), 0, 12);
            GaranteUtilizadores(bd, "Lúcio Junior", "122934156", new DateTime(1980, 09, 16), "Rua da Guarda", "961425888", "lucio.junior@gmail.com", "7350-002", "Cliente", false, "Portalegre", new DateTime(2021, 02, 28), 0, 12);
            GaranteUtilizadores(bd, "Tiago Silva", "157929582", new DateTime(1975, 02, 24), "Rua do Escorregadio", "916999985", "tiago.silva@gmail.com", "7350-002", "Cliente", false, "Portalegre", new DateTime(2021, 01, 20), 0, 12);
            GaranteUtilizadores(bd, "Ana Godinho", "194493148", new DateTime(1968, 12, 19), "Rua do Emigrante", "923611182", "ana.godinho@gmail.com", "7370-001", "Cliente", false, "Portalegre", new DateTime(2021, 02, 22), 0, 12);
            GaranteUtilizadores(bd, "Filipa Oliveira", "123458366", new DateTime(1956, 12, 05), "Rua Marciano Cipriano", "923654111", "filipa.oliveira@gmail.com", "7370-002", "Cliente", false, "Portalegre", new DateTime(2021, 01, 13), 0, 12);

            //-------------------------- 13 PORTO-----------------
            GaranteUtilizadores(bd, "Patrícia Amaral", "146136560", new DateTime(1986, 03, 01), "Largo Escultor José Moreira da Silva", "969994000", "patricia.amaral@gmail.com", "4000-312", "Cliente", false, "Porto", new DateTime(2020, 08, 05), 0, 13);
            GaranteUtilizadores(bd, "João Santos", "134833236", new DateTime(1988, 11, 14), "Rua Latino Coelho Pares", "933777655", "joao.santos@gmail.com", "4000-314", "Cliente", false, "Porto", new DateTime(2021, 01, 05), 0, 13);
            GaranteUtilizadores(bd, "João Ferreira", "118889990", new DateTime(1963, 03, 01), "Rua de Moreira Ímpares", "923005564", "joao.ferreira@gmail.com", "4000-346", "Cliente", false, "Porto", new DateTime(2020, 10, 11), 0, 13);
            GaranteUtilizadores(bd, "Tânia Pereira", "222915277", new DateTime(1967, 06, 03), "Rua do Alto da Fontinha", "962221008", "tania.pereira@gmail.com", "4000-007", "Cliente", false, "Porto", new DateTime(2020, 08, 12), 0, 13);
            GaranteUtilizadores(bd, "Rute Pequena", "207335281", new DateTime(1975, 02, 28), "Rua Júlio Dinis Fast-Food Mister Pick Wick", "929994197", "rute.pequena@gmail.com", "4050-001", "Cliente", false, "Porto", new DateTime(2020, 10, 17), 0, 13);
            GaranteUtilizadores(bd, "Paulo Jorge", "272817996", new DateTime(1998, 07, 11), "Rua Júlio Dinis", "923222203", "paulo.jorge@gmail.com", "4050-322", "Cliente", false, "Porto", new DateTime(2020, 08, 18), 0, 13);
            GaranteUtilizadores(bd, "Helder Reis", "233644253", new DateTime(1999, 07, 01), "Travessa Marracuene", "923658890", "helder.reis@gmail.com", "4050-357", "Cliente", false, "Porto", new DateTime(2020, 08, 26), 0, 13);
            GaranteUtilizadores(bd, "Lucas Castilho", "280748604", new DateTime(1974, 01, 01), "Rua Guerra Junqueiro", "938882365", "tome.fernandes@gmail.com", "4169-009", "Cliente", false, "Porto", new DateTime(2020, 08, 27), 0, 13);
            GaranteUtilizadores(bd, "Tomé Fernades", "241553741", new DateTime(1985, 06, 11), "Rua do Campo Alegre", "927888608", "tome.fernandes@gmail.com", "4169-007", "Cliente", false, "Porto", new DateTime(2020, 08, 25), 0, 13);
            GaranteUtilizadores(bd, "Paula Andrade", "273948180", new DateTime(1962, 02, 08), "Rua Gonçalo Sampaio", "925332261", "paula.andrade@gmail.com", "4169-001", "Cliente", false, "Porto", new DateTime(2020, 11, 10), 0, 13);
            GaranteUtilizadores(bd, "Jacinto Dias", "200013980", new DateTime(1957, 03, 24), "Rua do Campo Alegre", "968022020", "jacinto.dias@gmail.com", "4169-007", "Cliente", false, "Porto", new DateTime(2020, 10, 05), 0, 13);
            GaranteUtilizadores(bd, "Amélia Paz", "256250090", new DateTime(1956, 08, 05), "Rua Professora Lucília Fernandes Canidelo", "932336459", "amelia.paz@gmail.com", "4400-651", "Cliente", false, "Porto", new DateTime(2020, 12, 05), 0, 13);

            //    //-------------------------- 14 SANTAREM-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "233931945", new DateTime(2000, 07, 01), "Casal dos Florindos", "917899925", "patricia.gomes@gmail.com", "2000-320", "Cliente", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);
            GaranteUtilizadores(bd, "Marlene Santos", "225618184", new DateTime(1987, 11, 21), "Casal da Igreja", "969951542", "marlene.satos@gmail.com", "2000-336", "Cliente", false, "Santarém", new DateTime(2020, 08, 19), 0, 14);
            GaranteUtilizadores(bd, "João Ferreira", "254315321", new DateTime(1978, 07, 01), "Dona Belida", "932007548", "joao.ferreira@gmail.com", "2000-342", "Cliente", false, "Santarém", new DateTime(2021, 01, 17), 0, 14);
            GaranteUtilizadores(bd, "Pedro Martins", "211155314", new DateTime(1969, 06, 06), "Avenida Bernardo Santareno", "963215699", "pedro.martins@gmail.com", "2009-004", "Cliente", false, "Santarém", new DateTime(2021, 01, 05), 0, 14);
            GaranteUtilizadores(bd, "Joana Lima", "226866920", new DateTime(1979, 10, 30), "Largo do Infante Santo", "923324100", "joana.lima@gmail.com", "2009-002", "Cliente", false, "Santarém", new DateTime(2021, 01, 05), 0, 14);
            GaranteUtilizadores(bd, "Patrícia Gomes", "270227300", new DateTime(1999, 04, 01), "Estrada Nacional 10", "925955574", "patricia.gomes@gmail.com", "2139-503", "Cliente", false, "Santarém", new DateTime(2020, 12, 28), 0, 14);
            GaranteUtilizadores(bd, "Irís Copeto", "294199098", new DateTime(1999, 09, 05), "Agolada", "965574088", "iris.copeto@gmail.com", "2100-001", "Cliente", false, "Santarém", new DateTime(2020, 11, 12), 0, 14);
            GaranteUtilizadores(bd, "Filipe Pais", "284740624", new DateTime(1987, 01, 01), "Varejola", "924898710", "filipe.pais@gmail.com", "2100-377", "Cliente", false, "Santarém", new DateTime(2020, 12, 12), 0, 14);
            GaranteUtilizadores(bd, "Amadeu Lourenço", "247047813", new DateTime(1965, 08, 17), "Louriceira", "920250005", "amadeu.lourenço@gmail.com", "6120-116", "Cliente", false, "Santarém", new DateTime(2020, 11, 05), 0, 14);
            GaranteUtilizadores(bd, "Amílcar Oliveira", "203980433", new DateTime(1974, 02, 10), "Estrada Nacional 10", "967369511", "amilcar.oliveira@gmail.com", "2139-503", "Cliente", false, "Santarém", new DateTime(2020, 10, 05), 0, 14);
            GaranteUtilizadores(bd, "Luísa Guerra", "235929190", new DateTime(1955, 08, 05), "Casal de Além", "922587776", "luisa.guerra@gmail.com", "2025-150", "Cliente", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);
            GaranteUtilizadores(bd, "Afonso Freira", "211773441", new DateTime(1957, 07, 05), "Pisão", "931478521", "afonso.freira@gmail.com", "2230-009", "Cliente", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);

            GaranteUtilizadores(bd, "Paula Neves", "273840240", new DateTime(1987, 05, 01), "Torre Cimeira", "969693331", "paula.neves@RD-Telecom.com", "6040-003", "Cliente", false, "Portalegre", new DateTime(2020, 09, 27), 0, 12);
            GaranteUtilizadores(bd, "Filipe Pinto", "276500202", new DateTime(1988, 10, 21), "Rua do Poço", "936772214", "filipe.pinto@RD-Telecom.com", "6050-106", "Cliente", false, "Portalegre", new DateTime(2020, 10, 29), 0, 12);
            GaranteUtilizadores(bd, "Ryan Vieira", "138948780", new DateTime(1968, 07, 13), "Ribeiro do Buraco", "921322224", "ryan.vieira@RD-Telecom.com", "7300-351", "Cliente", false, "Portalegre", new DateTime(2020, 10, 07), 0, 12);
            GaranteUtilizadores(bd, "Rodrigo Amarelo", "166386367", new DateTime(1970, 06, 28), "Cubos", "928742214", "rodrigo.amarelo@RD-Telecom.com", "7300-316", "Cliente", false, "Portalegre", new DateTime(2020, 12, 06), 0, 12);
            GaranteUtilizadores(bd, "Rita Abrantes", "150944810", new DateTime(1984, 10, 07), "Praça do Município", "960000123", "rita.abrantes@RD-Telecom.com", "7301-855", "Cliente", false, "Portalegre", new DateTime(2020, 11, 20), 0, 12);
            GaranteUtilizadores(bd, "Luís Rico", "109665619", new DateTime(1982, 07, 18), "Travessa da Rua do Comércio", "911288898", "luis.rico@RD-Telecom.com", "7301-857", "Cliente", false, "Portalegre", new DateTime(2020, 10, 25), 0, 12);
            GaranteUtilizadores(bd, "Helder Conceição", "157260070", new DateTime(1973, 07, 01), "Rua das Encruzilhadas", "936236545", "helder.conceicao@RD-Telecom.com", "7320-123", "Cliente", false, "Portalegre", new DateTime(2020, 10, 19), 0, 12);
            GaranteUtilizadores(bd, "Mariza Falcão", "186849087", new DateTime(2000, 01, 01), "Portas do Sol", "968555523", "mariza.falcao@RD-Telecom.com", "7350-002", "Cliente", false, "Portalegre", new DateTime(2020, 11, 13), 0, 12);
            GaranteUtilizadores(bd, "Lúcio Junior", "122934156", new DateTime(1980, 09, 16), "Rua da Guarda", "961425888", "lucio.junior@RD-Telecom.com", "7350-002", "Cliente", false, "Portalegre", new DateTime(2021, 02, 28), 0, 12);
            GaranteUtilizadores(bd, "Tiago Silva", "157929582", new DateTime(1975, 02, 24), "Rua do Escorregadio", "916999985", "tiago.silva@RD-Telecom.com", "7350-002", "Cliente", false, "Portalegre", new DateTime(2021, 01, 20), 0, 12);
            GaranteUtilizadores(bd, "Ana Godinho", "194493148", new DateTime(1968, 12, 19), "Rua do Emigrante", "923611182", "ana.godinho@RD-Telecom.com", "7370-001", "Cliente", false, "Portalegre", new DateTime(2021, 02, 22), 0, 12);
            GaranteUtilizadores(bd, "Filipa Oliveira", "123458366", new DateTime(1956, 12, 05), "Rua Marciano Cipriano", "923654111", "filipa.oliveira@RD-Telecom.com", "7370-002", "Cliente", false, "Portalegre", new DateTime(2021, 01, 13), 0, 12);
             
               //-------------------------- 13 PORTO-----------------
            GaranteUtilizadores(bd, "Patrícia Amaral", "146136560", new DateTime(1986, 03, 01), "Largo Escultor José Moreira da Silva", "969994000", "patricia.amaral@RD-Telecom.com", "4000-312", "Cliente", false, "Porto", new DateTime(2020, 08, 05), 0, 13);
            GaranteUtilizadores(bd, "João Santos", "134833236", new DateTime(1988, 11, 14), "Rua Latino Coelho Pares", "933777655", "joao.santos@RD-Telecom.com", "4000-314", "Cliente", false, "Porto", new DateTime(2021, 01, 05), 0, 13);
            GaranteUtilizadores(bd, "João Ferreira", "118889990", new DateTime(1963, 03, 01), "Rua de Moreira Ímpares", "923005564", "joao.ferreira@RD-Telecom.com", "4000-346", "Cliente", false, "Porto", new DateTime(2020, 10, 11), 0, 13);
            GaranteUtilizadores(bd, "Tânia Pereira", "222915277", new DateTime(1967, 06, 03), "Rua do Alto da Fontinha", "962221008", "tania.pereira@RD-Telecom.com", "4000-007", "Cliente", false, "Porto", new DateTime(2020, 08, 12), 0, 13);
            GaranteUtilizadores(bd, "Rute Pequena", "207335281", new DateTime(1975, 02, 28), "Rua Júlio Dinis Fast-Food Mister Pick Wick", "929994197", "rute.pequena@RD-Telecom.com", "4050-001", "Cliente", false, "Porto", new DateTime(2020, 10, 17), 0, 13);
            GaranteUtilizadores(bd, "Paulo Jorge", "272817996", new DateTime(1998, 07, 11), "Rua Júlio Dinis", "923222203", "paulo.jorge@RD-Telecom.com", "4050-322", "Cliente", false, "Porto", new DateTime(2020, 08, 18), 0, 13);
            GaranteUtilizadores(bd, "Helder Reis", "233644253", new DateTime(1999, 07, 01), "Travessa Marracuene", "923658890", "helder.reis@RD-Telecom.com", "4050-357", "Cliente", false, "Porto", new DateTime(2020, 08, 26), 0, 13);
            GaranteUtilizadores(bd, "Lucas Castilho", "280748604", new DateTime(1974, 01, 01), "Rua Guerra Junqueiro", "938882365", "tome.fernandes@RD-Telecom.com", "4169-009", "Cliente", false, "Porto", new DateTime(2020, 08, 27), 0, 13);
            GaranteUtilizadores(bd, "Tomé Fernades", "241553741", new DateTime(1985, 06, 11), "Rua do Campo Alegre", "927888608", "tome.fernandes@RD-Telecom.com", "4169-007", "Cliente", false, "Porto", new DateTime(2020, 08, 25), 0, 13);
            GaranteUtilizadores(bd, "Paula Andrade", "273948180", new DateTime(1962, 02, 08), "Rua Gonçalo Sampaio", "925332261", "paula.andrade@RD-Telecom.com", "4169-001", "Cliente", false, "Porto", new DateTime(2020, 11, 10), 0, 13);
            GaranteUtilizadores(bd, "Jacinto Dias", "200013980", new DateTime(1957, 03, 24), "Rua do Campo Alegre", "968022020", "jacinto.dias@RD-Telecom.com", "4169-007", "Cliente", false, "Porto", new DateTime(2020, 10, 05), 0, 13);
            GaranteUtilizadores(bd, "Amélia Paz", "256250090", new DateTime(1956, 08, 05), "Rua Professora Lucília Fernandes Canidelo", "932336459", "amelia.paz@RD-Telecom.com", "4400-651", "Cliente", false, "Porto", new DateTime(2020, 12, 05), 0, 13);

            //    //-------------------------- 14 SANTAREM-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "233931945", new DateTime(2000, 07, 01), "Casal dos Florindos", "917899925", "patricia.gomes@RD-Telecom.com", "2000-320", "Cliente", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);
            GaranteUtilizadores(bd, "Marlene Santos", "225618184", new DateTime(1987, 11, 21), "Casal da Igreja", "969951542", "marlene.satos@RD-Telecom.com", "2000-336", "Cliente", false, "Santarém", new DateTime(2020, 08, 19), 0, 14);
            GaranteUtilizadores(bd, "João Ferreira", "254315321", new DateTime(1978, 07, 01), "Dona Belida", "932007548", "joao.ferreira@RD-Telecom.com", "2000-342", "Cliente", false, "Santarém", new DateTime(2021, 01, 17), 0, 14);
            GaranteUtilizadores(bd, "Pedro Martins", "211155314", new DateTime(1969, 06, 06), "Avenida Bernardo Santareno", "963215699", "pedro.martins@RD-Telecom.com", "2009-004", "Cliente", false, "Santarém", new DateTime(2021, 01, 05), 0, 14);
            GaranteUtilizadores(bd, "Joana Lima", "226866920", new DateTime(1979, 10, 30), "Largo do Infante Santo", "923324100" , "joana.lima@RD-Telecom.com", "2009-002", "Cliente", false, "Santarém", new DateTime(2021, 01, 05), 0, 14);
            GaranteUtilizadores(bd, "Patrícia Gomes", "270227300", new DateTime(1999, 04, 01), "Estrada Nacional 10", "925955574", "patricia.gomes@RD-Telecom.com", "2139-503", "Cliente", false, "Santarém", new DateTime(2020, 12, 28), 0, 14);
            GaranteUtilizadores(bd, "Irís Copeto", "294199098", new DateTime(1999, 09, 05), "Agolada", "965574088", "iris.copeto@RD-Telecom.com", "2100-001", "Cliente", false, "Santarém", new DateTime(2020, 11, 12), 0, 14);
            GaranteUtilizadores(bd, "Filipe Pais", "284740624", new DateTime(1987, 01, 01), "Varejola", "924898710", "filipe.pais@RD-Telecom.com", "2100-377", "Cliente", false, "Santarém", new DateTime(2020, 12, 12), 0, 14);
            GaranteUtilizadores(bd, "Amadeu Lourenço", "247047813", new DateTime(1965, 08, 17), "Louriceira", "920250005", "amadeu.lourenço@RD-Telecom.com", "6120-116", "Cliente", false, "Santarém", new DateTime(2020, 11, 05), 0, 14);
            GaranteUtilizadores(bd, "Amílcar Oliveira", "203980433", new DateTime(1974, 02, 10), "Estrada Nacional 10", "967369511", "amilcar.oliveira@RD-Telecom.com", "2139-503", "Cliente", false, "Santarém", new DateTime(2020, 10, 05), 0, 14);
            GaranteUtilizadores(bd, "Luísa Guerra", "235929190", new DateTime(1955, 08, 05), "Casal de Além", "922587776", "luisa.guerra@RD-Telecom.com", "2025-150", "Cliente", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);
            GaranteUtilizadores(bd, "Afonso Freira", "211773441", new DateTime(1957, 07, 05), "Pisão", "931478521", "afonso.freira@RD-Telecom.com", "2230-009", "Cliente", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);


            //    //-------------------------- 15 SETUBAL-----------------
            GaranteUtilizadores(bd, "Patrícia Varandas", "280863500", new DateTime(1986, 07, 01), "Praceta Bernardim Ribeiro", "914886951", "patricia.varandas@RD-Telecom.com", "2800-002", "Cliente", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            GaranteUtilizadores(bd, "Miguel Santos", "221444394", new DateTime(1988, 05, 21), "Praça Doutora Adelaide Coutinho", "960007878", "miguel.santos@RD-Telecom.com", "2800-002", "Cliente", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            GaranteUtilizadores(bd, "João Ferreira", "297310860", new DateTime(1978, 06, 01), "Rua Bulhão Pato", "926555826", "joao.ferreira@RD-Telecom.com", "2800-003", "Cliente", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            GaranteUtilizadores(bd, "Tânia Sousa", "104715111", new DateTime(1970, 06, 08), "Rua Capitão Leitão Ímpares", "965813310", "tania-sousa@RD-Telecom.com", "2800-137", "Cliente", false, "Setúbal", new DateTime(2020, 11, 05), 0, 15);
            GaranteUtilizadores(bd, "Rute Martins", "173067735", new DateTime(1968, 10, 30), "Pátio Albers", "926125822", "rute.martins@RD-Telecom.com", "2830-320", "Cliente", false, "Setúbal", new DateTime(2020, 12, 11), 0, 15);
            GaranteUtilizadores(bd, "Bernardo Pinto", "108452255", new DateTime(2000, 08, 01), "Travessa do Alto José Ferreira", "960001489", "bernardo.pinto@RD-Telecom.com", "2830-381", "Cliente", false, "Setúbal", new DateTime(2020, 08, 19), 0, 15); ;
            GaranteUtilizadores(bd, "Paula Neves", "176706160", new DateTime(1999, 11, 01), "Rua da Bandeira", "966788952", "paula.neves@RD-Telecom.com", "2830-330", "Cliente", false, "Setúbal", new DateTime(2020, 08, 20), 0, 15);
            GaranteUtilizadores(bd, "Miriam Palito", "367127822", new DateTime(2001, 01, 01), "Rua Professor Egas Moniz", "914852224", "miriam.palito@RD-Telecom.com", "2830-357", "Cliente", false, "Setúbal", new DateTime(2021, 02, 27), 0, 15);
            GaranteUtilizadores(bd, "Vanessa Albino", "301702780", new DateTime(1988, 09, 11), "Rua Fernando de Sousa", "923012374", "vanessa.albino@RD-Telecom.com", "2844-001", "Cliente", false, "Setúbal", new DateTime(2020, 12, 30), 0, 15);
            GaranteUtilizadores(bd, "Rosa Amarelo", "349842078", new DateTime(1975, 02, 11), "2890-200", "920777758", "rosa.amarelo@RD-Telecom.com", "2890-200", "Cliente", false, "Setúbal", new DateTime(2020, 11, 05), 0, 02);
            GaranteUtilizadores(bd, "Vanessa Rodrigues", "346354463", new DateTime(1955, 07, 28), "Estrada Nacional 5", "968520050", "vanessa.roduigues@RD-Telecom.com", "2959-501", "Cliente", false, "Setúbal", new DateTime(2020, 09, 10), 0, 15);
            GaranteUtilizadores(bd, "Afonso Pereira", "340319747", new DateTime(1956, 12, 30), "Monte das Parchanas", "968531999", "afonso.pereira@RD-Telecom.com", "7595-002", "Cliente", false, "Setúbal", new DateTime(2020, 10, 28), 0, 15);

            //    //-------------------------- 16 VIANA DO CASTELO-----------------
            GaranteUtilizadores(bd, "Pedro Gomes", "874024455", new DateTime(1995, 07, 11), "Largo da Oliveira", "918777654", "pedro.gomes@RD-Telecom.com", "4900-003", "Cliente", false, "Viana do Castelo", new DateTime(2020, 08, 05), 0, 16);
            GaranteUtilizadores(bd, "Marlene Pereira", "884995283", new DateTime(1988, 11, 21), "Estrada de Santo António", "965896690", "marlene.pereira@RD-Telecom.com", "4900-006", "Cliente", false, "Viana do Castelo", new DateTime(2020, 10, 05), 0, 16);
            GaranteUtilizadores(bd, "João Ferreira", "863523650", new DateTime(1977, 07, 01), "Largo do Pião", "963555337", "joao.ferreira@RD-Telecom.com", "4900-102", "Cliente", false, "Viana do Castelo", new DateTime(2020, 11, 05), 0, 16);
            GaranteUtilizadores(bd, "Tânia Sousa", "896105300", new DateTime(1969, 06, 06), "Rua Paula Ferreira", "967520333", "tania-sousa@RD-Telecom.com", "4900-862", "Cliente", false, "Viana do Castelo", new DateTime(2020, 09, 05), 0, 16);
            GaranteUtilizadores(bd, "Rute Martins", "836156277", new DateTime(1979, 10, 30), "Rua de São Pedro de Areosa", "923552252", "rute.martins@RD-Telecom.com", "4900-902", "Cliente", false, "Viana do Castelo", new DateTime(2021, 01, 05), 0, 16);
            GaranteUtilizadores(bd, "Luís Bernardo", "856393940", new DateTime(2000, 07, 16), "Travessa dos Sobreiros", "934777723", "luis.bernardo@RD-Telecom.com", "4900-914", "Cliente", false, "Viana do Castelo", new DateTime(2021, 02, 05), 0, 16);
            GaranteUtilizadores(bd, "Helder Vicente", "814819974", new DateTime(1999, 07, 17), "Rua de Monserrate", "966555112", "helder.vicente@RD-Telecom.com", "4904-859", "Cliente", false, "Viana do Castelo", new DateTime(2020, 11, 17), 0, 16);
            GaranteUtilizadores(bd, "António Santos", "892848677", new DateTime(2001, 05, 01), "Rua Pedro Homem de Melo", "963322259", "antonio.santos@RD-Telecom.com", "4904-861", "Cliente", false, "Viana do Castelo", new DateTime(2020, 09, 28), 0, 16);
            GaranteUtilizadores(bd, "Célia Pimento", "803570180", new DateTime(1980, 09, 11), "Rua Santiago da Barra", "923696007", "celia.pimento@RD-Telecom.com", "4904-882", "Cliente", false, "Viana do Castelo", new DateTime(2020, 08, 30), 0, 16);
            GaranteUtilizadores(bd, "Paulo Feliz", "828853312", new DateTime(1975, 02, 08), "Estrada de Santa Luzia", "911111033", "paulo.feliz@RD-Telecom.com", "4904-858", "Cliente", false, "Viana do Castelo", new DateTime(2020, 10, 14), 0, 16);
            GaranteUtilizadores(bd, "Joaquim Guerra", "823701514", new DateTime(1959, 08, 24), "Avenida Capitão Gaspar de Castro", "965333311", "joaquim.guerra@RD-Telecom.com", "4904-873", "Cliente", false, "Viana do Castelo", new DateTime(2020, 12, 17), 0, 16);
            GaranteUtilizadores(bd, "Afonso Freira", "870545140", new DateTime(1956, 07, 26), "Monterrão", "932654877", "afonso.freira@RD-Telecom.com", "4940-003", "Cliente", false, "Viana do Castelo", new DateTime(2020, 10, 13), 0, 16);

            //    //-------------------------- 17 VILA REAL-----------------
            GaranteUtilizadores(bd, "Patrícia Avillar", "866085220", new DateTime(2001, 09, 01), "Passagem", "966999985", "patricia.avillar@RD-Telecom.com", "5000-004", "Cliente", false, "Vila Real", new DateTime(2020, 08, 05), 0, 17);
            GaranteUtilizadores(bd, "Marlene Pacheco", "867120487", new DateTime(1988, 12, 21), "Cabana", "932000120", "marlene.pacheco@RD-Telecom.com", "5000-008", "Cliente", false, "Vila Real", new DateTime(2020, 10, 05), 0, 17);
            GaranteUtilizadores(bd, "Filipe Ferreira", "838298222", new DateTime(1975, 08, 01), " Camatoga", "925889950", "filipe.ferreira@RD-Telecom.com", "5040-001", "Cliente", false, "Vila Real", new DateTime(2020, 08, 27), 0, 17);
            GaranteUtilizadores(bd, "Bruna Sousa", "833248723", new DateTime(1969, 04, 06), "Porto Rei", "920025992", "bruna.sousa@RD-Telecom.com", "5040-117", "Cliente", false, "Vila Real", new DateTime(2020, 08, 28), 0, 17);
            GaranteUtilizadores(bd, "António Martins", "811951200", new DateTime(1985, 10, 30), "Covinhas", "96777025", "antonio.martins@RD-Telecom.com", "5050-103", "Cliente", false, "Vila Real", new DateTime(2020, 10, 05), 0, 17);
            GaranteUtilizadores(bd, "Inês Silva", "816333076", new DateTime(1973, 07, 01), "Salgueiral", "927771003", "ines.silva@RD-Telecom.com", "5050-007", "Cliente", false, "Vila Real", new DateTime(2020, 11, 05), 0, 17);
            GaranteUtilizadores(bd, "Pedro Andrade", "846489538", new DateTime(2001, 07, 11), "Rua da Barreira", "925644585", "pedro.andrade@RD-Telecom.com", "5070-003", "Cliente", false, "Vila Real", new DateTime(2021, 01, 05), 0, 17);
            GaranteUtilizadores(bd, "Vanessa Monteiro", "891658122", new DateTime(1976, 01, 01), "Rua da Ponte Nova", "963233668", "vanessa.monteiro@RD-Telecom.com", "5070-003", "Cliente", false, "Vila Real", new DateTime(2020, 12, 05), 0, 17);
            GaranteUtilizadores(bd, "Manuela Fonseca", "800463919", new DateTime(1995, 09, 11), "Rua Amadeu Necho", "925626922", "manuela.fonseca@RD-Telecom.com", "5070-008", "Cliente", false, "Vila Real", new DateTime(2020, 08, 19), 0, 17);
            GaranteUtilizadores(bd, "Kelvin Antunes", "822729687", new DateTime(1987, 02, 11), "Estrada Municipal", "962002025", "kelvin.antunes@RD-Telecom.com", "5070-173", "Cliente", false, "Vila Real", new DateTime(2020, 08, 27), 0, 17);
            GaranteUtilizadores(bd, "Rita Godinho", "884984958", new DateTime(1966, 10, 24), "Porto Rei", "923690101", "rita.godinho@RD-Telecom.com", "5040-117", "Cliente", false, "Vila Real", new DateTime(2020, 08, 01), 0, 17);
            GaranteUtilizadores(bd, "Bernardo Marques", "894369750", new DateTime(1958, 09, 05), "Povoação", "938899227", "bernardo.marques@RD-Telecom.com", "5040-295", "Cliente", false, "Vila Real", new DateTime(2020, 11, 05), 0, 17);

            //    //-------------------------- 18 VISEU-----------------
            GaranteUtilizadores(bd, "Paula Gomes", "847487059", new DateTime(2000, 06, 11), "Beco do Areal", "965416300", "paula.gomes@RD-Telecom.com", "3430-505", "Cliente", false, "Viseu", new DateTime(2021, 02, 05), 0, 18);
            GaranteUtilizadores(bd, "Marlene Santinho", "899136206", new DateTime(1988, 07, 09), "Avenida Madre Rita Amada de Jesus", "928321888", "marlene.santinho@RD-Telecom.com", "3500-179", "Cliente", false, "Viseu", new DateTime(2021, 01, 05), 0, 18);
            GaranteUtilizadores(bd, "João Monteiro", "864420773", new DateTime(1986, 03, 01), "Rua Nova Jugueiros", "965658448", "joao.monteiro@RD-Telecom.com", "3500-003", "Cliente", false, "Viseu", new DateTime(2020, 08, 05), 0, 18);
            GaranteUtilizadores(bd, "Tânia Laranjo", "897727509", new DateTime(1969, 09, 06), "Rua Imaculado Coração de Maria", "932339632", "tania.laranjo@RD-Telecom.com", "3500-236", "Cliente", false, "Viseu", new DateTime(2020, 10, 05), 0, 18);
            GaranteUtilizadores(bd, "Anabela Moreria", "830646272", new DateTime(1964, 10, 23), "Rua 31 de Janeiro", "933332005", "anabela.moreira@RD-Telecom.com", "3500-217", "Cliente", false, "Viseu", new DateTime(2020, 12, 05), 0, 18);
            GaranteUtilizadores(bd, "Bruno Fernandes", "859511839", new DateTime(1999, 07, 24), "Rua Viscondessa de São Caetano", "910220008", "bruno.fernandes@RD-Telecom.com", "3500-185", "Cliente", false, "Viseu", new DateTime(2021, 02, 12), 0, 18);
            GaranteUtilizadores(bd, "Bruno Nogueira", "831822546", new DateTime(1999, 06, 21), "Rua do Hospital", "923333318", "bruno.nogueira@RD-Telecom.com", "3500-161", "Cliente", false, "Viseu", new DateTime(2021, 01, 17), 0, 18);
            GaranteUtilizadores(bd, "Ana Gomes", "818443383", new DateTime(2000, 01, 28), "Estrada Nacional 16", "968498749", "ana.gomes@RD-Telecom.com", "3519-002", "Cliente", false, "Viseu", new DateTime(2020, 11, 28), 0, 18);
            GaranteUtilizadores(bd, "Rita Rocha", "858391015", new DateTime(1984, 09, 11), "Cadraço", "920006552", "rita.rocha@RD-Telecom.com", "3475-003", "Cliente", false, "Viseu", new DateTime(2020, 10, 25), 0, 18);
            GaranteUtilizadores(bd, "Joana Dias", "815841531", new DateTime(1987, 02, 08), "Pedrogão", "921336668", "joana.dias@RD-Telecom.com", "3475-004", "Cliente", false, "Viseu", new DateTime(2020, 12, 17), 0, 18);
            GaranteUtilizadores(bd, "Maria Bastos", "868745251", new DateTime(1960, 07, 24), "Abóboda", "914444255", "maria.bastos@RD-Telecom.com", "3475-007", "Cliente", false, "Viseu", new DateTime(2020, 11, 09), 0, 18);
            GaranteUtilizadores(bd, "Luís Neto", "871557380", new DateTime(1979, 10, 05), "Rua Doutor Sebastião Alcantara", "937193333", "luis.neto@RD-Telecom.com", "3534-002", "Cliente", false, "Viseu", new DateTime(2021, 03, 14), 0, 18);

            //    //-------------------------- 19 AÇORES-----------------
            GaranteUtilizadores(bd, "Paula Mendes", "885803973", new DateTime(2000, 06, 01), "À Fonseca ", "930001114", "paula.mendes@RD-Telecom.com", "9700-302", "Cliente", false, "Açores", new DateTime(2020, 07, 01), 0, 19);
            GaranteUtilizadores(bd, "Joana Santos", "802477259", new DateTime(1989, 11, 11), "Outeiro de São Mateus", "968880005", "joana.santos@RD-Telecom.com", "9700-305", "Cliente", false, "Açores", new DateTime(2021, 01, 01), 0, 19);
            GaranteUtilizadores(bd, "Pedro Ferreira", "807758604", new DateTime(1974, 07, 01), "Presas", "963332008", "pedro.ferreira@RD-Telecom.com", "9700-308", "Cliente", false, "Açores", new DateTime(2020, 09, 01), 0, 19);
            GaranteUtilizadores(bd, "Fernanda Sousa", "892395559", new DateTime(1969, 08, 06), "Rua Nova", "961322298", "Fernanda.sousa@RD-Telecom.com", "9700-132", "Cliente", false, "Açores", new DateTime(2020, 12, 10), 0, 19);
            GaranteUtilizadores(bd, "Rita Martins", "898142938", new DateTime(1979, 11, 30), "Praça Doutor Sousa Júnior ", "938888789", "rita.martins@RD-Telecom.com", "9700-007", "Cliente", false, "Açores", new DateTime(2020, 10, 11), 0, 19);
            GaranteUtilizadores(bd, "João Patrício", "863866247", new DateTime(2001, 07, 01), "Abaixo do Fragoso", "965811111", "joao.patricio@RD-Telecom.com", "9880-101", "Cliente", false, "Açores", new DateTime(2020, 12, 28), 0, 19);
            GaranteUtilizadores(bd, "Helder Machado", "803990936", new DateTime(1999, 07, 01), "Bairro do Carrapacho", "915235555", "Helder.machado@RD-Telecom.com", "9880-120", "Cliente", false, "Açores", new DateTime(2020, 11, 01), 0, 19);
            GaranteUtilizadores(bd, "Luís Falcão", "809441578", new DateTime(2000, 11, 01), "Bacelo", "925871444", "miriam.falcao@RD-Telecom.com", "9880-103", "Cliente", false, "Açores", new DateTime(2020, 07, 16), 0, 19);
            GaranteUtilizadores(bd, "Vanessa Ribeiro", "862023769", new DateTime(1980, 09, 11), "Avenida Mousinho de Albuquerque", "926557999", "vanessa.ribeiro@RD-Telecom.com", "9880-999", "Cliente", false, "Açores", new DateTime(2020, 09, 21), 0, 19);
            GaranteUtilizadores(bd, "Rafael Leão", "846019183", new DateTime(1975, 02, 24), "Pedras Brancas", "961733331", "rafael.leao@RD-Telecom.com", "9880-171", "Cliente", false, "Açores", new DateTime(2020, 09, 05), 0, 19);
            GaranteUtilizadores(bd, "Célia Francisca", "851087574", new DateTime(1955, 08, 24), "Fajã da Isabel Pereira", "911111821", "celia.francisca@RD-Telecom.com", "9800-101", "Cliente", false, "Açores", new DateTime(2020, 10, 01), 0, 19);
            GaranteUtilizadores(bd, "Rita Freira", "851596118", new DateTime(1956, 06, 05), "Ribeira D'Água", "932228541", "rita.freira@RD-Telecom.com", "9800-209", "Cliente", false, "Açores", new DateTime(2021, 02, 05), 0, 19);

            //    //-------------------------- 20 MADEIRA-----------------
            GaranteUtilizadores(bd, "Patrícia Passarinha", "859762505", new DateTime(2001, 07, 01), "Caminho Ribeira dos Socorridos ", "965388882", "patricia.passarinha@RDtelecom.com", "9000-617", "Cliente", false, "Madeira", new DateTime(2020, 07, 01), 0, 20);
            GaranteUtilizadores(bd, "Marlene Lavrador", "800551257", new DateTime(1968, 11, 21), "2ª Travessa Caminho Arieiro de Baixo", "938555566", "marlene.Lavrador@RDtelecom.com", "9000-602", "Cliente", false, "Madeira", new DateTime(2020, 08, 01), 0, 20);
            GaranteUtilizadores(bd, "Petra Fernandes", "893337951", new DateTime(1988, 09, 01), "Azinhaga Vargem", "96872222", "petra.fernandes@RDtelecom.com", "9000-730", "Cliente", false, "Madeira", new DateTime(2021, 01, 01), 0, 20);
            GaranteUtilizadores(bd, "Vânia Fernandes", "819972525", new DateTime(1969, 07, 06), "Avenida Colégio Militar ", "912330000", "Vania.fernandes@RDtelecom.com", "9000-996", "Cliente", false, "Madeira", new DateTime(2021, 02, 01), 0, 20);
            GaranteUtilizadores(bd, "Pedro Alves", "848937023", new DateTime(1979, 10, 27), "Beco Virtudes", "927499920", "pedro.alves@RDtelecom.com", "9000-616", "Cliente", false, "Madeira", new DateTime(2020, 09, 21), 0, 20);
            GaranteUtilizadores(bd, "Patrícia Gomes", "867937785", new DateTime(1999, 09, 24), "Caminho Arieiro", "963337882", "patricia.gomes@RDtelecom.com", "9000-243 ", "Cliente", false, "Madeira", new DateTime(2020, 10, 28), 0, 20);
            GaranteUtilizadores(bd, "Tiago Prata", "832935352", new DateTime(1999, 07, 18), "Rua Hospital Velho", "924755555", "tiago.prata@RDtelecom.com", "9064-507", "Cliente", false, "Madeira", new DateTime(2020, 11, 28), 0, 20);
            GaranteUtilizadores(bd, "Paula Falcão", "822757753", new DateTime(2000, 01, 26), "Rua Nova Rochinha", "960147886", "paula.falcao@RDtelecom.com", "9064-509", "Cliente", false, "Madeira", new DateTime(2020, 12, 17), 0, 20);
            GaranteUtilizadores(bd, "Inês Santos", "808952331", new DateTime(1980, 09, 30), "Travessa Contracta e Corujeira", "969952033", "ines.santos@RDtelecom.com", "9125-003", "Cliente", false, "Madeira", new DateTime(2020, 09, 10), 0, 20);
            GaranteUtilizadores(bd, "Fábio Martins", "846266369", new DateTime(1975, 02, 10), "Estrada do Garajau Vargem", "960003335", "fabio.martins@RDtelecom.com", "9125-253", "Cliente", false, "Madeira", new DateTime(2021, 02, 10), 0, 20);
            GaranteUtilizadores(bd, "Jaime Antunes", "895001713", new DateTime(1955, 02, 24), "Rua Abegoaria", "912300067", "jaime.antunes@RDtelecom.com", "9125-122", "Cliente", false, "Madeira", new DateTime(2020, 12, 08), 0, 20);
            GaranteUtilizadores(bd, "Joaquim Alves", "854852301", new DateTime(1956, 01, 05), "Cruz", "96000025", "joaquim.alves@RDtelecom.com", "9225-007", "Operador", false, "Madeira", new DateTime(2020, 12, 12), 0, 20);

            //---------------OPERADORES--------------------

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
            GaranteUtilizadores(bd, "Paula Piruvato", "275433641", new DateTime(1992, 09, 04), "Largo dos Cadeirões", "935751153", "ana.brito@RDtelecom.com", "7920-002", "Operador", false, "Beja", new DateTime(2021, 02, 28), 0, 2);
            GaranteUtilizadores(bd, "Thomas Lourenço", "142518093", new DateTime(1979, 04, 06), "Praça do Ultramar", "928963321", "luis.neto@RDtelecom.com", "7801-857", "Operador", false, "Beja", new DateTime(2020, 10, 28), 0, 2);
            GaranteUtilizadores(bd, "Luís Smith", "172501482", new DateTime(1975, 06, 08), "Moitinhas", "960154784", "freitas.mondego@RDtelecom.com", "7665-803", "Operador", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            GaranteUtilizadores(bd, "Márcia Wood", "265371988", new DateTime(1972, 11, 27), "Ribeira de Torquinhos", "921789321", "joao.cardoso@RDtelecom.com", "7665-814", "Operador", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            GaranteUtilizadores(bd, "Jerónimo Graciano", "244225834", new DateTime(1956, 05, 22), "Rua da Cova da Burra", "928032965", "rita.brandao@RDtelecom.com", "7700-003", "Operador", false, "Beja", new DateTime(2021, 01, 05), 0, 2);

            //    //-------------------------- 3 BRAGA------------------
            GaranteUtilizadores(bd, "Fernando Couto", "239833252", new DateTime(1977, 03, 19), "Rua dos Bombeiros Voluntários", "960023231", "fernado.couto@RDtelecom.com", "4700-002", "Operador", false, "Braga", new DateTime(2020, 12, 05), 0, 3);
            GaranteUtilizadores(bd, "Deolinda Bacalhau", "292716222", new DateTime(2001, 05, 21), "Rua Professora Alda Brandão Real", "933584787", "deolinda.bacalhau@RDtelecom.com", "4700-002", "Operador", false, "Braga", new DateTime(2020, 11, 17), 0, 3);
            GaranteUtilizadores(bd, "Ivanilda Pessoa", "206870523", new DateTime(1977, 08, 01), "Rua da Sobreira Frossos", "923001221", "ivanilda.pessoa@RDtelecom.com", "4700-441", "Operador", false, "Braga", new DateTime(2020, 12, 26), 0, 3);
            GaranteUtilizadores(bd, "Onofre Galvão", "267894422", new DateTime(1969, 04, 30), "Largo de Maximinos", "928976413", "onofre.galvao@RDtelecom.com", "4700-999", "Operador", false, "Braga", new DateTime(2020, 12, 10), 0, 3);
            GaranteUtilizadores(bd, "Ian Coelho", "249703238", new DateTime(2002, 01, 31), "Largo de São Tiago", "92587963", "ian.coelho@RDtelecom.com", "4704-504", "Operador", false, "Braga", new DateTime(2020, 11, 05), 0, 3);
            GaranteUtilizadores(bd, "Ryan Oliveira", "240442571", new DateTime(1988, 03, 05), "Rua das Oliveiras", "920322333", "ryan.oliveira@RDtelecom.com", "4705-790", "Operador", false, "Braga", new DateTime(2020, 11, 28), 0, 3);
            GaranteUtilizadores(bd, "Marizete Gillot", "285368559", new DateTime(1956, 10, 04), "Rua dos Caixoteiros", "922001789", "marizete.gillot@RDtelecom.com", "4705-001", "Operador", false, "Braga", new DateTime(2020, 10, 07), 0, 3);
            GaranteUtilizadores(bd, "Beto da Alegria", "249227673", new DateTime(1957, 03, 17), "Rua Sem Nome", "925567841", "beto.alegria@RDtelecom.com", "4750-008", "Operador", false, "Braga", new DateTime(2021, 01, 05), 0, 3);
            GaranteUtilizadores(bd, "Pinheiro dos Santos", "273654888", new DateTime(1970, 02, 28), "Travessa do Rio da Guarda", "921003288", "pinheiro.santos@RDtelecom.com", "4765-489", "Operador", false, "Braga", new DateTime(2021, 02, 05), 0, 3);
            GaranteUtilizadores(bd, "Divina de Jesus", "268345139", new DateTime(1958, 11, 30), "Rua Cães de Pedra Lt 5", "921785432", "divina.jesus@RDtelecom.com", "4835-003", "Operador", false, "Braga", new DateTime(2021, 02, 12), 0, 3);
            GaranteUtilizadores(bd, "Irina Leite", "263696340", new DateTime(1999, 10, 27), "Rua da Madalena", "929633600", "irina.leite@RDtelecom.com", "4835-511", "Operador", false, "Braga", new DateTime(2021, 01, 14), 0, 3);

            //    //-------------------------- 4 BRAGANÇA------------------
            GaranteUtilizadores(bd, "Natally Domingues", "239833252", new DateTime(1974, 06, 19), "Bairro Moinho de Vento", "939007258", "natally.domingues@RDtelecom.com", "5140-005", "Operador", false, "Bragança", new DateTime(2020, 11, 13), 0, 4);
            GaranteUtilizadores(bd, "Nicolau Figueiras", "292716222", new DateTime(2001, 01, 21), "Quinta Lameira de Ferro", "932101491", "nicolau.figueiras@RDtelecom.com", "5140-135", "Operador", false, "Bragança", new DateTime(2020, 10, 27), 0, 4);
            GaranteUtilizadores(bd, "John Dias", "206870523", new DateTime(1987, 09, 03), "Rua Sem Nome 218 Bairro Além do Rio ", "966852031", "john.dias@RDtelecom.com", "5300-001", "Operador", false, "Bragança", new DateTime(2020, 10, 25), 0, 4);
            GaranteUtilizadores(bd, "Maria Leal", "267894422", new DateTime(1969, 09, 30), "Rua da Fragata", "923455896", "maria.leal@RDtelecom.com", "5385-101", "Operador", false, "Bragança", new DateTime(2020, 11, 12), 0, 4);
            GaranteUtilizadores(bd, "Isabel dos Santinhos", "249703238", new DateTime(1957, 05, 31), "Valbom Pitez", "922788996", "isabel.santinhos@RDtelecom.com", "5385-132", "Operador", false, "Bragança", new DateTime(2020, 12, 07), 0, 4);
            GaranteUtilizadores(bd, "Rui Fragona", "240442571", new DateTime(1988, 03, 07), "Azenha do Areal", "920335411", "rui.fragona@RDtelecom.com", "5370-131", "Operador", false, "Bragança", new DateTime(2020, 12, 18), 0, 4);
            GaranteUtilizadores(bd, "Dunildo de Boa Esperança", "285368559", new DateTime(2000, 10, 04), "Vale de Lobo", "929693914", "dunildo.esperanca@RDtelecom.com", "5370-102", "Operador", false, "Bragança", new DateTime(2020, 12, 24), 0, 4);
            GaranteUtilizadores(bd, "Carla Dorys", "249227673", new DateTime(1995, 08, 17), "Vilar Seco", "963321087", "carla.dorys@RDtelecom.com", "5350-204", "Operador", false, "Bragança", new DateTime(2020, 10, 05), 0, 4);
            GaranteUtilizadores(bd, "Birna de Oliveira", "273654888", new DateTime(1980, 02, 28), "Rua dos Combatentes da Grande Guerra", "930147852", "birna.oliveira@RDtelecom.com", "5301-861", "Operador", false, "Bragança", new DateTime(2021, 03, 05), 0, 4);
            GaranteUtilizadores(bd, "João Salgado", "268345139", new DateTime(1966, 11, 30), "Rua Cova da Beira", "926698230", "joao.salgado@RDtelecom.com", "5300-869", "Operador", false, "Bragança", new DateTime(2021, 01, 05), 0, 4);
            GaranteUtilizadores(bd, "Feitosa Pauleta", "263696340", new DateTime(1972, 10, 27), "Rotunda do Lavrador Bairro da Braguinha ", "921033025", "feitosa.pauleta@RDtelecom.com", "5300-420", "Operador", false, "Bragança", new DateTime(2021, 02, 21), 0, 4);

            //    //-------------------------- 5 CASTELO BRANCO------------------
            GaranteUtilizadores(bd, "Cláudia Vieira", "195173210", new DateTime(1965, 06, 19), "Rua das Rosas", "933896541", "claudia.vieira@RDtelecom.com", "6250-004", "Operador", false, "Castelo Branco", new DateTime(2020, 10, 11), 0, 5);
            GaranteUtilizadores(bd, "Diogo Andrade", "136693199", new DateTime(1999, 01, 21), "Sítio do Cabecinho", "937258852", "diogo.andrade@RDtelecom.com", "6250-111", "Operador", false, "Castelo Branco", new DateTime(2020, 09, 05), 0, 5);
            GaranteUtilizadores(bd, "Maria Ruah", "116663987", new DateTime(1988, 02, 03), "Quinta de Valverdinho", "963012547", "maria.ruah@RDtelecom.com", "6250-163", "Operador", false, "Castelo Branco", new DateTime(2020, 11, 03), 0, 5);
            GaranteUtilizadores(bd, "Florbela Antunes", "127533818", new DateTime(1980, 09, 30), "Rua do Curral", "922013645", "florbela.antunes@RDtelecom.com", "6215-001", "Operador", false, "Castelo Branco", new DateTime(2020, 11, 20), 0, 5);
            GaranteUtilizadores(bd, "António Antunes", "111712580", new DateTime(1974, 05, 31), "Rua Marquês de Ávila e Bolama", "928328961", "antonio.antunes@RDtelecom.com", "6201-001", "Operador", false, "Castelo Branco", new DateTime(2020, 12, 22), 0, 5);
            GaranteUtilizadores(bd, "Liliana Aveiro", "183191404", new DateTime(2000, 03, 07), "Viela do Castelo", "927031759", "liliana.aveiro@RDtelecom.com", "6200-227", "Operador", false, "Castelo Branco", new DateTime(2020, 11, 18), 0, 5);
            GaranteUtilizadores(bd, "Maria Pedroso", "161954464", new DateTime(2000, 10, 04), "Travessa das Trapas", "924630158", "maria.pedroso@RDtelecom.com", "6200-237", "Operador", false, "Castelo Branco", new DateTime(2020, 11, 17), 0, 5);
            GaranteUtilizadores(bd, "Pedro Fernandes", "182518434", new DateTime(1957, 08, 17), "Bairro da Formiguinha Vila do Carvalho", "966332157", "pedro.fernandes@RDtelecom.com", "6200-241", "Operador", false, "Castelo Branco", new DateTime(2021, 01, 13), 0, 5);
            GaranteUtilizadores(bd, "Miguel Moniz", "145814360", new DateTime(1962, 02, 28), "Rua das Tendas", "933212269", "miguel.moniz@RDtelecom.com", "6200-699", "Operador", false, "Castelo Branco", new DateTime(2020, 11, 11), 0, 5);
            GaranteUtilizadores(bd, "Felisberto Ortiz", "114162123", new DateTime(1971, 02, 28), "Travessa dos Escabelados", "922100366", "felisberto.ortiz@RDtelecom.com", "6200-742", "Operador", false, "Castelo Branco", new DateTime(2021, 02, 20), 0, 5);
            GaranteUtilizadores(bd, "António Sanchez", "163492115", new DateTime(1976, 11, 27), "Rua Canada", "925644710", "antonio.sanchez@RDtelecom.com", "6005-002", "Operador", false, "Castelo Branco", new DateTime(2021, 01, 13), 0, 5);

            //    //-------------------------- 6 COIMBRA-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "248858939", new DateTime(1999, 07, 01), "Rua do Norte", "929188821", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, "Coimbra", new DateTime(2020, 10, 05), 0, 6);
            GaranteUtilizadores(bd, "Marlene Santos", "123456789", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "933298771", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, "Coimbra", new DateTime(2020, 12, 01), 0, 6);
            GaranteUtilizadores(bd, "João Ferreira", "233333231", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "929155551", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, "Coimbra", new DateTime(2020, 11, 26), 0, 6);
            GaranteUtilizadores(bd, "Tânia Sousa", "233259627", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "927854121", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, "Coimbra", new DateTime(2020, 10, 27), 0, 6);
            GaranteUtilizadores(bd, "Rute Martins", "221639896", new DateTime(1979, 10, 30), "Cruz de Ferro", "929154199", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, "Coimbra", new DateTime(2020, 09, 25), 0, 6);
            GaranteUtilizadores(bd, "Paulo Pedra", "215922158", new DateTime(1999, 07, 01), "Rua do Norte", "929155501", "paulo.pedra@RDtelecom.com", "3000-295", "Operador", false, "Coimbra", new DateTime(2020, 10, 11), 0, 6);
            GaranteUtilizadores(bd, "Helder Copeto", "209281472", new DateTime(1999, 07, 01), "Rua do Norte", "929157411", "helder.copeto@RDtelecom.com", "3000-295", "Operador", false, "Coimbra", new DateTime(2020, 10, 11), 0, 6);
            GaranteUtilizadores(bd, "Miriam Falcão", "218052421", new DateTime(2000, 01, 01), "Vale Derradeiro", "929159871", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, "Coimbra", new DateTime(2020, 10, 11), 0, 6);
            GaranteUtilizadores(bd, "Célia Tomate", "224046284", new DateTime(1980, 09, 11), "Seladinhas", "929199991", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, "Coimbra", new DateTime(2021, 02, 18), 0, 6);
            GaranteUtilizadores(bd, "Tadeu Leão", "294178775", new DateTime(1975, 02, 08), "Flor da Rosa", "929100021", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, "Coimbra", new DateTime(2021, 03, 11), 0, 6);
            GaranteUtilizadores(bd, "Harley Guerra", "230936679", new DateTime(1955, 12, 24), "Beco da Alegria", "929004121", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, "Coimbra", new DateTime(2021, 02, 20), 0, 6);
            GaranteUtilizadores(bd, "Afonso Freira", "271671130", new DateTime(1956, 12, 05), "Beco das Cruzes", "929154555", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, "Coimbra", new DateTime(2021, 01, 11), 0, 6);


            //    //-------------------------- 7 EVORA-----------------
            GaranteUtilizadores(bd, "Andreia Alves", "238122549", new DateTime(2001, 07, 01), "Vale de Pegas", "921456654", "andreia.alves@RDtelecom.com", "7490-120", "Operador", false, "Évora", new DateTime(2020, 10, 17), 0, 7);
            GaranteUtilizadores(bd, "João Correia", "270613994", new DateTime(1999, 11, 21), "Rua João de Deus", "936825714", "joao.correia@RDtelecom.com", "7250-142", "Operador", false, "Évora", new DateTime(2020, 09, 28), 0, 7);
            GaranteUtilizadores(bd, "Ricardo da Gama", "205118615", new DateTime(1975, 07, 01), "Rua da Liberdade", "920147963", "ricardo.gama@RDtelecom.com", "7220-002", "Operador", false, "Évora", new DateTime(2020, 09, 26), 0, 7);
            GaranteUtilizadores(bd, "Inês Castro", "278968724", new DateTime(1969, 06, 08), "Rua dos Irmãos", "927369148", "ines.castro@RDtelecom.com", "7220-003", "Operador", false, "Évora", new DateTime(2020, 11, 13), 0, 7);
            GaranteUtilizadores(bd, "Andressa Ribeiro", "220236410", new DateTime(1962, 03, 30), "Praceta do Brasil", "928741147", "andressa.ribeiro@RDtelecom.com", "7200-479", "Operador", false, "Évora", new DateTime(2020, 11, 07), 0, 7);
            GaranteUtilizadores(bd, "Pablo Abrunhosa", "201957060", new DateTime(1980, 07, 01), "Rua Projectada à Avenida Tomás Alcaide", "926951753", "pablo.abrunhosa@RDtelecom.com", "7100-130", "Operador", false, "Évora", new DateTime(2020, 11, 05), 0, 7);
            GaranteUtilizadores(bd, "Ramon Marques", "246386339", new DateTime(1999, 07, 01), "Travessa das Amendoeiras", "920147895", "ramon.marques@RDtelecom.com", "7090-006", "Operador", false, "Évora", new DateTime(2020, 10, 03), 0, 7);
            GaranteUtilizadores(bd, "Mariana da Serenidade", "269577556", new DateTime(1999, 01, 01), "Bairro Ferragolo", "922333698", "mariana.serenidade@RDtelecom.com", "7080-109", "Operador", false, "Évora", new DateTime(2020, 11, 26), 0, 7);
            GaranteUtilizadores(bd, "Dilma Rosas", "253854040", new DateTime(1958, 09, 21), "Casa de Pau", "920032147", "dilma.rosas@RDtelecom.com", "7050-634", "Operador", false, "Évora", new DateTime(2020, 11, 26), 0, 7);
            GaranteUtilizadores(bd, "Vicente Silva", "281567182", new DateTime(1965, 02, 08), "Largo das Alterações", "931456321", "vicente.silva@RDtelecom.com", "7000-502", "Operador", false, "Évora", new DateTime(2021, 01, 26), 0, 7); ;
            GaranteUtilizadores(bd, "Flascotter Pereira", "286365723", new DateTime(1995, 03, 24), "Rua Francisco Soares Lusitano", "966333210", "flascotter.pereira@RDtelecom.com", "7004-511", "Operador", false, "Évora", new DateTime(2021, 01, 26), 0, 7);
            GaranteUtilizadores(bd, "Sara Moedas", "278661610", new DateTime(1956, 05, 05), "Largo dos Colegiais 2", "933225871", "sara.moedas@RDtelecom.com", "7004-516", "Operador", false, "Évora", new DateTime(2021, 02, 26), 0, 7);

            //    //-------------------------- 8 FARO-----------------
            GaranteUtilizadores(bd, "Miguel Rossi", "298933896", new DateTime(1999, 07, 01), "Rua da Viola ", "925874100", "miguel.rossi@RDtelecom.com", "8000-274", "Operador", false, "Faro", new DateTime(2020, 12, 28), 0, 8);
            GaranteUtilizadores(bd, "Martina Castilho", "290825091", new DateTime(1988, 11, 21), "Rua do Bocage", "933302145", "martina.castilho@RDtelecom.com", "8004-002", "Operador", false, "Faro", new DateTime(2020, 12, 06), 0, 8);
            GaranteUtilizadores(bd, "Romeo Ximenes", "256438676", new DateTime(1978, 07, 01), "Areal Gordo", "932587410", "romeo.ximenes@RDtelecom.com", "8005-409", "Operador", false, "Faro", new DateTime(2020, 11, 17), 0, 8);
            GaranteUtilizadores(bd, "John Pitt", "200101447", new DateTime(1969, 06, 06), "Travessa do Borrego", "933666520", "john.pitt@RDtelecom.com", "8125-002", "Operador", false, "Faro", new DateTime(2020, 09, 17), 0, 8);
            GaranteUtilizadores(bd, "Zézinho Camarrinha", "213627736", new DateTime(1979, 10, 30), "Beco das Palmeiras", "921230002", "zezinho.camarrinha@RDtelecom.com", "8125-609", "Operador", false, "Faro", new DateTime(2020, 10, 19), 0, 8);
            GaranteUtilizadores(bd, "Luna Smith", "254704085", new DateTime(1999, 07, 01), "Beco Condestável", "925666417", "luna.smith@RDtelecom.com", "8125-636", "Operador", false, "Faro", new DateTime(2020, 10, 27), 0, 8);
            GaranteUtilizadores(bd, "Luísa Salvador", "261746227", new DateTime(1999, 06, 01), "Beco dos Bitas", "936254102", "luisa.salvador@RDtelecom.com", "8200-002", "Operador", false, "Faro", new DateTime(2020, 10, 26), 0, 8);
            GaranteUtilizadores(bd, "Ana Cacho", "255512546", new DateTime(2000, 01, 01), "Rua das Telecomunicações", "920320001", "ana.cacho@RDtelecom.com", "8201-871", "Operador", false, "Faro", new DateTime(2020, 11, 17), 0, 8);
            GaranteUtilizadores(bd, "Fernando Rock", "203265424", new DateTime(1980, 09, 11), "Caminho Municipal", "967369874", "fernando.rock@RDtelecom.com", "8201-877", "Operador", false, "Faro", new DateTime(2021, 03, 17), 0, 8);
            GaranteUtilizadores(bd, "Miguel Feliz", "299944611", new DateTime(1975, 02, 08), "Avenida dos Descobrimentos", "921321111", "miguel.feliz@RDtelecom.com", "8601-852", "Operador", false, "Faro", new DateTime(2021, 02, 17), 0, 8);
            GaranteUtilizadores(bd, "Maria Ferrari", "226395324", new DateTime(1955, 12, 24), "Rua 25 de Abril", "917854123", "maria.ferrari@RDtelecom.com", "8801-005", "Operador", false, "Faro", new DateTime(2021, 01, 28), 0, 8);
            GaranteUtilizadores(bd, "Bruno da Câmara Pereira", "231898975", new DateTime(1956, 12, 05), "Monte Olimpio", "917364825", "bruno.pereira@RDtelecom.com", "8900-106", "Operador", false, "Faro", new DateTime(2021, 01, 15), 0, 8);


            //    //-------------------------- 9 GUARDA-----------------
            GaranteUtilizadores(bd, "Alicia Sancho", "240315170", new DateTime(1988, 07, 01), "Ponte do Abade", "926999852", "alicia.sancho@RDtelecom.com", "3570-191", "Operador", false, "Guarda", new DateTime(2020, 11, 03), 0, 9);
            GaranteUtilizadores(bd, "Mateo Jesus", "216994918", new DateTime(1964, 11, 21), "Rua Quebra Costas", "933022589", "mateo.jesus@RDtelecom.com", "5155-003", "Operador", false, "Guarda", new DateTime(2020, 10, 18), 0, 9);
            GaranteUtilizadores(bd, "Antonnella Conti", "262339374", new DateTime(1954, 08, 01), "Zurrão", "922557410", "antonnella.conti@RDtelecom.com", "6260-196", "Operador", false, "Guarda", new DateTime(2020, 09, 20), 0, 9);
            GaranteUtilizadores(bd, "Nuno Gatti", "281167222", new DateTime(1970, 02, 06), "Carvalhal da Louça", "923654789", "nuno.gatti@RDtelecom.com", "6270-131", "Operador", false, "Guarda", new DateTime(2020, 10, 28), 0, 9);
            GaranteUtilizadores(bd, "Patrícia Carbone", "253533643", new DateTime(1980, 03, 30), "Rua Amadeus Mozart", "966968749", "patricia.carbone@RDtelecom.com", "6300-509", "Operador", false, "Guarda", new DateTime(2020, 12, 28), 0, 9);
            GaranteUtilizadores(bd, "Pedro Guerra", "254138349", new DateTime(1999, 08, 01), "Muxagata", "923456987", "pedro.guerra@RDtelecom.com", "6370-361", "Operador", false, "Guarda", new DateTime(2020, 10, 28), 0, 9);
            GaranteUtilizadores(bd, "Célia Valente", "263953840", new DateTime(1999, 07, 01), "Juncais", "910002658", "celia.valente@RDtelecom.com", "6370-332", "Operador", false, "Guarda", new DateTime(2020, 11, 28), 0, 9);
            GaranteUtilizadores(bd, "Rosa Serra", "281900361", new DateTime(2000, 01, 01), "Quinta da Costa", "92888632", "rosa.serra@RDtelecom.com", "6324-004", "Operador", false, "Guarda", new DateTime(2020, 12, 05), 0, 9);
            GaranteUtilizadores(bd, "Ricardo Estrela", "206569327", new DateTime(1987, 09, 17), "Parada", "963011456", "ricardo.estrla@RDtelecom.com", "6355-142", "Operador", false, "Guarda", new DateTime(2021, 02, 28), 0, 9);
            GaranteUtilizadores(bd, "Carlos Fechaduras", "220640610", new DateTime(1859, 05, 08), "Senouras", "925666874", "carlos.fechaduras@RDtelecom.com", "6355-170", "Operador", false, "Guarda", new DateTime(2021, 03, 01), 0, 9);
            GaranteUtilizadores(bd, "Álvaro Bruxelas", "210346760", new DateTime(1958, 12, 31), "Beco da Alegria", "91025800", "alvaro.bruxelas@RDtelecom.com", "6355-170", "Operador", false, "Guarda", new DateTime(2021, 01, 20), 0, 9);
            GaranteUtilizadores(bd, "Isamara Lobão", "215494725", new DateTime(1956, 12, 05), "Lajeosa", "936058777", "isamara.lobao@RDtelecom.com", "6320-161", "Operador", false, "Guarda", new DateTime(2021, 01, 28), 0, 9);

            //    //-------------------------- 10 LEIRIA-----------------
            GaranteUtilizadores(bd, "Amílcar Malho", "119888068", new DateTime(1967, 03, 01), "Rua dos Inácios", "923600144", "amilcar.malho@RDtelecom.com", "2400-773", "Operador", false, "Leiria", new DateTime(2020, 10, 18), 0, 10);
            GaranteUtilizadores(bd, "Joana de Sá", "131092812", new DateTime(1966, 11, 21), "Rua do Futuro", "930054711", "joana.sa@RDtelecom.com", "2400-760", "Operador", false, "Leiria", new DateTime(2020, 09, 25), 0, 10);
            GaranteUtilizadores(bd, "João Cabral", "161270441", new DateTime(2000, 06, 01), "Moinho do Rato", "925632008", "joao.cabral@RDtelecom.com", "2410-528", "Operador", false, "Leiria", new DateTime(2020, 10, 25), 0, 10);
            GaranteUtilizadores(bd, "Ilídio Brazeta", "140129375", new DateTime(1999, 06, 09), "Rua de Saint-Maur-Des-Fosses", "963012547", "ilidio.brazeta@RDtelecom.com", "2414-001", "Operador", false, "Leiria", new DateTime(2020, 10, 08), 0, 10);
            GaranteUtilizadores(bd, "Ricardo Caramelo", "161728219", new DateTime(1984, 02, 28), "Estrada da Mata Marrazes", "921456920", "ricardo.caramelo@RDtelecom.com", "2419-001", "Operador", false, "Leiria", new DateTime(2020, 10, 03), 0, 10);
            GaranteUtilizadores(bd, "João Figo", "175938652", new DateTime(1999, 07, 11), "Rua de Santa Margarida", "923001458", "joao.figo@RDtelecom.com", "2420-999", "Operador", false, "Leiria", new DateTime(2020, 11, 28), 0, 10);
            GaranteUtilizadores(bd, "Romina Santos", "163520500", new DateTime(1999, 07, 01), "Beco Grilo", "931478569", "romina.santos@RDtelecom.com", "2460-005", "Operador", false, "Leiria", new DateTime(2020, 11, 17), 0, 10);
            GaranteUtilizadores(bd, "Rui Rosa", "103294708", new DateTime(2000, 01, 01), "Rua Mercedes e Carlos Campeão", "968547000", "rui.rosa@RDtelecom.com", "2460-006", "Operador", false, "Leiria", new DateTime(2020, 11, 12), 0, 10);
            GaranteUtilizadores(bd, "Vanda Ruivo", "109509552", new DateTime(1980, 10, 11), "Bolo", "922365009", "vanda.ruivo@RDtelecom.com", "3280-113", "Operador", false, "Leiria", new DateTime(2020, 11, 03), 0, 10);
            GaranteUtilizadores(bd, "Tiago Andrade", "163600937", new DateTime(1975, 08, 08), "Sapateira", "967896333", "tiago.andrade@RDtelecom.com", "3280-123", "Operador", false, "Leiria", new DateTime(2020, 11, 03), 0, 10);
            GaranteUtilizadores(bd, "Marta Martinelli", "195614313", new DateTime(1988, 12, 24), "Rua dos Lavadouros", "910258963", "marta.martinelli@RDtelecom.com", "2525-123", "Operador", false, "Leiria", new DateTime(2021, 03, 03), 0, 10);
            GaranteUtilizadores(bd, "Joaquim Vitale", "116386428", new DateTime(1996, 12, 05), "Picha", "939391250", "joaquim.vitale@RDtelecom.com", "3270-143", "Operador", false, "Leiria", new DateTime(2021, 01, 03), 0, 10);


            //    //-------------------------- 11 LISBOA-----------------
            GaranteUtilizadores(bd, "Geraldo Fraga", "126914966", new DateTime(1968, 08, 01), "Rua Brito Aranha", "924141230", "geraldo.fraga@RDtelecom.com", "1000-007", "Operador", false, "Lisboa", new DateTime(2020, 10, 13), 0, 11);
            GaranteUtilizadores(bd, "Celeste Djata", "196656087", new DateTime(1969, 11, 28), "Avenida dos Defensores de Chaves", "937182456", "celeste.djata@RDtelecom.com", "1049-004", "Operador", false, "Lisboa", new DateTime(2020, 10, 18), 0, 11);
            GaranteUtilizadores(bd, "Carla Costa", "176965173", new DateTime(1978, 05, 01), "Largo das Palmeiras", "931773910", "carla.costa@RDtelecom.com", "1050-168", "Operador", false, "Lisboa", new DateTime(2020, 10, 14), 0, 11);
            GaranteUtilizadores(bd, "Daniele Lucas", "110466721", new DateTime(1973, 08, 06), "Avenida de Berna", "917182935", "daniele.lucas@RDtelecom.com", "1067-001", "Operador", false, "Lisboa", new DateTime(2020, 11, 08), 0, 11);
            GaranteUtilizadores(bd, "Davide Ramos", "171941195", new DateTime(1986, 10, 30), "Vila Celeste Rua Garcia", "961455620", "davide.ramos@RDtelecom.com", "1070-136", "Operador", false, "Lisboa", new DateTime(2020, 12, 18), 0, 11);
            GaranteUtilizadores(bd, "Diana Leite", "164398112", new DateTime(1999, 07, 01), "Beco Benformoso", "967410226", "diana.leite@RDtelecom.com", "1100-008", "Operador", false, "Lisboa", new DateTime(2020, 11, 09), 0, 11);
            GaranteUtilizadores(bd, "Dunildo Fernandes", "133792285", new DateTime(1988, 07, 01), "Largo Cabeço da Bola", "937852013", "dunildo.fernandes@RDtelecom.com", "1150-008", "Operador", false, "Lisboa", new DateTime(2020, 11, 02), 0, 11);
            GaranteUtilizadores(bd, "Beatriz Testa", "141553898", new DateTime(2000, 01, 01), "Beco da Bempostinha", "931456110", "beatriz.testa@RDtelecom.com", "1150-006", "Operador", false, "Lisboa", new DateTime(2020, 10, 10), 0, 11);
            GaranteUtilizadores(bd, "Pedro Farina", "177572280", new DateTime(2000, 09, 29), "Rua dos Anjos", "969391789", "pedro.farina@RDtelecom.com", "1169-004", "Operador", false, "Lisboa", new DateTime(2020, 10, 18), 0, 11);
            GaranteUtilizadores(bd, "Bernardino Caputo", "150336322", new DateTime(1975, 02, 08), "Rua dos Lusíadas", "919320365", "bernardino.caputo@RDtelecom.com", "1349-006", "Operador", false, "Lisboa", new DateTime(2021, 03, 10), 0, 11);
            GaranteUtilizadores(bd, "Pablo Medina", "153510340", new DateTime(1955, 08, 24), "Cabeça Gorda", "932514789", "pablo.medina@RDtelecom.com", "2565-001", "Operador", false, "Lisboa", new DateTime(2021, 02, 23), 0, 11);
            GaranteUtilizadores(bd, "Eva Simões", "170633977", new DateTime(1969, 12, 18), "Avenida João de Belas", "930258789", "eva.simoes@RDtelecom.com", "2605-203", "Operador", false, "Lisboa", new DateTime(2021, 01, 18), 0, 11);

            //    //-------------------------- 12 PORTALEGRE-----------------
            GaranteUtilizadores(bd, "Paula Neves", "246991585", new DateTime(1987, 05, 01), "Torre Cimeira", "969691321", "paula.neves@RDtelecom.com", "6040-003", "Operador", false, "Portalegre", new DateTime(2020, 09, 27), 0, 12);
            GaranteUtilizadores(bd, "Filipe Pinto", "207370133", new DateTime(1988, 10, 21), "Rua do Poço", "936285714", "filipe.pinto@RDtelecom.com", "6050-106", "Operador", false, "Portalegre", new DateTime(2020, 10, 29), 0, 12);
            GaranteUtilizadores(bd, "Ryan Vieira", "258078286", new DateTime(1968, 07, 13), "Ribeiro do Buraco", "921326554", "ryan.vieira@RDtelecom.com", "7300-351", "Operador", false, "Portalegre", new DateTime(2020, 10, 07), 0, 12);
            GaranteUtilizadores(bd, "Rodrigo Amarelo", "292120265", new DateTime(1970, 06, 28), "Cubos", "925632214", "rodrigo.amarelo@RDtelecom.com", "7300-316", "Operador", false, "Portalegre", new DateTime(2020, 12, 06), 0, 12);
            GaranteUtilizadores(bd, "Rita Abrantes", "210764333", new DateTime(1984, 10, 07), "Praça do Município", "960321123", "rita.abrantes@RDtelecom.com", "7301-855", "Operador", false, "Portalegre", new DateTime(2020, 11, 20), 0, 12);
            GaranteUtilizadores(bd, "Luís Rico", "246103230", new DateTime(1982, 07, 18), "Travessa da Rua do Comércio", "911233698", "luis.rico@RDtelecom.com", "7301-857", "Operador", false, "Portalegre", new DateTime(2020, 10, 25), 0, 12);
            GaranteUtilizadores(bd, "Helder Conceição", "247266221", new DateTime(1973, 07, 01), "Rua das Encruzilhadas", "936200145", "helder.conceicao@RDtelecom.com", "7320-123", "Operador", false, "Portalegre", new DateTime(2020, 10, 19), 0, 12);
            GaranteUtilizadores(bd, "Mariza Falcão", "265156343", new DateTime(2000, 01, 01), "Portas do Sol", "968574123", "mariza.falcao@RDtelecom.com", "7350-002", "Operador", false, "Portalegre", new DateTime(2020, 11, 13), 0, 12);
            GaranteUtilizadores(bd, "Lúcio Junior", "284225959", new DateTime(1980, 09, 16), "Rua da Guarda", "961425632", "lucio.junior@RDtelecom.com", "7350-002", "Operador", false, "Portalegre", new DateTime(2021, 02, 28), 0, 12);
            GaranteUtilizadores(bd, "Tiago Silva", "256300291", new DateTime(1975, 02, 24), "Rua do Escorregadio", "916914785", "tiago.silva@RDtelecom.com", "7350-002", "Operador", false, "Portalegre", new DateTime(2021, 01, 20), 0, 12);
            GaranteUtilizadores(bd, "Ana Godinho", "274980398", new DateTime(1968, 12, 19), "Rua do Emigrante", "923654782", "ana.godinho@RDtelecom.com", "7370-001", "Operador", false, "Portalegre", new DateTime(2021, 02, 22), 0, 12);
            GaranteUtilizadores(bd, "Filipa Oliveira", "270511059", new DateTime(1956, 12, 05), "Rua Marciano Cipriano", "923654741", "filipa.oliveira@RDtelecom.com", "7370-002", "Operador", false, "Portalegre", new DateTime(2021, 01, 13), 0, 12);

            //-------------------------- 13 PORTO-----------------
            GaranteUtilizadores(bd, "Patrícia Amaral", "232501173", new DateTime(1986, 03, 01), "Largo Escultor José Moreira da Silva", "968574000", "patricia.amaral@RDtelecom.com", "4000-312", "Operador", false, "Porto", new DateTime(2020, 08, 05), 0, 13);
            GaranteUtilizadores(bd, "João Santos", "255170262", new DateTime(1988, 11, 14), "Rua Latino Coelho Pares", "933220655", "joao.santos@RDtelecom.com", "4000-314", "Operador", false, "Porto", new DateTime(2021, 01, 05), 0, 13);
            GaranteUtilizadores(bd, "João Ferreira", "279641966", new DateTime(1963, 03, 01), "Rua de Moreira Ímpares", "923002564", "joao.ferreira@RDtelecom.com", "4000-346", "Operador", false, "Porto", new DateTime(2020, 10, 11), 0, 13);
            GaranteUtilizadores(bd, "Tânia Pereira", "265227186", new DateTime(1967, 06, 03), "Rua do Alto da Fontinha", "968321008", "tania.pereira@RDtelecom.com", "4000-007", "Operador", false, "Porto", new DateTime(2020, 08, 12), 0, 13);
            GaranteUtilizadores(bd, "Rute Pequena", "220300828", new DateTime(1975, 02, 28), "Rua Júlio Dinis Fast-Food Mister Pick Wick", "925654197", "rute.pequena@RDtelecom.com", "4050-001", "Operador", false, "Porto", new DateTime(2020, 10, 17), 0, 13);
            GaranteUtilizadores(bd, "Paulo Jorge", "215830300", new DateTime(1998, 07, 11), "Rua Júlio Dinis", "923685203", "paulo.jorge@RDtelecom.com", "4050-322", "Operador", false, "Porto", new DateTime(2020, 08, 18), 0, 13);
            GaranteUtilizadores(bd, "Helder Reis", "222960540", new DateTime(1999, 07, 01), "Travessa Marracuene", "923654780", "helder.reis@RDtelecom.com", "4050-357", "Operador", false, "Porto", new DateTime(2020, 08, 26), 0, 13);
            GaranteUtilizadores(bd, "Lucas Castilho", "204095387", new DateTime(1974, 01, 01), "Rua Guerra Junqueiro", "936002365", "tome.fernandes@RDtelecom.com", "4169-009", "Operador", false, "Porto", new DateTime(2020, 08, 27), 0, 13);
            GaranteUtilizadores(bd, "Tomé Fernades", "240389263", new DateTime(1985, 06, 11), "Rua do Campo Alegre", "927183608", "tome.fernandes@RDtelecom.com", "4169-007", "Operador", false, "Porto", new DateTime(2020, 08, 25), 0, 13);
            GaranteUtilizadores(bd, "Paula Andrade", "210053895", new DateTime(1962, 02, 08), "Rua Gonçalo Sampaio", "925328961", "paula.andrade@RDtelecom.com", "4169-001", "Operador", false, "Porto", new DateTime(2020, 11, 10), 0, 13);
            GaranteUtilizadores(bd, "Jacinto Dias", "267983921", new DateTime(1957, 03, 24), "Rua do Campo Alegre", "968321520", "jacinto.dias@RDtelecom.com", "4169 - 007", "Operador", false, "Porto", new DateTime(2020, 10, 05), 0, 13);
            GaranteUtilizadores(bd, "Amélia Paz", "207692670", new DateTime(1956, 08, 05), "Rua Professora Lucília Fernandes Canidelo", "930221459", "amelia.paz@RDtelecom.com", "4400-651", "Operador", false, "Porto", new DateTime(2020, 12, 05), 0, 13);

            //    //-------------------------- 14 SANTAREM-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "102923698", new DateTime(2000, 07, 01), "Casal dos Florindos", "917896325", "patricia.gomes@RDtelecom.com", "2000-320", "Operador", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);
            GaranteUtilizadores(bd, "Marlene Santos", "167804812", new DateTime(1987, 11, 21), "Casal da Igreja", "969587542", "marlene.satos@RDtelecom.com", "2000-336", "Operador", false, "Santarém", new DateTime(2020, 08, 19), 0, 14);
            GaranteUtilizadores(bd, "João Ferreira", "179394614", new DateTime(1978, 07, 01), "Dona Belida", "932102548", "joao.ferreira@RDtelecom.com", "2000-342", "Operador", false, "Santarém", new DateTime(2021, 01, 17), 0, 14);
            GaranteUtilizadores(bd, "Pedro Martins", "134904710", new DateTime(1969, 06, 06), "Avenida Bernardo Santareno", "963214520", "pedro.martins@RDtelecom.com", "2009-004", "Operador", false, "Santarém", new DateTime(2021, 01, 05), 0, 14);
            GaranteUtilizadores(bd, "Joana Lima", "194846377", new DateTime(1979, 10, 30), "Largo do Infante Santo", "925874100", "joana.lima@RDtelecom.com", "2009-002", "Operador", false, "Santarém", new DateTime(2021, 01, 05), 0, 14);
            GaranteUtilizadores(bd, "Patrícia Gomes", "130908010", new DateTime(1999, 04, 01), "Estrada Nacional 10", "925964874", "patricia.gomes@RDtelecom.com", "2139-503", "Operador", false, "Santarém", new DateTime(2020, 12, 28), 0, 14);
            GaranteUtilizadores(bd, "Irís Copeto", "137377924", new DateTime(1999, 09, 05), "Agolada", "965412088", "iris.copeto@RDtelecom.com", "2100-001", "Operador", false, "Santarém", new DateTime(2020, 11, 12), 0, 14);
            GaranteUtilizadores(bd, "Filipe Pais", "193317842", new DateTime(1987, 01, 01), "Varejola", "924863210", "filipe.pais@RDtelecom.com", "2100-377", "Operador", false, "Santarém", new DateTime(2020, 12, 12), 0, 14);
            GaranteUtilizadores(bd, "Amadeu Lourenço", "187836825", new DateTime(1965, 08, 17), "Louriceira", "920258885", "amadeu.lourenço@RDtelecom.com", "6120-116", "Operador", false, "Santarém", new DateTime(2020, 11, 05), 0, 14);
            GaranteUtilizadores(bd, "Amílcar Oliveira", "116024879", new DateTime(1974, 02, 10), "Estrada Nacional 10", "967862111", "amilcar.oliveira@RDtelecom.com", "2139-503", "Operador", false, "Santarém", new DateTime(2020, 10, 05), 0, 14);
            GaranteUtilizadores(bd, "Luísa Guerra", "194892441", new DateTime(1955, 08, 05), "Casal de Além", "922587456", "luisa.guerra@RDtelecom.com", "2025-150", "Operador", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);
            GaranteUtilizadores(bd, "Afonso Freira", "143171410", new DateTime(1957, 07, 05), "Pisão", "932008521", "afonso.freira@RDtelecom.com", "2230-009", "Operador", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);

            //    //-------------------------- 15 SETUBAL-----------------
            GaranteUtilizadores(bd, "Patrícia Varandas", "159738296", new DateTime(1986, 07, 01), "Praceta Bernardim Ribeiro", "914753951", "patricia.varandas@RDtelecom.com", "2800-002", "Operador", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            GaranteUtilizadores(bd, "Miguel Santos", "115818910", new DateTime(1988, 05, 21), "Praça Doutora Adelaide Coutinho", "960225478", "miguel.santos@RDtelecom.com", "2800-002", "Operador", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            GaranteUtilizadores(bd, "João Ferreira", "125484038", new DateTime(1978, 06, 01), "Rua Bulhão Pato", "926715826", "joao.ferreira@RDtelecom.com", "2800-003", "Operador", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            GaranteUtilizadores(bd, "Tânia Sousa", "120730464", new DateTime(1970, 06, 08), "Rua Capitão Leitão Ímpares", "965874100", "tania-sousa@RDtelecom.com", "2800-137", "Operador", false, "Setúbal", new DateTime(2020, 11, 05), 0, 15);
            GaranteUtilizadores(bd, "Rute Martins", "107984512", new DateTime(1968, 10, 30), "Pátio Albers", "926548222", "rute.martins@RDtelecom.com", "2830-320", "Operador", false, "Setúbal", new DateTime(2020, 12, 11), 0, 15);
            GaranteUtilizadores(bd, "Bernardo Pinto", "140414878", new DateTime(2000, 08, 01), "Travessa do Alto José Ferreira", "960321489", "bernardo.pinto@RDtelecom.com", "2830-381", "Operador", false, "Setúbal", new DateTime(2020, 08, 19), 0, 15); ;
            GaranteUtilizadores(bd, "Paula Neves", "174218990", new DateTime(1999, 11, 01), "Rua da Bandeira", "966999852", "paula.neves@RDtelecom.com", "2830-330", "Operador", false, "Setúbal", new DateTime(2020, 08, 20), 0, 15);
            GaranteUtilizadores(bd, "Miriam Palito", "147726387", new DateTime(2001, 01, 01), "Rua Professor Egas Moniz", "914852684", "miriam.palito@RDtelecom.com", "2830-357", "Operador", false, "Setúbal", new DateTime(2021, 02, 27), 0, 15);
            GaranteUtilizadores(bd, "Vanessa Albino", "188485481", new DateTime(1988, 09, 11), "Rua Fernando de Sousa", "923355874", "vanessa.albino@RDtelecom.com", "2844-001", "Operador", false, "Setúbal", new DateTime(2020, 12, 30), 0, 15);
            GaranteUtilizadores(bd, "Rosa Amarelo", "180639439", new DateTime(1975, 02, 11), "2890-200", "920333658", "rosa.amarelo@RDtelecom.com", "2890-200", "Operador", false, "Setúbal", new DateTime(2020, 11, 05), 0, 02);
            GaranteUtilizadores(bd, "Vanessa Rodrigues", "164580247", new DateTime(1955, 07, 28), "Estrada Nacional 5", "968321450", "vanessa.roduigues@RDtelecom.com", "2959-501", "Operador", false, "Setúbal", new DateTime(2020, 09, 10), 0, 15);
            GaranteUtilizadores(bd, "Afonso Pereira", "178949655", new DateTime(1956, 12, 30), "Monte das Parchanas", "968532000", "afonso.pereira@RDtelecom.com", "7595-002", "Operador", false, "Setúbal", new DateTime(2020, 10, 28), 0, 15);

            //    //-------------------------- 16 VIANA DO CASTELO-----------------
            GaranteUtilizadores(bd, "Pedro Gomes", "283312491", new DateTime(1995, 07, 11), "Largo da Oliveira", "918654654", "pedro.gomes@RDtelecom.com", "4900-003", "Operador", false, "Viana do Castelo", new DateTime(2020, 08, 05), 0, 16);
            GaranteUtilizadores(bd, "Marlene Pereira", "292990308", new DateTime(1988, 11, 21), "Estrada de Santo António", "965888970", "marlene.pereira@RDtelecom.com", "4900-006", "Operador", false, "Viana do Castelo", new DateTime(2020, 10, 05), 0, 16);
            GaranteUtilizadores(bd, "João Ferreira", "237628317", new DateTime(1977, 07, 01), "Largo do Pião", "963210337", "joao.ferreira@RDtelecom.com", "4900-102", "Operador", false, "Viana do Castelo", new DateTime(2020, 11, 05), 0, 16);
            GaranteUtilizadores(bd, "Tânia Sousa", "250558637", new DateTime(1969, 06, 06), "Rua Paula Ferreira", "967520147", "tania-sousa@RDtelecom.com", "4900-862", "Operador", false, "Viana do Castelo", new DateTime(2020, 09, 05), 0, 16);
            GaranteUtilizadores(bd, "Rute Martins", "266466117", new DateTime(1979, 10, 30), "Rua de São Pedro de Areosa", "923117852", "rute.martins@RDtelecom.com", "4900-902", "Operador", false, "Viana do Castelo", new DateTime(2021, 01, 05), 0, 16);
            GaranteUtilizadores(bd, "Luís Bernardo", "296425150", new DateTime(2000, 07, 16), "Travessa dos Sobreiros", "935888723", "luis.bernardo@RDtelecom.com", "4900-914", "Operador", false, "Viana do Castelo", new DateTime(2021, 02, 05), 0, 16);
            GaranteUtilizadores(bd, "Helder Vicente", "286887100", new DateTime(1999, 07, 17), "Rua de Monserrate", "966541112", "helder.vicente@RDtelecom.com", "4904 - 859", "Operador", false, "Viana do Castelo", new DateTime(2020, 11, 17), 0, 16);
            GaranteUtilizadores(bd, "António Santos", "238294749", new DateTime(2001, 05, 01), "Rua Pedro Homem de Melo", "963325559", "antonio.santos@RDtelecom.com", "4904-861", "Operador", false, "Viana do Castelo", new DateTime(2020, 09, 28), 0, 16);
            GaranteUtilizadores(bd, "Célia Pimento", "241415659", new DateTime(1980, 09, 11), "Rua Santiago da Barra", "923698777", "celia.pimento@RDtelecom.com", "4904-882", "Operador", false, "Viana do Castelo", new DateTime(2020, 08, 30), 0, 16);
            GaranteUtilizadores(bd, "Paulo Feliz", "291340725", new DateTime(1975, 02, 08), "Estrada de Santa Luzia", "912152033", "paulo.feliz@RDtelecom.com", "4904-858", "Operador", false, "Viana do Castelo", new DateTime(2020, 10, 14), 0, 16);
            GaranteUtilizadores(bd, "Joaquim Guerra", "292585438", new DateTime(1959, 08, 24), "Avenida Capitão Gaspar de Castro", "965321111", "joaquim.guerra@RDtelecom.com", "4904-873", "Operador", false, "Viana do Castelo", new DateTime(2020, 12, 17), 0, 16);
            GaranteUtilizadores(bd, "Afonso Freira", "280477228", new DateTime(1956, 07, 26), "Monterrão", "932654780", "afonso.freira@RDtelecom.com", "4940-003", "Operador", false, "Viana do Castelo", new DateTime(2020, 10, 13), 0, 16);

            //    //-------------------------- 17 VILA REAL-----------------
            GaranteUtilizadores(bd, "Patrícia Avillar", "226746380", new DateTime(2001, 09, 01), "Passagem", "966987785", "patricia.avillar@RDtelecom.com", "5000-004", "Operador", false, "Vila Real", new DateTime(2020, 08, 05), 0, 17);
            GaranteUtilizadores(bd, "Marlene Pacheco", "278338682", new DateTime(1988, 12, 21), "Cabana", "932654120", "marlene.pacheco@RDtelecom.com", "5000-008", "Operador", false, "Vila Real", new DateTime(2020, 10, 05), 0, 17);
            GaranteUtilizadores(bd, "Filipe Ferreira", "242584799", new DateTime(1975, 08, 01), " Camatoga", "925669850", "filipe.ferreira@RDtelecom.com", "5040-001", "Operador", false, "Vila Real", new DateTime(2020, 08, 27), 0, 17);
            GaranteUtilizadores(bd, "Bruna Sousa", "203240995", new DateTime(1969, 04, 06), "Porto Rei", "920357892", "bruna.sousa@RDtelecom.com", "5040-117", "Operador", false, "Vila Real", new DateTime(2020, 08, 28), 0, 17);
            GaranteUtilizadores(bd, "António Martins", "215600061", new DateTime(1985, 10, 30), "Covinhas", "968321025", "antonio.martins@RDtelecom.com", "5050-103", "Operador", false, "Vila Real", new DateTime(2020, 10, 05), 0, 17);
            GaranteUtilizadores(bd, "Inês Silva", "206368330", new DateTime(1973, 07, 01), "Salgueiral", "925841003", "ines.silva@RDtelecom.com", "5050-007", "Operador", false, "Vila Real", new DateTime(2020, 11, 05), 0, 17);
            GaranteUtilizadores(bd, "Pedro Andrade", "261055097", new DateTime(2001, 07, 11), "Rua da Barreira", "925632145", "pedro.andrade@RDtelecom.com", "5070-003", "Operador", false, "Vila Real", new DateTime(2021, 01, 05), 0, 17);
            GaranteUtilizadores(bd, "Vanessa Monteiro", "222266902", new DateTime(1976, 01, 01), "Rua da Ponte Nova", "963221058", "vanessa.monteiro@RDtelecom.com", "5070-003", "Operador", false, "Vila Real", new DateTime(2020, 12, 05), 0, 17);
            GaranteUtilizadores(bd, "Manuela Fonseca", "243715790", new DateTime(1995, 09, 11), "Rua Amadeu Necho", "925621489", "manuela.fonseca@RDtelecom.com", "5070-008", "Operador", false, "Vila Real", new DateTime(2020, 08, 19), 0, 17);
            GaranteUtilizadores(bd, "Kelvin Antunes", "233428267", new DateTime(1987, 02, 11), "Estrada Municipal", "962087536", "kelvin.antunes@RDtelecom.com", "5070-173", "Operador", false, "Vila Real", new DateTime(2020, 08, 27), 0, 17);
            GaranteUtilizadores(bd, "Rita Godinho", "268256683", new DateTime(1966, 10, 24), "Porto Rei", "923698520", "rita.godinho@RDtelecom.com", "5040-117", "Operador", false, "Vila Real", new DateTime(2020, 08, 01), 0, 17);
            GaranteUtilizadores(bd, "Bernardo Marques", "277466563", new DateTime(1958, 09, 05), "Povoação", "938219227", "bernardo.marques@RDtelecom.com", "5040-295", "Operador", false, "Vila Real", new DateTime(2020, 11, 05), 0, 17);

            //    //-------------------------- 18 VISEU-----------------
            GaranteUtilizadores(bd, "Paula Gomes", "183894359", new DateTime(2000, 06, 11), "Beco do Areal", "965412200", "paula.gomes@RDtelecom.com", "3430-505", "Operador", false, "Viseu", new DateTime(2021, 02, 05), 0, 18);
            GaranteUtilizadores(bd, "Marlene Santinho", "103467882", new DateTime(1988, 07, 09), "Avenida Madre Rita Amada de Jesus", "928321485", "marlene.santinho@RDtelecom.com", "3500-179", "Operador", false, "Viseu", new DateTime(2021, 01, 05), 0, 18);
            GaranteUtilizadores(bd, "João Monteiro", "155241869", new DateTime(1986, 03, 01), "Rua Nova Jugueiros", "965874448", "joao.monteiro@RDtelecom.com", "3500-003", "Operador", false, "Viseu", new DateTime(2020, 08, 05), 0, 18);
            GaranteUtilizadores(bd, "Tânia Laranjo", "143563157", new DateTime(1969, 09, 06), "Rua Imaculado Coração de Maria", "932335920", "tania.laranjo@RDtelecom.com", "3500-236", "Operador", false, "Viseu", new DateTime(2020, 10, 05), 0, 18);
            GaranteUtilizadores(bd, "Anabela Moreria", "172309840", new DateTime(1964, 10, 23), "Rua 31 de Janeiro", "935852005", "anabela.moreira@RDtelecom.com", "3500-217", "Operador", false, "Viseu", new DateTime(2020, 12, 05), 0, 18);
            GaranteUtilizadores(bd, "Bruno Fernandes", "182643603", new DateTime(1999, 07, 24), "Rua Viscondessa de São Caetano", "910223658", "bruno.fernandes@RDtelecom.com", "3500-185", "Operador", false, "Viseu", new DateTime(2021, 02, 12), 0, 18);
            GaranteUtilizadores(bd, "Bruno Nogueira", "165569204", new DateTime(1999, 06, 21), "Rua do Hospital", "923620018", "bruno.nogueira@RDtelecom.com", "3500-161", "Operador", false, "Viseu", new DateTime(2021, 01, 17), 0, 18);
            GaranteUtilizadores(bd, "Ana Gomes", "176401890", new DateTime(2000, 01, 28), "Estrada Nacional 16", "968412339", "ana.gomes@RDtelecom.com", "3519-002", "Operador", false, "Viseu", new DateTime(2020, 11, 28), 0, 18);
            GaranteUtilizadores(bd, "Rita Rocha", "194866360", new DateTime(1984, 09, 11), "Cadraço", "925896552", "rita.rocha@RDtelecom.com", "3475-003", "Operador", false, "Viseu", new DateTime(2020, 10, 25), 0, 18);
            GaranteUtilizadores(bd, "Joana Dias", "173792294", new DateTime(1987, 02, 08), "Pedrogão", "921332068", "joana.dias@RDtelecom.com", "3475-004", "Operador", false, "Viseu", new DateTime(2020, 12, 17), 0, 18);
            GaranteUtilizadores(bd, "Maria Bastos", "103649492", new DateTime(1960, 07, 24), "Abóboda", "915735255", "maria.bastos@RDtelecom.com", "3475-007", "Operador", false, "Viseu", new DateTime(2020, 11, 09), 0, 18);
            GaranteUtilizadores(bd, "Luís Neto", "156449307", new DateTime(1979, 10, 05), "Rua Doutor Sebastião Alcantara", "937190258", "luis.neto@RDtelecom.com", "3534-002", "Operador", false, "Viseu", new DateTime(2021, 03, 14), 0, 18);

            //    //-------------------------- 19 AÇORES-----------------
            GaranteUtilizadores(bd, "Paula Mendes", "120771314", new DateTime(2000, 06, 01), "À Fonseca ", "930005874", "paula.mendes@RDtelecom.com", "9700-302", "Operador", false, "Açores", new DateTime(2020, 07, 01), 0, 19);
            GaranteUtilizadores(bd, "Joana Santos", "137971443", new DateTime(1989, 11, 11), "Outeiro de São Mateus", "965320005", "joana.santos@RDtelecom.com", "9700-305", "Operador", false, "Açores", new DateTime(2021, 01, 01), 0, 19);
            GaranteUtilizadores(bd, "Pedro Ferreira", "152267387", new DateTime(1974, 07, 01), "Presas", "961742008", "pedro.ferreira@RDtelecom.com", "9700-308", "Operador", false, "Açores", new DateTime(2020, 09, 01), 0, 19);
            GaranteUtilizadores(bd, "Fernanda Sousa", "142615889", new DateTime(1969, 08, 06), "Rua Nova", "961325698", "Fernanda.sousa@RDtelecom.com", "9700-132", "Operador", false, "Açores", new DateTime(2020, 12, 10), 0, 19);
            GaranteUtilizadores(bd, "Rita Martins", "144505665", new DateTime(1979, 11, 30), "Praça Doutor Sousa Júnior ", "930014789", "rita.martins@RDtelecom.com", "9700-007", "Operador", false, "Açores", new DateTime(2020, 10, 11), 0, 19);
            GaranteUtilizadores(bd, "João Patrício", "167301900", new DateTime(2001, 07, 01), "Abaixo do Fragoso", "965874123", "joao.patricio@RDtelecom.com", "9880-101", "Operador", false, "Açores", new DateTime(2020, 12, 28), 0, 19);
            GaranteUtilizadores(bd, "Helder Machado", "174189800", new DateTime(1999, 07, 01), "Bairro do Carrapacho", "915233281", "Helder.machado@RDtelecom.com", "9880-120", "Operador", false, "Açores", new DateTime(2020, 11, 01), 0, 19);
            GaranteUtilizadores(bd, "Luís Falcão", "139100873", new DateTime(2000, 11, 01), "Bacelo", "925879411", "miriam.falcao@RDtelecom.com", "9880-103", "Operador", false, "Açores", new DateTime(2020, 07, 16), 0, 19);
            GaranteUtilizadores(bd, "Vanessa Ribeiro", "174957050", new DateTime(1980, 09, 11), "Avenida Mousinho de Albuquerque", "926557201", "vanessa.ribeiro@RDtelecom.com", "9880-999", "Operador", false, "Açores", new DateTime(2020, 09, 21), 0, 19);
            GaranteUtilizadores(bd, "Rafael Leão", "119348470", new DateTime(1975, 02, 24), "Pedras Brancas", "961741211", "rafael.leao@RDtelecom.com", "9880-171", "Operador", false, "Açores", new DateTime(2020, 09, 05), 0, 19);
            GaranteUtilizadores(bd, "Célia Francisca", "117424919", new DateTime(1955, 08, 24), "Fajã da Isabel Pereira", "911577821", "celia.francisca@RDtelecom.com", "9800-101", "Operador", false, "Açores", new DateTime(2020, 10, 01), 0, 19);
            GaranteUtilizadores(bd, "Rita Freira", "107167727", new DateTime(1956, 06, 05), "Ribeira D'Água", "937888541", "rita.freira@RDtelecom.com", "9800-209", "Operador", false, "Açores", new DateTime(2021, 02, 05), 0, 19);

            //    //-------------------------- 20 MADEIRA-----------------
            GaranteUtilizadores(bd, "Patrícia Passarinha", "113150814", new DateTime(2001, 07, 01), "Caminho Ribeira dos Socorridos ", "965321002", "patricia.passarinha@RDtelecom.com", "9000-617", "Operador", false, "Madeira", new DateTime(2020, 07, 01), 0, 20);
            GaranteUtilizadores(bd, "Marlene Lavrador", "184785715", new DateTime(1968, 11, 21), "2ª Travessa Caminho Arieiro de Baixo", "938520366", "marlene.Lavrador@RDtelecom.com", "9000-602", "Operador", false, "Madeira", new DateTime(2020, 08, 01), 0, 20);
            GaranteUtilizadores(bd, "Petra Fernandes", "170288900", new DateTime(1988, 09, 01), "Azinhaga Vargem", "968741250", "petra.fernandes@RDtelecom.com", "9000-730", "Operador", false, "Madeira", new DateTime(2021, 01, 01), 0, 20);
            GaranteUtilizadores(bd, "Vânia Fernandes", "129628522", new DateTime(1969, 07, 06), "Avenida Colégio Militar ", "912335620", "Vania.fernandes@RDtelecom.com", "9000-996", "Operador", false, "Madeira", new DateTime(2021, 02, 01), 0, 20);
            GaranteUtilizadores(bd, "Pedro Alves", "137275862", new DateTime(1979, 10, 27), "Beco Virtudes", "927415620", "pedro.alves@RDtelecom.com", "9000-616", "Operador", false, "Madeira", new DateTime(2020, 09, 21), 0, 20);
            GaranteUtilizadores(bd, "Patrícia Gomes", "100247520", new DateTime(1999, 09, 24), "Caminho Arieiro", "965327882", "patricia.gomes@RDtelecom.com", "9000-243 ", "Operador", false, "Madeira", new DateTime(2020, 10, 28), 0, 20);
            GaranteUtilizadores(bd, "Tiago Prata", "127523502", new DateTime(1999, 07, 18), "Rua Hospital Velho", "924710655", "tiago.prata@RDtelecom.com", "9064-507", "Operador", false, "Madeira", new DateTime(2020, 11, 28), 0, 20);
            GaranteUtilizadores(bd, "Paula Falcão", "172885205", new DateTime(2000, 01, 26), "Rua Nova Rochinha", "924521333", "paula.falcao@RDtelecom.com", "9064-509", "Operador", false, "Madeira", new DateTime(2020, 12, 17), 0, 20);
            GaranteUtilizadores(bd, "Inês Santos", "170898610", new DateTime(1980, 09, 30), "Travessa Contracta e Corujeira", "965824110", "ines.santos@RDtelecom.com", "9125-003", "Operador", false, "Madeira", new DateTime(2020, 09, 10), 0, 20);
            GaranteUtilizadores(bd, "Fábio Martins", "169789560", new DateTime(1975, 02, 10), "Estrada do Garajau Vargem", "932226987", "fabio.martins@RDtelecom.com", "9125-253", "Operador", false, "Madeira", new DateTime(2021, 02, 10), 0, 20);
            GaranteUtilizadores(bd, "Jaime Antunes", "139861750", new DateTime(1955, 02, 24), "Rua Abegoaria", "915738522", "jaime.antunes@RDtelecom.com", "9125-122", "Operador", false, "Madeira", new DateTime(2020, 12, 08), 0, 20);
            GaranteUtilizadores(bd, "Joaquim Alves", "158218310", new DateTime(1956, 01, 05), "Cruz", "932165420", "joaquim.alves@RDtelecom.com", "9225-007", "Operador", false, "Madeira", new DateTime(2020, 12, 12), 0, 20);

        }

        private static Utilizadores GaranteUtilizadores(Projeto_Lab_WebContext bd, string nome, string nif, DateTime datanascimento,
            string morada, string telemovel, string email, string codigopostal, string role, bool inactivo, string concelho, DateTime dataativacao, int pontos, int distrito)
        {
            Utilizadores utilizadores = bd.Utilizadores.FirstOrDefault(c => c.Nome == nome);
            if (utilizadores == null)
            {
                utilizadores = new Utilizadores { Nome = nome, Nif = nif, DataNascimento = datanascimento, Morada = morada, Concelho = concelho, Telemovel = telemovel, Email = email, CodigoPostal = codigopostal, Role = role, Inactivo = inactivo, DataAtivacao = dataativacao, Pontos = pontos, DistritosId = distrito };
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
            GaranteDistritos(bd, "Aveiro");
            GaranteDistritos(bd, "Beja");
            GaranteDistritos(bd, "Braga");
            GaranteDistritos(bd, "Bragança");
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

        private static Distritos GaranteDistritos(Projeto_Lab_WebContext bd, string nome)
        {
            Distritos distritos = bd.Distritos.FirstOrDefault(e => e.Nome == nome);
            if (distritos == null)
            {
                distritos = new Distritos() { Nome = nome };
                bd.Distritos.Add(distritos);
                bd.SaveChanges();
            }
            return distritos;

        }

        private static void InserePromocoes(Projeto_Lab_WebContext bd)
        {
            GaranteExistenciaPromocoes(bd, "PascoaS", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes pequenos", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 2, 99m, false);
            GaranteExistenciaPromocoes(bd, "PascoaM", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes médios", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 3, 99m, false);
            GaranteExistenciaPromocoes(bd, "PascoaL", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes grandes", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 4, 99m, false);
            GaranteExistenciaPromocoes(bd, "VerãoS", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes pequenos", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 1, 99m, false);
            GaranteExistenciaPromocoes(bd, "VerãoM", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes médio", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 2, 59m, false);
            GaranteExistenciaPromocoes(bd, "VerãoL", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes grandes", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 3, 99m, false);
            GaranteExistenciaPromocoes(bd, "NatalS", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes pequenos", new DateTime(2020, 12, 01), new DateTime(2021, 01, 31), 3, 99m, false);
            GaranteExistenciaPromocoes(bd, "NatalM", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes médios", new DateTime(2020, 12, 01), new DateTime(2021, 01, 31), 4, 99m, false);
            GaranteExistenciaPromocoes(bd, "NatalL", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes grandes", new DateTime(2020, 12, 01), new DateTime(2021, 01, 31), 5, 99m, false);

        }

        private static Promocoes GaranteExistenciaPromocoes(Projeto_Lab_WebContext bd, string nome, string descricao, DateTime dataInicio, DateTime datafim, int promocaoDesc, decimal v, bool inactivo)
        {
            Promocoes promocoes = bd.Promocoes.FirstOrDefault(c => c.Nome == nome);
            if (promocoes == null)
            {
                promocoes = new Promocoes { Nome = nome, Descricao = descricao, DataInicio = dataInicio, DataFim = datafim, PromocaoDesc = promocaoDesc, Inactivo = inactivo };
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

        //---------------------------------PromocoesPacotes------------------------------
        private static void InserePromocoesPacotes(Projeto_Lab_WebContext bd)
        {

            var pacoteRD4 = GarantePacotes(bd, "Pacote RD4", 55, "O pacote RD4 destacou-se por apresentar a melhor relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade", false, new DateTime(2021, 03, 01));
            var pacoteRD3 = GarantePacotes(bd, "Pacote RD3", 45, "O pacote RD3 destacou-se por apresentar a uma ótima relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade para quem não quer ter um telemóvel associado ao pacote.", false, new DateTime(2021, 03, 01));
            var pacoteRDGaming = GarantePacotes(bd, "Pacote RD - Gaming", 55, "A oferta Pacote RD - Gaming é ideal para", false, new DateTime(2021, 03, 01));
            var pacoteRDGPremium = GarantePacotes(bd, "Pacote RD - TV Premium + gaming", 65, "A oferta Pacote RD - TV Premium + gaming destacou - se na categoria de “Melhor pacote para Gaming” por apresentar a melhor relação ao nível do número de canais dedicado ao universo cinematográfico(canais base, exclusivos e premium) face ao custo mensal, bem como uma internet de alta velocidade para não haver falhas durante os jogos.", false, new DateTime(2021, 03, 01));
            var pacoteTvVoz = GarantePacotes(bd, "RD TV e Voz", 25, "Este Pacote RD TV e Voz é ideal para os clientes que querem ver televisão", false, new DateTime(2021, 03, 01));
            var pacoteRDFamiliar = GarantePacotes(bd, "RD Familiar", 45, "Pacote ideal para os momentos de lazer em família.", false, new DateTime(2021, 03, 01));

            var pascoaS = GaranteExistenciaPromocoes(bd, "PascoaS", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes pequenos", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 2, 99m, false);
            var pascoaM = GaranteExistenciaPromocoes(bd, "PascoaM", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes médios", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 3, 99m, false);
            var pascoaL = GaranteExistenciaPromocoes(bd, "PascoaL", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes grandes", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 4, 99m, false);
            var VeraoS = GaranteExistenciaPromocoes(bd, "VerãoS", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes pequenos", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 1, 99m, false);
            var VeraoM = GaranteExistenciaPromocoes(bd, "VerãoM", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes médio", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 2, 59m, false);
            var VeraoL = GaranteExistenciaPromocoes(bd, "VerãoL", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes grandes", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 3, 99m, false);
            var NatalS = GaranteExistenciaPromocoes(bd, "NatalS", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes pequenos", new DateTime(2021, 12, 01), new DateTime(2022, 01, 31), 3, 99m, false);
            var NatalM = GaranteExistenciaPromocoes(bd, "NatalM", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes médios", new DateTime(2021, 12, 01), new DateTime(2022, 01, 31), 4, 99m, false);
            var NatalL = GaranteExistenciaPromocoes(bd, "NatalL", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes grandes", new DateTime(2021, 12, 01), new DateTime(2022, 01, 31), 5, 99m, false);


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


       
        private static void InsereReclamacoes(Projeto_Lab_WebContext bd)
        {

            if (bd.Reclamacoes.Any()) return;

            var aveirocliente1 = GaranteUtilizadores(bd, "Eduardo Pires", "237051974", new DateTime(2000, 01, 19), "Sargento Mor", "921233367", "eduardo.pires@RD-Telecom.com", "3020-740", "Cliente", false, "Aveiro", new DateTime(2020, 08, 05), 0, 1);
            var aveirooperador2 = GaranteUtilizadores(bd, "Glória Aveiro", "218120460", new DateTime(1988, 09, 21), "Rua Fernando Caldeira", "937654321", "gloria.ascencao@RDtelecom.com", "3754-501", "Operador", false, "Aveiro", new DateTime(2020, 12, 12), 0, 1);

            var bejacliente4 = GaranteUtilizadores(bd, "Vasco Barreiros", "296928135", new DateTime(1962, 02, 25), "Avenida Manuel Álvaro Lopes Pereira", "927477781", "bernado.ribeiro@RD-Telecom.com", "3800-625", "Cliente", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            var bejaoperador5 = GaranteUtilizadores(bd, "Mário RD Beja", "292565798", new DateTime(1987, 07, 16), "Albergaria dos Fusos", "923148620", "amadeu.almeida@RDtelecom.com", "7940-411", "Operador", false, "Beja", new DateTime(2020, 08, 26), 0, 2);

            var bragacliente7 = GaranteUtilizadores(bd, "Marizete Gillot", "351103988", new DateTime(1956, 10, 04), "Rua dos Caixoteiros", "922008889", "marizete.gillot@RD-Telecom.com", "4705-001", "Cliente", false, "Braga", new DateTime(2020, 10, 07), 0, 3);
            var bragaoperador6 = GaranteUtilizadores(bd, "Ryan RD Braga", "240442571", new DateTime(1988, 03, 05), "Rua das Oliveiras", "920322333", "ryan.oliveira@RDtelecom.com", "4705-790", "Operador", false, "Braga", new DateTime(2020, 11, 28), 0, 3);

            var bragancacliente11 = GaranteUtilizadores(bd, "Feitosa Pauleta", "235592650", new DateTime(1972, 10, 27), "Rotunda do Lavrador Bairro da Braguinha ", "921038825", "feitosa.pauleta@RD-Telecom.com", "5300-420", "Cliente", false, "Bragança", new DateTime(2021, 02, 21), 0, 4);
            var bragancaoperador1 = GaranteUtilizadores(bd, "Natally RD Bragança", "239833252", new DateTime(1974, 06, 19), "Bairro Moinho de Vento", "939007258", "natally.domingues@RDtelecom.com", "5140-005", "Operador", false, "Bragança", new DateTime(2020, 11, 13), 0, 4);

            var castelobrancocliente7 = GaranteUtilizadores(bd, "Maria Pedroso", "179189093", new DateTime(2000, 10, 04), "Travessa das Trapas", "924688158", "maria.pedroso@RD-Telecom.com", "6200-237", "Cliente", false, "Castelo Branco", new DateTime(2020, 11, 17), 0, 5);
            var castelobrancoperador7 = GaranteUtilizadores(bd, "António RD Castelo Branco", "111712580", new DateTime(1974, 05, 31), "Rua Marquês de Ávila e Bolama", "928328961", "antonio.antunes@RDtelecom.com", "6201-001", "Operador", false, "Castelo Branco", new DateTime(2020, 12, 22), 0, 5);

            var coimbracliente7 = GaranteUtilizadores(bd, "Helder Copeto", "145533590", new DateTime(1999, 07, 01), "Rua do Norte", "929122221", "helder.copeto@RD-Telecom.com", "3000-295", "Cliente", false, "Coimbra", new DateTime(2020, 10, 11), 0, 6);
            var coimbraoperador10 = GaranteUtilizadores(bd, "Tadeu Coimbra RD", "294178775", new DateTime(1975, 02, 08), "Flor da Rosa", "929100021", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, "Coimbra", new DateTime(2021, 03, 11), 0, 6);

            var evoracliente12 = GaranteUtilizadores(bd, "Sara Moedas", "254578870", new DateTime(1956, 05, 05), "Largo dos Colegiais 2", "933299871", "sara.moedas@RD-Telecom.com", "7004-516", "Cliente", false, "Évora", new DateTime(2021, 02, 26), 0, 7);
            var evoraoperador3 = GaranteUtilizadores(bd, "Ricardo RD Évora", "205118615", new DateTime(1975, 07, 01), "Rua da Liberdade", "920147963", "ricardo.gama@RDtelecom.com", "7220-002", "Operador", false, "Évora", new DateTime(2020, 09, 26), 0, 7);

            var farocliente1 = GaranteUtilizadores(bd, "Miguel Rossi", "253871166", new DateTime(1999, 07, 01), "Rua da Viola ", "925874990", "miguel.rossi@RD-Telecom.com", "8000-274", "Cliente", false, "Faro", new DateTime(2020, 12, 28), 0, 8);
            var farooperador10 = GaranteUtilizadores(bd, "Miguel RD Faro", "299944611", new DateTime(1975, 02, 08), "Avenida dos Descobrimentos", "921321111", "miguel.feliz@RDtelecom.com", "8601-852", "Operador", false, "Faro", new DateTime(2021, 02, 17), 0, 8);

            var guardacliente9 = GaranteUtilizadores(bd, "Ricardo Estrela", "138133743", new DateTime(1987, 09, 17), "Parada", "963991456", "ricardo.estrla@RD-Telecom.com", "6355-142", "Cliente", false, "Guarda", new DateTime(2021, 02, 28), 0, 9);
            var guardaoperador12 = GaranteUtilizadores(bd, "Isamara RD Guarda", "215494725", new DateTime(1956, 12, 05), "Lajeosa", "936058777", "isamara.lobao@RDtelecom.com", "6320-161", "Operador", false, "Guarda", new DateTime(2021, 01, 28), 0, 9);

            bd.Reclamacoes.AddRange(new Reclamacoes[] {
            new Reclamacoes
            {
                Descricao = "Falha no telefone",
                DataReclamacao =new DateTime(2021,02,03),
                Resposta = "Falha resolvida",
                EstadoResposta = true,
                DataResolucao = new DateTime(2021,02,06),
                EstadoResolução = true,
                ClienteId=aveirocliente1.UtilizadorId,
                FuncionarioId=aveirooperador2.UtilizadorId,
                Inactivo = true,

            },
             new Reclamacoes
            {
                Descricao = "Falha na internet",
                DataReclamacao =new DateTime(2021,02,03),
                Resposta = "Falha resolvida",
                EstadoResposta = true,
                DataResolucao = new DateTime(2021,02,03),
                EstadoResolução = true,
                ClienteId=bejacliente4.UtilizadorId,
                FuncionarioId=bejaoperador5.UtilizadorId,
                 Inactivo = false,

            },
              new Reclamacoes
            {
                Descricao = "Instalação de pacote errado",
                DataReclamacao =new DateTime(2021,01,03),
                Resposta = "REtificação do pacote instalado",
                EstadoResposta = true,
                DataResolucao = new DateTime(2021,01,05),
                EstadoResolução = true,
                ClienteId=bragacliente7.UtilizadorId,
                FuncionarioId=bragaoperador6.UtilizadorId,
                 Inactivo = false,

            },
               new Reclamacoes
            {
                Descricao = "Pacote de canais não corresponde ao soliticado",
                DataReclamacao =new DateTime(2020,10,25),
                Resposta = "Problema resolvido",
                EstadoResposta = true,
                DataResolucao = new DateTime(2020,10,25),
                EstadoResolução = true,
                ClienteId=bragancacliente11.UtilizadorId,
                FuncionarioId=bragancaoperador1.UtilizadorId,
                 Inactivo = false,

            },
                new Reclamacoes
            {
                Descricao = "Falha no serviço RD3",
                DataReclamacao =new DateTime(2021,02,03),
                Resposta = "Falha resolvida",
                EstadoResposta = true,
                DataResolucao = new DateTime(2021,02,03),
                EstadoResolução = true,
                ClienteId=castelobrancocliente7.UtilizadorId,
                FuncionarioId=castelobrancoperador7.UtilizadorId,
                 Inactivo = false,

            },
                 new Reclamacoes
            {
                Descricao = "Mudança de titularidade",
                DataReclamacao =new DateTime(2021,01,07),
                Resposta = "Mudança resolvida",
                EstadoResposta = true,
                DataResolucao = new DateTime(2021,01,17),
                EstadoResolução = true,
                ClienteId=coimbracliente7.UtilizadorId,
                FuncionarioId=coimbraoperador10.UtilizadorId,
                 Inactivo = false,

            },
                  new Reclamacoes
            {
                Descricao = "Telefone fixo sem funcionar",
                DataReclamacao =new DateTime(2020,11,25),
                Resposta = "Telefone a funcionar corretamente",
                EstadoResposta = true,
                DataResolucao = new DateTime(2020,11,30),
                EstadoResolução = true,
                ClienteId=evoracliente12.UtilizadorId,
                FuncionarioId=evoraoperador3.UtilizadorId,
                 Inactivo = false,

            },
                   new Reclamacoes
            {
                Descricao = "Má prestação de serviço",
                DataReclamacao =new DateTime(2021,02,03),
                Resposta = "Problema resolvido",
                EstadoResposta = true,
                DataResolucao = new DateTime(2021,02,08),
                EstadoResolução = true,
                ClienteId=farocliente1.UtilizadorId,
                FuncionarioId=farooperador10.UtilizadorId,
                 Inactivo = false,

            },
                    new Reclamacoes
            {
                Descricao = "Falha na Internet",
                DataReclamacao =new DateTime(2021,02,01),
                Resposta = "Falha resolvida",
                EstadoResposta = true,
                DataResolucao = new DateTime(2021,02,02),
                EstadoResolução = true,
                ClienteId=aveirocliente1.UtilizadorId,
                FuncionarioId=aveirooperador2.UtilizadorId,
                 Inactivo = false,

            },
                     new Reclamacoes
            {
                Descricao = "Fatura incorreta",
                DataReclamacao =new DateTime(2021,02,03),
                Resposta = "Erro retificado",
                EstadoResposta = true,
                DataResolucao = new DateTime(2021,02,06),
                EstadoResolução = true,
                ClienteId=guardacliente9.UtilizadorId,
                FuncionarioId=guardaoperador12.UtilizadorId,
                 Inactivo = false,

            },


        });
            bd.SaveChanges();
        }

        //---------------------ADMINISTRADORES-----------------------

        internal static async Task InsereRolesAsync(RoleManager<IdentityRole> gestorRoles)
        {
            await CriaRoleSeNecessario(gestorRoles, ROLE_ADIMINISTRADOR);
            await CriaRoleSeNecessario(gestorRoles, ROLE_CLIENTE);
            await CriaRoleSeNecessario(gestorRoles, ROLE_OPERADOR);
        }

        private static async Task CriaRoleSeNecessario(RoleManager<IdentityRole> gestorRoles, string funcao)
        {
            if (!await gestorRoles.RoleExistsAsync(funcao))
            {
                IdentityRole role = new IdentityRole(funcao);
                await gestorRoles.CreateAsync(role);
            }
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

