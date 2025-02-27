#region License
/* 
* Copyright (C) 1999-2023 John Källén.
*
* This program is free software; you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation; either version 2, or (at your option)
* any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program; see the file COPYING.  If not, write to
* the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA.
*/
#endregion

using Reko.Core;
using Reko.Core.Services;
using Reko.Gui.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace Reko.Gui.Forms
{
    public interface IAnalyzedPageInteractor : IPhasePageInteractor
    {
    }

	public class AnalyzedPageInteractorImpl : PhasePageInteractorImpl, IAnalyzedPageInteractor
	{
        private IDisassemblyViewService disasmViewerSvc;
        private IProjectBrowserService projectSvc;
        private bool canAdvance;

		public AnalyzedPageInteractorImpl(IServiceProvider services) : base(services)
		{
            disasmViewerSvc = services.RequireService<IDisassemblyViewService>();
            projectSvc = services.RequireService<IProjectBrowserService>();

            this.canAdvance = true;
		}

        public override void PerformWork(IWorkerDialogService workerDlgSvc)
        {
            workerDlgSvc.SetCaption("Generating intermediate code");
            Decompiler?.AnalyzeDataFlow();
        }

        public override bool CanAdvance
        {
            get { return canAdvance; }
        }

        public override void EnterPage()
        {
            projectSvc.Reload();
        }

		public override bool LeavePage()
		{
			return true;
        }

        public override IPhasePageInteractor NextPage(DecompilerPhases decompilerPhases)
        {
            return decompilerPhases.Final;
        }

        public KeyValuePair<Address, Procedure> SelectedProcedureEntry
        {
            get
            {
                return new KeyValuePair<Address, Procedure>(null!, null!);
            }
        }

        #region ICommandTarget interface 
        public override bool QueryStatus(CommandID cmdId, CommandStatus status, CommandText text)
        {
            if (cmdId.Guid == CmdSets.GuidReko)
            {
                switch ((CmdIds)cmdId.ID)
                {
                case CmdIds.ActionFinishDecompilation:
                case CmdIds.ActionRestartDecompilation:
                    status.Status = MenuStatus.Visible | MenuStatus.Enabled;
                    return true;
                case CmdIds.ActionNextPhase:
                    status.Status = MenuStatus.Visible | MenuStatus.Enabled;
                    text.Text = Resources.ReconstructDataTypes;
                    return true;
                }
            }
            return base.QueryStatus(cmdId, status, text);
        }

        public override ValueTask<bool> ExecuteAsync(CommandID cmdId)
        {
            if (cmdId.Guid == CmdSets.GuidReko)
            {
            }
            return base.ExecuteAsync(cmdId);
        }

        #endregion

	}
}
