using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using vehicles.API.Data;

namespace vehicles.API.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetComboBrands()
        {
            List<SelectListItem> list = _context.brands.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            })
            .OrderBy(x => x.Text)
            .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una marca...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboDocumentTypes()
        {
            List<SelectListItem> list = _context.documentTypes.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            })
            .OrderBy(x => x.Text)
            .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de documento...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboProcedures()
        {
            List<SelectListItem> list = _context.procedures.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            })
            .OrderBy(x => x.Text)
            .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Procedimiento...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboVehicleTypes()
        {
            List<SelectListItem> list = _context.vehicleTypes.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            })
            .OrderBy(x => x.Text)
            .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de vehiculo...]",
                Value = "0"
            });

            return list;
        }
    }
}
