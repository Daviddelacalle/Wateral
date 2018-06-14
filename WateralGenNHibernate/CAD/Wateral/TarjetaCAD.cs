
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
 * Clase Tarjeta:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class TarjetaCAD : BasicCAD, ITarjetaCAD
{
public TarjetaCAD() : base ()
{
}

public TarjetaCAD(ISession sessionAux) : base (sessionAux)
{
}



public TarjetaEN ReadOIDDefault (string numero
                                 )
{
        TarjetaEN tarjetaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tarjetaEN = (TarjetaEN)session.Get (typeof(TarjetaEN), numero);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in TarjetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tarjetaEN;
}

public System.Collections.Generic.IList<TarjetaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TarjetaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TarjetaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TarjetaEN>();
                        else
                                result = session.CreateCriteria (typeof(TarjetaEN)).List<TarjetaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in TarjetaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TarjetaEN tarjeta)
{
        try
        {
                SessionInitializeTransaction ();
                TarjetaEN tarjetaEN = (TarjetaEN)session.Load (typeof(TarjetaEN), tarjeta.Numero);

                tarjetaEN.CVC = tarjeta.CVC;


                tarjetaEN.Fecha = tarjeta.Fecha;


                tarjetaEN.Nombre = tarjeta.Nombre;


                tarjetaEN.Apellidos = tarjeta.Apellidos;



                session.Update (tarjetaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in TarjetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (TarjetaEN tarjeta)
{
        try
        {
                SessionInitializeTransaction ();
                if (tarjeta.UserRegistrado != null) {
                        // Argumento OID y no colección.
                        tarjeta.UserRegistrado = (WateralGenNHibernate.EN.Wateral.UserRegistradoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.UserRegistradoEN), tarjeta.UserRegistrado.Email);

                        tarjeta.UserRegistrado.Tarjetas
                        .Add (tarjeta);
                }

                session.Save (tarjeta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in TarjetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tarjeta.Numero;
}

public void Modify (TarjetaEN tarjeta)
{
        try
        {
                SessionInitializeTransaction ();
                TarjetaEN tarjetaEN = (TarjetaEN)session.Load (typeof(TarjetaEN), tarjeta.Numero);

                tarjetaEN.CVC = tarjeta.CVC;


                tarjetaEN.Fecha = tarjeta.Fecha;


                tarjetaEN.Nombre = tarjeta.Nombre;


                tarjetaEN.Apellidos = tarjeta.Apellidos;

                session.Update (tarjetaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in TarjetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string numero
                     )
{
        try
        {
                SessionInitializeTransaction ();
                TarjetaEN tarjetaEN = (TarjetaEN)session.Load (typeof(TarjetaEN), numero);
                session.Delete (tarjetaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in TarjetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: TarjetaEN
public TarjetaEN ReadOID (string numero
                          )
{
        TarjetaEN tarjetaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tarjetaEN = (TarjetaEN)session.Get (typeof(TarjetaEN), numero);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in TarjetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tarjetaEN;
}

public System.Collections.Generic.IList<TarjetaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TarjetaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TarjetaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TarjetaEN>();
                else
                        result = session.CreateCriteria (typeof(TarjetaEN)).List<TarjetaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in TarjetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
