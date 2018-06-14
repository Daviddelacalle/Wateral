
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_Administrador_publicar_noticia) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class AdministradorCP : BasicCP
{
public int Publicar_noticia (string p_oid, string noticia, string foto, Nullable<DateTime> fecha)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_Administrador_publicar_noticia) ENABLED START*/

        IAdministradorCAD administradorCAD = null;
        AdministradorCEN administradorCEN = null;
        INoticiaCAD noticiaCAD = null;
        NoticiaCEN noticiaCEN = null;


        int result = -1;


        try
        {
                SessionInitializeTransaction ();
                administradorCAD = new AdministradorCAD (session);
                administradorCEN = new  AdministradorCEN (administradorCAD);
                noticiaCAD = new NoticiaCAD (session);
                noticiaCEN = new NoticiaCEN (noticiaCAD);

                result = noticiaCEN.New_ (p_oid, noticia, foto, fecha);

                NoticiaEN noticiapublicada = noticiaCEN.ReadOID (result);

                System.Console.WriteLine ("Noticia publicada con �xito");
                System.Console.WriteLine ("Administrador que la ha publicado: " + noticiapublicada.Administrador.Email);
                System.Console.WriteLine ("Texto de la noticia: " + noticiapublicada.Noticia);




                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
