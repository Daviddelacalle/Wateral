
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CEN.Wateral;
using WateralGenNHibernate.CAD.Wateral;

//extras
using System.Linq;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                /*
                // Insert the initilizations of entities using the CEN classes
                DateTime nacimiento = new DateTime(1997, 10, 1);
                DateTime fechafin = new DateTime(2018, 01, 10);
                DateTime manana = new DateTime(2018, 01, 12);
                DateTime domingo = new DateTime(2018, 01, 14);
                DateTime lunes = new DateTime(2018, 01, 15);
                DateTime hora = new DateTime(2008, 01, 13, 11, 00, 0);
                DateTime fin1 = new DateTime(2008, 01, 13, 11, 00, 0);
                DateTime hora2 = new DateTime(2008, 4, 13, 15, 00, 0);
                DateTime fin2 = new DateTime(2008, 4, 13, 18, 00, 0);
                DateTime hora3 = new DateTime(2008, 4, 14, 12, 00, 0);
                DateTime fin3 = new DateTime(2008, 4, 14, 15, 00, 0);
                DateTime hora4 = new DateTime(2008, 4, 14, 10, 00, 0);

                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");
                ProfesorCEN profesor = new ProfesorCEN ();
                UserRegistradoCEN user_gen = new UserRegistradoCEN();
                string profe = user_gen.New_("bartolo@mellamo.com", "Bart", "Bartolomé", "Patriarka", "PutabidaXD", nacimiento, "imagen1.jpg");
                string profe1 = user_gen.New_("federostia@pati.es", "Fede", "Federico", "iuytfds", "1234", nacimiento, "imagen1.jpg");
                string profe2 = user_gen.New_("gust@vo.com", "Gus", "Gush", "juy2ujf", "1234", nacimiento, "imagen");
                string profe3 = user_gen.New_("heisenberg@eeuu.com", "Heis", "Heisenberg", "2354rte", "1234", nacimiento, "imagen");
                string profe4 = user_gen.New_("ladea@dea.com", "DEA", "LaDea", "2ed45v3x", "1234", nacimiento, "imagen");
                string profe5 = user_gen.New_("batman@gotham.com", "Bat", "Batman", "45tv4y3w4", "1234", nacimiento, "imagen");

                int profesor1 = profesor.New_("esdfsdsdf", "EveryDay", profe, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.kitesurf);
                int profesor2 = profesor.New_("34tswrdfdf", "Verano", profe1, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.kitesurf);
                int profesor3 = profesor.New_("4yh4wtrwsg", "Agosto", profe2, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.windsurf);
                int profesor4 = profesor.New_("sw4gsgstww", "Agosto", profe3, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.windsurf);
                int profesor5 = profesor.New_("wet4wtvgcs", "Agosto", profe4, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.sup);
                int profesor6 = profesor.New_("w4tsw4twst", "Agosto", profe5, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.vela);
                

                //Creaci�n de curso

                CursoCEN cursoCEN = new CursoCEN ();

                int kitesurf = cursoCEN.New_ (200, 6, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.kitesurf, "Iniciación", DateTime.Today, fechafin, "kitesurf.jpg");
                int kitesurfP = cursoCEN.New_ (200, 6, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.kitesurf, "Perfeccionamiento", DateTime.Today, fechafin, "kitesurf2.jpg");
                int kitesurfA = cursoCEN.New_ (60, 1, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.kitesurf, "Freestyle", DateTime.Today, fechafin, "kitesurf3.jpg");

                int windsurf = cursoCEN.New_ (150, 6, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.windsurf, "Iniciación", DateTime.Today, fechafin, "windsurf.jpg");
                int windsurfA = cursoCEN.New_ (150, 6, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.windsurf, "Avanzado", DateTime.Today, fechafin, "windsurfA.jpg");

                int paddlesurf = cursoCEN.New_ (100, 2, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.sup, "Iniciación", DateTime.Today, fechafin, "sup.jpg");
                int paddlesurfOlas = cursoCEN.New_ (240, 10, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.sup, "Olas", DateTime.Today, fechafin, "supOlas.jpg");

                int vela = cursoCEN.New_ (200, 10, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.vela, "Básico", DateTime.Today, fechafin, "vela.jpg");


                GrupoCEN grupoCEN = new GrupoCEN();
                int grupo1 = grupoCEN.New_(kitesurf, profesor1, 4, "Sabado y Domingo de 11:00 a 14:00");
                int grupo2 = grupoCEN.New_(kitesurf, profesor2, 4, "Sabado y Domingo de 11:00 a 14:00");
                int grupo3 = grupoCEN.New_(kitesurfP, profesor2, 2, "Sabado y Domingo de 15:00 a 18:00");
                int grupo4 = grupoCEN.New_(kitesurfA, profesor1, 1, "Lunes y miércoles de 12:00 a 15:00");
                int grupoWind1 = grupoCEN.New_(windsurf, profesor3, 6, "Domingos de 09:00 a 12:00");
                int grupoWind2 = grupoCEN.New_(windsurfA, profesor3, 6, "Domingos de 09:00 a 12:00");
                int grupoWind3 = grupoCEN.New_(windsurfA, profesor4, 6, "Domingos de 12:00 a 15:00");
                int grupoSup1 = grupoCEN.New_(paddlesurf, profesor5, 10, "Domingos de 10:00 a 12:00");
                int grupoVela1 = grupoCEN.New_(vela, profesor6, 6, "Domingos de 10:00 a 12:00");

                ClaseCEN creadorclases = new ClaseCEN();

                int claseKite1 = creadorclases.New_(grupo1, manana, hora, fin1);
                int claseKite2 = creadorclases.New_(grupo2, manana, hora, fin1);
                int claseKite3 = creadorclases.New_(grupo3, lunes, hora2, fin2);
                int claseKite4 = creadorclases.New_(grupo3, lunes, hora3, fin3);
                int claseKite5 = creadorclases.New_(grupo3, lunes, hora3, fin3);
                int claseWind1 = creadorclases.New_(grupoWind1, domingo, hora, fin1);
                int claseWind2 = creadorclases.New_(grupoWind2, domingo, hora, fin1);
                int claseWind3 = creadorclases.New_(grupoWind3, domingo, hora3, fin3);
                int claseSup1 = creadorclases.New_(grupoSup1, domingo, hora4, fin3);
                int claseVela1 = creadorclases.New_(grupoVela1, domingo, hora4, fin3);
                
                //Grupos a los que se matricula el alumno
                IList<int> grupos = new List<int>();
                grupos.Add(grupo1);
                grupos.Add(grupo2);
                grupos.Add(grupo3);
                grupos.Add(grupo4);
                grupos.Add(grupoWind1);

                /*
                //Creamos dos focking usuarios
                UserRegistradoCEN userRegistradoCEN = new UserRegistradoCEN ();
                string usuario = userRegistradoCEN.New_ ("email@Masteryi.com", "Master yi", "Pepe", "Mas", "1234", nacimiento, "foto");
                string usuario2 = userRegistradoCEN.New_ ("email@lux.com", "lux", "Pepe", "Mas", "1234", nacimiento, "imagen");
                string usuario3 = userRegistradoCEN.New_("Carlos@currante.com","Elprofe","Carlos","Aldaravi","Prueba1.", nacimiento, "imagen");

                MensajeCEN mensaje = new MensajeCEN ();
                mensaje.EnviarMensaje (usuario, usuario2, "Guapo");
                System.Console.WriteLine ("////////////// LOGIN DE USUARIO /////////////////////////");
                if (userRegistradoCEN.Identificarse ("email@Masteryi.com", "1234"))
                        System.Console.WriteLine ("Identificado");
                else
                        System.Console.WriteLine ("No Identificado");

                System.Console.WriteLine ("////////////// LOGIN DE USUARIO /////////////////////////");
                */
                //PagoCEN pago = new PagoCEN ();
                //int pagao = pago.New_ (WateralGenNHibernate.Enumerated.Wateral.TipoPagoEnum.PayPal, false);
                //Los usuarios quieren inscribirse a cursos
                /*
                WateralGenNHibernate.CP.Wateral.AlumnoCP alumnoCP = new WateralGenNHibernate.CP.Wateral.AlumnoCP ();
                try
                {
                        AlumnoEN alumno1 = alumnoCP.Inscribirse_curso ("Todos los dias", "Flojucho", 40, WateralGenNHibernate.Enumerated.Wateral.TallaEnum.l, 23, "AAAAAAA", grupos, usuario);
                        Solicitud_cambioCEN quierocambio = new Solicitud_cambioCEN ();
                        quierocambio.SolicitarCambio (alumno1.Idalumno, grupo1, grupo2);
                        WateralGenNHibernate.CP.Wateral.ValoracionCursoCP valor = new WateralGenNHibernate.CP.Wateral.ValoracionCursoCP ();
                        valor.ValorarCurso (10, alumno1.Idalumno, kitesurf);
                }
                catch (Exception ex)
                {
                        System.Console.WriteLine (ex.Message);
                }
                try
                {
                        AlumnoEN alumno2 = alumnoCP.Inscribirse_curso ("Todos los dies", "Flojuche", 40, WateralGenNHibernate.Enumerated.Wateral.TallaEnum.l, 23, "BBBBB", grupos, usuario2);
                }
                catch (Exception ex)
                {
                        System.Console.WriteLine (ex.Message);
                }
                */





                // Variable que surge del componente de proceso que crea un alumno y lo inscribe al curso
                //int registroalumno = cpalumno.Inscribirse_curso (usuario, "Todos los dias", 30, WateralGenNHibernate.Enumerated.Wateral.TallaEnum.l, 32, "29348728349A", gruposinscribirse, "Flojillo");

                //int cambioid = cambiador.SolicitarCambio (registroalumno, grupo1, grupo2);

                AdministradorCEN administrador = new AdministradorCEN ();


                //alumno.EnviarMensaje (registroalumno, profesor1, "Hola");
                //alumno.ConsultarHorarioInscrito (registroalumno);

                // si lees esto estás en git

                ProductoCEN productoCEN = new ProductoCEN ();
                int prod1 = productoCEN.New_ (1, "Neopreno ION Corto", "neopreno1.jpg", "Perfecto para temporada de final de primavera y principio de otoño", 99.9, 12.9);
                int prod2 = productoCEN.New_ (2, "North Dice 14m", "northdice.jpg", "Cometa para vientos flojos", 1200, 25);
                int prod3 = productoCEN.New_ (3, "Tabla RRD 145x42cm", "tabla.jpg", "Perfecta para iniciacion", 350, 15);
                int prod4 = productoCEN.New_ (7, "Camiseta QuickSilver", "camisetaQS.jpg", "Camiseta de tirantes", 30, 90);
                int prod5 = productoCEN.New_ (5, "Neopreno ION Largo 5.3", "neopreno2.jpg", "Perfecto para invierno", 250, 10);
                int prod6 = productoCEN.New_ (9, "Neopreno QuickSilver 5.4", "neopreno3.jpg", "Perfecto para invierno", 220, 10);
                WateralGenNHibernate.CP.Wateral.ProductoCP consulta = new WateralGenNHibernate.CP.Wateral.ProductoCP ();
                consulta.ConsultarProductos ("Neopreno");
                /*
                CestaCEN cestaCEN = new CestaCEN ();
                int cesta = cestaCEN.New_ (usuario);
                int cesta2 = cestaCEN.New_ (usuario2);


                LineaCestaCEN lineaCestaCEN = new LineaCestaCEN ();
                int linea1 = lineaCestaCEN.New_ (cesta, 1, 12, 12.5, prod1);
                int linea2 = lineaCestaCEN.New_ (cesta2, 2, 3, 12, prod2);

                IList<int> lineas = new List<int>();
                lineas.Add (linea1);
                lineas.Add (linea2);

                IList<int> lineas2 = new List<int>();
                lineas.Add (linea2);

                DateTime fecha = new DateTime(1990, 1, 1);
                AdministradorCEN administradorCEN = new AdministradorCEN ();
                //string admin1 = administradorCEN.New_ ("admin@admin.com", "admin", "yo", "yoyo", "1234", nacimiento, "imagen");
                //string admin2 = administradorCEN.New_("administrator@gmail.com", "admin2", "Administrator", "Apellidos", "Admin123.", fecha,"imagen");

                /*PROTECTED REGION END*/
                //CestaEN xD= cestaCEN.ObtenerCesta("email@Masteryi.com");
                //System.Console.WriteLine(xD.Usuario_Regist);

            }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
