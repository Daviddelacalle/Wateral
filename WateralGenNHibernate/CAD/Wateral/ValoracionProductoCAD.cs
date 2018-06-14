
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
 * Clase ValoracionProducto:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class ValoracionProductoCAD : BasicCAD, IValoracionProductoCAD
{
public ValoracionProductoCAD() : base ()
{
}

public ValoracionProductoCAD(ISession sessionAux) : base (sessionAux)
{
}



public ValoracionProductoEN ReadOIDDefault (int id_valoracion
                                            )
{
        ValoracionProductoEN valoracionProductoEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionProductoEN = (ValoracionProductoEN)session.Get (typeof(ValoracionProductoEN), id_valoracion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionProductoEN;
}

public System.Collections.Generic.IList<ValoracionProductoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ValoracionProductoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ValoracionProductoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ValoracionProductoEN>();
                        else
                                result = session.CreateCriteria (typeof(ValoracionProductoEN)).List<ValoracionProductoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProductoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ValoracionProductoEN valoracionProducto)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionProductoEN valoracionProductoEN = (ValoracionProductoEN)session.Load (typeof(ValoracionProductoEN), valoracionProducto.Id_valoracion);


                session.Update (valoracionProductoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ValoracionProductoEN valoracionProducto)
{
        try
        {
                SessionInitializeTransaction ();
                if (valoracionProducto.UserRegistrado != null) {
                        // Argumento OID y no colección.
                        valoracionProducto.UserRegistrado = (WateralGenNHibernate.EN.Wateral.UserRegistradoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.UserRegistradoEN), valoracionProducto.UserRegistrado.Email);

                        valoracionProducto.UserRegistrado.ValoracionesProducto
                        .Add (valoracionProducto);
                }
                if (valoracionProducto.Producto != null) {
                        // Argumento OID y no colección.
                        valoracionProducto.Producto = (WateralGenNHibernate.EN.Wateral.ProductoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.ProductoEN), valoracionProducto.Producto.Id);

                        valoracionProducto.Producto.ValoracionesProducto
                        .Add (valoracionProducto);
                }

                session.Save (valoracionProducto);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionProducto.Id_valoracion;
}

public void Modify (ValoracionProductoEN valoracionProducto)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionProductoEN valoracionProductoEN = (ValoracionProductoEN)session.Load (typeof(ValoracionProductoEN), valoracionProducto.Id_valoracion);

                valoracionProductoEN.Nota = valoracionProducto.Nota;

                session.Update (valoracionProductoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id_valoracion
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionProductoEN valoracionProductoEN = (ValoracionProductoEN)session.Load (typeof(ValoracionProductoEN), id_valoracion);
                session.Delete (valoracionProductoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int ValorarProducto (ValoracionProductoEN valoracionProducto)
{
        try
        {
                SessionInitializeTransaction ();
                if (valoracionProducto.UserRegistrado != null) {
                        // Argumento OID y no colección.
                        valoracionProducto.UserRegistrado = (WateralGenNHibernate.EN.Wateral.UserRegistradoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.UserRegistradoEN), valoracionProducto.UserRegistrado.Email);

                        valoracionProducto.UserRegistrado.ValoracionesProducto
                        .Add (valoracionProducto);
                }
                if (valoracionProducto.Producto != null) {
                        // Argumento OID y no colección.
                        valoracionProducto.Producto = (WateralGenNHibernate.EN.Wateral.ProductoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.ProductoEN), valoracionProducto.Producto.Id);

                        valoracionProducto.Producto.ValoracionesProducto
                        .Add (valoracionProducto);
                }

                session.Save (valoracionProducto);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionProducto.Id_valoracion;
}

//Sin e: ReadOID
//Con e: ValoracionProductoEN
public ValoracionProductoEN ReadOID (int id_valoracion
                                     )
{
        ValoracionProductoEN valoracionProductoEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionProductoEN = (ValoracionProductoEN)session.Get (typeof(ValoracionProductoEN), id_valoracion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionProductoEN;
}

public System.Collections.Generic.IList<ValoracionProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionProductoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ValoracionProductoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ValoracionProductoEN>();
                else
                        result = session.CreateCriteria (typeof(ValoracionProductoEN)).List<ValoracionProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
