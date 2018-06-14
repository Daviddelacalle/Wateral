

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
 *      Definition of the class GrupoCEN
 *
 */
public partial class GrupoCEN
{
private IGrupoCAD _IGrupoCAD;

public GrupoCEN()
{
        this._IGrupoCAD = new GrupoCAD ();
}

public GrupoCEN(IGrupoCAD _IGrupoCAD)
{
        this._IGrupoCAD = _IGrupoCAD;
}

public IGrupoCAD get_IGrupoCAD ()
{
        return this._IGrupoCAD;
}

public int New_ (int p_curso, int p_profesor, int p_maxalumnos, string p_horario)
{
        GrupoEN grupoEN = null;
        int oid;

        //Initialized GrupoEN
        grupoEN = new GrupoEN ();

        if (p_curso != -1) {
                // El argumento p_curso -> Property curso es oid = false
                // Lista de oids id
                grupoEN.Curso = new WateralGenNHibernate.EN.Wateral.CursoEN ();
                grupoEN.Curso.Id = p_curso;
        }


        if (p_profesor != -1) {
                // El argumento p_profesor -> Property profesor es oid = false
                // Lista de oids id
                grupoEN.Profesor = new WateralGenNHibernate.EN.Wateral.ProfesorEN ();
                grupoEN.Profesor.Id = p_profesor;
        }

        grupoEN.Maxalumnos = p_maxalumnos;

        grupoEN.Horario = p_horario;

        //Call to GrupoCAD

        oid = _IGrupoCAD.New_ (grupoEN);
        return oid;
}

public void Modify (int p_Grupo_OID, int p_maxalumnos, string p_horario)
{
        GrupoEN grupoEN = null;

        //Initialized GrupoEN
        grupoEN = new GrupoEN ();
        grupoEN.Id = p_Grupo_OID;
        grupoEN.Maxalumnos = p_maxalumnos;
        grupoEN.Horario = p_horario;
        //Call to GrupoCAD

        _IGrupoCAD.Modify (grupoEN);
}

public void Destroy (int id
                     )
{
        _IGrupoCAD.Destroy (id);
}

public GrupoEN ReadOID (int id
                        )
{
        GrupoEN grupoEN = null;

        grupoEN = _IGrupoCAD.ReadOID (id);
        return grupoEN;
}

public System.Collections.Generic.IList<GrupoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<GrupoEN> list = null;

        list = _IGrupoCAD.ReadAll (first, size);
        return list;
}
}
}
