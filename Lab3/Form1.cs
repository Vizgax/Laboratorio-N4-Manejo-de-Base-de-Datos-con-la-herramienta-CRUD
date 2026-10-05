

using Microsoft.Data.SqlClient;
using System.Data;

namespace Lab3
{
    public partial class Form1 : Form
    {
        // Conexión y variables utilizadas por el formulario.
        private readonly Conexion conexion = new Conexion();
        private byte[]? imagenActual;

        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarProductos()
        {
            try
            {
                using SqlConnection cn = new SqlConnection(Conexion.CadenaConexion);

                const string sql = @"
                    SELECT id, nombre, precio, cantidad, imagen
                    FROM dbo.productos
                    ORDER BY id;";

                using SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();

                using SqlDataReader reader = cmd.ExecuteReader();

                DGV_BD.Rows.Clear();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string nombre = reader["nombre"].ToString() ?? "";
                    decimal precio = Convert.ToDecimal(reader["precio"]);
                    int cantidad = Convert.ToInt32(reader["cantidad"]);

                    byte[]? datosImagen = null;

                    if (reader["imagen"] != DBNull.Value)
                        datosImagen = (byte[])reader["imagen"];

                    Image? imagen = BytesAImagen(datosImagen);

                    int fila = DGV_BD.Rows.Add(
                        id,
                        nombre,
                        precio.ToString("0.00"),
                        cantidad,
                        imagen);

                    DGV_BD.Rows[fila].Height = 70;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los productos.\n\n" +
                    "Verifica la conexión a SQL Server y el nombre de la base de datos.\n\n" +
                    ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {


            if (!ValidarCampos(false, out decimal precio, out int cantidad))
                return;

            try
            {
                using SqlConnection cn = new SqlConnection(Conexion.CadenaConexion);

                const string sql = @"
                    INSERT INTO dbo.productos (nombre, precio, cantidad, imagen)
                    VALUES (@nombre, @precio, @cantidad, @imagen);";

                using SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = TB_Nom.Text.Trim();

                SqlParameter pPrecio = cmd.Parameters.Add("@precio", SqlDbType.Decimal);
                pPrecio.Precision = 10;
                pPrecio.Scale = 2;
                pPrecio.Value = precio;

                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
                cmd.Parameters.Add("@imagen", SqlDbType.VarBinary, -1).Value =
                    imagenActual ?? Array.Empty<byte>();

                cn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Producto guardado correctamente.",
                    "Guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo guardar el producto.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void BTN_Mod_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(TB_ID.Text.Trim(), out int id))
            {
                MessageBox.Show(
                    "Selecciona un producto de la tabla para modificarlo.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos(false, out decimal precio, out int cantidad))
                return;

            try
            {
                using SqlConnection cn = new SqlConnection(Conexion.CadenaConexion);

                const string sql = @"
                    UPDATE dbo.productos
                    SET nombre = @nombre,
                        precio = @precio,
                        cantidad = @cantidad,
                        imagen = @imagen
                    WHERE id = @id;";

                using SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = TB_Nom.Text.Trim();

                SqlParameter pPrecio = cmd.Parameters.Add("@precio", SqlDbType.Decimal);
                pPrecio.Precision = 10;
                pPrecio.Scale = 2;
                pPrecio.Value = precio;

                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
                cmd.Parameters.Add("@imagen", SqlDbType.VarBinary, -1).Value =
                    imagenActual ?? Array.Empty<byte>();

                cn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    MessageBox.Show(
                        "No se encontró el producto indicado.",
                        "Modificar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(
                    "Producto modificado correctamente.",
                    "Modificar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo modificar el producto.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void BTN_Elim_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(TB_ID.Text.Trim(), out int id))
            {
                MessageBox.Show(
                    "Selecciona un producto de la tabla para eliminarlo.",
                    "Eliminar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Deseas eliminar el producto seleccionado?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                using SqlConnection cn = new SqlConnection(Conexion.CadenaConexion);

                const string sql = "DELETE FROM dbo.productos WHERE id = @id;";

                using SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    MessageBox.Show(
                        "No se encontró el producto indicado.",
                        "Eliminar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(
                    "Producto eliminado correctamente.",
                    "Eliminar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el producto.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void BTN_Clean_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            TB_ID.Clear();
            TB_Nom.Clear();
            TB_Prec.Clear();
            TB_Cant.Clear();

            imagenActual = null;

            if (PB_IMG.Image != null)
            {
                Image imagenAnterior = PB_IMG.Image;
                PB_IMG.Image = null;
                imagenAnterior.Dispose();
            }

            DGV_BD.ClearSelection();
            TB_Nom.Focus();
        }

        private void BTN_AgIMG_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialogo = new OpenFileDialog
            {
                Title = "Seleccionar imagen",
                Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Multiselect = false
            };

            if (dialogo.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                // Se copia el archivo a memoria para poder almacenarlo en VARBINARY(MAX).
                imagenActual = File.ReadAllBytes(dialogo.FileName);

                using MemoryStream ms = new MemoryStream(imagenActual);
                using Image imagenTemporal = Image.FromStream(ms);

                if (PB_IMG.Image != null)
                {
                    Image anterior = PB_IMG.Image;
                    PB_IMG.Image = null;
                    anterior.Dispose();
                }

                PB_IMG.Image = new Bitmap(imagenTemporal);
            }
            catch (Exception ex)
            {
                imagenActual = null;

                MessageBox.Show(
                    "No se pudo cargar la imagen.\n\n" + ex.Message,
                    "Imagen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void DGV_BD_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= DGV_BD.Rows.Count)
                return;

            DataGridViewRow fila = DGV_BD.Rows[e.RowIndex];

            if (fila.Cells["ID_Col"].Value == null)
                return;

            TB_ID.Text = fila.Cells["ID_Col"].Value.ToString();
            TB_Nom.Text = fila.Cells["Nom_Col"].Value?.ToString() ?? "";
            TB_Prec.Text = fila.Cells["Prec_Col"].Value?.ToString() ?? "";
            TB_Cant.Text = fila.Cells["Cant_Col"].Value?.ToString() ?? "";

            if (fila.Cells["Img_Col"].Value is Image imagen)
            {
                imagenActual = ImagenABytes(imagen);

                if (PB_IMG.Image != null)
                {
                    Image anterior = PB_IMG.Image;
                    PB_IMG.Image = null;
                    anterior.Dispose();
                }

                PB_IMG.Image = new Bitmap(imagen);
            }
            else
            {
                imagenActual = null;

                if (PB_IMG.Image != null)
                {
                    Image anterior = PB_IMG.Image;
                    PB_IMG.Image = null;
                    anterior.Dispose();
                }
            }
        }

        private bool ValidarCampos(
            bool requiereId,
            out decimal precio,
            out int cantidad)
        {
            precio = 0;
            cantidad = 0;

            if (requiereId && !int.TryParse(TB_ID.Text.Trim(), out _))
            {
                MessageBox.Show(
                    "El ID no es válido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TB_Nom.Text))
            {
                MessageBox.Show(
                    "Escribe el nombre del producto.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                TB_Nom.Focus();
                return false;
            }

            if (!decimal.TryParse(
                    TB_Prec.Text.Trim(),
                    System.Globalization.NumberStyles.Number,
                    System.Globalization.CultureInfo.CurrentCulture,
                    out precio) || precio < 0)
            {
                MessageBox.Show(
                    "Escribe un precio válido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                TB_Prec.Focus();
                return false;
            }

            if (!int.TryParse(TB_Cant.Text.Trim(), out cantidad) || cantidad < 0)
            {
                MessageBox.Show(
                    "Escribe una cantidad válida.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                TB_Cant.Focus();
                return false;
            }

            return true;
        }

        private static Image? BytesAImagen(byte[]? datos)
        {
            if (datos == null || datos.Length == 0)
                return null;

            try
            {
                using MemoryStream ms = new MemoryStream(datos);
                using Image temporal = Image.FromStream(ms);
                return new Bitmap(temporal);
            }
            catch
            {
                return null;
            }
        }

        private static byte[] ImagenABytes(Image imagen)
        {
            using MemoryStream ms = new MemoryStream();
            imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }
}