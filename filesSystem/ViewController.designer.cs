// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace filesSystem
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton createButton { get; set; }

		[Outlet]
		UIKit.UIButton FileButton { get; set; }

		[Outlet]
		UIKit.UIButton logLoopButton { get; set; }

		[Outlet]
		UIKit.UIButton readButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (FileButton != null) {
				FileButton.Dispose ();
				FileButton = null;
			}

			if (readButton != null) {
				readButton.Dispose ();
				readButton = null;
			}

			if (createButton != null) {
				createButton.Dispose ();
				createButton = null;
			}

			if (logLoopButton != null) {
				logLoopButton.Dispose ();
				logLoopButton = null;
			}
		}
	}
}
