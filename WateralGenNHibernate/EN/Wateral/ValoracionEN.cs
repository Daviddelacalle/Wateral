
using System;
// Definición clase ValoracionEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class ValoracionEN
{
/**
 *	Atributo id_valoracion
 */
private int id_valoracion;



/**
 *	Atributo nota
 */
private int nota;



/**
 *	Atributo comentario
 */
private string comentario;






public virtual int Id_valoracion {
        get { return id_valoracion; } set { id_valoracion = value;  }
}



public virtual int Nota {
        get { return nota; } set { nota = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int id_valoracion, int nota, string comentario
                    )
{
        this.init (Id_valoracion, nota, comentario);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (Id_valoracion, valoracion.Nota, valoracion.Comentario);
}

private void init (int id_valoracion
                   , int nota, string comentario)
{
        this.Id_valoracion = id_valoracion;


        this.Nota = nota;

        this.Comentario = comentario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
        if (t == null)
                return false;
        if (Id_valoracion.Equals (t.Id_valoracion))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id_valoracion.GetHashCode ();
        return hash;
}
}
}
