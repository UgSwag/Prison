using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using prison.Commands;

namespace prison.ModelViews
{
    class RecordsViewModel
    {
        public ICommand ReloadGrid { get; set; }
        public RecordsViewModel()
        {
            ReloadGrid = new UpdateRecordCommander();
        }
    }
}
