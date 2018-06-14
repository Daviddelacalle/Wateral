
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
 * Clase UserRegistrado:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class UserRegistradoCAD : BasicCAD, IUserRegistradoCAD
{
public UserRegistradoCAD() : base ()
{
}

public UserRegistradoCAD(ISession sessionAux) : base (sessionAux)
{
}



public UserRegistradoEN ReadOIDDefault (string email
                                        )
{
        UserRegistradoEN userRegistradoEN = null;

        try
        {
                SessionInitializeTransaction ();
                userRegistradoEN = (UserRegistradoEN)session.Get (typeof(UserRegistradoEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in UserRegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userRegistradoEN;
}

public System.Collections.Generic.IList<UserRegistradoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UserRegistradoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UserRegistradoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UserRegistradoEN>();
                        else
                                result = session.CreateCriteria (typeof(UserRegistradoEN)).List<UserRegistradoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in UserRegistradoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UserRegistradoEN userRegistrado)
{
        try
        {
                SessionInitializeTransaction ();
                UserRegistradoEN userRegistradoEN = (UserRegistradoEN)session.Load (typeof(UserRegistradoEN), userRegistrado.Email);

                userRegistradoEN.Usuario = userRegistrado.Usuario;


                userRegistradoEN.Nombre = userRegistrado.Nombre;


                userRegistradoEN.Apellidos = userRegistrado.Apellidos;


                userRegistradoEN.Contrasenya = userRegistrado.Contrasenya;


                userRegistradoEN.Telefono = userRegistrado.Telefono;


                userRegistradoEN.Nacimiento = userRegistrado.Nacimiento;


                userRegistradoEN.Calle = userRegistrado.Calle;


                userRegistradoEN.Ciudad = userRegistrado.Ciudad;


                userRegistradoEN.Codpostal = userRegistrado.Codpostal;


                userRegistradoEN.Provincia = userRegistrado.Provincia;


                userRegistradoEN.Credito = userRegistrado.Credito;









                userRegistradoEN.Imagen = userRegistrado.Imagen;


                session.Update (userRegistradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in UserRegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (UserRegistradoEN userRegistrado)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (userRegistrado);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in UserRegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userRegistrado.Email;
}

public void Modify (UserRegistradoEN userRegistrado)
{
        try
        {
                SessionInitializeTransaction ();
                UserRegistradoEN userRegistradoEN = (UserRegistradoEN)session.Load (typeof(UserRegistradoEN), userRegistrado.Email);

                userRegistradoEN.Usuario = userRegistrado.Usuario;


                userRegistradoEN.Nombre = userRegistrado.Nombre;


                userRegistradoEN.Apellidos = userRegistrado.Apellidos;


                userRegistradoEN.Contrasenya = userRegistrado.Contrasenya;


                userRegistradoEN.Nacimiento = userRegistrado.Nacimiento;


                userRegistradoEN.Imagen = userRegistrado.Imagen;

                session.Update (userRegistradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in UserRegistradoCAD.", ex);
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
                UserRegistradoEN userRegistradoEN = (UserRegistradoEN)session.Load (typeof(UserRegistradoEN), email);
                session.Delete (userRegistradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in UserRegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: UserRegistradoEN
public UserRegistradoEN ReadOID (string email
                                 )
{
        UserRegistradoEN userRegistradoEN = null;

        try
        {
                SessionInitializeTransaction ();
                userRegistradoEN = (UserRegistradoEN)session.Get (typeof(UserRegistradoEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in UserRegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userRegistradoEN;
}

public System.Collections.Generic.IList<UserRegistradoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UserRegistradoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UserRegistradoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UserRegistradoEN>();
                else
                        result = session.CreateCriteria (typeof(UserRegistradoEN)).List<UserRegistradoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in UserRegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
