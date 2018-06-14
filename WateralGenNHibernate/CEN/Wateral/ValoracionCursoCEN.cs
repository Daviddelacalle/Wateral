

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
 *      Definition of the class ValoracionCursoCEN
 *
 */
public partial class ValoracionCursoCEN
{
private IValoracionCursoCAD _IValoracionCursoCAD;

public ValoracionCursoCEN()
{
        this._IValoracionCursoCAD = new ValoracionCursoCAD ();
}

public ValoracionCursoCEN(IValoracionCursoCAD _IValoracionCursoCAD)
{
        this._IValoracionCursoCAD = _IValoracionCursoCAD;
}

public IValoracionCursoCAD get_IValoracionCursoCAD ()
{
        return this._IValoracionCursoCAD;
}

public int New_ (int p_nota, int p_alumno, int p_curso)
{
        ValoracionCursoEN valoracionCursoEN = null;
        int oid;

        //Initialized ValoracionCursoEN
        valoracionCursoEN = new ValoracionCursoEN ();
        valoracionCursoEN.Nota = p_nota;


        if (p_alumno != -1) {
                // El argumento p_alumno -> Property alumno es oid = false
                // Lista de oids id_valoracion
                valoracionCursoEN.Alumno = new WateralGenNHibernate.EN.Wateral.AlumnoEN ();
                valoracionCursoEN.Alumno.Idalumno = p_alumno;
        }


        if (p_curso != -1) {
                // El argumento p_curso -> Property curso es oid = false
                // Lista de oids id_valoracion
                valoracionCursoEN.Curso = new WateralGenNHibernate.EN.Wateral.CursoEN ();
                valoracionCursoEN.Curso.Id = p_curso;
        }

        //Call to ValoracionCursoCAD

        oid = _IValoracionCursoCAD.New_ (valoracionCursoEN);
        return oid;
}

public void Modify (int p_ValoracionCurso_OID, int p_nota)
{
        ValoracionCursoEN valoracionCursoEN = null;

        //Initialized ValoracionCursoEN
        valoracionCursoEN = new ValoracionCursoEN ();
        valoracionCursoEN.Id_valoracion = p_ValoracionCurso_OID;
        valoracionCursoEN.Nota = p_nota;
        //Call to ValoracionCursoCAD

        _IValoracionCursoCAD.Modify (valoracionCursoEN);
}

public void Destroy (int id_valoracion
                     )
{
        _IValoracionCursoCAD.Destroy (id_valoracion);
}

public ValoracionCursoEN ReadOID (int id_valoracion
                                  )
{
        ValoracionCursoEN valoracionCursoEN = null;

        valoracionCursoEN = _IValoracionCursoCAD.ReadOID (id_valoracion);
        return valoracionCursoEN;
}

public System.Collections.Generic.IList<ValoracionCursoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionCursoEN> list = null;

        list = _IValoracionCursoCAD.ReadAll (first, size);
        return list;
}
}
}
