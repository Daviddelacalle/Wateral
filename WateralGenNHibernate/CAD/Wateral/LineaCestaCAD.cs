
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
 * Clase LineaCesta:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class LineaCestaCAD : BasicCAD, ILineaCestaCAD
{
public LineaCestaCAD() : base ()
{
}

public LineaCestaCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaCestaEN ReadOIDDefault (int linea
                                    )
{
        LineaCestaEN lineaCestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaCestaEN = (LineaCestaEN)session.Get (typeof(LineaCestaEN), linea);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaCestaEN;
}

public System.Collections.Generic.IList<LineaCestaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaCestaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaCestaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaCestaEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaCestaEN)).List<LineaCestaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaCestaEN lineaCesta)
{
        try
        {
                SessionInitializeTransaction ();
                LineaCestaEN lineaCestaEN = (LineaCestaEN)session.Load (typeof(LineaCestaEN), lineaCesta.Linea);



                lineaCestaEN.Cantidad = lineaCesta.Cantidad;


                lineaCestaEN.Dias = lineaCesta.Dias;


                lineaCestaEN.Precio = lineaCesta.Precio;


                session.Update (lineaCestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (LineaCestaEN lineaCesta)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaCesta.Cesta != null) {
                        // Argumento OID y no colección.
                        lineaCesta.Cesta = (WateralGenNHibernate.EN.Wateral.CestaEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.CestaEN), lineaCesta.Cesta.Id);

                        lineaCesta.Cesta.LineasCesta
                        .Add (lineaCesta);
                }
                if (lineaCesta.Producto != null) {
                        // Argumento OID y no colección.
                        lineaCesta.Producto = (WateralGenNHibernate.EN.Wateral.ProductoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.ProductoEN), lineaCesta.Producto.Id);

                        lineaCesta.Producto.LineasCesta
                        .Add (lineaCesta);
                }

                session.Save (lineaCesta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaCesta.Linea;
}

public void Modify (LineaCestaEN lineaCesta)
{
        try
        {
                SessionInitializeTransaction ();
                LineaCestaEN lineaCestaEN = (LineaCestaEN)session.Load (typeof(LineaCestaEN), lineaCesta.Linea);

                lineaCestaEN.Cantidad = lineaCesta.Cantidad;


                lineaCestaEN.Dias = lineaCesta.Dias;


                lineaCestaEN.Precio = lineaCesta.Precio;

                session.Update (lineaCestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int linea
                     )
{
        try
        {
                SessionInitializeTransaction ();
                LineaCestaEN lineaCestaEN = (LineaCestaEN)session.Load (typeof(LineaCestaEN), linea);
                session.Delete (lineaCestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: LineaCestaEN
public LineaCestaEN ReadOID (int linea
                             )
{
        LineaCestaEN lineaCestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaCestaEN = (LineaCestaEN)session.Get (typeof(LineaCestaEN), linea);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaCestaEN;
}

public System.Collections.Generic.IList<LineaCestaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaCestaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LineaCestaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LineaCestaEN>();
                else
                        result = session.CreateCriteria (typeof(LineaCestaEN)).List<LineaCestaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
