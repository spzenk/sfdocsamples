

function RateArticle(textbox, combo)
{
		try
	{
		var oBtn = textbox;
		oBtn.load(oBtn.value);
		
		if(oBtn.getAttribute("PB" + oBtn.value) == null)
		{
			
			if(SaveData(oBtn,combo.value))
				return true;
			else
			{
				alert("Error en la votacion!");
				return false;
			}
		}
		else
		{				
			alert("Usted ya ha votado este articulo!");				
			return false;
		}
	}
	catch(ex)
	{
		alert(ex.message);
			if(SaveData(oBtn, combo.value))
				return true;
			else
			{
				alert("Error en la votacion!");
				return false;
			}			
	}
}//RateArticle
//---------------------------------------------
function SaveData(control, calif)
{
	try
	{
		control.setAttribute("PB" + control.value , calif);
		control.save(control.value);
		return true;
	}
	catch(ex)
	{					
		return false;				
	}
}//SaveData		

