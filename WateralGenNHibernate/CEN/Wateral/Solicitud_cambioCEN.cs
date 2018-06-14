

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
 *      Definition of the class Solicitud_cambioCEN
 *
 */
public partial class Solicitud_cambioCEN
{
private ISolicitud_cambioCAD _ISolicitud_cambioCAD;

public Solicitud_cambioCEN()
{
        this._ISolicitud_cambioCAD = new Solicitud_cambioCAD ();
}

public Solicitud_cambioCEN(ISolicitud_cambioCAD _ISolicitud_cambioCAD)
{
        this._ISolicitud_cambioCAD = _ISolicitud_cambioCAD;
}

public ISolicitud_cambioCAD get_ISolicitud_cambioCAD ()
{
        return this._ISolicitud_cambioCAD;
}

public int New_ (bool p_validado, int p_alumno, int p_grupo, int p_grupo_0)
{
        Solicitud_cambioEN solicitud_cambioEN = null;
        int oid;

        //Initialized Solicitud_cambioEN
        solicitud_cambioEN = new Solicitud_cambioEN ();
        solicitud_cambioEN.Validado = p_validado;


        if (p_alumno != -1) {
                // El argumento p_alumno -> Property alumno es oid = false
                // Lista de oids id
                solicitud_cambioEN.Alumno = new WateralGenNHibernate.EN.Wateral.AlumnoEN ();
                solicitud_cambioEN.Alumno.Idalumno = p_alumno;
        }


        if (p_grupo != -1) {
                // El argumento p_grupo -> Property grupo es oid = false
                // Lista de oids id
                solicitud_cambioEN.Grupo = new WateralGenNHibernate.EN.Wateral.GrupoEN ();
                solicitud_cambioEN.Grupo.Id = p_grupo;
        }


        if (p_grupo_0 != -1) {
                // El argumento p_grupo_0 -> Property grupo_0 es oid = false
                // Lista de oids id
                solicitud_cambioEN.Grupo_0 = new WateralGenNHibernate.EN.Wateral.GrupoEN ();
                solicitud_cambioEN.Grupo_0.Id = p_grupo_0;
        }

        //Call to Solicitud_cambioCAD

        oid = _ISolicitud_cambioCAD.New_ (solicitud_cambioEN);
        return oid;
}

public void Modify (int p_Solicitud_cambio_OID, bool p_validado)
{
        Solicitud_cambioEN solicitud_cambioEN = null;

        //Initialized Solicitud_cambioEN
        solicitud_cambioEN = new Solicitud_cambioEN ();
        solicitud_cambioEN.Id = p_Solicitud_cambio_OID;
        solicitud_cambioEN.Validado = p_validado;
        //Call to Solicitud_cambioCAD

        _ISolicitud_cambioCAD.Modify (solicitud_cambioEN);
}

public void Destroy (int id
                     )
{
        _ISolicitud_cambioCAD.Destroy (id);
}

public Solicitud_cambioEN ReadOID (int id
                                   )
{
        Solicitud_cambioEN solicitud_cambioEN = null;

        solicitud_cambioEN = _ISolicitud_cambioCAD.ReadOID (id);
        return solicitud_cambioEN;
}

public System.Collections.Generic.IList<Solicitud_cambioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<Solicitud_cambioEN> list = null;

        list = _ISolicitud_cambioCAD.ReadAll (first, size);
        return list;
}
}
}
