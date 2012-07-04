using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JediHelper
/// </summary>
public class JediHelper
{
	public JediHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static List<Jedi> Listado()
    {
        List<Jedi> lista = new List<Jedi>();

        lista.Add(new Jedi {@Nombre = "Yoda", @Especie = "Especie de Yoda", @FechaNacimiento = "896 BBY", @ImagenURL = "http://images3.wikia.nocookie.net/starwars/images/thumb/4/45/Yoda.jpg/250px-Yoda.jpg", @GUID = new Guid("18c85181-86b0-440c-ab10-eb1732d6f5ae") });
        lista.Add(new Jedi { @Nombre = "Obi-Wan \"Ben\" Kenobi", @Especie = "Humano", @FechaNacimiento = "57 BBY", @ImagenURL = "http://images2.wikia.nocookie.net/starwars/images/thumb/9/94/Obi-wan_headshot.jpg/250px-Obi-wan_headshot.jpg", @GUID = new Guid("99ef0a17-6692-4fd8-9363-8cc597448fa8") });
        lista.Add(new Jedi { @Nombre = "Qui-Gon Jinn", @Especie = "Humano", @FechaNacimiento = "92 BBY", @ImagenURL = "http://images2.wikia.nocookie.net/starwars/images/thumb/c/c0/Quigonheadshot.jpg/250px-Quigonheadshot.jpg", @GUID = new Guid("3a6b0879-b2f0-49ed-8eff-b1cae5e80089") });
        lista.Add(new Jedi { @Nombre = "Anakin Skywalker", @Especie = "Humano", @FechaNacimiento = "41.9 BBY", @ImagenURL = "http://images3.wikia.nocookie.net/__cb20090414190851/starwars/images/thumb/8/89/AnakinEstGrumpy.jpg/250px-AnakinEstGrumpy.jpg", @GUID = new Guid("a61a831a-8372-4b4c-b34a-bb239c8ddae0") });
        lista.Add(new Jedi { @Nombre = "Ki(-Adi - Mundi)", @Especie = "Cerean", @FechaNacimiento = "92 BBY", @ImagenURL = "http://images3.wikia.nocookie.net/starwars/images/thumb/9/9e/KiAdiMundi.jpg/250px-KiAdiMundi.jpg", @GUID = new Guid("64a92cf5-3e16-460d-b7a6-4a5ad6fc8602") });


        return lista;
    }
}