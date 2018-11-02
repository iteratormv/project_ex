using Exhibition.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Data.BizLayer
{
	public class PharmaVisitor
	{
		public int pId { get; set; }
		public string pForName { get; set; }
		public string pSurName { get; set; }
		public string pConpany { get; set; }
		public string pJobTitle { get; set; }
		public string pCustomerNo { get; set; }
		public string pRowNumber { get; set; }
		public string pBarcode { get; set; }
		public string pDescription { get; set; }
		public string pRegDate { get; set; }
		public string pPaymentStatus { get; set; }
		public string pPaymentComment { get; set; }
		public string pStatus { get; set; }

		public PharmaVisitor() { }

		public PharmaVisitor(ExhibitionVisitor select_visitor)
		{
			pId = select_visitor.Id;
			pSurName = select_visitor.LastName;
			pForName = select_visitor.FirstName;
			pConpany = select_visitor.Company.Name;
			pJobTitle = select_visitor.Position.Name;
			pCustomerNo = select_visitor.Email;
			pRowNumber = select_visitor.PhoneNumber;
			pBarcode = select_visitor.BarCode;
			pDescription = select_visitor.Description.Name;
			pRegDate = select_visitor.DateCreated.ToString();
			pPaymentStatus = select_visitor.Payment_Status;
			pPaymentComment = select_visitor.Payment_Status_Comment;
			pStatus = select_visitor.Status;
		}

		public PharmaVisitor(ExhibitionVisitor select_visitor, ExhibitionDataForContext context)
		{
			pId = select_visitor.Id;
			pSurName = select_visitor.LastName;
			pForName = select_visitor.FirstName;
			pConpany = context.Companies.Where(c => c.Id == select_visitor.CompanyId).Select(s => s.Name).FirstOrDefault();
			pJobTitle = context.Positions.Where(p => p.Id == select_visitor.PositionId).Select(s => s.Name).FirstOrDefault();
			pCustomerNo = select_visitor.Email;
			pRowNumber = select_visitor.PhoneNumber;
			pBarcode = select_visitor.BarCode;
			pDescription = context.Descriptions.Where(d => d.Id == select_visitor.DescriptionId).Select(s => s.Name).FirstOrDefault();
			pRegDate = select_visitor.DateCreated.ToString();
			pPaymentStatus = select_visitor.Payment_Status;
			pPaymentComment = select_visitor.Payment_Status_Comment;
			pStatus = select_visitor.Status;
		}
	}
}
