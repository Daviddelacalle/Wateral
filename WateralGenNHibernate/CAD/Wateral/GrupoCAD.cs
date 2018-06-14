
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
 * Clase Grupo:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class GrupoCAD : BasicCAD, IGrupoCAD
{
public GrupoCAD() : base ()
{
}

public GrupoCAD(ISession sessionAux) : base (sessionAux)
{
}



public GrupoEN ReadOIDDefault (int id
                               )
{
        GrupoEN grupoEN = null;

        try
        {
                SessionInitializeTransaction ();
                grupoEN = (GrupoEN)session.Get (typeof(GrupoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return grupoEN;
}

public System.Collections.Generic.IList<GrupoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<GrupoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(GrupoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<GrupoEN>();
                        else
                                result = session.CreateCriteria (typeof(GrupoEN)).List<GrupoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (GrupoEN grupo)
{
        try
        {
                SessionInitializeTransaction ();
                GrupoEN grupoEN = (GrupoEN)session.Load (typeof(GrupoEN), grupo.Id);




                grupoEN.Maxalumnos = grupo.Maxalumnos;


                grupoEN.Horario = grupo.Horario;




                session.Update (grupoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (GrupoEN grupo)
{
        try
        {
                SessionInitializeTransaction ();
                if (grupo.Curso != null) {
                        // Argumento OID y no colección.
                        grupo.Curso = (WateralGenNHibernate.EN.Wateral.CursoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.CursoEN), grupo.Curso.Id);

                        grupo.Curso.Grupos
                        .Add (grupo);
                }
                if (grupo.Profesor != null) {
                        // Argumento OID y no colección.
                        grupo.Profesor = (WateralGenNHibernate.EN.Wateral.ProfesorEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.ProfesorEN), grupo.Profesor.Id);

                        grupo.Profesor.Grupos
                        .Add (grupo);
                }

                session.Save (grupo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return grupo.Id;
}

public void Modify (GrupoEN grupo)
{
        try
        {
                SessionInitializeTransaction ();
                GrupoEN grupoEN = (GrupoEN)session.Load (typeof(GrupoEN), grupo.Id);

                grupoEN.Maxalumnos = grupo.Maxalumnos;


                grupoEN.Horario = grupo.Horario;

                session.Update (grupoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
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
                GrupoEN grupoEN = (GrupoEN)session.Load (typeof(GrupoEN), id);
                session.Delete (grupoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: GrupoEN
public GrupoEN ReadOID (int id
                        )
{
        GrupoEN grupoEN = null;

        try
        {
                SessionInitializeTransaction ();
                grupoEN = (GrupoEN)session.Get (typeof(GrupoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return grupoEN;
}

public System.Collections.Generic.IList<GrupoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<GrupoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(GrupoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<GrupoEN>();
                else
                        result = session.CreateCriteria (typeof(GrupoEN)).List<GrupoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
