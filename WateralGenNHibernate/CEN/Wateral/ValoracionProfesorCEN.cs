

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
 *      Definition of the class ValoracionProfesorCEN
 *
 */
public partial class ValoracionProfesorCEN
{
private IValoracionProfesorCAD _IValoracionProfesorCAD;

public ValoracionProfesorCEN()
{
        this._IValoracionProfesorCAD = new ValoracionProfesorCAD ();
}

public ValoracionProfesorCEN(IValoracionProfesorCAD _IValoracionProfesorCAD)
{
        this._IValoracionProfesorCAD = _IValoracionProfesorCAD;
}

public IValoracionProfesorCAD get_IValoracionProfesorCAD ()
{
        return this._IValoracionProfesorCAD;
}

public int New_ (int p_nota, int p_alumno_0, int p_profesor)
{
        ValoracionProfesorEN valoracionProfesorEN = null;
        int oid;

        //Initialized ValoracionProfesorEN
        valoracionProfesorEN = new ValoracionProfesorEN ();
        valoracionProfesorEN.Nota = p_nota;


        if (p_alumno_0 != -1) {
                // El argumento p_alumno_0 -> Property alumno_0 es oid = false
                // Lista de oids id_valoracion
                valoracionProfesorEN.Alumno_0 = new WateralGenNHibernate.EN.Wateral.AlumnoEN ();
                valoracionProfesorEN.Alumno_0.Idalumno = p_alumno_0;
        }


        if (p_profesor != -1) {
                // El argumento p_profesor -> Property profesor es oid = false
                // Lista de oids id_valoracion
                valoracionProfesorEN.Profesor = new WateralGenNHibernate.EN.Wateral.ProfesorEN ();
                valoracionProfesorEN.Profesor.Id = p_profesor;
        }

        //Call to ValoracionProfesorCAD

        oid = _IValoracionProfesorCAD.New_ (valoracionProfesorEN);
        return oid;
}

public void Modify (int p_ValoracionProfesor_OID, int p_nota)
{
        ValoracionProfesorEN valoracionProfesorEN = null;

        //Initialized ValoracionProfesorEN
        valoracionProfesorEN = new ValoracionProfesorEN ();
        valoracionProfesorEN.Id_valoracion = p_ValoracionProfesor_OID;
        valoracionProfesorEN.Nota = p_nota;
        //Call to ValoracionProfesorCAD

        _IValoracionProfesorCAD.Modify (valoracionProfesorEN);
}

public void Destroy (int id_valoracion
                     )
{
        _IValoracionProfesorCAD.Destroy (id_valoracion);
}

public ValoracionProfesorEN ReadOID (int id_valoracion
                                     )
{
        ValoracionProfesorEN valoracionProfesorEN = null;

        valoracionProfesorEN = _IValoracionProfesorCAD.ReadOID (id_valoracion);
        return valoracionProfesorEN;
}

public System.Collections.Generic.IList<ValoracionProfesorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionProfesorEN> list = null;

        list = _IValoracionProfesorCAD.ReadAll (first, size);
        return list;
}
}
}
