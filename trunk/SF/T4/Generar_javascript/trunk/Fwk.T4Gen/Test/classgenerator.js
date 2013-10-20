 
					

 
		

var simplecarviewmodel = function()
{
		var self = this;

		self.$type = 'Test.ViewModels.SimpleCarViewModel, Models';

				self.Brand = ko.observable();
						self.Model = ko.observable();
						self.id = ko.observable();
						self.isactive = ko.observable();
				


   this.Initialize();

}

       
		

var optionviewmodel = function()
{
		var self = this;

		self.$type = 'Fwk.Bases.ViewModels.OptionViewModel, Models';

				self.name = ko.observable();
						self.catalogprice = ko.observable();
						self.id = ko.observable();
						self.isactive = ko.observable();
				


   this.Initialize();

}

       
		

var carviewmodel = function()
{
		var self = this;

		self.$type = 'Test.CarViewModel, Models';

				self.Co2 = ko.observable();
						self.Importdate = ko.observable();
						self.Options = ko.observableArray();
						self.Availableyears = ko.observableArray();
						self.Availablecountries = ko.observableArray();
						self.id = ko.observable();
						self.isactive = ko.observable();
				


   this.Initialize();

}

       
 



