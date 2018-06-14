

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.Exceptions;

using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;


namespace WateralGenNHibernate.CEN.Wateral
{
/*
 *      Definition of the class Solucionar_CambioCEN
 *
 */
public partial class Solucionar_CambioCEN
{
private ISolucionar_CambioCAD _ISolucionar_CambioCAD;

public Solucionar_CambioCEN()
{
        this._ISolucionar_CambioCAD = new Solucionar_CambioCAD ();
}

public Solucionar_CambioCEN(ISolucionar_CambioCAD _ISolucionar_CambioCAD)
{
        this._ISolucionar_CambioCAD = _ISolucionar_CambioCAD;
}

public ISolucionar_CambioCAD get_ISolucionar_CambioCAD ()
{
        return this._ISolucionar_CambioCAD;
}

public int New_ (System.Collections.Generic.IList<string> p_alumnos, int p_grupo)
{
        Solucionar_CambioEN solucionar_CambioEN = null;
        int oid;

        //Initialized Solucionar_CambioEN
        solucionar_CambioEN = new Solucionar_CambioEN ();

        solucionar_CambioEN.Alumnos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.AlumnoEN>();
        if (p_alumnos != null) {
                foreach (string item in p_alumnos) {
                        WateralGenNHibernate.EN.Wateral.AlumnoEN en = new WateralGenNHibernate.EN.Wateral.AlumnoEN ();
                        en.Email = item;
                        solucionar_CambioEN.Alumnos.Add (en);
                }
        }

        else{
                solucionar_CambioEN.Alumnos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.AlumnoEN>();
        }


        if (p_grupo != -1) {
                // El argumento p_grupo -> Property grupo es oid = false
                // Lista de oids id
                solucionar_CambioEN.Grupo = new WateralGenNHibernate.EN.Wateral.GrupoEN ();
                solucionar_CambioEN.Grupo.Id = p_grupo;
        }

        //Call to Solucionar_CambioCAD

        oid = _ISolucionar_CambioCAD.New_ (solucionar_CambioEN);
        return oid;
}

public void Modify (int p_Solucionar_Cambio_OID)
{
        Solucionar_CambioEN solucionar_CambioEN = null;

        //Initialized Solucionar_CambioEN
        solucionar_CambioEN = new Solucionar_CambioEN ();
        solucionar_CambioEN.Id = p_Solucionar_Cambio_OID;
        //Call to Solucionar_CambioCAD

        _ISolucionar_CambioCAD.Modify (solucionar_CambioEN);
}

public void Destroy (int id
                     )
{
        _ISolucionar_CambioCAD.Destroy (id);
}
}
}
