// ******************************************************************
//
//	If this code works it was written by:
//		Henry Minute
//		MamSoft / Manniff Computers
//		© 2008 - 2009...
//
//	if not, I have no idea who wrote it.
//
// ******************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NestedControlDesignerTest
{
	public partial class NestedControlTestForm : Form
	{
		public NestedControlTestForm()
		{
			InitializeComponent();
		}

		private void NestedControlTestForm_Load(object sender, EventArgs e)
		{
			this.cboxNumbers.SelectedIndex = 0;
		}
	}
}
