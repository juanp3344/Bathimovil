using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class TiposPortatilesModel : PageModel
    {
        private ITipos_PortatilesPresentacion? ITiposPortatiles_Presentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;
        private readonly IWebHostEnvironment _env; // ← AGREGAR
        [BindProperty] public List<Tipos_Portatiles>? Lista { get; set; }
        [BindProperty] public Tipos_Portatiles? Tipos_Portatiles { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public IFormFile? ImagenFile { get; set; }

        public TiposPortatilesModel(IWebHostEnvironment env)
        {
               _env = env; 
            ITiposPortatiles_Presentacion = new Tipos_PortatilesPresentacion(); 
            IAuditoriasPresentacion = new AuditoriasPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (ITiposPortatiles_Presentacion == null)
                    return;
                Lista = ITiposPortatiles_Presentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");
                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista t portatil", usuario);
                Tipos_Portatiles = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Tipos_Portatiles = Lista!.FirstOrDefault(x => x.Id_Tipo_Portatil == data);
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public async Task OnPostBtGuardar() 
        {
            try
            {
                var usuario = HttpContext.Session.GetString("Usuario");
                if (Tipos_Portatiles == null)
                    return;

                if (ImagenFile != null && ImagenFile.Length > 0)
                {
                    var carpeta = Path.Combine(_env.WebRootPath, "images", "portatiles");
                    Directory.CreateDirectory(carpeta); // crea carpeta si no existe

                    // Borrar imagen anterior si existe
                    if (!string.IsNullOrEmpty(Tipos_Portatiles.ImagenUrl))
                    {
                        var rutaAnterior = Path.Combine(_env.WebRootPath,
                                           Tipos_Portatiles.ImagenUrl.TrimStart('/'));
                        if (System.IO.File.Exists(rutaAnterior))
                            System.IO.File.Delete(rutaAnterior);
                    }

                    var nombreArchivo = Guid.NewGuid() + Path.GetExtension(ImagenFile.FileName);
                    var rutaCompleta = Path.Combine(carpeta, nombreArchivo);

                    using var stream = new FileStream(rutaCompleta, FileMode.Create);
                    await ImagenFile.CopyToAsync(stream);

                    Tipos_Portatiles.ImagenUrl = "/images/portatiles/" + nombreArchivo;
                }
                // ── FIN BLOQUE IMAGEN ─────────────────────────

                if (Tipos_Portatiles.Id_Tipo_Portatil == 0)
                {
                    Tipos_Portatiles = ITiposPortatiles_Presentacion!.Guardar(Tipos_Portatiles!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un t portatil", usuario);
                }
                else
                    Tipos_Portatiles = ITiposPortatiles_Presentacion!.Modificar(Tipos_Portatiles!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un t portatil", usuario);

                if (Tipos_Portatiles.Id_Tipo_Portatil == 0)
                    return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Tipos_Portatiles == null)
                    return;
                Tipos_Portatiles = ITiposPortatiles_Presentacion!.Eliminar(Tipos_Portatiles!);
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un t portatil", usuario);
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Tipos_Portatiles = Lista!.FirstOrDefault(x => x.Id_Tipo_Portatil == data);
                Lista = null;
                Borrando = true;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }

    }

    
    }
