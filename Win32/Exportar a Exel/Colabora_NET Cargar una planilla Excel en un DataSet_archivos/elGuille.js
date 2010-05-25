// FlashObject
// Para que se vean los Flash sin necesidad de activarlos.
// Puesto para usar con los banners de Microsoft (McCann) (23/Ago/06 15.11)
//
/**
 * FlashObject v1.3d: Flash detection and embed - http://blog.deconcept.com/flashobject/
 *
 * FlashObject is (c) 2006 Geoff Stearns and is released under the MIT License:
 * http://www.opensource.org/licenses/mit-license.php
 *
 */
if(typeof com=="undefined"){var com=new Object();}
if(typeof com.deconcept=="undefined"){com.deconcept=new Object();}
if(typeof com.deconcept.util=="undefined"){com.deconcept.util=new Object();}
if(typeof com.deconcept.FlashObjectUtil=="undefined"){com.deconcept.FlashObjectUtil=new Object();}
com.deconcept.FlashObject=function(_1,id,w,h,_5,c,_7,_8,_9,_a,_b){
if(!document.createElement||!document.getElementById){return;}
this.DETECT_KEY=_b?_b:"detectflash";
this.skipDetect=com.deconcept.util.getRequestParameter(this.DETECT_KEY);
this.params=new Object();
this.variables=new Object();
this.attributes=new Array();
this.useExpressInstall=_7;
if(_1){this.setAttribute("swf",_1);}
if(id){this.setAttribute("id",id);}
if(w){this.setAttribute("width",w);}
if(h){this.setAttribute("height",h);}
if(_5){this.setAttribute("version",new com.deconcept.PlayerVersion(_5.toString().split(".")));}
this.installedVer=com.deconcept.FlashObjectUtil.getPlayerVersion(this.getAttribute("version"),_7);
if(c){this.addParam("bgcolor",c);}
var q=_8?_8:"high";
this.addParam("quality",q);
var _d=(_9)?_9:window.location;
this.setAttribute("xiRedirectUrl",_d);
this.setAttribute("redirectUrl","");
if(_a){this.setAttribute("redirectUrl",_a);}
};
com.deconcept.FlashObject.prototype={setAttribute:function(_e,_f){
this.attributes[_e]=_f;
},getAttribute:function(_10){
return this.attributes[_10];
},addParam:function(_11,_12){
this.params[_11]=_12;
},getParams:function(){
return this.params;
},addVariable:function(_13,_14){
this.variables[_13]=_14;
},getVariable:function(_15){
return this.variables[_15];
},getVariables:function(){
return this.variables;
},createParamTag:function(n,v){
var p=document.createElement("param");
p.setAttribute("name",n);
p.setAttribute("value",v);
return p;
},getVariablePairs:function(){
var _19=new Array();
var key;
var _1b=this.getVariables();
for(key in _1b){_19.push(key+"="+_1b[key]);}
return _19;
},getFlashHTML:function(){
var _1c="";
if(navigator.plugins&&navigator.mimeTypes&&navigator.mimeTypes.length){
if(this.getAttribute("doExpressInstall")){
this.addVariable("MMplayerType","PlugIn");
}
_1c="<embed type=\"application/x-shockwave-flash\" src=\""+this.getAttribute("swf")+"\" width=\""+this.getAttribute("width")+"\" height=\""+this.getAttribute("height")+"\"";
_1c+=" id=\""+this.getAttribute("id")+"\" name=\""+this.getAttribute("id")+"\" ";
var _1d=this.getParams();
for(var key in _1d){_1c+=[key]+"=\""+_1d[key]+"\" ";}
var _1f=this.getVariablePairs().join("&");
if(_1f.length>0){_1c+="flashvars=\""+_1f+"\"";}
_1c+="/>";
}else{
if(this.getAttribute("doExpressInstall")){this.addVariable("MMplayerType","ActiveX");}
_1c="<object id=\""+this.getAttribute("id")+"\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" width=\""+this.getAttribute("width")+"\" height=\""+this.getAttribute("height")+"\">";
_1c+="<param name=\"movie\" value=\""+this.getAttribute("swf")+"\" />";
var _20=this.getParams();
for(var key in _20){_1c+="<param name=\""+key+"\" value=\""+_20[key]+"\" />";}
var _22=this.getVariablePairs().join("&");
if(_22.length>0){_1c+="<param name=\"flashvars\" value=\""+_22+"\" />";
}_1c+="</object>";}
return _1c;
},write:function(_23){
if(this.useExpressInstall){
var _24=new com.deconcept.PlayerVersion([6,0,65]);
if(this.installedVer.versionIsValid(_24)&&!this.installedVer.versionIsValid(this.getAttribute("version"))){
this.setAttribute("doExpressInstall",true);
this.addVariable("MMredirectURL",escape(this.getAttribute("xiRedirectUrl")));
document.title=document.title.slice(0,47)+" - Flash Player Installation";
this.addVariable("MMdoctitle",document.title);}
}else{this.setAttribute("doExpressInstall",false);}
if(this.skipDetect||this.getAttribute("doExpressInstall")||this.installedVer.versionIsValid(this.getAttribute("version"))){
var n=(typeof _23=="string")?document.getElementById(_23):_23;
n.innerHTML=this.getFlashHTML();
}else{if(this.getAttribute("redirectUrl")!=""){document.location.replace(this.getAttribute("redirectUrl"));}}}};
com.deconcept.FlashObjectUtil.getPlayerVersion=function(_26,_27){
var _28=new com.deconcept.PlayerVersion(0,0,0);
if(navigator.plugins&&navigator.mimeTypes.length){
var x=navigator.plugins["Shockwave Flash"];
if(x&&x.description){_28=new com.deconcept.PlayerVersion(x.description.replace(/([a-z]|[A-Z]|\s)+/,"").replace(/(\s+r|\s+b[0-9]+)/,".").split("."));}
}else{
try{var axo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash");
for(var i=3;axo!=null;i++){
axo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash."+i);
_28=new com.deconcept.PlayerVersion([i,0,0]);}}
catch(e){}
if(_26&&_28.major>_26.major){return _28;}
if(!_26||((_26.minor!=0||_26.rev!=0)&&_28.major==_26.major)||_28.major!=6||_27){
try{
_28=new com.deconcept.PlayerVersion(axo.GetVariable("$version").split(" ")[1].split(","));
}catch(e){}}}
return _28;
};
com.deconcept.PlayerVersion=function(_2c){
this.major=parseInt(_2c[0])||0;
this.minor=parseInt(_2c[1])||0;
this.rev=parseInt(_2c[2])||0;
};
com.deconcept.PlayerVersion.prototype.versionIsValid=function(fv){
if(this.major<fv.major){return false;}
if(this.major>fv.major){return true;}
if(this.minor<fv.minor){return false;}
if(this.minor>fv.minor){return true;}
if(this.rev<fv.rev){return false;}
return true;
};
com.deconcept.util={getRequestParameter:function(_2e){
var q=document.location.search||document.location.hash;
if(q){var _30=q.indexOf(_2e+"=");
var _31=(q.indexOf("&",_30)>-1)?q.indexOf("&",_30):q.length;
if(q.length>1&&_30>-1){
return q.substring(q.indexOf("=",_30)+1,_31);}}return "";
},removeChildren:function(n){
while(n.hasChildNodes()){
n.removeChild(n.firstChild);}}};
if(Array.prototype.push==null){
Array.prototype.push=function(_33){
this[this.length]=_33;
return this.length;};}
var getQueryParamValue=com.deconcept.util.getRequestParameter;
var FlashObject=com.deconcept.FlashObject;

//
//==========================================
// elGuille.js
// (c)Guillermo 'guille' Som, 1998-2006
// Última revisión:           (30/Mar/2006)
//==========================================
function validarGuille(valor){
	if(valor=="")
		return false;
    fBuscarGuille.B3.value=valor;
    fBuscarGuille.Op.value="150";
    return true;
}
function validarGuille2(valor){
	if(valor=="")
		return false;
    fBuscarGuille2.B3.value=valor;
    fBuscarGuille2.Op.value="150";
    return true;
}

document.write("<table border='1' width='100%'>" +
"  <tr>" +
"    <td valign='middle' align='middle' width='200' rowspan=2>" +
"       <a href='"+gsPath+"default.aspx'>" +
"       <img src='"+gsPath+"imagenes/el_guille.gif' alt='ir al indice principal' border='0'></a>" +
"    </td>" +
"    <td align='middle'>" +
"       <font face='Comic Sans MS' color='#000080' size='4'><strong>el Guille, la Web del Visual Basic, C#, .NET y m&aacute;s...</strong></font>" +
"    </td>" +
"  </tr>" +
"   <tr>" +
"       <td align='middle' height=20 background='"+gsPath+"imagenes/barra_grisclaro.png'><b><font face='Verdana' size='1'>&nbsp;"+
"       <a href='"+gsPath+"lonuevo/lo_nuevo0611.aspx'><acronym title='Lo Nuevo de este mes'>Lo Nuevo</acronym></a> -" +
"       <a href='"+gsPath+"NET/vs2005/default.aspx'><acronym title='El indice de punto NET 2.0 y Visual Studio 2005'>VS2005</acronym></a> -" +
"       <a href='"+gsPath+"NET/default.aspx'><acronym title='El indice de punto NET'>.NET</acronym></a> -" +
"       <a href='"+gsPath+"NET/ADONET/indiceADONET.asp'><acronym title='Bases de datos de punto NET'>ADO.NET</acronym></a> -" +
"       <a href='"+gsPath+"NET/ASPNET/indiceASPNET.aspx'><acronym title='Paginas y servicios Web en punto NET'>ASP.NET</acronym></a> -" +
"       <a href='"+gsPath+"NET/comodotnet.htm'><acronym title='Como... en punto NET'>C&oacute;mo...</acronym></a> -" +
"       <a href='"+gsPath+"colabora/colaboraNET.htm'><acronym title='Las colaboraciones'>Colabora</acronym></a> -" +
"       <a href='"+gsPath+"vb/default.aspx'><acronym title='El indice de VB6'>VB6</acronym></a> -" +
"       <a href='"+gsPath+"vb/VB_API.HTM'><acronym title='API de Windows (VB6)'>API</acronym></a> -" +
"       <a href='"+gsPath+"vb/bases/ADO/indiceADO.htm'><acronym title='Bases de datos VB6'>Bases</acronym></a> -" +
"       <a href='"+gsPath+"HTMLscripts/HTML_TIP.HTM'><acronym title='Lenguajes Scripts y HTML'>HTML</acronym></a> -" +
"       <a href='"+gsPath+"sistema/sistema.htm'><acronym title='Articulos y trucos para Windows'>Sistema</acronym></a> -" +
"       <a href='"+gsPath+"otrositios/otros_sitios.htm'><acronym title='Otros sitios'>Links</acronym></a>&nbsp;</font></b>" +
"       </td>" +
"   </tr>" +
"</table>");
// Mostrar alternando lo que había con lo del hosting (07/Mar/06)
var hoyBanArriba = new Date();
var mBanSegundos = hoyBanArriba.getSeconds(); // .getMinutes();
var bannerMSjul = false;

// Para probar el anuncio del sponsor
//mBanSegundos = 1
//mBanSegundos = 56

if( mBanSegundos < 10 ) // 0-9 (10)
{
// Anuncio Libro
document.write(""+
"<div align=center><h2><a href='" + gsPath + "NET/MIVB2005/comprar.asp'>Compra mi libro Visual Basic 2005</a></h2></div>");
}
else if( mBanSegundos < 20 ) // 10-19 (10)
{
document.write(""+
"<div align=center><h1><a href='http://aniversario.elguille.info/' target='_blank'>El sitio del Guille cumple 10 a&ntilde;os !!!</a></h1></div>");
}
else if( mBanSegundos < 25 ) // 20-24 (5)
{
// Búsqueda y foros
document.write("<hr noshade size=3>" +
"<div align=center><form name='fBuscarGuille' method='POST' onsubmit='return validarGuille(T1.value);' action='" + gsPath + "buscar.aspx' target ='buscar'>"+
"<input type='hidden' name='B3' value=''>" +
"<input type='hidden' name='Op' value='150'>" +
"<font face=Verdana size=2><b>Resuelve tus dudas: <a href='http://foros.elguille.info/' target=_blank>Entra en los foros del Guille</a>"+
"&nbsp;&nbsp;&nbsp;o busca en el Guille: </b>" +
"<input type='text' name='T1' size='20' maxlength='150' style='padding:0; position: relative; height: 20; width: 150'>&nbsp;" + 
"<input type='image' src='" + gsPath + "imagenes/IrDerRXP28.jpg' " + 
"alt=' Busqueda simple en el Guille.info (puedes indicar varias palabras usando AND y OR)'" + 
" border='0' width='25' height='25' name='enviar' align='absbottom' style='height: 24px'>" +
"&nbsp;&nbsp;<a href='" + gsPath + "buscarAv.aspx' target='buscar'><font size=1><b><acronym title='Busqueda avanzada en elGuille'>BuscarAv</acronym></b></font></a></font>" +
"</form></div>");
}
else if( mBanSegundos < 35 ) // 25-34 (10)
{
// Oferta foros a 4.95
document.write("<div align='center'>"+
"	<table border='0' bordercolor='#000000' width='100%' style='border-collapse: collapse' id='tableHosting01'>"+
"		<tr>"+
"			<td align='center' bgcolor='#F0F0F0'>&nbsp;<br>"+
"<b><font size='5'><font color='#FF0000'>OFERTA</font> de <a href='"+gsPath+"hostings/elguille_ofertas_hosting.asp'>alojamiento</a> .NET 2.0, SQL Server desde 4.95 Eur</font></b>"+
"<br>&nbsp;"+
"			</td>"+
"		</tr>"+
"	</table>"+
"</div>");
}
else if( mBanSegundos < 40 ) // 35-39 (5)
{
// Oferta foros a 2.95
document.write("<div align='center'>"+
"	<table border='0' bordercolor='#000000' width='100%' style='border-collapse: collapse' id='tableHosting00'>"+
"		<tr>"+
"			<td align='center' bgcolor='#F0F0F0'>&nbsp;<br>"+
"<b><font size='5'><font color='#FF0000'>La OFERTA</font> de <a href='"+gsPath+"hostings/elguille_ofertas_hosting.asp'>alojamiento</a> <font color='#FF0000'>m&aacute;s econ&oacute;mica</font>: 2.95 Eur</font></b>"+
"<br>&nbsp;"+
"			</td>"+
"		</tr>"+
"	</table>"+
"</div>");
}
else if( mBanSegundos < 50 ) // 40-49 (10)
{
// Microsoft 01/Jul/06 al 30/Sep/06
bannerMSjul = true;
document.write(""+
"<center>"+
"<div id='flashcontent'>"+
" <embed src='"+gsPath+"sponsors/ms_notas.swf' quality=high pluginspage='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash' width='300' height='250' loop='false' scale='exactfit'></embed>"+
"</div><script type='text/javascript'>"+
"   var mymovie = new FlashObject('"+gsPath+"sponsors/ms_notas.swf', 'pelicula', '300', '250', '7', '#ffffff');"+
"   mymovie.addParam('menu', 'false');"+
"   mymovie.addParam('scale', 'noscale');"+
"   /*mymovie.addParam('wmode', 'transparent'); */  // Quitar los comentarios de ser necesario"+
"   mymovie.write('flashcontent');"+
"</script>"+
"</center>"+
"");
}
else // 51-59 (10)
{
// Microsoft 01/Jul/06 al 30/Sep/06
bannerMSjul = true;
document.write(""+
"<center>"+
"<div id='flashcontent'>"+
" <embed src='"+gsPath+"sponsors/ms_moscas.swf' quality=high pluginspage='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash' width='300' height='250' loop='false' scale='exactfit'></embed>"+
"</div><script type='text/javascript'>"+
"   var mymovie = new FlashObject('"+gsPath+"sponsors/ms_moscas.swf', 'pelicula', '300', '250', '7', '#ffffff');"+
"   mymovie.addParam('menu', 'false');"+
"   mymovie.addParam('scale', 'noscale');"+
"   /*mymovie.addParam('wmode', 'transparent'); */  // Quitar los comentarios de ser necesario"+
"   mymovie.write('flashcontent');"+
"</script>"+
"</center>"+
"");
}