
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
 * Clase Alumno:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class AlumnoCAD : BasicCAD, IAlumnoCAD
{
public AlumnoCAD() : base ()
{
}

public AlumnoCAD(ISession sessionAux) : base (sessionAux)
{
}



public AlumnoEN ReadOIDDefault (int idalumno
                                )
{
        AlumnoEN alumnoEN = null;

        try
        {
                SessionInitializeTransaction ();
                alumnoEN = (AlumnoEN)session.Get (typeof(AlumnoEN), idalumno);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return alumnoEN;
}

public System.Collections.Generic.IList<AlumnoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AlumnoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AlumnoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AlumnoEN>();
                        else
                                result = session.CreateCriteria (typeof(AlumnoEN)).List<AlumnoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AlumnoEN alumno)
{
        try
        {
                SessionInitializeTransaction ();
                AlumnoEN alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), alumno.Idalumno);

                alumnoEN.Disponibilidad = alumno.Disponibilidad;


                alumnoEN.Salud = alumno.Salud;


                alumnoEN.Peso = alumno.Peso;


                alumnoEN.Talla = alumno.Talla;


                alumnoEN.NumPie = alumno.NumPie;


                alumnoEN.DNI = alumno.DNI;







                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (AlumnoEN alumno)
{
        try
        {
                SessionInitializeTransaction ();
                if (alumno.Grupos != null) {
                        for (int i = 0; i < alumno.Grupos.Count; i++) {
                                alumno.Grupos [i] = (WateralGenNHibernate.EN.Wateral.GrupoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.GrupoEN), alumno.Grupos [i].Id);
                                alumno.Grupos [i].Alumnos.Add (alumno);
                        }
                }
                if (alumno.UserRegistrado != null) {
                        // Argumento OID y no colección.
                        alumno.UserRegistrado = (WateralGenNHibernate.EN.Wateral.UserRegistradoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.UserRegistradoEN), alumno.UserRegistrado.Email);

                        alumno.UserRegistrado.Alumno
                                = alumno;
                }

                session.Save (alumno);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return alumno.Idalumno;
}

public void Modify (AlumnoEN alumno)
{
        try
        {
                SessionInitializeTransaction ();
                AlumnoEN alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), alumno.Idalumno);

                alumnoEN.Disponibilidad = alumno.Disponibilidad;


                alumnoEN.Salud = alumno.Salud;


                alumnoEN.Peso = alumno.Peso;


                alumnoEN.Talla = alumno.Talla;


                alumnoEN.NumPie = alumno.NumPie;


                alumnoEN.DNI = alumno.DNI;

                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int idalumno
                     )
{
        try
        {
                SessionInitializeTransaction ();
                AlumnoEN alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), idalumno);
                session.Delete (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: AlumnoEN
public AlumnoEN ReadOID (int idalumno
                         )
{
        AlumnoEN alumnoEN = null;

        try
        {
                SessionInitializeTransaction ();
                alumnoEN = (AlumnoEN)session.Get (typeof(AlumnoEN), idalumno);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return alumnoEN;
}

public System.Collections.Generic.IList<AlumnoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AlumnoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AlumnoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AlumnoEN>();
                else
                        result = session.CreateCriteria (typeof(AlumnoEN)).List<AlumnoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public long CuentaAlumnos (int grupo)
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AlumnoEN self where select count(a) from AlumnoEN a inner join a.Grupos g where g.Id = :grupo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AlumnoENcuentaAlumnosHQL");
                query.SetParameter ("grupo", grupo);


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public int Inscribirse_curso (AlumnoEN alumno)
{
        try
        {
                SessionInitializeTransaction ();
                if (alumno.Grupos != null) {
                        for (int i = 0; i < alumno.Grupos.Count; i++) {
                                alumno.Grupos [i] = (WateralGenNHibernate.EN.Wateral.GrupoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.GrupoEN), alumno.Grupos [i].Id);
                                alumno.Grupos [i].Alumnos.Add (alumno);
                        }
                }
                if (alumno.UserRegistrado != null) {
                        // Argumento OID y no colección.
                        alumno.UserRegistrado = (WateralGenNHibernate.EN.Wateral.UserRegistradoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.UserRegistradoEN), alumno.UserRegistrado.Email);

                        alumno.UserRegistrado.Alumno
                                = alumno;
                }

                session.Save (alumno);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return alumno.Idalumno;
}
}
}
