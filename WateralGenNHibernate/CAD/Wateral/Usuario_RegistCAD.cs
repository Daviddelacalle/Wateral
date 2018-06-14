
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
 * Clase Usuario_Regist:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class Usuario_RegistCAD : BasicCAD, IUsuario_RegistCAD
{
public Usuario_RegistCAD() : base ()
{
}

public Usuario_RegistCAD(ISession sessionAux) : base (sessionAux)
{
}



public Usuario_RegistEN ReadOIDDefault (string email
                                        )
{
        Usuario_RegistEN usuario_RegistEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuario_RegistEN = (Usuario_RegistEN)session.Get (typeof(Usuario_RegistEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Usuario_RegistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario_RegistEN;
}

public System.Collections.Generic.IList<Usuario_RegistEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<Usuario_RegistEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(Usuario_RegistEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<Usuario_RegistEN>();
                        else
                                result = session.CreateCriteria (typeof(Usuario_RegistEN)).List<Usuario_RegistEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Usuario_RegistCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (Usuario_RegistEN usuario_Regist)
{
        try
        {
                SessionInitializeTransaction ();
                Usuario_RegistEN usuario_RegistEN = (Usuario_RegistEN)session.Load (typeof(Usuario_RegistEN), usuario_Regist.Email);

                usuario_RegistEN.Nomusuario = usuario_Regist.Nomusuario;


                usuario_RegistEN.Nombre = usuario_Regist.Nombre;


                usuario_RegistEN.Apellidos = usuario_Regist.Apellidos;


                usuario_RegistEN.Contrasenya = usuario_Regist.Contrasenya;


                usuario_RegistEN.Telefono = usuario_Regist.Telefono;


                usuario_RegistEN.Nacimiento = usuario_Regist.Nacimiento;


                usuario_RegistEN.Calle = usuario_Regist.Calle;


                usuario_RegistEN.Ciudad = usuario_Regist.Ciudad;


                usuario_RegistEN.Codpostal = usuario_Regist.Codpostal;


                usuario_RegistEN.Provincia = usuario_Regist.Provincia;


                usuario_RegistEN.Credito = usuario_Regist.Credito;




                session.Update (usuario_RegistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Usuario_RegistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (Usuario_RegistEN usuario_Regist)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuario_Regist);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Usuario_RegistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario_Regist.Email;
}

public void Modify (Usuario_RegistEN usuario_Regist)
{
        try
        {
                SessionInitializeTransaction ();
                Usuario_RegistEN usuario_RegistEN = (Usuario_RegistEN)session.Load (typeof(Usuario_RegistEN), usuario_Regist.Email);

                usuario_RegistEN.Nomusuario = usuario_Regist.Nomusuario;


                usuario_RegistEN.Nombre = usuario_Regist.Nombre;


                usuario_RegistEN.Apellidos = usuario_Regist.Apellidos;


                usuario_RegistEN.Contrasenya = usuario_Regist.Contrasenya;


                usuario_RegistEN.Telefono = usuario_Regist.Telefono;


                usuario_RegistEN.Nacimiento = usuario_Regist.Nacimiento;


                usuario_RegistEN.Calle = usuario_Regist.Calle;


                usuario_RegistEN.Ciudad = usuario_Regist.Ciudad;


                usuario_RegistEN.Codpostal = usuario_Regist.Codpostal;


                usuario_RegistEN.Provincia = usuario_Regist.Provincia;


                usuario_RegistEN.Credito = usuario_Regist.Credito;

                session.Update (usuario_RegistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Usuario_RegistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string email
                     )
{
        try
        {
                SessionInitializeTransaction ();
                Usuario_RegistEN usuario_RegistEN = (Usuario_RegistEN)session.Load (typeof(Usuario_RegistEN), email);
                session.Delete (usuario_RegistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Usuario_RegistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: Usuario_RegistEN
public Usuario_RegistEN ReadOID (string email
                                 )
{
        Usuario_RegistEN usuario_RegistEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuario_RegistEN = (Usuario_RegistEN)session.Get (typeof(Usuario_RegistEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Usuario_RegistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario_RegistEN;
}

public System.Collections.Generic.IList<Usuario_RegistEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<Usuario_RegistEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(Usuario_RegistEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<Usuario_RegistEN>();
                else
                        result = session.CreateCriteria (typeof(Usuario_RegistEN)).List<Usuario_RegistEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Usuario_RegistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
