
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
 * Clase Curso:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class CursoCAD : BasicCAD, ICursoCAD
{
public CursoCAD() : base ()
{
}

public CursoCAD(ISession sessionAux) : base (sessionAux)
{
}



public CursoEN ReadOIDDefault (int id
                               )
{
        CursoEN cursoEN = null;

        try
        {
                SessionInitializeTransaction ();
                cursoEN = (CursoEN)session.Get (typeof(CursoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cursoEN;
}

public System.Collections.Generic.IList<CursoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CursoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CursoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CursoEN>();
                        else
                                result = session.CreateCriteria (typeof(CursoEN)).List<CursoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CursoEN curso)
{
        try
        {
                SessionInitializeTransaction ();
                CursoEN cursoEN = (CursoEN)session.Load (typeof(CursoEN), curso.Id);


                cursoEN.Precio = curso.Precio;


                cursoEN.Duracion = curso.Duracion;


                cursoEN.Tipo = curso.Tipo;


                cursoEN.Nombre = curso.Nombre;



                cursoEN.FechaInicio = curso.FechaInicio;


                cursoEN.FechaFin = curso.FechaFin;



                cursoEN.Imagen = curso.Imagen;

                session.Update (cursoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CursoEN curso)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (curso);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return curso.Id;
}

public void Modify (CursoEN curso)
{
        try
        {
                SessionInitializeTransaction ();
                CursoEN cursoEN = (CursoEN)session.Load (typeof(CursoEN), curso.Id);

                cursoEN.Precio = curso.Precio;


                cursoEN.Duracion = curso.Duracion;


                cursoEN.Tipo = curso.Tipo;


                cursoEN.Nombre = curso.Nombre;


                cursoEN.FechaInicio = curso.FechaInicio;


                cursoEN.FechaFin = curso.FechaFin;


                cursoEN.Imagen = curso.Imagen;

                session.Update (cursoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
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
                CursoEN cursoEN = (CursoEN)session.Load (typeof(CursoEN), id);
                session.Delete (cursoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CursoEN
public CursoEN ReadOID (int id
                        )
{
        CursoEN cursoEN = null;

        try
        {
                SessionInitializeTransaction ();
                cursoEN = (CursoEN)session.Get (typeof(CursoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cursoEN;
}

public System.Collections.Generic.IList<CursoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CursoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CursoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CursoEN>();
                else
                        result = session.CreateCriteria (typeof(CursoEN)).List<CursoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
