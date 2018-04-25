using System;
using System.IO;
using System.Linq;
using ProyectoFinal5.Modelos.Entidades;
using SQLite;
using System.Collections.Generic;

namespace ProyectoFinal5.iOS.DAL.Local
{
    public static class BaseDatosHelper
    {
        static readonly string _baseDatos = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            "proyectofinal4.db3");

        public static void CrearBaseDatos()
        {
            if (!File.Exists(_baseDatos))
            {
                using (var db = new SQLiteConnection(_baseDatos))
                {
                    db.CreateTable<Models.Configuracion>();
                    db.CreateTable<Models.Coordenada>();
                }
            }
        }

        public static void InsertarConfiguracion(Models.Configuracion configuracion)
        {
            using (var db = new SQLiteConnection(_baseDatos))
            {
                var existente = db.Table<Models.Configuracion>()
                                  .Where(c => c.Clave == configuracion.Clave)
                                  .FirstOrDefault();

                if (existente != null)
                {
                    db.Delete<Models.Configuracion>(existente);
                }

                db.Insert(configuracion);
            }
        }

        public static Models.Configuracion ObtenerConfiguracion(string clave)
        {
            using (var db = new SQLiteConnection(_baseDatos))
            {
                return db.Table<Models.Configuracion>()
                         .FirstOrDefault(c => c.Clave == clave);
            }
        }

        public static void InsertarCoordenada(Models.Coordenada coordenada)
        {
            using (var db = new SQLiteConnection(_baseDatos))
            {
                db.Insert(coordenada);
            }
        }

        public static List<PosicionViaje> ObtenerPosicionesViaje(int idViaje)
        {
            using (var db = new SQLiteConnection(_baseDatos))
            {
                return db.Table<Models.Coordenada>()
                                    .AsEnumerable()
                                    .Where(c => c.ViajeId == idViaje)
                                    .Select(c =>
                {
                    return new PosicionViaje
                    {
                        ViajeId = c.ViajeId,
                        Fecha = c.Fecha,
                        Coordenada = new Coordenada
                        {
                            Latitud = c.Latitud,
                            Longitud = c.Longitud
                        }
                    };
                }).ToList();
            }
        }
    }
}
