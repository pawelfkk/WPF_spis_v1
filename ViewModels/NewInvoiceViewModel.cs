using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class NewInvoiceViewModel : WorkspaceViewModel
    {
        #region Konstruktor
        public NewInvoiceViewModel()
        {
            base.DisplayName = "Nowa faktura";
        }
        #endregion
    }
}
