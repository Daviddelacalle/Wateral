
using System;
using System.Text;
using WateralGenNHibernate.CEN.Wateral;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.Exceptions;


/*
 * Clase Noticia:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class NoticiaCAD : BasicCAD, INoticiaCAD
{
public NoticiaCAD() : base ()
{
}

public NoticiaCAD(ISession sessionAux) : base (sessionAux)
{
}



public NoticiaEN ReadOIDDefault (int id
                                 )
{
        NoticiaEN noticiaEN = null;

        try
        {
                SessionInitializeTransaction ();
                noticiaEN = (NoticiaEN)session.Get (typeof(NoticiaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return noticiaEN;
}

public System.Collections.Generic.IList<NoticiaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NoticiaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NoticiaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NoticiaEN>();
                        else
                                result = session.CreateCriteria (typeof(NoticiaEN)).List<NoticiaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NoticiaEN noticia)
{
        try
        {
                SessionInitializeTransaction ();
                NoticiaEN noticiaEN = (NoticiaEN)session.Load (typeof(NoticiaEN), noticia.Id);


                noticiaEN.Noticia = noticia.Noticia;


                noticiaEN.Imagen = noticia.Imagen;


                noticiaEN.Fecha = noticia.Fecha;


                noticiaEN.Titulo = noticia.Titulo;

                session.Update (noticiaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NoticiaEN noticia)
{
        try
        {
                SessionInitializeTransaction ();
                if (noticia.Administrador != null) {
                        // Argumento OID y no colección.
                        noticia.Administrador = (WateralGenNHibernate.EN.Wateral.AdministradorEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.AdministradorEN), noticia.Administrador.Email);

                        noticia.Administrador.Noticias
                        .Add (noticia);
                }

                session.Save (noticia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return noticia.Id;
}

public void Modify (NoticiaEN noticia)
{
        try
        {
                SessionInitializeTransaction ();
                NoticiaEN noticiaEN = (NoticiaEN)session.Load (typeof(NoticiaEN), noticia.Id);

                noticiaEN.Noticia = noticia.Noticia;


                noticiaEN.Imagen = noticia.Imagen;


                noticiaEN.Fecha = noticia.Fecha;


                noticiaEN.Titulo = noticia.Titulo;

                session.Update (noticiaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                NoticiaEN noticiaEN = (NoticiaEN)session.Load (typeof(NoticiaEN), id);
                session.Delete (noticiaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: NoticiaEN
public NoticiaEN ReadOID (int id
                          )
{
        NoticiaEN noticiaEN = null;

        try
        {
                SessionInitializeTransaction ();
                noticiaEN = (NoticiaEN)session.Get (typeof(NoticiaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return noticiaEN;
}

public System.Collections.Generic.IList<NoticiaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NoticiaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NoticiaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<NoticiaEN>();
                else
                        result = session.CreateCriteria (typeof(NoticiaEN)).List<NoticiaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
