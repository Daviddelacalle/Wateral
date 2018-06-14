

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
 *      Definition of the class MatrículaCEN
 *
 */
public partial class MatrículaCEN
{
private IMatrículaCAD _IMatrículaCAD;

public MatrículaCEN()
{
        this._IMatrículaCAD = new MatrículaCAD ();
}

public MatrículaCEN(IMatrículaCAD _IMatrículaCAD)
{
        this._IMatrículaCAD = _IMatrículaCAD;
}

public IMatrículaCAD get_IMatrículaCAD ()
{
        return this._IMatrículaCAD;
}

public int New_ (int p_alumno, string p_curso)
{
        MatrículaEN matrículaEN = null;
        int oid;

        //Initialized MatrículaEN
        matrículaEN = new MatrículaEN ();

        if (p_alumno != -1) {
                // El argumento p_alumno -> Property alumno es oid = false
                // Lista de oids id
                matrículaEN.Alumno = new WateralGenNHibernate.EN.Wateral.AlumnoEN ();
                matrículaEN.Alumno.Idalumno = p_alumno;
        }


        if (p_curso != null) {
                // El argumento p_curso -> Property curso es oid = false
                // Lista de oids id
                matrículaEN.Curso = new WateralGenNHibernate.EN.Wateral.CursoEN ();
                matrículaEN.Curso.Nombre = p_curso;
        }

        //Call to MatrículaCAD

        oid = _IMatrículaCAD.New_ (matrículaEN);
        return oid;
}

public void Modify (int p_Matrícula_OID)
{
        MatrículaEN matrículaEN = null;

        //Initialized MatrículaEN
        matrículaEN = new MatrículaEN ();
        matrículaEN.Id = p_Matrícula_OID;
        //Call to MatrículaCAD

        _IMatrículaCAD.Modify (matrículaEN);
}

public void Destroy (int id
                     )
{
        _IMatrículaCAD.Destroy (id);
}

public MatrículaEN ReadOID (int id
                            )
{
        MatrículaEN matrículaEN = null;

        matrículaEN = _IMatrículaCAD.ReadOID (id);
        return matrículaEN;
}

public System.Collections.Generic.IList<MatrículaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MatrículaEN> list = null;

        list = _IMatrículaCAD.ReadAll (first, size);
        return list;
}
}
}
