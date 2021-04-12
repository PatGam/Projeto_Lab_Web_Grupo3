using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Lab_Web_Grupo3.Models;

namespace Projeto_Lab_Web_Grupo3.Data
{
    public class SeedDataContratos
    {
        internal static void InsereDadosContratos(Projeto_Lab_WebContext bd)
        {
            InsereContratos(bd);
            InsereServicosContratos(bd);
            InsereDistritosPacotes(bd);
            InsereDistritosPromocoes(bd);

        }
        internal static void InsereContratos(Projeto_Lab_WebContext bd)
        {
            if (bd.Contratos.Any()) return;

            var pascoaS = GaranteExistenciaPromocoes(bd, "PascoaS", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes pequenos", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 2, 99m, false);
            var pascoaM = GaranteExistenciaPromocoes(bd, "PascoaM", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes médios", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 3, 99m, false);
            var pascoaL = GaranteExistenciaPromocoes(bd, "PascoaL", "Desconto aplicável durante a época da Páscoa para novas adesões, para pacotes grandes", new DateTime(2021, 03, 01), new DateTime(2021, 04, 30), 4, 99m, false);
            var veraoS = GaranteExistenciaPromocoes(bd, "VerãoS", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes pequenos", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 1, 99m, false);
            var veraoM = GaranteExistenciaPromocoes(bd, "VerãoM", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes médio", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 2, 59m, false);
            var veraoL = GaranteExistenciaPromocoes(bd, "VerãoL", "Desconto aplicável durante a época de Verão para novas adesões, para pacotes grandes", new DateTime(2021, 07, 01), new DateTime(2021, 08, 31), 3, 99m, false);
            var natalS = GaranteExistenciaPromocoes(bd, "NatalS", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes pequenos", new DateTime(2020, 12, 01), new DateTime(2021, 01, 31), 3, 99m, false);
            var natalM = GaranteExistenciaPromocoes(bd, "NatalM", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes médios", new DateTime(2020, 12, 01), new DateTime(2021, 01, 31), 4, 99m, false);
            var natalL = GaranteExistenciaPromocoes(bd, "NatalL", "Desconto aplicável durante a época de Natal para novas adesões, para pacotes grandes", new DateTime(2020, 12, 01), new DateTime(2021, 01, 31), 5, 99m, false);

            //-----------------------CLIENTES-------------------------------------------

            //Clientes de Aveiro
            var aveirocliente1 = GaranteUtilizadores(bd, "Eduardo Pires", "237051974", new DateTime(2000, 01, 19), "Sargento Mor", "921233367", "eduardo.pires@RD-Telecom.com", "3020-740", "Cliente", false, "Aveiro", new DateTime(2020, 08, 05), 0, 1);
            var aveirocliente2 = GaranteUtilizadores(bd, "Glória da Ascenção", "220613710", new DateTime(1988, 09, 21), "Rua Fernando Caldeira", "937654441", "gloria.ascencao@RD-Telecom.com", "3754-501", "Cliente", false, "Aveiro", new DateTime(2020, 12, 12), 0, 1);
            var aveirocliente3 = GaranteUtilizadores(bd, "Maria Aparecida", "287253333", new DateTime(1977, 10, 01), "Rua Doutor Tomás Aquino", "927411189", "maria.aparecida@RD-Telecom.com", "3800-523", "Cliente", false, "Aveiro", new DateTime(2020, 10, 15), 0, 1);
            var aveirocliente4 = GaranteUtilizadores(bd, "Bernardo Ribeiro", "291231438", new DateTime(1969, 03, 25), "Avenida Manuel Álvaro Lopes Pereira", "929662587", "bernado.ribeiro@RD-Telecom.com", "3800-625", "Cliente", false, "Aveiro", new DateTime(2020, 10, 17), 0, 1);
            var aveirocliente5 = GaranteUtilizadores(bd, "Amadeu Almeida", "249861585", new DateTime(1979, 07, 16), "Avenida do Doutor Lourenço Peixinho", "921212245", "amadeu.almeida@RD-Telecom.com", "3804-501", "Cliente", false, "Aveiro", new DateTime(2020, 12, 28), 0, 1);
            var aveirocliente6 = GaranteUtilizadores(bd, "José Socrates", "269768807", new DateTime(1958, 05, 05), "Viela da Capela", "920128801", "jose.socrates@RD-Telecom.com", "3810-002", "Cliente", false, "Aveiro", new DateTime(2020, 08, 17), 0, 1);
            var aveirocliente7 = GaranteUtilizadores(bd, "Ana Brito", "243552530", new DateTime(2000, 09, 04), "Rua do Jardim", "929630030", "ana.brito@RD-Telecom.com", "3054-001", "Cliente", false, "Aveiro", new DateTime(2020, 08, 19), 0, 1);
            var aveirocliente8 = GaranteUtilizadores(bd, "Luís Neto", "205291546", new DateTime(1985, 04, 04), "Avenida Comendador Augusto Martins Pereira", "920256647", "luis.neto@RD-Telecom.com", "3744-002", "Cliente", false, "Aveiro", new DateTime(2020, 08, 28), 0, 1);
            var aveirocliente9 = GaranteUtilizadores(bd, "Freitas do Mondego", "286228831", new DateTime(1975, 02, 08), "Rua do Murtório Rochico ", "961557784", "freitas.mondego@RD-Telecom.com", "3865-299", "Cliente", false, "Aveiro", new DateTime(2020, 10, 02), 0, 1);
            var aveirocliente10 = GaranteUtilizadores(bd, "João Cardoso", "266992528", new DateTime(1958, 12, 27), "Travessa da Lomba", "923298822", "joao.cardoso@RD-Telecom.com", "3865-003", "Cliente", false, "Aveiro", new DateTime(2021, 01, 05), 0, 1); ;
            var aveirocliente11 = GaranteUtilizadores(bd, "Rita de Brandão", "204161746", new DateTime(1956, 08, 27), "Largo 5 de Outubro Jardim dos Campos Pares", "929985574", "rita.brandao1@RD-Telecom.com", "3880-006", "Cliente", false, "Aveiro", new DateTime(2021, 02, 05), 0, 1);
            var aveirocliente12 = GaranteUtilizadores(bd, "Rita de Brandão2", "510065112", new DateTime(1956, 08, 27), "Largo 5 de Outubro Jardim dos Campos Pares", "929985575", "rita.brandao2@RD-Telecom.com", "3880-007", "Cliente", false, "Aveiro", new DateTime(2021, 02, 05), 0, 1);
            var aveirocliente13 = GaranteUtilizadores(bd, "Rita de Brandão3", "509688977", new DateTime(1956, 08, 27), "Largo 5 de Outubro Jardim dos Campos Pares", "929985576", "rita.brandao3@RD-Telecom.com", "3880-008", "Cliente", false, "Aveiro", new DateTime(2021, 02, 05), 0, 1);
            var aveirocliente14 = GaranteUtilizadores(bd, "Rita de Brandão4", "508948576", new DateTime(1956, 08, 27), "Largo 5 de Outubro Jardim dos Campos Pares", "929985577", "rita.brandao4@RD-Telecom.com", "3880-009", "Cliente", false, "Aveiro", new DateTime(2021, 02, 05), 0, 1);
            var aveirocliente15 = GaranteUtilizadores(bd, "Cliente", "506719693", new DateTime(2000, 01, 19), "Sargento Mor", "921233389", "cliente@RDtelecom.com", "3020-740", "Cliente", false, "Aveiro", new DateTime(2020, 08, 05), 0, 1);


            //Clientes de Beja
            var bejacliente1 = GaranteUtilizadores(bd, "Ramos de Oliveira", "234325003", new DateTime(2001, 01, 19), "Beco da Rua Acima", "963125884", "eduardo.pires@RD-Telecom.com", "7960-002", "Cliente", false, "Beja", new DateTime(2021, 01, 05), 0, 2);
            var bejacliente2 = GaranteUtilizadores(bd, "Catarina Alves", "274113490", new DateTime(1995, 09, 21), "Marmelar", "932789991", "gloria.ascencao@RD-Telecom.com", "7960-001", "Cliente", false, "Beja", new DateTime(2020, 10, 17), 0, 2);
            var bejacliente3 = GaranteUtilizadores(bd, "Rui del Nascimiento", "255721188", new DateTime(1965, 10, 11), "Rua Longa", "921029661", "maria.aparecida@RD-Telecom.com", "7940-160", "Cliente", false, "Beja", new DateTime(2020, 10, 25), 0, 2);
            var bejacliente4 = GaranteUtilizadores(bd, "Vasco Barreiros", "296928135", new DateTime(1962, 02, 25), "Avenida Manuel Álvaro Lopes Pereira", "927477781", "bernado.ribeiro@RD-Telecom.com", "3800-625", "Cliente", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            var bejacliente5 = GaranteUtilizadores(bd, "Mário Botelho", "222784261", new DateTime(1987, 07, 16), "Albergaria dos Fusos", "923148000", "amadeu.almeida@RD-Telecom.com", "7940-411", "Cliente", false, "Beja", new DateTime(2020, 08, 26), 0, 2);
            var bejacliente6 = GaranteUtilizadores(bd, "Lula de La Cruz", "227929160", new DateTime(1958, 04, 05), "Rua dos Lobos", "932951883", "jose.socrates@RD-Telecom.com", "7920-005", "Cliente", false, "Beja", new DateTime(2020, 08, 28), 0, 2);
            var bejacliente7 = GaranteUtilizadores(bd, "Paula Piruvato", "213154145", new DateTime(1992, 09, 04), "Largo dos Cadeirões", "935777153", "ana.brito@RD-Telecom.com", "7920-002", "Cliente", false, "Beja", new DateTime(2021, 02, 28), 0, 2);
            var bejacliente8 = GaranteUtilizadores(bd, "Thomas Lourenço", "244040737", new DateTime(1979, 04, 06), "Praça do Ultramar", "928969741", "luis.neto@RD-Telecom.com", "7801-857", "Cliente", false, "Beja", new DateTime(2020, 10, 28), 0, 2);
            var bejacliente9 = GaranteUtilizadores(bd, "Luís Smith", "206451326", new DateTime(1975, 06, 08), "Moitinhas", "960155584", "freitas.mondego@RD-Telecom.com", "7665-803", "Cliente", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            var bejacliente10 = GaranteUtilizadores(bd, "Márcia Wood", "226962938", new DateTime(1972, 11, 27), "Ribeira de Torquinhos", "921733321", "joao.cardoso@RD-Telecom.com", "7665-814", "Cliente", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            var bejacliente11 = GaranteUtilizadores(bd, "Jerónimo Graciano", "294559604", new DateTime(1956, 05, 22), "Rua da Cova da Burra", "928999965", "jeronimo@RD-Telecom.com", "7700-003", "Cliente", false, "Beja", new DateTime(2021, 01, 05), 0, 2);
            var bejacliente12 = GaranteUtilizadores(bd, "Jerónimo #2", "504749781", new DateTime(1956, 05, 22), "Rua da Cova da Burra", "928999966", "jeronimo1@RD-Telecom.com", "7700-003", "Cliente", false, "Beja", new DateTime(2021, 01, 05), 0, 2);
            var bejacliente13 = GaranteUtilizadores(bd, "Jerónimo #3", "502778849", new DateTime(1956, 05, 22), "Rua da Cova da Burra", "928999967", "jeronimo2@RD-Telecom.com", "7700-003", "Cliente", false, "Beja", new DateTime(2021, 01, 05), 0, 2);

            //Clientes de Braga
            var bragacliente1 = GaranteUtilizadores(bd, "Fernando Couto", "379524520", new DateTime(1977, 03, 19), "Rua dos Bombeiros Voluntários", "960999231", "fernado.couto@RD-Telecom.com", "4700-002", "Cliente", false, "Braga", new DateTime(2020, 12, 05), 0, 3);
            var bragacliente2 = GaranteUtilizadores(bd, "Deolinda Bacalhau", "311778135", new DateTime(2001, 05, 21), "Rua Professora Alda Brandão Real", "938784787", "deolinda.bacalhau@RD-Telecom.com", "4700-002", "Cliente", false, "Braga", new DateTime(2020, 11, 17), 0, 3);
            var bragacliente3 = GaranteUtilizadores(bd, "Ivanilda Pessoa", "398444773", new DateTime(1977, 08, 01), "Rua da Sobreira Frossos", "923088821", "ivanilda.pessoa@RD-Telecom.com", "4700-441", "Cliente", false, "Braga", new DateTime(2020, 12, 26), 0, 3);
            var bragacliente4 = GaranteUtilizadores(bd, "Onofre Galvão", "314065806", new DateTime(1969, 04, 30), "Largo de Maximinos", "928777413", "onofre.galvao@RD-Telecom.com", "4700-999", "Cliente", false, "Braga", new DateTime(2020, 12, 10), 0, 3);
            var bragacliente5 = GaranteUtilizadores(bd, "Ian Coelho", "349413444", new DateTime(2002, 01, 31), "Largo de São Tiago", "92577963", "ian.coelho@RD-Telecom.com", "4704-504", "Cliente", false, "Braga", new DateTime(2020, 11, 05), 0, 3);
            var bragacliente6 = GaranteUtilizadores(bd, "Ryan Oliveira", "304309028", new DateTime(1988, 03, 05), "Rua das Oliveiras", "920324433", "ryan.oliveira@RD-Telecom.com", "4705-790", "Cliente", false, "Braga", new DateTime(2020, 11, 28), 0, 3);
            var bragacliente7 = GaranteUtilizadores(bd, "Marizete Gillot", "351103988", new DateTime(1956, 10, 04), "Rua dos Caixoteiros", "922008889", "marizete.gillot@RD-Telecom.com", "4705-001", "Cliente", false, "Braga", new DateTime(2020, 10, 07), 0, 3);
            var bragacliente8 = GaranteUtilizadores(bd, "Beto da Alegria", "381587959", new DateTime(1957, 03, 17), "Rua Sem Nome", "925599841", "beto.alegria@RD-Telecom.com", "4750-008", "Cliente", false, "Braga", new DateTime(2021, 01, 05), 0, 3);
            var bragacliente9 = GaranteUtilizadores(bd, "Pinheiro dos Santos", "328112283", new DateTime(1970, 02, 28), "Travessa do Rio da Guarda", "921113288", "pinheiro.santos@RD-Telecom.com", "4765-489", "Cliente", false, "Braga", new DateTime(2021, 02, 05), 0, 3);
            var bragacliente10 = GaranteUtilizadores(bd, "Divina de Jesus", "104815809", new DateTime(1958, 11, 30), "Rua Cães de Pedra Lt 5", "921786632", "divina.jesus@RD-Telecom.com", "4835-003", "Cliente", false, "Braga", new DateTime(2021, 02, 12), 0, 3);
            var bragacliente11 = GaranteUtilizadores(bd, "Irina Leite", "169622398", new DateTime(1999, 10, 27), "Rua da Madalena", "929993600", "irina.leite@RD-Telecom.com", "4835-511", "Cliente", false, "Braga", new DateTime(2021, 01, 14), 0, 3);
            var bragacliente12 = GaranteUtilizadores(bd, "Cliente Braga1", "980438829", new DateTime(1999, 10, 27), "Rua da Madalena", "929993601", "clientebraga1@RD-Telecom.com", "4835-511", "Cliente", false, "Braga", new DateTime(2021, 01, 14), 0, 3);
            var bragacliente13 = GaranteUtilizadores(bd, "Cliente Braga2", "510075029", new DateTime(1999, 10, 27), "Rua da Madalena", "929993602", "clientebraga2@RD-Telecom.com", "4835-511", "Cliente", false, "Braga", new DateTime(2021, 01, 14), 0, 3);


            //--------------------BRAGANCA-------------------------------------------------
            var bragancacliente1 = GaranteUtilizadores(bd, "Natally Domingues", "190328274", new DateTime(1974, 06, 19), "Bairro Moinho de Vento", "939088858", "natally.domingues@RD-Telecom.com", "5140-005", "Cliente", false, "Bragança", new DateTime(2020, 11, 13), 0, 4);
            var bragancacliente2 = GaranteUtilizadores(bd, "Nicolau Figueiras", "128593598", new DateTime(2001, 01, 21), "Quinta Lameira de Ferro", "932100091", "nicolau.figueiras@RD-Telecom.com", "5140-135", "Cliente", false, "Bragança", new DateTime(2020, 10, 27), 0, 4);
            var bragancacliente3 = GaranteUtilizadores(bd, "John Dias", "106481150", new DateTime(1987, 09, 03), "Rua Sem Nome 218 Bairro Além do Rio ", "966853331", "john.dias@RD-Telecom.com", "5300-001", "Cliente", false, "Bragança", new DateTime(2020, 10, 25), 0, 4);
            var bragancacliente4 = GaranteUtilizadores(bd, "Maria Leal", "121325539", new DateTime(1969, 09, 30), "Rua da Fragata", "923456396", "maria.leal@RD-Telecom.com", "5385-101", "Cliente", false, "Bragança", new DateTime(2020, 11, 12), 0, 4);
            var bragancacliente5 = GaranteUtilizadores(bd, "Isabel dos Santinhos", "124336760", new DateTime(1957, 05, 31), "Valbom Pitez", "922788556", "isabel.santinhos@RD-Telecom.com", "5385-132", "Cliente", false, "Bragança", new DateTime(2020, 12, 07), 0, 4);
            var bragancacliente6 = GaranteUtilizadores(bd, "Rui Fragona", "133933784", new DateTime(1988, 03, 07), "Azenha do Areal", "920975411", "rui.fragona@RD-Telecom.com", "5370-131", "Cliente", false, "Bragança", new DateTime(2020, 12, 18), 0, 4);
            var bragancacliente7 = GaranteUtilizadores(bd, "Dunildo de Boa Esperança", "160594944", new DateTime(2000, 10, 04), "Vale de Lobo", "929693777", "dunildo.esperanca@RD-Telecom.com", "5370-102", "Cliente", false, "Bragança", new DateTime(2020, 12, 24), 0, 4);
            var bragancacliente8 = GaranteUtilizadores(bd, "Carla Dorys", "220963959", new DateTime(1995, 08, 17), "Vilar Seco", "963991087", "carla.dorys@RD-Telecom.com", "5350-204", "Cliente", false, "Bragança", new DateTime(2020, 10, 05), 0, 4);
            var bragancacliente9 = GaranteUtilizadores(bd, "Birna de Oliveira", "218499124", new DateTime(1980, 02, 28), "Rua dos Combatentes da Grande Guerra", "930100852", "birna.oliveira@RD-Telecom.com", "5301-861", "Cliente", false, "Bragança", new DateTime(2021, 03, 05), 0, 4);
            var bragancacliente10 = GaranteUtilizadores(bd, "João Salgado", "259012629", new DateTime(1966, 11, 30), "Rua Cova da Beira", "926698880", "joao.salgado@RD-Telecom.com", "5300-869", "Cliente", false, "Bragança", new DateTime(2021, 01, 05), 0, 4);
            var bragancacliente11 = GaranteUtilizadores(bd, "Feitosa Pauleta", "235592650", new DateTime(1972, 10, 27), "Rotunda do Lavrador Bairro da Braguinha ", "921038825", "feitosa.pauleta@RD-Telecom.com", "5300-420", "Cliente", false, "Bragança", new DateTime(2021, 02, 21), 0, 4);
            var bragancacliente12 = GaranteUtilizadores(bd, "Feitosa 2", "502778849", new DateTime(1972, 10, 27), "Rotunda do Lavrador Bairro da Braguinha ", "921038826", "feitosa.pauleta2@RD-Telecom.com", "5300-420", "Cliente", false, "Bragança", new DateTime(2021, 02, 21), 0, 4);


            //    //-------------------------- 5 CASTELO BRANCO------------------
            var castelobrancocliente1 = GaranteUtilizadores(bd, "Cláudia Vieira", "187114781", new DateTime(1965, 06, 19), "Rua das Rosas", "933897771", "claudia.vieira@RD-Telecom.com", "6250-004", "Cliente", false, "Castelo Branco", new DateTime(2020, 10, 11), 0, 5);
            var castelobrancocliente2 = GaranteUtilizadores(bd, "Diogo Andrade", "151327912", new DateTime(1999, 01, 21), "Sítio do Cabecinho", "937333852", "diogo.andrade@RD-Telecom.com", "6250-111", "Cliente", false, "Castelo Branco", new DateTime(2020, 09, 05), 0, 5);
            var castelobrancocliente3 = GaranteUtilizadores(bd, "Maria Ruah", "137352603", new DateTime(1988, 02, 03), "Quinta de Valverdinho", "963013347", "maria.ruah@RD-Telecom.com", "6250-163", "Cliente", false, "Castelo Branco", new DateTime(2020, 11, 03), 0, 5);
            var castelobrancocliente4 = GaranteUtilizadores(bd, "Florbela Antunes", "132809338", new DateTime(1980, 09, 30), "Rua do Curral", "929913645", "florbela.antunes@RD-Telecom.com", "6215-001", "Cliente", false, "Castelo Branco", new DateTime(2020, 11, 20), 0, 5);
            var castelobrancocliente5 = GaranteUtilizadores(bd, "António Antunes", "137252226", new DateTime(1974, 05, 31), "Rua Marquês de Ávila e Bolama", "928329961", "antonio.antunes@RD-Telecom.com", "6201-001", "Cliente", false, "Castelo Branco", new DateTime(2020, 12, 22), 0, 5);
            var castelobrancocliente6 = GaranteUtilizadores(bd, "Liliana Aveiro", "188164138", new DateTime(2000, 03, 07), "Viela do Castelo", "928881759", "liliana.aveiro@RD-Telecom.com", "6200-227", "Cliente", false, "Castelo Branco", new DateTime(2020, 11, 18), 0, 5);
            var castelobrancocliente7 = GaranteUtilizadores(bd, "Maria Pedroso", "179189093", new DateTime(2000, 10, 04), "Travessa das Trapas", "924688158", "maria.pedroso@RD-Telecom.com", "6200-237", "Cliente", false, "Castelo Branco", new DateTime(2020, 11, 17), 0, 5);
            var castelobrancocliente8 = GaranteUtilizadores(bd, "Pedro Fernandes", "101788460", new DateTime(1957, 08, 17), "Bairro da Formiguinha Vila do Carvalho", "966333357", "pedro.fernandes@RD-Telecom.com", "6200-241", "Cliente", false, "Castelo Branco", new DateTime(2021, 01, 13), 0, 5);
            var castelobrancocliente9 = GaranteUtilizadores(bd, "Miguel Moniz", "116037490", new DateTime(1962, 02, 28), "Rua das Tendas", "933212789", "miguel.moniz@RD-Telecom.com", "6200-699", "Cliente", false, "Castelo Branco", new DateTime(2021, 01, 30), 0, 5);
            var castelobrancocliente10 = GaranteUtilizadores(bd, "Felisberto Ortiz", "123718805", new DateTime(1971, 02, 28), "Travessa dos Escabelados", "922111366", "felisberto.ortiz@RD-Telecom.com", "6200-742", "Cliente", false, "Castelo Branco", new DateTime(2021, 02, 20), 0, 5);
            var castelobrancocliente11 = GaranteUtilizadores(bd, "António Sanchez", "124414680", new DateTime(1976, 11, 27), "Rua Canada", "925688710", "antonio.sanchez@RD-Telecom.com", "6005-002", "Cliente", false, "Castelo Branco", new DateTime(2021, 01, 13), 0, 5);
            var castelobrancocliente12 = GaranteUtilizadores(bd, "António Sanchez2", "511195370", new DateTime(1976, 11, 27), "Rua Canada", "925688711", "antonio2.sanchez@RD-Telecom.com", "6005-002", "Cliente", false, "Castelo Branco", new DateTime(2021, 01, 13), 0, 5);

            //    //-------------------------- 6 COIMBRA-----------------
            var coimbracliente1 = GaranteUtilizadores(bd, "Patrícia Gomes", "132814714", new DateTime(1999, 07, 01), "Rua do Norte", "929152221", "patricia.gomes@RD-Telecom.com", "3000-295", "Cliente", false, "Coimbra", new DateTime(2020, 10, 05), 0, 6);
            var coimbracliente2 = GaranteUtilizadores(bd, "Marlene Santos", "146552504", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "933334121", "marlene.satos@RD-Telecom.com", "3030-253", "Cliente", false, "Coimbra", new DateTime(2020, 12, 01), 0, 6);
            var coimbracliente3 = GaranteUtilizadores(bd, "João Ferreira", "125308655", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "929150021", "joao.ferreira@RD-Telecom.com", "3084-501", "Cliente", false, "Coimbra", new DateTime(2020, 11, 26), 0, 6);
            var coimbracliente4 = GaranteUtilizadores(bd, "Tânia Sousa", "164157174", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "927004121", "tania-sousa@RD-Telecom.com", "3400-215", "Cliente", false, "Coimbra", new DateTime(2020, 10, 27), 0, 6);
            var coimbracliente5 = GaranteUtilizadores(bd, "Rute Martins", "137414625", new DateTime(1979, 10, 30), "Cruz de Ferro", "929152229", "rute.martins@RD-Telecom.com", "3000-295", "Cliente", false, "Coimbra", new DateTime(2020, 09, 25), 0, 6);
            var coimbracliente6 = GaranteUtilizadores(bd, "Paulo Pedra", "173407951", new DateTime(1999, 07, 01), "Rua do Norte", "929155521", "paulo.pedra@RD-Telecom.com", "3000-295", "Cliente", false, "Coimbra", new DateTime(2020, 10, 11), 0, 6);
            var coimbracliente7 = GaranteUtilizadores(bd, "Helder Copeto", "145533590", new DateTime(1999, 07, 01), "Rua do Norte", "929122221", "helder.copeto@RD-Telecom.com", "3000-295", "Cliente", false, "Coimbra", new DateTime(2020, 10, 11), 0, 6);
            var coimbracliente8 = GaranteUtilizadores(bd, "Miriam Falcão", "149807074", new DateTime(2000, 01, 01), "Vale Derradeiro", "928884121", "miriam.falcao@RD-Telecom.com", "3320-002", "Cliente", false, "Coimbra", new DateTime(2020, 10, 11), 0, 6);
            var coimbracliente9 = GaranteUtilizadores(bd, "Célia Tomate", "113263295", new DateTime(1980, 09, 11), "Seladinhas", "929133321", "celia.tomate@RD-Telecom.com", "3320-367", "Cliente", false, "Coimbra", new DateTime(2021, 02, 18), 0, 6);
            var coimbracliente10 = GaranteUtilizadores(bd, "Tadeu Leão", "174464681", new DateTime(1975, 02, 08), "Flor da Rosa", "929159991", "tadeu.leao@RD-Telecom.com", "3040-471", "Cliente", false, "Coimbra", new DateTime(2021, 03, 11), 0, 6);
            var coimbracliente11 = GaranteUtilizadores(bd, "Harley Guerra", "148342205", new DateTime(1955, 12, 24), "Beco da Alegria", "929222121", "harley.guerra@RD-Telecom.com", "3025-129", "Cliente", false, "Coimbra", new DateTime(2021, 02, 20), 0, 6);
            var coimbracliente12 = GaranteUtilizadores(bd, "Afonso Freira", "118233580", new DateTime(1956, 12, 05), "Beco das Cruzes", "929004121", "afonso.freira@RD-Telecom.com", "3000-133 ", "Cliente", false, "Coimbra", new DateTime(2021, 01, 11), 0, 6);


            //    //-------------------------- 7 EVORA-----------------
            var evoracliente1 = GaranteUtilizadores(bd, "Andreia Alves", "226173461", new DateTime(2001, 07, 01), "Vale de Pegas", "921996654", "andreia.alves@RD-Telecom.com", "7490-120", "Cliente", false, "Évora", new DateTime(2020, 10, 17), 0, 7);
            var evoracliente2 = GaranteUtilizadores(bd, "João Correia", "265149207", new DateTime(1999, 11, 21), "Rua João de Deus", "936889914", "joao.correia@RD-Telecom.com", "7250-142", "Cliente", false, "Évora", new DateTime(2020, 09, 28), 0, 7);
            var evoracliente3 = GaranteUtilizadores(bd, "Ricardo da Gama", "278404324", new DateTime(1975, 07, 01), "Rua da Liberdade", "920111963", "ricardo.gama@RD-Telecom.com", "7220-002", "Cliente", false, "Évora", new DateTime(2020, 09, 26), 0, 7);
            var evoracliente4 = GaranteUtilizadores(bd, "Inês Castro", "214553698", new DateTime(1969, 06, 08), "Rua dos Irmãos", "927000148", "ines.castro@RD-Telecom.com", "7220-003", "Cliente", false, "Évora", new DateTime(2020, 11, 13), 0, 7);
            var evoracliente5 = GaranteUtilizadores(bd, "Andressa Ribeiro", "201479745", new DateTime(1962, 03, 30), "Praceta do Brasil", "928000147", "andressa.ribeiro@RD-Telecom.com", "7200-479", "Cliente", false, "Évora", new DateTime(2020, 11, 07), 0, 7);
            var evoracliente6 = GaranteUtilizadores(bd, "Pablo Abrunhosa", "239385853", new DateTime(1980, 07, 01), "Rua Projectada à Avenida Tomás Alcaide", "926999953", "pablo.abrunhosa@RD-Telecom.com", "7100-130", "Cliente", false, "Évora", new DateTime(2020, 11, 05), 0, 7);
            var evoracliente7 = GaranteUtilizadores(bd, "Ramon Marques", "286791862", new DateTime(1999, 07, 01), "Travessa das Amendoeiras", "920123395", "ramon.marques@RD-Telecom.com", "7090-006", "Cliente", false, "Évora", new DateTime(2020, 10, 03), 0, 7);
            var evoracliente8 = GaranteUtilizadores(bd, "Mariana da Serenidade", "240339380", new DateTime(1999, 01, 01), "Bairro Ferragolo", "922999698", "mariana.serenidade@RD-Telecom.com", "7080-109", "Cliente", false, "Évora", new DateTime(2020, 11, 26), 0, 7);
            var evoracliente9 = GaranteUtilizadores(bd, "Dilma Rosas", "264773268", new DateTime(1958, 09, 21), "Casa de Pau", "920888147", "dilma.rosas@RD-Telecom.com", "7050-634", "Cliente", false, "Évora", new DateTime(2020, 11, 26), 0, 7);
            var evoracliente10 = GaranteUtilizadores(bd, "Vicente Silva", "249853442", new DateTime(1965, 02, 08), "Largo das Alterações", "931459321", "vicente.silva@RD-Telecom.com", "7000-502", "Cliente", false, "Évora", new DateTime(2021, 01, 26), 0, 7);
            var evoracliente11 = GaranteUtilizadores(bd, "Flascotter Pereira", "250372339", new DateTime(1995, 03, 24), "Rua Francisco Soares Lusitano", "966321010", "flascotter.pereira@RD-Telecom.com", "7004-511", "Cliente", false, "Évora", new DateTime(2021, 01, 26), 0, 7);
            var evoracliente12 = GaranteUtilizadores(bd, "Sara Moedas", "254578870", new DateTime(1956, 05, 05), "Largo dos Colegiais 2", "933299871", "sara.moedas@RD-Telecom.com", "7004-516", "Cliente", false, "Évora", new DateTime(2021, 02, 26), 0, 7);

            //    //-------------------------- 8 FARO-----------------
            var farocliente1 = GaranteUtilizadores(bd, "Miguel Rossi", "253871166", new DateTime(1999, 07, 01), "Rua da Viola ", "925874990", "miguel.rossi@RD-Telecom.com", "8000-274", "Cliente", false, "Faro", new DateTime(2020, 12, 28), 0, 8);
            var farocliente2 = GaranteUtilizadores(bd, "Martina Castilho", "287333248", new DateTime(1988, 11, 21), "Rua do Bocage", "930662145", "martina.castilho@RD-Telecom.com", "8004-002", "Cliente", false, "Faro", new DateTime(2020, 12, 06), 0, 8);
            var farocliente3 = GaranteUtilizadores(bd, "Romeo Ximenes", "247989940", new DateTime(1978, 07, 01), "Areal Gordo", "932777410", "romeo.ximenes@RD-Telecom.com", "8005-409", "Cliente", false, "Faro", new DateTime(2020, 11, 17), 0, 8);
            var farocliente4 = GaranteUtilizadores(bd, "John Pitt", "219245061", new DateTime(1969, 06, 06), "Travessa do Borrego", "933699520", "john.pitt@RD-Telecom.com", "8125-002", "Cliente", false, "Faro", new DateTime(2020, 09, 17), 0, 8);
            var farocliente5 = GaranteUtilizadores(bd, "Zézinho Camarrinha", "288869397", new DateTime(1979, 10, 30), "Beco das Palmeiras", "921238802", "zezinho.camarrinha@RD-Telecom.com", "8125-609", "Cliente", false, "Faro", new DateTime(2020, 10, 19), 0, 8);
            var farocliente6 = GaranteUtilizadores(bd, "Luna Smith", "205571000", new DateTime(1999, 07, 01), "Beco Condestável", "925677717", "luna.smith@RD-Telecom.com", "8125-636", "Cliente", false, "Faro", new DateTime(2020, 10, 27), 0, 8);
            var farocliente7 = GaranteUtilizadores(bd, "Luísa Salvador", "261067010", new DateTime(1999, 06, 01), "Beco dos Bitas", "936299902", "luisa.salvador@RD-Telecom.com", "8200-002", "Cliente", false, "Faro", new DateTime(2020, 10, 26), 0, 8);
            var farocliente8 = GaranteUtilizadores(bd, "Ana Cacho", "221649549", new DateTime(2000, 01, 01), "Rua das Telecomunicações", "920333001", "ana.cacho@RD-Telecom.com", "8201-871", "Cliente", false, "Faro", new DateTime(2020, 11, 17), 0, 8);
            var farocliente9 = GaranteUtilizadores(bd, "Fernando Rock", "200024078", new DateTime(1980, 09, 11), "Caminho Municipal", "967399974", "fernando.rock@RD-Telecom.com", "8201-877", "Cliente", false, "Faro", new DateTime(2021, 03, 17), 0, 8);
            var farocliente10 = GaranteUtilizadores(bd, "Miguel Feliz", "112022740", new DateTime(1975, 02, 08), "Avenida dos Descobrimentos", "921327771", "miguel.feliz@RD-Telecom.com", "8601-852", "Cliente", false, "Faro", new DateTime(2021, 02, 17), 0, 8);
            var farocliente11 = GaranteUtilizadores(bd, "Maria Ferrari", "175059500", new DateTime(1955, 12, 24), "Rua 25 de Abril", "917866623", "maria.ferrari@RD-Telecom.com", "8801-005", "Cliente", false, "Faro", new DateTime(2021, 01, 28), 0, 8);
            var farocliente12 = GaranteUtilizadores(bd, "Bruno da Câmara Pereira", "173713785", new DateTime(1956, 12, 05), "Monte Olimpio", "917300725", "bruno.pereira@RD-Telecom.com", "8900-106", "Cliente", false, "Faro", new DateTime(2021, 01, 15), 0, 8);


            //    //-------------------------- 9 GUARDA-----------------
            var guardacliente1 = GaranteUtilizadores(bd, "Alicia Sancho", "191045012", new DateTime(1988, 07, 01), "Ponte do Abade", "926000852", "alicia.sancho@RD-Telecom.com", "3570-191", "Cliente", false, "Guarda", new DateTime(2020, 11, 03), 0, 9);
            var guardacliente2 = GaranteUtilizadores(bd, "Mateo Jesus", "100156320", new DateTime(1964, 11, 21), "Rua Quebra Costas", "931122589", "mateo.jesus@RD-Telecom.com", "5155-003", "Cliente", false, "Guarda", new DateTime(2020, 10, 18), 0, 9);
            var guardacliente3 = GaranteUtilizadores(bd, "Antonnella Conti", "124152384", new DateTime(1954, 08, 01), "Zurrão", "920007410", "antonnella.conti@RD-Telecom.com", "6260-196", "Cliente", false, "Guarda", new DateTime(2020, 09, 20), 0, 9);
            var guardacliente4 = GaranteUtilizadores(bd, "Nuno Gatti", "188733698", new DateTime(1970, 02, 06), "Carvalhal da Louça", "923111789", "nuno.gatti@RD-Telecom.com", "6270-131", "Cliente", false, "Guarda", new DateTime(2020, 10, 28), 0, 9);
            var guardacliente5 = GaranteUtilizadores(bd, "Patrícia Carbone", "140198016", new DateTime(1980, 03, 30), "Rua Amadeus Mozart", "966961149", "patricia.carbone@RD-Telecom.com", "6300-509", "Cliente", false, "Guarda", new DateTime(2020, 12, 28), 0, 9);
            var guardacliente6 = GaranteUtilizadores(bd, "Pedro Guerra", "178896896", new DateTime(1999, 08, 01), "Muxagata", "923499987", "pedro.guerra@RD-Telecom.com", "6370-361", "Cliente", false, "Guarda", new DateTime(2020, 10, 28), 0, 9);
            var guardacliente7 = GaranteUtilizadores(bd, "Célia Valente", "184714370", new DateTime(1999, 07, 01), "Juncais", "910999658", "celia.valente@RD-Telecom.com", "6370-332", "Cliente", false, "Guarda", new DateTime(2020, 11, 28), 0, 9);
            var guardacliente8 = GaranteUtilizadores(bd, "Rosa Serra", "139163085", new DateTime(2000, 01, 01), "Quinta da Costa", "92800532", "rosa.serra@RD-Telecom.com", "6324-004", "Cliente", false, "Guarda", new DateTime(2020, 12, 05), 0, 9);
            var guardacliente9 = GaranteUtilizadores(bd, "Ricardo Estrela", "138133743", new DateTime(1987, 09, 17), "Parada", "963991456", "ricardo.estrla@RD-Telecom.com", "6355-142", "Cliente", false, "Guarda", new DateTime(2021, 02, 28), 0, 9);
            var guardacliente10 = GaranteUtilizadores(bd, "Carlos Fechaduras", "131192051", new DateTime(1859, 05, 08), "Senouras", "925999874", "carlos.fechaduras@RD-Telecom.com", "6355-170", "Cliente", false, "Guarda", new DateTime(2021, 03, 01), 0, 9);
            var guardacliente11 = GaranteUtilizadores(bd, "Álvaro Bruxelas", "163833320", new DateTime(1958, 12, 31), "Beco da Alegria", "91055800", "alvaro.bruxelas@RD-Telecom.com", "6355-170", "Cliente", false, "Guarda", new DateTime(2021, 01, 20), 0, 9);
            var guardacliente12 = GaranteUtilizadores(bd, "Isamara Lobão", "104089440", new DateTime(1956, 12, 05), "Lajeosa", "936000077", "isamara.lobao@RD-Telecom.com", "6320-161", "Cliente", false, "Guarda", new DateTime(2021, 01, 28), 0, 9);

            //    //-------------------------- 10 LEIRIA-----------------
            var leiriacliente1 = GaranteUtilizadores(bd, "Amílcar Malho", "174926960", new DateTime(1967, 03, 01), "Rua dos Inácios", "923888144", "amilcar.malho@RD-Telecom.com", "2400-773", "Cliente", false, "Leiria", new DateTime(2020, 10, 18), 0, 10);
            var leiriacliente2 = GaranteUtilizadores(bd, "Joana de Sá", "298515989", new DateTime(1966, 11, 21), "Rua do Futuro", "931114711", "joana.sa@RD-Telecom.com", "2400-760", "Cliente", false, "Leiria", new DateTime(2020, 09, 25), 0, 10);
            var leiriacliente3 = GaranteUtilizadores(bd, "João Cabral", "297389955", new DateTime(2000, 06, 01), "Moinho do Rato", "925687708", "joao.cabral@RD-Telecom.com", "2410-528", "Cliente", false, "Leiria", new DateTime(2020, 10, 25), 0, 10);
            var leiriacliente4 = GaranteUtilizadores(bd, "Ilídio Brazeta", "259304727", new DateTime(1999, 06, 09), "Rua de Saint-Maur-Des-Fosses", "963999547", "ilidio.brazeta@RD-Telecom.com", "2414-001", "Cliente", false, "Leiria", new DateTime(2020, 10, 08), 0, 10);
            var leiriacliente5 = GaranteUtilizadores(bd, "Ricardo Caramelo", "240926803", new DateTime(1984, 02, 28), "Estrada da Mata Marrazes", "921457880", "ricardo.caramelo@RD-Telecom.com", "2419-001", "Cliente", false, "Leiria", new DateTime(2020, 10, 03), 0, 10);
            var leiriacliente6 = GaranteUtilizadores(bd, "João Figo", "210911891", new DateTime(1999, 07, 11), "Rua de Santa Margarida", "923099958", "joao.figo@RD-Telecom.com", "2420-999", "Cliente", false, "Leiria", new DateTime(2020, 11, 28), 0, 10);
            var leiriacliente7 = GaranteUtilizadores(bd, "Romina Santos", "201022117", new DateTime(1999, 07, 01), "Beco Grilo", "931477779", "romina.santos@RD-Telecom.com", "2460-005", "Cliente", false, "Leiria", new DateTime(2020, 11, 17), 0, 10);
            var leiriacliente8 = GaranteUtilizadores(bd, "Rui Rosa", "248554140", new DateTime(2000, 01, 01), "Rua Mercedes e Carlos Campeão", "968541100", "rui.rosa@RD-Telecom.com", "2460-006", "Cliente", false, "Leiria", new DateTime(2020, 11, 12), 0, 10);
            var leiriacliente9 = GaranteUtilizadores(bd, "Vanda Ruivo", "251055809", new DateTime(1980, 10, 11), "Bolo", "922388809", "vanda.ruivo@RD-Telecom.com", "3280-113", "Cliente", false, "Leiria", new DateTime(2020, 11, 03), 0, 10);
            var leiriacliente10 = GaranteUtilizadores(bd, "Tiago Andrade", "219730024", new DateTime(1975, 08, 08), "Sapateira", "967365333", "tiago.andrade@RD-Telecom.com", "3280-123", "Cliente", false, "Leiria", new DateTime(2020, 11, 03), 0, 10);
            var leiriacliente11 = GaranteUtilizadores(bd, "Marta Martinelli", "280206054", new DateTime(1988, 12, 24), "Rua dos Lavadouros", "910258977", "marta.martinelli@RD-Telecom.com", "2525-123", "Cliente", false, "Leiria", new DateTime(2021, 03, 03), 0, 10);
            var leiriacliente12 = GaranteUtilizadores(bd, "Joaquim Vitale", "252516800", new DateTime(1996, 12, 05), "Picha", "939300650", "joaquim.vitale@RD-Telecom.com", "3270-143", "Cliente", false, "Leiria", new DateTime(2021, 01, 03), 0, 10);


            //    //-------------------------- 11 LISBOA-----------------
            var lisboacliente1 = GaranteUtilizadores(bd, "Geraldo Fraga", "283068396", new DateTime(1968, 08, 01), "Rua Brito Aranha", "924888230", "geraldo.fraga@RD-Telecom.com", "1000-007", "Cliente", false, "Lisboa", new DateTime(2020, 10, 13), 0, 11);
            var lisboacliente2 = GaranteUtilizadores(bd, "Celeste Djata", "245604693", new DateTime(1969, 11, 28), "Avenida dos Defensores de Chaves", "931182456", "celeste.djata@RD-Telecom.com", "1049-004", "Cliente", false, "Lisboa", new DateTime(2020, 10, 18), 0, 11);
            var lisboacliente3 = GaranteUtilizadores(bd, "Carla Costa", "216326117", new DateTime(1978, 05, 01), "Largo das Palmeiras", "931773888", "carla.costa@RD-Telecom.com", "1050-168", "Cliente", false, "Lisboa", new DateTime(2020, 10, 14), 0, 11);
            var lisboacliente4 = GaranteUtilizadores(bd, "Daniele Lucas", "290364272", new DateTime(1973, 08, 06), "Avenida de Berna", "917133335", "daniele.lucas@RD-Telecom.com", "1067-001", "Cliente", false, "Lisboa", new DateTime(2020, 11, 08), 0, 11);
            var lisboacliente5 = GaranteUtilizadores(bd, "Davide Ramos", "276497961", new DateTime(1986, 10, 30), "Vila Celeste Rua Garcia", "961999620", "davide.ramos@RD-Telecom.com", "1070-136", "Cliente", false, "Lisboa", new DateTime(2020, 12, 18), 0, 11);
            var lisboacliente6 = GaranteUtilizadores(bd, "Diana Leite", "214102351", new DateTime(1999, 07, 01), "Beco Benformoso", "967422226", "diana.leite@RD-Telecom.com", "1100-008", "Cliente", false, "Lisboa", new DateTime(2020, 11, 09), 0, 11);
            var lisboacliente7 = GaranteUtilizadores(bd, "Dunildo Fernandes", "252014456", new DateTime(1988, 07, 01), "Largo Cabeço da Bola", "937888813", "dunildo.fernandes@RD-Telecom.com", "1150-008", "Cliente", false, "Lisboa", new DateTime(2020, 11, 02), 0, 11);
            var lisboacliente8 = GaranteUtilizadores(bd, "Beatriz Testa", "249546264", new DateTime(2000, 01, 01), "Beco da Bempostinha", "933336110", "beatriz.testa@RD-Telecom.com", "1150-006", "Cliente", false, "Lisboa", new DateTime(2020, 10, 10), 0, 11);
            var lisboacliente9 = GaranteUtilizadores(bd, "Pedro Farina", "235700576", new DateTime(2000, 09, 29), "Rua dos Anjos", "969999789", "pedro.farina@RD-Telecom.com", "1169-004", "Cliente", false, "Lisboa", new DateTime(2020, 10, 18), 0, 11);
            var lisboacliente10 = GaranteUtilizadores(bd, "Bernardino Caputo", "280722664", new DateTime(1975, 02, 08), "Rua dos Lusíadas", "919320005", "bernardino.caputo@RD-Telecom.com", "1349-006", "Cliente", false, "Lisboa", new DateTime(2021, 03, 10), 0, 11);
            var lisboacliente11 = GaranteUtilizadores(bd, "Pablo Medina", "216419433", new DateTime(1955, 08, 24), "Cabeça Gorda", "935555789", "pablo.medina@RD-Telecom.com", "2565-001", "Cliente", false, "Lisboa", new DateTime(2021, 02, 23), 0, 11);
            var lisboacliente12 = GaranteUtilizadores(bd, "Eva Simões", "279983395", new DateTime(1969, 12, 18), "Avenida João de Belas", "930222789", "eva.simoes@RD-Telecom.com", "2605-203", "Cliente", false, "Lisboa", new DateTime(2021, 01, 18), 0, 11);

            //    //-------------------------- 12 PORTALEGRE-----------------
            var portalegrecliente1 = GaranteUtilizadores(bd, "Paula Neves", "273840240", new DateTime(1987, 05, 01), "Torre Cimeira", "969693331", "paula.neves@RD-Telecom.com", "6040-003", "Cliente", false, "Portalegre", new DateTime(2020, 09, 27), 0, 12);
            var portalegrecliente2 = GaranteUtilizadores(bd, "Filipe Pinto", "276500202", new DateTime(1988, 10, 21), "Rua do Poço", "936772214", "filipe.pinto@RD-Telecom.com", "6050-106", "Cliente", false, "Portalegre", new DateTime(2020, 10, 29), 0, 12);
            var portalegrecliente3 = GaranteUtilizadores(bd, "Ryan Vieira", "138948780", new DateTime(1968, 07, 13), "Ribeiro do Buraco", "921322224", "ryan.vieira@RD-Telecom.com", "7300-351", "Cliente", false, "Portalegre", new DateTime(2020, 10, 07), 0, 12);
            var portalegrecliente4 = GaranteUtilizadores(bd, "Rodrigo Amarelo", "166386367", new DateTime(1970, 06, 28), "Cubos", "928742214", "rodrigo.amarelo@RD-Telecom.com", "7300-316", "Cliente", false, "Portalegre", new DateTime(2020, 12, 06), 0, 12);
            var portalegrecliente5 = GaranteUtilizadores(bd, "Rita Abrantes", "150944810", new DateTime(1984, 10, 07), "Praça do Município", "960000123", "rita.abrantes@RD-Telecom.com", "7301-855", "Cliente", false, "Portalegre", new DateTime(2020, 11, 20), 0, 12);
            var portalegrecliente6 = GaranteUtilizadores(bd, "Luís Rico", "109665619", new DateTime(1982, 07, 18), "Travessa da Rua do Comércio", "911288898", "luis.rico@RD-Telecom.com", "7301-857", "Cliente", false, "Portalegre", new DateTime(2020, 10, 25), 0, 12);
            var portalegrecliente7 = GaranteUtilizadores(bd, "Helder Conceição", "157260070", new DateTime(1973, 07, 01), "Rua das Encruzilhadas", "936236545", "helder.conceicao@RD-Telecom.com", "7320-123", "Cliente", false, "Portalegre", new DateTime(2020, 10, 19), 0, 12);
            var portalegrecliente8 = GaranteUtilizadores(bd, "Mariza Falcão", "186849087", new DateTime(2000, 01, 01), "Portas do Sol", "968555523", "mariza.falcao@RD-Telecom.com", "7350-002", "Cliente", false, "Portalegre", new DateTime(2020, 11, 13), 0, 12);
            var portalegrecliente9 = GaranteUtilizadores(bd, "Lúcio Junior", "122934156", new DateTime(1980, 09, 16), "Rua da Guarda", "961425888", "lucio.junior@RD-Telecom.com", "7350-002", "Cliente", false, "Portalegre", new DateTime(2021, 02, 28), 0, 12);
            var portalegrecliente10 = GaranteUtilizadores(bd, "Tiago Silva", "157929582", new DateTime(1975, 02, 24), "Rua do Escorregadio", "916999985", "tiago.silva@RD-Telecom.com", "7350-002", "Cliente", false, "Portalegre", new DateTime(2021, 01, 20), 0, 12);
            var portalegrecliente11 = GaranteUtilizadores(bd, "Ana Godinho", "194493148", new DateTime(1968, 12, 19), "Rua do Emigrante", "923611182", "ana.godinho@RD-Telecom.com", "7370-001", "Cliente", false, "Portalegre", new DateTime(2021, 02, 22), 0, 12);
            var portalegrecliente12 = GaranteUtilizadores(bd, "Filipa Oliveira", "123458366", new DateTime(1956, 12, 05), "Rua Marciano Cipriano", "923654111", "filipa.oliveira@RD-Telecom.com", "7370-002", "Cliente", false, "Portalegre", new DateTime(2021, 01, 13), 0, 12);

            //-------------------------- 13 PORTO-----------------
            var portocliente1 = GaranteUtilizadores(bd, "Patrícia Amaral", "146136560", new DateTime(1986, 03, 01), "Largo Escultor José Moreira da Silva", "969994000", "patricia.amaral@RD-Telecom.com", "4000-312", "Cliente", false, "Porto", new DateTime(2020, 08, 05), 0, 13);
            var portocliente2 = GaranteUtilizadores(bd, "João Santos", "134833236", new DateTime(1988, 11, 14), "Rua Latino Coelho Pares", "933777655", "joao.santos@RD-Telecom.com", "4000-314", "Cliente", false, "Porto", new DateTime(2021, 01, 05), 0, 13);
            var portocliente3 = GaranteUtilizadores(bd, "João Ferreira", "118889990", new DateTime(1963, 03, 01), "Rua de Moreira Ímpares", "923005564", "joao.ferreira@RD-Telecom.com", "4000-346", "Cliente", false, "Porto", new DateTime(2020, 10, 11), 0, 13);
            var portocliente4 = GaranteUtilizadores(bd, "Tânia Pereira", "222915277", new DateTime(1967, 06, 03), "Rua do Alto da Fontinha", "962221008", "tania.pereira@RD-Telecom.com", "4000-007", "Cliente", false, "Porto", new DateTime(2020, 08, 12), 0, 13);
            var portocliente5 = GaranteUtilizadores(bd, "Rute Pequena", "207335281", new DateTime(1975, 02, 28), "Rua Júlio Dinis Fast-Food Mister Pick Wick", "929994197", "rute.pequena@RD-Telecom.com", "4050-001", "Cliente", false, "Porto", new DateTime(2020, 10, 17), 0, 13);
            var portocliente6 = GaranteUtilizadores(bd, "Paulo Jorge", "272817996", new DateTime(1998, 07, 11), "Rua Júlio Dinis", "923222203", "paulo.jorge@RD-Telecom.com", "4050-322", "Cliente", false, "Porto", new DateTime(2020, 08, 18), 0, 13);
            var portocliente7 = GaranteUtilizadores(bd, "Helder Reis", "233644253", new DateTime(1999, 07, 01), "Travessa Marracuene", "923658890", "helder.reis@RD-Telecom.com", "4050-357", "Cliente", false, "Porto", new DateTime(2020, 08, 26), 0, 13);
            var portocliente8 = GaranteUtilizadores(bd, "Lucas Castilho", "280748604", new DateTime(1974, 01, 01), "Rua Guerra Junqueiro", "938882365", "tome.fernandes@RD-Telecom.com", "4169-009", "Cliente", false, "Porto", new DateTime(2020, 08, 27), 0, 13);
            var portocliente9 = GaranteUtilizadores(bd, "Tomé Fernades", "241553741", new DateTime(1985, 06, 11), "Rua do Campo Alegre", "927888608", "tome.fernandes@RD-Telecom.com", "4169-007", "Cliente", false, "Porto", new DateTime(2020, 08, 25), 0, 13);
            var portocliente10 = GaranteUtilizadores(bd, "Paula Andrade", "273948180", new DateTime(1962, 02, 08), "Rua Gonçalo Sampaio", "925332261", "paula.andrade@RD-Telecom.com", "4169-001", "Cliente", false, "Porto", new DateTime(2020, 11, 10), 0, 13);
            var portocliente11 = GaranteUtilizadores(bd, "Jacinto Dias", "200013980", new DateTime(1957, 03, 24), "Rua do Campo Alegre", "968022020", "jacinto.dias@RD-Telecom.com", "4169-007", "Cliente", false, "Porto", new DateTime(2020, 10, 05), 0, 13);
            var portocliente12 = GaranteUtilizadores(bd, "Amélia Paz", "256250090", new DateTime(1956, 08, 05), "Rua Professora Lucília Fernandes Canidelo", "932336459", "amelia.paz@RD-Telecom.com", "4400-651", "Cliente", false, "Porto", new DateTime(2020, 12, 05), 0, 13);

            //    //-------------------------- 14 SANTAREM-----------------
            var santaremcliente1 = GaranteUtilizadores(bd, "Patrícia Gomes", "233931945", new DateTime(2000, 07, 01), "Casal dos Florindos", "917899925", "patricia.gomes@RD-Telecom.com", "2000-320", "Cliente", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);
            var santaremcliente2 = GaranteUtilizadores(bd, "Marlene Santos", "225618184", new DateTime(1987, 11, 21), "Casal da Igreja", "969951542", "marlene.satos@RD-Telecom.com", "2000-336", "Cliente", false, "Santarém", new DateTime(2020, 08, 19), 0, 14);
            var santaremcliente3 = GaranteUtilizadores(bd, "João Ferreira", "254315321", new DateTime(1978, 07, 01), "Dona Belida", "932007548", "joao.ferreira@RD-Telecom.com", "2000-342", "Cliente", false, "Santarém", new DateTime(2021, 01, 17), 0, 14);
            var santaremcliente4 = GaranteUtilizadores(bd, "Pedro Martins", "211155314", new DateTime(1969, 06, 06), "Avenida Bernardo Santareno", "963215699", "pedro.martins@RD-Telecom.com", "2009-004", "Cliente", false, "Santarém", new DateTime(2021, 01, 05), 0, 14);
            var santaremcliente5 = GaranteUtilizadores(bd, "Joana Lima", "226866920", new DateTime(1979, 10, 30), "Largo do Infante Santo", "923324100", "joana.lima@RD-Telecom.com", "2009-002", "Cliente", false, "Santarém", new DateTime(2021, 01, 05), 0, 14);
            var santaremcliente6 = GaranteUtilizadores(bd, "Patrícia Gomes", "270227300", new DateTime(1999, 04, 01), "Estrada Nacional 10", "925955574", "patricia.gomes@RD-Telecom.com", "2139-503", "Cliente", false, "Santarém", new DateTime(2020, 12, 28), 0, 14);
            var santaremcliente7 = GaranteUtilizadores(bd, "Irís Copeto", "294199098", new DateTime(1999, 09, 05), "Agolada", "965574088", "iris.copeto@RD-Telecom.com", "2100-001", "Cliente", false, "Santarém", new DateTime(2020, 11, 12), 0, 14);
            var santaremcliente8 = GaranteUtilizadores(bd, "Filipe Pais", "284740624", new DateTime(1987, 01, 01), "Varejola", "924898710", "filipe.pais@RD-Telecom.com", "2100-377", "Cliente", false, "Santarém", new DateTime(2020, 12, 12), 0, 14);
            var santaremcliente9 = GaranteUtilizadores(bd, "Amadeu Lourenço", "247047813", new DateTime(1965, 08, 17), "Louriceira", "920250005", "amadeu.lourenço@RD-Telecom.com", "6120-116", "Cliente", false, "Santarém", new DateTime(2020, 11, 05), 0, 14);
            var santaremcliente10 = GaranteUtilizadores(bd, "Amílcar Oliveira", "203980433", new DateTime(1974, 02, 10), "Estrada Nacional 10", "967369511", "amilcar.oliveira@RD-Telecom.com", "2139-503", "Cliente", false, "Santarém", new DateTime(2020, 10, 05), 0, 14);
            var santaremcliente11 = GaranteUtilizadores(bd, "Luísa Guerra", "235929190", new DateTime(1955, 08, 05), "Casal de Além", "922587776", "luisa.guerra@RD-Telecom.com", "2025-150", "Cliente", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);
            var santaremcliente12 = GaranteUtilizadores(bd, "Afonso Freira", "211773441", new DateTime(1957, 07, 05), "Pisão", "931478521", "afonso.freira@RD-Telecom.com", "2230-009", "Cliente", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);

            //    //-------------------------- 15 SETUBAL-----------------
            var setubalcliente1 = GaranteUtilizadores(bd, "Patrícia Varandas", "280863500", new DateTime(1986, 07, 01), "Praceta Bernardim Ribeiro", "914886951", "patricia.varandas@RD-Telecom.com", "2800-002", "Cliente", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            var setubalcliente2 = GaranteUtilizadores(bd, "Miguel Santos", "221444394", new DateTime(1988, 05, 21), "Praça Doutora Adelaide Coutinho", "960007878", "miguel.santos@RD-Telecom.com", "2800-002", "Cliente", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            var setubalcliente3 = GaranteUtilizadores(bd, "João Ferreira", "297310860", new DateTime(1978, 06, 01), "Rua Bulhão Pato", "926555826", "joao.ferreira@RD-Telecom.com", "2800-003", "Cliente", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            var setubalcliente4 = GaranteUtilizadores(bd, "Tânia Sousa", "104715111", new DateTime(1970, 06, 08), "Rua Capitão Leitão Ímpares", "965813310", "tania-sousa@RD-Telecom.com", "2800-137", "Cliente", false, "Setúbal", new DateTime(2020, 11, 05), 0, 15);
            var setubalcliente5 = GaranteUtilizadores(bd, "Rute Martins", "173067735", new DateTime(1968, 10, 30), "Pátio Albers", "926125822", "rute.martins@RD-Telecom.com", "2830-320", "Cliente", false, "Setúbal", new DateTime(2020, 12, 11), 0, 15);
            var setubalcliente6 = GaranteUtilizadores(bd, "Bernardo Pinto", "108452255", new DateTime(2000, 08, 01), "Travessa do Alto José Ferreira", "960001489", "bernardo.pinto@RD-Telecom.com", "2830-381", "Cliente", false, "Setúbal", new DateTime(2020, 08, 19), 0, 15); ;
            var setubalcliente7 = GaranteUtilizadores(bd, "Paula Neves", "176706160", new DateTime(1999, 11, 01), "Rua da Bandeira", "966788952", "paula.neves@RD-Telecom.com", "2830-330", "Cliente", false, "Setúbal", new DateTime(2020, 08, 20), 0, 15);
            var setubalcliente8 = GaranteUtilizadores(bd, "Miriam Palito", "367127822", new DateTime(2001, 01, 01), "Rua Professor Egas Moniz", "914852224", "miriam.palito@RD-Telecom.com", "2830-357", "Cliente", false, "Setúbal", new DateTime(2021, 02, 27), 0, 15);
            var setubalcliente9 = GaranteUtilizadores(bd, "Vanessa Albino", "301702780", new DateTime(1988, 09, 11), "Rua Fernando de Sousa", "923012374", "vanessa.albino@RD-Telecom.com", "2844-001", "Cliente", false, "Setúbal", new DateTime(2020, 12, 30), 0, 15);
            var setubalcliente10 = GaranteUtilizadores(bd, "Rosa Amarelo", "349842078", new DateTime(1975, 02, 11), "2890-200", "920777758", "rosa.amarelo@RD-Telecom.com", "2890-200", "Cliente", false, "Setúbal", new DateTime(2020, 11, 05), 0, 02);
            var setubalcliente11 = GaranteUtilizadores(bd, "Vanessa Rodrigues", "346354463", new DateTime(1955, 07, 28), "Estrada Nacional 5", "968520050", "vanessa.roduigues@RD-Telecom.com", "2959-501", "Cliente", false, "Setúbal", new DateTime(2020, 09, 10), 0, 15);
            var setubalcliente12 = GaranteUtilizadores(bd, "Afonso Pereira", "340319747", new DateTime(1956, 12, 30), "Monte das Parchanas", "968531999", "afonso.pereira@RD-Telecom.com", "7595-002", "Cliente", false, "Setúbal", new DateTime(2020, 10, 28), 0, 15);

            //    //-------------------------- 16 VIANA DO CASTELO-----------------
            var vianacliente1 = GaranteUtilizadores(bd, "Pedro Gomes", "874024455", new DateTime(1995, 07, 11), "Largo da Oliveira", "918777654", "pedro.gomes@RD-Telecom.com", "4900-003", "Cliente", false, "Viana do Castelo", new DateTime(2020, 08, 05), 0, 16);
            var vianacliente2 = GaranteUtilizadores(bd, "Marlene Pereira", "884995283", new DateTime(1988, 11, 21), "Estrada de Santo António", "965896690", "marlene.pereira@RD-Telecom.com", "4900-006", "Cliente", false, "Viana do Castelo", new DateTime(2020, 10, 05), 0, 16);
            var vianacliente3 = GaranteUtilizadores(bd, "João Ferreira", "863523650", new DateTime(1977, 07, 01), "Largo do Pião", "963555337", "joao.ferreira@RD-Telecom.com", "4900-102", "Cliente", false, "Viana do Castelo", new DateTime(2020, 11, 05), 0, 16);
            var vianacliente4 = GaranteUtilizadores(bd, "Tânia Sousa", "896105300", new DateTime(1969, 06, 06), "Rua Paula Ferreira", "967520333", "tania-sousa@RD-Telecom.com", "4900-862", "Cliente", false, "Viana do Castelo", new DateTime(2020, 09, 05), 0, 16);
            var vianacliente5 = GaranteUtilizadores(bd, "Rute Martins", "836156277", new DateTime(1979, 10, 30), "Rua de São Pedro de Areosa", "923552252", "rute.martins@RD-Telecom.com", "4900-902", "Cliente", false, "Viana do Castelo", new DateTime(2021, 01, 05), 0, 16);
            var vianacliente6 = GaranteUtilizadores(bd, "Luís Bernardo", "856393940", new DateTime(2000, 07, 16), "Travessa dos Sobreiros", "934777723", "luis.bernardo@RD-Telecom.com", "4900-914", "Cliente", false, "Viana do Castelo", new DateTime(2021, 02, 05), 0, 16);
            var vianacliente7 = GaranteUtilizadores(bd, "Helder Vicente", "814819974", new DateTime(1999, 07, 17), "Rua de Monserrate", "966555112", "helder.vicente@RD-Telecom.com", "4904-859", "Cliente", false, "Viana do Castelo", new DateTime(2020, 11, 17), 0, 16);
            var vianacliente8 = GaranteUtilizadores(bd, "António Santos", "892848677", new DateTime(2001, 05, 01), "Rua Pedro Homem de Melo", "963322259", "antonio.santos@RD-Telecom.com", "4904-861", "Cliente", false, "Viana do Castelo", new DateTime(2020, 09, 28), 0, 16);
            var vianacliente9 = GaranteUtilizadores(bd, "Célia Pimento", "803570180", new DateTime(1980, 09, 11), "Rua Santiago da Barra", "923696007", "celia.pimento@RD-Telecom.com", "4904-882", "Cliente", false, "Viana do Castelo", new DateTime(2020, 08, 30), 0, 16);
            var vianacliente10 = GaranteUtilizadores(bd, "Paulo Feliz", "828853312", new DateTime(1975, 02, 08), "Estrada de Santa Luzia", "911111033", "paulo.feliz@RD-Telecom.com", "4904-858", "Cliente", false, "Viana do Castelo", new DateTime(2020, 10, 14), 0, 16);
            var vianacliente11 = GaranteUtilizadores(bd, "Joaquim Guerra", "823701514", new DateTime(1959, 08, 24), "Avenida Capitão Gaspar de Castro", "965333311", "joaquim.guerra@RD-Telecom.com", "4904-873", "Cliente", false, "Viana do Castelo", new DateTime(2020, 12, 17), 0, 16);
            var vianacliente12 = GaranteUtilizadores(bd, "Afonso Freira", "870545140", new DateTime(1956, 07, 26), "Monterrão", "932654877", "afonso.freira@RD-Telecom.com", "4940-003", "Cliente", false, "Viana do Castelo", new DateTime(2020, 10, 13), 0, 16);

            //    //-------------------------- 17 VILA REAL-----------------
            var vilarealcliente1 = GaranteUtilizadores(bd, "Patrícia Avillar", "866085220", new DateTime(2001, 09, 01), "Passagem", "966999985", "patricia.avillar@RD-Telecom.com", "5000-004", "Cliente", false, "Vila Real", new DateTime(2020, 08, 05), 0, 17);
            var vilarealcliente2 = GaranteUtilizadores(bd, "Marlene Pacheco", "867120487", new DateTime(1988, 12, 21), "Cabana", "932000120", "marlene.pacheco@RD-Telecom.com", "5000-008", "Cliente", false, "Vila Real", new DateTime(2020, 10, 05), 0, 17);
            var vilarealcliente3 = GaranteUtilizadores(bd, "Filipe Ferreira", "838298222", new DateTime(1975, 08, 01), " Camatoga", "925889950", "filipe.ferreira@RD-Telecom.com", "5040-001", "Cliente", false, "Vila Real", new DateTime(2020, 08, 27), 0, 17);
            var vilarealcliente4 = GaranteUtilizadores(bd, "Bruna Sousa", "833248723", new DateTime(1969, 04, 06), "Porto Rei", "920025992", "bruna.sousa@RD-Telecom.com", "5040-117", "Cliente", false, "Vila Real", new DateTime(2020, 08, 28), 0, 17);
            var vilarealcliente5 = GaranteUtilizadores(bd, "António Martins", "811951200", new DateTime(1985, 10, 30), "Covinhas", "96777025", "antonio.martins@RD-Telecom.com", "5050-103", "Cliente", false, "Vila Real", new DateTime(2020, 10, 05), 0, 17);
            var vilarealcliente6 = GaranteUtilizadores(bd, "Inês Silva", "816333076", new DateTime(1973, 07, 01), "Salgueiral", "927771003", "ines.silva@RD-Telecom.com", "5050-007", "Cliente", false, "Vila Real", new DateTime(2020, 11, 05), 0, 17);
            var vilarealcliente7 = GaranteUtilizadores(bd, "Pedro Andrade", "846489538", new DateTime(2001, 07, 11), "Rua da Barreira", "925644585", "pedro.andrade@RD-Telecom.com", "5070-003", "Cliente", false, "Vila Real", new DateTime(2021, 01, 05), 0, 17);
            var vilarealcliente8 = GaranteUtilizadores(bd, "Vanessa Monteiro", "891658122", new DateTime(1976, 01, 01), "Rua da Ponte Nova", "963233668", "vanessa.monteiro@RD-Telecom.com", "5070-003", "Cliente", false, "Vila Real", new DateTime(2020, 12, 05), 0, 17);
            var vilarealcliente9 = GaranteUtilizadores(bd, "Manuela Fonseca", "800463919", new DateTime(1995, 09, 11), "Rua Amadeu Necho", "925626922", "manuela.fonseca@RD-Telecom.com", "5070-008", "Cliente", false, "Vila Real", new DateTime(2020, 08, 19), 0, 17);
            var vilarealcliente10 = GaranteUtilizadores(bd, "Kelvin Antunes", "822729687", new DateTime(1987, 02, 11), "Estrada Municipal", "962002025", "kelvin.antunes@RD-Telecom.com", "5070-173", "Cliente", false, "Vila Real", new DateTime(2020, 08, 27), 0, 17);
            var vilarealcliente11 = GaranteUtilizadores(bd, "Rita Godinho", "884984958", new DateTime(1966, 10, 24), "Porto Rei", "923690101", "rita.godinho@RD-Telecom.com", "5040-117", "Cliente", false, "Vila Real", new DateTime(2020, 08, 01), 0, 17);
            var vilarealcliente12 = GaranteUtilizadores(bd, "Bernardo Marques", "894369750", new DateTime(1958, 09, 05), "Povoação", "938899227", "bernardo.marques@RD-Telecom.com", "5040-295", "Cliente", false, "Vila Real", new DateTime(2020, 11, 05), 0, 17);

            //    //-------------------------- 18 VISEU-----------------
            var viseucliente1 = GaranteUtilizadores(bd, "Paula Gomes", "847487059", new DateTime(2000, 06, 11), "Beco do Areal", "965416300", "paula.gomes@RD-Telecom.com", "3430-505", "Cliente", false, "Viseu", new DateTime(2021, 02, 05), 0, 18);
            var viseucliente2 = GaranteUtilizadores(bd, "Marlene Santinho", "899136206", new DateTime(1988, 07, 09), "Avenida Madre Rita Amada de Jesus", "928321888", "marlene.santinho@RD-Telecom.com", "3500-179", "Cliente", false, "Viseu", new DateTime(2021, 01, 05), 0, 18);
            var viseucliente3 = GaranteUtilizadores(bd, "João Monteiro", "864420773", new DateTime(1986, 03, 01), "Rua Nova Jugueiros", "965658448", "joao.monteiro@RD-Telecom.com", "3500-003", "Cliente", false, "Viseu", new DateTime(2020, 08, 05), 0, 18);
            var viseucliente4 = GaranteUtilizadores(bd, "Tânia Laranjo", "897727509", new DateTime(1969, 09, 06), "Rua Imaculado Coração de Maria", "932339632", "tania.laranjo@RD-Telecom.com", "3500-236", "Cliente", false, "Viseu", new DateTime(2020, 10, 05), 0, 18);
            var viseucliente5 = GaranteUtilizadores(bd, "Anabela Moreria", "830646272", new DateTime(1964, 10, 23), "Rua 31 de Janeiro", "933332005", "anabela.moreira@RD-Telecom.com", "3500-217", "Cliente", false, "Viseu", new DateTime(2020, 12, 05), 0, 18);
            var viseucliente6 = GaranteUtilizadores(bd, "Bruno Fernandes", "859511839", new DateTime(1999, 07, 24), "Rua Viscondessa de São Caetano", "910220008", "bruno.fernandes@RD-Telecom.com", "3500-185", "Cliente", false, "Viseu", new DateTime(2021, 02, 12), 0, 18);
            var viseucliente7 = GaranteUtilizadores(bd, "Bruno Nogueira", "831822546", new DateTime(1999, 06, 21), "Rua do Hospital", "923333318", "bruno.nogueira@RD-Telecom.com", "3500-161", "Cliente", false, "Viseu", new DateTime(2021, 01, 17), 0, 18);
            var viseucliente8 = GaranteUtilizadores(bd, "Ana Gomes", "818443383", new DateTime(2000, 01, 28), "Estrada Nacional 16", "968498749", "ana.gomes@RD-Telecom.com", "3519-002", "Cliente", false, "Viseu", new DateTime(2020, 11, 28), 0, 18);
            var viseucliente9 = GaranteUtilizadores(bd, "Rita Rocha", "858391015", new DateTime(1984, 09, 11), "Cadraço", "920006552", "rita.rocha@RD-Telecom.com", "3475-003", "Cliente", false, "Viseu", new DateTime(2020, 10, 25), 0, 18);
            var viseucliente10 = GaranteUtilizadores(bd, "Joana Dias", "815841531", new DateTime(1987, 02, 08), "Pedrogão", "921336668", "joana.dias@RD-Telecom.com", "3475-004", "Cliente", false, "Viseu", new DateTime(2020, 12, 17), 0, 18);
            var viseucliente11 = GaranteUtilizadores(bd, "Maria Bastos", "868745251", new DateTime(1960, 07, 24), "Abóboda", "914444255", "maria.bastos@RD-Telecom.com", "3475-007", "Cliente", false, "Viseu", new DateTime(2020, 11, 09), 0, 18);
            var viseucliente12 = GaranteUtilizadores(bd, "Luís Neto", "871557380", new DateTime(1979, 10, 05), "Rua Doutor Sebastião Alcantara", "937193333", "luis.neto@RD-Telecom.com", "3534-002", "Cliente", false, "Viseu", new DateTime(2021, 03, 14), 0, 18);

            //    //-------------------------- 19 AÇORES-----------------
            var acorescliente1 = GaranteUtilizadores(bd, "Paula Mendes", "885803973", new DateTime(2000, 06, 01), "À Fonseca ", "930001114", "paula.mendes@RD-Telecom.com", "9700-302", "Cliente", false, "Açores", new DateTime(2020, 07, 01), 0, 19);
            var acorescliente2 = GaranteUtilizadores(bd, "Joana Santos", "802477259", new DateTime(1989, 11, 11), "Outeiro de São Mateus", "968880005", "joana.santos@RD-Telecom.com", "9700-305", "Cliente", false, "Açores", new DateTime(2021, 01, 01), 0, 19);
            var acorescliente3 = GaranteUtilizadores(bd, "Pedro Ferreira", "807758604", new DateTime(1974, 07, 01), "Presas", "963332008", "pedro.ferreira@RD-Telecom.com", "9700-308", "Cliente", false, "Açores", new DateTime(2020, 09, 01), 0, 19);
            var acorescliente4 = GaranteUtilizadores(bd, "Fernanda Sousa", "892395559", new DateTime(1969, 08, 06), "Rua Nova", "961322298", "Fernanda.sousa@RD-Telecom.com", "9700-132", "Cliente", false, "Açores", new DateTime(2020, 12, 10), 0, 19);
            var acorescliente5 = GaranteUtilizadores(bd, "Rita Martins", "898142938", new DateTime(1979, 11, 30), "Praça Doutor Sousa Júnior ", "938888789", "rita.martins@RD-Telecom.com", "9700-007", "Cliente", false, "Açores", new DateTime(2020, 10, 11), 0, 19);
            var acorescliente6 = GaranteUtilizadores(bd, "João Patrício", "863866247", new DateTime(2001, 07, 01), "Abaixo do Fragoso", "965811111", "joao.patricio@RD-Telecom.com", "9880-101", "Cliente", false, "Açores", new DateTime(2020, 12, 28), 0, 19);
            var acorescliente7 = GaranteUtilizadores(bd, "Helder Machado", "803990936", new DateTime(1999, 07, 01), "Bairro do Carrapacho", "915235555", "Helder.machado@RD-Telecom.com", "9880-120", "Cliente", false, "Açores", new DateTime(2020, 11, 01), 0, 19);
            var acorescliente8 = GaranteUtilizadores(bd, "Luís Falcão", "809441578", new DateTime(2000, 11, 01), "Bacelo", "925871444", "miriam.falcao@RD-Telecom.com", "9880-103", "Cliente", false, "Açores", new DateTime(2020, 07, 16), 0, 19);
            var acorescliente9 = GaranteUtilizadores(bd, "Vanessa Ribeiro", "862023769", new DateTime(1980, 09, 11), "Avenida Mousinho de Albuquerque", "926557999", "vanessa.ribeiro@RD-Telecom.com", "9880-999", "Cliente", false, "Açores", new DateTime(2020, 09, 21), 0, 19);
            var acorescliente10 = GaranteUtilizadores(bd, "Rafael Leão", "846019183", new DateTime(1975, 02, 24), "Pedras Brancas", "961733331", "rafael.leao@RD-Telecom.com", "9880-171", "Cliente", false, "Açores", new DateTime(2020, 09, 05), 0, 19);
            var acorescliente11 = GaranteUtilizadores(bd, "Célia Francisca", "851087574", new DateTime(1955, 08, 24), "Fajã da Isabel Pereira", "911111821", "celia.francisca@RD-Telecom.com", "9800-101", "Cliente", false, "Açores", new DateTime(2020, 10, 01), 0, 19);
            var acorescliente12 = GaranteUtilizadores(bd, "Rita Freira", "851596118", new DateTime(1956, 06, 05), "Ribeira D'Água", "932228541", "rita.freira@RD-Telecom.com", "9800-209", "Cliente", false, "Açores", new DateTime(2021, 02, 05), 0, 19);

            //    //-------------------------- 20 MADEIRA-----------------
            var madeiracliente1 = GaranteUtilizadores(bd, "Patrícia Passarinha", "859762505", new DateTime(2001, 07, 01), "Caminho Ribeira dos Socorridos ", "965388882", "patricia.passarinha@RDtelecom.com", "9000-617", "Cliente", false, "Madeira", new DateTime(2020, 07, 01), 0, 20);
            var madeiracliente2 = GaranteUtilizadores(bd, "Marlene Lavrador", "800551257", new DateTime(1968, 11, 21), "2ª Travessa Caminho Arieiro de Baixo", "938555566", "marlene.Lavrador@RDtelecom.com", "9000-602", "Cliente", false, "Madeira", new DateTime(2020, 08, 01), 0, 20);
            var madeiracliente3 = GaranteUtilizadores(bd, "Petra Fernandes", "893337951", new DateTime(1988, 09, 01), "Azinhaga Vargem", "96872222", "petra.fernandes@RDtelecom.com", "9000-730", "Cliente", false, "Madeira", new DateTime(2021, 01, 01), 0, 20);
            var madeiracliente4 = GaranteUtilizadores(bd, "Vânia Fernandes", "819972525", new DateTime(1969, 07, 06), "Avenida Colégio Militar ", "912330000", "Vania.fernandes@RDtelecom.com", "9000-996", "Cliente", false, "Madeira", new DateTime(2021, 02, 01), 0, 20);
            var madeiracliente5 = GaranteUtilizadores(bd, "Pedro Alves", "848937023", new DateTime(1979, 10, 27), "Beco Virtudes", "927499920", "pedro.alves@RDtelecom.com", "9000-616", "Cliente", false, "Madeira", new DateTime(2020, 09, 21), 0, 20);
            var madeiracliente6 = GaranteUtilizadores(bd, "Patrícia Gomes", "867937785", new DateTime(1999, 09, 24), "Caminho Arieiro", "963337882", "patricia.gomes@RDtelecom.com", "9000-243 ", "Cliente", false, "Madeira", new DateTime(2020, 10, 28), 0, 20);
            var madeiracliente7 = GaranteUtilizadores(bd, "Tiago Prata", "832935352", new DateTime(1999, 07, 18), "Rua Hospital Velho", "924755555", "tiago.prata@RDtelecom.com", "9064-507", "Cliente", false, "Madeira", new DateTime(2020, 11, 28), 0, 20);
            var madeiracliente8 = GaranteUtilizadores(bd, "Paula Falcão", "822757753", new DateTime(2000, 01, 26), "Rua Nova Rochinha", "960147886", "paula.falcao@RDtelecom.com", "9064-509", "Cliente", false, "Madeira", new DateTime(2020, 12, 17), 0, 20);
            var madeiracliente9 = GaranteUtilizadores(bd, "Inês Santos", "808952331", new DateTime(1980, 09, 30), "Travessa Contracta e Corujeira", "969952033", "ines.santos@RDtelecom.com", "9125-003", "Cliente", false, "Madeira", new DateTime(2020, 09, 10), 0, 20);
            var madeiracliente10 = GaranteUtilizadores(bd, "Fábio Martins", "846266369", new DateTime(1975, 02, 10), "Estrada do Garajau Vargem", "960003335", "fabio.martins@RDtelecom.com", "9125-253", "Cliente", false, "Madeira", new DateTime(2021, 02, 10), 0, 20);
            var madeiracliente11 = GaranteUtilizadores(bd, "Jaime Antunes", "895001713", new DateTime(1955, 02, 24), "Rua Abegoaria", "912300067", "jaime.antunes@RDtelecom.com", "9125-122", "Cliente", false, "Madeira", new DateTime(2020, 12, 08), 0, 20);
            var madeiracliente12 = GaranteUtilizadores(bd, "Joaquim Alves", "854852301", new DateTime(1956, 01, 05), "Cruz", "96000025", "joaquim.alves@RDtelecom.com", "9225-007", "Operador", false, "Madeira", new DateTime(2020, 12, 12), 0, 20);

            //-------------------------------OPERADORES---------------------------------------

            //Operadores de Aveiro
            var aveirooperador1 = GaranteUtilizadores(bd, "Eduardo Aveiro", "286714957", new DateTime(2000, 01, 19), "Sargento Mor", "921234567", "eduardo.pires@RDtelecom.com", "3020-740", "Operador", false, "Aveiro", new DateTime(2020, 08, 05), 0, 1);
            var aveirooperador2 = GaranteUtilizadores(bd, "Glória Aveiro", "218120460", new DateTime(1988, 09, 21), "Rua Fernando Caldeira", "937654321", "gloria.ascencao@RDtelecom.com", "3754-501", "Operador", false, "Aveiro", new DateTime(2020, 12, 12), 0, 1);
            var aveirooperador3 = GaranteUtilizadores(bd, "Maria Aveiro", "206602448", new DateTime(1977, 10, 01), "Rua Doutor Tomás Aquino", "927412589", "maria.aparecida@RDtelecom.com", "3800-523", "Operador", false, "Aveiro", new DateTime(2020, 10, 15), 0, 1);
            var aveirooperador4 = GaranteUtilizadores(bd, "Bernardo Aveiro", "292565798", new DateTime(1969, 03, 25), "Avenida Manuel Álvaro Lopes Pereira", "929632587", "bernado.ribeiro@RDtelecom.com", "3800-625", "Operador", false, "Aveiro", new DateTime(2020, 10, 17), 0, 1);
            var aveirooperador5 = GaranteUtilizadores(bd, "Amadeu Aveiro", "292565798", new DateTime(1979, 07, 16), "Avenida do Doutor Lourenço Peixinho", "921212145", "amadeu.almeida@RDtelecom.com", "3804-501", "Operador", false, "Aveiro", new DateTime(2020, 12, 28), 0, 1);
            var aveirooperador6 = GaranteUtilizadores(bd, "José Aveiro", "250559102", new DateTime(1958, 05, 05), "Viela da Capela", "920123201", "jose.socrates@RDtelecom.com", "3810-002", "Operador", false, "Aveiro", new DateTime(2020, 08, 17), 0, 1);
            var aveirooperador7 = GaranteUtilizadores(bd, "Ana Aveiro", "275433641", new DateTime(2000, 09, 04), "Rua do Jardim", "929633230", "ana.brito@RDtelecom.com", "3054-001", "Operador", false, "Aveiro", new DateTime(2020, 08, 19), 0, 1);
            var aveirooperador8 = GaranteUtilizadores(bd, "Luís Aveiro", "142518093", new DateTime(1985, 04, 04), "Avenida Comendador Augusto Martins Pereira", "920258847", "luis.neto@RDtelecom.com", "3744-002", "Operador", false, "Aveiro", new DateTime(2020, 08, 28), 0, 1);
            var aveirooperador9 = GaranteUtilizadores(bd, "Freitas Aveiro", "172501482", new DateTime(1975, 02, 08), "Rua do Murtório Rochico ", "961477784", "freitas.mondego@RDtelecom.com", "3865-299", "Operador", false, "Aveiro", new DateTime(2020, 10, 02), 0, 1);
            var aveirooperador10 = GaranteUtilizadores(bd, "João Aveiro", "265371988", new DateTime(1958, 12, 27), "Travessa da Lomba", "923212322", "joao.cardoso@RDtelecom.com", "3865-003", "Operador", false, "Aveiro", new DateTime(2021, 01, 05), 0, 1); ;
            var aveirooperador11 = GaranteUtilizadores(bd, "Rita Aveiro", "244225834", new DateTime(1956, 08, 27), "Largo 5 de Outubro Jardim dos Campos Pares", "929988774", "rita.brandao@RDtelecom.com", "3880-006", "Operador", false, "Aveiro", new DateTime(2021, 02, 05), 0, 1);
            var aveiroperador12 = GaranteUtilizadores(bd, "Operador", "506719693", new DateTime(2000, 01, 19), "Sargento Mor", "921233389", "operador@RDtelecom.com", "3020-740", "Operador", false, "Aveiro", new DateTime(2020, 08, 05), 0, 1);


            //    //-------------------------- 2 BEJA------------------
            var bejaoperador1 = GaranteUtilizadores(bd, "Ramos RD Beja", "286714957", new DateTime(2001, 01, 19), "Beco da Rua Acima", "963125474", "eduardo.pires@RDtelecom.com", "7960-002", "Operador", false, "Beja", new DateTime(2021, 01, 05), 0, 2);
            var bejaoperador2 = GaranteUtilizadores(bd, "Catarina RD Beja", "218120460", new DateTime(1995, 09, 21), "Marmelar", "932789321", "gloria.ascencao@RDtelecom.com", "7960-001", "Operador", false, "Beja", new DateTime(2020, 10, 17), 0, 2);
            var bejaoperador3 = GaranteUtilizadores(bd, "Rui RD Beja", "206602448", new DateTime(1965, 10, 11), "Rua Longa", "921023951", "maria.aparecida@RDtelecom.com", "7940-160", "Operador", false, "Beja", new DateTime(2020, 10, 25), 0, 2);
            var bejaoperador4 = GaranteUtilizadores(bd, "Vasco RD Beja", "292565798", new DateTime(1962, 02, 25), "Avenida Manuel Álvaro Lopes Pereira", "927406381", "bernado.ribeiro@RDtelecom.com", "3800-625", "Operador", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            var bejaoperador5 = GaranteUtilizadores(bd, "Mário RD Beja", "292565798", new DateTime(1987, 07, 16), "Albergaria dos Fusos", "923148620", "amadeu.almeida@RDtelecom.com", "7940-411", "Operador", false, "Beja", new DateTime(2020, 08, 26), 0, 2);
            var bejaoperador6 = GaranteUtilizadores(bd, "Lula RD Beja", "250559102", new DateTime(1958, 04, 05), "Rua dos Lobos", "932951753", "jose.socrates@RDtelecom.com", "7920-005", "Operador", false, "Beja", new DateTime(2020, 08, 28), 0, 2);
            var bejaoperador7 = GaranteUtilizadores(bd, "Paula RD Beja", "275433641", new DateTime(1992, 09, 04), "Largo dos Cadeirões", "935751153", "ana.brito@RDtelecom.com", "7920-002", "Operador", false, "Beja", new DateTime(2021, 02, 28), 0, 2);
            var bejaoperador8 = GaranteUtilizadores(bd, "Thomas RD Beja", "142518093", new DateTime(1979, 04, 06), "Praça do Ultramar", "928963321", "luis.neto@RDtelecom.com", "7801-857", "Operador", false, "Beja", new DateTime(2020, 10, 28), 0, 2);
            var bejaoperador9 = GaranteUtilizadores(bd, "Luís RD Beja", "172501482", new DateTime(1975, 06, 08), "Moitinhas", "960154784", "freitas.mondego@RDtelecom.com", "7665-803", "Operador", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            var bejaoperador10 = GaranteUtilizadores(bd, "Márcia RD Beja", "265371988", new DateTime(1972, 11, 27), "Ribeira de Torquinhos", "921789321", "joao.cardoso@RDtelecom.com", "7665-814", "Operador", false, "Beja", new DateTime(2020, 12, 05), 0, 2);
            var bejaoperador11 = GaranteUtilizadores(bd, "Jerónimo RD Beja", "244225834", new DateTime(1956, 05, 22), "Rua da Cova da Burra", "928032965", "rita.brandao@RDtelecom.com", "7700-003", "Operador", false, "Beja", new DateTime(2021, 01, 05), 0, 2);

            //    //-------------------------- 3 BRAGA------------------
            var bragaoperador1 = GaranteUtilizadores(bd, "Fernando RD Braga", "239833252", new DateTime(1977, 03, 19), "Rua dos Bombeiros Voluntários", "960023231", "fernado.couto@RDtelecom.com", "4700-002", "Operador", false, "Braga", new DateTime(2020, 12, 05), 0, 3);
            var bragaoperador2 = GaranteUtilizadores(bd, "Deolinda RD Braga", "292716222", new DateTime(2001, 05, 21), "Rua Professora Alda Brandão Real", "933584787", "deolinda.bacalhau@RDtelecom.com", "4700-002", "Operador", false, "Braga", new DateTime(2020, 11, 17), 0, 3);
            var bragaoperador3 = GaranteUtilizadores(bd, "Ivanilda RD Braga", "206870523", new DateTime(1977, 08, 01), "Rua da Sobreira Frossos", "923001221", "ivanilda.pessoa@RDtelecom.com", "4700-441", "Operador", false, "Braga", new DateTime(2020, 12, 26), 0, 3);
            var bragaoperador4 = GaranteUtilizadores(bd, "Onofre RD Braga", "267894422", new DateTime(1969, 04, 30), "Largo de Maximinos", "928976413", "onofre.galvao@RDtelecom.com", "4700-999", "Operador", false, "Braga", new DateTime(2020, 12, 10), 0, 3);
            var bragaoperador5 = GaranteUtilizadores(bd, "Ian RD Braga", "249703238", new DateTime(2002, 01, 31), "Largo de São Tiago", "92587963", "ian.coelho@RDtelecom.com", "4704-504", "Operador", false, "Braga", new DateTime(2020, 11, 05), 0, 3);
            var bragaoperador6 = GaranteUtilizadores(bd, "Ryan RD Braga", "240442571", new DateTime(1988, 03, 05), "Rua das Oliveiras", "920322333", "ryan.oliveira@RDtelecom.com", "4705-790", "Operador", false, "Braga", new DateTime(2020, 11, 28), 0, 3);
            var bragaoperador7 = GaranteUtilizadores(bd, "Marizete RD Braga", "285368559", new DateTime(1956, 10, 04), "Rua dos Caixoteiros", "922001789", "marizete.gillot@RDtelecom.com", "4705-001", "Operador", false, "Braga", new DateTime(2020, 10, 07), 0, 3);
            var bragaoperador8 = GaranteUtilizadores(bd, "Beto da RD Braga", "249227673", new DateTime(1957, 03, 17), "Rua Sem Nome", "925567841", "beto.alegria@RDtelecom.com", "4750-008", "Operador", false, "Braga", new DateTime(2021, 01, 05), 0, 3);
            var bragaoperador9 = GaranteUtilizadores(bd, "Pinheiro RD Braga", "273654888", new DateTime(1970, 02, 28), "Travessa do Rio da Guarda", "921003288", "pinheiro.santos@RDtelecom.com", "4765-489", "Operador", false, "Braga", new DateTime(2021, 02, 05), 0, 3);
            var bragaoperador10 = GaranteUtilizadores(bd, "Divina RD Braga", "268345139", new DateTime(1958, 11, 30), "Rua Cães de Pedra Lt 5", "921785432", "divina.jesus@RDtelecom.com", "4835-003", "Operador", false, "Braga", new DateTime(2021, 02, 12), 0, 3);
            var bragaoperador11 = GaranteUtilizadores(bd, "Irina RD Braga", "263696340", new DateTime(1999, 10, 27), "Rua da Madalena", "929633600", "irina.leite@RDtelecom.com", "4835-511", "Operador", false, "Braga", new DateTime(2021, 01, 14), 0, 3);

            //    //-------------------------- 4 BRAGANÇA------------------
            var bragancaoperador1 = GaranteUtilizadores(bd, "Natally RD Bragança", "239833252", new DateTime(1974, 06, 19), "Bairro Moinho de Vento", "939007258", "natally.domingues@RDtelecom.com", "5140-005", "Operador", false, "Bragança", new DateTime(2020, 11, 13), 0, 4);
            var bragancaoperador2 = GaranteUtilizadores(bd, "Nicolau RD Bragança", "292716222", new DateTime(2001, 01, 21), "Quinta Lameira de Ferro", "932101491", "nicolau.figueiras@RDtelecom.com", "5140-135", "Operador", false, "Bragança", new DateTime(2020, 10, 27), 0, 4);
            var bragancaoperador3 = GaranteUtilizadores(bd, "John RD Bragança", "206870523", new DateTime(1987, 09, 03), "Rua Sem Nome 218 Bairro Além do Rio ", "966852031", "john.dias@RDtelecom.com", "5300-001", "Operador", false, "Bragança", new DateTime(2020, 10, 25), 0, 4);
            var bragancaoperador4 = GaranteUtilizadores(bd, "Maria RD Bragança", "267894422", new DateTime(1969, 09, 30), "Rua da Fragata", "923455896", "maria.leal@RDtelecom.com", "5385-101", "Operador", false, "Bragança", new DateTime(2020, 11, 12), 0, 4);
            var bragancaoperador5 = GaranteUtilizadores(bd, "Isabel RD Bragança", "249703238", new DateTime(1957, 05, 31), "Valbom Pitez", "922788996", "isabel.santinhos@RDtelecom.com", "5385-132", "Operador", false, "Bragança", new DateTime(2020, 12, 07), 0, 4);
            var bragancaoperador6 = GaranteUtilizadores(bd, "Rui RD Bragança", "240442571", new DateTime(1988, 03, 07), "Azenha do Areal", "920335411", "rui.fragona@RDtelecom.com", "5370-131", "Operador", false, "Bragança", new DateTime(2020, 12, 18), 0, 4);
            var bragancaoperador7 = GaranteUtilizadores(bd, "Dunildo RD Bragança", "285368559", new DateTime(2000, 10, 04), "Vale de Lobo", "929693914", "dunildo.esperanca@RDtelecom.com", "5370-102", "Operador", false, "Bragança", new DateTime(2020, 12, 24), 0, 4);
            var bragancaoperador8 = GaranteUtilizadores(bd, "Carla RD Bragança", "249227673", new DateTime(1995, 08, 17), "Vilar Seco", "963321087", "carla.dorys@RDtelecom.com", "5350-204", "Operador", false, "Bragança", new DateTime(2020, 10, 05), 0, 4);
            var bragancaoperador9 = GaranteUtilizadores(bd, "Birna RD Bragança", "273654888", new DateTime(1980, 02, 28), "Rua dos Combatentes da Grande Guerra", "930147852", "birna.oliveira@RDtelecom.com", "5301-861", "Operador", false, "Bragança", new DateTime(2021, 03, 05), 0, 4);
            var bragancaoperador10 = GaranteUtilizadores(bd, "João RD Bragança", "268345139", new DateTime(1966, 11, 30), "Rua Cova da Beira", "926698230", "joao.salgado@RDtelecom.com", "5300-869", "Operador", false, "Bragança", new DateTime(2021, 01, 05), 0, 4);
            var bragancaoperador11 = GaranteUtilizadores(bd, "Feitosa RD Bragança", "263696340", new DateTime(1972, 10, 27), "Rotunda do Lavrador Bairro da Braguinha ", "921033025", "feitosa.pauleta@RDtelecom.com", "5300-420", "Operador", false, "Bragança", new DateTime(2021, 02, 21), 0, 4);

            //    //-------------------------- 5 CASTELO BRANCO------------------
            var castelobrancooperador1 = GaranteUtilizadores(bd, "Cláudia RD Castelo Branco", "195173210", new DateTime(1965, 06, 19), "Rua das Rosas", "933896541", "claudia.vieira@RDtelecom.com", "6250-004", "Operador", false, "Castelo Branco", new DateTime(2020, 10, 11), 0, 5);
            var castelobrancooperador2 = GaranteUtilizadores(bd, "Diogo RD Castelo Branco", "136693199", new DateTime(1999, 01, 21), "Sítio do Cabecinho", "937258852", "diogo.andrade@RDtelecom.com", "6250-111", "Operador", false, "Castelo Branco", new DateTime(2020, 09, 05), 0, 5);
            var castelobrancooperador3 = GaranteUtilizadores(bd, "Maria RD Castelo Branco", "116663987", new DateTime(1988, 02, 03), "Quinta de Valverdinho", "963012547", "maria.ruah@RDtelecom.com", "6250-163", "Operador", false, "Castelo Branco", new DateTime(2020, 11, 03), 0, 5);
            var castelobrancooperador4 = GaranteUtilizadores(bd, "Florbela RD Castelo Branco", "127533818", new DateTime(1980, 09, 30), "Rua do Curral", "922013645", "florbela.antunes@RDtelecom.com", "6215-001", "Operador", false, "Castelo Branco", new DateTime(2020, 11, 20), 0, 5);
            var castelobrancooperador5 = GaranteUtilizadores(bd, "António RD Castelo Branco", "111712580", new DateTime(1974, 05, 31), "Rua Marquês de Ávila e Bolama", "928328961", "antonio.antunes@RDtelecom.com", "6201-001", "Operador", false, "Castelo Branco", new DateTime(2020, 12, 22), 0, 5);
            var castelobrancooperador6 = GaranteUtilizadores(bd, "Liliana RD Castelo Branco", "183191404", new DateTime(2000, 03, 07), "Viela do Castelo", "927031759", "liliana.aveiro@RDtelecom.com", "6200-227", "Operador", false, "Castelo Branco", new DateTime(2020, 11, 18), 0, 5);
            var castelobrancooperador8 = GaranteUtilizadores(bd, "Maria RD Castelo Branco", "161954464", new DateTime(2000, 10, 04), "Travessa das Trapas", "924630158", "maria.pedroso@RDtelecom.com", "6200-237", "Operador", false, "Castelo Branco", new DateTime(2020, 11, 17), 0, 5);
            var castelobrancooperador9 = GaranteUtilizadores(bd, "Pedro RD Castelo Branco", "182518434", new DateTime(1957, 08, 17), "Bairro da Formiguinha Vila do Carvalho", "966332157", "pedro.fernandes@RDtelecom.com", "6200-241", "Operador", false, "Castelo Branco", new DateTime(2021, 01, 13), 0, 5);
            var castelobrancooperador10 = GaranteUtilizadores(bd, "Miguel RD Castelo Branco", "145814360", new DateTime(1962, 02, 28), "Rua das Tendas", "933212269", "miguel.moniz@RDtelecom.com", "6200-699", "Operador", false, "Castelo Branco", new DateTime(2020, 11, 11), 0, 5);
            var castelobrancooperador11 = GaranteUtilizadores(bd, "Felisberto RD Castelo Branco", "114162123", new DateTime(1971, 02, 28), "Travessa dos Escabelados", "922100366", "felisberto.ortiz@RDtelecom.com", "6200-742", "Operador", false, "Castelo Branco", new DateTime(2021, 02, 20), 0, 5);
            var castelobrancooperador12 = GaranteUtilizadores(bd, "António RD Castelo Branco", "163492115", new DateTime(1976, 11, 27), "Rua Canada", "925644710", "antonio.sanchez@RDtelecom.com", "6005-002", "Operador", false, "Castelo Branco", new DateTime(2021, 01, 13), 0, 5);

            //    //-------------------------- 6 COIMBRA-----------------
            var coimbraoperador1 = GaranteUtilizadores(bd, "Patrícia Coimbra RD", "248858939", new DateTime(1999, 07, 01), "Rua do Norte", "929188821", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, "Coimbra", new DateTime(2020, 10, 05), 0, 6);
            var coimbraoperador2 = GaranteUtilizadores(bd, "Marlene Coimbra RD", "123456789", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "933298771", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, "Coimbra", new DateTime(2020, 12, 01), 0, 6);
            var coimbraoperador3 = GaranteUtilizadores(bd, "João Coimbra RD", "233333231", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "929155551", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, "Coimbra", new DateTime(2020, 11, 26), 0, 6);
            var coimbraoperador4 = GaranteUtilizadores(bd, "Tânia Coimbra RD", "233259627", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "927854121", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, "Coimbra", new DateTime(2020, 10, 27), 0, 6);
            var coimbraoperador5 = GaranteUtilizadores(bd, "Rute Coimbra RD", "221639896", new DateTime(1979, 10, 30), "Cruz de Ferro", "929154199", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, "Coimbra", new DateTime(2020, 09, 25), 0, 6);
            var coimbraoperador6 = GaranteUtilizadores(bd, "Paulo Coimbra RD", "215922158", new DateTime(1999, 07, 01), "Rua do Norte", "929155501", "paulo.pedra@RDtelecom.com", "3000-295", "Operador", false, "Coimbra", new DateTime(2020, 10, 11), 0, 6);
            var coimbraoperador7 = GaranteUtilizadores(bd, "Helder Coimbra RD", "209281472", new DateTime(1999, 07, 01), "Rua do Norte", "929157411", "helder.copeto@RDtelecom.com", "3000-295", "Operador", false, "Coimbra", new DateTime(2020, 10, 11), 0, 6);
            var coimbraoperador8 = GaranteUtilizadores(bd, "Miriam Coimbra RD", "218052421", new DateTime(2000, 01, 01), "Vale Derradeiro", "929159871", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, "Coimbra", new DateTime(2020, 10, 11), 0, 6);
            var coimbraoperador9 = GaranteUtilizadores(bd, "Célia Coimbra RD", "224046284", new DateTime(1980, 09, 11), "Seladinhas", "929199991", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, "Coimbra", new DateTime(2021, 02, 18), 0, 6);
            var coimbraoperador10 = GaranteUtilizadores(bd, "Tadeu Coimbra RD", "294178775", new DateTime(1975, 02, 08), "Flor da Rosa", "929100021", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, "Coimbra", new DateTime(2021, 03, 11), 0, 6);
            var coimbraoperador11 = GaranteUtilizadores(bd, "Harley Coimbra RD", "230936679", new DateTime(1955, 12, 24), "Beco da Alegria", "929004121", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, "Coimbra", new DateTime(2021, 02, 20), 0, 6);
            var coimbraoperador12 = GaranteUtilizadores(bd, "Afonso Coimbra RD", "271671130", new DateTime(1956, 12, 05), "Beco das Cruzes", "929154555", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, "Coimbra", new DateTime(2021, 01, 11), 0, 6);


            //    //-------------------------- 7 EVORA-----------------
            var evoraoperador1 = GaranteUtilizadores(bd, "Andreia RD Évora", "238122549", new DateTime(2001, 07, 01), "Vale de Pegas", "921456654", "andreia.alves@RDtelecom.com", "7490-120", "Operador", false, "Évora", new DateTime(2020, 10, 17), 0, 7);
            var evoraoperador2 = GaranteUtilizadores(bd, "João RD Évora", "270613994", new DateTime(1999, 11, 21), "Rua João de Deus", "936825714", "joao.correia@RDtelecom.com", "7250-142", "Operador", false, "Évora", new DateTime(2020, 09, 28), 0, 7);
            var evoraoperador3 = GaranteUtilizadores(bd, "Ricardo RD Évora", "205118615", new DateTime(1975, 07, 01), "Rua da Liberdade", "920147963", "ricardo.gama@RDtelecom.com", "7220-002", "Operador", false, "Évora", new DateTime(2020, 09, 26), 0, 7);
            var evoraoperador4 = GaranteUtilizadores(bd, "Inês RD Évora", "278968724", new DateTime(1969, 06, 08), "Rua dos Irmãos", "927369148", "ines.castro@RDtelecom.com", "7220-003", "Operador", false, "Évora", new DateTime(2020, 11, 13), 0, 7);
            var evoraoperador5 = GaranteUtilizadores(bd, "Andressa RD Évora", "220236410", new DateTime(1962, 03, 30), "Praceta do Brasil", "928741147", "andressa.ribeiro@RDtelecom.com", "7200-479", "Operador", false, "Évora", new DateTime(2020, 11, 07), 0, 7);
            var evoraoperador6 = GaranteUtilizadores(bd, "Pablo RD Évora", "201957060", new DateTime(1980, 07, 01), "Rua Projectada à Avenida Tomás Alcaide", "926951753", "pablo.abrunhosa@RDtelecom.com", "7100-130", "Operador", false, "Évora", new DateTime(2020, 11, 05), 0, 7);
            var evoraoperador7 = GaranteUtilizadores(bd, "Ramon RD Évora", "246386339", new DateTime(1999, 07, 01), "Travessa das Amendoeiras", "920147895", "ramon.marques@RDtelecom.com", "7090-006", "Operador", false, "Évora", new DateTime(2020, 10, 03), 0, 7);
            var evoraoperador8 = GaranteUtilizadores(bd, "Mariana RD Évora", "269577556", new DateTime(1999, 01, 01), "Bairro Ferragolo", "922333698", "mariana.serenidade@RDtelecom.com", "7080-109", "Operador", false, "Évora", new DateTime(2020, 11, 26), 0, 7);
            var evoraoperador9 = GaranteUtilizadores(bd, "Dilma RD Évora", "253854040", new DateTime(1958, 09, 21), "Casa de Pau", "920032147", "dilma.rosas@RDtelecom.com", "7050-634", "Operador", false, "Évora", new DateTime(2020, 11, 26), 0, 7);
            var evoraoperador10 = GaranteUtilizadores(bd, "Vicente RD Évora", "281567182", new DateTime(1965, 02, 08), "Largo das Alterações", "931456321", "vicente.silva@RDtelecom.com", "7000-502", "Operador", false, "Évora", new DateTime(2021, 01, 26), 0, 7); ;
            var evoraoperador11 = GaranteUtilizadores(bd, "Flascotter RD Évora", "286365723", new DateTime(1995, 03, 24), "Rua Francisco Soares Lusitano", "966333210", "flascotter.pereira@RDtelecom.com", "7004-511", "Operador", false, "Évora", new DateTime(2021, 01, 26), 0, 7);
            var evoraoperador12 = GaranteUtilizadores(bd, "Sara RD Évora", "278661610", new DateTime(1956, 05, 05), "Largo dos Colegiais 2", "933225871", "sara.moedas@RDtelecom.com", "7004-516", "Operador", false, "Évora", new DateTime(2021, 02, 26), 0, 7);

            //    //-------------------------- 8 FARO-----------------
            var farooperador1 = GaranteUtilizadores(bd, "Miguel RD Faro", "298933896", new DateTime(1999, 07, 01), "Rua da Viola ", "925874100", "miguel.rossi@RDtelecom.com", "8000-274", "Operador", false, "Faro", new DateTime(2020, 12, 28), 0, 8);
            var farooperador2 = GaranteUtilizadores(bd, "Martina RD Faro", "290825091", new DateTime(1988, 11, 21), "Rua do Bocage", "933302145", "martina.castilho@RDtelecom.com", "8004-002", "Operador", false, "Faro", new DateTime(2020, 12, 06), 0, 8);
            var farooperador3 = GaranteUtilizadores(bd, "Romeo RD Faro", "256438676", new DateTime(1978, 07, 01), "Areal Gordo", "932587410", "romeo.ximenes@RDtelecom.com", "8005-409", "Operador", false, "Faro", new DateTime(2020, 11, 17), 0, 8);
            var farooperador4 = GaranteUtilizadores(bd, "John RD Faro", "200101447", new DateTime(1969, 06, 06), "Travessa do Borrego", "933666520", "john.pitt@RDtelecom.com", "8125-002", "Operador", false, "Faro", new DateTime(2020, 09, 17), 0, 8);
            var farooperador5 = GaranteUtilizadores(bd, "Zézinho RD Faro", "213627736", new DateTime(1979, 10, 30), "Beco das Palmeiras", "921230002", "zezinho.camarrinha@RDtelecom.com", "8125-609", "Operador", false, "Faro", new DateTime(2020, 10, 19), 0, 8);
            var farooperador6 = GaranteUtilizadores(bd, "Luna RD Faro", "254704085", new DateTime(1999, 07, 01), "Beco Condestável", "925666417", "luna.smith@RDtelecom.com", "8125-636", "Operador", false, "Faro", new DateTime(2020, 10, 27), 0, 8);
            var farooperador7 = GaranteUtilizadores(bd, "Luísa RD Faro", "261746227", new DateTime(1999, 06, 01), "Beco dos Bitas", "936254102", "luisa.salvador@RDtelecom.com", "8200-002", "Operador", false, "Faro", new DateTime(2020, 10, 26), 0, 8);
            var farooperador8 = GaranteUtilizadores(bd, "Ana RD Faro", "255512546", new DateTime(2000, 01, 01), "Rua das Telecomunicações", "920320001", "ana.cacho@RDtelecom.com", "8201-871", "Operador", false, "Faro", new DateTime(2020, 11, 17), 0, 8);
            var farooperador9 = GaranteUtilizadores(bd, "Fernando RD Faro", "203265424", new DateTime(1980, 09, 11), "Caminho Municipal", "967369874", "fernando.rock@RDtelecom.com", "8201-877", "Operador", false, "Faro", new DateTime(2021, 03, 17), 0, 8);
            var farooperador10 = GaranteUtilizadores(bd, "Miguel RD Faro", "299944611", new DateTime(1975, 02, 08), "Avenida dos Descobrimentos", "921321111", "miguel.feliz@RDtelecom.com", "8601-852", "Operador", false, "Faro", new DateTime(2021, 02, 17), 0, 8);
            var farooperador11 = GaranteUtilizadores(bd, "Maria RD Faro", "226395324", new DateTime(1955, 12, 24), "Rua 25 de Abril", "917854123", "maria.ferrari@RDtelecom.com", "8801-005", "Operador", false, "Faro", new DateTime(2021, 01, 28), 0, 8);
            var farooperador12 = GaranteUtilizadores(bd, "Bruno RD Faro", "231898975", new DateTime(1956, 12, 05), "Monte Olimpio", "917364825", "bruno.pereira@RDtelecom.com", "8900-106", "Operador", false, "Faro", new DateTime(2021, 01, 15), 0, 8);


            //    //-------------------------- 9 GUARDA-----------------
            var guardaoperador1 = GaranteUtilizadores(bd, "Alicia RD Guarda", "240315170", new DateTime(1988, 07, 01), "Ponte do Abade", "926999852", "alicia.sancho@RDtelecom.com", "3570-191", "Operador", false, "Guarda", new DateTime(2020, 11, 03), 0, 9);
            var guardaoperador2 = GaranteUtilizadores(bd, "Mateo RD Guarda", "216994918", new DateTime(1964, 11, 21), "Rua Quebra Costas", "933022589", "mateo.jesus@RDtelecom.com", "5155-003", "Operador", false, "Guarda", new DateTime(2020, 10, 18), 0, 9);
            var guardaoperador3 = GaranteUtilizadores(bd, "Antonnella RD Guarda", "262339374", new DateTime(1954, 08, 01), "Zurrão", "922557410", "antonnella.conti@RDtelecom.com", "6260-196", "Operador", false, "Guarda", new DateTime(2020, 09, 20), 0, 9);
            var guardaoperador4 = GaranteUtilizadores(bd, "Nuno RD Guarda", "281167222", new DateTime(1970, 02, 06), "Carvalhal da Louça", "923654789", "nuno.gatti@RDtelecom.com", "6270-131", "Operador", false, "Guarda", new DateTime(2020, 10, 28), 0, 9);
            var guardaoperador5 = GaranteUtilizadores(bd, "Patrícia RD Guarda", "253533643", new DateTime(1980, 03, 30), "Rua Amadeus Mozart", "966968749", "patricia.carbone@RDtelecom.com", "6300-509", "Operador", false, "Guarda", new DateTime(2020, 12, 28), 0, 9);
            var guardaoperador6 = GaranteUtilizadores(bd, "Pedro RD Guarda", "254138349", new DateTime(1999, 08, 01), "Muxagata", "923456987", "pedro.guerra@RDtelecom.com", "6370-361", "Operador", false, "Guarda", new DateTime(2020, 10, 28), 0, 9);
            var guardaoperador7 = GaranteUtilizadores(bd, "Célia RD Guarda", "263953840", new DateTime(1999, 07, 01), "Juncais", "910002658", "celia.valente@RDtelecom.com", "6370-332", "Operador", false, "Guarda", new DateTime(2020, 11, 28), 0, 9);
            var guardaoperador8 = GaranteUtilizadores(bd, "Rosa RD Guarda", "281900361", new DateTime(2000, 01, 01), "Quinta da Costa", "92888632", "rosa.serra@RDtelecom.com", "6324-004", "Operador", false, "Guarda", new DateTime(2020, 12, 05), 0, 9);
            var guardaoperador9 = GaranteUtilizadores(bd, "Ricardo RD Guarda", "206569327", new DateTime(1987, 09, 17), "Parada", "963011456", "ricardo.estrla@RDtelecom.com", "6355-142", "Operador", false, "Guarda", new DateTime(2021, 02, 28), 0, 9);
            var guardaoperador10 = GaranteUtilizadores(bd, "Carlos RD Guarda", "220640610", new DateTime(1859, 05, 08), "Senouras", "925666874", "carlos.fechaduras@RDtelecom.com", "6355-170", "Operador", false, "Guarda", new DateTime(2021, 03, 01), 0, 9);
            var guardaoperador11 = GaranteUtilizadores(bd, "Álvaro RD Guarda", "210346760", new DateTime(1958, 12, 31), "Beco da Alegria", "91025800", "alvaro.bruxelas@RDtelecom.com", "6355-170", "Operador", false, "Guarda", new DateTime(2021, 01, 20), 0, 9);
            var guardaoperador12 = GaranteUtilizadores(bd, "Isamara RD Guarda", "215494725", new DateTime(1956, 12, 05), "Lajeosa", "936058777", "isamara.lobao@RDtelecom.com", "6320-161", "Operador", false, "Guarda", new DateTime(2021, 01, 28), 0, 9);

            //    //-------------------------- 10 LEIRIA-----------------
            var leiriaoperador1 = GaranteUtilizadores(bd, "Amílcar RD Leiria", "119888068", new DateTime(1967, 03, 01), "Rua dos Inácios", "923600144", "amilcar.malho@RDtelecom.com", "2400-773", "Operador", false, "Leiria", new DateTime(2020, 10, 18), 0, 10);
            var leiriaoperador2 = GaranteUtilizadores(bd, "Joana RD Leiria", "131092812", new DateTime(1966, 11, 21), "Rua do Futuro", "930054711", "joana.sa@RDtelecom.com", "2400-760", "Operador", false, "Leiria", new DateTime(2020, 09, 25), 0, 10);
            var leiriaoperador3 = GaranteUtilizadores(bd, "João RD Leiria", "161270441", new DateTime(2000, 06, 01), "Moinho do Rato", "925632008", "joao.cabral@RDtelecom.com", "2410-528", "Operador", false, "Leiria", new DateTime(2020, 10, 25), 0, 10);
            var leiriaoperador4 = GaranteUtilizadores(bd, "Ilídio RD Leiria", "140129375", new DateTime(1999, 06, 09), "Rua de Saint-Maur-Des-Fosses", "963012547", "ilidio.brazeta@RDtelecom.com", "2414-001", "Operador", false, "Leiria", new DateTime(2020, 10, 08), 0, 10);
            var leiriaoperador5 = GaranteUtilizadores(bd, "Ricardo RD Leiria", "161728219", new DateTime(1984, 02, 28), "Estrada da Mata Marrazes", "921456920", "ricardo.caramelo@RDtelecom.com", "2419-001", "Operador", false, "Leiria", new DateTime(2020, 10, 03), 0, 10);
            var leiriaoperador6 = GaranteUtilizadores(bd, "João RD Leiria", "175938652", new DateTime(1999, 07, 11), "Rua de Santa Margarida", "923001458", "joao.figo@RDtelecom.com", "2420-999", "Operador", false, "Leiria", new DateTime(2020, 11, 28), 0, 10);
            var leiriaoperador7 = GaranteUtilizadores(bd, "Romina RD Leiria", "163520500", new DateTime(1999, 07, 01), "Beco Grilo", "931478569", "romina.santos@RDtelecom.com", "2460-005", "Operador", false, "Leiria", new DateTime(2020, 11, 17), 0, 10);
            var leiriaoperador8 = GaranteUtilizadores(bd, "Rui RD Leiria", "103294708", new DateTime(2000, 01, 01), "Rua Mercedes e Carlos Campeão", "968547000", "rui.rosa@RDtelecom.com", "2460-006", "Operador", false, "Leiria", new DateTime(2020, 11, 12), 0, 10);
            var leiriaoperador9 = GaranteUtilizadores(bd, "Vanda RD Leiria", "109509552", new DateTime(1980, 10, 11), "Bolo", "922365009", "vanda.ruivo@RDtelecom.com", "3280-113", "Operador", false, "Leiria", new DateTime(2020, 11, 03), 0, 10);
            var leiriaoperador10 = GaranteUtilizadores(bd, "Tiago RD Leiria", "163600937", new DateTime(1975, 08, 08), "Sapateira", "967896333", "tiago.andrade@RDtelecom.com", "3280-123", "Operador", false, "Leiria", new DateTime(2020, 11, 03), 0, 10);
            var leiriaoperador11 = GaranteUtilizadores(bd, "Marta RD Leiria", "195614313", new DateTime(1988, 12, 24), "Rua dos Lavadouros", "910258963", "marta.martinelli@RDtelecom.com", "2525-123", "Operador", false, "Leiria", new DateTime(2021, 03, 03), 0, 10);
            var leiriaoperador12 = GaranteUtilizadores(bd, "Joaquim RD Leiria", "116386428", new DateTime(1996, 12, 05), "Picha", "939391250", "joaquim.vitale@RDtelecom.com", "3270-143", "Operador", false, "Leiria", new DateTime(2021, 01, 03), 0, 10);


            //    //-------------------------- 11 LISBOA-----------------
            var lisboaoperador1 = GaranteUtilizadores(bd, "Geraldo RD Lisboa", "126914966", new DateTime(1968, 08, 01), "Rua Brito Aranha", "924141230", "geraldo.fraga@RDtelecom.com", "1000-007", "Operador", false, "Lisboa", new DateTime(2020, 10, 13), 0, 11);
            var lisboaoperador2 = GaranteUtilizadores(bd, "Celeste RD Lisboa", "196656087", new DateTime(1969, 11, 28), "Avenida dos Defensores de Chaves", "937182456", "celeste.djata@RDtelecom.com", "1049-004", "Operador", false, "Lisboa", new DateTime(2020, 10, 18), 0, 11);
            var lisboaoperador3 = GaranteUtilizadores(bd, "Carla RD Lisboa", "176965173", new DateTime(1978, 05, 01), "Largo das Palmeiras", "931773910", "carla.costa@RDtelecom.com", "1050-168", "Operador", false, "Lisboa", new DateTime(2020, 10, 14), 0, 11);
            var lisboaoperador4 = GaranteUtilizadores(bd, "Daniele RD Lisboa", "110466721", new DateTime(1973, 08, 06), "Avenida de Berna", "917182935", "daniele.lucas@RDtelecom.com", "1067-001", "Operador", false, "Lisboa", new DateTime(2020, 11, 08), 0, 11);
            var lisboaoperador5 = GaranteUtilizadores(bd, "Davide RD Lisboa", "171941195", new DateTime(1986, 10, 30), "Vila Celeste Rua Garcia", "961455620", "davide.ramos@RDtelecom.com", "1070-136", "Operador", false, "Lisboa", new DateTime(2020, 12, 18), 0, 11);
            var lisboaoperador6 = GaranteUtilizadores(bd, "Diana RD Lisboa", "164398112", new DateTime(1999, 07, 01), "Beco Benformoso", "967410226", "diana.leite@RDtelecom.com", "1100-008", "Operador", false, "Lisboa", new DateTime(2020, 11, 09), 0, 11);
            var lisboaoperador7 = GaranteUtilizadores(bd, "Dunildo RD Lisboa", "133792285", new DateTime(1988, 07, 01), "Largo Cabeço da Bola", "937852013", "dunildo.fernandes@RDtelecom.com", "1150-008", "Operador", false, "Lisboa", new DateTime(2020, 11, 02), 0, 11);
            var lisboaoperador8 = GaranteUtilizadores(bd, "Beatriz RD Lisboa", "141553898", new DateTime(2000, 01, 01), "Beco da Bempostinha", "931456110", "beatriz.testa@RDtelecom.com", "1150-006", "Operador", false, "Lisboa", new DateTime(2020, 10, 10), 0, 11);
            var lisboaoperador9 = GaranteUtilizadores(bd, "Pedro RD Lisboa", "177572280", new DateTime(2000, 09, 29), "Rua dos Anjos", "969391789", "pedro.farina@RDtelecom.com", "1169-004", "Operador", false, "Lisboa", new DateTime(2020, 10, 18), 0, 11);
            var lisboaoperador10 = GaranteUtilizadores(bd, "Bernardino RD Lisboa", "150336322", new DateTime(1975, 02, 08), "Rua dos Lusíadas", "919320365", "bernardino.caputo@RDtelecom.com", "1349-006", "Operador", false, "Lisboa", new DateTime(2021, 03, 10), 0, 11);
            var lisboaoperador11 = GaranteUtilizadores(bd, "Pablo RD Lisboa", "153510340", new DateTime(1955, 08, 24), "Cabeça Gorda", "932514789", "pablo.medina@RDtelecom.com", "2565-001", "Operador", false, "Lisboa", new DateTime(2021, 02, 23), 0, 11);
            var lisboaoperador12 = GaranteUtilizadores(bd, "Eva RD Lisboa", "170633977", new DateTime(1969, 12, 18), "Avenida João de Belas", "930258789", "eva.simoes@RDtelecom.com", "2605-203", "Operador", false, "Lisboa", new DateTime(2021, 01, 18), 0, 11);

            //    //-------------------------- 12 PORTALEGRE-----------------
            var portalegreoperador1 = GaranteUtilizadores(bd, "Paula RD Portalegre", "246991585", new DateTime(1987, 05, 01), "Torre Cimeira", "969691321", "paula.neves@RDtelecom.com", "6040-003", "Operador", false, "Portalegre", new DateTime(2020, 09, 27), 0, 12);
            var portalegreoperador2 = GaranteUtilizadores(bd, "Filipe RD Portalegre", "207370133", new DateTime(1988, 10, 21), "Rua do Poço", "936285714", "filipe.pinto@RDtelecom.com", "6050-106", "Operador", false, "Portalegre", new DateTime(2020, 10, 29), 0, 12);
            var portalegreoperador3 = GaranteUtilizadores(bd, "Ryan RD Portalegre", "258078286", new DateTime(1968, 07, 13), "Ribeiro do Buraco", "921326554", "ryan.vieira@RDtelecom.com", "7300-351", "Operador", false, "Portalegre", new DateTime(2020, 10, 07), 0, 12);
            var portalegreoperador4 = GaranteUtilizadores(bd, "Rodrigo RD Portalegre", "292120265", new DateTime(1970, 06, 28), "Cubos", "925632214", "rodrigo.amarelo@RDtelecom.com", "7300-316", "Operador", false, "Portalegre", new DateTime(2020, 12, 06), 0, 12);
            var portalegreoperador5 = GaranteUtilizadores(bd, "Rita RD Portalegre", "210764333", new DateTime(1984, 10, 07), "Praça do Município", "960321123", "rita.abrantes@RDtelecom.com", "7301-855", "Operador", false, "Portalegre", new DateTime(2020, 11, 20), 0, 12);
            var portalegreoperador6 = GaranteUtilizadores(bd, "Luís RD Portalegre", "246103230", new DateTime(1982, 07, 18), "Travessa da Rua do Comércio", "911233698", "luis.rico@RDtelecom.com", "7301-857", "Operador", false, "Portalegre", new DateTime(2020, 10, 25), 0, 12);
            var portalegreoperador7 = GaranteUtilizadores(bd, "Helder RD Portalegre", "247266221", new DateTime(1973, 07, 01), "Rua das Encruzilhadas", "936200145", "helder.conceicao@RDtelecom.com", "7320-123", "Operador", false, "Portalegre", new DateTime(2020, 10, 19), 0, 12);
            var portalegreoperador8 = GaranteUtilizadores(bd, "Mariza RD Portalegre", "265156343", new DateTime(2000, 01, 01), "Portas do Sol", "968574123", "mariza.falcao@RDtelecom.com", "7350-002", "Operador", false, "Portalegre", new DateTime(2020, 11, 13), 0, 12);
            var portalegreoperador9 = GaranteUtilizadores(bd, "Lúcio RD Portalegre", "284225959", new DateTime(1980, 09, 16), "Rua da Guarda", "961425632", "lucio.junior@RDtelecom.com", "7350-002", "Operador", false, "Portalegre", new DateTime(2021, 02, 28), 0, 12);
            var portalegreoperador10 = GaranteUtilizadores(bd, "Tiago RD Portalegre", "256300291", new DateTime(1975, 02, 24), "Rua do Escorregadio", "916914785", "tiago.silva@RDtelecom.com", "7350-002", "Operador", false, "Portalegre", new DateTime(2021, 01, 20), 0, 12);
            var portalegreoperador11 = GaranteUtilizadores(bd, "Ana RD Portalegre", "274980398", new DateTime(1968, 12, 19), "Rua do Emigrante", "923654782", "ana.godinho@RDtelecom.com", "7370-001", "Operador", false, "Portalegre", new DateTime(2021, 02, 22), 0, 12);
            var portalegreoperador12 = GaranteUtilizadores(bd, "Filipa RD Portalegre", "270511059", new DateTime(1956, 12, 05), "Rua Marciano Cipriano", "923654741", "filipa.oliveira@RDtelecom.com", "7370-002", "Operador", false, "Portalegre", new DateTime(2021, 01, 13), 0, 12);

            //-------------------------- 13 PORTO-----------------
            var portoperador1 = GaranteUtilizadores(bd, "Patrícia RD Porto", "232501173", new DateTime(1986, 03, 01), "Largo Escultor José Moreira da Silva", "968574000", "patricia.amaral@RDtelecom.com", "4000-312", "Operador", false, "Porto", new DateTime(2020, 08, 05), 0, 13);
            var portoperador2 = GaranteUtilizadores(bd, "João RD Porto", "255170262", new DateTime(1988, 11, 14), "Rua Latino Coelho Pares", "933220655", "joao.santos@RDtelecom.com", "4000-314", "Operador", false, "Porto", new DateTime(2021, 01, 05), 0, 13);
            var portoperador3 = GaranteUtilizadores(bd, "João RD Porto", "279641966", new DateTime(1963, 03, 01), "Rua de Moreira Ímpares", "923002564", "joao.ferreira@RDtelecom.com", "4000-346", "Operador", false, "Porto", new DateTime(2020, 10, 11), 0, 13);
            var portoperador4 = GaranteUtilizadores(bd, "Tânia RD Porto", "265227186", new DateTime(1967, 06, 03), "Rua do Alto da Fontinha", "968321008", "tania.pereira@RDtelecom.com", "4000-007", "Operador", false, "Porto", new DateTime(2020, 08, 12), 0, 13);
            var portoperador5 = GaranteUtilizadores(bd, "Rute RD Porto", "220300828", new DateTime(1975, 02, 28), "Rua Júlio Dinis Fast-Food Mister Pick Wick", "925654197", "rute.pequena@RDtelecom.com", "4050-001", "Operador", false, "Porto", new DateTime(2020, 10, 17), 0, 13);
            var portoperador6 = GaranteUtilizadores(bd, "Paulo RD Porto", "215830300", new DateTime(1998, 07, 11), "Rua Júlio Dinis", "923685203", "paulo.jorge@RDtelecom.com", "4050-322", "Operador", false, "Porto", new DateTime(2020, 08, 18), 0, 13);
            var portoperador7 = GaranteUtilizadores(bd, "Helder RD Porto", "222960540", new DateTime(1999, 07, 01), "Travessa Marracuene", "923654780", "helder.reis@RDtelecom.com", "4050-357", "Operador", false, "Porto", new DateTime(2020, 08, 26), 0, 13);
            var portoperador8 = GaranteUtilizadores(bd, "Lucas RD Porto", "204095387", new DateTime(1974, 01, 01), "Rua Guerra Junqueiro", "936002365", "tome.fernandes@RDtelecom.com", "4169-009", "Operador", false, "Porto", new DateTime(2020, 08, 27), 0, 13);
            var portoperador9 = GaranteUtilizadores(bd, "Tomé RD Porto", "240389263", new DateTime(1985, 06, 11), "Rua do Campo Alegre", "927183608", "tome.fernandes@RDtelecom.com", "4169-007", "Operador", false, "Porto", new DateTime(2020, 08, 25), 0, 13);
            var portoperador10 = GaranteUtilizadores(bd, "Paula RD Porto", "210053895", new DateTime(1962, 02, 08), "Rua Gonçalo Sampaio", "925328961", "paula.andrade@RDtelecom.com", "4169-001", "Operador", false, "Porto", new DateTime(2020, 11, 10), 0, 13);
            var portoperador11 = GaranteUtilizadores(bd, "Jacinto RD Porto", "267983921", new DateTime(1957, 03, 24), "Rua do Campo Alegre", "968321520", "jacinto.dias@RDtelecom.com", "4169-007", "Operador", false, "Porto", new DateTime(2020, 10, 05), 0, 13);
            var portoperador12 = GaranteUtilizadores(bd, "Amélia RD Porto", "207692670", new DateTime(1956, 08, 05), "Rua Professora Lucília Fernandes Canidelo", "930221459", "amelia.paz@RDtelecom.com", "4400-651", "Operador", false, "Porto", new DateTime(2020, 12, 05), 0, 13);

            //    //-------------------------- 14 SANTAREM-----------------
            var santaremoperador1 = GaranteUtilizadores(bd, "Patrícia RD Santarem", "102923698", new DateTime(2000, 07, 01), "Casal dos Florindos", "917896325", "patricia.gomes@RDtelecom.com", "2000-320", "Operador", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);
            var santaremoperador2 = GaranteUtilizadores(bd, "Marlene RD Santarem", "167804812", new DateTime(1987, 11, 21), "Casal da Igreja", "969587542", "marlene.satos@RDtelecom.com", "2000-336", "Operador", false, "Santarém", new DateTime(2020, 08, 19), 0, 14);
            var santaremoperador3 = GaranteUtilizadores(bd, "João RD Santarem", "179394614", new DateTime(1978, 07, 01), "Dona Belida", "932102548", "joao.ferreira@RDtelecom.com", "2000-342", "Operador", false, "Santarém", new DateTime(2021, 01, 17), 0, 14);
            var santaremoperador4 = GaranteUtilizadores(bd, "Pedro RD Santarem", "134904710", new DateTime(1969, 06, 06), "Avenida Bernardo Santareno", "963214520", "pedro.martins@RDtelecom.com", "2009-004", "Operador", false, "Santarém", new DateTime(2021, 01, 05), 0, 14);
            var santaremoperador5 = GaranteUtilizadores(bd, "Joana RD Santarem", "194846377", new DateTime(1979, 10, 30), "Largo do Infante Santo", "925874100", "joana.lima@RDtelecom.com", "2009-002", "Operador", false, "Santarém", new DateTime(2021, 01, 05), 0, 14);
            var santaremoperador6 = GaranteUtilizadores(bd, "Patrícia RD Santarem", "130908010", new DateTime(1999, 04, 01), "Estrada Nacional 10", "925964874", "patricia.gomes@RDtelecom.com", "2139-503", "Operador", false, "Santarém", new DateTime(2020, 12, 28), 0, 14);
            var santaremoperador7 = GaranteUtilizadores(bd, "Irís RD Santarem", "137377924", new DateTime(1999, 09, 05), "Agolada", "965412088", "iris.copeto@RDtelecom.com", "2100-001", "Operador", false, "Santarém", new DateTime(2020, 11, 12), 0, 14);
            var santaremoperador8 = GaranteUtilizadores(bd, "Filipe RD Santarem", "193317842", new DateTime(1987, 01, 01), "Varejola", "924863210", "filipe.pais@RDtelecom.com", "2100-377", "Operador", false, "Santarém", new DateTime(2020, 12, 12), 0, 14);
            var santaremoperador9 = GaranteUtilizadores(bd, "Amadeu RD Santarem", "187836825", new DateTime(1965, 08, 17), "Louriceira", "920258885", "amadeu.lourenço@RDtelecom.com", "6120-116", "Operador", false, "Santarém", new DateTime(2020, 11, 05), 0, 14);
            var santaremoperador10 = GaranteUtilizadores(bd, "Amílcar RD Santarem", "116024879", new DateTime(1974, 02, 10), "Estrada Nacional 10", "967862111", "amilcar.oliveira@RDtelecom.com", "2139-503", "Operador", false, "Santarém", new DateTime(2020, 10, 05), 0, 14);
            var santaremoperador11 = GaranteUtilizadores(bd, "Luísa RD Santarem", "194892441", new DateTime(1955, 08, 05), "Casal de Além", "922587456", "luisa.guerra@RDtelecom.com", "2025-150", "Operador", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);
            var santaremoperador12 = GaranteUtilizadores(bd, "Afonso RD Santarem", "143171410", new DateTime(1957, 07, 05), "Pisão", "932008521", "afonso.freira@RDtelecom.com", "2230-009", "Operador", false, "Santarém", new DateTime(2020, 08, 05), 0, 14);

            //    //-------------------------- 15 SETUBAL-----------------
            var setubaloperador1 = GaranteUtilizadores(bd, "Patrícia RD Setúbal", "159738296", new DateTime(1986, 07, 01), "Praceta Bernardim Ribeiro", "914753951", "patricia.varandas@RDtelecom.com", "2800-002", "Operador", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            var setubaloperador2 = GaranteUtilizadores(bd, "Miguel RD Setúbal", "115818910", new DateTime(1988, 05, 21), "Praça Doutora Adelaide Coutinho", "960225478", "miguel.santos@RDtelecom.com", "2800-002", "Operador", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            var setubaloperador3 = GaranteUtilizadores(bd, "João RD Setúbal", "125484038", new DateTime(1978, 06, 01), "Rua Bulhão Pato", "926715826", "joao.ferreira@RDtelecom.com", "2800-003", "Operador", false, "Setúbal", new DateTime(2020, 08, 05), 0, 15);
            var setubaloperador4 = GaranteUtilizadores(bd, "Tânia RD Setúbal", "120730464", new DateTime(1970, 06, 08), "Rua Capitão Leitão Ímpares", "965874100", "tania-sousa@RDtelecom.com", "2800-137", "Operador", false, "Setúbal", new DateTime(2020, 11, 05), 0, 15);
            var setubaloperador5 = GaranteUtilizadores(bd, "Rute RD Setúbal", "107984512", new DateTime(1968, 10, 30), "Pátio Albers", "926548222", "rute.martins@RDtelecom.com", "2830-320", "Operador", false, "Setúbal", new DateTime(2020, 12, 11), 0, 15);
            var setubaloperador6 = GaranteUtilizadores(bd, "Bernardo RD Setúbal", "140414878", new DateTime(2000, 08, 01), "Travessa do Alto José Ferreira", "960321489", "bernardo.pinto@RDtelecom.com", "2830-381", "Operador", false, "Setúbal", new DateTime(2020, 08, 19), 0, 15); ;
            var setubaloperador7 = GaranteUtilizadores(bd, "Paula RD Setúbal", "174218990", new DateTime(1999, 11, 01), "Rua da Bandeira", "966999852", "paula.neves@RDtelecom.com", "2830-330", "Operador", false, "Setúbal", new DateTime(2020, 08, 20), 0, 15);
            var setubaloperador8 = GaranteUtilizadores(bd, "Miriam RD Setúbal", "147726387", new DateTime(2001, 01, 01), "Rua Professor Egas Moniz", "914852684", "miriam.palito@RDtelecom.com", "2830-357", "Operador", false, "Setúbal", new DateTime(2021, 02, 27), 0, 15);
            var setubaloperador9 = GaranteUtilizadores(bd, "Vanessa RD Setúbal", "188485481", new DateTime(1988, 09, 11), "Rua Fernando de Sousa", "923355874", "vanessa.albino@RDtelecom.com", "2844-001", "Operador", false, "Setúbal", new DateTime(2020, 12, 30), 0, 15);
            var setubaloperador10 = GaranteUtilizadores(bd, "Rosa RD Setúbal", "180639439", new DateTime(1975, 02, 11), "2890-200", "920333658", "rosa.amarelo@RDtelecom.com", "2890-200", "Operador", false, "Setúbal", new DateTime(2020, 11, 05), 0, 15);
            var setubaloperador11 = GaranteUtilizadores(bd, "Vanessa RD Setúbal", "164580247", new DateTime(1955, 07, 28), "Estrada Nacional 5", "968321450", "vanessa.roduigues@RDtelecom.com", "2959-501", "Operador", false, "Setúbal", new DateTime(2020, 09, 10), 0, 15);
            var setubaloperador12 = GaranteUtilizadores(bd, "Afonso RD Setúbal", "178949655", new DateTime(1956, 12, 30), "Monte das Parchanas", "968532000", "afonso.pereira@RDtelecom.com", "7595-002", "Operador", false, "Setúbal", new DateTime(2020, 10, 28), 0, 15);

            //    //-------------------------- 16 VIANA DO CASTELO-----------------
            var vianaoperador1 = GaranteUtilizadores(bd, "Pedro RD Viana", "283312491", new DateTime(1995, 07, 11), "Largo da Oliveira", "918654654", "pedro.gomes@RDtelecom.com", "4900-003", "Operador", false, "Viana do Castelo", new DateTime(2020, 08, 05), 0, 16);
            var vianaoperador2 = GaranteUtilizadores(bd, "Marlene RD Viana", "292990308", new DateTime(1988, 11, 21), "Estrada de Santo António", "965888970", "marlene.pereira@RDtelecom.com", "4900-006", "Operador", false, "Viana do Castelo", new DateTime(2020, 10, 05), 0, 16);
            var vianaoperador3 = GaranteUtilizadores(bd, "João RD Viana", "237628317", new DateTime(1977, 07, 01), "Largo do Pião", "963210337", "joao.ferreira@RDtelecom.com", "4900-102", "Operador", false, "Viana do Castelo", new DateTime(2020, 11, 05), 0, 16);
            var vianaoperador4 = GaranteUtilizadores(bd, "Tânia RD Viana", "250558637", new DateTime(1969, 06, 06), "Rua Paula Ferreira", "967520147", "tania-sousa@RDtelecom.com", "4900-862", "Operador", false, "Viana do Castelo", new DateTime(2020, 09, 05), 0, 16);
            var vianaoperador5 = GaranteUtilizadores(bd, "Rute RD Viana", "266466117", new DateTime(1979, 10, 30), "Rua de São Pedro de Areosa", "923117852", "rute.martins@RDtelecom.com", "4900-902", "Operador", false, "Viana do Castelo", new DateTime(2021, 01, 05), 0, 16);
            var vianaoperador6 = GaranteUtilizadores(bd, "Luís RD Viana", "296425150", new DateTime(2000, 07, 16), "Travessa dos Sobreiros", "935888723", "luis.bernardo@RDtelecom.com", "4900-914", "Operador", false, "Viana do Castelo", new DateTime(2021, 02, 05), 0, 16);
            var vianaoperador7 = GaranteUtilizadores(bd, "Helder RD Viana", "286887100", new DateTime(1999, 07, 17), "Rua de Monserrate", "966541112", "helder.vicente@RDtelecom.com", "4904-859", "Operador", false, "Viana do Castelo", new DateTime(2020, 11, 17), 0, 16);
            var vianaoperador8 = GaranteUtilizadores(bd, "António RD Viana", "238294749", new DateTime(2001, 05, 01), "Rua Pedro Homem de Melo", "963325559", "antonio.santos@RDtelecom.com", "4904-861", "Operador", false, "Viana do Castelo", new DateTime(2020, 09, 28), 0, 16);
            var vianaoperador9 = GaranteUtilizadores(bd, "Célia RD Viana", "241415659", new DateTime(1980, 09, 11), "Rua Santiago da Barra", "923698777", "celia.pimento@RDtelecom.com", "4904-882", "Operador", false, "Viana do Castelo", new DateTime(2020, 08, 30), 0, 16);
            var vianaoperador10 = GaranteUtilizadores(bd, "Paulo RD Viana", "291340725", new DateTime(1975, 02, 08), "Estrada de Santa Luzia", "912152033", "paulo.feliz@RDtelecom.com", "4904-858", "Operador", false, "Viana do Castelo", new DateTime(2020, 10, 14), 0, 16);
            var vianaoperador11 = GaranteUtilizadores(bd, "Joaquim RD Viana", "292585438", new DateTime(1959, 08, 24), "Avenida Capitão Gaspar de Castro", "965321111", "joaquim.guerra@RDtelecom.com", "4904-873", "Operador", false, "Viana do Castelo", new DateTime(2020, 12, 17), 0, 16);
            var vianaoperador12 = GaranteUtilizadores(bd, "Afonso RD Viana", "280477228", new DateTime(1956, 07, 26), "Monterrão", "932654780", "afonso.freira@RDtelecom.com", "4940-003", "Operador", false, "Viana do Castelo", new DateTime(2020, 10, 13), 0, 16);

            //    //-------------------------- 17 VILA REAL-----------------
            var vilarealoperador1 = GaranteUtilizadores(bd, "Patrícia RD Vila Real", "226746380", new DateTime(2001, 09, 01), "Passagem", "966987785", "patricia.avillar@RDtelecom.com", "5000-004", "Operador", false, "Vila Real", new DateTime(2020, 08, 05), 0, 17);
            var vilarealoperador2 = GaranteUtilizadores(bd, "Marlene RD Vila Real", "278338682", new DateTime(1988, 12, 21), "Cabana", "932654120", "marlene.pacheco@RDtelecom.com", "5000-008", "Operador", false, "Vila Real", new DateTime(2020, 10, 05), 0, 17);
            var vilarealoperador3 = GaranteUtilizadores(bd, "Filipe RD Vila Real", "242584799", new DateTime(1975, 08, 01), " Camatoga", "925669850", "filipe.ferreira@RDtelecom.com", "5040-001", "Operador", false, "Vila Real", new DateTime(2020, 08, 27), 0, 17);
            var vilarealoperador4 = GaranteUtilizadores(bd, "Bruna RD Vila Real", "203240995", new DateTime(1969, 04, 06), "Porto Rei", "920357892", "bruna.sousa@RDtelecom.com", "5040-117", "Operador", false, "Vila Real", new DateTime(2020, 08, 28), 0, 17);
            var vilarealoperador5 = GaranteUtilizadores(bd, "António RD Vila Real", "215600061", new DateTime(1985, 10, 30), "Covinhas", "968321025", "antonio.martins@RDtelecom.com", "5050-103", "Operador", false, "Vila Real", new DateTime(2020, 10, 05), 0, 17);
            var vilarealoperador6 = GaranteUtilizadores(bd, "Inês RD Vila Real", "206368330", new DateTime(1973, 07, 01), "Salgueiral", "925841003", "ines.silva@RDtelecom.com", "5050-007", "Operador", false, "Vila Real", new DateTime(2020, 11, 05), 0, 17);
            var vilarealoperador7 = GaranteUtilizadores(bd, "Pedro RD Vila Real", "261055097", new DateTime(2001, 07, 11), "Rua da Barreira", "925632145", "pedro.andrade@RDtelecom.com", "5070-003", "Operador", false, "Vila Real", new DateTime(2021, 01, 05), 0, 17);
            var vilarealoperador8 = GaranteUtilizadores(bd, "Vanessa RD Vila Real", "222266902", new DateTime(1976, 01, 01), "Rua da Ponte Nova", "963221058", "vanessa.monteiro@RDtelecom.com", "5070-003", "Operador", false, "Vila Real", new DateTime(2020, 12, 05), 0, 17);
            var vilarealoperador9 = GaranteUtilizadores(bd, "Manuela RD Vila Real", "243715790", new DateTime(1995, 09, 11), "Rua Amadeu Necho", "925621489", "manuela.fonseca@RDtelecom.com", "5070-008", "Operador", false, "Vila Real", new DateTime(2020, 08, 19), 0, 17);
            var vilarealoperador10 = GaranteUtilizadores(bd, "Kelvin RD Vila Real", "233428267", new DateTime(1987, 02, 11), "Estrada Municipal", "962087536", "kelvin.antunes@RDtelecom.com", "5070-173", "Operador", false, "Vila Real", new DateTime(2020, 08, 27), 0, 17);
            var vilarealoperador11 = GaranteUtilizadores(bd, "Rita RD Vila Real", "268256683", new DateTime(1966, 10, 24), "Porto Rei", "923698520", "rita.godinho@RDtelecom.com", "5040-117", "Operador", false, "Vila Real", new DateTime(2020, 08, 01), 0, 17);
            var vilarealoperador12 = GaranteUtilizadores(bd, "Bernardo RD Vila Real", "277466563", new DateTime(1958, 09, 05), "Povoação", "938219227", "bernardo.marques@RDtelecom.com", "5040-295", "Operador", false, "Vila Real", new DateTime(2020, 11, 05), 0, 17);

            //    //-------------------------- 18 VISEU-----------------
            var viseuoperador1 = GaranteUtilizadores(bd, "Paula RD Viseu", "183894359", new DateTime(2000, 06, 11), "Beco do Areal", "965412200", "paula.gomes@RDtelecom.com", "3430-505", "Operador", false, "Viseu", new DateTime(2021, 02, 05), 0, 18);
            var viseuoperador2 = GaranteUtilizadores(bd, "Marlene RD Viseu", "103467882", new DateTime(1988, 07, 09), "Avenida Madre Rita Amada de Jesus", "928321485", "marlene.santinho@RDtelecom.com", "3500-179", "Operador", false, "Viseu", new DateTime(2021, 01, 05), 0, 18);
            var viseuoperador3 = GaranteUtilizadores(bd, "João RD Viseu", "155241869", new DateTime(1986, 03, 01), "Rua Nova Jugueiros", "965874448", "joao.monteiro@RDtelecom.com", "3500-003", "Operador", false, "Viseu", new DateTime(2020, 08, 05), 0, 18);
            var viseuoperador4 = GaranteUtilizadores(bd, "Tânia RD Viseu", "143563157", new DateTime(1969, 09, 06), "Rua Imaculado Coração de Maria", "932335920", "tania.laranjo@RDtelecom.com", "3500-236", "Operador", false, "Viseu", new DateTime(2020, 10, 05), 0, 18);
            var viseuoperador5 = GaranteUtilizadores(bd, "Anabela RD Viseu", "172309840", new DateTime(1964, 10, 23), "Rua 31 de Janeiro", "935852005", "anabela.moreira@RDtelecom.com", "3500-217", "Operador", false, "Viseu", new DateTime(2020, 12, 05), 0, 18);
            var viseuoperador6 = GaranteUtilizadores(bd, "Bruno RD Viseu", "182643603", new DateTime(1999, 07, 24), "Rua Viscondessa de São Caetano", "910223658", "bruno.fernandes@RDtelecom.com", "3500-185", "Operador", false, "Viseu", new DateTime(2021, 02, 12), 0, 18);
            var viseuoperador7 = GaranteUtilizadores(bd, "Bruno RD Viseu", "165569204", new DateTime(1999, 06, 21), "Rua do Hospital", "923620018", "bruno.nogueira@RDtelecom.com", "3500-161", "Operador", false, "Viseu", new DateTime(2021, 01, 17), 0, 18);
            var viseuoperador8 = GaranteUtilizadores(bd, "Ana RD Viseu", "176401890", new DateTime(2000, 01, 28), "Estrada Nacional 16", "968412339", "ana.gomes@RDtelecom.com", "3519-002", "Operador", false, "Viseu", new DateTime(2020, 11, 28), 0, 18);
            var viseuoperador9 = GaranteUtilizadores(bd, "Rita RD Viseu", "194866360", new DateTime(1984, 09, 11), "Cadraço", "925896552", "rita.rocha@RDtelecom.com", "3475-003", "Operador", false, "Viseu", new DateTime(2020, 10, 25), 0, 18);
            var viseuoperador10 = GaranteUtilizadores(bd, "Joana RD Viseu", "173792294", new DateTime(1987, 02, 08), "Pedrogão", "921332068", "joana.dias@RDtelecom.com", "3475-004", "Operador", false, "Viseu", new DateTime(2020, 12, 17), 0, 18);
            var viseuoperador11 = GaranteUtilizadores(bd, "Maria RD Viseu", "103649492", new DateTime(1960, 07, 24), "Abóboda", "915735255", "maria.bastos@RDtelecom.com", "3475-007", "Operador", false, "Viseu", new DateTime(2020, 11, 09), 0, 18);
            var viseuoperador12 = GaranteUtilizadores(bd, "Luís RD Viseu", "156449307", new DateTime(1979, 10, 05), "Rua Doutor Sebastião Alcantara", "937190258", "luis.neto@RDtelecom.com", "3534-002", "Operador", false, "Viseu", new DateTime(2021, 03, 14), 0, 18);

            //    //-------------------------- 19 AÇORES-----------------
            var acoresoperador1 = GaranteUtilizadores(bd, "Paula RD Açores", "120771314", new DateTime(2000, 06, 01), "À Fonseca ", "930005874", "paula.mendes@RDtelecom.com", "9700-302", "Operador", false, "Açores", new DateTime(2020, 07, 01), 0, 19);
            var acoresoperador2 = GaranteUtilizadores(bd, "Joana RD Açores", "137971443", new DateTime(1989, 11, 11), "Outeiro de São Mateus", "965320005", "joana.santos@RDtelecom.com", "9700-305", "Operador", false, "Açores", new DateTime(2021, 01, 01), 0, 19);
            var acoresoperador3 = GaranteUtilizadores(bd, "Pedro RD Açores", "152267387", new DateTime(1974, 07, 01), "Presas", "961742008", "pedro.ferreira@RDtelecom.com", "9700-308", "Operador", false, "Açores", new DateTime(2020, 09, 01), 0, 19);
            var acoresoperador4 = GaranteUtilizadores(bd, "Fernanda RD Açores", "142615889", new DateTime(1969, 08, 06), "Rua Nova", "961325698", "Fernanda.sousa@RDtelecom.com", "9700-132", "Operador", false, "Açores", new DateTime(2020, 12, 10), 0, 19);
            var acoresoperador5 = GaranteUtilizadores(bd, "Rita RD Açores", "144505665", new DateTime(1979, 11, 30), "Praça Doutor Sousa Júnior ", "930014789", "rita.martins@RDtelecom.com", "9700-007", "Operador", false, "Açores", new DateTime(2020, 10, 11), 0, 19);
            var acoresoperador6 = GaranteUtilizadores(bd, "João RD Açores", "167301900", new DateTime(2001, 07, 01), "Abaixo do Fragoso", "965874123", "joao.patricio@RDtelecom.com", "9880-101", "Operador", false, "Açores", new DateTime(2020, 12, 28), 0, 19);
            var acoresoperador7 = GaranteUtilizadores(bd, "Helder RD Açores", "174189800", new DateTime(1999, 07, 01), "Bairro do Carrapacho", "915233281", "Helder.machado@RDtelecom.com", "9880-120", "Operador", false, "Açores", new DateTime(2020, 11, 01), 0, 19);
            var acoresoperador8 = GaranteUtilizadores(bd, "Luís RD Açores", "139100873", new DateTime(2000, 11, 01), "Bacelo", "925879411", "miriam.falcao@RDtelecom.com", "9880-103", "Operador", false, "Açores", new DateTime(2020, 07, 16), 0, 19);
            var acoresoperador9 = GaranteUtilizadores(bd, "Vanessa RD Açores", "174957050", new DateTime(1980, 09, 11), "Avenida Mousinho de Albuquerque", "926557201", "vanessa.ribeiro@RDtelecom.com", "9880-999", "Operador", false, "Açores", new DateTime(2020, 09, 21), 0, 19);
            var acoresoperador10 = GaranteUtilizadores(bd, "Rafael RD Açores", "119348470", new DateTime(1975, 02, 24), "Pedras Brancas", "961741211", "rafael.leao@RDtelecom.com", "9880-171", "Operador", false, "Açores", new DateTime(2020, 09, 05), 0, 19);
            var acoresoperador11 = GaranteUtilizadores(bd, "Célia RD Açores", "117424919", new DateTime(1955, 08, 24), "Fajã da Isabel Pereira", "911577821", "celia.francisca@RDtelecom.com", "9800-101", "Operador", false, "Açores", new DateTime(2020, 10, 01), 0, 19);
            var acoresoperador12 = GaranteUtilizadores(bd, "Rita RD Açores", "107167727", new DateTime(1956, 06, 05), "Ribeira D'Água", "937888541", "rita.freira@RDtelecom.com", "9800-209", "Operador", false, "Açores", new DateTime(2021, 02, 05), 0, 19);

            //    //-------------------------- 20 MADEIRA-----------------
            var madeiraoperador1 = GaranteUtilizadores(bd, "Patrícia RD Madeira", "113150814", new DateTime(2001, 07, 01), "Caminho Ribeira dos Socorridos ", "965321002", "patricia.passarinha@RDtelecom.com", "9000-617", "Operador", false, "Madeira", new DateTime(2020, 07, 01), 0, 20);
            var madeiraoperador2 = GaranteUtilizadores(bd, "Marlene RD Madeira", "184785715", new DateTime(1968, 11, 21), "2ª Travessa Caminho Arieiro de Baixo", "938520366", "marlene.Lavrador@RDtelecom.com", "9000-602", "Operador", false, "Madeira", new DateTime(2020, 08, 01), 0, 20);
            var madeiraoperador3 = GaranteUtilizadores(bd, "Petra RD Madeira", "170288900", new DateTime(1988, 09, 01), "Azinhaga Vargem", "968741250", "petra.fernandes@RDtelecom.com", "9000-730", "Operador", false, "Madeira", new DateTime(2021, 01, 01), 0, 20);
            var madeiraoperador4 = GaranteUtilizadores(bd, "Vânia RD Madeira", "129628522", new DateTime(1969, 07, 06), "Avenida Colégio Militar ", "912335620", "Vania.fernandes@RDtelecom.com", "9000-996", "Operador", false, "Madeira", new DateTime(2021, 02, 01), 0, 20);
            var madeiraoperador5 = GaranteUtilizadores(bd, "Pedro RD Madeira", "137275862", new DateTime(1979, 10, 27), "Beco Virtudes", "927415620", "pedro.alves@RDtelecom.com", "9000-616", "Operador", false, "Madeira", new DateTime(2020, 09, 21), 0, 20);
            var madeiraoperador6 = GaranteUtilizadores(bd, "Patrícia RD Madeira", "100247520", new DateTime(1999, 09, 24), "Caminho Arieiro", "965327882", "patricia.gomes@RDtelecom.com", "9000-243 ", "Operador", false, "Madeira", new DateTime(2020, 10, 28), 0, 20);
            var madeiraoperador7 = GaranteUtilizadores(bd, "Tiago RD Madeira", "127523502", new DateTime(1999, 07, 18), "Rua Hospital Velho", "924710655", "tiago.prata@RDtelecom.com", "9064-507", "Operador", false, "Madeira", new DateTime(2020, 11, 28), 0, 20);
            var madeiraoperador8 = GaranteUtilizadores(bd, "Paula RD Madeira", "172885205", new DateTime(2000, 01, 26), "Rua Nova Rochinha", "924521333", "paula.falcao@RDtelecom.com", "9064-509", "Operador", false, "Madeira", new DateTime(2020, 12, 17), 0, 20);
            var madeiraoperador9 = GaranteUtilizadores(bd, "Inês RD Madeira", "170898610", new DateTime(1980, 09, 30), "Travessa Contracta e Corujeira", "965824110", "ines.santos@RDtelecom.com", "9125-003", "Operador", false, "Madeira", new DateTime(2020, 09, 10), 0, 20);
            var madeiraoperador10 = GaranteUtilizadores(bd, "Fábio RD Madeira", "169789560", new DateTime(1975, 02, 10), "Estrada do Garajau Vargem", "932226987", "fabio.martins@RDtelecom.com", "9125-253", "Operador", false, "Madeira", new DateTime(2021, 02, 10), 0, 20);
            var madeiraoperador11 = GaranteUtilizadores(bd, "Jaime RD Madeira", "139861750", new DateTime(1955, 02, 24), "Rua Abegoaria", "915738522", "jaime.antunes@RDtelecom.com", "9125-122", "Operador", false, "Madeira", new DateTime(2020, 12, 08), 0, 20);
            var madeiraoperador12 = GaranteUtilizadores(bd, "Joaquim RD Madeira", "158218310", new DateTime(1956, 01, 05), "Cruz", "932165420", "joaquim.alves@RDtelecom.com", "9225-007", "Operador", false, "Madeira", new DateTime(2020, 12, 12), 0, 20);

            //-------DISTRITOS----------------------------
            var aveiro = GaranteDistritos(bd, "Aveiro");
            var beja = GaranteDistritos(bd, "Beja");
            var braga = GaranteDistritos(bd, "Braga");
            var braganca = GaranteDistritos(bd, "Bragança");
            var cb = GaranteDistritos(bd, "Castelo Branco");
            var cbr = GaranteDistritos(bd, "Coimbra");
            var evora = GaranteDistritos(bd, "Évora");
            var faro = GaranteDistritos(bd, "Faro");
            var guarda = GaranteDistritos(bd, "Guarda");
            var leiria = GaranteDistritos(bd, "Leiria");
            var lx = GaranteDistritos(bd, "Lisboa");
            var portalegre = GaranteDistritos(bd, "Portalegre");
            var porto = GaranteDistritos(bd, "Porto");
            var santarem = GaranteDistritos(bd, "Santarém");
            var setubal = GaranteDistritos(bd, "Setúbal");
            var viana = GaranteDistritos(bd, "Viana do Castelo");
            var vilareal = GaranteDistritos(bd, "Vila Real");
            var viseu = GaranteDistritos(bd, "Viseu");
            var acores = GaranteDistritos(bd, "Açores");
            var madeira = GaranteDistritos(bd, "Madeira");

            var pacoteRD4 = GarantePacotes(bd, "Pacote RD4", 55, "O pacote RD4 destacou-se por apresentar a melhor relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade", false, new DateTime(2021, 03, 01), 1);
            var pacoteRD3 = GarantePacotes(bd, "Pacote RD3", 45, "O pacote RD3 destacou-se por apresentar a uma ótima relação do mercado entre velocidade de internet, número de canais de televisão disponibilizados e minutos em chamadas no telefone fixo face à mensalidade para quem não quer ter um telemóvel associado ao pacote.", false, new DateTime(2021, 03, 01), 1);
            var pacoteRDGaming = GarantePacotes(bd, "Pacote RD - Gaming", 55, "A oferta Pacote RD - Gaming é ideal para", false, new DateTime(2021, 03, 01), 1);
            var pacoteRDGPremium = GarantePacotes(bd, "Pacote RD - TV Premium + gaming", 65, "A oferta Pacote RD - TV Premium + gaming destacou - se na categoria de “Melhor pacote para Gaming” por apresentar a melhor relação ao nível do número de canais dedicado ao universo cinematográfico(canais base, exclusivos e premium) face ao custo mensal, bem como uma internet de alta velocidade para não haver falhas durante os jogos.", false, new DateTime(2021, 03, 01), 1);
            var pacoteTvVoz = GarantePacotes(bd, "RD TV e Voz", 25, "Este Pacote RD TV e Voz é ideal para os clientes que querem ver televisão", false, new DateTime(2021, 03, 01), 1);
            var pacoteRDFamiliar = GarantePacotes(bd, "RD Familiar", 45, "Pacote ideal para os momentos de lazer em família.", false, new DateTime(2021, 03, 01), 1);



            bd.Contratos.AddRange(new Contratos[] {

                //Contratos dos Operadores de Aveiro
                new Contratos
                     {
                    UtilizadorId = aveirocliente15.UtilizadorId,
                    ClienteId = aveirocliente15.UtilizadorId,
                    FuncionarioId = aveiroperador12.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 236111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente15.Morada,
                    CodigoPostal = aveirocliente15.CodigoPostal,
                    DistritosId = aveiro.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = aveirocliente1.UtilizadorId,
                    ClienteId = aveirocliente1.UtilizadorId,
                    FuncionarioId = aveirooperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 236111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente1.Morada,
                    CodigoPostal = aveirocliente1.CodigoPostal,
                    DistritosId = aveiro.DistritosId,
                },
                  new Contratos
                     {
                    UtilizadorId = aveirocliente2.UtilizadorId,
                    ClienteId = aveirocliente2.UtilizadorId,
                    FuncionarioId = aveirooperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 236111112,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente2.Morada,
                    CodigoPostal = aveirocliente2.CodigoPostal,
                    DistritosId = aveiro.DistritosId,
                },
                  new Contratos
                     {
                    UtilizadorId = aveirocliente3.UtilizadorId,
                    ClienteId = aveirocliente3.UtilizadorId,
                    FuncionarioId = aveirooperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 236111112,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente3.Morada,
                    CodigoPostal = aveirocliente3.CodigoPostal,
                    DistritosId = aveiro.DistritosId,
                },
                  new Contratos
                     {
                    UtilizadorId = aveirocliente4.UtilizadorId,
                    ClienteId = aveirocliente4.UtilizadorId,
                    FuncionarioId = aveirooperador2.UtilizadorId,
                    PacoteId = pacoteRD3.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 236111112,
                    PrecoPacote = pacoteRD3.Preco,
                    NomePacote = pacoteRD3.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD3.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente4.Morada,
                    CodigoPostal = aveirocliente4.CodigoPostal,
                    DistritosId = aveiro.DistritosId,
                },
            new Contratos
                     {
                    UtilizadorId = aveirocliente5.UtilizadorId,
                    ClienteId = aveirocliente5.UtilizadorId,
                    FuncionarioId = aveirooperador3.UtilizadorId,
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId = natalL.PromocoesId,
                    DataInicio = natalL.DataInicio,
                    DataFim = natalL.DataInicio.AddYears(2),
                    Telefone = 236111112,
                    PrecoPacote = pacoteRDFamiliar.Preco,
                    NomePacote = pacoteRDFamiliar.Nome,
                    PromocaoDesc = natalL.PromocaoDesc,
                    PrecoFinal = pacoteRDFamiliar.Preco - natalL.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente5.Morada,
                    CodigoPostal = aveirocliente5.CodigoPostal,
                    DistritosId = aveiro.DistritosId,
                },
            new Contratos
                     {
                    UtilizadorId = aveirocliente6.UtilizadorId,
                    ClienteId = aveirocliente6.UtilizadorId,
                    FuncionarioId = aveirooperador4.UtilizadorId,
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId = natalL.PromocoesId,
                    DataInicio = natalL.DataInicio,
                    DataFim = natalL.DataInicio.AddYears(2),
                    Telefone = 236111112,
                    PrecoPacote = pacoteRDFamiliar.Preco,
                    NomePacote = pacoteRDFamiliar.Nome,
                    PromocaoDesc = natalL.PromocaoDesc,
                    PrecoFinal = pacoteRDFamiliar.Preco - natalL.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente6.Morada,
                    CodigoPostal = aveirocliente6.CodigoPostal,
                    DistritosId = aveiro.DistritosId,
                },
            new Contratos
                     {
                    UtilizadorId = aveirocliente7.UtilizadorId,
                    ClienteId = aveirocliente7.UtilizadorId,
                    FuncionarioId = aveirooperador5.UtilizadorId,
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId = natalL.PromocoesId,
                    DataInicio = natalL.DataInicio,
                    DataFim = natalL.DataInicio.AddYears(2),
                    Telefone = 236111112,
                    PrecoPacote = pacoteRDFamiliar.Preco,
                    NomePacote = pacoteRDFamiliar.Nome,
                    PromocaoDesc = natalL.PromocaoDesc,
                    PrecoFinal = pacoteRDFamiliar.Preco - natalL.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente7.Morada,
                    CodigoPostal = aveirocliente7.CodigoPostal,
                    DistritosId = aveiro.DistritosId,
                },
                      new Contratos
                     {
                    UtilizadorId = aveirocliente8.UtilizadorId,
                    ClienteId = aveirocliente8.UtilizadorId,
                    FuncionarioId = aveirooperador6.UtilizadorId,
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId = natalL.PromocoesId,
                    DataInicio = natalL.DataInicio,
                    DataFim = natalL.DataInicio.AddYears(2),
                    Telefone = 236111112,
                    PrecoPacote = pacoteRDFamiliar.Preco,
                    NomePacote = pacoteRDFamiliar.Nome,
                    PromocaoDesc = natalL.PromocaoDesc,
                    PrecoFinal = pacoteRDFamiliar.Preco - natalL.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente8.Morada,
                    CodigoPostal = aveirocliente8.CodigoPostal,
                    DistritosId = aveiro.DistritosId,
                },
                       new Contratos
                     {
                    UtilizadorId = aveirocliente9.UtilizadorId,
                    ClienteId = aveirocliente9.UtilizadorId,
                    FuncionarioId = aveirooperador7.UtilizadorId,
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId = natalL.PromocoesId,
                    DataInicio = natalL.DataInicio,
                    DataFim = natalL.DataInicio.AddYears(2),
                    Telefone = 236111112,
                    PrecoPacote = pacoteRDFamiliar.Preco,
                    NomePacote = pacoteRDFamiliar.Nome,
                    PromocaoDesc = natalL.PromocaoDesc,
                    PrecoFinal = pacoteRDFamiliar.Preco - natalL.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente9.Morada,
                    CodigoPostal = aveirocliente9.CodigoPostal,
                    DistritosId = aveiro.DistritosId,
                },
                        new Contratos
                     {
                    UtilizadorId = aveirocliente10.UtilizadorId,
                    ClienteId = aveirocliente10.UtilizadorId,
                    FuncionarioId = aveirooperador8.UtilizadorId,
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId = natalL.PromocoesId,
                    DataInicio = natalL.DataInicio,
                    DataFim = natalL.DataInicio.AddYears(2),
                    Telefone = 236111112,
                    PrecoPacote = pacoteRDFamiliar.Preco,
                    NomePacote = pacoteRDFamiliar.Nome,
                    PromocaoDesc = natalL.PromocaoDesc,
                    PrecoFinal = pacoteRDFamiliar.Preco - natalL.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente10.Morada,
                    CodigoPostal = aveirocliente10.CodigoPostal,
                    DistritosId = aveiro.DistritosId,
                },
                         new Contratos
                     {
                    UtilizadorId = aveirocliente11.UtilizadorId,
                    ClienteId = aveirocliente11.UtilizadorId,
                    FuncionarioId = aveirooperador9.UtilizadorId,
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId = natalL.PromocoesId,
                    DataInicio = natalL.DataInicio,
                    DataFim = natalL.DataInicio.AddYears(2),
                    Telefone = 236111112,
                    PrecoPacote = pacoteRDFamiliar.Preco,
                    NomePacote = pacoteRDFamiliar.Nome,
                    PromocaoDesc = natalL.PromocaoDesc,
                    PrecoFinal = pacoteRDFamiliar.Preco - natalL.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente11.Morada,
                    CodigoPostal = aveirocliente11.CodigoPostal,
                    DistritosId = aveiro.DistritosId,

                         },
                new Contratos
                     {
                    UtilizadorId = aveirocliente12.UtilizadorId,
                    ClienteId = aveirocliente12.UtilizadorId,
                    FuncionarioId = aveirooperador10.UtilizadorId,
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId = natalL.PromocoesId,
                    DataInicio = natalL.DataInicio,
                    DataFim = natalL.DataInicio.AddYears(2),
                    Telefone = 236111112,
                    PrecoPacote = pacoteRDFamiliar.Preco,
                    NomePacote = pacoteRDFamiliar.Nome,
                    PromocaoDesc = natalL.PromocaoDesc,
                    PrecoFinal = pacoteRDFamiliar.Preco - natalL.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente12.Morada,
                    CodigoPostal = aveirocliente12.CodigoPostal,
                    DistritosId = aveiro.DistritosId,
                          },
                new Contratos
                     {
                    UtilizadorId = aveirocliente13.UtilizadorId,
                    ClienteId = aveirocliente13.UtilizadorId,
                    FuncionarioId = aveiroperador12.UtilizadorId,
                    PacoteId = pacoteRDGaming.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 236111112,
                    PrecoPacote = pacoteRDGaming.Preco,
                    NomePacote = pacoteRDGaming.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRDGaming.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = aveirocliente13.Morada,
                    CodigoPostal = aveirocliente13.CodigoPostal,
                    DistritosId = aveiro.DistritosId,
                          },



                //Contratos dos Operadores de Beja
                  new Contratos
                     {
                    UtilizadorId = bejacliente1.UtilizadorId,
                    ClienteId = bejacliente1.UtilizadorId,
                    FuncionarioId = bejaoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bejacliente1.Morada,
                    CodigoPostal = bejacliente1.CodigoPostal,
                    DistritosId = beja.DistritosId,
                },
                  new Contratos
                     {
                    UtilizadorId = bejacliente2.UtilizadorId,
                    ClienteId = bejacliente2.UtilizadorId,
                    FuncionarioId = bejaoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bejacliente2.Morada,
                    CodigoPostal = bejacliente2.CodigoPostal,
                    DistritosId = beja.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bejacliente3.UtilizadorId,
                    ClienteId = bejacliente3.UtilizadorId,
                    FuncionarioId = bejaoperador3.UtilizadorId,
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId = natalL.PromocoesId,
                    DataInicio = natalL.DataInicio,
                    DataFim = natalL.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRDFamiliar.Preco,
                    NomePacote = pacoteRDFamiliar.Nome,
                    PromocaoDesc = pascoaL.PromocaoDesc,
                    PrecoFinal = pacoteRDFamiliar.Preco - natalL.PromocaoDesc,
                    Inactivo = false,
                    Morada = bejacliente3.Morada,
                    CodigoPostal = bejacliente3.CodigoPostal,
                    DistritosId = beja.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bejacliente4.UtilizadorId,
                    ClienteId = bejacliente4.UtilizadorId,
                    FuncionarioId = bejaoperador3.UtilizadorId,
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId = natalL.PromocoesId,
                    DataInicio = natalL.DataInicio,
                    DataFim = natalL.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRDFamiliar.Preco,
                    NomePacote = pacoteRDFamiliar.Nome,
                    PromocaoDesc = pascoaL.PromocaoDesc,
                    PrecoFinal = pacoteRDFamiliar.Preco - natalL.PromocaoDesc,
                    Inactivo = false,
                    Morada = bejacliente4.Morada,
                    CodigoPostal = bejacliente4.CodigoPostal,
                    DistritosId = beja.DistritosId,
                },
                  new Contratos
                     {
                    UtilizadorId = bejacliente5.UtilizadorId,
                    ClienteId = bejacliente5.UtilizadorId,
                    FuncionarioId = bejaoperador4.UtilizadorId,
                    PacoteId = pacoteRDFamiliar.PacoteId,
                    PromocoesId = natalL.PromocoesId,
                    DataInicio = natalL.DataInicio,
                    DataFim = natalL.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRDFamiliar.Preco,
                    NomePacote = pacoteRDFamiliar.Nome,
                    PromocaoDesc = natalL.PromocaoDesc,
                    PrecoFinal = pacoteRDFamiliar.Preco - natalL.PromocaoDesc,
                    Inactivo = false,
                    Morada = bejacliente5.Morada,
                    CodigoPostal = bejacliente5.CodigoPostal,
                    DistritosId = beja.DistritosId,
                },
                  new Contratos
                     {
                    UtilizadorId = bejacliente6.UtilizadorId,
                    ClienteId = bejacliente6.UtilizadorId,
                    FuncionarioId = bejaoperador5.UtilizadorId,
                    PacoteId = pacoteRDGPremium.PacoteId,
                    PromocoesId = natalL.PromocoesId,
                    DataInicio = natalL.DataInicio,
                    DataFim = natalL.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRDGPremium.Preco,
                    NomePacote = pacoteRDGPremium.Nome,
                    PromocaoDesc = natalL.PromocaoDesc,
                    PrecoFinal = pacoteRDGPremium.Preco - natalL.PromocaoDesc,
                    Inactivo = false,
                    Morada = bejacliente6.Morada,
                    CodigoPostal = bejacliente6.CodigoPostal,
                    DistritosId = beja.DistritosId,
                },
                  new Contratos
                     {
                    UtilizadorId = bejacliente7.UtilizadorId,
                    ClienteId = bejacliente7.UtilizadorId,
                    FuncionarioId = bejaoperador6.UtilizadorId,
                    PacoteId = pacoteTvVoz.PacoteId,
                    PromocoesId = natalS.PromocoesId,
                    DataInicio = natalS.DataInicio,
                    DataFim = natalS.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteTvVoz.Preco,
                    NomePacote = pacoteTvVoz.Nome,
                    PromocaoDesc = natalS.PromocaoDesc,
                    PrecoFinal = pacoteTvVoz.Preco - natalS.PromocaoDesc,
                    Inactivo = false,
                    Morada = bejacliente7.Morada,
                    CodigoPostal = bejacliente7.CodigoPostal,
                    DistritosId = beja.DistritosId,
                },
                  new Contratos
                     {
                    UtilizadorId = bejacliente8.UtilizadorId,
                    ClienteId = bejacliente8.UtilizadorId,
                    FuncionarioId = bejaoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bejacliente8.Morada,
                    CodigoPostal = bejacliente8.CodigoPostal,
                    DistritosId = beja.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bejacliente9.UtilizadorId,
                    ClienteId = bejacliente9.UtilizadorId,
                    FuncionarioId = bejaoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bejacliente9.Morada,
                    CodigoPostal = bejacliente9.CodigoPostal,
                    DistritosId = beja.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bejacliente10.UtilizadorId,
                    ClienteId = bejacliente10.UtilizadorId,
                    FuncionarioId = bejaoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bejacliente10.Morada,
                    CodigoPostal = bejacliente10.CodigoPostal,
                    DistritosId = beja.DistritosId,
                },
                  new Contratos
                     {
                    UtilizadorId = bejacliente11.UtilizadorId,
                    ClienteId = bejacliente11.UtilizadorId,
                    FuncionarioId = bejaoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bejacliente11.Morada,
                    CodigoPostal = bejacliente11.CodigoPostal,
                    DistritosId = beja.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bejacliente12.UtilizadorId,
                    ClienteId = bejacliente12.UtilizadorId,
                    FuncionarioId = bejaoperador11.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bejacliente12.Morada,
                    CodigoPostal = bejacliente12.CodigoPostal,
                    DistritosId = beja.DistritosId,
                },


            //Contratos dos Operadores de Braga


                  new Contratos
                     {
                    UtilizadorId = bragacliente1.UtilizadorId,
                    ClienteId = bragacliente1.UtilizadorId,
                    FuncionarioId = bragaoperador1.UtilizadorId,
                    PacoteId = pacoteRD3.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD3.Preco,
                    NomePacote = pacoteRD3.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD3.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragacliente1.Morada,
                    CodigoPostal = bragacliente1.CodigoPostal,
                    DistritosId = braga.DistritosId,
                },
                  new Contratos
                     {
                    UtilizadorId = bragacliente2.UtilizadorId,
                    ClienteId = bragacliente2.UtilizadorId,
                    FuncionarioId = bragaoperador2.UtilizadorId,
                    PacoteId = pacoteRDGaming.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRDGaming.Preco,
                    NomePacote = pacoteRDGaming.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRDGaming.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragacliente2.Morada,
                    CodigoPostal = bragacliente2.CodigoPostal,
                    DistritosId = braga.DistritosId,
                },
                  new Contratos
                     {
                    UtilizadorId = bragacliente3.UtilizadorId,
                    ClienteId = bragacliente3.UtilizadorId,
                    FuncionarioId = bragaoperador3.UtilizadorId,
                    PacoteId = pacoteTvVoz.PacoteId,
                    PromocoesId = natalS.PromocoesId,
                    DataInicio = natalS.DataInicio,
                    DataFim = natalS.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteTvVoz.Preco,
                    NomePacote = pacoteTvVoz.Nome,
                    PromocaoDesc = natalS.PromocaoDesc,
                    PrecoFinal = pacoteTvVoz.Preco - natalS.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragacliente3.Morada,
                    CodigoPostal = bragacliente3.CodigoPostal,
                    DistritosId = braga.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bragacliente4.UtilizadorId,
                    ClienteId = bragacliente4.UtilizadorId,
                    FuncionarioId = bragaoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragacliente4.Morada,
                    CodigoPostal = bragacliente4.CodigoPostal,
                    DistritosId = braga.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bragacliente5.UtilizadorId,
                    ClienteId = bragacliente5.UtilizadorId,
                    FuncionarioId = bragaoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragacliente5.Morada,
                    CodigoPostal = bragacliente5.CodigoPostal,
                    DistritosId = braga.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bragacliente6.UtilizadorId,
                    ClienteId = bragacliente6.UtilizadorId,
                    FuncionarioId = bragaoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragacliente6.Morada,
                    CodigoPostal = bragacliente6.CodigoPostal,
                    DistritosId = braga.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bragacliente7.UtilizadorId,
                    ClienteId = bragacliente7.UtilizadorId,
                    FuncionarioId = bragaoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragacliente7.Morada,
                    CodigoPostal = bragacliente7.CodigoPostal,
                    DistritosId = braga.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bragacliente8.UtilizadorId,
                    ClienteId = bragacliente8.UtilizadorId,
                    FuncionarioId = bragaoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragacliente8.Morada,
                    CodigoPostal = bragacliente8.CodigoPostal,
                    DistritosId = braga.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bragacliente9.UtilizadorId,
                    ClienteId = bragacliente9.UtilizadorId,
                    FuncionarioId = bragaoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragacliente9.Morada,
                    CodigoPostal = bragacliente9.CodigoPostal,
                    DistritosId = braga.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bragacliente10.UtilizadorId,
                    ClienteId = bragacliente10.UtilizadorId,
                    FuncionarioId = bragaoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragacliente10.Morada,
                    CodigoPostal = bragacliente10.CodigoPostal,
                    DistritosId = braga.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bragacliente11.UtilizadorId,
                    ClienteId = bragacliente11.UtilizadorId,
                    FuncionarioId = bragaoperador11.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragacliente11.Morada,
                    CodigoPostal = bragacliente11.CodigoPostal,
                    DistritosId = braga.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bragacliente12.UtilizadorId,
                    ClienteId = bragacliente12.UtilizadorId,
                    FuncionarioId = bragaoperador11.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragacliente12.Morada,
                    CodigoPostal = bragacliente12.CodigoPostal,
                    DistritosId = braga.DistritosId,
                },

                   //Contratos dos Operadores de Bragança

                  new Contratos
                     {
                    UtilizadorId = bragancacliente1.UtilizadorId,
                    ClienteId = bragancacliente1.UtilizadorId,
                    FuncionarioId = bragancaoperador1.UtilizadorId,
                    PacoteId = pacoteRD3.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD3.Preco,
                    NomePacote = pacoteRD3.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD3.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragancacliente1.Morada,
                    CodigoPostal = bragancacliente1.CodigoPostal,
                    DistritosId = braganca.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bragancacliente2.UtilizadorId,
                    ClienteId = bragancacliente2.UtilizadorId,
                    FuncionarioId = bragancaoperador2.UtilizadorId,
                    PacoteId = pacoteRDGaming.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRDGaming.Preco,
                    NomePacote = pacoteRDGaming.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRDGaming.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragancacliente2.Morada,
                    CodigoPostal = bragancacliente2.CodigoPostal,
                    DistritosId = braganca.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = bragancacliente3.UtilizadorId,
                    ClienteId = bragancacliente3.UtilizadorId,
                    FuncionarioId = bragancaoperador3.UtilizadorId,
                    PacoteId = pacoteTvVoz.PacoteId,
                    PromocoesId = natalS.PromocoesId,
                    DataInicio = natalS.DataInicio,
                    DataFim = natalS.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteTvVoz.Preco,
                    NomePacote = pacoteTvVoz.Nome,
                    PromocaoDesc = natalS.PromocaoDesc,
                    PrecoFinal = pacoteTvVoz.Preco - natalS.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragancacliente3.Morada,
                    CodigoPostal = bragancacliente3.CodigoPostal,
                    DistritosId = braganca.DistritosId,
                },


                   new Contratos
                     {
                    UtilizadorId = bragancacliente4.UtilizadorId,
                    ClienteId = bragancacliente4.UtilizadorId,
                    FuncionarioId = bragancaoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragancacliente4.Morada,
                    CodigoPostal = bragancacliente4.CodigoPostal,
                    DistritosId = braganca.DistritosId,
                },

                   new Contratos
                     {
                    UtilizadorId = bragancacliente5.UtilizadorId,
                    ClienteId = bragancacliente5.UtilizadorId,
                    FuncionarioId = bragancaoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragancacliente5.Morada,
                    CodigoPostal = bragancacliente5.CodigoPostal,
                    DistritosId = braganca.DistritosId,
                },

                   new Contratos
                     {
                    UtilizadorId = bragancacliente6.UtilizadorId,
                    ClienteId = bragancacliente6.UtilizadorId,
                    FuncionarioId = bragancaoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragancacliente6.Morada,
                    CodigoPostal = bragancacliente6.CodigoPostal,
                    DistritosId = braganca.DistritosId,
                },

                   new Contratos
                     {
                    UtilizadorId = bragancacliente7.UtilizadorId,
                    ClienteId = bragancacliente7.UtilizadorId,
                    FuncionarioId = bragancaoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragancacliente7.Morada,
                    CodigoPostal = bragancacliente7.CodigoPostal,
                    DistritosId = braganca.DistritosId,
                },

                   new Contratos
                     {
                    UtilizadorId = bragancacliente8.UtilizadorId,
                    ClienteId = bragancacliente8.UtilizadorId,
                    FuncionarioId = bragancaoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragancacliente8.Morada,
                    CodigoPostal = bragancacliente8.CodigoPostal,
                    DistritosId = braganca.DistritosId,
                },


                   new Contratos
                     {
                    UtilizadorId = bragancacliente9.UtilizadorId,
                    ClienteId = bragancacliente9.UtilizadorId,
                    FuncionarioId = bragancaoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragancacliente9.Morada,
                    CodigoPostal = bragancacliente9.CodigoPostal,
                    DistritosId = braganca.DistritosId,
                },

                    new Contratos
                     {
                    UtilizadorId = bragancacliente10.UtilizadorId,
                    ClienteId = bragancacliente10.UtilizadorId,
                    FuncionarioId = bragancaoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragancacliente10.Morada,
                    CodigoPostal = bragancacliente10.CodigoPostal,
                    DistritosId = braganca.DistritosId,
                },

                     new Contratos
                     {
                    UtilizadorId = bragancacliente11.UtilizadorId,
                    ClienteId = bragancacliente11.UtilizadorId,
                    FuncionarioId = bragancaoperador11.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragancacliente11.Morada,
                    CodigoPostal = bragancacliente11.CodigoPostal,
                    DistritosId = braganca.DistritosId,
                },

                            new Contratos
                     {
                    UtilizadorId = bragancacliente12.UtilizadorId,
                    ClienteId = bragancacliente12.UtilizadorId,
                    FuncionarioId = bragancaoperador11.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = bragancacliente12.Morada,
                    CodigoPostal = bragancacliente12.CodigoPostal,
                    DistritosId = braganca.DistritosId,
                },


                //Contratos dos Operadores de CB
                new Contratos
                     {
                    UtilizadorId = castelobrancocliente1.UtilizadorId,
                    ClienteId = castelobrancocliente1.UtilizadorId,
                    FuncionarioId = castelobrancooperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = castelobrancocliente1.Morada,
                    CodigoPostal = castelobrancocliente1.CodigoPostal,
                    DistritosId = cb.DistritosId,
                },

                new Contratos
                     {
                    UtilizadorId = castelobrancocliente2.UtilizadorId,
                    ClienteId = castelobrancocliente2.UtilizadorId,
                    FuncionarioId = castelobrancooperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = castelobrancocliente2.Morada,
                    CodigoPostal = castelobrancocliente2.CodigoPostal,
                    DistritosId = cb.DistritosId,
                },

                new Contratos
                     {
                    UtilizadorId = castelobrancocliente3.UtilizadorId,
                    ClienteId = castelobrancocliente3.UtilizadorId,
                    FuncionarioId = castelobrancooperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = castelobrancocliente3.Morada,
                    CodigoPostal = castelobrancocliente3.CodigoPostal,
                    DistritosId = cb.DistritosId,
                },

                new Contratos
                     {
                    UtilizadorId = castelobrancocliente4.UtilizadorId,
                    ClienteId = castelobrancocliente4.UtilizadorId,
                    FuncionarioId = castelobrancooperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = castelobrancocliente4.Morada,
                    CodigoPostal = castelobrancocliente4.CodigoPostal,
                    DistritosId = cb.DistritosId,
                },

                new Contratos
                     {
                    UtilizadorId = castelobrancocliente5.UtilizadorId,
                    ClienteId = castelobrancocliente5.UtilizadorId,
                    FuncionarioId = castelobrancooperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = castelobrancocliente5.Morada,
                    CodigoPostal = castelobrancocliente5.CodigoPostal,
                    DistritosId = cb.DistritosId,
                },

                new Contratos
                     {
                    UtilizadorId = castelobrancocliente6.UtilizadorId,
                    ClienteId = castelobrancocliente6.UtilizadorId,
                    FuncionarioId = castelobrancooperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = castelobrancocliente6.Morada,
                    CodigoPostal = castelobrancocliente6.CodigoPostal,
                    DistritosId = cb.DistritosId,
                },

                new Contratos
                     {
                    UtilizadorId = castelobrancocliente7.UtilizadorId,
                    ClienteId = castelobrancocliente7.UtilizadorId,
                    FuncionarioId = castelobrancooperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = castelobrancocliente7.Morada,
                    CodigoPostal = castelobrancocliente7.CodigoPostal,
                    DistritosId = cb.DistritosId,
                },

                new Contratos
                     {
                    UtilizadorId = castelobrancocliente8.UtilizadorId,
                    ClienteId = castelobrancocliente8.UtilizadorId,
                    FuncionarioId = castelobrancooperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = castelobrancocliente8.Morada,
                    CodigoPostal = castelobrancocliente8.CodigoPostal,
                    DistritosId = cb.DistritosId,
                },

                new Contratos
                     {
                    UtilizadorId = castelobrancocliente9.UtilizadorId,
                    ClienteId = castelobrancocliente9.UtilizadorId,
                    FuncionarioId = castelobrancooperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = castelobrancocliente9.Morada,
                    CodigoPostal = castelobrancocliente9.CodigoPostal,
                    DistritosId = cb.DistritosId,
                },

                new Contratos
                     {
                    UtilizadorId = castelobrancocliente10.UtilizadorId,
                    ClienteId = castelobrancocliente10.UtilizadorId,
                    FuncionarioId = castelobrancooperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = castelobrancocliente10.Morada,
                    CodigoPostal = castelobrancocliente10.CodigoPostal,
                    DistritosId = cb.DistritosId,
                },

                new Contratos
                     {
                    UtilizadorId = castelobrancocliente11.UtilizadorId,
                    ClienteId = castelobrancocliente11.UtilizadorId,
                    FuncionarioId = castelobrancooperador11.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = castelobrancocliente11.Morada,
                    CodigoPostal = castelobrancocliente11.CodigoPostal,
                    DistritosId = cb.DistritosId,
                },

                new Contratos
                     {
                    UtilizadorId = castelobrancocliente12.UtilizadorId,
                    ClienteId = castelobrancocliente12.UtilizadorId,
                    FuncionarioId = castelobrancooperador11.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = castelobrancocliente12.Morada,
                    CodigoPostal = castelobrancocliente12.CodigoPostal,
                    DistritosId = cb.DistritosId,
                },

                  //Contratos dos Operadores de Coimbra

                  new Contratos
                     {
                    UtilizadorId = coimbracliente1.UtilizadorId,
                    ClienteId = coimbracliente1.UtilizadorId,
                    FuncionarioId = coimbraoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = coimbracliente1.Morada,
                    CodigoPostal = coimbracliente1.CodigoPostal,
                    DistritosId = cbr.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = coimbracliente2.UtilizadorId,
                    ClienteId = coimbracliente2.UtilizadorId,
                    FuncionarioId = coimbraoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = coimbracliente2.Morada,
                    CodigoPostal = coimbracliente2.CodigoPostal,
                    DistritosId = cbr.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = coimbracliente3.UtilizadorId,
                    ClienteId = coimbracliente3.UtilizadorId,
                    FuncionarioId = coimbraoperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = coimbracliente3.Morada,
                    CodigoPostal = coimbracliente3.CodigoPostal,
                    DistritosId = cbr.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = coimbracliente4.UtilizadorId,
                    ClienteId = coimbracliente4.UtilizadorId,
                    FuncionarioId = coimbraoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = coimbracliente4.Morada,
                    CodigoPostal = coimbracliente4.CodigoPostal,
                    DistritosId = cbr.DistritosId,
                },

                  new Contratos
                     {
                    UtilizadorId = coimbracliente5.UtilizadorId,
                    ClienteId = coimbracliente5.UtilizadorId,
                    FuncionarioId = coimbraoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = coimbracliente5.Morada,
                    CodigoPostal = coimbracliente5.CodigoPostal,
                    DistritosId = cbr.DistritosId,
                },

                   new Contratos
                     {
                    UtilizadorId = coimbracliente6.UtilizadorId,
                    ClienteId = coimbracliente6.UtilizadorId,
                    FuncionarioId = coimbraoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = coimbracliente6.Morada,
                    CodigoPostal = coimbracliente6.CodigoPostal,
                    DistritosId = cbr.DistritosId,
                },

                   new Contratos
                     {
                    UtilizadorId = coimbracliente7.UtilizadorId,
                    ClienteId = coimbracliente7.UtilizadorId,
                    FuncionarioId = coimbraoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = coimbracliente7.Morada,
                    CodigoPostal = coimbracliente7.CodigoPostal,
                    DistritosId = cbr.DistritosId,
                },

                   new Contratos
                     {
                    UtilizadorId = coimbracliente8.UtilizadorId,
                    ClienteId = coimbracliente8.UtilizadorId,
                    FuncionarioId = coimbraoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = coimbracliente8.Morada,
                    CodigoPostal = coimbracliente8.CodigoPostal,
                    DistritosId = cbr.DistritosId,
                },

                    new Contratos
                     {
                    UtilizadorId = coimbracliente9.UtilizadorId,
                    ClienteId = coimbracliente9.UtilizadorId,
                    FuncionarioId = coimbraoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = coimbracliente9.Morada,
                    CodigoPostal = coimbracliente9.CodigoPostal,
                    DistritosId = cbr.DistritosId,
                },

                    new Contratos
                     {
                    UtilizadorId = coimbracliente10.UtilizadorId,
                    ClienteId = coimbracliente10.UtilizadorId,
                    FuncionarioId = coimbraoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = coimbracliente10.Morada,
                    CodigoPostal = coimbracliente10.CodigoPostal,
                    DistritosId = cbr.DistritosId,
                },

                    new Contratos
                     {
                    UtilizadorId = coimbracliente11.UtilizadorId,
                    ClienteId = coimbracliente11.UtilizadorId,
                    FuncionarioId = coimbraoperador11.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = coimbracliente11.Morada,
                    CodigoPostal = coimbracliente11.CodigoPostal,
                    DistritosId = cbr.DistritosId,
                },

                    new Contratos
                     {
                    UtilizadorId = coimbracliente12.UtilizadorId,
                    ClienteId = coimbracliente12.UtilizadorId,
                    FuncionarioId = coimbraoperador11.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = coimbracliente12.Morada,
                    CodigoPostal = coimbracliente12.CodigoPostal,
                    DistritosId = cbr.DistritosId,
                },

                  //Contratos dos Operadores de Évora

                           new Contratos
                     {
                    UtilizadorId = evoracliente1.UtilizadorId,
                    ClienteId = evoracliente1.UtilizadorId,
                    FuncionarioId = evoraoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = evoracliente1.Morada,
                    CodigoPostal = evoracliente1.CodigoPostal,
                    DistritosId = evora.DistritosId,
                },

                new Contratos
                {
                    UtilizadorId = evoracliente2.UtilizadorId,
                    ClienteId = evoracliente2.UtilizadorId,
                    FuncionarioId = evoraoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = evoracliente2.Morada,
                    CodigoPostal = evoracliente2.CodigoPostal,
                    DistritosId = evora.DistritosId,
                },

                 new Contratos
                {
                    UtilizadorId = evoracliente3.UtilizadorId,
                    ClienteId = evoracliente3.UtilizadorId,
                    FuncionarioId = evoraoperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = evoracliente3.Morada,
                    CodigoPostal = evoracliente3.CodigoPostal,
                    DistritosId = evora.DistritosId,
                },

                  new Contratos
                {
                    UtilizadorId = evoracliente4.UtilizadorId,
                    ClienteId = evoracliente4.UtilizadorId,
                    FuncionarioId = evoraoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = evoracliente4.Morada,
                    CodigoPostal = evoracliente4.CodigoPostal,
                    DistritosId = evora.DistritosId,
                },

                  new Contratos
                {
                    UtilizadorId = evoracliente5.UtilizadorId,
                    ClienteId = evoracliente5.UtilizadorId,
                    FuncionarioId = evoraoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = evoracliente5.Morada,
                    CodigoPostal = evoracliente5.CodigoPostal,
                    DistritosId = evora.DistritosId,
                },

                  new Contratos
                {
                    UtilizadorId = evoracliente6.UtilizadorId,
                    ClienteId = evoracliente6.UtilizadorId,
                    FuncionarioId = evoraoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = evoracliente6.Morada,
                    CodigoPostal = evoracliente6.CodigoPostal,
                    DistritosId = evora.DistritosId,
                },

                  new Contratos
                {
                    UtilizadorId = evoracliente7.UtilizadorId,
                    ClienteId = evoracliente7.UtilizadorId,
                    FuncionarioId = evoraoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = evoracliente7.Morada,
                    CodigoPostal = evoracliente7.CodigoPostal,
                    DistritosId = evora.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = evoracliente8.UtilizadorId,
                    ClienteId = evoracliente8.UtilizadorId,
                    FuncionarioId = evoraoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = evoracliente8.Morada,
                    CodigoPostal = evoracliente8.CodigoPostal,
                    DistritosId = evora.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = evoracliente9.UtilizadorId,
                    ClienteId = evoracliente9.UtilizadorId,
                    FuncionarioId = evoraoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = evoracliente9.Morada,
                    CodigoPostal = evoracliente9.CodigoPostal,
                    DistritosId = evora.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = evoracliente10.UtilizadorId,
                    ClienteId = evoracliente10.UtilizadorId,
                    FuncionarioId = evoraoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = evoracliente10.Morada,
                    CodigoPostal = evoracliente10.CodigoPostal,
                    DistritosId = evora.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = evoracliente11.UtilizadorId,
                    ClienteId = evoracliente11.UtilizadorId,
                    FuncionarioId = evoraoperador11.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = evoracliente11.Morada,
                    CodigoPostal = evoracliente11.CodigoPostal,
                    DistritosId = evora.DistritosId,
                },

                    new Contratos
                {
                    UtilizadorId = evoracliente12.UtilizadorId,
                    ClienteId = evoracliente12.UtilizadorId,
                    FuncionarioId = evoraoperador11.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = evoracliente12.Morada,
                    CodigoPostal = evoracliente12.CodigoPostal,
                    DistritosId = evora.DistritosId,
                },

                  //Contratos dos Operadores de Faro

                     new Contratos
                {
                    UtilizadorId = farocliente1.UtilizadorId,
                    ClienteId = farocliente1.UtilizadorId,
                    FuncionarioId = farooperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = farocliente1.Morada,
                    CodigoPostal = farocliente1.CodigoPostal,
                    DistritosId = faro.DistritosId,
                },

                      new Contratos
                {
                    UtilizadorId = farocliente2.UtilizadorId,
                    ClienteId = farocliente2.UtilizadorId,
                    FuncionarioId = farooperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = farocliente2.Morada,
                    CodigoPostal = farocliente2.CodigoPostal,
                    DistritosId = faro.DistritosId,
                },

                    new Contratos
                {
                    UtilizadorId = farocliente3.UtilizadorId,
                    ClienteId = farocliente3.UtilizadorId,
                    FuncionarioId = farooperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = farocliente3.Morada,
                    CodigoPostal = farocliente3.CodigoPostal,
                    DistritosId = faro.DistritosId,
                },

                new Contratos
                {
                    UtilizadorId = farocliente4.UtilizadorId,
                    ClienteId = farocliente4.UtilizadorId,
                    FuncionarioId = farooperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = farocliente4.Morada,
                    CodigoPostal = farocliente4.CodigoPostal,
                    DistritosId = faro.DistritosId,
                },


                new Contratos
                {
                    UtilizadorId = farocliente5.UtilizadorId,
                    ClienteId = farocliente5.UtilizadorId,
                    FuncionarioId = farooperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = farocliente5.Morada,
                    CodigoPostal = farocliente5.CodigoPostal,
                    DistritosId = faro.DistritosId,
                },

                new Contratos
                {
                    UtilizadorId = farocliente6.UtilizadorId,
                    ClienteId = farocliente6.UtilizadorId,
                    FuncionarioId = farooperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = farocliente6.Morada,
                    CodigoPostal = farocliente6.CodigoPostal,
                    DistritosId = faro.DistritosId,
                },

                new Contratos
                {
                    UtilizadorId = farocliente7.UtilizadorId,
                    ClienteId = farocliente7.UtilizadorId,
                    FuncionarioId = farooperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = farocliente7.Morada,
                    CodigoPostal = farocliente7.CodigoPostal,
                    DistritosId = faro.DistritosId,
                },

                new Contratos
                {
                    UtilizadorId = farocliente8.UtilizadorId,
                    ClienteId = farocliente8.UtilizadorId,
                    FuncionarioId = farooperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = farocliente8.Morada,
                    CodigoPostal = farocliente8.CodigoPostal,
                    DistritosId = faro.DistritosId,
                },

                new Contratos
                {
                    UtilizadorId = farocliente9.UtilizadorId,
                    ClienteId = farocliente9.UtilizadorId,
                    FuncionarioId = farooperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = farocliente9.Morada,
                    CodigoPostal = farocliente9.CodigoPostal,
                    DistritosId = faro.DistritosId,
                },

                new Contratos
                {
                    UtilizadorId = farocliente10.UtilizadorId,
                    ClienteId = farocliente10.UtilizadorId,
                    FuncionarioId = farooperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = farocliente10.Morada,
                    CodigoPostal = farocliente10.CodigoPostal,
                    DistritosId = faro.DistritosId,
                },

                new Contratos
                {
                    UtilizadorId = farocliente11.UtilizadorId,
                    ClienteId = farocliente11.UtilizadorId,
                    FuncionarioId = farooperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = farocliente11.Morada,
                    CodigoPostal = farocliente11.CodigoPostal,
                    DistritosId = faro.DistritosId,
                },

                  //Contratos dos Operadores de Guarda

                new Contratos
                {
                    UtilizadorId = guardacliente1.UtilizadorId,
                    ClienteId = guardacliente1.UtilizadorId,
                    FuncionarioId = guardaoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = guardacliente1.Morada,
                    CodigoPostal = guardacliente1.CodigoPostal,
                    DistritosId = guarda.DistritosId,
                },

                new Contratos
                {
                    UtilizadorId = guardacliente2.UtilizadorId,
                    ClienteId = guardacliente2.UtilizadorId,
                    FuncionarioId = guardaoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = guardacliente2.Morada,
                    CodigoPostal = guardacliente2.CodigoPostal,
                    DistritosId = guarda.DistritosId,
                },

                new Contratos
                {
                    UtilizadorId = guardacliente3.UtilizadorId,
                    ClienteId = guardacliente3.UtilizadorId,
                    FuncionarioId = guardaoperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = guardacliente3.Morada,
                    CodigoPostal = guardacliente3.CodigoPostal,
                    DistritosId = guarda.DistritosId,
                },

                 new Contratos
                {
                    UtilizadorId = guardacliente4.UtilizadorId,
                    ClienteId = guardacliente4.UtilizadorId,
                    FuncionarioId = guardaoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = guardacliente4.Morada,
                    CodigoPostal = guardacliente4.CodigoPostal,
                    DistritosId = guarda.DistritosId,
                },

                 new Contratos
                {
                    UtilizadorId = guardacliente5.UtilizadorId,
                    ClienteId = guardacliente5.UtilizadorId,
                    FuncionarioId = guardaoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = guardacliente5.Morada,
                    CodigoPostal = guardacliente5.CodigoPostal,
                    DistritosId = guarda.DistritosId,
                },

                 new Contratos
                {
                    UtilizadorId = guardacliente6.UtilizadorId,
                    ClienteId = guardacliente6.UtilizadorId,
                    FuncionarioId = guardaoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = guardacliente6.Morada,
                    CodigoPostal = guardacliente6.CodigoPostal,
                    DistritosId = guarda.DistritosId,
                },

                 new Contratos
                {
                    UtilizadorId = guardacliente7.UtilizadorId,
                    ClienteId = guardacliente7.UtilizadorId,
                    FuncionarioId = guardaoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = guardacliente7.Morada,
                    CodigoPostal = guardacliente7.CodigoPostal,
                    DistritosId = guarda.DistritosId,
                },

                 new Contratos
                {
                    UtilizadorId = guardacliente8.UtilizadorId,
                    ClienteId = guardacliente8.UtilizadorId,
                    FuncionarioId = guardaoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = guardacliente8.Morada,
                    CodigoPostal = guardacliente8.CodigoPostal,
                    DistritosId = guarda.DistritosId,
                },

                  new Contratos
                {
                    UtilizadorId = guardacliente9.UtilizadorId,
                    ClienteId = guardacliente9.UtilizadorId,
                    FuncionarioId = guardaoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = guardacliente9.Morada,
                    CodigoPostal = guardacliente9.CodigoPostal,
                    DistritosId = guarda.DistritosId,
                },

                  new Contratos
                {
                    UtilizadorId = guardacliente10.UtilizadorId,
                    ClienteId = guardacliente10.UtilizadorId,
                    FuncionarioId = guardaoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = guardacliente10.Morada,
                    CodigoPostal = guardacliente10.CodigoPostal,
                    DistritosId = guarda.DistritosId,
                },

                  new Contratos
                {
                    UtilizadorId = guardacliente11.UtilizadorId,
                    ClienteId = guardacliente11.UtilizadorId,
                    FuncionarioId = guardaoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = guardacliente11.Morada,
                    CodigoPostal = guardacliente11.CodigoPostal,
                    DistritosId = guarda.DistritosId,
                },


                  //Contratos dos Operadores de Leiria

                   new Contratos
                {
                    UtilizadorId = leiriacliente1.UtilizadorId,
                    ClienteId = leiriacliente1.UtilizadorId,
                    FuncionarioId = leiriaoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = leiriacliente1.Morada,
                    CodigoPostal = leiriacliente1.CodigoPostal,
                    DistritosId = leiria.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = leiriacliente2.UtilizadorId,
                    ClienteId = leiriacliente2.UtilizadorId,
                    FuncionarioId = leiriaoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = leiriacliente2.Morada,
                    CodigoPostal = leiriacliente2.CodigoPostal,
                    DistritosId = leiria.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = leiriacliente3.UtilizadorId,
                    ClienteId = leiriacliente3.UtilizadorId,
                    FuncionarioId = leiriaoperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = leiriacliente3.Morada,
                    CodigoPostal = leiriacliente3.CodigoPostal,
                    DistritosId = leiria.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = leiriacliente4.UtilizadorId,
                    ClienteId = leiriacliente4.UtilizadorId,
                    FuncionarioId = leiriaoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = leiriacliente4.Morada,
                    CodigoPostal = leiriacliente4.CodigoPostal,
                    DistritosId = leiria.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = leiriacliente5.UtilizadorId,
                    ClienteId = leiriacliente5.UtilizadorId,
                    FuncionarioId = leiriaoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = leiriacliente5.Morada,
                    CodigoPostal = leiriacliente5.CodigoPostal,
                    DistritosId = leiria.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = leiriacliente6.UtilizadorId,
                    ClienteId = leiriacliente6.UtilizadorId,
                    FuncionarioId = leiriaoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = leiriacliente6.Morada,
                    CodigoPostal = leiriacliente6.CodigoPostal,
                    DistritosId = leiria.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = leiriacliente7.UtilizadorId,
                    ClienteId = leiriacliente7.UtilizadorId,
                    FuncionarioId = leiriaoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = leiriacliente7.Morada,
                    CodigoPostal = leiriacliente7.CodigoPostal,
                    DistritosId = leiria.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = leiriacliente8.UtilizadorId,
                    ClienteId = leiriacliente8.UtilizadorId,
                    FuncionarioId = leiriaoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = leiriacliente8.Morada,
                    CodigoPostal = leiriacliente8.CodigoPostal,
                    DistritosId = leiria.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = leiriacliente9.UtilizadorId,
                    ClienteId = leiriacliente9.UtilizadorId,
                    FuncionarioId = leiriaoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = leiriacliente9.Morada,
                    CodigoPostal = leiriacliente9.CodigoPostal,
                    DistritosId = leiria.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = leiriacliente10.UtilizadorId,
                    ClienteId = leiriacliente10.UtilizadorId,
                    FuncionarioId = leiriaoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = leiriacliente10.Morada,
                    CodigoPostal = leiriacliente10.CodigoPostal,
                    DistritosId = leiria.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = leiriacliente11.UtilizadorId,
                    ClienteId = leiriacliente11.UtilizadorId,
                    FuncionarioId = leiriaoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = leiriacliente11.Morada,
                    CodigoPostal = leiriacliente11.CodigoPostal,
                    DistritosId = leiria.DistritosId,
                },

                  //Contratos dos Operadores de Lx
                   new Contratos
                {
                    UtilizadorId = lisboacliente1.UtilizadorId,
                    ClienteId = lisboacliente1.UtilizadorId,
                    FuncionarioId = lisboaoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = lisboacliente1.Morada,
                    CodigoPostal = lisboacliente1.CodigoPostal,
                    DistritosId = lx.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = lisboacliente2.UtilizadorId,
                    ClienteId = lisboacliente2.UtilizadorId,
                    FuncionarioId = lisboaoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = lisboacliente2.Morada,
                    CodigoPostal = lisboacliente2.CodigoPostal,
                    DistritosId = lx.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = lisboacliente3.UtilizadorId,
                    ClienteId = lisboacliente3.UtilizadorId,
                    FuncionarioId = lisboaoperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = lisboacliente3.Morada,
                    CodigoPostal = lisboacliente3.CodigoPostal,
                    DistritosId = lx.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = lisboacliente4.UtilizadorId,
                    ClienteId = lisboacliente4.UtilizadorId,
                    FuncionarioId = lisboaoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = lisboacliente4.Morada,
                    CodigoPostal = lisboacliente4.CodigoPostal,
                    DistritosId = lx.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = lisboacliente5.UtilizadorId,
                    ClienteId = lisboacliente5.UtilizadorId,
                    FuncionarioId = lisboaoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = lisboacliente5.Morada,
                    CodigoPostal = lisboacliente5.CodigoPostal,
                    DistritosId = lx.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = lisboacliente6.UtilizadorId,
                    ClienteId = lisboacliente6.UtilizadorId,
                    FuncionarioId = lisboaoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = lisboacliente6.Morada,
                    CodigoPostal = lisboacliente6.CodigoPostal,
                    DistritosId = lx.DistritosId,
                },

                    new Contratos
                {
                    UtilizadorId = lisboacliente7.UtilizadorId,
                    ClienteId = lisboacliente7.UtilizadorId,
                    FuncionarioId = lisboaoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = lisboacliente7.Morada,
                    CodigoPostal = lisboacliente7.CodigoPostal,
                    DistritosId = lx.DistritosId,
                },

                    new Contratos
                {
                    UtilizadorId = lisboacliente8.UtilizadorId,
                    ClienteId = lisboacliente8.UtilizadorId,
                    FuncionarioId = lisboaoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = lisboacliente8.Morada,
                    CodigoPostal = lisboacliente8.CodigoPostal,
                    DistritosId = lx.DistritosId,
                },

                    new Contratos
                {
                    UtilizadorId = lisboacliente9.UtilizadorId,
                    ClienteId = lisboacliente9.UtilizadorId,
                    FuncionarioId = lisboaoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = lisboacliente9.Morada,
                    CodigoPostal = lisboacliente9.CodigoPostal,
                    DistritosId = lx.DistritosId,
                },


                    new Contratos
                {
                    UtilizadorId = lisboacliente10.UtilizadorId,
                    ClienteId = lisboacliente10.UtilizadorId,
                    FuncionarioId = lisboaoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = lisboacliente10.Morada,
                    CodigoPostal = lisboacliente10.CodigoPostal,
                    DistritosId = lx.DistritosId,
                },

                    new Contratos
                {
                    UtilizadorId = lisboacliente11.UtilizadorId,
                    ClienteId = lisboacliente11.UtilizadorId,
                    FuncionarioId = lisboaoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = lisboacliente11.Morada,
                    CodigoPostal = lisboacliente11.CodigoPostal,
                    DistritosId = lx.DistritosId,
                },


                  //Contratos dos Operadores de Portalegre
                  new Contratos
                {
                    UtilizadorId = portalegrecliente1.UtilizadorId,
                    ClienteId = portalegrecliente1.UtilizadorId,
                    FuncionarioId = portalegreoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portalegrecliente1.Morada,
                    CodigoPostal = portalegrecliente1.CodigoPostal,
                    DistritosId = portalegre.DistritosId,
                },

                  new Contratos
                {
                    UtilizadorId = portalegrecliente2.UtilizadorId,
                    ClienteId = portalegrecliente2.UtilizadorId,
                    FuncionarioId = portalegreoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portalegrecliente2.Morada,
                    CodigoPostal = portalegrecliente2.CodigoPostal,
                    DistritosId = portalegre.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = portalegrecliente3.UtilizadorId,
                    ClienteId = portalegrecliente3.UtilizadorId,
                    FuncionarioId = portalegreoperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portalegrecliente3.Morada,
                    CodigoPostal = portalegrecliente3.CodigoPostal,
                    DistritosId = portalegre.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = portalegrecliente4.UtilizadorId,
                    ClienteId = portalegrecliente4.UtilizadorId,
                    FuncionarioId = portalegreoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portalegrecliente4.Morada,
                    CodigoPostal = portalegrecliente4.CodigoPostal,
                    DistritosId = portalegre.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = portalegrecliente5.UtilizadorId,
                    ClienteId = portalegrecliente5.UtilizadorId,
                    FuncionarioId = portalegreoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portalegrecliente5.Morada,
                    CodigoPostal = portalegrecliente5.CodigoPostal,
                    DistritosId = portalegre.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = portalegrecliente6.UtilizadorId,
                    ClienteId = portalegrecliente6.UtilizadorId,
                    FuncionarioId = portalegreoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portalegrecliente6.Morada,
                    CodigoPostal = portalegrecliente6.CodigoPostal,
                    DistritosId = portalegre.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = portalegrecliente7.UtilizadorId,
                    ClienteId = portalegrecliente7.UtilizadorId,
                    FuncionarioId = portalegreoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portalegrecliente7.Morada,
                    CodigoPostal = portalegrecliente7.CodigoPostal,
                    DistritosId = portalegre.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = portalegrecliente8.UtilizadorId,
                    ClienteId = portalegrecliente8.UtilizadorId,
                    FuncionarioId = portalegreoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portalegrecliente8.Morada,
                    CodigoPostal = portalegrecliente8.CodigoPostal,
                    DistritosId = portalegre.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = portalegrecliente9.UtilizadorId,
                    ClienteId = portalegrecliente9.UtilizadorId,
                    FuncionarioId = portalegreoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portalegrecliente9.Morada,
                    CodigoPostal = portalegrecliente9.CodigoPostal,
                    DistritosId = portalegre.DistritosId,
                },

                    new Contratos
                {
                    UtilizadorId = portalegrecliente10.UtilizadorId,
                    ClienteId = portalegrecliente10.UtilizadorId,
                    FuncionarioId = portalegreoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portalegrecliente10.Morada,
                    CodigoPostal = portalegrecliente10.CodigoPostal,
                    DistritosId = portalegre.DistritosId,
                },

                     new Contratos
                {
                    UtilizadorId = portalegrecliente11.UtilizadorId,
                    ClienteId = portalegrecliente11.UtilizadorId,
                    FuncionarioId = portalegreoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portalegrecliente11.Morada,
                    CodigoPostal = portalegrecliente11.CodigoPostal,
                    DistritosId = portalegre.DistritosId,
                },


                  //Contratos dos Operadores de Porto
                   new Contratos
                {
                    UtilizadorId = portocliente1.UtilizadorId,
                    ClienteId = portocliente1.UtilizadorId,
                    FuncionarioId = portoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portocliente1.Morada,
                    CodigoPostal = portocliente1.CodigoPostal,
                    DistritosId = porto.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = portocliente2.UtilizadorId,
                    ClienteId = portocliente2.UtilizadorId,
                    FuncionarioId = portoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portocliente2.Morada,
                    CodigoPostal = portocliente2.CodigoPostal,
                    DistritosId = porto.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = portocliente3.UtilizadorId,
                    ClienteId = portocliente3.UtilizadorId,
                    FuncionarioId = portoperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portocliente3.Morada,
                    CodigoPostal = portocliente3.CodigoPostal,
                    DistritosId = porto.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = portocliente4.UtilizadorId,
                    ClienteId = portocliente4.UtilizadorId,
                    FuncionarioId = portoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portocliente4.Morada,
                    CodigoPostal = portocliente4.CodigoPostal,
                    DistritosId = porto.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = portocliente5.UtilizadorId,
                    ClienteId = portocliente5.UtilizadorId,
                    FuncionarioId = portoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portocliente5.Morada,
                    CodigoPostal = portocliente5.CodigoPostal,
                    DistritosId = porto.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = portocliente6.UtilizadorId,
                    ClienteId = portocliente6.UtilizadorId,
                    FuncionarioId = portoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portocliente6.Morada,
                    CodigoPostal = portocliente6.CodigoPostal,
                    DistritosId = porto.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = portocliente7.UtilizadorId,
                    ClienteId = portocliente7.UtilizadorId,
                    FuncionarioId = portoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portocliente7.Morada,
                    CodigoPostal = portocliente7.CodigoPostal,
                    DistritosId = porto.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = portocliente8.UtilizadorId,
                    ClienteId = portocliente8.UtilizadorId,
                    FuncionarioId = portoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portocliente8.Morada,
                    CodigoPostal = portocliente8.CodigoPostal,
                    DistritosId = porto.DistritosId,
                },

                    new Contratos
                {
                    UtilizadorId = portocliente9.UtilizadorId,
                    ClienteId = portocliente9.UtilizadorId,
                    FuncionarioId = portoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portocliente9.Morada,
                    CodigoPostal = portocliente9.CodigoPostal,
                    DistritosId = porto.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = portocliente10.UtilizadorId,
                    ClienteId = portocliente10.UtilizadorId,
                    FuncionarioId = portoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portocliente10.Morada,
                    CodigoPostal = portocliente10.CodigoPostal,
                    DistritosId = porto.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = portocliente11.UtilizadorId,
                    ClienteId = portocliente11.UtilizadorId,
                    FuncionarioId = portoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = portocliente11.Morada,
                    CodigoPostal = portocliente11.CodigoPostal,
                    DistritosId = porto.DistritosId,
                },

                  //Contratos dos Operadores de Santarém
                   new Contratos
                {
                    UtilizadorId = santaremcliente1.UtilizadorId,
                    ClienteId = santaremcliente1.UtilizadorId,
                    FuncionarioId = santaremoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = santaremcliente1.Morada,
                    CodigoPostal = santaremcliente1.CodigoPostal,
                    DistritosId = santarem.DistritosId,
                },

                    new Contratos
                {
                    UtilizadorId = santaremcliente2.UtilizadorId,
                    ClienteId = santaremcliente2.UtilizadorId,
                    FuncionarioId = santaremoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = santaremcliente2.Morada,
                    CodigoPostal = santaremcliente2.CodigoPostal,
                    DistritosId = santarem.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = santaremcliente3.UtilizadorId,
                    ClienteId = santaremcliente3.UtilizadorId,
                    FuncionarioId = santaremoperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = santaremcliente3.Morada,
                    CodigoPostal = santaremcliente3.CodigoPostal,
                    DistritosId = santarem.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = santaremcliente4.UtilizadorId,
                    ClienteId = santaremcliente4.UtilizadorId,
                    FuncionarioId = santaremoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = santaremcliente4.Morada,
                    CodigoPostal = santaremcliente4.CodigoPostal,
                    DistritosId = santarem.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = santaremcliente5.UtilizadorId,
                    ClienteId = santaremcliente5.UtilizadorId,
                    FuncionarioId = santaremoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = santaremcliente5.Morada,
                    CodigoPostal = santaremcliente5.CodigoPostal,
                    DistritosId = santarem.DistritosId,
                },
                    new Contratos
                {
                    UtilizadorId = santaremcliente6.UtilizadorId,
                    ClienteId = santaremcliente6.UtilizadorId,
                    FuncionarioId = santaremoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = santaremcliente6.Morada,
                    CodigoPostal = santaremcliente6.CodigoPostal,
                    DistritosId = santarem.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = santaremcliente7.UtilizadorId,
                    ClienteId = santaremcliente7.UtilizadorId,
                    FuncionarioId = santaremoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = santaremcliente7.Morada,
                    CodigoPostal = santaremcliente7.CodigoPostal,
                    DistritosId = santarem.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = santaremcliente8.UtilizadorId,
                    ClienteId = santaremcliente8.UtilizadorId,
                    FuncionarioId = santaremoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = santaremcliente8.Morada,
                    CodigoPostal = santaremcliente8.CodigoPostal,
                    DistritosId = santarem.DistritosId,
                },
                      new Contratos
                {
                    UtilizadorId = santaremcliente9.UtilizadorId,
                    ClienteId = santaremcliente9.UtilizadorId,
                    FuncionarioId = santaremoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = santaremcliente9.Morada,
                    CodigoPostal = santaremcliente9.CodigoPostal,
                    DistritosId = santarem.DistritosId,
                },
                      new Contratos
                {
                    UtilizadorId = santaremcliente10.UtilizadorId,
                    ClienteId = santaremcliente10.UtilizadorId,
                    FuncionarioId = santaremoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = santaremcliente10.Morada,
                    CodigoPostal = santaremcliente10.CodigoPostal,
                    DistritosId = santarem.DistritosId,
                },
                      new Contratos
                {
                    UtilizadorId = santaremcliente11.UtilizadorId,
                    ClienteId = santaremcliente11.UtilizadorId,
                    FuncionarioId = santaremoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = santaremcliente11.Morada,
                    CodigoPostal = santaremcliente11.CodigoPostal,
                    DistritosId = santarem.DistritosId,
                },


                  //Contratos dos Operadores de Setúbal
                new Contratos
                {
                    UtilizadorId = setubalcliente1.UtilizadorId,
                    ClienteId = setubalcliente1.UtilizadorId,
                    FuncionarioId = setubaloperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = setubalcliente1.Morada,
                    CodigoPostal = setubalcliente1.CodigoPostal,
                    DistritosId = setubal.DistritosId,
                },

                new Contratos
                {
                    UtilizadorId = setubalcliente2.UtilizadorId,
                    ClienteId = setubalcliente2.UtilizadorId,
                    FuncionarioId = setubaloperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = setubalcliente2.Morada,
                    CodigoPostal = setubalcliente2.CodigoPostal,
                    DistritosId = setubal.DistritosId,
                },

                new Contratos
                {
                    UtilizadorId = setubalcliente3.UtilizadorId,
                    ClienteId = setubalcliente3.UtilizadorId,
                    FuncionarioId = setubaloperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = setubalcliente3.Morada,
                    CodigoPostal = setubalcliente3.CodigoPostal,
                    DistritosId = setubal.DistritosId,
                },
                new Contratos
                {
                    UtilizadorId = setubalcliente4.UtilizadorId,
                    ClienteId = setubalcliente4.UtilizadorId,
                    FuncionarioId = setubaloperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = setubalcliente4.Morada,
                    CodigoPostal = setubalcliente4.CodigoPostal,
                    DistritosId = setubal.DistritosId,
                },
                 new Contratos
                {
                    UtilizadorId = setubalcliente5.UtilizadorId,
                    ClienteId = setubalcliente5.UtilizadorId,
                    FuncionarioId = setubaloperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = setubalcliente5.Morada,
                    CodigoPostal = setubalcliente5.CodigoPostal,
                    DistritosId = setubal.DistritosId,
                },
                 new Contratos
                {
                    UtilizadorId = setubalcliente6.UtilizadorId,
                    ClienteId = setubalcliente6.UtilizadorId,
                    FuncionarioId = setubaloperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = setubalcliente6.Morada,
                    CodigoPostal = setubalcliente6.CodigoPostal,
                    DistritosId = setubal.DistritosId,
                },
                 new Contratos
                {
                    UtilizadorId = setubalcliente7.UtilizadorId,
                    ClienteId = setubalcliente7.UtilizadorId,
                    FuncionarioId = setubaloperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = setubalcliente7.Morada,
                    CodigoPostal = setubalcliente7.CodigoPostal,
                    DistritosId = setubal.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = setubalcliente8.UtilizadorId,
                    ClienteId = setubalcliente8.UtilizadorId,
                    FuncionarioId = setubaloperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = setubalcliente8.Morada,
                    CodigoPostal = setubalcliente8.CodigoPostal,
                    DistritosId = setubal.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = setubalcliente9.UtilizadorId,
                    ClienteId = setubalcliente9.UtilizadorId,
                    FuncionarioId = setubaloperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = setubalcliente9.Morada,
                    CodigoPostal = setubalcliente9.CodigoPostal,
                    DistritosId = setubal.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = setubalcliente10.UtilizadorId,
                    ClienteId = setubalcliente10.UtilizadorId,
                    FuncionarioId = setubaloperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = setubalcliente10.Morada,
                    CodigoPostal = setubalcliente10.CodigoPostal,
                    DistritosId = setubal.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = setubalcliente11.UtilizadorId,
                    ClienteId = setubalcliente11.UtilizadorId,
                    FuncionarioId = setubaloperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = setubalcliente11.Morada,
                    CodigoPostal = setubalcliente11.CodigoPostal,
                    DistritosId = setubal.DistritosId,
                },


                  //Contratos dos Operadores de Viana
                  new Contratos
                {
                    UtilizadorId = vianacliente1.UtilizadorId,
                    ClienteId = vianacliente1.UtilizadorId,
                    FuncionarioId = vianaoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vianacliente1.Morada,
                    CodigoPostal = vianacliente1.CodigoPostal,
                    DistritosId = viana.DistritosId,
                },

                   new Contratos
                {
                    UtilizadorId = vianacliente2.UtilizadorId,
                    ClienteId = vianacliente2.UtilizadorId,
                    FuncionarioId = vianaoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vianacliente2.Morada,
                    CodigoPostal = vianacliente2.CodigoPostal,
                    DistritosId = viana.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = vianacliente3.UtilizadorId,
                    ClienteId = vianacliente3.UtilizadorId,
                    FuncionarioId = vianaoperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vianacliente3.Morada,
                    CodigoPostal = vianacliente3.CodigoPostal,
                    DistritosId = viana.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = vianacliente4.UtilizadorId,
                    ClienteId = vianacliente4.UtilizadorId,
                    FuncionarioId = vianaoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vianacliente4.Morada,
                    CodigoPostal = vianacliente4.CodigoPostal,
                    DistritosId = viana.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = vianacliente5.UtilizadorId,
                    ClienteId = vianacliente5.UtilizadorId,
                    FuncionarioId = vianaoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vianacliente5.Morada,
                    CodigoPostal = vianacliente5.CodigoPostal,
                    DistritosId = viana.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = vianacliente6.UtilizadorId,
                    ClienteId = vianacliente6.UtilizadorId,
                    FuncionarioId = vianaoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vianacliente6.Morada,
                    CodigoPostal = vianacliente6.CodigoPostal,
                    DistritosId = viana.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = vianacliente7.UtilizadorId,
                    ClienteId = vianacliente7.UtilizadorId,
                    FuncionarioId = vianaoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vianacliente7.Morada,
                    CodigoPostal = vianacliente7.CodigoPostal,
                    DistritosId = viana.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = vianacliente8.UtilizadorId,
                    ClienteId = vianacliente8.UtilizadorId,
                    FuncionarioId = vianaoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vianacliente8.Morada,
                    CodigoPostal = vianacliente8.CodigoPostal,
                    DistritosId = viana.DistritosId,

                },
                   new Contratos
                {
                    UtilizadorId = vianacliente9.UtilizadorId,
                    ClienteId = vianacliente9.UtilizadorId,
                    FuncionarioId = vianaoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vianacliente9.Morada,
                    CodigoPostal = vianacliente9.CodigoPostal,
                    DistritosId = viana.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = vianacliente10.UtilizadorId,
                    ClienteId = vianacliente10.UtilizadorId,
                    FuncionarioId = vianaoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vianacliente10.Morada,
                    CodigoPostal = vianacliente10.CodigoPostal,
                    DistritosId = viana.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = vianacliente11.UtilizadorId,
                    ClienteId = vianacliente11.UtilizadorId,
                    FuncionarioId = vianaoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vianacliente11.Morada,
                    CodigoPostal = vianacliente11.CodigoPostal,
                    DistritosId = viana.DistritosId,
                },
                
                  //Contratos dos Operadores de Vila Real
                     new Contratos
                {
                    UtilizadorId = vilarealcliente1.UtilizadorId,
                    ClienteId = vilarealcliente1.UtilizadorId,
                    FuncionarioId = vilarealoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vilarealcliente1.Morada,
                    CodigoPostal = vilarealcliente1.CodigoPostal,
                    DistritosId = vilareal.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = vilarealcliente2.UtilizadorId,
                    ClienteId = vilarealcliente2.UtilizadorId,
                    FuncionarioId = vilarealoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vilarealcliente2.Morada,
                    CodigoPostal = vilarealcliente2.CodigoPostal,
                    DistritosId = vilareal.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = vilarealcliente3.UtilizadorId,
                    ClienteId = vilarealcliente3.UtilizadorId,
                    FuncionarioId = vilarealoperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vilarealcliente3.Morada,
                    CodigoPostal = vilarealcliente3.CodigoPostal,
                    DistritosId = vilareal.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = vilarealcliente4.UtilizadorId,
                    ClienteId = vilarealcliente4.UtilizadorId,
                    FuncionarioId = vilarealoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vilarealcliente4.Morada,
                    CodigoPostal = vilarealcliente4.CodigoPostal,
                    DistritosId = vilareal.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = vilarealcliente5.UtilizadorId,
                    ClienteId = vilarealcliente5.UtilizadorId,
                    FuncionarioId = vilarealoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vilarealcliente5.Morada,
                    CodigoPostal = vilarealcliente5.CodigoPostal,
                    DistritosId = vilareal.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = vilarealcliente6.UtilizadorId,
                    ClienteId = vilarealcliente6.UtilizadorId,
                    FuncionarioId = vilarealoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vilarealcliente6.Morada,
                    CodigoPostal = vilarealcliente6.CodigoPostal,
                    DistritosId = vilareal.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = vilarealcliente7.UtilizadorId,
                    ClienteId = vilarealcliente7.UtilizadorId,
                    FuncionarioId = vilarealoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vilarealcliente7.Morada,
                    CodigoPostal = vilarealcliente7.CodigoPostal,
                    DistritosId = vilareal.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = vilarealcliente8.UtilizadorId,
                    ClienteId = vilarealcliente8.UtilizadorId,
                    FuncionarioId = vilarealoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vilarealcliente8.Morada,
                    CodigoPostal = vilarealcliente8.CodigoPostal,
                    DistritosId = vilareal.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = vilarealcliente9.UtilizadorId,
                    ClienteId = vilarealcliente9.UtilizadorId,
                    FuncionarioId = vilarealoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vilarealcliente9.Morada,
                    CodigoPostal = vilarealcliente9.CodigoPostal,
                    DistritosId = vilareal.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = vilarealcliente10.UtilizadorId,
                    ClienteId = vilarealcliente10.UtilizadorId,
                    FuncionarioId = vilarealoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vilarealcliente10.Morada,
                    CodigoPostal = vilarealcliente10.CodigoPostal,
                    DistritosId = vilareal.DistritosId,
                },
                     new Contratos
                {
                    UtilizadorId = vilarealcliente11.UtilizadorId,
                    ClienteId = vilarealcliente11.UtilizadorId,
                    FuncionarioId = vilarealoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = vilarealcliente11.Morada,
                    CodigoPostal = vilarealcliente11.CodigoPostal,
                    DistritosId = vilareal.DistritosId,
                },


                  //Contratos dos Operadores de Viseu
            new Contratos
                {
                    UtilizadorId = viseucliente1.UtilizadorId,
                    ClienteId = viseucliente1.UtilizadorId,
                    FuncionarioId = viseuoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = viseucliente1.Morada,
                    CodigoPostal = viseucliente1.CodigoPostal,
                    DistritosId = viseu.DistritosId,
                },
            new Contratos
                {
                    UtilizadorId = viseucliente2.UtilizadorId,
                    ClienteId = viseucliente2.UtilizadorId,
                    FuncionarioId = viseuoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = viseucliente2.Morada,
                    CodigoPostal = viseucliente2.CodigoPostal,
                    DistritosId = viseu.DistritosId,
                },
            new Contratos
                {
                    UtilizadorId = viseucliente3.UtilizadorId,
                    ClienteId = viseucliente3.UtilizadorId,
                    FuncionarioId = viseuoperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = viseucliente3.Morada,
                    CodigoPostal = viseucliente3.CodigoPostal,
                    DistritosId = viseu.DistritosId,
                },
            new Contratos
                {
                    UtilizadorId = viseucliente4.UtilizadorId,
                    ClienteId = viseucliente4.UtilizadorId,
                    FuncionarioId = viseuoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = viseucliente4.Morada,
                    CodigoPostal = viseucliente4.CodigoPostal,
                    DistritosId = viseu.DistritosId,
                },
            new Contratos
                {
                    UtilizadorId = viseucliente5.UtilizadorId,
                    ClienteId = viseucliente5.UtilizadorId,
                    FuncionarioId = viseuoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = viseucliente5.Morada,
                    CodigoPostal = viseucliente5.CodigoPostal,
                    DistritosId = viseu.DistritosId,
                },
            new Contratos
                {
                    UtilizadorId = viseucliente6.UtilizadorId,
                    ClienteId = viseucliente6.UtilizadorId,
                    FuncionarioId = viseuoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = viseucliente6.Morada,
                    CodigoPostal = viseucliente6.CodigoPostal,
                    DistritosId = viseu.DistritosId,
                },
            new Contratos
                {
                    UtilizadorId = viseucliente7.UtilizadorId,
                    ClienteId = viseucliente7.UtilizadorId,
                    FuncionarioId = viseuoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = viseucliente7.Morada,
                    CodigoPostal = viseucliente7.CodigoPostal,
                    DistritosId = viseu.DistritosId,
                },
            new Contratos
                {
                    UtilizadorId = viseucliente8.UtilizadorId,
                    ClienteId = viseucliente8.UtilizadorId,
                    FuncionarioId = viseuoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = viseucliente8.Morada,
                    CodigoPostal = viseucliente8.CodigoPostal,
                    DistritosId = viseu.DistritosId,
                },
            new Contratos
                {
                    UtilizadorId = viseucliente9.UtilizadorId,
                    ClienteId = viseucliente9.UtilizadorId,
                    FuncionarioId = viseuoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = viseucliente9.Morada,
                    CodigoPostal = viseucliente9.CodigoPostal,
                    DistritosId = viseu.DistritosId,
                },
            new Contratos
                {
                    UtilizadorId = viseucliente10.UtilizadorId,
                    ClienteId = viseucliente10.UtilizadorId,
                    FuncionarioId = viseuoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = viseucliente10.Morada,
                    CodigoPostal = viseucliente10.CodigoPostal,
                    DistritosId = viseu.DistritosId,
                },
            new Contratos
                {
                    UtilizadorId = viseucliente11.UtilizadorId,
                    ClienteId = viseucliente11.UtilizadorId,
                    FuncionarioId = viseuoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = viseucliente11.Morada,
                    CodigoPostal = viseucliente11.CodigoPostal,
                    DistritosId = viseu.DistritosId,
                },

                  //Contratos dos Operadores de Açores
                  new Contratos
                {
                    UtilizadorId = acorescliente1.UtilizadorId,
                    ClienteId = acorescliente1.UtilizadorId,
                    FuncionarioId = acoresoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = acorescliente1.Morada,
                    CodigoPostal = acorescliente1.CodigoPostal,
                    DistritosId = acores.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = acorescliente2.UtilizadorId,
                    ClienteId = acorescliente2.UtilizadorId,
                    FuncionarioId = acoresoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = acorescliente2.Morada,
                    CodigoPostal = acorescliente2.CodigoPostal,
                    DistritosId = acores.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = acorescliente3.UtilizadorId,
                    ClienteId = acorescliente3.UtilizadorId,
                    FuncionarioId = acoresoperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = acorescliente3.Morada,
                    CodigoPostal = acorescliente3.CodigoPostal,
                    DistritosId = acores.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = acorescliente4.UtilizadorId,
                    ClienteId = acorescliente4.UtilizadorId,
                    FuncionarioId = acoresoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = acorescliente4.Morada,
                    CodigoPostal = acorescliente4.CodigoPostal,
                    DistritosId = acores.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = acorescliente5.UtilizadorId,
                    ClienteId = acorescliente5.UtilizadorId,
                    FuncionarioId = acoresoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = acorescliente5.Morada,
                    CodigoPostal = acorescliente5.CodigoPostal,
                    DistritosId = acores.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = acorescliente6.UtilizadorId,
                    ClienteId = acorescliente6.UtilizadorId,
                    FuncionarioId = acoresoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = acorescliente6.Morada,
                    CodigoPostal = acorescliente6.CodigoPostal,
                    DistritosId = acores.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = acorescliente7.UtilizadorId,
                    ClienteId = acorescliente7.UtilizadorId,
                    FuncionarioId = acoresoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = acorescliente7.Morada,
                    CodigoPostal = acorescliente7.CodigoPostal,
                    DistritosId = acores.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = acorescliente8.UtilizadorId,
                    ClienteId = acorescliente8.UtilizadorId,
                    FuncionarioId = acoresoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = acorescliente8.Morada,
                    CodigoPostal = acorescliente8.CodigoPostal,
                    DistritosId = acores.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = acorescliente9.UtilizadorId,
                    ClienteId = acorescliente9.UtilizadorId,
                    FuncionarioId = acoresoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = acorescliente9.Morada,
                    CodigoPostal = acorescliente9.CodigoPostal,
                    DistritosId = acores.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = acorescliente10.UtilizadorId,
                    ClienteId = acorescliente10.UtilizadorId,
                    FuncionarioId = acoresoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = acorescliente10.Morada,
                    CodigoPostal = acorescliente10.CodigoPostal,
                    DistritosId = acores.DistritosId,
                },
                  new Contratos
                {
                    UtilizadorId = acorescliente11.UtilizadorId,
                    ClienteId = acorescliente11.UtilizadorId,
                    FuncionarioId = acoresoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = acorescliente11.Morada,
                    CodigoPostal = acorescliente11.CodigoPostal,
                    DistritosId = acores.DistritosId,
                },

                  //Contratos dos Operadores de Madeira
                   new Contratos
                {
                    UtilizadorId = madeiracliente1.UtilizadorId,
                    ClienteId = madeiracliente1.UtilizadorId,
                    FuncionarioId = madeiraoperador1.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = madeiracliente1.Morada,
                    CodigoPostal = madeiracliente1.CodigoPostal,
                    DistritosId = madeira.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = madeiracliente2.UtilizadorId,
                    ClienteId = madeiracliente2.UtilizadorId,
                    FuncionarioId = madeiraoperador2.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = madeiracliente2.Morada,
                    CodigoPostal = madeiracliente2.CodigoPostal,
                    DistritosId = madeira.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = madeiracliente3.UtilizadorId,
                    ClienteId = madeiracliente3.UtilizadorId,
                    FuncionarioId = madeiraoperador3.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = madeiracliente3.Morada,
                    CodigoPostal = madeiracliente3.CodigoPostal,
                    DistritosId = madeira.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = madeiracliente4.UtilizadorId,
                    ClienteId = madeiracliente4.UtilizadorId,
                    FuncionarioId = madeiraoperador4.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = madeiracliente4.Morada,
                    CodigoPostal = madeiracliente4.CodigoPostal,
                    DistritosId = madeira.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = madeiracliente5.UtilizadorId,
                    ClienteId = madeiracliente5.UtilizadorId,
                    FuncionarioId = madeiraoperador5.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = madeiracliente5.Morada,
                    CodigoPostal = madeiracliente5.CodigoPostal,
                    DistritosId = madeira.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = madeiracliente6.UtilizadorId,
                    ClienteId = madeiracliente6.UtilizadorId,
                    FuncionarioId = madeiraoperador6.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = madeiracliente6.Morada,
                    CodigoPostal = madeiracliente6.CodigoPostal,
                    DistritosId = madeira.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = madeiracliente7.UtilizadorId,
                    ClienteId = madeiracliente7.UtilizadorId,
                    FuncionarioId = madeiraoperador7.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = madeiracliente7.Morada,
                    CodigoPostal = madeiracliente7.CodigoPostal,
                    DistritosId = madeira.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = madeiracliente8.UtilizadorId,
                    ClienteId = madeiracliente8.UtilizadorId,
                    FuncionarioId = madeiraoperador8.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = madeiracliente8.Morada,
                    CodigoPostal = madeiracliente8.CodigoPostal,
                    DistritosId = madeira.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = madeiracliente9.UtilizadorId,
                    ClienteId = madeiracliente9.UtilizadorId,
                    FuncionarioId = madeiraoperador9.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = madeiracliente9.Morada,
                    CodigoPostal = madeiracliente9.CodigoPostal,
                    DistritosId = madeira.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = madeiracliente10.UtilizadorId,
                    ClienteId = madeiracliente10.UtilizadorId,
                    FuncionarioId = madeiraoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = madeiracliente10.Morada,
                    CodigoPostal = madeiracliente10.CodigoPostal,
                    DistritosId = madeira.DistritosId,
                },
                   new Contratos
                {
                    UtilizadorId = madeiracliente11.UtilizadorId,
                    ClienteId = madeiracliente11.UtilizadorId,
                    FuncionarioId = madeiraoperador10.UtilizadorId,
                    PacoteId = pacoteRD4.PacoteId,
                    PromocoesId = natalM.PromocoesId,
                    DataInicio = natalM.DataInicio,
                    DataFim = natalM.DataInicio.AddYears(2),
                    Telefone = 231111111,
                    PrecoPacote = pacoteRD4.Preco,
                    NomePacote = pacoteRD4.Nome,
                    PromocaoDesc = natalM.PromocaoDesc,
                    PrecoFinal = pacoteRD4.Preco - natalM.PromocaoDesc,
                    Inactivo = false,
                    Morada = madeiracliente11.Morada,
                    CodigoPostal = madeiracliente11.CodigoPostal,
                    DistritosId = madeira.DistritosId,
                },




            });
            bd.SaveChanges();
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


                };
                bd.Pacotes.Add(pacotes);
                bd.SaveChanges();
            }
            return pacotes;
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

        internal static void InsereServicosContratos(Projeto_Lab_WebContext bd)
        {
            if (bd.ServicosContratos.Any()) return;
            List<ServicosPacotes> servicosNoPacote = new List<ServicosPacotes>();
            List<ServicosContratos> servicosNosContratos = new List<ServicosContratos>();

            foreach (var contrato in bd.Contratos)
            {
                foreach (var pacote in bd.ServicosPacotes)
                {
                    if (contrato.PacoteId == pacote.PacoteId)
                    {
                        servicosNoPacote.Add(pacote);
                    }
                }

                foreach (var item in servicosNoPacote)
                {
                    servicosNosContratos.Add(new ServicosContratos() { ServicoId = item.ServicoId, ContratoId = contrato.ContratoId });
                }
                servicosNoPacote.Clear();
            }
            foreach (var item in servicosNosContratos)
            {
                bd.ServicosContratos.Add(item);
            }
            bd.SaveChanges();


        }

        internal static void InsereDistritosPacotes(Projeto_Lab_WebContext bd)
        {
            if (bd.DistritosPacotes.Any()) return;
            List<Pacotes> pacotes = new List<Pacotes>();
            List<Distritos> distritos = new List<Distritos>();
            List<DistritosPacotes> distritospacotes = new List<DistritosPacotes>();


            foreach (var pacote in bd.Pacotes)
            {
                foreach (var distrito in bd.Distritos)
                {
                    distritospacotes.Add(new DistritosPacotes { PacoteId = pacote.PacoteId, DistritosId = distrito.DistritosId });

                }
            }
            foreach (var item in distritospacotes)
            {
                bd.DistritosPacotes.Add(item);
            }
            bd.SaveChanges();


        }

        internal static void InsereDistritosPromocoes(Projeto_Lab_WebContext bd)
        {
            if (bd.DistritosPromocoes.Any()) return;

            List<DistritosPromocoes> distritospromocoes = new List<DistritosPromocoes>();


            foreach (var promocao in bd.Promocoes)
            {
                foreach (var distrito in bd.Distritos)
                {
                    distritospromocoes.Add(new DistritosPromocoes { PromocoesId = promocao.PromocoesId, DistritosId = distrito.DistritosId });

                }
            }
            foreach (var item in distritospromocoes)
            {
                bd.DistritosPromocoes.Add(item);
            }
            bd.SaveChanges();

        }

    }
}
