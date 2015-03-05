using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Unvired.Kernel.Model;
using Unvired.Kernel.Database;
#if UNVIRED_WIN8
using Unvired.Kernel.SQLite;
#endif

namespace Entity {
	/*
	This class represents Business Entity Header for 
	*/	
	public class MATERIAL_HEADER : DataStructure {
		
		
		// 
		private string _MATERIAL_NO;

		// 
		private string _MATERIAL_DESC;

		// 
		private string _MATERIAL_TYPE;

		// 
		private string _DEFAULT_UOM;

	
		internal static bool IsHeader {
			get {
			    return true;
			}
	    }
		
		[Unique]
	
		public string MATERIAL_NO { 
			get {
				return _MATERIAL_NO;
			}
			set {
				_MATERIAL_NO = value;
				RaisePropertyChanged("MATERIAL_NO");
			}
		}

		public string MATERIAL_DESC { 
			get {
				return _MATERIAL_DESC;
			}
			set {
				_MATERIAL_DESC = value;
				RaisePropertyChanged("MATERIAL_DESC");
			}
		}

		public string MATERIAL_TYPE { 
			get {
				return _MATERIAL_TYPE;
			}
			set {
				_MATERIAL_TYPE = value;
				RaisePropertyChanged("MATERIAL_TYPE");
			}
		}

		public string DEFAULT_UOM { 
			get {
				return _DEFAULT_UOM;
			}
			set {
				_DEFAULT_UOM = value;
				RaisePropertyChanged("DEFAULT_UOM");
			}
		}

	}
}

