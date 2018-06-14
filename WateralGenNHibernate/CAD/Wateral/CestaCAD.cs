
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
 * Clase Cesta:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class CestaCAD : BasicCAD, ICestaCAD
{
public CestaCAD() : base ()
{
}

public CestaCAD(ISession sessionAux) : base (sessionAux)
{
}



public CestaEN ReadOIDDefault (int id
                               )
{
        CestaEN cestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cestaEN = (CestaEN)session.Get (typeof(CestaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cestaEN;
}

public System.Collections.Generic.IList<CestaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CestaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CestaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CestaEN>();
                        else
                                result = session.CreateCriteria (typeof(CestaEN)).List<CestaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CestaEN cesta)
{
        try
        {
                SessionInitializeTransaction ();
                CestaEN cestaEN = (CestaEN)session.Load (typeof(CestaEN), cesta.Id);


                session.Update (cestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CestaEN cesta)
{
        try
        {
                SessionInitializeTransaction ();
                if (cesta.Usuario_Regist != null) {
                        // Argumento OID y no colección.
                        cesta.Usuario_Regist = (WateralGenNHibernate.EN.Wateral.UserRegistradoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.UserRegistradoEN), cesta.Usuario_Regist.Email);

                        cesta.Usuario_Regist.Cestas
                                = cesta;
                }

                session.Save (cesta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cesta.Id;
}

public void Modify (CestaEN cesta)
{
        try
        {
                SessionInitializeTransaction ();
                CestaEN cestaEN = (CestaEN)session.Load (typeof(CestaEN), cesta.Id);
                session.Update (cestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
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
                CestaEN cestaEN = (CestaEN)session.Load (typeof(CestaEN), id);
                session.Delete (cestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CestaEN
public CestaEN ReadOID (int id
                        )
{
        CestaEN cestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cestaEN = (CestaEN)session.Get (typeof(CestaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cestaEN;
}

public System.Collections.Generic.IList<CestaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CestaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CestaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CestaEN>();
                else
                        result = session.CreateCriteria (typeof(CestaEN)).List<CestaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
