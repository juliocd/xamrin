using System;
namespace tables_android.Models
{
    public class Planeta
    {
        string nombre;
        public string Nombre 
        { 
            set{
                nombre = value;
            } get{
                return nombre;
            } 
        }

        string descripcion;
		public string Descripcion
		{
			set
			{
				descripcion = value;
			}
			get
			{
				return descripcion;
			}
		}

        string imagen;
        public string Imagen
		{
			set
			{
				imagen = value;
			}
			get
			{
				return imagen;
			}
		}

        public Planeta(string _nombre, string _descripcion)
        {
            this.nombre = _nombre;
            this.descripcion = _descripcion;
        }
    }
}
