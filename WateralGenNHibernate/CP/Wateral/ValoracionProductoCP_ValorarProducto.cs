
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_ValoracionProducto_valorarProducto) ENABLED START*/
// �references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class ValoracionProductoCP : BasicCP
{
public WateralGenNHibernate.EN.Wateral.ValoracionProductoEN ValorarProducto (int p_nota, string p_userRegistrado, int p_producto, string comentario)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_ValoracionProducto_valorarProducto) ENABLED START*/

        IValoracionProductoCAD valoracionProductoCAD = null;
        ValoracionProductoCEN valoracionProductoCEN = null;

        WateralGenNHibernate.EN.Wateral.ValoracionProductoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                valoracionProductoCAD = new ValoracionProductoCAD (session);
                valoracionProductoCEN = new ValoracionProductoCEN (valoracionProductoCAD);




                int oid;
                //Initialized ValoracionProductoEN
                ValoracionProductoEN valoracionProductoEN;
                valoracionProductoEN = new ValoracionProductoEN ();
                valoracionProductoEN.Nota = p_nota;
                valoracionProductoEN.Comentario = comentario;


                if (p_userRegistrado != null) {
                        valoracionProductoEN.UserRegistrado = new WateralGenNHibernate.EN.Wateral.UserRegistradoEN ();
                        valoracionProductoEN.UserRegistrado.Email = p_userRegistrado;
                }


                if (p_producto != -1) {
                        valoracionProductoEN.Producto = new WateralGenNHibernate.EN.Wateral.ProductoEN ();
                        valoracionProductoEN.Producto.Id = p_producto;
                }

                //Call to ValoracionProductoCAD

                oid = valoracionProductoCAD.ValorarProducto (valoracionProductoEN);
                result = valoracionProductoCAD.ReadOIDDefault (oid);



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
