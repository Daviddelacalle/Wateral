

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
 *      Definition of the class AlumnoCEN
 *
 */
public partial class AlumnoCEN
{
private IAlumnoCAD _IAlumnoCAD;

public AlumnoCEN()
{
        this._IAlumnoCAD = new AlumnoCAD ();
}

public AlumnoCEN(IAlumnoCAD _IAlumnoCAD)
{
        this._IAlumnoCAD = _IAlumnoCAD;
}

public IAlumnoCAD get_IAlumnoCAD ()
{
        return this._IAlumnoCAD;
}

public int New_ (string p_disponibilidad, string p_salud, int p_peso, WateralGenNHibernate.Enumerated.Wateral.TallaEnum p_talla, int p_numPie, string p_DNI, System.Collections.Generic.IList<int> p_grupos, string p_userRegistrado)
{
        AlumnoEN alumnoEN = null;
        int oid;

        //Initialized AlumnoEN
        alumnoEN = new AlumnoEN ();
        alumnoEN.Disponibilidad = p_disponibilidad;

        alumnoEN.Salud = p_salud;

        alumnoEN.Peso = p_peso;

        alumnoEN.Talla = p_talla;

        alumnoEN.NumPie = p_numPie;

        alumnoEN.DNI = p_DNI;


        alumnoEN.Grupos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.GrupoEN>();
        if (p_grupos != null) {
                foreach (int item in p_grupos) {
                        WateralGenNHibernate.EN.Wateral.GrupoEN en = new WateralGenNHibernate.EN.Wateral.GrupoEN ();
                        en.Id = item;
                        alumnoEN.Grupos.Add (en);
                }
        }

        else{
                alumnoEN.Grupos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.GrupoEN>();
        }


        if (p_userRegistrado != null) {
                // El argumento p_userRegistrado -> Property userRegistrado es oid = false
                // Lista de oids idalumno
                alumnoEN.UserRegistrado = new WateralGenNHibernate.EN.Wateral.UserRegistradoEN ();
                alumnoEN.UserRegistrado.Email = p_userRegistrado;
        }

        //Call to AlumnoCAD

        oid = _IAlumnoCAD.New_ (alumnoEN);
        return oid;
}

public void Modify (int p_Alumno_OID, string p_disponibilidad, string p_salud, int p_peso, WateralGenNHibernate.Enumerated.Wateral.TallaEnum p_talla, int p_numPie, string p_DNI)
{
        AlumnoEN alumnoEN = null;

        //Initialized AlumnoEN
        alumnoEN = new AlumnoEN ();
        alumnoEN.Idalumno = p_Alumno_OID;
        alumnoEN.Disponibilidad = p_disponibilidad;
        alumnoEN.Salud = p_salud;
        alumnoEN.Peso = p_peso;
        alumnoEN.Talla = p_talla;
        alumnoEN.NumPie = p_numPie;
        alumnoEN.DNI = p_DNI;
        //Call to AlumnoCAD

        _IAlumnoCAD.Modify (alumnoEN);
}

public void Destroy (int idalumno
                     )
{
        _IAlumnoCAD.Destroy (idalumno);
}

public AlumnoEN ReadOID (int idalumno
                         )
{
        AlumnoEN alumnoEN = null;

        alumnoEN = _IAlumnoCAD.ReadOID (idalumno);
        return alumnoEN;
}

public System.Collections.Generic.IList<AlumnoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AlumnoEN> list = null;

        list = _IAlumnoCAD.ReadAll (first, size);
        return list;
}
public long CuentaAlumnos (int grupo)
{
        return _IAlumnoCAD.CuentaAlumnos (grupo);
}
}
}
