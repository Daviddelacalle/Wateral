

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
 *      Definition of the class MatriculaCEN
 *
 */
public partial class MatriculaCEN
{
private IMatriculaCAD _IMatriculaCAD;

public MatriculaCEN()
{
        this._IMatriculaCAD = new MatriculaCAD ();
}

public MatriculaCEN(IMatriculaCAD _IMatriculaCAD)
{
        this._IMatriculaCAD = _IMatriculaCAD;
}

public IMatriculaCAD get_IMatriculaCAD ()
{
        return this._IMatriculaCAD;
}

public int New_ (int p_curso, int p_alumno)
{
        MatriculaEN matriculaEN = null;
        int oid;

        //Initialized MatriculaEN
        matriculaEN = new MatriculaEN ();

        if (p_curso != -1) {
                // El argumento p_curso -> Property curso es oid = false
                // Lista de oids id
                matriculaEN.Curso = new WateralGenNHibernate.EN.Wateral.CursoEN ();
                matriculaEN.Curso.Id = p_curso;
        }


        if (p_alumno != -1) {
                // El argumento p_alumno -> Property alumno es oid = false
                // Lista de oids id
                matriculaEN.Alumno = new WateralGenNHibernate.EN.Wateral.AlumnoEN ();
                matriculaEN.Alumno.Idalumno = p_alumno;
        }

        //Call to MatriculaCAD

        oid = _IMatriculaCAD.New_ (matriculaEN);
        return oid;
}

public void Modify (int p_Matricula_OID)
{
        MatriculaEN matriculaEN = null;

        //Initialized MatriculaEN
        matriculaEN = new MatriculaEN ();
        matriculaEN.Id = p_Matricula_OID;
        //Call to MatriculaCAD

        _IMatriculaCAD.Modify (matriculaEN);
}

public void Destroy (int id
                     )
{
        _IMatriculaCAD.Destroy (id);
}

public MatriculaEN ReadOID (int id
                            )
{
        MatriculaEN matriculaEN = null;

        matriculaEN = _IMatriculaCAD.ReadOID (id);
        return matriculaEN;
}

public System.Collections.Generic.IList<MatriculaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MatriculaEN> list = null;

        list = _IMatriculaCAD.ReadAll (first, size);
        return list;
}
}
}
