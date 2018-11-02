using Exhibition.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Data.BizLayer
{
	public class BizVisitor
	{
		public int vId { get; set; }
		public string vLastName { get; set; }
		public string vFirstName { get; set; }
		public string vPathronim { get; set; }
		public string vConpany { get; set; }
		public string vPosition { get; set; }
		public string vBarcode { get; set; }
		public string vDescription { get; set; }
		public string vPhoneMobile { get; set; }
		public string vPhoneWork { get; set; }
		public string vEmail { get; set; }
		public string vRegDate { get; set; }
		public string vExhibit { get; set; }
		public string vRaport { get; set; }
		public string vCity { get; set; }
		public string vStatus { get; set; }


		public BizVisitor() { }


		public BizVisitor(ExhibitionVisitor select_visitor, ExhibitionDataForContext context)
		{
			vId = select_visitor.Id;
			vLastName = select_visitor.LastName;
			vFirstName = select_visitor.FirstName;
			vPathronim = select_visitor.Pathronim;
			vConpany = context.Companies.Where(c => c.Id == select_visitor.CompanyId).Select(s => s.Name).FirstOrDefault();
			vPosition = context.Positions.Where(p => p.Id == select_visitor.PositionId).Select(s => s.Name).FirstOrDefault();
			vDescription = context.Descriptions.Where(d => d.Id == select_visitor.DescriptionId).Select(s => s.Name).FirstOrDefault();
			vPhoneMobile = select_visitor.PhoneNumber;
			vPhoneWork = select_visitor.WorkPhone;
			vEmail = select_visitor.Email;
			vRegDate = select_visitor.DateCreated.ToString();
			vExhibit = context.Exhibits.Where(e => e.Id == select_visitor.ExhibitId).Select(s => s.Name).FirstOrDefault();
			vRaport = context.Raports.Where(r => r.Id == select_visitor.RaportId).Select(s => s.Name).FirstOrDefault();
			vCity = context.Cities.Where(c => c.Id == select_visitor.CityId).Select(s => s.Name).FirstOrDefault();
			vStatus = select_visitor.Status;
			vBarcode = select_visitor.BarCode;
		}



	}


}
