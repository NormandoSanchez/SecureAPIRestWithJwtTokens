using System.Data;
using System.Reflection;

namespace SecureAPIRestWithJwtTokens.Tools
{
    public static class DataSetExtensions
    {
        /// <summary>
        /// Convierte un DataTable en una lista de objetos del tipo especificado.
        /// Asigna los valores de las columnas del DataTable a las propiedades del objeto que coinciden en nombre.
        /// </summary>
        /// <typeparam name="T">Tipo</typeparam>
        /// <param name="dt">Datatable</param>
        /// <returns></returns>
        public static List<T>? MapToList<T>(this DataTable dt) where T : new()
        {
            List<T>? entities = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                var entity = typeof(T);
                entities = [];
                var propDict = new Dictionary<string, PropertyInfo>();
                var props = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                propDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);

                foreach (DataRow dr in dt.Rows)
                {
                    T newObject = new();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (propDict.ContainsKey(dc.ColumnName.ToUpper()))
                        {
                            var info = propDict[dc.ColumnName.ToUpper()];
                            if ((info != null) && info.CanWrite)
                            {
                                var val = dr[dc.ColumnName];
                                info.SetValue(newObject, (val == DBNull.Value) ? null : val, null);
                            }
                        }
                    }
                    entities.Add(newObject);
                }
            }

            return entities;
        }
    }
}
