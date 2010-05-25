function sendData(ty,elements,esp)
{       if(typeof(XMLHttpRequest)!='undefined')
		{	try { var petel = new XMLHttpRequest();  } 
			catch(exepcion){  }
        }    
		else
		{	try {  var petel = new ActiveXObject('Microsoft.XMLHTTP');  } 
			catch(excepcion){  var petel = new ActiveXObject('Msxml2.XMLHTTP');  }
        }
		try{ petel.open('POST','../../ajax/sendrequest.php?hash=' + Math.random(),esp );  }
        catch(excepcion){  return false;    }
        petel.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        elements= 'type=' + ty + '&' + elements;
		petel.send(elements);
       	return true;      
}