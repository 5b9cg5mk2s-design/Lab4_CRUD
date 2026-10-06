using System.Collections.Generic;

namespace Labb4Productos
{
    public interface IProductoRepository
    {
        bool Insertar(Dictionary<string, object> data);
        List<Producto> ObtenerTodos(string filtro);
        bool Actualizar(Producto producto);
        bool Anular(int id); // Reemplaza la eliminación física por la lógica
    }
}
