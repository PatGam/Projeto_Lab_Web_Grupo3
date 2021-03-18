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

            //-------------------------- 1 AVEIRO------------------
            GaranteUtilizadores(bd, "Eduardo Pires", "286714957", new DateTime(2000, 01, 19), "Sargento Mor", "921234567", "eduardo.pires@RDtelecom.com", "3020-740", "Operador", false, 1);
            GaranteUtilizadores(bd, "Glória da Ascenção", "218120460", new DateTime(1988, 09, 21), "Rua Fernando Caldeira", "937654321", "gloria.ascencao@RDtelecom.com", "3754-501", "Operador", false, 1);
            GaranteUtilizadores(bd, "Maria Aparecida", "206602448", new DateTime(1977, 10, 01), "Rua Doutor Tomás Aquino", "927412589", "maria.aparecida@RDtelecom.com", "3800-523", "Operador", false, 1);
            GaranteUtilizadores(bd, "Bernardo Ribeiro", "292565798", new DateTime(1969, 03, 25), "Avenida Manuel Álvaro Lopes Pereira", "929632587", "bernado.ribeiro@RDtelecom.com", "3800-625", "Operador", false, 1);
            GaranteUtilizadores(bd, "Amadeu Almeida", "292565798", new DateTime(1979, 07, 16), "Avenida do Doutor Lourenço Peixinho", "921212145", "amadeu.almeida@RDtelecom.com", "3804-501", "Operador", false, 1);
            GaranteUtilizadores(bd, "José Socrates", "250559102", new DateTime(1958, 05, 05), "Viela da Capela", "920123201", "jose.socrates@RDtelecom.com", "3810-002", "Operador", false, 1);
            GaranteUtilizadores(bd, "Ana Brito", "275433641", new DateTime(2000, 09, 04), "Rua do Jardim", "929633230", "ana.brito@RDtelecom.com", "3054-001", "Operador", false, 1);
            GaranteUtilizadores(bd, "Luís Neto", "142518093", new DateTime(1985, 04, 04), "Avenida Comendador Augusto Martins Pereira", "920258847", "luis.neto@RDtelecom.com", "3744-002", "Operador", false, 1);
            GaranteUtilizadores(bd, "Freitas do Mondego", "172501482", new DateTime(1975, 02, 08), "Rua do Murtório Rochico ", "961477784", "freitas.mondego@RDtelecom.com", "3865-299", "Operador", false, 1);
            GaranteUtilizadores(bd, "João Cardoso", "265371988", new DateTime(1958, 12, 27), "Travessa da Lomba", "923212322", "joao.cardoso@RDtelecom.com", "3865-003", "Operador", false, 1);
            GaranteUtilizadores(bd, "Rita de Brandão", "244225834", new DateTime(1956, 08, 27), "Largo 5 de Outubro Jardim dos Campos Pares", "929988774", "rita.brandao@RDtelecom.com", "3880-006", "Operador", false, 1);

            //-------------------------- 2 BEJA------------------
            GaranteUtilizadores(bd, "Ramos de Oliveira", "286714957", new DateTime(2001, 01, 19), "Beco da Rua Acima", "963125474", "eduardo.pires@RDtelecom.com", "7960-002", "Operador", false, 2);
            GaranteUtilizadores(bd, "Catarina Alves", "218120460", new DateTime(1995, 09, 21), "Marmelar", "932789321", "gloria.ascencao@RDtelecom.com", "7960-001", "Operador", false, 2);
            GaranteUtilizadores(bd, "Rui del Nascimiento", "206602448", new DateTime(1965, 10, 11), "Rua Longa", "921023951", "maria.aparecida@RDtelecom.com", "7940-160", "Operador", false, 2);
            GaranteUtilizadores(bd, "Vasco Barreiros", "292565798", new DateTime(1962, 02, 25), "Avenida Manuel Álvaro Lopes Pereira", "927406381", "bernado.ribeiro@RDtelecom.com", "3800-625", "Operador", false, 2);
            GaranteUtilizadores(bd, "Mário Botelho", "292565798", new DateTime(1987, 07, 16), "Albergaria dos Fusos", "923148620", "amadeu.almeida@RDtelecom.com", "7940-411", "Operador", false, 2);
            GaranteUtilizadores(bd, "Lula de La Cruz", "250559102", new DateTime(1958, 04, 05), "Rua dos Lobos", "932951753", "jose.socrates@RDtelecom.com", "7920-005", "Operador", false, 2);
            GaranteUtilizadores(bd, "Paula Piruvato", "275433641", new DateTime(1992, 09, 04), "Largo dos Cadeirões", "935751153", "ana.brito@RDtelecom.com", "7920-002", "Operador", false, 2);
            GaranteUtilizadores(bd, "Thomas Lourenço", "142518093", new DateTime(1979, 04, 06), "Praça do Ultramar", "928963321", "luis.neto@RDtelecom.com", "7801-857", "Operador", false, 2);
            GaranteUtilizadores(bd, "Luís Smith", "172501482", new DateTime(1975, 06, 08), "Moitinhas", "960154784", "freitas.mondego@RDtelecom.com", "7665-803", "Operador", false, 2);
            GaranteUtilizadores(bd, "Márcia Wood", "265371988", new DateTime(1972, 11, 27), "Ribeira de Torquinhos", "921789321", "joao.cardoso@RDtelecom.com", "7665-814", "Operador", false, 2);
            GaranteUtilizadores(bd, "Jerónimo Graciano", "244225834", new DateTime(1956, 05, 22), "Rua da Cova da Burra", "928032965", "rita.brandao@RDtelecom.com", "7700-003", "Operador", false, 2);

            //-------------------------- 3 BRAGA------------------
            GaranteUtilizadores(bd, "Fernando Couto", "239833252", new DateTime(1977, 03, 19), "Rua dos Bombeiros Voluntários", "960023231", "fernado.couto@RDtelecom.com", "4700-002", "Operador", false, 3);
            GaranteUtilizadores(bd, "Deolinda Bacalhau", "292716222", new DateTime(2001, 05, 21), "Rua Professora Alda Brandão Real", "933584787", "deolinda.bacalhau@RDtelecom.com", "4700-002", "Operador", false, 3);
            GaranteUtilizadores(bd, "Ivanilda Pessoa", "206870523", new DateTime(1977, 08, 01), "Rua da Sobreira Frossos", "923001221", "ivanilda.pessoa@RDtelecom.com", "4700-441", "Operador", false, 3);
            GaranteUtilizadores(bd, "Onofre Galvão", "267894422", new DateTime(1969, 04, 30), "Largo de Maximinos", "928976413", "onofre.galvao@RDtelecom.com", "4700-999", "Operador", false, 3);
            GaranteUtilizadores(bd, "Ian Coelho", "249703238", new DateTime(2002, 01, 31), "Largo de São Tiago", "92587963", "ian.coelho@RDtelecom.com", "4704-504", "Operador", false, 3);
            GaranteUtilizadores(bd, "Ryan Oliveira", "240442571", new DateTime(1988, 03, 05), "Rua das Oliveiras", "920322333", "ryan.oliveira@RDtelecom.com", "4705-790", "Operador", false, 3);
            GaranteUtilizadores(bd, "Marizete Gillot", "285368559", new DateTime(1956, 10, 04), "Rua dos Caixoteiros", "922001789", "marizete.gillot@RDtelecom.com", "4705-001", "Operador", false, 3);
            GaranteUtilizadores(bd, "Beto da Alegria", "249227673", new DateTime(1957, 03, 17), "Rua Sem Nome", "925567841", "beto.alegria@RDtelecom.com", "4750-008", "Operador", false, 3);
            GaranteUtilizadores(bd, "Pinheiro dos Santos", "273654888", new DateTime(1970, 02, 28), "Travessa do Rio da Guarda", "921003288", "pinheiro.santos@RDtelecom.com", "4765-489", "Operador", false, 3);
            GaranteUtilizadores(bd, "Divina de Jesus", "268345139", new DateTime(1958, 11, 30), "Rua Cães de Pedra Lt 5", "921785432", "divina.jesus@RDtelecom.com", "4835-003", "Operador", false, 3);
            GaranteUtilizadores(bd, "Irina Leite", "263696340", new DateTime(1999, 10, 27), "Rua da Madalena", "929633600", "irina.leite@RDtelecom.com", "4835-511", "Operador", false, 3);

            //-------------------------- 4 BRAGANÇA------------------
            GaranteUtilizadores(bd, "Natally Domingues", "239833252", new DateTime(1974, 06, 19), "Bairro Moinho de Vento", "939007258", "natally.domingues@RDtelecom.com", "5140-005", "Operador", false, 4);
            GaranteUtilizadores(bd, "Nicolau Figueiras", "292716222", new DateTime(2001, 01, 21), "Quinta Lameira de Ferro", "932101491", "nicolau.figueiras@RDtelecom.com", "5140-135", "Operador", false, 4);
            GaranteUtilizadores(bd, "John Dias", "206870523", new DateTime(1987, 09, 03), "Rua Sem Nome 218 Bairro Além do Rio ", "966852031", "john.dias@RDtelecom.com", "5300-001", "Operador", false, 4);
            GaranteUtilizadores(bd, "Maria Leal", "267894422", new DateTime(1969, 09, 30), "Rua da Fragata", "923455896", "maria.leal@RDtelecom.com", "5385-101", "Operador", false, 4);
            GaranteUtilizadores(bd, "Isabel dos Santinhos", "249703238", new DateTime(1957, 05, 31), "Valbom Pitez", "922788996", "isabel.santinhos@RDtelecom.com", "5385-132", "Operador", false, 4);
            GaranteUtilizadores(bd, "Rui Fragona", "240442571", new DateTime(1988, 03, 07), "Azenha do Areal", "920335411", "rui.fragona@RDtelecom.com", "5370-131", "Operador", false, 4);
            GaranteUtilizadores(bd, "Dunildo de Boa Esperança", "285368559", new DateTime(2000, 10, 04), "Vale de Lobo", "929693914", "dunildo.esperanca@RDtelecom.com", "5370-102", "Operador", false, 4);
            GaranteUtilizadores(bd, "Carla Dorys", "249227673", new DateTime(1995, 08, 17), "Vilar Seco", "963321087", "carla.dorys@RDtelecom.com", "5350-204", "Operador", false, 4);
            GaranteUtilizadores(bd, "Birna de Oliveira", "273654888", new DateTime(1980, 02, 28), "Rua dos Combatentes da Grande Guerra", "930147852", "birna.oliveira@RDtelecom.com", "5301-861", "Operador", false, 4);
            GaranteUtilizadores(bd, "João Salgado", "268345139", new DateTime(1966, 11, 30), "Rua Cova da Beira", "926698230", "joao.salgado@RDtelecom.com", "5300-869", "Operador", false, 4);
            GaranteUtilizadores(bd, "Feitosa Pauleta", "263696340", new DateTime(1972, 10, 27), "Rotunda do Lavrador Bairro da Braguinha ", "921033025", "feitosa.pauleta@RDtelecom.com", "5300-420", "Operador", false, 4);

            //-------------------------- 5 CASTELO BRANCO------------------
            GaranteUtilizadores(bd, "Cláudia Vieira", "195173210", new DateTime(1965, 06, 19), "Rua das Rosas", "933896541", "claudia.vieira@RDtelecom.com", "6250-004", "Operador", false, 5);
            GaranteUtilizadores(bd, "Diogo Andrade", "136693199", new DateTime(1999, 01, 21), "Sítio do Cabecinho", "937258852", "diogo.andrade@RDtelecom.com", "6250-111", "Operador", false, 5);
            GaranteUtilizadores(bd, "Maria Ruah", "116663987", new DateTime(1988, 02, 03), "Quinta de Valverdinho", "963012547", "maria.ruah@RDtelecom.com", "6250-163", "Operador", false, 5);
            GaranteUtilizadores(bd, "Florbela Antunes", "127533818", new DateTime(1980, 09, 30), "Rua do Curral", "922013645", "florbela.antunes@RDtelecom.com", "6215-001", "Operador", false, 5);
            GaranteUtilizadores(bd, "António Antunes", "111712580", new DateTime(1974, 05, 31), "Rua Marquês de Ávila e Bolama", "928328961", "antonio.antunes@RDtelecom.com", "6201-001", "Operador", false, 5);
            GaranteUtilizadores(bd, "Liliana Aveiro", "183191404", new DateTime(2000, 03, 07), "Viela do Castelo", "927031759", "liliana.aveiro@RDtelecom.com", "6200-227", "Operador", false, 5);
            GaranteUtilizadores(bd, "Maria Pedroso", "161954464", new DateTime(2000, 10, 04), "Travessa das Trapas", "924630158", "maria.pedroso@RDtelecom.com", "6200-237", "Operador", false, 5);
            GaranteUtilizadores(bd, "Pedro Fernandes", "182518434", new DateTime(1957, 08, 17), "Bairro da Formiguinha Vila do Carvalho", "966332157", "pedro.fernandes@RDtelecom.com", "6200-241", "Operador", false, 5);
            GaranteUtilizadores(bd, "Miguel Moniz", "145814360", new DateTime(1962, 02, 30), "Rua das Tendas", "933212269", "miguel.moniz@RDtelecom.com", "6200-699", "Operador", false, 5);
            GaranteUtilizadores(bd, "Felisberto Ortiz", "114162123", new DateTime(1971, 02, 30), "Travessa dos Escabelados", "922100366", "felisberto.ortiz@RDtelecom.com", "6200-742", "Operador", false, 5);
            GaranteUtilizadores(bd, "António Sanchez", "163492115", new DateTime(1976, 11, 27), "Rua Canada", "925644710", "antonio.sanchez@RDtelecom.com", "6005-002", "Operador", false, 5);

            //-------------------------- 6 COIMBRA-----------------
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

            //------------------------------------------------------
            //-------------------------- 7 EVORA-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "238122549", new DateTime(1999, 07, 01), "Rua do Norte", "921456654", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 7);
            GaranteUtilizadores(bd, "Marlene Santos", "270613994", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "936825714", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 7);
            GaranteUtilizadores(bd, "João Ferreira", "205118615", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "920147963", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 7);
            GaranteUtilizadores(bd, "Tânia Sousa", "278968724", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "927369148", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 7);
            GaranteUtilizadores(bd, "Rute Martins", "220236410", new DateTime(1979, 10, 30), "Cruz de Ferro", "928741147", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 7);
            GaranteUtilizadores(bd, "Paulo Pedra", "201957060", new DateTime(1999, 07, 01), "Rua do Norte", "926951753", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 7);
            GaranteUtilizadores(bd, "Helder Copeto", "246386339", new DateTime(1999, 07, 01), "Rua do Norte", "920147895", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 7);
            GaranteUtilizadores(bd, "Miriam Falcão", "269577556", new DateTime(2000, 01, 01), "Vale Derradeiro", "922333698", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 7);
            GaranteUtilizadores(bd, "Célia Tomate", "253854040", new DateTime(1980, 09, 11), "Seladinhas", "920032147", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 7);
            GaranteUtilizadores(bd, "Tadeu Leão", "281567182", new DateTime(1975, 02, 08), "Flor da Rosa", "931456321", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 7);
            GaranteUtilizadores(bd, "Harley Guerra", "286365723", new DateTime(1955, 12, 24), "Beco da Alegria", "966333210", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 7);
            GaranteUtilizadores(bd, "Afonso Freira", "278661610", new DateTime(1956, 12, 05), "Beco das Cruzes", "933225871", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 7);

            //-------------------------- 8 FARO-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "298933896", new DateTime(1999, 07, 01), "Rua do Norte", "925874100", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 8);
            GaranteUtilizadores(bd, "Marlene Santos", "290825091", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "933302145", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 8);
            GaranteUtilizadores(bd, "João Ferreira", "256438676", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "932587410", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 8);
            GaranteUtilizadores(bd, "Tânia Sousa", "200101447", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "933666520", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 8);
            GaranteUtilizadores(bd, "Rute Martins", "213627736", new DateTime(1979, 10, 30), "Cruz de Ferro", "921230002", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 8);
            GaranteUtilizadores(bd, "Paulo Pedra", "254704085", new DateTime(1999, 07, 01), "Rua do Norte", "925666417", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 8);
            GaranteUtilizadores(bd, "Helder Copeto", "261746227", new DateTime(1999, 07, 01), "Rua do Norte", "936254102", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 8);
            GaranteUtilizadores(bd, "Miriam Falcão", "255512546", new DateTime(2000, 01, 01), "Vale Derradeiro", "920320001", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 8);
            GaranteUtilizadores(bd, "Célia Tomate", "203265424", new DateTime(1980, 09, 11), "Seladinhas", "967369874", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 8);
            GaranteUtilizadores(bd, "Tadeu Leão", "299944611", new DateTime(1975, 02, 08), "Flor da Rosa", "921321111", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 8);
            GaranteUtilizadores(bd, "Harley Guerra", "226395324", new DateTime(1955, 12, 24), "Beco da Alegria", "917854123", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 8);
            GaranteUtilizadores(bd, "Afonso Freira", "231898975", new DateTime(1956, 12, 05), "Beco das Cruzes", "917364825", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 8);


            //-------------------------- 9 GUARDA-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "240315170", new DateTime(1999, 07, 01), "Rua do Norte", "926999852", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 9);
            GaranteUtilizadores(bd, "Marlene Santos", "216994918", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "933022589", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 9);
            GaranteUtilizadores(bd, "João Ferreira", "262339374", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "922557410", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 9);
            GaranteUtilizadores(bd, "Tânia Sousa", "281167222", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "923654789", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 9);
            GaranteUtilizadores(bd, "Rute Martins", "253533643", new DateTime(1979, 10, 30), "Cruz de Ferro", "966968749", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 9);
            GaranteUtilizadores(bd, "Paulo Pedra", "254138349", new DateTime(1999, 07, 01), "Rua do Norte", "923456987", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 9);
            GaranteUtilizadores(bd, "Helder Copeto", "263953840", new DateTime(1999, 07, 01), "Rua do Norte", "910002658", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 9);
            GaranteUtilizadores(bd, "Miriam Falcão", "281900361", new DateTime(2000, 01, 01), "Vale Derradeiro", "92888632", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 9);
            GaranteUtilizadores(bd, "Célia Tomate", "206569327", new DateTime(1980, 09, 11), "Seladinhas", "963011456", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 9);
            GaranteUtilizadores(bd, "Tadeu Leão", "220640610", new DateTime(1975, 02, 08), "Flor da Rosa", "925666874", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 9);
            GaranteUtilizadores(bd, "Harley Guerra", "210346760", new DateTime(1955, 12, 24), "Beco da Alegria", "91025800", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 9);
            GaranteUtilizadores(bd, "Afonso Freira", "215494725", new DateTime(1956, 12, 05), "Beco das Cruzes", "936058777", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 9);

            //-------------------------- 10 LEIRIA-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "119888068", new DateTime(1999, 07, 01), "Rua do Norte", "923600144", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 10);
            GaranteUtilizadores(bd, "Marlene Santos", "131092812", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "930054711", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 10);
            GaranteUtilizadores(bd, "João Ferreira", "161270441", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "925632008", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 10);
            GaranteUtilizadores(bd, "Tânia Sousa", "140129375", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "963012547", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 10);
            GaranteUtilizadores(bd, "Rute Martins", "161728219", new DateTime(1979, 10, 30), "Cruz de Ferro", "921456920", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 10);
            GaranteUtilizadores(bd, "Paulo Pedra", "175938652", new DateTime(1999, 07, 01), "Rua do Norte", "923001458", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 10);
            GaranteUtilizadores(bd, "Helder Copeto", "163520500", new DateTime(1999, 07, 01), "Rua do Norte", "931478569", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 10);
            GaranteUtilizadores(bd, "Miriam Falcão", "103294708", new DateTime(2000, 01, 01), "Vale Derradeiro", "968547000", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 10);
            GaranteUtilizadores(bd, "Célia Tomate", "109509552", new DateTime(1980, 09, 11), "Seladinhas", "922365009", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 10);
            GaranteUtilizadores(bd, "Tadeu Leão", "163600937", new DateTime(1975, 02, 08), "Flor da Rosa", "967896333", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 10);
            GaranteUtilizadores(bd, "Harley Guerra", "195614313", new DateTime(1955, 12, 24), "Beco da Alegria", "910258963", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 10);
            GaranteUtilizadores(bd, "Afonso Freira", "116386428", new DateTime(1956, 12, 05), "Beco das Cruzes", "939391250", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 10);


            //-------------------------- 11 LISBOA-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "126914966", new DateTime(1999, 07, 01), "Rua do Norte", "924141230", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 11);
            GaranteUtilizadores(bd, "Marlene Santos", "196656087", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "937182456", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 11);
            GaranteUtilizadores(bd, "João Ferreira", "176965173", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "931773910", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 11);
            GaranteUtilizadores(bd, "Tânia Sousa", "110466721", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "917182935", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 11);
            GaranteUtilizadores(bd, "Rute Martins", "171941195", new DateTime(1979, 10, 30), "Cruz de Ferro", "961455620", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 11);
            GaranteUtilizadores(bd, "Paulo Pedra", "164398112", new DateTime(1999, 07, 01), "Rua do Norte", "967410226", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 11);
            GaranteUtilizadores(bd, "Helder Copeto", "133792285", new DateTime(1999, 07, 01), "Rua do Norte", "937852013", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 11);
            GaranteUtilizadores(bd, "Miriam Falcão", "141553898", new DateTime(2000, 01, 01), "Vale Derradeiro", "931456110", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 11);
            GaranteUtilizadores(bd, "Célia Tomate", "177572280", new DateTime(1980, 09, 11), "Seladinhas", "969391789", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 11);
            GaranteUtilizadores(bd, "Tadeu Leão", "150336322", new DateTime(1975, 02, 08), "Flor da Rosa", "919320365", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 11);
            GaranteUtilizadores(bd, "Harley Guerra", "153510340", new DateTime(1955, 12, 24), "Beco da Alegria", "932514789", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 11);
            GaranteUtilizadores(bd, "Afonso Freira", "170633977", new DateTime(1956, 12, 05), "Beco das Cruzes", "930258789", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 11);

            //-------------------------- 12 PORTALEGRE-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "246991585", new DateTime(1999, 07, 01), "Rua do Norte", "969691321", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 12);
            GaranteUtilizadores(bd, "Marlene Santos", "207370133", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "936285714", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 12);
            GaranteUtilizadores(bd, "João Ferreira", "258078286", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "921326554", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 12);
            GaranteUtilizadores(bd, "Tânia Sousa", "292120265", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "925632214", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 12);
            GaranteUtilizadores(bd, "Rute Martins", "210764333", new DateTime(1979, 10, 30), "Cruz de Ferro", "960321123", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 12);
            GaranteUtilizadores(bd, "Paulo Pedra", "246103230", new DateTime(1999, 07, 01), "Rua do Norte", "911233698", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 12);
            GaranteUtilizadores(bd, "Helder Copeto", "247266221", new DateTime(1999, 07, 01), "Rua do Norte", "936200145", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 12);
            GaranteUtilizadores(bd, "Miriam Falcão", "265156343", new DateTime(2000, 01, 01), "Vale Derradeiro", "968574123", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 12);
            GaranteUtilizadores(bd, "Célia Tomate", "284225959", new DateTime(1980, 09, 11), "Seladinhas", "961425632", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 12);
            GaranteUtilizadores(bd, "Tadeu Leão", "256300291", new DateTime(1975, 02, 08), "Flor da Rosa", "916914785", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 12);
            GaranteUtilizadores(bd, "Harley Guerra", "274980398", new DateTime(1955, 12, 24), "Beco da Alegria", "923654782", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 12);
            GaranteUtilizadores(bd, "Afonso Freira", "270511059", new DateTime(1956, 12, 05), "Beco das Cruzes", "923654741", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 12);

            //-------------------------- 13 PORTO-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "232501173", new DateTime(1999, 07, 01), "Rua do Norte", "968574000", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 13);
            GaranteUtilizadores(bd, "Marlene Santos", "255170262", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "933220655", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 13);
            GaranteUtilizadores(bd, "João Ferreira", "279641966", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "923002564", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 13);
            GaranteUtilizadores(bd, "Tânia Sousa", "265227186", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "968321008", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 13);
            GaranteUtilizadores(bd, "Rute Martins", "220300828", new DateTime(1979, 10, 30), "Cruz de Ferro", "925654197", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 13);
            GaranteUtilizadores(bd, "Paulo Pedra", "215830300", new DateTime(1999, 07, 01), "Rua do Norte", "923685203", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 13);
            GaranteUtilizadores(bd, "Helder Copeto", "222960540", new DateTime(1999, 07, 01), "Rua do Norte", "923654780", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 13);
            GaranteUtilizadores(bd, "Miriam Falcão", "204095387", new DateTime(2000, 01, 01), "Vale Derradeiro", "936002365", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 13);
            GaranteUtilizadores(bd, "Célia Tomate", "240389263", new DateTime(1980, 09, 11), "Seladinhas", "927183608", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 13);
            GaranteUtilizadores(bd, "Tadeu Leão", "210053895", new DateTime(1975, 02, 08), "Flor da Rosa", "925328961", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 13);
            GaranteUtilizadores(bd, "Harley Guerra", "267983921", new DateTime(1955, 12, 24), "Beco da Alegria", "968321520", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 13);
            GaranteUtilizadores(bd, "Afonso Freira", "207692670", new DateTime(1956, 12, 05), "Beco das Cruzes", "930221459", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 13);

            //-------------------------- 14 SANTAREM-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "102923698", new DateTime(1999, 07, 01), "Rua do Norte", "917896325", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 14);
            GaranteUtilizadores(bd, "Marlene Santos", "167804812", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "969587542", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 14);
            GaranteUtilizadores(bd, "João Ferreira", "179394614", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "932102548", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 14);
            GaranteUtilizadores(bd, "Tânia Sousa", "134904710", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "963214520", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 14);
            GaranteUtilizadores(bd, "Rute Martins", "194846377", new DateTime(1979, 10, 30), "Cruz de Ferro", "939963210", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 14);
            GaranteUtilizadores(bd, "Paulo Pedra", "130908010", new DateTime(1999, 07, 01), "Rua do Norte", "925964874", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 14);
            GaranteUtilizadores(bd, "Helder Copeto", "137377924", new DateTime(1999, 07, 01), "Rua do Norte", "965412088", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 14);
            GaranteUtilizadores(bd, "Miriam Falcão", "193317842", new DateTime(2000, 01, 01), "Vale Derradeiro", "924863210", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 14);
            GaranteUtilizadores(bd, "Célia Tomate", "187836825", new DateTime(1980, 09, 11), "Seladinhas", "920258885", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 14);
            GaranteUtilizadores(bd, "Tadeu Leão", "116024879", new DateTime(1975, 02, 08), "Flor da Rosa", "967862111", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 14);
            GaranteUtilizadores(bd, "Harley Guerra", "194892441", new DateTime(1955, 12, 24), "Beco da Alegria", "922587456", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 14);
            GaranteUtilizadores(bd, "Afonso Freira", "143171410", new DateTime(1956, 12, 05), "Beco das Cruzes", "932008521", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 14);

            //-------------------------- 15 SETUBAL-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "159738296", new DateTime(1999, 07, 01), "Rua do Norte", "914753951", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 15);
            GaranteUtilizadores(bd, "Marlene Santos", "115818910", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "960225478", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 15);
            GaranteUtilizadores(bd, "João Ferreira", "125484038", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "926715826", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 15);
            GaranteUtilizadores(bd, "Tânia Sousa", "120730464", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "965874100", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 15);
            GaranteUtilizadores(bd, "Rute Martins", "107984512", new DateTime(1979, 10, 30), "Cruz de Ferro", "926548222", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 15);
            GaranteUtilizadores(bd, "Paulo Pedra", "140414878", new DateTime(1999, 07, 01), "Rua do Norte", "960321489", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 15);
            GaranteUtilizadores(bd, "Helder Copeto", "174218990", new DateTime(1999, 07, 01), "Rua do Norte", "966999852", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 15);
            GaranteUtilizadores(bd, "Miriam Falcão", "147726387", new DateTime(2000, 01, 01), "Vale Derradeiro", "914852684", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 15);
            GaranteUtilizadores(bd, "Célia Tomate", "188485481", new DateTime(1980, 09, 11), "Seladinhas", "923355874", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 15);
            GaranteUtilizadores(bd, "Tadeu Leão", "180639439", new DateTime(1975, 02, 08), "Flor da Rosa", "920333658", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 15);
            GaranteUtilizadores(bd, "Harley Guerra", "164580247", new DateTime(1955, 12, 24), "Beco da Alegria", "968321450", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 15);
            GaranteUtilizadores(bd, "Afonso Freira", "178949655", new DateTime(1956, 12, 05), "Beco das Cruzes", "968532000", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 15);

            //-------------------------- 16 VIANA DO CASTELO-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "283312491", new DateTime(1999, 07, 01), "Rua do Norte", "918654654", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 16);
            GaranteUtilizadores(bd, "Marlene Santos", "292990308", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "965888970", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 16);
            GaranteUtilizadores(bd, "João Ferreira", "237628317", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "963210337", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 16);
            GaranteUtilizadores(bd, "Tânia Sousa", "250558637", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "967520147", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 16);
            GaranteUtilizadores(bd, "Rute Martins", "266466117", new DateTime(1979, 10, 30), "Cruz de Ferro", "923117852", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 16);
            GaranteUtilizadores(bd, "Paulo Pedra", "296425150", new DateTime(1999, 07, 01), "Rua do Norte", "935888723", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 16);
            GaranteUtilizadores(bd, "Helder Copeto", "286887100", new DateTime(1999, 07, 01), "Rua do Norte", "966541112", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 16);
            GaranteUtilizadores(bd, "Miriam Falcão", "238294749", new DateTime(2000, 01, 01), "Vale Derradeiro", "963325559", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 16);
            GaranteUtilizadores(bd, "Célia Tomate", "241415659", new DateTime(1980, 09, 11), "Seladinhas", "923698777", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 16);
            GaranteUtilizadores(bd, "Tadeu Leão", "291340725", new DateTime(1975, 02, 08), "Flor da Rosa", "912152033", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 16);
            GaranteUtilizadores(bd, "Harley Guerra", "292585438", new DateTime(1955, 12, 24), "Beco da Alegria", "965321111", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 16);
            GaranteUtilizadores(bd, "Afonso Freira", "280477228", new DateTime(1956, 12, 05), "Beco das Cruzes", "932654780", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 16);

            //-------------------------- 17 VILA REAL-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "226746380", new DateTime(1999, 07, 01), "Rua do Norte", "966987785", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 17);
            GaranteUtilizadores(bd, "Marlene Santos", "278338682", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "932654120", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 17);
            GaranteUtilizadores(bd, "João Ferreira", "242584799", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "925669850", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 17);
            GaranteUtilizadores(bd, "Tânia Sousa", "203240995", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "920357892", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 17);
            GaranteUtilizadores(bd, "Rute Martins", "215600061", new DateTime(1979, 10, 30), "Cruz de Ferro", "968321025", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 17);
            GaranteUtilizadores(bd, "Paulo Pedra", "206368330", new DateTime(1999, 07, 01), "Rua do Norte", "925841003", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 17);
            GaranteUtilizadores(bd, "Helder Copeto", "261055097", new DateTime(1999, 07, 01), "Rua do Norte", "925632145", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 17);
            GaranteUtilizadores(bd, "Miriam Falcão", "222266902", new DateTime(2000, 01, 01), "Vale Derradeiro", "963221058", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 17);
            GaranteUtilizadores(bd, "Célia Tomate", "243715790", new DateTime(1980, 09, 11), "Seladinhas", "925621489", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 17);
            GaranteUtilizadores(bd, "Tadeu Leão", "233428267", new DateTime(1975, 02, 08), "Flor da Rosa", "962087536", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 17);
            GaranteUtilizadores(bd, "Harley Guerra", "268256683", new DateTime(1955, 12, 24), "Beco da Alegria", "923698520", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 17);
            GaranteUtilizadores(bd, "Afonso Freira", "277466563", new DateTime(1956, 12, 05), "Beco das Cruzes", "938219227", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 17);

            //-------------------------- 18 VISEU-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "183894359", new DateTime(1999, 07, 01), "Rua do Norte", "965412200", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 18);
            GaranteUtilizadores(bd, "Marlene Santos", "103467882", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "928321485", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 18);
            GaranteUtilizadores(bd, "João Ferreira", "155241869", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "965874448", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 18);
            GaranteUtilizadores(bd, "Tânia Sousa", "143563157", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "932335920", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 18);
            GaranteUtilizadores(bd, "Rute Martins", "172309840", new DateTime(1979, 10, 30), "Cruz de Ferro", "935852005", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 18);
            GaranteUtilizadores(bd, "Paulo Pedra", "182643603", new DateTime(1999, 07, 01), "Rua do Norte", "910223658", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 18);
            GaranteUtilizadores(bd, "Helder Copeto", "165569204", new DateTime(1999, 07, 01), "Rua do Norte", "923620018", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 18);
            GaranteUtilizadores(bd, "Miriam Falcão", "176401890", new DateTime(2000, 01, 01), "Vale Derradeiro", "968412339", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 18);
            GaranteUtilizadores(bd, "Célia Tomate", "194866360", new DateTime(1980, 09, 11), "Seladinhas", "925896552", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 18);
            GaranteUtilizadores(bd, "Tadeu Leão", "173792294", new DateTime(1975, 02, 08), "Flor da Rosa", "921332068", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 18);
            GaranteUtilizadores(bd, "Harley Guerra", "103649492", new DateTime(1955, 12, 24), "Beco da Alegria", "915735255", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 18);
            GaranteUtilizadores(bd, "Afonso Freira", "156449307", new DateTime(1956, 12, 05), "Beco das Cruzes", "937190258", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 18);

            //-------------------------- 19 AÇORES-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "120771314", new DateTime(1999, 07, 01), "Rua do Norte", "930005874", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 19);
            GaranteUtilizadores(bd, "Marlene Santos", "137971443", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "965320005", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 19);
            GaranteUtilizadores(bd, "João Ferreira", "152267387", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "961742008", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 19);
            GaranteUtilizadores(bd, "Tânia Sousa", "142615889", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "961325698", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 19);
            GaranteUtilizadores(bd, "Rute Martins", "144505665", new DateTime(1979, 10, 30), "Cruz de Ferro", "930014789", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 19);
            GaranteUtilizadores(bd, "Paulo Pedra", "167301900", new DateTime(1999, 07, 01), "Rua do Norte", "965874123", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 19);
            GaranteUtilizadores(bd, "Helder Copeto", "174189800", new DateTime(1999, 07, 01), "Rua do Norte", "91523321", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 19);
            GaranteUtilizadores(bd, "Miriam Falcão", "139100873", new DateTime(2000, 01, 01), "Vale Derradeiro", "925879411", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 19);
            GaranteUtilizadores(bd, "Célia Tomate", "174957050", new DateTime(1980, 09, 11), "Seladinhas", "926557201", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 19);
            GaranteUtilizadores(bd, "Tadeu Leão", "119348470", new DateTime(1975, 02, 08), "Flor da Rosa", "961741211", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 19);
            GaranteUtilizadores(bd, "Harley Guerra", "117424919", new DateTime(1955, 12, 24), "Beco da Alegria", "911577821", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 19);
            GaranteUtilizadores(bd, "Afonso Freira", "107167727", new DateTime(1956, 12, 05), "Beco das Cruzes", "937888541", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 19);

            //-------------------------- 20 MADEIRA-----------------
            GaranteUtilizadores(bd, "Patrícia Gomes", "113150814", new DateTime(1999, 07, 01), "Rua do Norte", "965321002", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 20);
            GaranteUtilizadores(bd, "Marlene Santos", "184785715", new DateTime(1988, 11, 21), "Rua Particular Ladeira do Baptista", "938520366", "marlene.satos@RDtelecom.com", "3030-253", "Operador", false, 20);
            GaranteUtilizadores(bd, "João Ferreira", "170288900", new DateTime(1978, 07, 01), "Avenida Saraiva de Carvalho", "968741250", "joao.ferreira@RDtelecom.com", "3084-501", "Operador", false, 20);
            GaranteUtilizadores(bd, "Tânia Sousa", "129628522", new DateTime(1969, 06, 06), "Pátio do Cabo do Lugar", "912335620", "tania-sousa@RDtelecom.com", "3400-215", "Operador", false, 20);
            GaranteUtilizadores(bd, "Rute Martins", "137275862", new DateTime(1979, 10, 30), "Cruz de Ferro", "927415620", "rute.martins@RDtelecom.com", "3000-295", "Operador", false, 20);
            GaranteUtilizadores(bd, "Paulo Pedra", "100247520", new DateTime(1999, 07, 01), "Rua do Norte", "965327882", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 20);
            GaranteUtilizadores(bd, "Helder Copeto", "127523502", new DateTime(1999, 07, 01), "Rua do Norte", "924710655", "patricia.gomes@RDtelecom.com", "3000-295", "Operador", false, 20);
            GaranteUtilizadores(bd, "Miriam Falcão", "172885205", new DateTime(2000, 01, 01), "Vale Derradeiro", "974521333", "miriam.falcao@RDtelecom.com", "3320-002", "Operador", false, 20);
            GaranteUtilizadores(bd, "Célia Tomate", "170898610", new DateTime(1980, 09, 11), "Seladinhas", "965824110", "celia.tomate@RDtelecom.com", "3320-367", "Operador", false, 20);
            GaranteUtilizadores(bd, "Tadeu Leão", "169789560", new DateTime(1975, 02, 08), "Flor da Rosa", "932226987", "tadeu.leao@RDtelecom.com", "3040-471", "Operador", false, 20);
            GaranteUtilizadores(bd, "Harley Guerra", "139861750", new DateTime(1955, 12, 24), "Beco da Alegria", "915738522", "harley.guerra@RDtelecom.com", "3025-129", "Operador", false, 20);
            GaranteUtilizadores(bd, "Afonso Freira", "158218310", new DateTime(1956, 12, 05), "Beco das Cruzes", "932165420", "afonso.freira@RDtelecom.com", "3000-133 ", "Operador", false, 20);

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

