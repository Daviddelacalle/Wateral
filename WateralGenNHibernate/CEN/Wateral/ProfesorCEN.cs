

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
 *      Definition of the class ProfesorCEN
 *
 */
public partial class ProfesorCEN
{
private IProfesorCAD _IProfesorCAD;

public ProfesorCEN()
{
        this._IProfesorCAD = new ProfesorCAD ();
}

public ProfesorCEN(IProfesorCAD _IProfesorCAD)
{
        this._IProfesorCAD = _IProfesorCAD;
}

public IProfesorCAD get_IProfesorCAD ()
{
        return this._IProfesorCAD;
}

public int New_ (string p_NIF, string p_disponibilidad, string p_userRegistrado, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum p_deporte)
{
        ProfesorEN profesorEN = null;
        int oid;

        //Initialized ProfesorEN
        profesorEN = new ProfesorEN ();
        profesorEN.NIF = p_NIF;

        profesorEN.Disponibilidad = p_disponibilidad;


        if (p_userRegistrado != null) {
                // El argumento p_userRegistrado -> Property userRegistrado es oid = false
                // Lista de oids id
                profesorEN.UserRegistrado = new WateralGenNHibernate.EN.Wateral.UserRegistradoEN ();
                profesorEN.UserRegistrado.Email = p_userRegistrado;
        }

        profesorEN.Deporte = p_deporte;

        //Call to ProfesorCAD

        oid = _IProfesorCAD.New_ (profesorEN);
        return oid;
}

public void Modify (int p_Profesor_OID, string p_NIF, string p_disponibilidad, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum p_deporte)
{
        ProfesorEN profesorEN = null;

        //Initialized ProfesorEN
        profesorEN = new ProfesorEN ();
        profesorEN.Id = p_Profesor_OID;
        profesorEN.NIF = p_NIF;
        profesorEN.Disponibilidad = p_disponibilidad;
        profesorEN.Deporte = p_deporte;
        //Call to ProfesorCAD

        _IProfesorCAD.Modify (profesorEN);
}

public void Destroy (int id
                     )
{
        _IProfesorCAD.Destroy (id);
}

public ProfesorEN ReadOID (int id
                           )
{
        ProfesorEN profesorEN = null;

        profesorEN = _IProfesorCAD.ReadOID (id);
        return profesorEN;
}

public System.Collections.Generic.IList<ProfesorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProfesorEN> list = null;

        list = _IProfesorCAD.ReadAll (first, size);
        return list;
}
}
}
